<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PantallaMesas.aspx.cs" Inherits="PropuestaResto.PantallaMesas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
     .col {
        width: 100px;
        height: 100px;
        background-color: lightgray;
        border: 2px solid black;
        display: flex;
        align-items: center;
        justify-content: center;
        cursor: pointer;
    }

</style>
    <div class="container ">
        <div class="row">
            <div class="col">mesa 1</div>
            <div class="col">mesa 2</div>
            <div class="col">mesa 3</div>
            <div class="col">mesa 4</div>
        </div>
        <div class="row">

            <div class="col">mesa 5</div>
            <div class="col">mesa 6</div>
            <div class="col">mesa 7</div>
            <div class="col">mesa 8</div>

        </div>
    </div>










</asp:Content>
