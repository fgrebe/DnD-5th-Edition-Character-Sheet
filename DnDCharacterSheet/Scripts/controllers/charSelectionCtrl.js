angular.module('dndCharacterSheet.controllers', [])
	.controller('CharSelectionCtrl', function ($scope, DnDSvc) {
	  //$scope.characters = [{ Name: "Mus" }, { Name: "Wumm" }]

	  $scope.LoadCharacters = function () {
	    DnDSvc.charSvc.GetCharacters($scope.LoadCharactersSuccess, $scope.error);
	  }

	  $scope.LoadCharactersSuccess = function (response) {
	    $scope.characters = response.Value;
	    $scope.$apply();
	  }

	  $scope.error = function (response) {
	    alert("error!");
	  }
	});