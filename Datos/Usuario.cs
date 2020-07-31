using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Usuario
    {

        MySqlConnection cn;

        public DataSet mostrar()
        {
            try
            {
                cn = new Conexion().IniciarConexion();

                MySqlCommand comando = new MySqlCommand("Select * from usuario ", cn);
                MySqlDataAdapter datos = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();

                datos.Fill(ds);

                return ds;


            }
            catch (MySqlException ex)
            {
                Console.WriteLine("" + ex);
                return null;
            }
            finally
            {
                cn.Close();
            }
        }

        public void Insertar(string id, string nombre, string telefono)
        {
            try
            {
                cn = new Conexion().IniciarConexion();

                MySqlCommand comando = new MySqlCommand($"INSERT INTo Usuario values({id}, '{nombre}', {telefono})", cn);
                comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public string[] Buscar(string id)
        {
            try
            {
                cn = new Conexion().IniciarConexion();

                MySqlCommand comando = new MySqlCommand($"select * from usuario where id={id}", cn);
                MySqlDataReader reader = comando.ExecuteReader();

                String[] datos = new String[3];

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        datos[0] = reader.GetString(0);
                        datos[1] = reader.GetString(1);
                        datos[2] = reader.GetString(2);

                    }

                    reader.Close();
                }

                return datos;

            }
            catch (MySqlException ex)
            {
                return null;
                throw;
            }
        }

        public void Actualizar(string id, string nombre, string telefono) {

            try
            {
                cn = new Conexion().IniciarConexion();

                MySqlCommand comando = new MySqlCommand($"Update Usuario set nombre= '{nombre}', telefono ={telefono} where id={id}", cn);
                comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

        }

        public void Eliminar(string id)
        {
            try
            {
                cn = new Conexion().IniciarConexion();

                MySqlCommand comando = new MySqlCommand($"delete from usuario where id={id}", cn);
                comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
        }

    }
}
