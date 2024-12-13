<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PropuestaResto.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #bfa6a0;
            margin: 0;
            padding: 0;
        }

        .contenedor-login {
            width: 100%;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            background-color: #bfa6a0;
        }

        .login-box {
            background-color: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 400px;
        }

        .form-label {
            font-weight: bold;
            font-size: 16px;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            margin: 8px 0;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .btn {
            background-color: #007bff;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            width: 100%;
            font-size: 16px;
        }

        .btn:hover {
            background-color: #0056b3;
        }

        .validacion {
            color: red;
            font-size: 12px;
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor-login">
        <div class="login-box">
            <h2>Iniciar Sesión</h2>

            <div class="mb-3">
                <label class="form-label" for="txtuser">Nombre de Usuario</label>
                <asp:TextBox runat="server" ID="txtuser" CssClass="form-control" placeholder="Nombre de usuario"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" CssClass="validacion" ErrorMessage="El nombre de usuario es requerido" ControlToValidate="txtuser"></asp:RequiredFieldValidator>
            </div>

            <div class="mb-3">
                <label class="form-label" for="txtPassword">Contraseña</label>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Contraseña"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" CssClass="validacion" ErrorMessage="La contraseña es requerida" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
            </div>

            <asp:Button runat="server" Text="Ingresar" ID="btnIngresar" OnClick="btnIngresar_Click" CssClass="btn" />
        </div>
    </div>
</asp:Content>
