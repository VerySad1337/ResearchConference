<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddReview.aspx.cs" Inherits="ResearchConference.AddReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label ID="Label4" runat="server" Text="Current rating Paper ID : "></asp:Label>
    <asp:Label ID="Label5" runat="server" Text=""></asp:Label> <br />
    
    <asp:Label ID="Label3" runat="server" Text="Select your rating for this paper: "></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="RatingDropDownlist" DataTextField="Grades" DataValueField="Grades" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="RatingDropDownlist" runat="server" ConnectionString="<%$ ConnectionStrings:RCMSConnectionString %>" SelectCommand="SELECT [Grades] FROM [Gradings]"></asp:SqlDataSource>
    
    </asp:Content>
