<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReviewerLogin.aspx.cs" Inherits="ResearchConference.ReviewerLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="displayTable">
    <asp:Label ID="Label3" runat="server" Text="Login"></asp:Label></br>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox></br>
    <asp:Label ID="Label1" runat="server" Text="Password"></asp:Label></br>
    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox></br>
    <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" class="btn btn-success btn-block btn-lg"/><br />
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label></BR>
    </div>
</asp:Content>
