<%@ Page Title="" Language="C#" MasterPageFile="~/Docentes.Master" AutoEventWireup="true" CodeBehind="CursosInscripto.aspx.cs" Inherits="UI.Web.Docente.CursosInscripto" %>
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
            <asp:GridView ID="dgvCursosIns" CssClass="table table-hover"  runat="server" AutoGenerateColumns="False" Width="616px">
                <Columns>
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="id_dictado" HeaderText="ID Dictado" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="id_curso" HeaderText="ID Curso" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="descripcion" HeaderText="Descripcion" />                    
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="cargo" HeaderText="Cargo" />
                </Columns>
            </asp:GridView>           
        </div>
       </center>
    </form>
</asp:Content>
