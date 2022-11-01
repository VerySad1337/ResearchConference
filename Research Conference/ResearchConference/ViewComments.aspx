<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewComments.aspx.cs" Inherits="ResearchConference.ViewComments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label3" runat="server" Text="List of comments for this post:"></asp:Label>
    <asp:SqlDataSource ID="ViewCommentsfromDB" runat="server" ConnectionString="<%$ ConnectionStrings:RCMSConnectionString %>" SelectCommand="SELECT [Comments], [UserID], [PaperID] FROM [Comments]"></asp:SqlDataSource>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="CommentID" HeaderText="CommentID" InsertVisible="False" ReadOnly="True" SortExpression="AllocationID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="PaperID" />
            <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="URL" />
        </Columns>
    </asp:GridView>
</asp:Content>
