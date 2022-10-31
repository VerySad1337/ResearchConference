<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddComments.aspx.cs" Inherits="ResearchConference.AddComments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label3" runat="server" Text="Add your comments:"></asp:Label></br>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></br>
    <asp:Button ID="onSubmit" runat="server" Text="Submit" OnClick="Button1_Click" />
    <asp:Button ID="cancel" runat="server" Text="Cancel"  OnClientClick="JavaScript:window.history.back(1); return false;" />
    
</asp:Content>
