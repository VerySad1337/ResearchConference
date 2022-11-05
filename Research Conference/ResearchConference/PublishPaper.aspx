<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PublishPaper.aspx.cs" Inherits="ResearchConference.PublishPaper" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <center>
    <h2>Research Conference</h2>
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
     <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="URL Link"></asp:TextBox>
    <asp:RequiredFieldValidator ID="urlValidate" 
    runat="server" ControlToValidate ="TextBox2" 
     ErrorMessage="Please enter the URL" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    
   <%--
 <asp:Label ID="Label4" runat="server" Text="Paper Title : "></asp:Label> >
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </br>
    <asp:Label ID="Label5" runat="server" Text="URL: "></asp:Label>

    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>--%>
  
    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
    <asp:Button class="btn btn-cancel btn-block btn-lg" ID="Button2" runat="server" Text="Cancel" OnClientClick="JavaScript:window.history.back(1); return false;" />
</center>

</asp:Content>
