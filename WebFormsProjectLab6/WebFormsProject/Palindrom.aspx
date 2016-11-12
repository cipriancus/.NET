<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Palindrom.aspx.cs" Inherits="WebFormsProject.Palindrom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Palindrom:</h2> 
     
    <div class="form-horizontal">
     <div class="form-group">
      <hr/> 
      <asp:TextBox ID="palindromTxt" runat="server"></asp:TextBox>
    
      <asp:Button ID="buttonPalindrom" runat="server" Text="Check" OnClick="btnPalindrom" />
      <br />
     
      <asp:Label ID="result" runat="server"></asp:Label>

       </div>
    </div>
</asp:Content>
