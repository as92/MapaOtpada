<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Prijava.aspx.cs" Inherits="MapaOtpada.Prijava" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="reg">
    <div class="loginmodal-container">
	 <h1>Prijava</h1><br/>
      <form id="formLogin" runat="server">
          <asp:TextBox ID="TbKor" runat="server" required="true"  placeholder="Korisničko ime"></asp:TextBox>
          <asp:TextBox ID="TbSifra" runat="server" required="true" placeholder="Lozinka"></asp:TextBox>
          <asp:Button CssClass="login loginmodal-submit" ID="btnSubmit" OnClick="LoginButtonClick" runat="server" Text="Prijava" />
	  </form>
    </div>
   </div>
</asp:Content>
