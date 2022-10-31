<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewReview.aspx.cs" Inherits="ResearchConference.ViewReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label3" runat="server" BorderStyle="Solid" Text="View your assigned review"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="AllocationID,Expr1" DataSourceID="ViewReviewFromDB">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="AllocationID" HeaderText="AllocationID" ReadOnly="True" SortExpression="AllocationID" />
            <asp:BoundField DataField="PaperID" HeaderText="PaperID" SortExpression="PaperID" />
            <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
            <asp:BoundField DataField="GradeID" HeaderText="GradeID" SortExpression="GradeID" />
            <asp:BoundField DataField="Expr1" HeaderText="Expr1" ReadOnly="True" SortExpression="Expr1" />
            <asp:BoundField DataField="Expr2" HeaderText="Expr2" SortExpression="Expr2" />
            <asp:BoundField DataField="PaperTitle" HeaderText="PaperTitle" SortExpression="PaperTitle" />
            <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="ViewReviewFromDB" runat="server" ConnectionString="<%$ ConnectionStrings:RCMSConnectionString %>" OnSelecting="ViewReviewFromDB_Selecting" SelectCommand="SELECT Allocation.AllocationID, Allocation.PaperID, Allocation.UserID, Allocation.GradeID, Paper.PaperID AS Expr1, Paper.Date, Paper.GradeID AS Expr2, Paper.PaperTitle, Paper.URL FROM Allocation INNER JOIN Paper ON Allocation.PaperID = Paper.PaperID ORDER BY Allocation.PaperID"></asp:SqlDataSource>
</asp:Content>
