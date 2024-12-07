<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PropuestaResto.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container text-center">
    <h1> PAGINA PRINCIPAL </h1>
    <h2>Opciones:</h2>
        <br />
        <br />

  <div class="row">
    <div class="col">
              <asp:Button Text="Mesas" CssClass="btn btn-primary" runat="server" id="btnMesas" OnClick="btnMesas_Click" />


    </div>

      <%if (Session["usuario"] !=null && ((Dominio.Usuario)Session["usuario"]).EsAdmin == true)
          {

          %>
    <div class="col">
              <asp:Button Text="Admin" CssClass="btn btn-primary" runat="server" id="btnAdmin" OnClick="btnAdmin_Click" />

    </div>
    <%} %>
  </div>
</div>
























</asp:Content>
