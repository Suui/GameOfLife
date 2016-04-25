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
			var neighbbors = new Neighborhood().For(new Coordinate(5, 5));

			neighbbors.Count(coordinate => coordinate.X == x && coordinate.Y == y).Should().Be(1);
		}
	}
}
