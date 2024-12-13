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
            <asp:Button Text="ABML DE USUARIOS/MESEROS" class="btn btn-outline-success" runat="server" ID="btnAbmUsuarios" OnClick="btnAbmUsuarios_Click" />
        </div>

        <div class="col">
            <asp:Button Text="ASIGNACION DE MESAS (a los meseros)" class="btn btn-outline-success" runat="server" ID="btnAsignacionMesa" OnClick="btnAsignacionMesa_Click" />
        </div>

        <div class="col">

        <asp:Button runat="server" Text="Agregar nuevo tipo insumo" ID="btnNuevoInsumo" CssClass="btn btn-primary" OnClick="btnNuevoInsumo_Click" />
        </div>

        <div class="col">
            <asp:Button Text="REPORTES" class="btn btn-outline-success" runat="server" ID="btnReportes" OnClick="btnReportes_Click" />
        </div>


    </div>






    <%--                                            INICIO  VISTA ABML INSUMOS                                 --%>
    <div id="ABMINSUMOS" runat="server" visible="false">
        <asp:Button runat="server" Text="Agregar Insumo" ID="btnAltaInsumo" CssClass="btn btn-primary" OnClick="btnAltaInsumo_Click" />

        <div id="divAltaInsumo" runat="server">

            <div class="row text-center">
                <div class="col-6">
                    <div class="mb-3">


                        <label for="txtDescripcionInsumo" class="form-label">Descripcion del insumo:</label>
                        <asp:TextBox runat="server" ID="txtDescripcionInsumo" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="La descripcion del insumo es requerida" ControlToValidate="txtDescripcionInsumo"> </asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-3">

                        <label for="txtCantidadInsumo" class="form-label">Cantidad:</label>
                        <asp:TextBox runat="server" ID="txtCantidadInsumo" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="La cantidad del insumo es requerida" ControlToValidate="txtCantidadInsumo"> </asp:RequiredFieldValidator>

                    </div>
                    <div class="mb-3">
                        <label for="ddlTipoInsumos" class="form-label">Tipo de insumo:</label>
                        <asp:DropDownList runat="server" ID="ddlTipoInsumos" CssClass="btn btn-outline-dark dropdown-toggle"></asp:DropDownList>

                    </div>
                    <div class="mb-3">
                        <label for="txtPrecioInsumo" class="form-label">Precio:</label>
                        <asp:TextBox runat="server" ID="txtPrecioInsumo" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="El precio del insumo es requerido" ControlToValidate="txtPrecioInsumo"> </asp:RequiredFieldValidator>

                    </div>
                    <div class="mb-3">
                        <asp:Button Text="Agregar" runat="server" ID="btnAceptarAgregarInsumo" CssClass="btn btn-primary" OnClick="btnAceptarAgregarInsumo_Click" />
                    </div>
                </div>
            </div>

        </div>
        <asp:Button runat="server" Text="Modificar insumo" ID="btnAceptarModificarInsumo" CssClass="btn btn-primary" OnClick="btnAceptarModificarInsumo_Click" />

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
                        <asp:Button runat="server" ID="btnModificar" CausesValidation="false"  CssClass="btn btn-primary" CommandArgument='<%#Eval("IdInsumo") %>' CommandName="IdInsumo" OnClick="btnModificar_Click" Text="Modificar" />
                        <asp:Button runat="server" ID="btnEliminar" CausesValidation="false"  CssClass="btn btn-warning" OnClick="btnEliminar_Click" CommandArgument='<%#Eval("IdInsumo") %>' CommandName="IdInsumo" Text="Eliminar" />
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







    <%--                                             VISTA ABML USUARIOS                                 --%>


    <div id="ABMUSUARIOS" runat="server" visible="false">
        <asp:Button runat="server" Text="Agregar Usuarios" ID="btnAltaUsuario" CssClass="btn btn-primary" OnClick="btnAltaUsuario_Click" />

        <div id="divAltaUsuario" runat="server">

            <div class="row text-center">
                <div class="col-6">
                    <div class="mb-3">


                        <label for="txtNombreUsuario" class="form-label">Nombre de usuario:</label>
                        <asp:TextBox runat="server" ID="txtNombreUsuario" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="El nombre del usuario es requerido" ControlToValidate="txtNombreUsuario"> </asp:RequiredFieldValidator>

                    </div>
                    <div class="mb-3">

                        <label for="txtPassword" class="form-label">Contraseña:</label>
                        <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="La password del usuario es requerida" ControlToValidate="txtPassword"> </asp:RequiredFieldValidator>

                    </div>
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre:</label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="El Nombre del mesero es requerido" ControlToValidate="txtNombre"> </asp:RequiredFieldValidator>

                    </div>
                    <div class="mb-3">
                        <label for="txtAppelido" class="form-label">Apellido:</label>
                        <asp:TextBox runat="server" ID="txtAppelido" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ErrorMessage="La Apellido del mesero es requerido" ControlToValidate="txtAppelido"> </asp:RequiredFieldValidator>

                    </div>
                    <div class="mb-3">
                        <label for="chkEsadmin" class="form-label">Es admin:</label>
                        <asp:CheckBox runat="server" ID="chkEsadmin" Text="Es Admin" />
                    </div>
                    <div class="mb-3">
                        <asp:Button Text="Agregar" runat="server" ID="btnAceptarAgregarUsuario" CssClass="btn btn-primary" OnClick="btnAceptarAgregarUsuario_Click" />
                    </div>
                </div>
            </div>

        </div>
        <asp:Button runat="server" Text="Modificar Usuario" ID="btnAceptarModificarUsuario" CssClass="btn btn-primary" OnClick="btnAceptarModificarUsuario_Click" />

        <asp:Repeater ID="repUsuarios" runat="server">
            <HeaderTemplate>
                <table class="table table-striped">
                    <tr>
                        <th>id</th>
                        <th>Nombre Usuario</th>
                        <th>Password</th>
                        <th>Nombre</th>
                        <th>Apellidop</th>
                        <th>FechaIngreso</th>
                        <th>EsAdmin</th>
                        <th>Accion</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("IdUsuario") %></td>
                    <td><%# Eval("NombreUsuario") %></td>
                    <td><%# Eval("Password") %></td>
                    <td><%# Eval("Nombre") %></td>
                    <td><%# Eval("Apellido") %></td>
                    <td><%# Eval("FechaIngreso") %></td>
                    <td><%# Eval("EsAdmin") %></td>
                    <td>
                        <asp:Button runat="server" CausesValidation="false"  ID="btnModificarUsuario" CssClass="btn btn-primary" CommandArgument='<%#Eval("IdUsuario") %>' CommandName="IdInsumo" OnClick="btnModificarUsuario_Click" Text="Modificar" />
                        <asp:Button runat="server" CausesValidation="false"  ID="btnEliminarUsuario" CssClass="btn btn-warning" OnClick="btnEliminarUsuario_Click" CommandArgument='<%#Eval("IdUsuario") %>' CommandName="IdInsumo" Text="Eliminar" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

    </div>
    <asp:TextBox runat="server" ID="txtIdUsuario" Visible="false"></asp:TextBox>





    <%--                                             VISTA ASIGNACION DE MESA                             --%>


    <div id="divASIGNACIONMESA" runat="server" visible="false">

        <div id="divAsignacionMesero" visible="false" runat="server">

            <div class="mb-3">
                <label for="txtIdMesa" class="form-label">IdMesa:</label>
                <asp:TextBox runat="server" ID="txtIdMesa" CssClass="form-control" Enabled="false"></asp:TextBox>

                <h4>Meseros disponibles</h4>
                <asp:DropDownList runat="server" ID="ddlMeseros" CssClass="btn btn-outline-dark ddropdown-toggle"></asp:DropDownList>
            </div>
            <asp:Button runat="server" ID="btnConfirmarAsignarMesero" OnClick="btnConfirmarAsignarMesero_Click" CssClass="btn btn-primary" Text="Confirmar Asignacion" />

        </div>


        <asp:Repeater ID="repMesasDisponibles" runat="server">
            <HeaderTemplate>
                <table class="table table-striped">
                    <tr>
                        <th>Número de mesa</th>
                        <th>Mesero Asignado a la mesa</th>
                        <th>Acciones</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("IdMesa") %></td>
                    <td><%# Eval("IdMeseroAsignado") %></td>

                    <td>
                        <asp:Button runat="server" ID="btnAsignarMeseroMesa" CssClass="btn btn-primary" CommandArgument='<%#Eval("IdMesa") %>' CommandName="IdMesa" OnClick="btnAsignarMeseroMesa_Click" Text="Asignar" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>









    </div>


    
        <%--      tipo insumo nuevo--%>
        <div id="divAltaNuevotipoInsumo" runat="server" visible="false">
            <div class="mb-3">
                <label for="ddlTipoInsumoActuales" class="form-label">Tipo de insumo actuales:</label>
                <asp:DropDownList runat="server" ID="ddlTipoInsumoActuales" CssClass="btn btn-outline-dark dropdown-toggle"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtDescripcionNuevoTipoInsumo" class="form-label">Descripcion del insumo:</label>
                <asp:TextBox runat="server" ID="txtDescripcionNuevoTipoInsumo" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="La descripcion del nuevo tipo insumo es requerida" ControlToValidate="txtDescripcionNuevoTipoInsumo"> </asp:RequiredFieldValidator>
            </div>
            <asp:Button runat="server" Text="Agregar Insumo" ID="Button1" CssClass="btn btn-primary" OnClick="btnConfirmacionNuevoTipoInsumo_Click" />
            <asp:Button runat="server" CausesValidation="false" Text="Cancelar" ID="btncancelarTipoInsumoNuevo" CssClass="btn btn-primary" OnClick="btncancelarTipoInsumoNuevo_Click" />

        </div>
        <%--      fin tipo insumo nuevo--%>




</asp:Content>
