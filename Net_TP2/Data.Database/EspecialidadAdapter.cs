using Business.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class EspecialidadAdapter:Adapter
    {
        public DataTable GetAll()
        {
            this.OpenConnection();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM especialidades";
            MySqlCommand cmd = new MySqlCommand(query, SqlConn);
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(dt);
            this.CloseConnection();
            return dt;
        }

        public void Delete(int id)
        {
            try
            {
                //abrimos la conexion
                this.OpenConnection();

                //creamos la sentencia sql yield asignamos un valor al parametro
                MySqlCommand cmdDelete =
                    new MySqlCommand("delete from especialidades where id_especialidad=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                //ejecutamos la sentencia sql
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar especialidad. Asegurese que no tenga asignado ningun plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Business.Entities.Especialidad EspecialidadActual)
        {
            if (EspecialidadActual.State == BusinessEntity.States.New)
            {
                this.Insert(EspecialidadActual);
            }
            else if (EspecialidadActual.State == BusinessEntity.States.Deleted)
            {
                this.Delete(EspecialidadActual.ID);
            }
            else if (EspecialidadActual.State == BusinessEntity.States.Modified)
            {
                this.Update(EspecialidadActual);
            }
            EspecialidadActual.State = BusinessEntity.States.Unmodified;
        }

        private void Update(Especialidad EspecialidadActual)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmdSave = new MySqlCommand("UPDATE especialidades " +
                "set desc_especialidad =@desc_especialidad WHERE id_especialidad=@id", SqlConn);

                cmdSave.Parameters.Add("@id", MySqlDbType.Int32).Value = EspecialidadActual.ID;                
                cmdSave.Parameters.Add("@desc_especialidad", MySqlDbType.VarChar, 50).Value = EspecialidadActual.Descripcion;                
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la especialidad", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
        }

        private void Insert(Especialidad EspecialidadActual)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmdSave = new MySqlCommand("insert into especialidades (desc_especialidad)" +
                "values (@desc_especialidad)", SqlConn); //esta linea es para recuperar el id que mysql asigno automaticamente

                cmdSave.Parameters.Add("@desc_especialidad", MySqlDbType.VarChar, 50).Value = EspecialidadActual.Descripcion;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear especialidad", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
        }

        public Especialidad GetOne(int idEspecialidad)
        {
            Especialidad esp = new Especialidad();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("select * from especialidades where id_especialidad = @idespecialidad", SqlConn);
                cmd.Parameters.Add("@idespecialidad", MySqlDbType.Int32).Value = idEspecialidad;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    esp.ID = (int)dr["id_especialidad"];
                    esp.Descripcion = (string)dr["desc_especialidad"];
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return esp;
        }
    }
}
