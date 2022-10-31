<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Successful.aspx.cs" Inherits="ResearchConference.Successful" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label3" runat="server" Text="Successful"></asp:Label></br>
    <asp:Button ID="Button1" runat="server" Text="Back to previous page" OnClientClick="JavaScript:window.history.back(1); return false;" /> 
</asp:Content>
