<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AltaPlan.aspx.cs" Inherits="UI.Web.Administrador.PlanesMaterias2.AltaPlan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminCenter" runat="server">

    <br />
    <br />
    <br />
    <b style="text-align:center">Listado de Materias<br />
        </b>
        <b style="text-align:center">Plan: 
            <asp:TextBox ID="txtDescPlan" runat="server"></asp:TextBox>
        </b>
        <br /> 
        <center>
           <div style="justify-content:center">
            <asp:GridView ID="dgvMaterias" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" Width="616px"> 
                <Columns>
                    <asp:TemplateField HeaderText="Materia">
                        <ItemTemplate>
                            <asp:TextBox ID="desc_materia" runat="server" AutoPostBack="false" Text='<%# Eval("desc_materia")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="desc_materia" Text="Campo Requerido"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Horas semanales">
                        <ItemTemplate>
                            <asp:TextBox ID="hs_semanales" runat="server" AutoPostBack="false" Text='<%# Eval("hs_semanales")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="hs_semanales" Text="Campo Requerido"/>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="hs_semanales" Text="Campo Numerico" ValidationExpression="/d{2}" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Horas totales">
                        <ItemTemplate>
                            <asp:TextBox ID="hs_totales" runat="server" AutoPostBack="false" Text='<%# Eval("hs_totales")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="hs_totales" Text="Campo Requerido"/>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="hs_semanales" Text="Campo Numerico" ValidationExpression="/d{2}" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
           <br />
           <p>
               <asp:Button CssClass="btn btn-success" ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" />
           </p>
        </div>
       </center>
</asp:Content>

