<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DnD.CharacterSheet.Default" %>
<asp:Content ID="contentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="contentMain" ContentPlaceHolderID="mainContent" runat="server">
  <script  src="<%=ResolveClientUrl("~/Scripts/controllers/charSelectionCtrl.js")%>" type="text/javascript"></script>

	<h1>Dungeons & Dragons Character Sheet</h1>
	<h2>Select Character</h2>

  <div ng-controller="CharSelectionCtrl">
    <table ng-init="LoadCharacters()">
      <tr ng-repeat="c in characters">
        <td>{{c.Name}}</td>
        <td>{{c.Class.Name}}</td>
        <td><a ng-href="/char/{{c.CharacterId}}">Open Character Sheet</a></td>
      </tr>
    </table>
  </div>

</asp:Content>
