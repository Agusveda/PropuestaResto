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

        <div class="row text-center">
            <div class="col-6">
                <div class="mb-3">

                    <label for="txtDescripcionInsumo" class="form-label">Descripcion del insumo:</label>
                    <asp:TextBox runat="server" ID="txtDescripcionInsumo" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">

                    <label for="txtCantidadInsumo" class="form-label">Cantidad:</label>
                    <asp:TextBox runat="server" ID="txtCantidadInsumo" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">

                    <label for="ddlTipoInsumos" class="form-label">Tipo de insumo:</label>
                    <asp:DropDownList runat="server" ID="ddlTipoInsumos" CssClass="btn btn-outline-dark dropdown-toggle"></asp:DropDownList>
                </div>
                <div class="mb-3">

                    <label for="txtPrecioInsumo" class="form-label">Precio:</label>
                    <asp:TextBox runat="server" ID="txtPrecioInsumo" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Button Text="Agregar Insumo" runat="server" ID="btnAceptarAgregarInsumo" CssClass="btn btn-primary" OnClick="btnAceptarAgregarInsumo_Click" />
                </div>
            </div>



        </div>








    </div>











</asp:Content>
