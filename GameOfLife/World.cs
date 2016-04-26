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
			var coordinate = Delimited(new Coordinate(x, y));
			return Coordinates[Coordinates.IndexOf(coordinate)];
		}

		private Coordinate Delimited(Coordinate coordinate)
		{
			if (coordinate.X >= Rows) coordinate.X = 0;
			if (coordinate.X < 0) coordinate.X = Rows - 1;
			if (coordinate.Y >= Columns) coordinate.Y = 0;
			if (coordinate.Y < 0) coordinate.Y = Columns - 1;
			return coordinate;
		}
	}
}