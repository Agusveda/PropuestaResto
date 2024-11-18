<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PantallaAdmin.aspx.cs" Inherits="PropuestaResto.PantallaAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container container text-center">

        <h1>PANTALLA DEL GERENTE </h1>


        <div class="col">
            <asp:Button Text="ABML DE INSUMOS" class="btn btn-outline-success" runat="server" ID="btnAbmInsumos" OnClick="btnAbmInsumos_Click" />
        </div>


        <div class="col">
            <asp:Button Text="Dar de alta mesero" class="btn btn-outline-success" runat="server" />
        </div>

    </div>






    <%--                                            INICIO  VISTA ABML INSUMOS                                 --%>
    <div id="ABMINSUMOS" runat="server">
        <asp:Button runat="server"  Text="Agregar Insumo" ID="btnAltaInsumo" CssClass="btn btn-primary" OnClick="btnAltaInsumo_Click"/>

        <div id="divAltaInsumo" runat="server">
           
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
                        <asp:Button Text="Agregar" runat="server" ID="btnAceptarAgregarInsumo" CssClass="btn btn-primary" OnClick="btnAceptarAgregarInsumo_Click" />
                    </div>
                </div>
            </div>

        </div>
        <asp:Button runat="server"  Text="Modificar insumo" ID="btnAceptarModificarInsumo" CssClass="btn btn-primary" OnClick="btnAceptarModificarInsumo_Click"/>

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
                        <asp:Button runat="server" ID="btnModificar" CssClass="btn btn-primary" CommandArgument='<%#Eval("IdInsumo") %>' CommandName="IdInsumo" OnClick="btnModificar_Click" Text="Modificar" />
                        <asp:Button runat="server" ID="btnEliminar" CssClass="btn btn-warning" OnClick="btnEliminar_Click" CommandArgument='<%#Eval("IdInsumo") %>' CommandName="IdInsumo" Text="Eliminar" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

    </div>
                        <asp:TextBox runat="server" ID="txtIdInsumo" Visible="false"></asp:TextBox>

     










    <%--                                           FIN  VISTA ABML INSUMOS                                 --%>
</asp:Content>
