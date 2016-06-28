using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.Web.Script.Services;

namespace MapaOtpada
{
    public partial class Template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var forma_marker = "";
            if (Session["korisnik"] != null && Session["tip"].ToString() != "admin")
            {
                //event za desni klik na mapu
                forma_marker = @"
                            google.maps.event.addListener(map,'rightclick', function(e) {
                            showSpremi(e.latLng.lat, e.latLng.lng); 
                            });";

            }
           
            Literal1.Text = @"<script type='text/javascript'>
                               function initialize() {
                                    var myLatlng = new google.maps.LatLng(43.511390686035156, 16.475044250488281);
                                    var mapOptions = {
                                    zoom: 14,
                                    center: myLatlng,
                                    mapTypeControl: true,
                                    scaleControl: true,
                                    mapTypeControlOptions: {
                                        style: google.maps.MapTypeControlStyle.DROPDOWN_MENU
                                    },
                                    navigationControl: true,
                                    navigationControlOptions: {
                                    style: google.maps.NavigationControlStyle.DEFAULT
                                    },
                                    mapTypeId: google.maps.MapTypeId.ROADMAP,
                                    backgroundColor: 'white'
                                    }
                                    var map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions); 
                                    " + forma_marker+ @"
                                    " + CitajKoordinate()+ @"
                                       map.controls[google.maps.ControlPosition.LEFT_BOTTOM].push(
                                         document.getElementById('legend'));

                                    }
                                    google.maps.event.addDomListener(window, 'load', initialize);
                                     </script>"; //funkcija za inicijalizaciju google mape, dodaje markere na mapu nakon što se stranica učita
             }

        public string CitajKoordinate()
        {
            var markers = "";
            var constr = ConfigurationManager.ConnectionStrings["MapaCNSTR"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Koordinate.Id,sirina,duzina,opis, urlSlika, Stanje, Korisnik.Ime, Korisnik.Prezime FROM Koordinate INNER JOIN Korisnik on Korisnik_Id = Korisnik.Id")) 
                    /*dohvacamo sve iz tablice koordinate gdje je ID od korisnika iz tablice
                    korisnik jednak Korisnik_Id iz tablice koordinate*/
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            
                            markers +=
                            @"  koordinate = new google.maps.LatLng(" + reader["Sirina"].ToString().Replace(',', '.') + "," + reader["Duzina"].ToString().Replace(',', '.') + @")
                                overlay = new CustomMarker(
		                        koordinate, 
		                        map,
		                        {
			                        marker_id:" + reader["id"].ToString() + @",
                                    opis:'" + reader["opis"].ToString() + @"',
                                    slika:'" + reader["urlSlika"].ToString() + @"',
                                    stanje:'" + reader["Stanje"].ToString() + @"',
                                    ime:'" + reader["Ime"].ToString() + @"',
                                    prezime:'" + reader["Prezime"].ToString() + @"'
		                        }
                            );";
                        }
                    }
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return markers;// vraca string sa marker id, opison, slikon, stanjem, imenom i prezimenon to korisitmo u Literal1.text
        }
    }
}