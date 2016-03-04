using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Business.Entities;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        public DataTable GetAll()
        {
            this.OpenConnection();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM planes";
            MySqlCommand cmd = new MySqlCommand(query, SqlConn);
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(dt);
            this.CloseConnection();
            return dt;
        }

            
        public Plan GetOne(int id)
        {
            Plan p = new Plan();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("select * from planes where id_plan = @idplan", SqlConn);
                cmd.Parameters.Add("@idplan", MySqlDbType.Int32).Value = id;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    p.Descripcion = (string)dr["desc_plan"];
                    p.IDEspecialidad = (int)dr["id_especialidad"];
                    p.ID = (int)dr["id_plan"];
                }
                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return p;
        }

        public void Add(Plan p)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmdSave = new MySqlCommand("insert into planes (desc_plan,id_especialidad) " +
                "values (@desc_plan,@id_especialidad)", SqlConn); 

                cmdSave.Parameters.Add("@desc_plan", MySqlDbType.VarChar, 50).Value = p.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", MySqlDbType.Int32).Value = p.IDEspecialidad;
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


        public void Add(Plan p, List<Materia> materias)
        {
            this.OpenConnection();
            MySqlTransaction trans = SqlConn.BeginTransaction();
            try
            {                
                long idPlan;
                {
                    MySqlCommand cmd = new MySqlCommand("insert into planes (desc_plan,id_especialidad) " +
                    "values (@desc_plan,@id_especialidad)", SqlConn,trans);
                    cmd.Parameters.Add("@desc_plan", MySqlDbType.VarChar, 50).Value = p.Descripcion;
                    cmd.Parameters.Add("@id_especialidad", MySqlDbType.Int32).Value=p.IDEspecialidad;
                    cmd.ExecuteNonQuery();
                    idPlan = cmd.LastInsertedId;
                    cmd.Parameters.Clear();                    
                }               
                foreach (var materia in materias)
                {
                    {
                        MySqlCommand cmd = new MySqlCommand("insert into materias (desc_materia, hs_semanales, hs_totales, id_plan) "+
                            "values (@desc_materias,@hs_semanales,@hs_totales,@id_plan)", SqlConn, trans);
                        cmd.Parameters.Add("@desc_materias", MySqlDbType.VarChar, 50).Value = materia.Descripcion;
                        cmd.Parameters.Add("@hs_semanales", MySqlDbType.Int32).Value = materia.HSSemanales;
                        cmd.Parameters.Add("@hs_totales", MySqlDbType.Int32).Value = materia.HSTotales;
                        cmd.Parameters.Add("@id_plan", MySqlDbType.Int32).Value = idPlan;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }                
                trans.Commit();
            }
            catch(Exception Ex)
            {
                trans.Rollback();
                Exception ExcepcionManejada = new Exception("Error al crear el plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        
    }
}
