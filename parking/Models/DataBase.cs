using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Windows.Forms;

namespace parking.Models
{
    internal class DataBase
    {
        //Propiedades de la clase DataBase
        SqlCommand com;//encargado de ejecutar las consultas en la bd
        SqlDataReader reader;
        DataTable recordset;
        string query;

        //cadena de conexion a la base de datos


        //Metodo Find
        //consulta la base de datos
        public DataTable Find(string table, string fields, string condition = "", string orderby = "")
        {
            recordset = new DataTable();


            if (condition == "" && orderby == "")
            {
                query = "Select " + fields + " from " + table;
            }
            else if (condition != "" && orderby == "")
            {
                query = "Select " + fields + " from " + table + " where " + condition;
            }
            else if (condition == "" && orderby != "")
            {
                query = "Select " + fields + " from " + table + " order by " + orderby;
            }
            else if (condition != "" && orderby != "")
            {
                query = "Select " + fields + " from " + table + " where " + condition + " order by " + orderby;
            }

            try
            {
                com = new SqlCommand(query, Connection.ConSql);
                Connection.OpenConnection();

                reader = com.ExecuteReader();
                recordset.Load(reader);

                reader.Close();
                com.Dispose();
                Connection.CloseConnection();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                Connection.EndsConnection();
            }
            return recordset;
        }
        //Fin Metodo Find

        //Metodo Save
        //inserta registros en la base de datos
        public int Save(string table, string fields, string values)
        {
            int ra = 0; //rowsaffected
            query = "Insert into " + table + "(" + fields + ") values(" + values + ")";
            try
            {
                com = new SqlCommand(query, Connection.ConSql);
                Connection.OpenConnection();

                ra = com.ExecuteNonQuery();

                com.Dispose();
                Connection.CloseConnection();

            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                Connection.EndsConnection();
            }
            return ra;
        }
        //fin Metodo Save

        //Metodo Update
        //Actualizar los registros de la base de datos
        public int Update(string table, string values, string condition = "")
        {
            int ra = 0; //rowsaffected
            if (condition == "")
            {
                query = "Update " + table + " set " + values;
            }
            else
            {
                query = "Update " + table + " set " + values + " where " + condition;
            }

            try
            {
                com = new SqlCommand(query, Connection.ConSql);
                            Connection.OpenConnection();

                ra = com.ExecuteNonQuery();

                com.Dispose();
                Connection.CloseConnection();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                Connection.EndsConnection();
            }
            return ra;
        }
        //Actualiza registros existentes
        //Fin Metodo Update

        //Metodo Destroy
        //Elimina registros de la base de datos
        public int Destroy(string table, string condition = "")
        {
            int ra = 0;
            if (condition == "")
            {
                query = "Delete from " + table;
            }
            else
            {
                query = "Delete from " + table + " where " + condition;
            }

            try
            {
                com = new SqlCommand(query, Connection.ConSql);
                Connection.OpenConnection();

                ra = com.ExecuteNonQuery();

                com.Dispose();
                Connection.CloseConnection();

            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                Connection.EndsConnection();
            }
            return ra;
        }
        //Fin Metodo Destroy

        //Metodo JoinTables
        //Combina datos de dos o mas tablas 
        public DataTable JoinTables(string data, string condition = "", string orderby = "")
        {
            recordset = new DataTable();

            if (condition == "" && orderby == "")
            {
                query = "Select " + data;

            }
            else if (condition != "" && orderby == "")
            {
                query = "Select " + data + " where " + condition;

            }
            else if (condition != "" && orderby != "")
            {
                query = "Select " + data + " where " + condition + " order by " + orderby;

            }
            else if (condition == "" && orderby != "")
            {
                query = "Select " + data + " order by " + orderby;
            }

            try
            {
                com = new SqlCommand(query, Connection.ConSql);
                Connection.OpenConnection();

                reader = com.ExecuteReader();
                recordset.Load(reader);

                com.Dispose();
                reader.Close();
                Connection.CloseConnection();

            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                Connection.EndsConnection();
            }

            return recordset;
        }
        //Fin Metodo JoinTables

        //Metodo GetNextId
        //Generar un nuevo identificador
        public string GetNextId(string idmod)
        {
            string NextId = "";
            query = "Select ULTIMO + 1 AS NEXTID FROM CORRELATIVOS WHERE IDMOD= '" + idmod + "'";
            Int64 x = 0;

            try
            {
                com = new SqlCommand(query, Connection.ConSql);
                Connection.OpenConnection();
                reader = com.ExecuteReader();

                if (reader.Read())
                {
                    x = Convert.ToInt64(reader["NEXTID"].ToString());
                }
                else
                {
                    MessageBox.Show("Error al generar el identificador!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();
                com.Dispose();
                Connection.CloseConnection();


            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);

            }
            finally
            {
                Connection.EndsConnection();
            }

            if (x >= 0 && x <= 9)
            {
                NextId = "00000" + x.ToString();
            }
            else if (x >= 9 && x <= 99)
            {
                NextId = "0000" + x.ToString();
            }
            else if (x >= 100 && x <= 999)
            {
                NextId = "000" + x.ToString();

            }
            else if (x >= 1000 && x <= 9999)
            {
                NextId = "00" + x.ToString();
            }
            else if (x >= 10000 && x <= 99999)
            {
                NextId = "0" + x.ToString();
            }
            else if (x >= 100000 && x <= 999999)
            {
                NextId = x.ToString();

            }
            else
            {
                MessageBox.Show("Ha llegado al limite, contactar con el administrador!", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            return NextId;

        }
        //Fin GetNextId

        //Metodo SetLastId
        //Actualizar correlativo
        public void SetLastId(string idmod)
        {
            query = "UPDATE CORRELATIVOS SET ULTIMO= ULTIMO+1 WHERE IDMOD= '" + idmod + "' ";
            try
            {
                com = new SqlCommand(query, Connection.ConSql);
                Connection.OpenConnection();
                com.ExecuteNonQuery();

                com.Dispose();
                Connection.CloseConnection();

            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);

            }
            finally
            {
                Connection.EndsConnection();
            }
        }


        //Fin SetLastId

        //Metodo Hook
        //Recupera un dato especifico de una tabla en nuestra base de datos
        public string Hook(string tablename, string field, string condition)
        {
            string target = "";
            query = "Select " + field + " AS TARGET from " + tablename + " where " + condition;


            try
            {
                com = new SqlCommand(query, Connection.ConSql);
                Connection.OpenConnection();
                reader = com.ExecuteReader();

                if (reader.Read())
                {
                    target = reader["TARGET"].ToString();

                }
                else
                {
                    MessageBox.Show("Error al recuperar el dato seleccionado");
                }

                reader.Close();
                com.Dispose();
                Connection.CloseConnection();

            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);

            }
            finally
            {
                Connection.EndsConnection();
            }

            return target;
        }
        //Fin Metodo Hook

        public string CheckIfIdExist(string tablename, string condition)
        {
            string resp = "";
            query = "Select * from " + tablename + " where " + condition;

            try
            {
                com = new SqlCommand(query, Connection.ConSql);
                Connection.OpenConnection();
                reader = com.ExecuteReader();

                if (reader.Read())
                {
                    resp = "S";

                }
                else
                {
                    resp = "N";
                }

                reader.Close();
                com.Dispose();
                Connection.CloseConnection();

            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);

            }
            finally
            {
                Connection.EndsConnection();
            }


            return resp;



        }
    }
}
