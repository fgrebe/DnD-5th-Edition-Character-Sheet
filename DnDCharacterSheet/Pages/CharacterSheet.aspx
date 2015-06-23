<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="CharacterSheet.aspx.cs" Inherits="DnD.CharacterSheet.Pages.CharacterSheet" %>
<asp:Content ID="headsContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="mainContent" ContentPlaceHolderID="mainContent" runat="server">
  <script src="<%=ResolveClientUrl("~/Scripts/controllers/characterCtrl.js")%>" type="text/javascript"></script>

  <div ng-controller="CharacterCtrl" ng-init="LoadCharacter(<%= CharacterId %>)">
    <h1>{{character.Name}}</h1>
    <p>Class: {{character.Class.Name}}</p>
    <p>Level: {{character.Level}}   <input type="button" ng-click="OnLevelUp(<%= CharacterId %>, character.Level + 1)" value="Level up"/></p>
    <p>Proficiency Bonus: {{character.ProficiencyBouns}}</p>
    <p>Player Name: {{character.PlayerName}}</p>
    <p>Hitpoints: {{character.Hitpoints}}</p>
    <p>Temporary Hitpoints: {{character.TempHitpoints}}</p>
    <p>Inventory: {{character.Inventory}}</p>
    <p>Note: {{character.Note}}</p>
    <p>AC: {{character.AC}}</p>
    <p>Maximum Hit Dice: {{character.MaxHitDice}}</p>
    <p>Speed: {{character.Speed}}</p>
    <p>Initiative: {{character.Initiative}}</p>
    <h2>Abilities:</h2>
    <table>
      <tr>
        <td>Strength: </td>
        <td><input type="text" value="{{character.Abilities.Strength.Score}}" ng-model="character.Abilities.Strength.Score" ng-blur="OnAbilityChanged()"/></td>
        <td ng-bind="(character.Abilities.Strength.Modifier<=0?'':'+') + character.Abilities.Strength.Modifier"></td>
      </tr>
       <tr>
        <td>Dexterity: </td>
        <td><input type="text" value="{{character.Abilities.Dexterity.Score}}" ng-model="character.Abilities.Dexterity.Score" ng-blur="OnAbilityChanged()"/></td>
        <td ng-bind="(character.Abilities.Dexterity.Modifier<=0?'':'+') + character.Abilities.Dexterity.Modifier"></td>
      </tr>
        <tr>
        <td>Constitution: </td>
        <td><input type="text" value="{{character.Abilities.Constitution.Score}}" ng-model="character.Abilities.Constitution.Score" ng-blur="OnAbilityChanged()"/></td>
        <td ng-bind="(character.Abilities.Constitution.Modifier<=0?'':'+') + character.Abilities.Constitution.Modifier"></td>
      </tr>
        <tr>
        <td>Intelligence: </td>
        <td><input type="text" value="{{character.Abilities.Intelligence.Score}}" ng-model="character.Abilities.Intelligence.Score" ng-blur="OnAbilityChanged()"/></td>
        <td ng-bind="(character.Abilities.Intelligence.Modifier<=0?'':'+') + character.Abilities.Intelligence.Modifier"></td>
      </tr>
        <tr>
        <td>Wisdom: </td>
        <td><input type="text" value="{{character.Abilities.Wisdom.Score}}" ng-model="character.Abilities.Wisdom.Score" ng-blur="OnAbilityChanged()"/></td>
        <td ng-bind="(character.Abilities.Wisdom.Modifier<=0?'':'+') + character.Abilities.Wisdom.Modifier"></td>
      </tr>
        <tr>
        <td>Charisma: </td>
        <td><input type="text" value="{{character.Abilities.Charisma.Score}}" ng-model="character.Abilities.Charisma.Score" ng-blur="OnAbilityChanged()"/></td>
        <td ng-bind="(character.Abilities.Charisma.Modifier<=0?'':'+') + character.Abilities.Charisma.Modifier"></td>
      </tr>
    </table>
    <h2>Skills:</h2>
    <table>
      <tr ng-repeat="s in character.Skills">
        <td ng-bind="s.Name"></td>
        <td ng-bind="'(' + s.Related.Name + ')'"></td>
        <td ng-bind="s.Proficient"></td>
        <td ng-bind="CalculateSkillModifier(s)"></td>
      </tr>
    </table>
  </div>
  
</asp:Content>
