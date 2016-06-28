<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MapaOtpada.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="welcome" runat="server">
    <li>
        <a href="Prijava.aspx" id="prijava" runat="server"><b>Prijava</b></a>
    </li>
    <li class="lilert">
        <asp:Button ID="odjava" runat="server" CssClass="btn" OnClick="OdjavaClick" Text="Odjava" />
    </li>
    <li>
        <asp:Label ID="korisnik" runat="server" Text="Korisnik"></asp:Label></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="map-canvas">
        <!-- map canvas je inicijaliziran u template.master.cs, stavljamo ga u div -->
    </div>
    <%--<div class="modal fade" id="spremiModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="loginmodal-container">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h1>Unos Otpada</h1>
                <br />
                <input id="sirina" type="hidden" name="sirina" value="" runat="server" />
                <input id="duzina" type="hidden" name="duzina" value="" runat="server" />
                <input id="opis" type="text" name="opis" placeholder="Opis" runat="server" />
                <input type="file" id="fileUpload" runat="server" name="file" />
                <asp:Button ID="BtnUnos" CssClass="login loginmodal-submit" runat="server" Text="Unesi" OnClick="BtnUnos_Click" Font-Size="Medium" />
            </div>
        </div>
    </div>--%>
    <div class="modal fade" id="spremiModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h3>Unos Otpada</h3>
                <br />
                <input id="sirina" type="hidden" name="sirina" value="" runat="server" />
                <input id="duzina" type="hidden" name="duzina" value="" runat="server" />
                 </div>
                <div class="modal-body">
                    <input id="opis" type="text" name="opis" placeholder="Opis" runat="server" />
                    <input type="file" id="fileUpload" runat="server" name="file" />
                </div>
                <div class="modal-footer">
                        <p class="korisnik" style="float:left"></p>
                    <asp:Button ID="BtnUnos" CssClass="btn btn-primary" runat="server" Text="Unesi" OnClick="BtnUnos_Click" Font-Size="Medium" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="prikazModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
        <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header">
                 <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <input class="markerId" id="markerId" type="hidden" name="markerId" value="" runat="server" />
                 <h4 class="modal-title"></h4>
                    </div>                  
                     <div class="modal-body">
                        <img class="opisSlika" alt="" src="" />
                    </div>
                    <div class="modal-footer">
                        <p class="korisnik" style="float:left"></p>
                        <asp:Button ID="BtnPromijeniStanje" OnClick="PromijeniStanje" CssClass="btn btn-primary" runat="server" Visible="false" Text="Preuzmi" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

