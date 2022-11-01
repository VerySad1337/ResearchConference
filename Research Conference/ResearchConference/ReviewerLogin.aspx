<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReviewerLogin.aspx.cs" Inherits="ResearchConference.ReviewerLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label3" runat="server" Text="Login"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></br>
    <asp:Label ID="Label1" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></br>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /><br />
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
</asp:Content>
