using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

/* TODO
- Any live cell with fewer than two live neighbours dies (referred to as underpopulation).
- Any live cell with more than three live neighbours dies (referred to as overpopulation or overcrowding).
- Any live cell with two or three live neighbours lives, unchanged, to the next generation.
- Any dead cell with exactly three live neighbours will come to life.
*/

namespace GameOfLifeTest
{
	[TestFixture]
	class CellShould
	{
		[Test]
		public void come_to_life_when_it_has_extacly_three_live_neighbors()
		{
			var neighborhood = Substitute.For<Neighborhood>();
			var coordinate = new Coordinate
			{
				Cell = new DeadCell(),
				Neighborhood = neighborhood
			};
			neighborhood.GetFor(Arg.Is(coordinate)).Returns(new List<Coordinate>
			{
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() }
			});

			coordinate.CalculateNextState();
			coordinate.Cell.NextState.GetType().Should().Be(typeof (LiveCell));
		}
	}

	public class DeadCell : Cell
	{
	}

	public class Neighborhood
	{
		public virtual List<Coordinate> GetFor(Coordinate coordinate)
		{
			return new List<Coordinate>();
		}
	}

	public class LiveCell : Cell
	{
	}

	public class Coordinate
	{
		public Cell Cell { get; set; }
		public Neighborhood Neighborhood { get; set; }

		public void CalculateNextState()
		{
			var aliveNeighbors = Neighborhood.GetFor(this).Count(neighbor => neighbor.Cell.IsAlive());
			if (aliveNeighbors == 3) Cell.NextState = new LiveCell();
		}
	}

	public class Cell
	{
		public Cell NextState { get; set; }

		public virtual bool IsAlive()
		{
			return true;
		}
	}
}
