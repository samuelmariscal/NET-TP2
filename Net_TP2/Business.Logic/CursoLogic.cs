﻿using Data.Database;
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

        public DataTable DameCursosAInscribir(int idPlan, int usrID)
        {
            return CursoData.GetCursosAInscribir(idPlan, usrID);
        }

        public void ActualizarCurso(int idCurso,int cupo)
        {
            int cupoActualizado = cupo - 1;
            CursoData.UpdateCurso(idCurso, cupoActualizado);
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
    }
}
