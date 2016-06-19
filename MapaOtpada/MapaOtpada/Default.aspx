<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MapaOtpada.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="welcome" runat="server">
    <form runat="server">
    <li>
        <a href="Prijava.aspx" id="prijava" runat="server"><b>Prijava</b></a>
    </li>
    <li>
        
        <asp:Button ID="odjava" runat="server" OnClick="OdjavaClick" Text="Odjava" />
        
    </li>
    </form>
    <asp:Label ID="korisnik" runat="server" Text="Korisnik"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="map-canvas">
       
    </div>
    <div class="modal fade" id="spremiModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
    	  <div class="modal-dialog">
				<div class="loginmodal-container">
					<h1>Login to Your Account</h1><br/>
				  <form id="formSpremi">
					  <input  id="sirina" type="hidden" name="sirina" value = ""/>
                      <input  id="duzina" type="hidden" name="duzina" value = ""/>
                      <input  id="opis" type="text" name="opis" placeholder="Opis" required/>
					  <input type="submit" name="spremi" class="login loginmodal-submit" value="Spremi"/>
				  </form>
				</div>
			</div>
	</div>
        <div class="modal fade" id="prikazModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
    	  <div class="modal-dialog">
				<div class="loginmodal-container">
					<h1 class="opisNaslov"></h1>
                    <img alt="" src="Images/9691b1d935242437ce69da71562e8026.jpg" />
				</div>
			</div>
	</div>
</asp:Content>

