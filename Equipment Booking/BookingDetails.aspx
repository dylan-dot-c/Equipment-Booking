<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookingDetails.aspx.cs" Inherits="Equipment_Booking.BookingDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title" class="container">
        <h1>Booking Details</h1>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server"></asp:GridView>
    </main>
</asp:Content>
