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
    public class CursoAdapter:Adapter
    {

        public DataTable GetAll(int idCom)
        {
            this.OpenConnection();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("select * from cursos where id_comision = @id", SqlConn);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = idCom;
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(dt);
            this.CloseConnection();
            return dt;
        }

        public DataTable GetCursosAInscribir(int idPlan, int idUsr)
        {
            this.OpenConnection();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM cursos inner join comisiones inner join materias "+
                "on cursos.id_comision=comisiones.id_comision and cursos.id_materia=materias.id_materia "+
                "where materias.id_plan=@id and cursos.cupo>=0 and id_curso not in "+
                "(select id_curso from alumnos_inscripciones where id_alumno=@id_usr)", SqlConn);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = idPlan;
            cmd.Parameters.Add("@id_usr", MySqlDbType.Int32).Value = idUsr;
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(dt);
            this.CloseConnection();
            return dt;
        }

        public void UpdateCupoCurso(int idCurso, int cupoActualizado)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmdSave = new MySqlCommand("UPDATE cursos " +
                "set cupo =@cupo " +
                "WHERE id_curso=@id", SqlConn);
                cmdSave.Parameters.Add("@id", MySqlDbType.Int32).Value = idCurso;
                cmdSave.Parameters.Add("@cupo", MySqlDbType.Int32).Value = cupoActualizado;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
        }
        private void UpdateCurso(Curso CursoActual)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmdSave = new MySqlCommand("UPDATE cursos " +
                "set cupo =@cupo, descripcion=@descripcion, id_materia=@id_materia " +
                "WHERE id_curso=@id", SqlConn);
                cmdSave.Parameters.Add("@id", MySqlDbType.Int32).Value = CursoActual.ID;
                cmdSave.Parameters.Add("@cupo", MySqlDbType.Int32).Value = CursoActual.Cupo;
                cmdSave.Parameters.Add("@descripcion", MySqlDbType.VarChar,50).Value = CursoActual.Descripcion;
                cmdSave.Parameters.Add("@id_materia", MySqlDbType.Int32).Value = CursoActual.IDMateria;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmdDelete =
                    new MySqlCommand("delete from cursos where id_curso=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public DataTable GetAll()
        {
            this.OpenConnection();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("select * from cursos c inner join comisiones com on c.id_comision=com.id_comision", SqlConn);
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(dt);
            this.CloseConnection();
            return dt;
        }

        public DataTable GetAlumnosDocente(int id_docente)
        {
            this.OpenConnection();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM docentes_cursos inner join alumnos_inscripciones inner join personas " +
                "on docentes_cursos.id_curso=alumnos_inscripciones.id_curso and alumnos_inscripciones.id_alumno=personas.id_persona " +
                "where id_docente=@id" , SqlConn);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id_docente;
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(dt);
            this.CloseConnection();
            return dt;
        }

        public void AddCurso(Business.Entities.Curso c)
        {
            this.OpenConnection();
            MySqlCommand cmd = new MySqlCommand("insert into cursos(anio_calendario,cupo,descripcion,id_comision,id_materia) values (@anio,@cupo,@desc,@com,@mat)", SqlConn);
            cmd.Parameters.Add("@anio", MySqlDbType.Int32).Value = c.AnioCalendario;
            cmd.Parameters.Add("@cupo", MySqlDbType.Int32).Value = c.Cupo;
            cmd.Parameters.Add("@desc", MySqlDbType.VarChar, 50).Value = c.Descripcion;
            cmd.Parameters.Add("@com", MySqlDbType.Int32).Value = c.IDComision;
            cmd.Parameters.Add("@mat", MySqlDbType.Int32).Value = c.IDMateria;

            cmd.ExecuteNonQuery();

            this.CloseConnection();
        }

        public Business.Entities.Curso GetOne(int idCurso)
        {
            Curso c = new Curso();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("select * from cursos where id_curso = @id", SqlConn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = idCurso;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    c.Descripcion = (string)dr["descripcion"];
                    c.Cupo = (int)dr["cupo"];
                    c.ID = (int)dr["id_curso"];
                    c.IDMateria = (int)dr["id_materia"];
                    c.AnioCalendario = (int)dr["anio_calendario"];
                    c.IDComision = (int)dr["id_comision"];
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
            return c;
        }

        public void Save(Curso CursoActual)
        {
            if (CursoActual.State == BusinessEntity.States.New)
            {
                this.AddCurso(CursoActual);
            }
            else if (CursoActual.State == BusinessEntity.States.Deleted)
            {
                this.Delete(CursoActual.ID);
            }
            else if (CursoActual.State == BusinessEntity.States.Modified)
            {
                this.UpdateCurso(CursoActual);
            }
            CursoActual.State = BusinessEntity.States.Unmodified; 
        }



        public DataTable ValidarCurso(int idCurso, int usrID)
        {
            this.OpenConnection();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("select * from docentes_cursos where id_curso = @idCurso and id_docente=@usrID", SqlConn);
            cmd.Parameters.Add("@idCurso", MySqlDbType.Int32).Value = idCurso;
            cmd.Parameters.Add("@usrID", MySqlDbType.Int32).Value = usrID;
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(dt);
            this.CloseConnection();
            return dt;
        }

        public DataTable GetAllRep()
        {
            this.OpenConnection();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("select c.id_curso, c.anio_calendario, c.cupo, c.descripcion, c.id_materia, com.desc_comision, " +
                "p.nombre, p.apellido from cursos c left join docentes_cursos dc on c.id_curso=dc.id_curso " +
                "left join personas p on p.id_persona=dc.id_docente left join comisiones com on com.id_comision=c.id_comision "+
                "group by c.id_curso", SqlConn);            
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(dt);
            this.CloseConnection();
            return dt;
        }
    }
}
