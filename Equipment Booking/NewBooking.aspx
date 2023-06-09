<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewBooking.aspx.cs" Inherits="Equipment_Booking.NewBooking" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        

        <div class="w-75 m-auto">
            <h1>ADD BOOKING</h1>

            <p>Enter information for booking this equipment. Please ensure all information is valid and true.</p>
        <div class="row m-auto mb-5 ">
   
            <div class="col-6">
                <label class="form-label">Equipment Name</label>
                <asp:TextBox CssClass="form-control" ID="txtName" runat="server"></asp:TextBox>
            </div>

            <div class="col-6">
                <label class="form-label">Rate(per Day)</label>
                <asp:TextBox CssClass="form-control" TextMode="Number" ID="txtRate" runat="server"></asp:TextBox>
            </div>
            
            <div class="col-6">
                <label class="form-label">First Name</label>
                <asp:TextBox CssClass="form-control" ID="txtFName" runat="server"></asp:TextBox>
            </div>
            
            <div class="col-6">
                <label class="form-label">Last Name</label>
                <asp:TextBox CssClass="form-control" ID="txtLName" runat="server"></asp:TextBox>
            </div>

            <div class="col-6">
                <label class="form-label">Email</label>
                <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server"></asp:TextBox>
            </div>
            
            <div class="col-6">
                <label class="form-label">TRN</label>
                <asp:TextBox CssClass="form-control" ID="txttrn" runat="server"></asp:TextBox>
            </div>

            <div class="col-6">
                <label class="form-label">ADDRESS line 1</label>
                <asp:TextBox CssClass="form-control" ID="txtAddress1" runat="server"></asp:TextBox>
            </div>
            
            <div class="col-6">
                <label class="form-label">ADDRESS line 2</label>
                <asp:TextBox CssClass="form-control" ID="txtAddress2" runat="server"></asp:TextBox>
            </div>

            <div class="col-6">
                <label class="form-label">Passport Photo</label>
                <asp:TextBox CssClass="form-control" ID="txtPhoto" runat="server"></asp:TextBox>
            </div>

            <div class="col-6">
                <label class="form-label">Phone Number</label>
                <asp:TextBox CssClass="form-control" ID="txtPhone" runat="server"></asp:TextBox>
            </div>

            <div class="col-6">
                <label class="form-label">Start Date</label>
                <asp:TextBox CssClass="form-control" TextMode="Date" ID="dateStart" runat="server"></asp:TextBox>
            </div>

            <div class="col-6">
                <label class="form-label">Return Date</label>
                <asp:TextBox CssClass="form-control" TextMode="Date" ID="dateEnd" runat="server"></asp:TextBox>
            </div>

            


        </div>

            <asp:Button ID="btnAdd" CssClass="btn btn-primary" OnClick="btnAdd_Click" runat="server" Text="Add Booking" />
            <br />
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
        </div>

    </main>
</asp:Content>
