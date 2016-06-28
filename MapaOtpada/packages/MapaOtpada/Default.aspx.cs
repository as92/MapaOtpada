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
using System.Web.Mvc;
using System.IO;


namespace MapaOtpada
{
    public class Koordinate
    {
        public string Duzina { get; set; }
        public string Sirina { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }

    }
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["korisnik"] != null)//sessionu dodajemo vrijednosti u prijava.aspx.cs
            {
                var ime = Session["ime"].ToString();
                korisnik.Text = "Dobrodošli, "+ime+"!";
                prijava.Visible = false;
                odjava.Visible = true;
                korisnik.Visible = true;
                if (Session["tip"].ToString() == "admin")
                {
                    BtnPromijeniStanje.Visible = true;
                }
            }
            else
            {
                prijava.Visible = true;
                odjava.Visible = false;
                korisnik.Visible = false;
            }
            
  
        }

        public void OdjavaClick(object sender, System.EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Default.aspx");
        }

        public void PromijeniStanje(object sender, System.EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["MapaCNSTR"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("IF (Select Stanje from Koordinate where Id=@Marker_Id)=1" +
                    "DELETE FROM Koordinate where Id=@Marker_Id;" +
                   "ELSE UPDATE Koordinate SET Stanje=1 WHERE Id = @Marker_Id;"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Marker_Id", markerId.Value);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("Default.aspx");
                }
            }
        }

        public void SpremiKoordinate(Koordinate koordinate)
        { 
            string constr = ConfigurationManager.ConnectionStrings["MapaCNSTR"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Koordinate VALUES(@Duzina, @Sirina, @Opis, @Korisnik_Id, @urlSlika, @Stanje)"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Duzina", koordinate.Duzina);
                    cmd.Parameters.AddWithValue("@Sirina", koordinate.Sirina);
                    cmd.Parameters.AddWithValue("@Opis", koordinate.Opis);
                    cmd.Parameters.AddWithValue("@Korisnik_Id", HttpContext.Current.Session["id"].ToString());
                    cmd.Parameters.AddWithValue("@urlSlika", koordinate.Slika);
                    cmd.Parameters.AddWithValue("@Stanje", 0);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("Default.aspx?spremi=ok");

                }
            }
        }

        protected void BtnUnos_Click(object sender, EventArgs e)
        {
            //Sliku uploadamo na server u direkotrij Images
            var koordinate = new Koordinate();
            var path = "";
            if (System.IO.File.Exists(Server.MapPath("~/Images/" + fileUpload.Value)))
            {
                path = "~/Images/" + fileUpload.Value;
                //ako postoji slika sa istim nazivom na serveru
                //necemo je spremiti ponovno nego cemo samo na ovu novu koordinatu
                //dodati njenu putanju
                //mogući problem su različite slike sa istim nazivom

            }
            else
            {
                path = "~/Images/" + fileUpload.Value;
                fileUpload.PostedFile.SaveAs(Server.MapPath(path));
            }
            koordinate.Sirina = sirina.Value;
            koordinate.Duzina = duzina.Value;
            koordinate.Opis = opis.Value;
            koordinate.Slika = path.Replace("~", "");
            //U bazu spremimo URL od slike
            SpremiKoordinate(koordinate);
        }
    }
}