<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="CursoComisiones.aspx.cs" Inherits="UI.Web.Administrador.CursoComisiones.CursoComisiones" %>
<asp:Content ID="admin" ContentPlaceHolderID="adminCenter" runat="server">
     <form id="form1" runat="server">
    
    <br />
    <br />
    <br />
    <b style="text-align:center">Listado de Comisiones y Cursos</b>
         <br />
         <b style="text-align:center">Plan: </b>
         <asp:DropDownList ID="ddlPlanes" runat="server" AutoPostBack="true" CausesValidation="True" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged" >

        </asp:DropDownList>
         <b style="text-align:center">Comision: </b>
         <asp:DropDownList ID="ddlComision" runat="server" AutoPostBack="true" CausesValidation="True" OnSelectedIndexChanged="ddlComision_SelectedIndexChanged">

        </asp:DropDownList>
         <br />
         <br />
       <center>
           <div style="justify-content:center">
            <asp:GridView ID="dgvCursos" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" Width="616px" onrowcommand="dgvCursos_RowCommand">
                <Columns>
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="id_curso" HeaderText="ID" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="anio_calendario" HeaderText="Año Calendario" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="cupo" HeaderText="Cupo" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="descripcion" HeaderText="Descripcion" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="id_comision" HeaderText="ID Comision" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="id_materia" HeaderText="ID Materia" />
                    <asp:ButtonField HeaderStyle-Font-Size="Larger" ControlStyle-CssClass="btn btn-danger" Text="BAJA" ButtonType="Button" HeaderText="Baja" CommandName="btnBaja" />
                    <asp:ButtonField HeaderStyle-Font-Size="Larger" ControlStyle-CssClass="btn btn-info" Text="MODIFICAR" ButtonType="Button" HeaderText="Modificar" CommandName="btnModificar"   />
                </Columns>

            </asp:GridView>
           <br />
           <p>
               <asp:Button CssClass="btn btn-success" ID="btnAlta" runat="server" Text="Alta Curso" OnClick="btnAlta_Click" />
           </p>
        </div>
       </center>
    </form>
</asp:Content>
