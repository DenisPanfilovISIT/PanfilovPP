using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WcfServiceLibrary1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        DataSet ds;
        SqlDataAdapter adapter;
        string conn = @"Data Source=DENISPANFILOV;Initial Catalog=PPlab2;Integrated Security=True";
       
        //всех записей
        public DataSet AllClients()
        {
            string proc = "AllClients";
            using(SqlConnection con=new SqlConnection(conn))
            {
                con.Open();
                adapter = new SqlDataAdapter(proc, con);
                ds = new DataSet();
                adapter.Fill(ds, "Client");
                con.Close();
            }
            return ds;
        }
        //получение одной записи
        public DataSet GetClient(int idClient)
        {
            string proc = "GetClient";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand command = new SqlCommand(proc, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter { ParameterName = "@idClient", Value = idClient };
                command.Parameters.Add(parameter);
                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                ds = new DataSet();
                table.Columns.Add("idClient");
                table.Columns.Add("fio");
                while (reader.Read())
                {
                    table.Rows.Add(reader.GetInt32(0), reader.GetString(1));
                }
                ds.Tables.Add(table);
                con.Close();
                return ds;
            }
        }
        //добавление
        public string InsClient(string fio)
        {
            string proc = "InsClient";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand command = new SqlCommand(proc, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter { ParameterName = "@fio", Value = fio };
                command.Parameters.Add(parameter);
                var result = command.ExecuteScalar();
                con.Close();
                return "Id добавленного клиента: " + result;
            }
        }
        //удаление
        public string DelClient(int idClient)
        {
            string proc = "DelClient";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand command = new SqlCommand(proc, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramete = new SqlParameter { ParameterName = "@idClient", Value = idClient };
                command.Parameters.Add(paramete);
                var result = command.ExecuteScalar();
                con.Close();
                return "Клиент удален";
            }
        }
        //обновление
        public string UpdClient(int idClient, string fio)
        {
            string proc = "UpdClient";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand command = new SqlCommand(proc, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramete = new SqlParameter { ParameterName = "@idClient", Value = idClient };
                command.Parameters.Add(paramete);
                SqlParameter paramete1 = new SqlParameter { ParameterName = "@fio", Value = fio };
                command.Parameters.Add(paramete1);
                var result = command.ExecuteScalar();
                con.Close();
                return "Клиент " + idClient + " обновлен";
            }
        }


        public DataSet AllZayavky()
        {
            string proc = "AllZayavky";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                adapter = new SqlDataAdapter(proc, con);
                ds = new DataSet();
                adapter.Fill(ds, "Zayavka");
                con.Close();
            }
            return ds;
        }

        public DataSet GetZayavka(int idZayavka)
        {
            string proc = "GetClient";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand command = new SqlCommand(proc, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter { ParameterName = "@idZayavka", Value = idZayavka };
                command.Parameters.Add(parameter);
                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                ds = new DataSet();
                table.Columns.Add("idZayavka");
                table.Columns.Add("fio");
                while (reader.Read())
                {
                    table.Rows.Add(reader.GetInt32(0), reader.GetString(1));
                }
                ds.Tables.Add(table);
                con.Close();
                return ds;
            }
        }

        public string InsZayavka(int idZayavka)
        {
            string proc = "InsZayavka";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand command = new SqlCommand(proc, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter { ParameterName = "@idZayavka", Value = idZayavka };
                command.Parameters.Add(parameter);
                var result = command.ExecuteScalar();
                con.Close();
                return "Id добавленной заявки: " + result;
            }
        }

        public string DelZayavka(int idZayavka)
        {
            string proc = "DelZayavka";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand command = new SqlCommand(proc, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramete = new SqlParameter { ParameterName = "@idZayavka", Value = idZayavka };
                command.Parameters.Add(paramete);
                var result = command.ExecuteScalar();
                con.Close();
                return "Заявка удалена";
            }
        }

        public string UpdZayavka(int idZayavka, int idClient)
        {
            string proc = "UpdZayavka";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand command = new SqlCommand(proc, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramete = new SqlParameter { ParameterName = "@idZayavka", Value = idZayavka };
                command.Parameters.Add(paramete);
                SqlParameter paramete1 = new SqlParameter { ParameterName = "@idClient", Value = idClient };
                command.Parameters.Add(paramete1);
                var result = command.ExecuteScalar();
                con.Close();
                return "Заявка " + idZayavka + " обновлена";
            }
        }


        public DataSet AllUsluga()
        {
            string proc = "AllUsluga";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                adapter = new SqlDataAdapter(proc, con);
                ds = new DataSet();
                adapter.Fill(ds, "Usluga");
                con.Close();
            }
            return ds;
        }

        public DataSet GetUsluga(int idUsluga)
        {
            string proc = "GetUsluga";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand command = new SqlCommand(proc, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter { ParameterName = "@idUsluga", Value = idUsluga };
                command.Parameters.Add(parameter);
                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                ds = new DataSet();
                table.Columns.Add("idUsluga");
                table.Columns.Add("nazvanie");
                table.Columns.Add("cena");
                while (reader.Read())
                {
                    table.Rows.Add(reader.GetInt32(0), reader.GetString(1),reader.GetInt32(2));
                }
                ds.Tables.Add(table);
                con.Close();
                return ds;
            }
        }

        public string InsUsluga(string nazvanie, int cena)
        {
            string proc = "InsUsluga";
            using (SqlConnection con = new SqlConnection(conn))
            {

                con.Open();
                SqlCommand command = new SqlCommand(proc, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter { ParameterName = "@nazvanie", Value = nazvanie };
                command.Parameters.Add(parameter);
                SqlParameter parameter1 = new SqlParameter { ParameterName = "@cena", Value = cena };
                command.Parameters.Add(parameter1);
                var result = command.ExecuteScalar();
                con.Close();
                return "Id добавленной услуги: " + result;
            }
        }

        public string DelUsluga(int idUsluga)
        {
            string proc = "DelUsluga";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand command = new SqlCommand(proc, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramete = new SqlParameter { ParameterName = "@idUsluga", Value = idUsluga };
                command.Parameters.Add(paramete);
                var result = command.ExecuteScalar();
                con.Close();
                return "Услуга удалена";
            }
        }

        public string UpdUsluga(int idUsluga, int cena)
        {
            string proc = "UpdUsluga";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand command = new SqlCommand(proc, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramete = new SqlParameter { ParameterName = "@idUsluga", Value = idUsluga };
                command.Parameters.Add(paramete);
                SqlParameter paramete1 = new SqlParameter { ParameterName = "@cena", Value = cena };
                command.Parameters.Add(paramete1);
                var result = command.ExecuteScalar();
                con.Close();
                return "Услуга " + idUsluga + " обновлена";
            }
        }


        public DataSet AllZayavkyUslugy()
        {
            string proc = "AllZayavkyUslugy";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                adapter = new SqlDataAdapter(proc, con);
                ds = new DataSet();
                adapter.Fill(ds, "Zayavka_Usluga");
                con.Close();
            }
            return ds;
        }

        public DataSet GetZayavkaUsluga(int id)
        {
            string proc = "GetZayavkaUsluga";
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand command = new SqlCommand(proc, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter { ParameterName = "@id", Value = id };
                command.Parameters.Add(parameter);
                SqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                ds = new DataSet();
                table.Columns.Add("zayavkaId");
                table.Columns.Add("uslugaId");
                while (reader.Read())
                {
                    table.Rows.Add(reader.GetString(0), reader.GetString(1));
                }
                ds.Tables.Add(table);
                con.Close();
                return ds;
            }
        }

        public string InsZayavkaUsluga(int zayavkaId, int uslugaId)
        {
            string proc = "InsZayavkaUsluga";
            using (SqlConnection con = new SqlConnection(conn))
            {

                con.Open();
                SqlCommand command = new SqlCommand(proc, con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter { ParameterName = "@zayavkaId", Value = zayavkaId };
                command.Parameters.Add(parameter);
                SqlParameter parameter1 = new SqlParameter { ParameterName = "@uslugaId", Value = uslugaId };
                command.Parameters.Add(parameter1);
                var result = command.ExecuteScalar();
                con.Close();
                return "Id добавленной заявки-услуги: " + result;
            }
        }
    }
}
