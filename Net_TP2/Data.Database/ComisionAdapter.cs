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
    public class ComisionAdapter:Adapter
    {

        public System.Data.DataTable GetAll(int idPlan)
        {
            this.OpenConnection();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("select * from comisiones where id_plan=@id", SqlConn);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = idPlan;
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(dt);
            this.CloseConnection();
            return dt;
        }

        public void Add(Business.Entities.Comision c)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmdSave = new MySqlCommand("insert into comisiones (anio_especialidad,desc_comision,id_plan)" +
                "values (@anio_especialidad,@desc_comision,@id_plan)", SqlConn);

                cmdSave.Parameters.Add("@anio_especialidad", MySqlDbType.Int32).Value = c.AnioEspecialidad;
                cmdSave.Parameters.Add("@desc_comision", MySqlDbType.VarChar,50).Value = c.Descripcion;
                cmdSave.Parameters.Add("@id_plan", MySqlDbType.Int32).Value = c.IDPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
        }

        public Comision GetOne(int idCom)
        {
            Comision c = new Comision();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("select * from comisiones where id_comision = @id", SqlConn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = idCom;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    c.Descripcion = (string)dr["desc_comision"];
                    c.AnioEspecialidad = (int)dr["anio_especialidad"];
                    c.IDPlan = (int)dr["id_plan"];
                    c.ID = (int)dr["id_comision"];
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return c;
        }

        public void Save(Business.Entities.Comision ComisionActual)
        {
            if (ComisionActual.State == BusinessEntity.States.New)
            {
                this.Insert(ComisionActual);
            }
            else if (ComisionActual.State == BusinessEntity.States.Deleted)
            {
                this.Delete(ComisionActual.ID);
            }
            else if (ComisionActual.State == BusinessEntity.States.Modified)
            {
                this.Update(ComisionActual);
            }
            ComisionActual.State = BusinessEntity.States.Unmodified;
        }

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmdDelete =
                    new MySqlCommand("delete from comisiones where id_comision=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        private void Insert(Comision ComisionActual)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmdSave = new MySqlCommand("insert into comisiones (desc_comision,anio_especialidad,id_plan) " +
                "values (@desc_comision,@anio_especialidad,@id_plan)", SqlConn); //esta linea es para recuperar el id que mysql asigno automaticamente

                cmdSave.Parameters.Add("@desc_comision", MySqlDbType.VarChar, 50).Value = ComisionActual.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", MySqlDbType.Int32).Value = ComisionActual.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", MySqlDbType.Int32).Value = ComisionActual.IDPlan;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear la comision", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
        }

        private void Update(Comision ComisionActual)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmdSave = new MySqlCommand("UPDATE comisiones " +
                "set desc_comision =@desc_comision, anio_especialidad = @anio_especialidad, " +
                "id_plan = @id_plan " +
                "WHERE id_comision=@id", SqlConn);

                cmdSave.Parameters.Add("@id", MySqlDbType.Int32).Value = ComisionActual.ID;
                cmdSave.Parameters.Add("@desc_comision", MySqlDbType.VarChar, 50).Value = ComisionActual.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", MySqlDbType.Int32).Value = ComisionActual.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", MySqlDbType.Int32).Value = ComisionActual.IDPlan;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la comision", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
