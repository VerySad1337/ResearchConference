<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReviewerDirectory.aspx.cs" Inherits="ResearchConference.ReviewerDirectory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:Table ID="Table2" runat="server" HorizontalAlign="Center">
        <asp:TableHeaderRow>
            <asp:TableCell>
            Navigations
                </asp:TableCell>
            </asp:TableHeaderRow>
    </asp:Table>
    <br />
    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
        <asp:TableHeaderRow>
            
        </asp:TableHeaderRow>
        <asp:TableFooterRow>
            <asp:TableCell>
                <asp:Button ID="viewreviewButton" runat="server" Text="View reviews" PostBackUrl="~/ViewReview.aspx"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="bidforpaperButton" runat="server" Text="Bid for paper" PostBackUrl="~/BidForPaper.aspx"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="currentmaxreviewButton" runat="server" Text="Current max review" PostBackUrl="~/CurrentMaxReview.aspx"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="publishpaperButton" runat="server" Text="Publish paper" PostBackUrl="~/PublishPaper.aspx"/>
            </asp:TableCell>
        </asp:TableFooterRow>

    </asp:Table>
</asp:Content>
