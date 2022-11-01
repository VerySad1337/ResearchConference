<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddReview.aspx.cs" Inherits="ResearchConference.AddReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label ID="Label5" runat="server" Text=""></asp:Label> 
    <br />
    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    <br />
    
    <asp:Label ID="Label3" runat="server" Text="Select your rating for this paper: "></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="RatingDropDownlist" DataTextField="Grades" DataValueField="Grades" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="RatingDropDownlist" runat="server" ConnectionString="<%$ ConnectionStrings:RCMSConnectionString %>" SelectCommand="SELECT [Grades] FROM [Gradings]" OnSelecting="RatingDropDownlist_Selecting"></asp:SqlDataSource> </br>

    
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update / Give Review" />
    
    <asp:Button ID="Button2" runat="server" Text="Back" OnClientClick="JavaScript:window.history.back(1); return false;"/>
    
    </asp:Content>
