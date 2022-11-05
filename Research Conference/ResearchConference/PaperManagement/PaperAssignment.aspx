<%@ Page Title="Paper Assignment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaperAssignment.aspx.cs" Inherits="ResearchConference.PaperAssignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>Paper Assignment</h2>
            <hr />



            <div class="row">
                <div class="col-md-2">
                    <div class="form-group">
                        <asp:Label ID="lblPaper" Text="Select Paper*: " AssociatedControlID="ddlPaperselection" runat="server">
                        </asp:Label>
                    </div>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList AutoPostBack="true" CssClass="dropdown" ValidationGroup="check1"
                        ID="ddlPaperselection" runat="server" Style="width: 150px; height: 30px; text-indent: 25px;"
                        OnSelectedIndexChanged="ddlPaperselection_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqPaper" runat="server" ControlToValidate="ddlPaperselection" ValidationGroup="check1" InitialValue=""
                        ErrorMessage="Paper is required." ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>


            <div class="form-group">
                <div class="row">
                    <div class="col-md-2">
                        <label>Select Reviewer*: </label>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList AutoPostBack="true" CssClass="dropdown" ValidationGroup="check1"
                            ID="ddlReviewer" runat="server" Style="width: 150px; height: 30px; max-width: 150px; text-indent: 25px;"
                            OnSelectedIndexChanged="ddlReviewer_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic"
                            ValidationGroup="check1" runat="server" ControlToValidate="ddlReviewer" InitialValue=""
                            ErrorMessage="Reviewer is required." ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <div class="form-group">
                <asp:Button class="btn btn-block btn-lg" ID="btnAssign" Style="width: inherit" runat="server" Text="Assign" ValidationGroup="check1" OnClick="btnAssignOnClick" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblSuccessMsg" Text="Successfully Assigned!" AssociatedControlID="ddlPaperselection" runat="server" Visible="false" ForeColor="Green">
                </asp:Label>
                <asp:Label ID="lblErrorMsg" Text="Successfully Assigned!" AssociatedControlID="ddlPaperselection" runat="server" Visible="false" Enabled="false" ForeColor="Red">
                </asp:Label>
            </div>


        </div>
    </div>
</asp:Content>
