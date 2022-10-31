<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewReview.aspx.cs" Inherits="ResearchConference.ViewReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label3" runat="server" BorderStyle="Solid" Text="View your assigned review"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="AllocationID" DataSourceID="ViewReviewFromDB">
        <Columns>
            <asp:BoundField DataField="AllocationID" HeaderText="AllocationID" ReadOnly="True" SortExpression="AllocationID" InsertVisible="False" />
            <asp:BoundField DataField="PaperID" HeaderText="PaperID" SortExpression="PaperID" />
            <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="GradeID" HeaderText="GradeID" SortExpression="GradeID" />
            <asp:BoundField DataField="PaperTitle" HeaderText="PaperTitle" SortExpression="PaperTitle" />
            <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="ViewReviewFromDB" runat="server" ConnectionString="<%$ ConnectionStrings:RCMSConnectionString %>" OnSelecting="ViewReviewFromDB_Selecting" SelectCommand="SELECT Allocation.AllocationID, Allocation.PaperID,  Allocation.UserID,Users.Name, Allocation.GradeID, Paper.Date, Paper.PaperTitle, Paper.URL  FROM (Allocation  INNER JOIN Paper ON Allocation.PaperID = Paper.PaperID) INNER JOIN USERS on Allocation.UserID = Users.UserID "></asp:SqlDataSource>
</asp:Content>
