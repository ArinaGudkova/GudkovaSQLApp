using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GudkovaSQLApp
{
    internal class DB
    {

        //Подключение БД
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;user=root;password=root;database=journal_articles");

        public void openConnect()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();

            }

        }
        public void closeConnect()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();

            }
        }
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}


