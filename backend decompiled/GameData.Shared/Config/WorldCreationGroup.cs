using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class WorldCreationGroup : ConfigData<WorldCreationGroupItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 身难
		/// </summary>
		public const sbyte Obstacle = 0;

		/// <summary>
		/// 机缘
		/// </summary>
		public const sbyte Income = 1;

		/// <summary>
		/// 修持
		/// </summary>
		public const sbyte Growth = 2;

		/// <summary>
		/// 通常
		/// </summary>
		public const sbyte Regular = 3;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 身难
		/// </summary>
		public static WorldCreationGroupItem Obstacle => Instance[(sbyte)0];

		/// <summary>
		/// 机缘
		/// </summary>
		public static WorldCreationGroupItem Income => Instance[(sbyte)1];

		/// <summary>
		/// 修持
		/// </summary>
		public static WorldCreationGroupItem Growth => Instance[(sbyte)2];

		/// <summary>
		/// 通常
		/// </summary>
		public static WorldCreationGroupItem Regular => Instance[(sbyte)3];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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
