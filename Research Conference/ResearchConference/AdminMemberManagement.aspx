<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="AdminMemberManagement.aspx.cs" Inherits="ResearchConference.AdminMemberManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                           <h4>Member Details</h4>
                        </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                           <img width="100px" src="imgs/generaluser.png" />
                        </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <asp:Label ID="lblmessage" runat="server" Visible="false" ForeColor="Green" Font-Bold="true"></asp:Label>
                        </div>
                        <br />
                        <br />
                        <div class="row">
                            <div class="col-md-4">
                                <label>Enter Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TxtMbrID" runat="server" placeholder="Member ID"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5" runat="server" visible="false" id="divAccountStatus">
                                <label>Account Status : </label>
                                <asp:Label runat="server" ID="txtAccount" Font-Bold="true"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-5" runat="server" id="divDispalyName" visible="false">
                                <label>Display Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TxtDisplayName" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5" runat="server" id="divLoginId" visible="false">
                                <label>Username</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TxtUserName" runat="server" placeholder="Enter User Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-5" runat="server" id="divpassword" visible="false">
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-5" runat="server" visible="false" id="divSalt">
                                <label>Salt</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TxtSalt" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-5" runat="server" visible="false" id="divMaxRevw">
                                <label>Max Review</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TxtMaxReview" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-5" runat="server" visible="false" id="divRole">
                                <label>Role</label>
                                <div class="form-group">
                                    <asp:DropDownList runat="server" ID="ddRole">
                                        <asp:ListItem Value="1" Text="Sys admin"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Conference Chair"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Reviewer"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Author"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8 mx-auto">
                                <asp:Button ID="Search" class="btn btn-lg btn-block btn-danger" runat="server" Text="Search" OnClick="Search_Click" />
                                <asp:Button ID="Insert" class="btn btn-lg btn-block btn-danger" runat="server" Text="Insert New User" OnClick="Insert_Click" Visible="false" />
                                <asp:Button ID="Update" class="btn btn-lg btn-block btn-danger" runat="server" Text="Update Existing User" OnClick="Update_Click" Visible="false" />
                                <asp:Button ID="DeleteButton" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete User Permanently" OnClick="DeleteButton_Click" Visible="false" />
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <a href="homepage.aspx"><< Back to Home</a><br>
                <br>
            </div>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                           <h4>Member List</h4>
                        </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:GridView ID="GV1" runat="server" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField DataField="UserID" HeaderText="User ID" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" />
                                        <asp:BoundField DataField="Role" HeaderText="Role" />
                                        <asp:BoundField DataField="MaxReview" HeaderText="MaxReview" />
                                    </Columns>
                                    <HeaderStyle BackColor="#0066cc" Font-Bold="true" ForeColor="White" />
                                    <RowStyle BackColor="#bfdfff" ForeColor="Black" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


