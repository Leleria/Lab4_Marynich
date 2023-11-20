using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Marynich_Lib
{
    public class WorkerDB
    {
        public static string connectString;

        static SqlConnection myConnection;

        static string SQLServerName = @"KIT-ПК\SQL2022";
        static string dataBaseName = "testingDBLab4";

        public void OpenConnection()
        {
            connectString = @"Data Source=" + SQLServerName + ";Initial Catalog=" + dataBaseName + ";Integrated Security=true;";
            myConnection = new SqlConnection(connectString);
            myConnection.Open();
        }
        public List<string[]> GetByID(int id)
        {
            List<string[]> result = new List<string[]>();
            string query = $"select * from TestTable where id = '{id}';";
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows == false)
            {
                string[] str = new string[1];
                str[0] = "Запись с таким ID не найдена";
                result.Add(str);
                return result;
            }
            else
            {
                while (reader.Read())
                {
                    result.Add(new string[reader.FieldCount]);
                    for (int i = 0; i < reader.FieldCount; i++)
                        result[result.Count - 1][i] = reader[i].ToString();

                }
                reader.Close();
            }
          
            return result;

        }
        public List<string[]> GetByName(string name)
        {
            List<string[]> result = new List<string[]>();
            string query = $"select * from TestTable where name = '{name}';";
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows == false)
            {
                string[] str = new string[1];
                str[0] = "Запись с таким именем не найдена";
                result.Add(str);
                return result;
            }
            else
            {
                while (reader.Read())
                {
                    result.Add(new string[reader.FieldCount]);
                    for (int i = 0; i < reader.FieldCount; i++)
                        result[result.Count - 1][i] = reader[i].ToString();

                }
                reader.Close();
            }
            
            return result;
        }

        public string Add(int id, string name, string message)
        {
            if (name == null || message == null)
            {
                return "Данные должны быть заполнены";
            }
            else
            {
                string query = $"insert into TestTable values('{id}', '{name}', '{message}');";
                SqlCommand command = new SqlCommand(query, myConnection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                return "Данные добавлены в базу";
            }
        }

        public string Update(int id, string message)
        {
            string query1 = $"select * from TestTable where id = '{id}';";
            SqlCommand command1 = new SqlCommand(query1, myConnection);
            SqlDataReader reader = command1.ExecuteReader();
            if (reader.HasRows == false)
            {
                reader.Close();
                return "Запись с таким ID не найдена";
            }
            else
            {
                reader.Close();
                string query = $"update TestTable set message = '{message}' where ID = {id}";
                SqlCommand command = new SqlCommand(query, myConnection);
                SqlDataReader reader1 = command.ExecuteReader();
                reader1.Close();
                return "Запись успешно обновлена";
            }

        }
        public string Delete(int id)
        {

            string query1 = $"select * from TestTable where id = '{id}';";
            SqlCommand command1 = new SqlCommand(query1, myConnection);
            SqlDataReader reader = command1.ExecuteReader();
            if (reader.HasRows == false)
            {
                reader.Close();
                return "Запись с таким ID не найдена";
            }
            else
            {
                reader.Close();
                string query = $"delete from TestTable where ID = '{id}';";
                SqlCommand command = new SqlCommand(query, myConnection);
                SqlDataReader reader1 = command.ExecuteReader();
                reader1.Close();
                return "Запись удалена успешно";
            }
        }
        public void CloseConnection()
        {
            myConnection.Close();
        }
    }
}
