<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PantallaReportes.aspx.cs" Inherits="PropuestaResto.PantallaReportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .reportes-container {
            margin-top: 50px;
            text-align: center;
        }

        .reportes-header {
            font-size: 2rem;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .reportes-buttons {
            margin-bottom: 30px;
        }

            .reportes-buttons .btn {
                width: 200px;
                margin: 10px;
                font-size: 1.1rem;
            }

        .reportes-table {
            margin-top: 20px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="container reportes-container">
        <h1 class="reportes-header">Reportes</h1>

        <!-- Sección de Reportes Generales -->
        <div class="reportes-generales">
            <h2>Reportes Generales</h2>
            <div class="mb-3">
                <label class="form-label">Monto Total de Ventas:</label>
                <asp:Label ID="lblMontoTotal" runat="server" CssClass="text-primary"></asp:Label>
            </div>
            <div class="mb-3">
                <label class="form-label">Cantidad Total de Insumos:</label>
                <asp:Label ID="lblCantidadInsumos" runat="server" CssClass="text-primary"></asp:Label>
            </div>
        </div>

              <!-- Botones de Reportes --> 

            <a href="PantallaMontoPorFechas.aspx" runat="server"> REPORTE MONTO POR FECHA </a>
            <a href="PantallaMontoMeseroPorMesa.aspx" runat="server"> REPORTE MESERO POR MESA </a>

        <div class="reportes-buttons">
            <asp:Button Text="Pedidos por Mesa" CssClass="btn btn-outline-primary" runat="server" ID="btnPedidosMesa" OnClick="btnPedidosMesa_Click" />
            <asp:Button Text="Pedidos por Mesero" CssClass="btn btn-outline-secondary" runat="server" ID="btnPedidosMesero" OnClick="btnPedidosMesero_Click" />
        </div>

        <div id="divMESAS" runat="server">

        <div id="divPedidoxMesa" runat="server" visible="false">

            <asp:Label runat="server" Text="Numero Mesa: "> </asp:Label>
            <asp:TextBox runat="server" ID="txtIdMesa"></asp:TextBox>
            <asp:Button runat="server" ID="ConfirmarPedidosMesa" OnClick="ConfirmarPedidosMesa_Click" Text="Buscar" />
        </div>

        <br />
        <asp:Label Visible="false" ID="lbTotal" runat="server" CssClass="text-primary" Font-Size="Large" Text="Total :"></asp:Label>

        <asp:Label ID="lblTotalPrecio" runat="server" CssClass="text-primary" Font-Size="Large"></asp:Label>


        <asp:Repeater ID="repPedidosMesa" runat="server">
            <HeaderTemplate>
                <table class="table table-bordered table-striped reportes-table">
                    <thead>
                        <tr>
                            <th>IdMesa</th>
                            <th>Precio</th>
                            <th>FechaHora</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("IdMesa") %></td>
                    <td><%# Eval("Precio") %></td>
                    <td><%# Eval("FechaHora") %></td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>



        </div>


        <div id="DIVMESERO" runat="server"> 


    <div id="divPedidosXMesero" runat="server" visible="false">

        <asp:Label runat="server" Text="idMesero:  "> </asp:Label>
        <asp:TextBox runat="server" ID="txtidMesero"></asp:TextBox>
        <asp:Button runat="server" ID="ConfirmarPedidosMesero" OnClick="ConfirmarPedidosMesero_Click" Text="Buscar" />
    </div>

    <br />
    <asp:Label Visible="false" ID="lblTotalmesero" runat="server" CssClass="text-primary" Font-Size="Large" Text="Total :"></asp:Label>

    <asp:Label ID="lblTotalPrecioMesero" runat="server" CssClass="text-primary" Font-Size="Large"></asp:Label>


    <asp:Repeater ID="rptPedidosMesero" runat="server">
        <HeaderTemplate>
            <table class="table table-bordered table-striped reportes-table">
                <thead>
                    <tr>
                        <th>idmesero</th>
                        <th>Nombre Mesero</th>
                        <th>IdMesa</th>
                        <th>Precio</th>
                        <th>FechaHora</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><%# Eval("IdUsuario") %></td>
                <td><%# Eval("Nombre") %></td>
                <td><%# Eval("IdMesa") %></td>
                <td><%# Eval("Precio") %></td>
                <td><%# Eval("FechaHora") %></td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>



        </div>

    </div>

</asp:Content>
