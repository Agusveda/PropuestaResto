<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PropuestaResto.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

        body {
            font-family: Arial, sans-serif;
            background-color: #bfa6a0; 
            margin: 0;
            padding: 0;
        }

        .container {
            width: 100%;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            text-align: center;
        }

        h1, h2 {
            color: #333; 
        }

        .row {
            display: flex;
            justify-content: center;
            gap: 20px; 
            flex-wrap: wrap;
        }

        .col {
            flex: 1;
            max-width: 250px;
            margin: 10px;
        }

        .btn {
            background-color: #007bff;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            width: 100%;
            font-size: 16px;
            margin-top: 20px;
        }

        .btn:hover {
            background-color: #0056b3;
        }


        .validacion {
            color: red;
            font-size: 12px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div>
            <h1>PAGINA PRINCIPAL</h1>
            <h2>Opciones:</h2>
            <br />
            <br />

            <div class="row">
                <div class="col">
                    <asp:Button Text="Mesas" CssClass="btn" runat="server" id="btnMesas" OnClick="btnMesas_Click" />
                </div>

                <% if (Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).EsAdmin == true) { %>
                    <div class="col">
                        <asp:Button Text="Admin" CssClass="btn" runat="server" id="btnAdmin" OnClick="btnAdmin_Click" />
                    </div>
                <% } %>
            </div>
        </div>
    </div>
</asp:Content>
