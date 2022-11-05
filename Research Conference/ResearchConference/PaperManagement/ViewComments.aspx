<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewComments.aspx.cs" Inherits="ResearchConference.PaperManagement.ViewComments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12">
            <h2><asp:Label ID="lblTitle" runat="server" Text="View Paper Comment(s)"></asp:Label></h2>
            <hr />
            <h4><asp:Label ID="lblErrormsg" runat="server" ></asp:Label></h4>
            <asp:GridView ID="gridPaper" runat="server" CssClass="table table-bordered table-hover table-striped" AllowPaging="True"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="350px" HeaderText="Comment(s)">
                        <ItemTemplate>
                            <asp:Label ID="lblComments" runat="server"
                                Text='<%#Eval("Comments")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="70px" HeaderText="Posted Date">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server"
                                Text='<%#Eval("Date")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </div>
</asp:Content>
