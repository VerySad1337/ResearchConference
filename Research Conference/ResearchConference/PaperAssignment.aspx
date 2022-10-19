<%@ Page Title="Paper Assignment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaperAssignment.aspx.cs" Inherits="ResearchConference.PaperAssignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col">
            <h2>Paper Assignment</h2>
            <hr />
            <div class="col-6">

                <div class="form-group">
                    <label>Select Paper: </label>
                    <asp:DropDownList AutoPostBack="true" CssClass="dropdown" ValidationGroup="g1"
                        ID="ddlPaperselection" runat="server" Style="width: 150px;height:30px; max-width: 150px"
                        OnSelectedIndexChanged="ddlPaperselection_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator InitialValue="-1" ID="Req_ID" Display="Dynamic"
                        ValidationGroup="g1" runat="server" ControlToValidate="ddlPaperselection"
                        Text="*" ErrorMessage="paper is required."></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <label>Select Reviewer: </label>
                    <asp:DropDownList AutoPostBack="true" CssClass="dropdown" ValidationGroup="g2"
                        ID="ddlReviewer" runat="server" Style="width: 150px; height:30px; max-width: 150px"
                        OnSelectedIndexChanged="ddlReviewer_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator1" Display="Dynamic"
                        ValidationGroup="g2" runat="server" ControlToValidate="ddlReviewer"
                        Text="*" ErrorMessage="reviewer is required."></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:Button class="btn btn-block btn-lg" ID="btnAssign" runat="server" Text="Assign" ValidationGroup="" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
