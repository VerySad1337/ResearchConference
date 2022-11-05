<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CurrentMaxReview.aspx.cs" Inherits="ResearchConference.CurrentMaxReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label3" runat="server" Text="Current Max Review Status (Tied to UserID 3 Only):"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label> </br>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> </br>
    <asp:Button ID="Button1" runat="server" Text="Set Max Review Now" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="Back" OnClientClick="JavaScript:window.history.back(1); return false;"  />
</asp:Content>
