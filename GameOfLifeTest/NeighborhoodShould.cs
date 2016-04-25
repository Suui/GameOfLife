using System.Linq;
using FluentAssertions;
using GameOfLife;
using NUnit.Framework;

/* TODO
	- Return a list with the immediate 8 neighbor coordinates
*/

namespace GameOfLifeTest
{
	[TestFixture]
	class NeighborhoodShould
	{
		[Test]
		public void include_the_left_neighbor()
		{
			var neighbors = new Neighborhood().For(new Coordinate(5, 5));

			neighbors.Count(coordinate => coordinate.X == 5 && coordinate.Y == 4).Should().Be(1);
		}

		[Test]
		public void include_the_right_neighbor()
		{
			var neighbors = new Neighborhood().For(new Coordinate(5, 5));

			neighbors.Count(coordinate => coordinate.X == 5 && coordinate.Y == 6).Should().Be(1);
		}

		[TestCase(4, 4)]
		[TestCase(4, 5)]
		[TestCase(4, 6)]
		public void include_the_three_upper_neighbors(int x, int y)
		{
			var neighbbors = new Neighborhood().For(new Coordinate(5, 5));

			neighbbors.Count(coordinate => coordinate.X == x && coordinate.Y == y).Should().Be(1);
		}
	}
}
