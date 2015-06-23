Type.registerNamespace('charactersvc');
charactersvc.icharacterservice = function () {
	charactersvc.icharacterservice.initializeBase(this);
	this._timeout = 0;
	this._userContext = null;
	this._succeeded = null;
	this._failed = null;
}
charactersvc.icharacterservice.prototype = {
	_get_path: function () {
		var p = this.get_path();
		if (p) return p;
		else return charactersvc.icharacterservice._staticInstance.get_path();
	},
	GetCharacters: function (succeededCallback, failedCallback, userContext) {
		return this._invoke(this._get_path(), 'GetCharacters', false, {}, succeededCallback, failedCallback, userContext);
	}
}
charactersvc.icharacterservice.registerClass('charactersvc.icharacterservice', Sys.Net.WebServiceProxy);
charactersvc.icharacterservice._staticInstance = new charactersvc.icharacterservice();
charactersvc.icharacterservice.set_path = function (value) { charactersvc.icharacterservice._staticInstance.set_path(value); }
charactersvc.icharacterservice.get_path = function () { return charactersvc.icharacterservice._staticInstance.get_path(); }
charactersvc.icharacterservice.set_timeout = function (value) { charactersvc.icharacterservice._staticInstance.set_timeout(value); }
charactersvc.icharacterservice.get_timeout = function () { return charactersvc.icharacterservice._staticInstance.get_timeout(); }
charactersvc.icharacterservice.set_defaultUserContext = function (value) { charactersvc.icharacterservice._staticInstance.set_defaultUserContext(value); }
charactersvc.icharacterservice.get_defaultUserContext = function () { return charactersvc.icharacterservice._staticInstance.get_defaultUserContext(); }
charactersvc.icharacterservice.set_defaultSucceededCallback = function (value) { charactersvc.icharacterservice._staticInstance.set_defaultSucceededCallback(value); }
charactersvc.icharacterservice.get_defaultSucceededCallback = function () { return charactersvc.icharacterservice._staticInstance.get_defaultSucceededCallback(); }
charactersvc.icharacterservice.set_defaultFailedCallback = function (value) { charactersvc.icharacterservice._staticInstance.set_defaultFailedCallback(value); }
charactersvc.icharacterservice.get_defaultFailedCallback = function () { return charactersvc.icharacterservice._staticInstance.get_defaultFailedCallback(); }
charactersvc.icharacterservice.set_enableJsonp = function (value) { charactersvc.icharacterservice._staticInstance.set_enableJsonp(value); }
charactersvc.icharacterservice.get_enableJsonp = function () { return charactersvc.icharacterservice._staticInstance.get_enableJsonp(); }
charactersvc.icharacterservice.set_jsonpCallbackParameter = function (value) { charactersvc.icharacterservice._staticInstance.set_jsonpCallbackParameter(value); }
charactersvc.icharacterservice.get_jsonpCallbackParameter = function () { return charactersvc.icharacterservice._staticInstance.get_jsonpCallbackParameter(); }
charactersvc.icharacterservice.set_path("http://localhost:2208/svc/char");
charactersvc.icharacterservice.GetCharacters = function (onSuccess, onFailed, userContext) { charactersvc.icharacterservice._staticInstance.GetCharacters(onSuccess, onFailed, userContext); }
var gtc = Sys.Net.WebServiceProxy._generateTypedConstructor;
Type.registerNamespace('DnD.DataAccess.Model');
if (typeof (DnD.DataAccess.Model.Character) === 'undefined') {
	DnD.DataAccess.Model.Character = gtc("Character:http://schemas.datacontract.org/2004/07/DnD.DataAccess.Model");
	DnD.DataAccess.Model.Character.registerClass('DnD.DataAccess.Model.Character');
}
if (typeof (DnD.DataAccess.Model.Class) === 'undefined') {
	DnD.DataAccess.Model.Class = gtc("Class:http://schemas.datacontract.org/2004/07/DnD.DataAccess.Model");
	DnD.DataAccess.Model.Class.registerClass('DnD.DataAccess.Model.Class');
}