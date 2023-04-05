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
            Program pr = new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("Koneksi Ke Database");
                    Console.WriteLine("Masukkan User ID : ");
                    string user = Console.ReadLine();
                    Console.WriteLine("Masukkan Password : ");
                    string pass = Console.ReadLine();
                    Console.WriteLine("Masukkan Database Tujuan : ");
                    string db = Console.ReadLine();
                    Console.Write("\nKetik K untuk terhubung ke Database");
                    char chr = Convert.ToChar(Console.ReadLine());
                    switch (chr)
                    {
                        case 'K':
                            {
                                //Buat Koneksi
                                SqlConnection conn = null;
                                string strkoneksi = "data source=Willy\\amiin;" +
                                "initial catalog = {0};" +
                                "user ID = {1}; password = {2}";
                                conn = new SqlConnection(string.Format(strkoneksi, db, user, pass));

                                conn.Open();
                                Console.Clear();
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine("\nMenu");
                                        Console.WriteLine("1. Melihat seluruh Data");
                                        Console.WriteLine("2. Tambah Data");
                                        Console.WriteLine("3. Keluar");
                                        Console.Write("\nEnter your choice (1-3): ");
                                        char ch = Convert.ToChar(Console.ReadLine());
                                        switch (ch)
                                        {
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("DATA MAHASISWA\n");
                                                    Console.WriteLine();
                                                    pr.baca(conn);
                                                }
                                                break;
                                            case '2':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("INPUT DATA MAHASISWA\n");
                                                    Console.WriteLine("Masukkan ID Calon Mahasiswa :");
                                                    string id_Calon = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Nama Mhasiswa :");
                                                    string NmaMhs = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Alamat Mahasiswa :");
                                                    string Almt = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Jenis Kelamin  (L/P) : ");
                                                    string jk = Console.ReadLine();
                                                    Console.WriteLine("Masukkan No Telepon : ");
                                                    string notlpn = Console.ReadLine();
                                                    try
                                                    {
                                                        pr.insert(NIM, NmaMhs, Almt, jk, notlpn, conn);
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\nAnda tidak memiliki akses untuk menambah data");
                                                    }
                                                }
                                                break;
                                            case '3':
                                                conn.Close();
                                                return;
                                            default:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("\nInvalid Option");
                                                }
                                                break;

                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("\nCheck for the value entered.");
                                    }
                                }
                            }
                    }
                }
            }
        }
    }
}
