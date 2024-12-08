<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PantallaReportes.aspx.cs" Inherits="PropuestaResto.PantallaReportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container container text-center">

        <h1>PANTALLA DEL GERENTE </h1>


        <div class="col">
            <asp:Button Text="ABML DE INSUMOS" class="btn btn-outline-success" runat="server" ID="btnAbmInsumos" OnClick="btnAbmInsumos_Click" />
        </div>


        <div class="col">
            <asp:Button Text="ABML DE USUARIOS/MESEROS" class="btn btn-outline-success" runat="server" ID="btnAbmUsuarios" OnClick="btnAbmUsuarios_Click" />
        </div>

        <div class="col">
            <asp:Button Text="ASIGNACION DE MESAS (a los meseros)" class="btn btn-outline-success" runat="server" ID="btnAsignacionMesa" OnClick="btnAsignacionMesa_Click" />
        </div>
         <div class="col">
     <asp:Button Text="REPORTES" class="btn btn-outline-success" runat="server" ID="btnReportes" OnClick="btnReportes_Click" />
 </div>


    </div>


</asp:Content>
