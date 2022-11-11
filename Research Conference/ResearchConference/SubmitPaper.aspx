<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubmitPaper.aspx.cs" Inherits="ResearchConference.SubmitPaper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <center>
    <h2>Research Conference</h2>
        <h4>Submit Your Paper to Review</h4>
    </center>


 <center>

    
    <asp:Label ID="Label3" runat="server" Text="Please upload your paper on google drive."></asp:Label></br> </br>

    <div class="form-group">
     <asp:TextBox CssClass="form-control" ID="PaperTitle" runat="server" placeholder="Paper Title"></asp:TextBox>
    <asp:RequiredFieldValidator ID="titleValidate" 
   runat="server" ControlToValidate ="PaperTitle" 
   ErrorMessage="Please enter the paper title" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>


    <div class="form-group">
     <asp:TextBox CssClass="form-control" ID="URL" runat="server" placeholder="URL Link"></asp:TextBox>
    <asp:RequiredFieldValidator ID="urlValidate" 
    runat="server" ControlToValidate ="URL" 
     ErrorMessage="Please enter the URL" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    

  
    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    <asp:Button class="btn btn-cancel btn-block btn-lg" ID="Button2" runat="server" Text="Cancel" OnClientClick="JavaScript:window.history.back(1); return false;" />
</center>

</asp:Content>
