<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Administrador.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplCenter" runat="server">
    <form id="form1" runat="server">
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
    <b style="text-align:center">Listado de Usuarios</b>
       <center>
           <div style="justify-content:center">
            <asp:GridView ID="dgvUsuarios" runat="server" AutoGenerateColumns="False" Width="616px" onrowcommand="dgvUsuarios_RowCommand">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" />
                    <asp:BoundField DataField="TipoPersona" HeaderText="Tipo Usuario" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:ButtonField Text="BAJA" ButtonType="Button" HeaderText="Baja" CommandName="btnBaja" />
                    <asp:ButtonField Text="MODIFICAR" ButtonType="Button" HeaderText="Modificar" CommandName="btnModificar"   />
                </Columns>

            </asp:GridView>
           <br />
           <p>
               <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" />
           </p>
        </div>
       </center>
    </form>

</asp:Content>
