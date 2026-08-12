using System;

namespace GameData.Utilities;

[AttributeUsage(AttributeTargets.Method)]
public class CellValueHandleAttribute : Attribute
{
	public readonly string Key;

	public readonly string DisplayName;

	public CellValueHandleAttribute(string key, string displayName = null)
	{
		Key = key;
		DisplayName = displayName ?? key;
	}
}
