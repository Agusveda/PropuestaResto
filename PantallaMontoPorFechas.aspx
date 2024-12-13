<%@ Page Title="Monto Total por Fechas" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PantallaMontoPorFechas.aspx.cs" Inherits="PropuestaResto.PantallaMontoPorFechas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .report-container {
            margin: 30px;
        }
        .btn-export {
            margin: 20px 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="report-container">
        <h1>Monto Total por Fechas</h1>

        <asp:GridView ID="gvMontoPorFechas" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="FechaHora" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="MontoTotal" HeaderText="Monto Total"   DataFormatString="$ {0:N2}" />
            </Columns>
        </asp:GridView>

        <asp:Button ID="btnExportar" runat="server" CssClass="btn btn-primary btn-export" Text="Exportar a Excel" OnClick="btnExportar_Click" />
    </div>
</asp:Content>
