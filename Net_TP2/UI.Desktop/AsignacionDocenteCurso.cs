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
    public partial class AsignacionDocenteCurso : ApplicationForm
    {
        public AsignacionDocenteCurso()
        {
            InitializeComponent();
            Listar();
        }

        private void Listar()
        {
            CursoLogic cl= new CursoLogic();
            dgvCursos.AutoGenerateColumns = false;
            dgvCursos.DataSource = cl.DameCursos();
        }

        private void AsignacionDocenteCurso_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCursosInscriptos_Click(object sender, EventArgs e)
        {
            CursosDocente cd = new CursosDocente();
            cd.Show();
        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            CursoLogic cl = new CursoLogic();
            int idCurso = (int)dgvCursos.CurrentRow.Cells[0].Value;
            if (cl.ValidarCurso(idCurso, UsuarioSesion.Sesion.ID).Rows.Count == 0)
            {
                AsignacionDocenteDesktop add = new AsignacionDocenteDesktop(idCurso);
                add.Show();
            }
            else
            {
                MessageBox.Show("Usted ya esta inscripto en este curso");
            }

        }
    }
}
