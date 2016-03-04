<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AltaMateria2.aspx.cs" Inherits="UI.Web.Administrador.PlanesMaterias2.AltaMateria2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminCenter" runat="server">
<br />
       <br />
       <br />
       
        <div class="form-group">
            <br />
           <label>Descripcion Materia:</label>
           <asp:TextBox runat="server" type="text" class="form-control" id="txtMateria" />
            <label>Horas Semanales:</label>
           <asp:TextBox runat="server" type="text" class="form-control" id="txtHsSemanales" />
            <label>Horas Totales:</label>
           <asp:TextBox runat="server" type="text" class="form-control" id="txtHsTotales" />
          
            <br /> <br />
            <p>
            <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" />
                        
            <asp:Button runat="server" ID="btnVolver" Text="Volver" OnClick="btnVolver_Click" />
             </p>
        </div>
       

</asp:Content>