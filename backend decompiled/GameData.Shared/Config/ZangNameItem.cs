using System;

namespace Config;

[Serializable]
public class ZangNameItem
{
	public readonly short TemplateId;

	public readonly string Name;

	public ZangNameItem(short id, string name)
	{
		TemplateId = id;
		Name = name;
	}
}
