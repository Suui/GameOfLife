namespace GameOfLife
{
	public class Cell
	{
		public Cell NextState { get; set; }

		public virtual bool IsAlive()
		{
			return true;
		}
	}

	public class DeadCell : Cell
	{
	}

	public class LiveCell : Cell
	{
	}
}