<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEquipments.aspx.cs" Inherits="Equipment_Booking.AddEquipments" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        

        <div class="w-75 m-auto">
            <h1>NEW EQUIPMENT</h1>

            <p>Please enter the following information for a new equipment.</p>
            
        <div class="row m-auto mb-5 ">
   
            <div class="col-6">
                <label class="form-label">Equipment Name</label>
                <asp:TextBox CssClass="form-control" ID="txtName" runat="server"></asp:TextBox>
            </div>
            <div class="col-6">
                <label class="form-label">Type</label>
                <asp:TextBox CssClass="form-control" ID="txtType" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <label class="form-label">Equipment Cost</label>

                <div class="input-group">
                    <span class="input-group-text">$$</span>
                    <asp:TextBox CssClass="form-control" TextMode="Number" ID="txtCost" runat="server"></asp:TextBox>
                </div>
            </div>
            


        </div>

            <asp:Button ID="btnAdd" OnClick="btnAdd_Click" CssClass="btn btn-primary" runat="server" Text="Add Equipment" />
            <br />
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
        </div>
    </main>
</asp:Content>
