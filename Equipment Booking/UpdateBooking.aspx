<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateBooking.aspx.cs" Inherits="Equipment_Booking.UpdateBooking" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title" class="container">
        <h1>Update Booking</h1>
        <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>

        <div>
            <label>Equipment ID</label>
            <asp:TextBox ID="txtEID" runat="server" Enabled="false"></asp:TextBox>
        </div>

        <div>
            <asp:DropDownList ID="ddlOptions" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
                <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                <asp:ListItem Text="Approved" Value="Approved"></asp:ListItem>
                <asp:ListItem Text="Returned" Value="Returned"></asp:ListItem>
            </asp:DropDownList>

            <label class="form-label"></label>
            <asp:TextBox ID="txtReturnDate" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />

        </div>
    </main>
</asp:Content>
