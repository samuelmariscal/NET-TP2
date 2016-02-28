<%@ Page Title="" Language="C#" MasterPageFile="~/Alumnos.Master" AutoEventWireup="true" CodeBehind="PlanEstudio.aspx.cs" Inherits="UI.Web.Alumno.PlanEstudio" %>
<asp:Content ID="alumnos" ContentPlaceHolderID="alumCenter" runat="server">


    
    <br />
    <br />
    <br />
    <b style="text-align:center">Plan de Estudio</b>
        <br />
        <br />
       <center>
           <div style="justify-content:center">
            <asp:GridView ID="dgvPlanEstudio" CssClass="table table-hover"  runat="server" AutoGenerateColumns="False" Width="616px">
                <Columns>
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="id_materia" HeaderText="ID Inscripción" />                    
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="desc_materia" HeaderText="Materia" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="hs_totales" HeaderText="Horas Totales" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="hs_semanales" HeaderText="Horas Semanales" />                    
                </Columns>
            </asp:GridView>           
        </div>
       </center>    
</asp:Content>
