<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PantallaReportes.aspx.cs" Inherits="PropuestaResto.PantallaReportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style>
        .reportes-container {
            margin-top: 50px;
            text-align: center;
        }

       
        .reportes-header {
            font-size: 2.5rem; 
            font-weight: bold;
            margin-bottom: 30px;
            color: #007bff; 
        }
        .reportes-links {
            margin-top: 20px;
        }

        .reportes-links a {
            display: inline-block;
            padding: 12px 20px;
            margin: 10px;
            font-size: 1.2rem;
            color: #5eae7b;
            text-decoration: none;
            border-radius: 8px;
        }

        .reportes-buttons {
            margin-top: 20px;
            text-align: center;
        }

        .reportes-buttons .btn {
            width: 250px;
            padding: 15px;
            font-size: 1.2rem;
            margin: 10px;
            border-radius: 8px; 
            transition: background-color 0.3s ease, transform 0.3s ease;
        }

        .reportes-buttons .btn:hover {
            background-color: #0056b3;
            color: white;
            transform: scale(1.05);
        }

        .reportes-generales h2 {
            font-size: 2rem;
            margin-bottom: 20px;
            font-weight: bold;
            color: #333;
        }

        .reportes-table {
            margin-top: 20px;
            width: 100%;
            border-collapse: collapse;
        }

        .reportes-table th, .reportes-table td {
            padding: 10px;
            text-align: left;
            border: 1px solid #ddd;
        }

        .reportes-table th {
            background-color: #f8f9fa;
        }

        .reportes-table tbody tr:hover {
            background-color: #f1f1f1;
        }

        .form-label {
            font-size: 1.2rem;
            font-weight: bold;
        }

        .text-primary {
            font-size: 1.5rem;
            color: #007bff;
        }

        .btn-search {
            margin-top: 20px;
            font-size: 1.1rem;
            padding: 10px 20px;
            background-color: #28a745;
            color: white;
            border-radius: 5px;
            border: none;
            transition: background-color 0.3s;
        }

        .btn-search:hover {
            background-color: #218838;
        }

       
        .total-label {
            font-size: 1.5rem;
            font-weight: bold;
            color: #28a745;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="container reportes-container">
        <h1 class="reportes-header">Reportes Generales</h1>

        <!-- Sección de Reportes Generales -->
        <div class="reportes-generales">
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
            <h2>Reportes Generales especificos</h2>

       <div class="reportes-links">
            <a  CssClass="btn btn-outline-primary" href="PantallaMontoPorFechas.aspx" runat="server">REPORTE MONTO POR FECHA</a>
            <a   CssClass="btn btn-outline-primary" href="PantallaMontoMeseroPorMesa.aspx" runat="server">REPORTE MESERO POR MESA</a>
        </div>
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
