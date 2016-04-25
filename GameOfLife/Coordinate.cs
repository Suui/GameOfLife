using System.Linq;


namespace GameOfLife
{
	public class Coordinate
	{
		public int X { get; set; }
		public int Y { get; set; }
		public Cell Cell { get; set; }
		public Neighborhood Neighborhood { get; set; }

		public Coordinate() {}

		public Coordinate(int x, int y)
		{
			X = x;
			Y = y;
		}

		public void CalculateNextState(List<Coordinate> neighbors)
		{
			var aliveNeighbors = neighbors.Count(neighbor => neighbor.Cell.IsAlive());
			if (aliveNeighbors == 3) Cell.NextState = new LiveCell();
			else
			{
				if (Cell.IsAlive() && aliveNeighbors == 2) Cell.NextState = new LiveCell();
				else Cell.NextState = new DeadCell();
			}
		}
	}
}