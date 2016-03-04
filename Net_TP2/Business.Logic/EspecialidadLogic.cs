using Business.Entities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class EspecialidadLogic:BusinessLogic
    {
        EspecialidadAdapter EspecialidadData;

        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }
        public DataTable DameEspecialidades()
        {
            return EspecialidadData.GetAll();
        }

        public void Delete(int id)
        {
            try
            {
                EspecialidadData.Delete(id);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }

        public void Save(Especialidad EspecialidadActual)
        {
            EspecialidadData.Save(EspecialidadActual);
        }

        public Especialidad GetOne(int idEspecialidad)
        {
            return EspecialidadData.GetOne(idEspecialidad);
        }


        public DataTable GetAll()
        {
            return EspecialidadData.GetAll();
        }
    }
}
