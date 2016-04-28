using System.Collections.Generic;
using GameOfLife;
using Nancy;
using Nancy.Extensions;
using Newtonsoft.Json;


namespace WebDisplay.Routes
{
	public class GameModule : NancyModule
	{
		public GameModule() : base("/game")
		{
			Get["/"] = _ => View["game"];

			Post["/world"] = _ =>
			{
				var jsonWorld = JsonConvert.DeserializeObject<Dictionary<string, int>>(Request.Body.AsString());
				var world = new World(jsonWorld["rows"], jsonWorld["columns"]);
				return Response.AsJson(world);
			};
		}
	}
}