<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Equipment_Booking.Dashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       
    <div class="row dashboard">
        <div class="col-2 bg-black text-white p-3">
            <h1 class="fs-3 text-center">
                <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></h1>
            <asp:Image ID="imgProfile" CssClass="w-100 rounded-circle" runat="server" />
        </div>

        <div class="col-10">
            <h1>DashBoard</h1>

            <h2>Bookings</h2>
            <a href="/Equipments.aspx">
                <span class="btn btn-dark mb-3">+ New Booking</span>
            </a>
            <asp:GridView ID="GridView1" CssClass="table table-dark table-striped" runat="server">

                <Columns>
                <asp:TemplateField HeaderText="ACTIONS">
                    <ItemTemplate>
                        
                        
                        <asp:HyperLink NavigateUrl='<%# "BookingDetails?id=" + Eval("booking_id") %>' runat="server"><span class="btn btn-primary border-4">Details</span></asp:HyperLink> 
                        <asp:HyperLink NavigateUrl='<%# "UpdateBooking?id=" + Eval("booking_id") %>' runat="server"><span class="btn btn-warning border-4">Update</span></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            </asp:GridView>
        </div>

    </div>
</asp:Content>
