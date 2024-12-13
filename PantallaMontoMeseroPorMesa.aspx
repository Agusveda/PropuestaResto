<%@ Page Title="Monto Mesero por Mesa" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PantallaMontoMeseroPorMesa.aspx.cs" Inherits="PropuestaResto.PantallaMontoMeseroPorMesa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2 class="text-center mb-4">Monto Mesero por Mesa</h2>
        <asp:GridView ID="gvMeseroPorMesa" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre del Mesero" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido del Mesero" />
                <asp:BoundField DataField="IdMesa" HeaderText="ID Mesa" />
                <asp:BoundField DataField="Precio" HeaderText="Monto Total" DataFormatString="$ {0:N2}" />
                <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
            </Columns>
        </asp:GridView>
                <asp:Button ID="btnExportarExcel" runat="server" Text="Exportar a Excel" CssClass="btn btn-primary mt-3" OnClick="btnExportarExcel_Click" />

    </div>
</asp:Content>
