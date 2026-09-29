using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class WorldCreationGroup : ConfigData<WorldCreationGroupItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte Obstacle = 0;

		public const sbyte Income = 1;

		public const sbyte Growth = 2;

		public const sbyte Regular = 3;
	}

	public static class DefValue
	{
		public static WorldCreationGroupItem Obstacle => Instance[(sbyte)0];

		public static WorldCreationGroupItem Income => Instance[(sbyte)1];

		public static WorldCreationGroupItem Growth => Instance[(sbyte)2];

		public static WorldCreationGroupItem Regular => Instance[(sbyte)3];
	}

	public static WorldCreationGroup Instance = new WorldCreationGroup();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "WorldCreations", "TemplateId", "Image" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new WorldCreationGroupItem(0, LocalStringManager.GetConfig("WorldCreationGroup_language", "Name_0"), "legacy_type_0", new byte[4] { 1, 11, 5, 6 }));
		_dataArray.Add(new WorldCreationGroupItem(1, LocalStringManager.GetConfig("WorldCreationGroup_language", "Name_1"), "legacy_type_1", new byte[3] { 7, 12, 14 }));
		_dataArray.Add(new WorldCreationGroupItem(2, LocalStringManager.GetConfig("WorldCreationGroup_language", "Name_2"), "legacy_type_2", new byte[4] { 2, 3, 4, 13 }));
		_dataArray.Add(new WorldCreationGroupItem(3, LocalStringManager.GetConfig("WorldCreationGroup_language", "Name_3"), null, new byte[4] { 8, 0, 9, 10 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<WorldCreationGroupItem>(4);
		CreateItems0();
	}
}
