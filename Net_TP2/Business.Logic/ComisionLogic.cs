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
    public class ComisionLogic:BusinessLogic
    {
        ComisionAdapter ComisionData;
        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }
        public DataTable DameComisiones(int idPlan)
        {
            return ComisionData.GetAll(idPlan);
        }

        public void Save(Comision ComisionActual)
        {
            ComisionData.Save(ComisionActual);
        }

        public Entities.Comision GetComision(int idCom)
        {
            return ComisionData.GetOne(idCom);
        }


        public void Delete(int id)
        {
            try
            {
                ComisionData.Delete(id);
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
