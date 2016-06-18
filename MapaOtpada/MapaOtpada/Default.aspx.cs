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
    public class Koordinate
    {
        public float Duzina { get; set; }
        public float Sirina { get; set; }
        public string Opis { get; set; }
    }
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["korisnik"] != null)
            {
                var KorisnickoIme = Session["korisnik"].ToString();
                korisnik.Text = KorisnickoIme;
                prijava.Visible = false;
                odjava.Visible = true;
            }
            else
            {
                prijava.Visible = true;
                odjava.Visible = false;
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
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Koordinate VALUES(@Duzina, @Sirina, @Opis)"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Duzina", koordinate.Duzina);
                    cmd.Parameters.AddWithValue("@Sirina", koordinate.Sirina);
                    cmd.Parameters.AddWithValue("@Opis", koordinate.Opis);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

    }
}