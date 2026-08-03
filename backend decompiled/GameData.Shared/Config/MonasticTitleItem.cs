using System;

namespace Config;

[Serializable]
public class MonasticTitleItem
{
	public readonly short TemplateId;

	public readonly string Name;

	public MonasticTitleItem(short id, string name)
	{
		TemplateId = id;
		Name = name;
	}
}
