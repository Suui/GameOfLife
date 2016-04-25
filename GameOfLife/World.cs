using System.Collections.Generic;


namespace GameOfLife
{
	public class World
	{
		private List<Coordinate> Coordinates { get; }

		public World(int rows, int columns)
		{
			Coordinates = new List<Coordinate>();
			for (var x = 0; x < rows; x++)
			{
				for (var y = 0; y < columns; y++)
					Coordinates.Add(new Coordinate(x, y) { Cell = new DeadCell() });
			}
		}

		public void UpdateWorld()
		{
			Coordinates.ForEach(coordinate =>
			{
				var neighbors = NeighborhoodFor(coordinate);
				coordinate.CalculateNextState(neighbors);
			});

			Coordinates.ForEach(coordinate => coordinate.Cell = coordinate.Cell.NextState);
		}

		public List<Coordinate> NeighborhoodFor(Coordinate coordinate)
		{
			return Neighborhood.For(coordinate).In(this);
		}

		public Coordinate Get(int x, int y)
		{
			return Coordinates[Coordinates.IndexOf(new Coordinate(x, y))];
		}
	}
}