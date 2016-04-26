using System;
using GameOfLife;


namespace Display
{
	class Program
	{
		static void Main(string[] args)
		{
			var world = new World(20, 20);

			world.PlaceLivingCellIn(10, 9);
			world.PlaceLivingCellIn(10, 10);
			world.PlaceLivingCellIn(10, 11);

			for (var index = 0; index < 100; index++)
			{
				Console.Clear();
				Console.WriteLine(world.ToString());
				world.Update();
				System.Threading.Thread.Sleep(1000);
			}
				
		}
	}
}
