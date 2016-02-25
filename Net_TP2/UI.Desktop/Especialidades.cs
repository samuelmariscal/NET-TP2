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
    public partial class Especialidades : ApplicationForm
    {
        public Especialidades()
        {
            InitializeComponent();
            dgvEspecialidades.AutoGenerateColumns = false;
            Listar();
        }

        private void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            dgvEspecialidades.DataSource = el.DameEspecialidades();
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop ed = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            ed.Show();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                EspecialidadLogic el = new EspecialidadLogic();
                int idEsp = (int)dgvEspecialidades.CurrentRow.Cells[0].Value;
                if (MessageBox.Show("¿Está seguro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    el.Delete(idEsp);
                    Listar();
                }
            }
            catch(Exception Ex)
            {
                Notificar("Error", Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            int id = (int)dgvEspecialidades.CurrentRow.Cells[0].Value;
            EspecialidadDesktop ed = new EspecialidadDesktop(id, ApplicationForm.ModoForm.Modificacion);
            ed.Show();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
