<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PantallaReportes.aspx.cs" Inherits="PropuestaResto.PantallaReportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container container text-center">

        <h1>REPORTES  </h1>


        <div class="col">
            <asp:Button Text="ABML DE INSUMOS" class="btn btn-outline-success" runat="server" ID="btnAbmInsumos" OnClick="btnAbmInsumos_Click" />
        </div>


        <div class="col">
            <asp:Button Text="Pedidos por mesa" class="btn btn-outline-success" runat="server" ID="btnAbmUsuarios" OnClick="btnAbmUsuarios_Click" />
        </div>
    </div>


</asp:Content>
