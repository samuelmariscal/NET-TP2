<%@ Page Title="" Language="C#" MasterPageFile="~/Alumnos.Master" AutoEventWireup="true" CodeBehind="EstadoAcademico.aspx.cs" Inherits="UI.Web.Alumno.EstadoAcademico" %>
<asp:Content ID="alumnos" ContentPlaceHolderID="alumCenter" runat="server">

    <form id="form1" runat="server">
    
    <br />
    <br />
    <br />
    <b style="text-align:center">Estado Académico</b>
        <br />
        <br />
       <center>
           <div style="justify-content:center">
            <asp:GridView ID="dgvEstadoAcad" CssClass="table table-hover"  runat="server" AutoGenerateColumns="False" Width="616px">
                <Columns>
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="id_inscripcion" HeaderText="ID Inscripción" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="descripcion" HeaderText="Curso" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="desc_materia" HeaderText="Materia" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="condicion" HeaderText="Condicion" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="nota" HeaderText="Nota" />                    
                </Columns>
            </asp:GridView>           
        </div>
       </center>
    </form>
</asp:Content>
