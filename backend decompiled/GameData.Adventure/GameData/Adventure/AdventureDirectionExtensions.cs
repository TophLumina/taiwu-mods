namespace GameData.Adventure;

public static class AdventureDirectionExtensions
{
	public static void Move(this EAdventureDirection direction, ref int x, ref int y)
	{
		switch (direction)
		{
		case EAdventureDirection.Up:
			y++;
			break;
		case EAdventureDirection.Down:
			y--;
			break;
		case EAdventureDirection.Left:
			x--;
			break;
		case EAdventureDirection.Right:
			x++;
			break;
		}
	}

	public static EAdventureDirection Clockwise(this EAdventureDirection direction)
	{
		return direction switch
		{
			EAdventureDirection.Up => EAdventureDirection.Right, 
			EAdventureDirection.Right => EAdventureDirection.Down, 
			EAdventureDirection.Down => EAdventureDirection.Left, 
			EAdventureDirection.Left => EAdventureDirection.Up, 
			_ => direction, 
		};
	}

	public static EAdventureDirection CounterClockwise(this EAdventureDirection direction)
	{
		return direction switch
		{
			EAdventureDirection.Up => EAdventureDirection.Left, 
			EAdventureDirection.Left => EAdventureDirection.Down, 
			EAdventureDirection.Down => EAdventureDirection.Right, 
			EAdventureDirection.Right => EAdventureDirection.Up, 
			_ => direction, 
		};
	}
}
