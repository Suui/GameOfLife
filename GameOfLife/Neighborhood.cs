using System.Collections.Generic;


namespace GameOfLife
{
	public class Neighborhood
	{
		public virtual List<Coordinate> GetFor(Coordinate coordinate)
		{
			return new List<Coordinate>();
		}
	}
}