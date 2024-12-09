<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PropuestaResto.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-6">
        <div class="mb-3">
            <label class="form-label">user </label>
            <asp:TextBox runat="server" ID="txtuser" placeholder="user name"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Password </label>
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
        </div>

        <asp:Button runat="server" Text="Ingresar" ID="btnIngresar" OnClick="btnIngresar_Click" />
    </div>





</asp:Content>
