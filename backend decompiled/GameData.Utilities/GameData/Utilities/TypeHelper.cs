using System;

namespace GameData.Utilities;

public static class TypeHelper
{
	private class U<T> where T : unmanaged
	{
	}

	public static bool IsUnManaged(Type type)
	{
		try
		{
			typeof(U<>).MakeGenericType(type);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}
}
