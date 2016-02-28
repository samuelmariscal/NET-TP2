<%@ Page Title="" Language="C#" MasterPageFile="~/Docentes.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Docente.Cursos" %>
<asp:Content ID="docentes" ContentPlaceHolderID="docCenter" runat="server">


    
    <br />
    <br />
    <br />
    <b style="text-align:center">Cursos</b>
        <br />
        <b><asp:Label runat="server" CssClass="label-warning" ID="lblVacio" Visible="false"></asp:Label></b>
        <br />
       <center>
           <div style="justify-content:center">
            <asp:GridView ID="dgvCursos" CssClass="table table-hover"  runat="server" AutoGenerateColumns="False" Width="616px" OnRowCommand="dgvCursos_RowCommand" >
                <Columns>
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="id_curso" HeaderText="ID Curso" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="descripcion" HeaderText="Descripcion" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="id_materia" HeaderText="ID Materia" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="desc_comision" HeaderText="Comision" />
                    <asp:BoundField HeaderStyle-Font-Size="Larger" DataField="anio_calendario" HeaderText="Año Calendario" />
                    <asp:TemplateField HeaderText="Cargo">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlCargos" Runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField HeaderStyle-Font-Size="Larger" ControlStyle-CssClass="btn btn-info" Text="Inscribir" ButtonType="Button" HeaderText="Inscripción" CommandName="btnInscribir"/>                   
                </Columns>
            </asp:GridView>           
        </div>
       </center>

</asp:Content>
