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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        private int id;
        private ModoForm modoForm;
        private Especialidad _especialidadActual;

        public Especialidad EspecialidadActual
        {
            get 
            {
                return _especialidadActual;
            }
            set
            {
                _especialidadActual = value;
            }
        }

        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(int id, ModoForm modoForm)
        {
            InitializeComponent();
            this.id = id;
            this.modoForm = modoForm;
            EspecialidadLogic el = new EspecialidadLogic();
            if (modoForm == ModoForm.Baja)
            {
                el.Delete(id);
            }
            else
            {
                EspecialidadActual = el.GetOne(id);
                this.MapearDeDatos();
            }  
        }

        public EspecialidadDesktop(ModoForm modoForm)
        {
            InitializeComponent();
            this.modoForm = modoForm;
        }

        private void EspecialidadDesktop_Load(object sender, EventArgs e)
        {

        }
        public override void MapearDeDatos()
        {
            this.txtDescEspecialidad.Text = this.EspecialidadActual.Descripcion;
        }
        public override void MapearADatos()
        {
            if (modoForm == ModoForm.Alta)
            {
                Especialidad e = new Especialidad();
                EspecialidadActual = e;
                e.Descripcion = this.txtDescEspecialidad.Text;
                this.EspecialidadActual.State = BusinessEntity.States.New;
            }
            else if (modoForm == ModoForm.Modificacion)
            {
                this.EspecialidadActual.Descripcion = this.txtDescEspecialidad.Text;
                this.EspecialidadActual.State = BusinessEntity.States.Modified;
            }
        }
        public override bool Validar()
        {
            if (txtDescEspecialidad.Text == "")
            {
                Notificar("Error", "El campo es obligatorio!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            EspecialidadLogic el = new EspecialidadLogic();
            el.Save(EspecialidadActual);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
                GuardarCambios();
            this.Dispose();
        }
    }
}
