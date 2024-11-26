<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PantallaPedido.aspx.cs" Inherits="PropuestaResto.PantallaPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <asp:Label Text="" runat="server" ID="lbIdMesa"></asp:Label>


        <asp:Repeater ID="repInsumos" runat="server">
        <HeaderTemplate>
            <table class="table table-striped">
                <tr>
                    <th>Descripción</th>
                    <th>Tipo de Insumo</th>
                    <th>Cantidad</th>
                    <th>Precio</th>
                    <th>Accion</th>
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><%# Eval("Descripcion") %></td>
                <td><%# Eval("IdTipoInsumo") %></td>
                <td><%# Eval("Cantidad") %></td>
                <td><%# Eval("Precio")   %></td>
                <td>
                    <asp:Button runat="server" ID="btnAgregar" CssClass="btn btn-primary" CommandArgument='<%#Eval("IdInsumo") %>' CommandName="IdInsumo" OnClick="btnAgregar_Click" Text="Agregar al pedido" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

</div>
<asp:TextBox runat="server" ID="txtIdInsumo" Visible="false"></asp:TextBox>





</asp:Content>
