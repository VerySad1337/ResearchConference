<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmationBidPaper.aspx.cs" Inherits="ResearchConference.ConfirmationBidPaper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></br>
    <asp:Button ID="Button1" runat="server" Text="Yes" OnClick="Button1_Click" />
    <asp:Button ID="Button2" runat="server" Text="No" OnClientClick="JavaScript:window.history.back(1); return false;"/>
</asp:Content>
