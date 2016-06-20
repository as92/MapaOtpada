<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MapaOtpada.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="welcome" runat="server">
  <%--  <form runat="server">
    <li>
        <a href="Prijava.aspx" id="prijava" runat="server"><b>Prijava</b></a>
    </li>
    <li>
        
        <asp:Button ID="odjava" runat="server" OnClick="OdjavaClick" Text="Odjava" />
        
    </li>
    </form>--%>
    <asp:Label ID="korisnik" runat="server" Text="Korisnik"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="map-canvas">
       
    </div>
    <div class="modal fade" id="spremiModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
    	  <div class="modal-dialog">
				<div class="loginmodal-container">
					<h1>Login to Your Account</h1><br/>
				  <form id="formSpremi" runat="server" action="#">
					  <input  id="sirina" type="hidden" name="sirina" value = "" runat="server" />
                      <input  id="duzina" type="hidden" name="duzina" value = "" runat="server"/>
                      <input  id="opis" type="text" name="opis" placeholder="Opis" required  runat="server"/>
                       <input type="file" class="upload"  id="fileUpload" runat="server" name="file"/>
                      <asp:Button ID="BtnUnos" runat="server" Text="Unesi"  OnClick="BtnUnos_Click" Font-Size="Medium" />
					  <%--<input type="submit" name="spremi" class="login loginmodal-submit" value="Spremi"/>--%>
				  </form>
				</div>
			</div>
	</div>
        <div class="modal fade" id="prikazModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
    	  <div class="modal-dialog">
				<div class="loginmodal-container">
					<h1 class="opisNaslov"></h1>
                    <img class="opisSlika" alt="" src="" />
				</div>
			</div>
	</div>
</asp:Content>

