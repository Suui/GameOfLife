using System.Collections.Generic;


namespace GameOfLife
{
	public class Neighborhood
	{
		private Coordinate Coordinate { get; set; }

		private Neighborhood(Coordinate coordinate)
		{
			Coordinate = coordinate;
		}

		public static Neighborhood For(Coordinate coordinate)
		{
			return new Neighborhood(coordinate);
		}

		public List<Coordinate> In(World world)
		{
			return new List<Coordinate>
			{
				world.Get(Coordinate.X - 1,    Coordinate.Y - 1),
				world.Get(Coordinate.X - 1,    Coordinate.Y),
				world.Get(Coordinate.X - 1,    Coordinate.Y + 1),

				world.Get(Coordinate.X,        Coordinate.Y - 1),
				world.Get(Coordinate.X,        Coordinate.Y + 1),

				world.Get(Coordinate.X + 1,    Coordinate.Y - 1),
				world.Get(Coordinate.X + 1,    Coordinate.Y),
				world.Get(Coordinate.X + 1,    Coordinate.Y + 1)
			};
		}
	}
}