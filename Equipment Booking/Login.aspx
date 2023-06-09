<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Equipment_Booking.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title" class="container mt-4">

        <h1>Login</h1>

        <p>Welcome back, please enter your information to continue.</p>
        
        <div class="mb-2">
            <label class="form-label">Username</label>
            <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-2">
            <label class="form-label">Password</label>
            <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <asp:Button CssClass="btn btn-success" ID="btnLogin" OnClick="btnLogin_Click"  runat="server" Text="LOGIN" />
        <br />
        <asp:Label ID="lblError" ForeColor="Red" runat="server" Text=""></asp:Label>
       
    </main>
</asp:Content>
