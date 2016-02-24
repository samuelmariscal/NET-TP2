<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AltaCurso.aspx.cs" Inherits="UI.Web.Administrador.CursoComisiones.AltaCurso" %>
<asp:Content ID="admin" ContentPlaceHolderID="adminCenter" runat="server">

    <form id="formAlta" runat="server">
     
       <br />
       <br />
       <br />
       
        <div class="form-group">
            <label>Plan: </label>
            <asp:TextBox runat="server" type="text" class="form-control" id="txtPlan" Enabled="False" />
           <label>Comision: </label>
           <asp:TextBox runat="server" type="text" class="form-control" id="txtComision" Enabled="False" />
            <br />
            <label>Descripción:</label>
           <asp:TextBox runat="server" type="text" class="form-control" id="txtDescripcion" />
            <label>Cupo: </label>
           <asp:TextBox runat="server" type="text" class="form-control" id="txtCupo" />
           <label>Materia: </label>
           <asp:DropDownList ID="ddlMaterias" runat="server">
           </asp:DropDownList><br />
            
          
            <br /> <br />
            <p>
            <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" />
                        
            <asp:Button runat="server" ID="btnVolver" Text="Volver" OnClick="btnVolver_Click" />
             </p>
        </div>
       
   </form>

</asp:Content>
