<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compute.aspx.cs" Inherits="WebFormsProject.Compute" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Compute:</h2> 
     
    <div class="form-horizontal">
     <div class="form-group">

       <hr/> 
      <asp:TextBox ID="txtNumber1" runat="server" TextMode="Number"></asp:TextBox>
    
      <asp:TextBox ID="txtNumber2" runat="server" TextMode="Number"></asp:TextBox>

       <asp:TextBox ID="txtNumber3" runat="server" TextMode="Number"></asp:TextBox>

      <asp:Button ID="Button1" runat="server" Text="Compute" OnClick="btnCompute" />
      <br />
      <asp:Label ID="result" runat="server"></asp:Label>

      <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNumber1"
                                            CssClass="text-danger" ErrorMessage="Only numbers allowed"/>
      <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNumber2"
                                            CssClass="text-danger" ErrorMessage="Only numbers allowed"/>
      <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNumber3"
                                            CssClass="text-danger" ErrorMessage="Only numbers allowed"/>
       </div>
    </div>
</asp:Content>