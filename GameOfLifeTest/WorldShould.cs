using FluentAssertions;
using GameOfLife;
using NUnit.Framework;


namespace GameOfLifeTest
{
	[TestFixture]
	class WorldShould
	{
		[Test]
		public void update_the_cells()
		{
			var world = new World(10, 10);

			world.PlaceLivingCellIn(5, 4);
			world.PlaceLivingCellIn(5, 5);
			world.PlaceLivingCellIn(5, 6);
			
			world.Update();

			world.Get(5, 4).Cell.GetType().Should().Be(typeof (DeadCell));
			world.Get(5, 5).Cell.GetType().Should().Be(typeof (LiveCell));
			world.Get(5, 6).Cell.GetType().Should().Be(typeof (DeadCell));
		}
	}
}
