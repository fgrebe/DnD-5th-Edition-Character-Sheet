angular.module("dndCharacterSheet.controllers")
	.controller("CharacterCtrl", function ($scope, $q, DnDSvc) {

		$scope.LoadCharacterSheet = function (characterId) {
			var promise = $q(function(resolve, reject) {
				DnDSvc.charSvc.GetArmors($scope.LoadArmorsSuccess, $scope.error);
			});

			promise.then(DnDSvc.charSvc.GetCharacter(characterId, $scope.LoadCharacterSuccess, $scope.error));
	  }

	  $scope.LoadCharacterSuccess = function (response) {
	  	$scope.character = response.Value;
	    $scope.$apply();
	  }

		$scope.LoadArmorsSuccess = function(response) {
			$scope.armors = response.Value;
			$scope.$apply();
		}

	  $scope.error = function (response) {
	    alert("error!");
	  }

	  $scope.OnAbilityChanged = function () { 
	    DnDSvc.charSvc.UpdateAbilities($scope.character.CharacterId, $scope.character.Abilities, $scope.UpdateAbilitiesSuccess, $scope.error);
	  }

	  $scope.UpdateAbilitiesSuccess = function (response) {
	    $scope.character.Abilities = response.Value.Abilities;
	    $scope.character.Skills = response.Value.Skills;
	    $scope.$apply();
	  }

	  $scope.CalculateSkillModifier = function (skill) {
	    return skill.Related.Modifier + (skill.Proficient ? $scope.character.ProficiencyBonus : 0);
	  }

	  $scope.OnLevelUp = function (characterId, level) {
	    DnDSvc.charSvc.LevelUp(characterId, level, $scope.LevelUpSuccess, $scope.error);
	  }

	  $scope.LevelUpSuccess = function (response) {
	    $scope.character.Level = response.Value.Level;
	    $scope.character.MaxHitDice = response.Value.MaxHitDice;
	    $scope.character.ProficiencyBonus = response.Value.ProficiencyBonus;
	    $scope.character.Hitpoints = response.Value.Hitpoints;
	    $scope.$apply();
	  }

		$scope.OnArmorChanged = function() {
			DnDSvc.charSvc.SetArmor($scope.character.CharacterId, $scope.character.ArmorId, $scope.SetArmorSuccess, $scope.error);
		}

		$scope.SetArmorSuccess = function(response) {
			$scope.character.Armor = response.Value.Armor;
			$scope.character.Armor.ArmorId = response.Value.Armor.ArmorId;
			$scope.character.AC = response.Value.AC;
			$scope.$apply;
		}
	});
