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
            
            if (Session["korisnik"] != null)
            {
                var KorisnickoIme = Session["korisnik"].ToString();
                korisnik.Text = KorisnickoIme;
                //prijava.Visible = false;
                //odjava.Visible = true;
            }
            else
            {
                //prijava.Visible = true;
                //odjava.Visible = false;
            }
  
        }

        public void OdjavaClick(object sender, System.EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Default.aspx");
        }
        [WebMethod]
        [ScriptMethod]
        public static void SpremiKoordinate(Koordinate koordinate)
        { 
            string constr = ConfigurationManager.ConnectionStrings["MapaCNSTR"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Koordinate VALUES(@Duzina, @Sirina, @Opis, @Korisnik_Id, @urlSlika)"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Duzina", koordinate.Duzina);
                    cmd.Parameters.AddWithValue("@Sirina", koordinate.Sirina);
                    cmd.Parameters.AddWithValue("@Opis", koordinate.Opis);
                    cmd.Parameters.AddWithValue("@Korisnik_Id", HttpContext.Current.Session["id"].ToString());
                    cmd.Parameters.AddWithValue("@urlSlika", koordinate.Slika);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        protected void BtnUnos_Click(object sender, EventArgs e)
        {
            var koordinate = new Koordinate();
            var path = "";
            if (System.IO.File.Exists(Server.MapPath("~/Images/" + fileUpload.Value)))
                {
                path = "~/ Images / " + fileUpload.Value.Insert(fileUpload.Value.IndexOf("."), "2");
                    fileUpload.PostedFile.SaveAs(Server.MapPath(path));
                    
                }
                else
                {
                path = "~/Images/" + fileUpload.Value;
                    fileUpload.PostedFile.SaveAs(Server.MapPath(path));
                   
                }

          
            koordinate.Sirina = sirina.Value;
            koordinate.Duzina = duzina.Value;
            koordinate.Opis = opis.Value;
            koordinate.Slika = path;
            SpremiKoordinate(koordinate);
        }
    }
}