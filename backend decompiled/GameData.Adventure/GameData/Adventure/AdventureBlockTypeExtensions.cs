namespace GameData.Adventure;

public static class AdventureBlockTypeExtensions
{
	public static bool Contains(this EAdventureBlockType type, EAdventureBlockType check)
	{
		return check switch
		{
			EAdventureBlockType.None => true, 
			EAdventureBlockType.In => (type == EAdventureBlockType.In || type == EAdventureBlockType.InOut) ? true : false, 
			EAdventureBlockType.Out => (uint)(type - 2) <= 1u, 
			EAdventureBlockType.InOut => type == EAdventureBlockType.InOut, 
			_ => false, 
		};
	}

	public static bool ContainsAny(this EAdventureBlockType type, EAdventureBlockType check)
	{
		bool flag = type.Contains(check);
		if (!flag)
		{
			bool flag2 = (uint)(type - 1) <= 1u;
			flag = flag2 && check == EAdventureBlockType.InOut;
		}
		return flag;
	}

	public static EAdventureBlockType Add(this EAdventureBlockType type, EAdventureBlockType addType)
	{
		if (type.Contains(addType))
		{
			return type;
		}
		return addType switch
		{
			EAdventureBlockType.None => type, 
			EAdventureBlockType.In => (type == EAdventureBlockType.None) ? EAdventureBlockType.In : EAdventureBlockType.InOut, 
			EAdventureBlockType.Out => (type == EAdventureBlockType.None) ? EAdventureBlockType.Out : EAdventureBlockType.InOut, 
			EAdventureBlockType.InOut => EAdventureBlockType.InOut, 
			_ => type, 
		};
	}

	public static EAdventureBlockType Remove(this EAdventureBlockType type, EAdventureBlockType removeType)
	{
		if (!type.Contains(removeType))
		{
			return type;
		}
		return removeType switch
		{
			EAdventureBlockType.None => type, 
			EAdventureBlockType.In => (type != EAdventureBlockType.In) ? EAdventureBlockType.Out : EAdventureBlockType.None, 
			EAdventureBlockType.Out => (type != EAdventureBlockType.Out) ? EAdventureBlockType.In : EAdventureBlockType.None, 
			EAdventureBlockType.InOut => EAdventureBlockType.None, 
			_ => type, 
		};
	}
}
