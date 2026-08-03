using System;

namespace Config;

[Serializable]
public class TownNameItem
{
	public readonly short TemplateId;

	public readonly string Name;

	public TownNameItem(short id, string name)
	{
		TemplateId = id;
		Name = name;
	}
}
