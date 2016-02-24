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
    public partial class CursosComisiones : ApplicationForm
    {
        public CursosComisiones()
        {
            InitializeComponent();
            dgvCursos.AutoGenerateColumns = false;
            Listar();
        }

        private void Listar()
        {
            try
            {
                PlanLogic pl = new PlanLogic();
                cmbPlanes.ValueMember = "id_plan";
                cmbPlanes.DisplayMember = "desc_plan";
                cmbPlanes.DataSource = pl.GetAll();
                ComisionLogic cl = new ComisionLogic();
                cmbComision.ValueMember = "id_comision";
                cmbComision.DisplayMember = "desc_comision";
                cmbComision.DataSource = cl.DameComisiones((int)cmbPlanes.SelectedValue);
                CursoLogic curl = new CursoLogic();
                btnAddCurso.Enabled = false;
                btnEliminarCurso.Enabled = false;
                btnModificarCurso.Enabled = false;
                dgvCursos.DataSource = curl.DameCursos((int)cmbComision.SelectedValue);
            }
            catch(NullReferenceException nre)
            {
                dgvCursos.DataSource = "";
                btnAddCurso.Enabled = false;
                btnEliminarCurso.Enabled = false;
                btnModificarCurso.Enabled = false;
            }
        }

        private void CursosComisiones_Load(object sender, EventArgs e)
        {

        }

        private void cmbPlanes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ComisionLogic cl = new ComisionLogic();
                cmbComision.ValueMember = "id_comision";
                cmbComision.DisplayMember = "desc_comision";
                cmbComision.DataSource = cl.DameComisiones((int)cmbPlanes.SelectedValue);
                CursoLogic curl = new CursoLogic();
                dgvCursos.DataSource = curl.DameCursos((int)cmbComision.SelectedValue);
                btnAddCurso.Enabled = true;
            }
            catch(NullReferenceException nre)
            {
                dgvCursos.DataSource = "";
                btnAddCurso.Enabled = false;
                btnEliminarCurso.Enabled = false;
                btnModificarCurso.Enabled = false;
            }
        }

        private void cmbComision_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CursoLogic curl = new CursoLogic();
            dgvCursos.DataSource = curl.DameCursos((int)cmbComision.SelectedValue);
        }

        private void btnAdmComision_Click(object sender, EventArgs e)
        {
            Comisiones c = new Comisiones((int)cmbPlanes.SelectedValue);
            c.Show();
        }

        private void btnAddCurso_Click(object sender, EventArgs e)
        {
            CursoDesktop ca = new CursoDesktop((int)cmbPlanes.SelectedValue, (int)cmbComision.SelectedValue,ModoForm.Alta);
            ca.ShowDialog();
        }

        private void dgvCursos_SelectionChanged(object sender, EventArgs e)
        {
            btnModificarCurso.Enabled = true;
            btnEliminarCurso.Enabled = true;
            btnAddCurso.Enabled = true;
        }

        private void btnModificarCurso_Click(object sender, EventArgs e)
        {
            int idCurso = (int)dgvCursos.CurrentRow.Cells[0].Value;
            int idCom = (int)dgvCursos.CurrentRow.Cells[4].Value;
            int idPlan = (int)cmbPlanes.SelectedValue;
            CursoDesktop cd = new CursoDesktop(idCurso,idPlan,idCom, ModoForm.Modificacion);
            cd.Show();
        }

        private void btnEliminarCurso_Click(object sender, EventArgs e)
        {
            CursoLogic cl = new CursoLogic();
            int id = (int)dgvCursos.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("¿Está seguro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                cl.Delete(id);
            this.Listar();
        }
    }
}
