namespace GameOfLife
{
	public abstract class Cell
	{
		public Cell NextState { get; set; }

		public abstract bool IsAlive();
	}

	public class DeadCell : Cell
	{
		public override bool IsAlive() => false;
	}

	public class LiveCell : Cell
	{
		public override bool IsAlive() => true;
	}
}