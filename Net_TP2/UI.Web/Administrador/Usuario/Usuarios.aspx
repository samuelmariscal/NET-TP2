<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Administrador.Usuarios" %>
<asp:Content ID="admin" ContentPlaceHolderID="adminCenter" runat="server">
    <form id="form1" runat="server">
    
    <br />
    <br />
    <br />
    <b style="text-align:center">Listado de Usuarios</b>
        <br />
        <br />
       <center>
           <div style="justify-content:center">
            <asp:GridView ID="dgvUsuarios" CssClass="table table-hover"  runat="server" AutoGenerateColumns="False" Width="616px" onrowcommand="dgvUsuarios_RowCommand">
                <Columns>
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="id" HeaderText="ID" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="TipoPersona" HeaderText="Tipo Usuario" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="apellido" HeaderText="Apellido" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="NombreUsuario" HeaderText="Usuario" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="email" HeaderText="Email" />
                    <asp:ButtonField HeaderStyle-Font-Size="Larger" ControlStyle-CssClass="btn btn-danger" Text="BAJA" ButtonType="Button" HeaderText="Baja" CommandName="btnBaja"/>
                    <asp:ButtonField HeaderStyle-Font-Size="Larger" ControlStyle-CssClass="btn btn-info" Text="MODIFICAR" ButtonType="Button" HeaderText="Modificar" CommandName="btnModificar"   />
                </Columns>

            </asp:GridView>
           
           <p>
               <asp:Button CssClass="btn btn-success" ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" />
           </p>
        </div>
       </center>
    </form>

</asp:Content>
