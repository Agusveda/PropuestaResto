<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PantallaMesas.aspx.cs" Inherits="PropuestaResto.PantallaMesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">






    <asp:Repeater ID="rptMesas" runat="server">
        <HeaderTemplate>
            <table class="table table-striped">
                <tr>
                    <th>Numero de mesa</th>
                    <th>Disponible</th>
                    <th>Acciones</th>

                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td>
                    <h5 class="card-tittle"><%#Eval("IdMesa") %></h5>

                </td>
                <td>
    <h1 class="card-text"><%# (bool)Eval("Disponible") ? "Mesa Ocupada " : "Disponible" %></h1>
</td>
                <td>
                    <a href="PantallaPedido.aspx?IdMesa=<%#Eval("IdMesa") %> "> Agregar Pedido</a>
<%--                    <asp:Button runat="server" ID="BtnAgregarPedido" CssClass="btn btn-primary" CommandArgument='<%#Eval("IdMesa") %>' CommandName="IdMesa" OnClick="BtnAgregarPedido_Click" Text="Agregar Pedido" />--%>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>









</asp:Content>
