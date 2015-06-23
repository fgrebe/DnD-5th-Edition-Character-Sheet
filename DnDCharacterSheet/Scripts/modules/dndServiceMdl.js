angular.module('dndCharacterSheet.svcModule', [])
	.factory('DnDSvc', [function() {

	return {
		charSvc: charactersvc.icharacterservice
	};
}])