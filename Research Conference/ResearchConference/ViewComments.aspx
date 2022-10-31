<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewComments.aspx.cs" Inherits="ResearchConference.ViewComments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label3" runat="server" Text="List of comments for this post:"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ViewCommentsfromDB">
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
            <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />
            <asp:BoundField DataField="ModifiedDate" HeaderText="ModifiedDate" SortExpression="ModifiedDate" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="ViewCommentsfromDB" runat="server" ConnectionString="<%$ ConnectionStrings:RCMSConnectionString %>" SelectCommand="SELECT [UserID], [Comments], [ModifiedDate], [CreatedDate] FROM [Comments]"></asp:SqlDataSource>
</asp:Content>
