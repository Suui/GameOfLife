using System.Collections.Generic;
using FluentAssertions;
using GameOfLife;
using NUnit.Framework;


namespace GameOfLifeTest
{
	[TestFixture]
	class CellShould
	{
		[Test]
		public void come_to_life_when_it_has_exactly_three_live_neighbors()
		{
			var coordinate = new Coordinate { Cell = new DeadCell() };
			var neighbors = new List<Coordinate>
			{
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() }
			};

			coordinate.CalculateNextState(neighbors);

			coordinate.Cell.NextState.GetType().Should().Be(typeof (LiveCell));
		}

		[Test]
		public void die_if_it_has_less_than_two_neighbors_alive()
		{
			var coordinate = new Coordinate { Cell = new LiveCell() };
			var neighbors = new List<Coordinate>
			{
				new Coordinate { Cell = new LiveCell() }
			};

			coordinate.CalculateNextState(neighbors);

			coordinate.Cell.NextState.GetType().Should().Be(typeof (DeadCell));
		}

		[Test]
		public void die_if_it_has_more_than_three_neighbors_alive()
		{
			var coordinate = new Coordinate { Cell = new LiveCell() };
			var neighbors = new List<Coordinate>
			{
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() }
			};

			coordinate.CalculateNextState(neighbors);

			coordinate.Cell.NextState.GetType().Should().Be(typeof (DeadCell));
		}

		[Test]
		public void stay_alive_if_it_has_two_neighbors_alive()
		{
			var coordinate = new Coordinate { Cell = new LiveCell() };
			var neighbors = new List<Coordinate>
			{
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() }
			};

			coordinate.CalculateNextState(neighbors);

			coordinate.Cell.NextState.GetType().Should().Be(typeof(LiveCell));
		}

		[Test]
		public void stay_alive_if_it_has_three_neighbors_alive()
		{
			var coordinate = new Coordinate { Cell = new LiveCell() };
			var neighbors = new List<Coordinate>
			{
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() }
			};

			coordinate.CalculateNextState(neighbors);

			coordinate.Cell.NextState.GetType().Should().Be(typeof(LiveCell));
		}
	}
}
