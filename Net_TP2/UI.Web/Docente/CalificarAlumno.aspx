<%@ Page Title="" Language="C#" MasterPageFile="~/Docentes.Master" AutoEventWireup="true" CodeBehind="CalificarAlumno.aspx.cs" Inherits="UI.Web.Docente.CalificarAlumno" %>
<asp:Content ID="docentes" ContentPlaceHolderID="docCenter" runat="server">

    <form id="formAlta" runat="server">
    
       <br />
       <br />
       <br />
       
       <div class="form-group">            
            <br />
           <label>ID Inscripcion:</label>
           <asp:TextBox runat="server" type="text" class="form-control" id="txtInscripcion" Enabled="false"/>
           <br />
           <br />
            <label>Estado:</label>
           <asp:TextBox runat="server" type="text" class="form-control" id="txtEstado" />
           <br />
           <br />
            <label>Nota:</label>
           <asp:DropDownList ID="ddlNotas" runat="server"></asp:DropDownList>
          
            <br /> <br />
            <p>
            <asp:Button runat="server" ID="btnCalificar" Text="Calificar" OnClick="btnCalificar_Click" />                        
             </p>
        </div>
       
   </form>
</asp:Content>
