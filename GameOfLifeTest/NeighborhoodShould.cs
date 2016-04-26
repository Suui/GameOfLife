using System.Linq;
using FluentAssertions;
using GameOfLife;
using NUnit.Framework;


namespace GameOfLifeTest
{
	[TestFixture]
	class NeighborhoodShould
	{
		[TestCase(4, 4)]
		[TestCase(4, 5)]
		[TestCase(4, 6)]
		[TestCase(5, 4)]
		[TestCase(5, 6)]
		[TestCase(6, 4)]
		[TestCase(6, 5)]
		[TestCase(6, 6)]
		public void include_the_eight_neighbors(int x, int y)
		{
			var world = new World(10, 10);

			var neighbbors = world.NeighborhoodFor(new Coordinate(5, 5));

			neighbbors.Count(coordinate => coordinate.Equals(new Coordinate(x, y))).Should().Be(1);
		}

		[Test]
		public void redirect_to_the_corresponding_coordinate_if_it_is_out_of_bound()
		{
			var world = new World(6, 6);

			var neighbors = world.NeighborhoodFor(new Coordinate(5, 5));

			neighbors.Count(coordinate => coordinate.X == 5 && coordinate.Y == 0).Should().Be(1);
		}
	}
}
