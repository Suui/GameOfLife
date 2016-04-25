using System.Collections.Generic;


namespace GameOfLife
{
	public class Neighborhood
	{
		public virtual List<Coordinate> For(Coordinate coordinate)
		{
			return new List<Coordinate>
			{
				new Coordinate(5, coordinate.Y - 1),
				new Coordinate(5, coordinate.Y + 1)
			};
		}
	}
}