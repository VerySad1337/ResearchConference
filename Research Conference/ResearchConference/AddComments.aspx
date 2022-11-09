<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddComments.aspx.cs" Inherits="ResearchConference.AddComments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label3" runat="server" Text="Adding your comments for:"></asp:Label></br>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> </br>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~\viewComments">View Comments</asp:HyperLink>
    </br>
    <asp:Button ID="onSubmit" runat="server" Text="Submit" OnClick="Button1_Click" />
    <asp:Button ID="cancel" runat="server" Text="Back"  OnClientClick="JavaScript:window.history.back(1); return false;" OnClick="cancel_Click" />
    
</asp:Content>
