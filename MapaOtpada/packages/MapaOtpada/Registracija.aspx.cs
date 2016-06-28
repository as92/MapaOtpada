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
using System.Security.Cryptography;
using System.Text;

namespace MapaOtpada
{
    public partial class Registracija : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void RegisterButtonClick(object sender, System.EventArgs e)
        {
            //upis u bazu i redirect na prijavu
            var constr = ConfigurationManager.ConnectionStrings["MapaCNSTR"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Korisnik VALUES(@Ime, @Prezime, @KorisnickoIme, @Lozinka, @Email, @Tip)"))
                {
                    using (MD5 md5Hash = MD5.Create())
                    {
                        string hash = GetMd5Hash(md5Hash, TbSifra.Text);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Ime", TbIme.Text);
                        cmd.Parameters.AddWithValue("@Prezime", TbPrezime.Text);
                        cmd.Parameters.AddWithValue("@KorisnickoIme", TbKor.Text);
                        cmd.Parameters.AddWithValue("@Lozinka", hash);
                        cmd.Parameters.AddWithValue("@Email", TbEmail.Text);
                        cmd.Parameters.AddWithValue("@Tip", "korisnik");
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            Response.Redirect("Prijava.aspx");
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}