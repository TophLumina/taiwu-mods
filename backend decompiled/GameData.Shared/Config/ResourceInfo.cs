using System;

namespace Config;

[Serializable]
public struct ResourceInfo(sbyte type, int count)
{
	public sbyte ResourceType = type;

	public int ResourceCount = count;
}
