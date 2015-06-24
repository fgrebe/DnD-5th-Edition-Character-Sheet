<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="NewCharacter.aspx.cs" Inherits="DnD.CharacterSheet.Pages.NewCharacter" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
	<link rel="Stylesheet" href="<%=ResolveClientUrl("~/Style/character_sheet.css") %>" type="text/css" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" runat="server">
	<script src="<%=ResolveClientUrl("~/Scripts/controllers/characterCtrl.js")%>" type="text/javascript"></script>

	<div ng-controller="CharacterCtrl" ng-init="InitNewCharacter()">
		<h1>New Character</h1>

		<table class="infoTable">
			<tr>
				<th>Name</th>
				<td>
					<input type="text" ng-model="character.Name" /></td>
			</tr>
			<tr>
				<th>Player Name</th>
				<td>
					<input type="text" ng-model="character.PlayerName" /></td>
			</tr>
			<tr>
				<th>Race</th>
				<td>
					<select ng-model="character.Race">
						<option>Human</option>
						<option>Elf</option>
						<option>Dwarf</option>
						<option>Halfling</option>
						<option>Half-Elf</option>
						<option>Half-Orc</option>
						<option>Mouseling</option>
					</select>
				</td>
			</tr>
			<tr>
				<th>Class</th>
				<td>
					<select ng-model="character.ClassId">
						<option ng-repeat="c in classes" value="{{c.ClassId}}">{{c.Name}}</option>
					</select>
				</td>
			</tr>
			<tr>
				<th>Alignment</th>
				<td>
					<select ng-model="character.Alignment">
						<option>Lawful Good</option>
						<option>Lawful Neutral</option>
						<option>Lawful Evil</option>
						<option>True Neutral</option>
						<option>Chaotic Good</option>
						<option>Chaotic Neutral</option>
						<option>Chaotic Evil</option>
					</select>
				</td>
			</tr>
			<tr>
				<th>Background</th>
				<td>
					<input type="text" ng-model="character.Background" />
				</td>
			</tr>
		</table>

		<div class="clear"></div>

		<div class="f-left">
			<h2>Abilities:</h2>
			<table>
				<tr>
					<th>Name</th>
					<th>Score</th>
				</tr>
				<tr>
					<td>Strength: </td>
					<td><input class="ability" type="text" ng-model="character.Abilities.Strength.Score" /></td>
				</tr>
				<tr>
					<td>Dexterity: </td>
					<td><input class="ability" type="text" ng-model="character.Abilities.Dexterity.Score" /></td>
				</tr>
				<tr>
					<td>Constitution: </td>
					<td><input class="ability" type="text" ng-model="character.Abilities.Constitution.Score" /></td>
				</tr>
				<tr>
					<td>Intelligence: </td>
					<td><input class="ability" type="text" ng-model="character.Abilities.Intelligence.Score" /></td>
				</tr>
				<tr>
					<td>Wisdom: </td>
					<td><input class="ability" type="text" ng-model="character.Abilities.Wisdom.Score" /></td>
				</tr>
				<tr>
					<td>Charisma: </td>
					<td><input class="ability" type="text" ng-model="character.Abilities.Charisma.Score" /></td>
				</tr>
			</table>
		</div>
		<div class="clear"></div>
		<input value="Submit" type="button" ng-click="AddCharacter(character.Name, character.PlayerName, character.Race, character.ClassId, character.Alignment, character.Background, character.Abilities.Strength.Score, character.Abilities.Dexterity.Score, character.Abilities.Constitution.Score, character.Abilities.Intelligence.Score, character.Abilities.Wisdom.Score, character.Abilities.Charisma.Score)"/>
		<input value="Go to Character Sheet" type="button" ng-click="GoToCharacter()" ng-if="character.CharacterId"/>
	</div>
</asp:Content>
