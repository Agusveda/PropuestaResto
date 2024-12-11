<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PantallaFinalizarPedido.aspx.cs" Inherits="PropuestaResto.PantallaFinalizarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .gridview-container {
            margin: 20px auto;
            max-width: 800px;
        }

        .gridview-container .table {
            width: 100%;
            border-collapse: collapse;
        }

        .gridview-container th, .gridview-container td {
            padding: 10px;
            text-align: left;
            border: 1px solid #ddd;
        }

        .gridview-container th {
            background-color: #f8f9fa;
            font-weight: bold;
            text-align: center;
        }

        .gridview-container tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .gridview-container tr:hover {
            background-color: #e9ecef;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button  runat="server" ID="btnImprimirpdf" OnClick="btnImprimirpdf_Click"/>

    <div class="gridview-container">
        <asp:GridView 
            ID="dgvPedidoFinal" 
            runat="server" 
            AutoGenerateColumns="true" 
            CssClass="table">
        </asp:GridView>
    </div>
</asp:Content>
