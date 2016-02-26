<%@ Page Title="" Language="C#" MasterPageFile="~/Docentes.Master" AutoEventWireup="true" CodeBehind="Calificaciones.aspx.cs" Inherits="UI.Web.Docente.Calificar" %>
<asp:Content ID="docentes" ContentPlaceHolderID="docCenter" runat="server">
    <form id="form1" runat="server">
    
    <br />
    <br />
    <br />
    <b style="text-align:center">Cursos</b>
        <br />
        <br />
       <center>
           <div style="justify-content:center">
            <asp:GridView ID="dgvCalificaciones" CssClass="table table-hover"  runat="server" AutoGenerateColumns="False" Width="616px" OnRowCommand="dgvCalificaciones_RowCommand">
                <Columns>
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="id_inscripcion" HeaderText="ID Inscripcion" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="apellido" HeaderText="Apellido" />                    
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="id_curso" HeaderText="ID Curso" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="condicion" HeaderText="Condicion" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="nota" HeaderText="Nota" />
                    <asp:ButtonField HeaderStyle-Font-Size="Larger" ControlStyle-CssClass="btn btn-info" Text="Calificar" ButtonType="Button" HeaderText="Calificar" CommandName="btnCalificar"   />
                </Columns>
            </asp:GridView>           
        </div>
       </center>
    </form>
</asp:Content>
