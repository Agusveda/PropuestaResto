<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PropuestaResto.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>


        body {
            font-family:  Arial, sans-serif;
            background-color: #bfa6a0;
            color: #bfa6a0;
        }

        .container {
            width: 100%;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: flex-start;
            text-align: center;
            padding: 20px;
            position: relative; 
        top: 50px;
        }

        h1 {
            font-size: 2.5em;
            color: #000000;
            margin-bottom: 10px;
        }

        h2 {
            font-size: 1.5em;
            color: #808080;
        }

        .row {
            display: flex;
            justify-content: center;
            gap: 20px;
            flex-wrap: wrap;
            margin-top: 20px;
        }

        .col {
            flex: 1;
            max-width: 250px;
            margin: 10px;
        }

        .btn {
            background-color: #a1d9c6;
            padding: 15px 20px;
  
            border-radius: 5px;
            cursor: pointer;
            width: 100%;
            font-size: 16px;
            box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.3);
            transition: background-color 0.3s, transform 0.2s;
        }

        .btn:hover {
            background-color: #5fac4c;
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
