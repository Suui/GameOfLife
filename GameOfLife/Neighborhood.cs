using System.Collections.Generic;


namespace GameOfLife
{
	public class Neighborhood
	{
		public virtual List<Coordinate> For(Coordinate coordinate)
		{
			return new List<Coordinate>
			{
				new Coordinate(coordinate.X,		coordinate.Y - 1),
				new Coordinate(coordinate.X,		coordinate.Y + 1),
				new Coordinate(coordinate.X - 1,	coordinate.Y - 1),
				new Coordinate(coordinate.X - 1,	coordinate.Y),
				new Coordinate(coordinate.X - 1,	coordinate.Y + 1)
			};
		}
	}
}