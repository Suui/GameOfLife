using System.Collections.Generic;


namespace GameOfLife
{
	public class World
	{
		private List<Coordinate> Coordinates { get; }
		private int Rows { get; }
		private int Columns { get; }

		public World(int rows, int columns)
		{
			Coordinates = new List<Coordinate>();
			Rows = rows;
			Columns = columns;

			for (var x = 0; x < Rows; x++)
			{
				for (var y = 0; y < Columns; y++)
					Coordinates.Add(new Coordinate(x, y) { Cell = new DeadCell() });
			}
		}

		public void Update()
		{
			Coordinates.ForEach(coordinate =>
			{
				var neighbors = NeighborhoodFor(coordinate);
				coordinate.CalculateNextState(neighbors);
			});

			Coordinates.ForEach(coordinate => coordinate.Cell = coordinate.Cell.NextState);
		}

		public void PlaceLivingCellIn(int x, int y) => Get(x, y).Cell = new LiveCell();

		public List<Coordinate> NeighborhoodFor(Coordinate coordinate) => Neighborhood.For(coordinate).In(this);

		public Coordinate Get(int x, int y)
		{
			if (x >= Rows) x = 0;
			if (x < 0) x = Rows - 1;
			if (y >= Columns) y = 0;
			if (y < 0) y = Columns - 1;
			return Coordinates[Coordinates.IndexOf(new Coordinate(x, y))];
		}
	}
}