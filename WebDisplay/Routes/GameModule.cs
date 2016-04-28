using GameOfLife;
using Nancy;
using Nancy.ModelBinding;


namespace WebDisplay.Routes
{
	public class GameModule : NancyModule
	{
		public GameModule() : base("/game")
		{
			Get["/"] = _ => View["game"];

			Post["/world"] = _ =>
			{
				var world2 = this.Bind<World>();
				var world = new World(20, 20);
				return Response.AsJson(world);
			};
		}
	}
}