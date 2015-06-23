<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DnD.CharacterSheet.Default" %>
<asp:Content ID="contentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="contentMain" ContentPlaceHolderID="mainContent" runat="server">
	<%--<asp:ListView ID="lstCharacters" runat="server">
		<LayoutTemplate>
			<table>
				<tbody>
					<tr runat="server" id="itemPlaceholder" />
				</tbody>
			</table>
		</LayoutTemplate>
		<ItemTemplate>
			<tr runat="server">
				<td runat="server">
					<asp:Label runat="server" Text='<%#Eval("Name") %>' />
				</td>
        <td runat="server">
          <asp:Label runat="server" Text='<%#Eval("Class.Name") %>' />
        </td>
        <td runat="server">
          <asp:Label runat="server" Text='<%#Eval("Level") %>' />
        </td>
			</tr>
		</ItemTemplate>
	</asp:ListView>--%>
<%--	<div ng-controller="CharacterCtrl">
		<div ng-init="LoadCharacters()"></div>
	</div>--%>
  <script  src="<%=ResolveClientUrl("~/Scripts/controllers/charSelectionCtrl.js")%>" type="text/javascript"></script>

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
