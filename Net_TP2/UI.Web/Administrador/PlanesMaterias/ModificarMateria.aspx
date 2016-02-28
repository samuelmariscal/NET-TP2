<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ModificarMateria.aspx.cs" Inherits="UI.Web.Administrador.PlanesMaterias.ModificarMateria" %>
<asp:Content ID="admin" ContentPlaceHolderID="adminCenter" runat="server">


    
       <br />
       <br />
       <br />
       
       <div class="form-group">
            <b style="text-align:center">Plan: </b>
           <asp:DropDownList ID="ddlPlanes" runat="server">
           </asp:DropDownList>
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
