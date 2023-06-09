<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Equipments.aspx.cs" Inherits="Equipment_Booking.Equipments" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container" aria-labelledby="title">
        <div class=" g-3">
            <h1>Equipments</h1>
            <asp:Button ID="btnAddNew" OnClick="btnAddNew_Click" CssClass="btn btn-primary my-4" runat="server" Text="+ Add New Equipment" />
        </div>

        <asp:GridView CssClass="table table-primary" ID="GridView1" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="ACTIONS">
                    <ItemTemplate>
                       
                        <asp:HyperLink NavigateUrl='<%# "NewBooking?id=" + Eval("equipment_id") %>' runat="server"><span class="btn btn-primary border-4">BOOK</span></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>

    </main>
</asp:Content>
