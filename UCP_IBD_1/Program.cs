using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCP_IBD_1
{
    internal class Program
    {
        public void insert(string id_calon_mhs, string nama, string alamat, string no_telp, string ttl, string email, SqlConnection con)
        {
            string str = "";
            str = "insert into HRD.calon_mhs (idCalon_Mhs, Nama, Alamat, NoTelp, Ttl, Email)"
                + "values(@idCalon, @nma, @alamat, @Phn, @ttl, @email)";

            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("idCalon", id_calon_mhs));
            cmd.Parameters.Add(new SqlParameter("nma", nama));
            cmd.Parameters.Add(new SqlParameter("alamat", alamat));
            cmd.Parameters.Add(new SqlParameter("Phn", no_telp));
            cmd.Parameters.Add(new SqlParameter("ttl", ttl));
            cmd.Parameters.Add(new SqlParameter("email", email));

            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Berhasil Ditambahkan");
        }

        public void baca (SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select + from HRD.calon_mhs", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }
        
        static void Main(string[] args)
        {

        }
    }
}
