<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PantallaPedido.aspx.cs" Inherits="PropuestaResto.PantallaPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager id="ScriptManager" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>


    <asp:Label Text="" runat="server" ID="lbIdMesa"></asp:Label>

        <asp:Label runat="server" Text="Filtar"> </asp:Label>
    <asp:TextBox runat="server" id="txtFiltro" AutoPostBack="true" OnTextChanged="Filtro_TextChanged"></asp:TextBox>
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
                <td><%# Convert.ToInt32(Eval("Cantidad")) == 0 ? "Sin stock" : Eval("Cantidad").ToString() %></td>

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

<asp:TextBox runat="server" ID="txtIdInsumo" Visible="false"></asp:TextBox>

    <asp:Repeater ID="repDetallePedido" runat="server">
    <HeaderTemplate>
        <h3>Detalle del Pedido</h3>
        <table class="table table-striped">
            <tr>
                <th>Descripción</th>
                <th>Cantidad</th>
                <th>Precio</th>
                <th>Acción</th>
            </tr>
    </HeaderTemplate>

    <ItemTemplate>
    <tr>
        <td><%# Eval("Descripcion") %></td>
        <td><%# Eval("Cantidad") %></td>
        <td><%# Eval("Precio") %></td>
        <td>
            <asp:Button runat="server" ID="btnAumentar" CssClass="btn btn-success" CommandArgument='<%# Eval("IdInsumo") %>' OnClick="btnAumentar_Click" Text="+" />
            <asp:Button runat="server" ID="btnDisminuir" CssClass="btn btn-warning" CommandArgument='<%# Eval("IdInsumo") %>' OnClick="btnDisminuir_Click" Text="-" />
            <asp:Button runat="server" ID="btnEliminar" CssClass="btn btn-danger" CommandArgument='<%# Eval("IdInsumo") %>' OnClick="btnEliminar_Click" Text="Eliminar" />
        </td>
    </tr>
</ItemTemplate>


    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>

<asp:Button ID="btnConfirmarPedido" runat="server" CssClass="btn btn-success" OnClick="btnConfirmarPedido_Click" Text="Confirmar Pedido" />

    <asp:Button ID="btnFinalizarPedido" runat="server" CssClass="btn btn-danger" OnClick="btnFinalizarPedido_Click" Text="Finalizar Pedido" />

    <asp:Button ID="btnAtras" runat="server" CssClass="btn btn-success" OnClick="btnAtras_Click" Text="Atras" />




        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
