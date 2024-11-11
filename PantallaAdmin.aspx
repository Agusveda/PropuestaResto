<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PantallaAdmin.aspx.cs" Inherits="PropuestaResto.PantallaAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container container text-center">

        <h1>PANTALLA DEL GERENTE </h1>

        <div class="col">
            <asp:Button Text="Administrar Insumos ()" class="btn btn-outline-success" runat="server" />
        </div>

        <div class="col">
            <asp:Button Text="Agregar nuevo insumo" class="btn btn-outline-success" runat="server" ID="btnAgregarInsumo" OnClick="btnAgregarInsumo_Click" />
        </div>

        <div class="col">
            <asp:Button Text="Modificar/eliminar insumo" class="btn btn-outline-success" runat="server" />
        </div>

        <div class="col">
            <asp:Button Text="Dar de alta mesero" class="btn btn-outline-success" runat="server" />
        </div>

    </div>

    <div id="divAltaInsumo" runat="server">
    <label class="container container text-center">REGISTROS ACTUALES EN LA CARTA </label>
    <asp:GridView ID="dgvInsumos" class="table" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Idinsumo" DataField="IdInsumo" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:BoundField HeaderText="Tipo Insumo" DataField="IdTipoInsumo.Descripciontipo" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
        </Columns>
    </asp:GridView>

        <div class="row">
            <div class="col-6">
                <label ></label>
                <asp:TextBox runat="server" ID="txt" ></asp:TextBox>

            </div>



        </div>

        

            




    </div>










</asp:Content>
