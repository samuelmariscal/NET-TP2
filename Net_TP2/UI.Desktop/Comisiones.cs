using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Comisiones : ApplicationForm
    {
        private int idPlan;
        public Comisiones(int idPlan)
        {
            InitializeComponent();
            this.idPlan = idPlan;
            Listar();
        }

        private void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            dgvComisiones.AutoGenerateColumns = false;
            dgvComisiones.DataSource = cl.DameComisiones(idPlan);
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop cd = new ComisionDesktop(idPlan, ModoForm.Alta);
            cd.Show();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            int idCom = (int)dgvComisiones.CurrentRow.Cells[0].Value;
            ComisionDesktop cd = new ComisionDesktop(idCom,ModoForm.Modificacion);
            cd.Show();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ComisionLogic cl = new ComisionLogic();
                int id = (int)dgvComisiones.CurrentRow.Cells[0].Value;
                if (MessageBox.Show("¿Está seguro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    cl.Delete(id);
                this.Listar();
            }
            catch(Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
