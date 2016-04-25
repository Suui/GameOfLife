using System.Collections.Generic;


namespace GameOfLife
{
	public class Neighborhood
	{
		public virtual List<Coordinate> For(Coordinate coordinate)
		{
			return new List<Coordinate>();
		}
	}
}