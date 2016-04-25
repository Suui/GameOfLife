using System.Collections.Generic;
using FluentAssertions;
using GameOfLife;
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
		private Neighborhood Neighborhood { get; set; }

		[SetUp]
		public void GivenAFakeNeighborhood()
		{
			Neighborhood = Substitute.For<Neighborhood>();
		}

		[Test]
		public void come_to_life_when_it_has_extacly_three_live_neighbors()
		{
			var coordinate = NewCoordinateWithADeadCell();
			Neighborhood.For(coordinate).Returns(new List<Coordinate>
			{
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() }
			});

			coordinate.CalculateNextState();

			coordinate.Cell.NextState.GetType().Should().Be(typeof (LiveCell));
		}

		[Test]
		public void die_if_it_has_less_than_two_neighbors_alive()
		{
			var coordinate = NewCoordinateWithALiveCell();
			Neighborhood.For(coordinate).Returns(new List<Coordinate>
			{
				new Coordinate { Cell = new LiveCell() }
			});

			coordinate.CalculateNextState();

			coordinate.Cell.NextState.GetType().Should().Be(typeof (DeadCell));
		}

		[Test]
		public void die_if_it_has_more_than_three_neighbors_alive()
		{
			var coordinate = NewCoordinateWithALiveCell();
			Neighborhood.For(coordinate).Returns(new List<Coordinate>
			{
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() }
			});

			coordinate.CalculateNextState();

			coordinate.Cell.NextState.GetType().Should().Be(typeof (DeadCell));
		}

		[Test]
		public void stay_alive_if_it_has_two_neighbors_alive()
		{
			var coordinate = NewCoordinateWithALiveCell();
			Neighborhood.For(coordinate).Returns(new List<Coordinate>
			{
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() }
			});

			coordinate.CalculateNextState();

			coordinate.Cell.NextState.GetType().Should().Be(typeof(LiveCell));
		}

		[Test]
		public void stay_alive_if_it_has_three_neighbors_alive()
		{
			var coordinate = NewCoordinateWithALiveCell();
			Neighborhood.For(coordinate).Returns(new List<Coordinate>
			{
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() }
			});

			coordinate.CalculateNextState();

			coordinate.Cell.NextState.GetType().Should().Be(typeof(LiveCell));
		}

		private Coordinate NewCoordinateWithADeadCell()
		{
			return new Coordinate
			{
				Cell = new DeadCell(),
				Neighborhood = Neighborhood
			};
		}

		private Coordinate NewCoordinateWithALiveCell()
		{
			var coordinate = new Coordinate
			{
				Cell = new LiveCell(),
				Neighborhood = Neighborhood
			};
			return coordinate;
		}
	}
}
