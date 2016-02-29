using Data.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class CursoLogic:BusinessLogic
    {
        CursoAdapter CursoData;
        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public DataTable DameCursos(int idCom)
        {
            return CursoData.GetAll(idCom);
        }

        public DataTable ValidarCurso(int idCurso, int usrID)
        {
            return CursoData.ValidarCurso(idCurso, usrID);
        }

        public DataTable DameCursosAInscribir(int idPlan, int usrID)
        {
            return CursoData.GetCursosAInscribir(idPlan, usrID);
        }

        public void ActualizarCupoCurso(int idCurso,int cupo)
        {
            int cupoActualizado = cupo - 1;
            CursoData.UpdateCupoCurso(idCurso, cupoActualizado);
        }

        public DataTable DameCursos()
        {
            return CursoData.GetAll();
        }

        public DataTable DameAlumnosDocente(int id_docente)
        {
            return CursoData.GetAlumnosDocente(id_docente);
        }

        public void AddCurso(Entities.Curso c)
        {
            CursoData.AddCurso(c);
        }

        public void Save(Entities.Curso CursoActual)
        {
            CursoData.Save(CursoActual);
        }

        public Entities.Curso GetOne(int idCurso)
        {
            return CursoData.GetOne(idCurso);
        }

        public void Delete(int id)
        {
            CursoData.Delete(id);
        }

        public DataTable GetAllRep()
        {
           return CursoData.GetAllRep();
        }
    }
}
