<%@ Page Title="" Language="C#" MasterPageFile="~/Alumnos.Master" AutoEventWireup="true" CodeBehind="InscribirMateria.aspx.cs" Inherits="UI.Web.Alumno.InscribirMateria" %>
<asp:Content ID="alumnos" ContentPlaceHolderID="alumCenter" runat="server">

    
    <br />
    <br />
    <br />
    <b style="text-align:center">Inscripcion a Cursado</b>
        <br />
        <label>Plan: </label>
        <asp:TextBox runat="server" type="text" class="form-control" id="txtPlan" Enabled="false" />
        <br />
        <br />
        <b><asp:Label runat="server" CssClass="label-warning" ID="lblVacio" Visible="false"></asp:Label></b>
       <center>
           <div style="justify-content:center">
            <asp:GridView ID="dgvCursosDisp" CssClass="table table-hover"  runat="server" AutoGenerateColumns="False" Width="616px" OnRowCommand="dgvMaterias_RowCommand">
                <Columns>
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="id_curso" HeaderText="ID Curso" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="desc_materia" HeaderText="Materia" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="desc_comision" HeaderText="Comision" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="descripcion" HeaderText="Curso" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="cupo" HeaderText="Cupo" />
                    <asp:ButtonField HeaderStyle-Font-Size="Larger" ControlStyle-CssClass="btn btn-info" Text="Inscribir" ButtonType="Button" HeaderText="Inscripción" CommandName="btnInscribir"   />
                </Columns>
            </asp:GridView>           
        </div>
       </center>


</asp:Content>
