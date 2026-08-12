using System;

namespace Config;

[Serializable]
public class SurnameItem
{
	public readonly short TemplateId;

	public readonly string Surname;

	public readonly sbyte Prob;

	public SurnameItem(short arg1, string arg2, sbyte arg3)
	{
		TemplateId = arg1;
		Surname = arg2;
		Prob = arg3;
	}
}
