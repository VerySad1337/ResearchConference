<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PublishPaper.aspx.cs" Inherits="ResearchConference.PublishPaper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label3" runat="server" Text="Please upload your paper on google drive."></asp:Label></br>
    <asp:Label ID="Label4" runat="server" Text="Paper Title : "></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </br>
    <asp:Label ID="Label5" runat="server" Text="URL: "></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </br>
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="Cancel" OnClientClick="JavaScript:window.history.back(1); return false;" />
</asp:Content>
