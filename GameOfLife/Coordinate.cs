using System.Collections.Generic;
using System.Linq;


namespace GameOfLife
{
	public class Coordinate
	{
		public int X { get; set; }
		public int Y { get; set; }
		public Cell Cell { get; set; }

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

		protected bool Equals(Coordinate other)
		{
			return X == other.X && Y == other.Y;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Coordinate)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (X * 397) ^ Y;
			}
		}
	}
}