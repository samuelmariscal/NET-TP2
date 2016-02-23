<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="UI.Web.Administrador.AltaUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplCenter" runat="server">

   <form id="formAlta" runat="server">
        <ul class="nav nav-tabs" id="tablist">
        <li class="alert-link"><a href="Admin.aspx">Home</a></li>
        <li class="alert-link"><a href="Usuarios.aspx">Ver Usuarios</a></li>
        <li class="alert-link"><a href="Administrador/Especialidades.aspx">Especialidades</a></li>
        <li class="alert-link"><a href="Administrador/PlanMateria.aspx">Planes y Materias</a></li>
        <li class="alert-link"><a href="Administrador/CursoComisiones.aspx">Cursos y Comisiones</a></li>
        <li class="alert-link"><a href="Login.aspx">Cerrar Sesión</a></li>
    </ul>
       <br />
       <br />
       <br />
       
        <div class="form-group">
           <label>Nombre:</label>
           <asp:TextBox runat="server" type="text" class="form-control" id="txtNombre" />
           <label>Apellido:</label>
           <asp:TextBox runat="server" type="text" class="form-control" id="txtApellido" />
            <label>Legajo:</label>
           <asp:TextBox runat="server" type="text" class="form-control" id="txtLegajo" />
            <label>Email:</label>
           <asp:TextBox runat="server" type="text" class="form-control" id="txtEmail" />
            <label>Dirección:</label>
           <asp:TextBox runat="server" type="text" class="form-control" id="txtDireccion" />
            <label>Telefono:</label>
            <asp:TextBox runat="server" type="text" class="form-control" ID="txtTelefono"/>
            <label>Tipo Persona:</label>
            <asp:DropDownList ID="ddlsTipoPersona" runat="server" Height="20px" Width="125px"></asp:DropDownList>
            <br />
            <label>Plan:</label>
            <asp:DropDownList runat="server" ID="ddlPlan" Height="20px" Width="125px"></asp:DropDownList><br />
            <label>Fecha de nacimiento:</label>
            <asp:TextBox runat="server" ID="txtFechaNacimiento" class="form-control"></asp:TextBox>
            <br /> <br />
            <p>
            <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" />
                        
            <asp:Button runat="server" ID="btnVolver" Text="Volver" />
             </p>
        </div>
       
   </form>


</asp:Content>
