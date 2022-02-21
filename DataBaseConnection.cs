using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class DataBaseConnection
    {
        static String cons = @"Data Source=RILPT181;Initial Catalog=Test;User ID=sa;Password=sa123";
        public void AddNewBotuque(botuque Botuque)
        {
            using (SqlConnection con = new SqlConnection(cons))
            {
                var query = "INSERT INTO botuque VALUES(@ClothBrand,@ClothSize,@ClothPrice)";
                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@ClothId", Botuque.ClothId);
                cmd.Parameters.AddWithValue("@ClothBrand", Botuque.ClothBrand);
                cmd.Parameters.AddWithValue("@ClothSize", Botuque.ClothSize);
                cmd.Parameters.AddWithValue("@ClothPrice", Botuque.ClothPrice);
                try
                {
                    con.Open();
                    int b = cmd.ExecuteNonQuery();
                    if (b == 0)
                        throw new Exception("details not added");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }
        public List<botuque> GetCloths()
        {
            var list = new List<botuque>();
            using (SqlConnection con = new SqlConnection(cons))
            {
                try
                {
                    con.Open();
                    SqlCommand sqlCmd = con.CreateCommand();
                    sqlCmd.CommandText = "SELECT * FROM botuque";
                    var reader = sqlCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var Bot = new botuque();
                        Bot.ClothId = Convert.ToInt32(reader[0]);
                        Bot.ClothBrand = reader[1].ToString();
                        Bot.ClothSize = Convert.ToInt32(reader[2]);
                        Bot.ClothPrice = Convert.ToInt32(reader[3]);
                            list.Add(Bot);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return list;
        }
      

        public void UpdateBotuque(botuque Botuque)
        {
            using (SqlConnection con = new SqlConnection(cons))
            {
                var query = $"UPDATE botuque SET ClothBrand ='{Botuque.ClothBrand}', ClothSize = '{Botuque.ClothSize}', ClothPrice = '{Botuque.ClothPrice}' WHERE ClothId = {Botuque.ClothId}";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new Exception("no details were updated");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void DeleteBotuque(int id)
        {

            using (SqlConnection con = new SqlConnection(cons))
            {
                try
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM botuque WHERE ClothId = " + id;
                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows == 0)
                        throw new Exception("Cannot Delete botuque");
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }

    }
}








