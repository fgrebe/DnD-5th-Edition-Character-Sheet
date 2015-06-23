using System.ServiceModel.Activation;
using System.Web;

namespace DnD.CharacterSheet.Services
{
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public abstract class ServiceBase
	{
		protected ServiceBase()
		{
			{
				HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
				HttpContext.Current.Response.Cache.SetNoStore();
			}
		}

		public static SvcResponse<T> CreateReponse<T>(T value = null, ResponseStatus status = ResponseStatus.Success) where T : class
		{
			return new SvcResponse<T> { Value = value, Status = status };
		}
	}
}