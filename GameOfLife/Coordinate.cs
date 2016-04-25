using System.Linq;


namespace GameOfLife
{
	public class Coordinate
	{
		public Cell Cell { get; set; }
		public Neighborhood Neighborhood { get; set; }

		public void CalculateNextState()
		{
			var aliveNeighbors = Neighborhood.For(this).Count(neighbor => neighbor.Cell.IsAlive());
			if (aliveNeighbors == 3) Cell.NextState = new LiveCell();
		}
	}
}