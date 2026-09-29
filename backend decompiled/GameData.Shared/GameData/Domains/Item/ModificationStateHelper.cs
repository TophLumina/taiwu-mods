namespace GameData.Domains.Item;

public static class ModificationStateHelper
{
	public static bool IsActive(byte state, byte type)
	{
		return (state & type) != 0;
	}

	public static bool IsAnyActive(byte state)
	{
		return state != 0;
	}

	public static byte Activate(byte state, byte type)
	{
		return (byte)(state | type);
	}

	public static byte Deactivate(byte state, byte type)
	{
		return (byte)(state & ~type);
	}
}
