<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="CharacterSheet.aspx.cs" Inherits="DnD.CharacterSheet.Pages.CharacterSheet" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
	<link rel="Stylesheet" href="<%=ResolveClientUrl("~/Style/character_sheet.css") %>" type="text/css" />
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" runat="server">
	<script src="<%=ResolveClientUrl("~/Scripts/controllers/characterCtrl.js")%>" type="text/javascript"></script>

	<div ng-controller="CharacterCtrl" ng-init="LoadCharacterSheet(<%= CharacterId %>)">
		<h1>{{character.Name}}</h1>

		<table class="infoTable">
			<tr>
				<th class="W100">Player Name</th>
				<td class="W100">{{character.PlayerName}}</td>
			</tr>
			<tr>
				<th>Class</th>
				<td>{{character.Class.Name}}</td>
			</tr>
			<tr>
				<th>Level</th>
				<td>{{character.Level}} <a href="#" ng-click="OnLevelUp(<%= CharacterId %>, character.Level + 1)">
					<img src="<%= ResolveClientUrl("~/Images/plus.png") %>" /></a>
			</tr>
			<tr>
				<th>Race</th>
				<td>{{character.Race}}</td>
			</tr>
			<tr>
				<th>Background</th>
				<td>{{character.Background}}</td>
			</tr>
			<tr>
				<th>Alignment</th>
				<td>{{character.Alignment}}</td>
			</tr>
			<tr>
				<th>Exp. Points</th>
				<td>{{character.ExperiencePoints}}</td>
			</tr>
		</table>
		<table class="infoTable">
			<tr>
				<th class="W100">Armor Class</th>
				<td class="W100">{{character.AC}}</td>
			</tr>
			<tr>
				<th>Initiative</th>
				<td>{{character.Initiative}}</td>
			</tr>
			<tr>
				<th>Speed</th>
				<td>{{character.Speed}}</td>
			</tr>
			<tr>
				<th>Hitpoints</th>
				<td>{{character.Hitpoints}}</td>
			</tr>
			<tr>
				<th>Temp. Hitpoints</th>
				<td>{{character.TempHitpoints}}</td>
			</tr>
			<tr>
				<th>Hit Dice</th>
				<td>{{character.MaxHitDice}}</td>
			</tr>
		</table>
		<div class="clear"></div>

		<div class="f-left">
			<h2>Abilities:</h2>
			<table>
				<tr>
					<th>Name</th>
					<th>Score</th>
					<th>Mod</th>
				</tr>
				<tr>
					<td>Strength: </td>
					<td>
						<input class="ability" type="text" value="{{character.Abilities.Strength.Score}}" ng-model="character.Abilities.Strength.Score" ng-blur="OnAbilityChanged()" /></td>
					<td class="W25 modifier" ng-bind="(character.Abilities.Strength.Modifier<=0?'':'+') + character.Abilities.Strength.Modifier"></td>
				</tr>
				<tr>
					<td>Dexterity: </td>
					<td>
						<input class="ability" type="text" value="{{character.Abilities.Dexterity.Score}}" ng-model="character.Abilities.Dexterity.Score" ng-blur="OnAbilityChanged()" /></td>
					<td class="W25 modifier" ng-bind="(character.Abilities.Dexterity.Modifier<=0?'':'+') + character.Abilities.Dexterity.Modifier"></td>
				</tr>
				<tr>
					<td>Constitution: </td>
					<td>
						<input class="ability" type="text" value="{{character.Abilities.Constitution.Score}}" ng-model="character.Abilities.Constitution.Score" ng-blur="OnAbilityChanged()" /></td>
					<td class="W25 modifier" ng-bind="(character.Abilities.Constitution.Modifier<=0?'':'+') + character.Abilities.Constitution.Modifier"></td>
				</tr>
				<tr>
					<td>Intelligence: </td>
					<td>
						<input class="ability" type="text" value="{{character.Abilities.Intelligence.Score}}" ng-model="character.Abilities.Intelligence.Score" ng-blur="OnAbilityChanged()" /></td>
					<td class="W25 modifier" ng-bind="(character.Abilities.Intelligence.Modifier<=0?'':'+') + character.Abilities.Intelligence.Modifier"></td>
				</tr>
				<tr>
					<td>Wisdom: </td>
					<td>
						<input class="ability" type="text" value="{{character.Abilities.Wisdom.Score}}" ng-model="character.Abilities.Wisdom.Score" ng-blur="OnAbilityChanged()" /></td>
					<td class="W25 modifier" ng-bind="(character.Abilities.Wisdom.Modifier<=0?'':'+') + character.Abilities.Wisdom.Modifier"></td>
				</tr>
				<tr>
					<td>Charisma: </td>
					<td>
						<input class="ability" type="text" value="{{character.Abilities.Charisma.Score}}" ng-model="character.Abilities.Charisma.Score" ng-blur="OnAbilityChanged()" /></td>
					<td class="W25 modifier" ng-bind="(character.Abilities.Charisma.Modifier<=0?'':'+') + character.Abilities.Charisma.Modifier"></td>
				</tr>
			</table>
		</div>

		<div class="f-left">
			<h2>Skills</h2>
			<table>
				<tr>
					<th></th>
					<th>Name</th>
					<th>Ability</th>
					<th>Mod</th>
				</tr>
				<tr ng-repeat="s in character.Skills">
					<td>
						<img ng-if="s.Proficient" src="<%= ResolveClientUrl("~/Images/proficient.png") %>" /><img ng-if="!s.Proficient" src="<%= ResolveClientUrl("~/Images/not_proficient.png") %>" /></td>
					<td ng-bind="s.Name"></td>
					<td ng-bind="'(' + s.Related.Name + ')'"></td>
					<td class="modifier" ng-bind="CalculateSkillModifier(s)"></td>
				</tr>
			</table>
		</div>
		<div class="clear"></div>
		<div>
			<h2>Equipment</h2>
			<table>
				<tr>
					<th>Armor</th>
					<td>
						<select ng-model="character.ArmorId" ng-change="OnArmorChanged()">
							<option ng-repeat="a in armors" value="{{a.ArmorId}}">{{a.Name}}</option>
						</select>
					</td>
				</tr>
			</table>
		</div>
	</div>

</asp:Content>
