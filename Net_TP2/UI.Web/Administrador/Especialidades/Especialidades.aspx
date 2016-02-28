<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Administrador.Especialidades" %>
<asp:Content ID="admin" ContentPlaceHolderID="adminCenter" runat="server">
    
    
    <br />
    <br />
    <br />
    <b style="text-align:center">Listado de Especialidades</b>
       <center>
           <div style="justify-content:center">
            <asp:GridView ID="dgvEspecialidades" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" Width="616px" onrowcommand="dgvEspecialidades_RowCommand">
                <Columns>
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="id_especialidad" HeaderText="ID" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="desc_especialidad" HeaderText="Especialidad" />
                    <asp:ButtonField HeaderStyle-Font-Size="Larger" ControlStyle-CssClass="btn btn-danger" Text="BAJA" ButtonType="Button" HeaderText="Baja" CommandName="btnBaja" />
                    <asp:ButtonField HeaderStyle-Font-Size="Larger" ControlStyle-CssClass="btn btn-info" Text="MODIFICAR" ButtonType="Button" HeaderText="Modificar" CommandName="btnModificar"   />
                </Columns>

            </asp:GridView>
           <br />
           <p>
               <asp:Button CssClass="btn btn-success" ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" />
           </p>
        </div>
       </center>
    

</asp:Content>