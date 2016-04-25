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
		[Test]
		public void come_to_life_when_it_has_extacly_three_live_neighbors()
		{
			var neighborhood = Substitute.For<Neighborhood>();
			var coordinate = new Coordinate
			{
				Cell = new DeadCell(),
				Neighborhood = neighborhood
			};
			neighborhood.For(coordinate).Returns(new List<Coordinate>
			{
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() },
				new Coordinate { Cell = new LiveCell() }
			});

			coordinate.CalculateNextState();

			coordinate.Cell.NextState.GetType().Should().Be(typeof (LiveCell));
		}
	}
}
