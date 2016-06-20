<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Registracija.aspx.cs" Inherits="MapaOtpada.Registracija" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="reg">
    <div class="loginmodal-container">
	 <h1>Registracija</h1><br/>
      <form id="formLogin" runat="server">
          <asp:TextBox ID="TbIme" runat="server" required="true"  placeholder="Ime"></asp:TextBox>
          <asp:TextBox ID="TbPrezime" runat="server" required="true"  placeholder="Prezime"></asp:TextBox>
          <asp:TextBox ID="TbKor" runat="server" required="true"  placeholder="Korisničko ime"></asp:TextBox>
          <asp:TextBox ID="TbSifra" runat="server" required="true" placeholder="Lozinka" TextMode="Password"></asp:TextBox>
          <asp:TextBox ID="TbEmail" runat="server" required="true"  placeholder="Email" TextMode="Email"></asp:TextBox>
          <asp:Button CssClass="login loginmodal-submit" ID="btnSubmit" OnClick="RegisterButtonClick" runat="server" Text="Registracija" />
	  </form>
    </div>
   </div>
</asp:Content>
