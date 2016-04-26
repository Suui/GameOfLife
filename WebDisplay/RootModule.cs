using Nancy;


namespace WebDisplay
{
	public class RootModule : NancyModule
	{
		public RootModule()
		{
			Get["/"] = _ => Response.AsRedirect("/game");
		}
	}
}