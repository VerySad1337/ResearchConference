<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewReview.aspx.cs" Inherits="ResearchConference.ViewReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label3" runat="server" Text="View your assigned review"></asp:Label>
    <asp:SqlDataSource ID="ViewReviewFromDB" runat="server" ConnectionString="<%$ ConnectionStrings:RCMSConnectionString %>" OnSelecting="ViewReviewFromDB_Selecting" SelectCommand="SELECT Allocation.AllocationID, Allocation.PaperID,  Allocation.UserID,Users.Name, Allocation.GradeID, Paper.Date, Paper.PaperTitle, Paper.URL  FROM (Allocation  INNER JOIN Paper ON Allocation.PaperID = Paper.PaperID) INNER JOIN USERS on Allocation.UserID = Users.UserID "></asp:SqlDataSource>


    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="AllocationID" HeaderText="AllocationID" InsertVisible="False" ReadOnly="True" SortExpression="AllocationID" />
            <asp:BoundField DataField="PaperID" HeaderText="PaperID" SortExpression="PaperID" />
            <%--<asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" /> --%>
            <asp:BoundField DataField="PaperTitle" HeaderText="PaperTitle" SortExpression="PaperTitle" />
            <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL" />
            <asp:BoundField DataField="GradeID" HeaderText="GradeID" SortExpression="GradeID" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="giveReview" Text ="Give Review" runat ="server" CommandArgument='<%# Eval("session") %>' OnClick ="giveReview_Click" />                 
                </ItemTemplate>                
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="giveComments" Text ="Give Comments" runat ="server" CommandArgument='<%# Eval("session") %>' OnClick ="giveComments_Click"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
