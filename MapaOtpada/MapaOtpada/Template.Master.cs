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
            var addMarker = "";
            if (Session["korisnik"] != null)
            {
                addMarker = @"google.maps.event.addListener(map,'rightclick', function(e) {
                            // 3 seconds after the center of the map has changed, pan back to the
                            // marker.
                            //alert(e.latLng);
                             writeToDatabase(e.latLng.lat(), e.latLng.lng(), 'Kakav opis makni se');
		                    console.log('Širina: '+e.latLng.lat()+' i Dužina: '+e.latLng.lng());
                            id = e.latLng.lat()+e.latLng.lng()
		                    addMarkers(id, map, e.latLng);    
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
" + addMarker+ @"
" + CitajKoordinate()+@"
}
google.maps.event.addDomListener(window, 'load', initialize);
                              </script>";
        }

        public string CitajKoordinate()
        {
            var markers = "";
            var tocke = new List<Koordinate>();
            string constr = ConfigurationManager.ConnectionStrings["MapaCNSTR"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id,sirina,duzina,opis FROM Koordinate"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var i = 0;
                        while (reader.Read())
                        {
                            i++;
                            markers +=
                            @"  koordinate = new google.maps.LatLng(" + reader["Sirina"].ToString().Replace(',','.') + "," + reader["Duzina"].ToString().Replace(',', '.') + @")
                                overlay = new CustomMarker(
		                        koordinate, 
		                        map,
		                        {
			                        marker_id:" + reader["id"].ToString() + @"
		                        }
                            );";
                        }
                    }
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return markers;
        }
    }
}