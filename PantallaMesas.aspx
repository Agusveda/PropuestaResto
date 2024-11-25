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
   


    <asp:Repeater runat="server" ID="rptMesas">
        <ItemTemplate>
            <div class="col">
                <div class="card">

                    <h5 class="card-tittle" > <%#Eval("IdMesa") %></h5>

                </div>


            </div>




        </ItemTemplate>
    </asp:Repeater>










</asp:Content>
