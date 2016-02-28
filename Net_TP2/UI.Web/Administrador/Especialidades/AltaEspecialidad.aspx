<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AltaEspecialidad.aspx.cs" Inherits="UI.Web.Administrador.AltaEspecialidad" %>
<asp:Content ID="admin" ContentPlaceHolderID="adminCenter" runat="server">

 
        
       <br />
       <br />
       <br />
       
        <div class="form-group">
           <label>Descripcion Especialidad:</label>
           <asp:TextBox runat="server" type="text" class="form-control" id="txtEspecialidad" />
          
            <br /> <br />
            <p>
            <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" />
                        
            <asp:Button runat="server" ID="btnVolver" Text="Volver" OnClick="btnVolver_Click" />
             </p>
        </div>
       
  
</asp:Content>
