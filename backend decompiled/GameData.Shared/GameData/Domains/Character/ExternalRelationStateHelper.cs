namespace GameData.Domains.Character;

public static class ExternalRelationStateHelper
{
	public static bool IsActive(ulong state, ulong type)
	{
		return (state & type) != 0;
	}

	public static byte Activate(ulong state, ulong type)
	{
		return (byte)(state | type);
	}

	public static byte Deactivate(ulong state, ulong type)
	{
		return (byte)(state & ~type);
	}
}
