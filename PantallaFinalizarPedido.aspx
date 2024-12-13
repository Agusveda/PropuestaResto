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

        .btn-Imprimir {
    background-color: #007bff;
    color: white; 
    padding: 10px 20px; 
    font-size: 16px;
    font-weight: bold;
    border: none; 
    border-radius: 5px; 
    cursor: pointer; 
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); 
    transition: background-color 0.3s ease, transform 0.2s ease; 
}

.btn-Imprimir:hover {
    background-color: #0056b3; 
    transform: translateY(-2px); 
}

.btn-Imprimir:active {
    background-color: #004085; 
    transform: translateY(0); 
}

        .button-container {
            text-align: center; 
            margin: 20px 0;
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="button-container">
        <asp:Button CssClass="btn-Imprimir" Text="Imprimir PDF" runat="server" ID="btnImprimirpdf" OnClick="btnImprimirpdf_Click" />
        <asp:Button CssClass="btn btn-brn-succes" Text="Volver a mesas" runat="server" ID="btnMesas" OnClick="btnMesas_Click" Visible="false" />

    </div>

    <div class="gridview-container">
        <asp:GridView 
            ID="dgvPedidoFinal" 
            runat="server" 
            AutoGenerateColumns="true" 
            CssClass="table">
        </asp:GridView>
    </div>

</asp:Content>
