<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BidForPaper.aspx.cs" Inherits="ResearchConference.BidForPaper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="PaperTitle" HeaderText="PaperTitle" SortExpression="PaperTitle" />
            <asp:BoundField DataField="URL" HeaderText="URL" SortExpression="URL" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="bidPaper" Text ="Bid for Paper" runat ="server" CommandArgument='<%# Eval("PaperID") %>' OnClick ="bidPaper_Click" />                 
                </ItemTemplate>                
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label3" runat="server"></asp:Label>
</asp:Content>
