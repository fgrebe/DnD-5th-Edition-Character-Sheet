using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using DnD.CharacterSheet.Services;

namespace DnD.CharacterSheet
{
	public class Global : HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			RegisterWebServiceRoutes(RouteTable.Routes);
			RegisterPageRoutes(RouteTable.Routes);
			RegisterDialogRoutes(RouteTable.Routes);
		}

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{

		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}

		private static void RegisterPageRoutes(RouteCollection routes)
		{
			routes.MapPageRoute("NewCharacter", "char/new", "~/Pages/NewCharacter.aspx");
			routes.MapPageRoute("CharacterSheet", "char/{characterId}", "~/Pages/CharacterSheet.aspx");
		}

		private static void RegisterDialogRoutes(RouteCollection routes)
		{
			routes.MapPageRoute("ArmorDialog", "items/armor", "~/Dialogs/ArmorDialog.aspx");
		}

		private static void RegisterWebServiceRoutes(RouteCollection routes)
		{
			ServiceHostFactory serviceHostFactory = new ServiceHostFactory();
			routes.Add(new ServiceRoute("svc/char", serviceHostFactory, typeof(CharacterService)));
		}
	}
}