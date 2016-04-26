using Nancy;


namespace WebDisplay
{
	public class GameModule : NancyModule
	{
		public GameModule() : base("/game")
		{
			Get["/"] = _ => View["game"];
		}
	}
}