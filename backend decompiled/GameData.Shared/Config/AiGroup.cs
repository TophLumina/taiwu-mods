using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AiGroup : ConfigData<AiGroupItem, int>
{
	public static class DefKey
	{
		public const int General = 0;

		public const int Combat = 1;
	}

	public static class DefValue
	{
		public static AiGroupItem General => Instance[0];

		public static AiGroupItem Combat => Instance[1];
	}

	public static AiGroup Instance = new AiGroup();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "GroupIds", "TemplateId" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new AiGroupItem(0, new List<int> { 0, 1 }));
		_dataArray.Add(new AiGroupItem(1, new List<int> { 1 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AiGroupItem>(2);
		CreateItems0();
	}
}
