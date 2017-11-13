using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mantenimiento.CapaDatos
{
    class ConectorSQL
    {


        private MySqlConnection conexion;
        private string sConexion, server, db, user, pass;


        public ConectorSQL()
        {


        }

        public ConectorSQL(string server, string db, string user, string pass)
        {
            this.server = server;
            this.db = db;
            this.user = user;
            this.pass = pass;
        }


        public bool OpenConnection()
        {
            if (this.server != null || this.db != null || this.user != null || this.pass != null)
            {
                sConexion = "SERVER=" + this.server + ";" + "DATABASE=" +
                this.db + ";" + "UID=" + this.user + ";" + "PASSWORD=" + this.pass + ";";
            }
            else
            {
                sConexion = "SERVER=" + "localhost" + ";" + "DATABASE=" +
               "hotel_sancarlos" + ";" + "UID=" + "root" + ";" + "PASSWORD=" + "" + ";";

            }
            conexion = new MySqlConnection(sConexion);
            try
            {
                conexion.Open();
                //MessageBox.Show("Conectado a la base de datos");
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }


        //Close connection
        public bool CloseConnection()
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public DataTable informacion(string query)
        {
            DataTable info = new DataTable();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(query, sConexion);
            adaptador.Fill(info);
            return info;
        }
    }
}
