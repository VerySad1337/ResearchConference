<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ResearchConference.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Login ID="Login1" runat="server" OnAuthenticate="ValidateUser">
        <LayoutTemplate>
            <div class="container">
                <div class="col-md-6 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <center>
                           <img width="150px" src="imgs/generaluser.png"/>
                        </center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <center>
                           <h3>Member Login</h3>
                        </center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <hr>
                                </div>
                            </div>
                            <div class="col-6">
                            </div>
                            <div class="col-6">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="UserName" runat="server" placeholder="Member ID"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="User Name is required." ForeColor="Red" ToolTip="User Name is required."
                                        ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </div>
                                <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="Password" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="Password is required." ForeColor="Red" ToolTip="Password is required."
                                        ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember me next time." />
                                </div>
                                <div align="center" colspan="2" style="color: Red;">
                                    <asp:Literal ID="lblFailureText" runat="server"></asp:Literal>
                                </div>
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="btnLogin" runat="server" Text="Login" CommandName="Login" ValidationGroup="Login1" OnClick="btnLogin_Click1" />
                                </div>
                                <div class="form-group">
                                    <a href="usersignup.aspx">
                                        <input class="btn btn-info btn-block btn-lg" id="Button2" type="button" value="Sign Up" /></a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br>
                </div>
            </div>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>
