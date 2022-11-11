<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPage.aspx.cs" Inherits="ResearchConference.PaperManagement.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
</script>
    <div class="row">
        <div class="col-md-12">
            <h2>View Rated Paper(s)</h2>
            <hr />

            <div class="col-md-4">
                <div class="form-group">
                    <div style="float: left;">
                        <asp:Button ID="btn1" class="btn btn-block btn-lg" Style="border: 3px solid rgb(64,75,128); width: inherit" runat="server" PostBackUrl="~/PaperManagement/PaperAssignment.aspx" Text="Paper Assignment"></asp:Button>
                    </div>
                    <div style="float: right">
                        <asp:Button ID="btnViewPaper" class="btn btn-block btn-lg" Style="border: 3px solid rgb(64,75,128); width: inherit" runat="server" PostBackUrl="~/PaperManagement/ViewPage.aspx" Text="View Paper List"></asp:Button>
                    </div>
                    <div style="clear: both"></div>
                </div>
            </div>

            <div class="form-group">
            </div>

            <div class="form-group">
                <asp:Label ID="lblSuccessMsg" Text="Successfully Assigned!" AssociatedControlID="ddlPaperselection" runat="server" Visible="false" ForeColor="Green">
                </asp:Label>
                <asp:Label ID="lblErrorMsg" Text="Successfully Assigned!" AssociatedControlID="ddlPaperselection" runat="server" Visible="false" Enabled="false" ForeColor="Red">
                </asp:Label>
            </div>
            <br />
            <br />


            <asp:GridView ID="gridPaper" runat="server" CssClass="table table-bordered table-hover table-striped" AllowPaging="True"
                OnPageIndexChanging="OnPageIndexChanging"
                OnRowCancelingEdit="gridPaper_RowCancelingEdit"
                OnRowEditing="gridPaper_RowEditing" OnRowUpdating="gridPaper_RowUpdating" PagerStyle-Height="400px"
                PageSize="5" AutoGenerateColumns="false" ShowFooter="true">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="250px" HeaderText="Paper Title Name" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblPaperID" runat="server"
                                Text='<%#Eval("PaperID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="250px" HeaderText="Author" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblAuthorID" runat="server"
                                Text='<%#Eval("UserIDPosted")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="250px" HeaderText="Paper Title Name">
                        <ItemTemplate>
                            <asp:Label ID="lblTitle" runat="server"
                                Text='<%#Eval("PaperTitle")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:HyperLinkField ID="paperURL" runat="server" Text='<%# Eval("URL") %>' NavigateUrl='<%# Eval("URL") %>' />--%>
                    <asp:TemplateField ItemStyle-Width="280px" HeaderStyle-Wrap="false" HeaderText="Paper Posted URL">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnIdLink" runat="server" Text='<%# Bind("URL") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-Wrap="false" HeaderText="Rating (out of 1.0)">
                        <ItemTemplate>
                            <asp:Label ID="lbltotalRate" runat="server" Text='<%#Eval("finalRate")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="100px" HeaderStyle-Wrap="false">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink2" runat="server" Text="View Comment(s)" Target ="_blank" NavigateUrl='<%#String.Format("~/PaperManagement/ViewComments.aspx?id={0}", Eval("PaperID"))%>'
                                 ></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField ItemStyle-Width="120px" HeaderText="Approval Status">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Approval")%>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlApproval" runat="server" AppendDataBoundItems="true" AutoPostBack="true" Style="width: 100px">
                                <asp:ListItem Text="Approve" Value="Approved" Selected="True" />
                                <asp:ListItem Text="Reject" Value="Rejected" />
                            </asp:DropDownList>
                            <%--<asp:TextBox ID="txtxApproval" runat="server" Text='<%#Eval("Approval")%>'></asp:TextBox>--%>
                        </EditItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <%-- <asp:TemplateField ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument='<%#  
                                         Eval("PaperID")%>'
                                        OnClientClick="return confirm('Do you want to delete?')"
                                        Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:TemplateField>--%>
                    <%--<asp:CommandField ShowEditButton="True" ItemStyle-Width="50px" />--%>
                    <asp:CommandField ShowEditButton="True" ItemStyle-Width="130px" ButtonType="Button" ControlStyle-CssClass="edit-sprite"></asp:CommandField>
                    <%--<asp:TemplateField ShowHeader="False">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="UpdateButton" runat="server" CssClass="UpdateButton" CommandName="Update" Text="Update" />&nbsp;<asp:LinkButton ID="Cancel" runat="server"
                                        CssClass="CancelButton" CommandName="Cancel" Text="Cancel" />
                                </EditItemTemplate>
                            </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
            <br/>
            <div class="form-group">
                <asp:Label ID="lblEmailSuccess" Text="Notification Email has been sent to Author." runat="server" Visible="false" ForeColor="Green" Font-Bold="true">
                </asp:Label>
            </div>
            <br />

        </div>
    </div>

</asp:Content>
