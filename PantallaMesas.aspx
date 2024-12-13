<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PantallaMesas.aspx.cs" Inherits="PropuestaResto.PantallaMesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Estilo básico para la tabla */
        .table {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }

        .table th, .table td {
            padding: 10px;
            border: 1px solid #ddd;
            text-align: left;
        }

        .table th {
            background-color: #f4f4f4;
        }

        /* Estilo para las filas de la tabla */
        .table tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .table tr:hover {
            background-color: #e9e9e9;
        }

        /* Estilo para el botón "Agregar Pedido" */
        .btn-agregar-pedido {
            padding: 8px 15px;
            font-size: 1rem;
            color: #fff;
            background-color: #007bff;
            text-decoration: none;
            border-radius: 5px;
            display: inline-block;
            text-align: center;
        }

        .btn-agregar-pedido:hover {
            background-color: #0056b3;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rptMesas" runat="server">
        <HeaderTemplate>
            <table class="table">
                <tr>
                    <th>Numero de mesa</th>
                    <th>Disponible</th>
                    <th>Acciones</th>
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td>
                    <h5 class="card-tittle"><%# Eval("IdMesa") %></h5>
                </td>
                <td>
                    <h5 class="card-text">
                        <%# (bool)Eval("Disponible") ? "Mesa Ocupada" : "Disponible" %>
                    </h5>
                </td>
                <td>
                    <a href="PantallaPedido.aspx?IdMesa=<%# Eval("IdMesa") %>" class="btn-agregar-pedido">Agregar Pedido</a>
                </td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
