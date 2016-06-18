<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MapaOtpada.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="welcome" runat="server">
    <form runat="server">
    <li>
        <a href="Prijava.aspx" id="prijava" runat="server"><b>Prijava</b></a>
    </li>
    <li>
        <%--<a href="#" id="odjava" onclick="OdjavaClick" runat="server">Odjava</a>--%>
        <asp:Button ID="odjava" runat="server" OnClick="OdjavaClick" Text="Odjava" />
        
    </li>
    </form>
    <asp:Label ID="korisnik" runat="server" Text="Korisnik"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="map-canvas">
    </div>
</asp:Content>

