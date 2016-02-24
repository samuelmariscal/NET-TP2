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
    public partial class CursoDesktop : ApplicationForm
    {
        private int plan, comision;
        private ModoForm modoForm;
        private Curso _cursoActual;
        public Curso CursoActual
        {
            get
            {
                return _cursoActual;
            }
            set
            {
                _cursoActual = value;
            }
        }

        public CursoDesktop()
        {
            InitializeComponent();
        }
        public CursoDesktop(int idPlan, int idComision, ModoForm modo): this()
        {
            this.modoForm = modo;
            comision = idComision;
            plan = idPlan;
        }
        public CursoDesktop(int idCurso,int idPlan, int idComision, ModoForm modo): this()
        {
            CursoLogic cl = new CursoLogic();
            this.modoForm = modo;
            comision = idComision;
            plan = idPlan;
            CursoActual = cl.GetOne(idCurso);
            this.MapearDeDatos();
        }

        private void CursoAdd_Load(object sender, EventArgs e)
        {
            Listar();
        }
        public override void MapearDeDatos()
        {
            this.txtComision.Text = this.CursoActual.Descripcion;
            this.txtCupo.Text = (this.CursoActual.Cupo).ToString();
            this.txtDescr.Text = this.CursoActual.Descripcion;
        }
        public override void MapearADatos()
        {
            if (modoForm == ModoForm.Alta)
            {
                Curso c = new Curso();
                CursoActual = c;
                c.Descripcion = this.txtDescr.Text;
                c.IDComision = int.Parse(this.txtComision.Text);
                c.IDMateria = (int)cmbMateria.SelectedValue;
                c.Cupo = int.Parse(txtCupo.Text);
                this.CursoActual.State = BusinessEntity.States.New;
            }
            else if (modoForm == ModoForm.Modificacion)
            {
                this.CursoActual.IDComision = int.Parse(this.txtComision.Text);
                this.CursoActual.Descripcion = this.txtDescr.Text;
                this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                this.CursoActual.IDMateria = (int)this.cmbMateria.SelectedValue;
                this.CursoActual.State = BusinessEntity.States.Modified;
            }
        }
        private void Listar()
        {
            this.txtComision.Text = comision.ToString();
            this.cmbMateria.DataSource = new MateriaLogic().GetAll(plan, comision);
            this.cmbMateria.DisplayMember = "desc_materia";
            this.cmbMateria.ValueMember = "id_materia";
        }

        public override bool Validar()
        {
            if (this.txtCupo.Text == "" || this.txtDescr.Text == "")
            {
                Notificar("Error", "Todos los campos deben estar completos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            CursoLogic cl = new CursoLogic();
            cl.Save(CursoActual);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                    GuardarCambios();
                this.Dispose();
            }
            catch (Exception ex)
            {
                Notificar("Error de ingreso", "Hay campos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
