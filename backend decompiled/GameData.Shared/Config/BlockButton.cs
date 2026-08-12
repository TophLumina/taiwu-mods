using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class BlockButton : ConfigData<BlockButtonItem, byte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 收集食材
		/// </summary>
		public const byte Gather0 = 0;

		/// <summary>
		/// 砍伐木料
		/// </summary>
		public const byte Gather1 = 1;

		/// <summary>
		/// 发掘金铁
		/// </summary>
		public const byte Gather2 = 2;

		/// <summary>
		/// 发掘玉石
		/// </summary>
		public const byte Gather3 = 3;

		/// <summary>
		/// 采集织物
		/// </summary>
		public const byte Gather4 = 4;

		/// <summary>
		/// 采集药材
		/// </summary>
		public const byte Gather5 = 5;

		/// <summary>
		/// 挖掘一次
		/// </summary>
		public const byte Dig = 6;

		/// <summary>
		/// 连续挖掘
		/// </summary>
		public const byte KeepDig = 7;

		/// <summary>
		/// 标记地点
		/// </summary>
		public const byte Mark = 8;

		/// <summary>
		/// 取消标记
		/// </summary>
		public const byte CancelMark = 9;

		/// <summary>
		/// 派遣村民
		/// </summary>
		public const byte Assign = 10;

		/// <summary>
		/// 切换村民
		/// </summary>
		public const byte SwitchCharacter = 11;

		/// <summary>
		/// 快速撤免
		/// </summary>
		public const byte CancelAssign = 12;

		/// <summary>
		/// 快速派遣
		/// </summary>
		public const byte QuickAssign = 13;

		/// <summary>
		/// 锁定派遣
		/// </summary>
		public const byte LockAssign = 14;

		/// <summary>
		/// 查看信息
		/// </summary>
		public const byte ShowInfo = 15;

		/// <summary>
		/// 待命
		/// </summary>
		public const byte Idle = 16;

		/// <summary>
		/// 守墓
		/// </summary>
		public const byte GraveKeeping = 17;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 收集食材
		/// </summary>
		public static BlockButtonItem Gather0 => Instance[(byte)0];

		/// <summary>
		/// 砍伐木料
		/// </summary>
		public static BlockButtonItem Gather1 => Instance[(byte)1];

		/// <summary>
		/// 发掘金铁
		/// </summary>
		public static BlockButtonItem Gather2 => Instance[(byte)2];

		/// <summary>
		/// 发掘玉石
		/// </summary>
		public static BlockButtonItem Gather3 => Instance[(byte)3];

		/// <summary>
		/// 采集织物
		/// </summary>
		public static BlockButtonItem Gather4 => Instance[(byte)4];

		/// <summary>
		/// 采集药材
		/// </summary>
		public static BlockButtonItem Gather5 => Instance[(byte)5];

		/// <summary>
		/// 挖掘一次
		/// </summary>
		public static BlockButtonItem Dig => Instance[(byte)6];

		/// <summary>
		/// 连续挖掘
		/// </summary>
		public static BlockButtonItem KeepDig => Instance[(byte)7];

		/// <summary>
		/// 标记地点
		/// </summary>
		public static BlockButtonItem Mark => Instance[(byte)8];

		/// <summary>
		/// 取消标记
		/// </summary>
		public static BlockButtonItem CancelMark => Instance[(byte)9];

		/// <summary>
		/// 派遣村民
		/// </summary>
		public static BlockButtonItem Assign => Instance[(byte)10];

		/// <summary>
		/// 切换村民
		/// </summary>
		public static BlockButtonItem SwitchCharacter => Instance[(byte)11];

		/// <summary>
		/// 快速撤免
		/// </summary>
		public static BlockButtonItem CancelAssign => Instance[(byte)12];

		/// <summary>
		/// 快速派遣
		/// </summary>
		public static BlockButtonItem QuickAssign => Instance[(byte)13];

		/// <summary>
		/// 锁定派遣
		/// </summary>
		public static BlockButtonItem LockAssign => Instance[(byte)14];

		/// <summary>
		/// 查看信息
		/// </summary>
		public static BlockButtonItem ShowInfo => Instance[(byte)15];

		/// <summary>
		/// 待命
		/// </summary>
		public static BlockButtonItem Idle => Instance[(byte)16];

		/// <summary>
		/// 守墓
		/// </summary>
		public static BlockButtonItem GraveKeeping => Instance[(byte)17];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static BlockButton Instance = new BlockButton();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Summary", "Desc", "TimeConsumeDesc", "TemplateId" };

	internal override int ToInt(byte value)
	{
		return value;
	}

	internal override byte ToTemplateId(int value)
	{
		return (byte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new BlockButtonItem(0, LocalStringManager.GetConfig("BlockButton_language", "Name_0"), LocalStringManager.GetConfig("BlockButton_language", "Summary_0"), LocalStringManager.GetConfig("BlockButton_language", "Desc_0"), 10, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_0")));
		_dataArray.Add(new BlockButtonItem(1, LocalStringManager.GetConfig("BlockButton_language", "Name_1"), LocalStringManager.GetConfig("BlockButton_language", "Summary_1"), LocalStringManager.GetConfig("BlockButton_language", "Desc_1"), 10, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_1")));
		_dataArray.Add(new BlockButtonItem(2, LocalStringManager.GetConfig("BlockButton_language", "Name_2"), LocalStringManager.GetConfig("BlockButton_language", "Summary_2"), LocalStringManager.GetConfig("BlockButton_language", "Desc_2"), 10, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_2")));
		_dataArray.Add(new BlockButtonItem(3, LocalStringManager.GetConfig("BlockButton_language", "Name_3"), LocalStringManager.GetConfig("BlockButton_language", "Summary_3"), LocalStringManager.GetConfig("BlockButton_language", "Desc_3"), 10, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_3")));
		_dataArray.Add(new BlockButtonItem(4, LocalStringManager.GetConfig("BlockButton_language", "Name_4"), LocalStringManager.GetConfig("BlockButton_language", "Summary_4"), LocalStringManager.GetConfig("BlockButton_language", "Desc_4"), 10, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_4")));
		_dataArray.Add(new BlockButtonItem(5, LocalStringManager.GetConfig("BlockButton_language", "Name_5"), LocalStringManager.GetConfig("BlockButton_language", "Summary_5"), LocalStringManager.GetConfig("BlockButton_language", "Desc_5"), 10, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_5")));
		_dataArray.Add(new BlockButtonItem(6, LocalStringManager.GetConfig("BlockButton_language", "Name_6"), LocalStringManager.GetConfig("BlockButton_language", "Summary_6"), LocalStringManager.GetConfig("BlockButton_language", "Desc_6"), 30, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_6")));
		_dataArray.Add(new BlockButtonItem(7, LocalStringManager.GetConfig("BlockButton_language", "Name_7"), LocalStringManager.GetConfig("BlockButton_language", "Summary_7"), LocalStringManager.GetConfig("BlockButton_language", "Desc_7"), 30, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_7")));
		_dataArray.Add(new BlockButtonItem(8, LocalStringManager.GetConfig("BlockButton_language", "Name_8"), LocalStringManager.GetConfig("BlockButton_language", "Summary_8"), LocalStringManager.GetConfig("BlockButton_language", "Desc_8"), -1, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_8")));
		_dataArray.Add(new BlockButtonItem(9, LocalStringManager.GetConfig("BlockButton_language", "Name_9"), LocalStringManager.GetConfig("BlockButton_language", "Summary_9"), LocalStringManager.GetConfig("BlockButton_language", "Desc_9"), -1, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_9")));
		_dataArray.Add(new BlockButtonItem(10, LocalStringManager.GetConfig("BlockButton_language", "Name_10"), LocalStringManager.GetConfig("BlockButton_language", "Summary_10"), LocalStringManager.GetConfig("BlockButton_language", "Desc_10"), -1, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_10")));
		_dataArray.Add(new BlockButtonItem(11, LocalStringManager.GetConfig("BlockButton_language", "Name_11"), LocalStringManager.GetConfig("BlockButton_language", "Summary_11"), LocalStringManager.GetConfig("BlockButton_language", "Desc_11"), -1, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_11")));
		_dataArray.Add(new BlockButtonItem(12, LocalStringManager.GetConfig("BlockButton_language", "Name_12"), LocalStringManager.GetConfig("BlockButton_language", "Summary_12"), LocalStringManager.GetConfig("BlockButton_language", "Desc_12"), -1, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_12")));
		_dataArray.Add(new BlockButtonItem(13, LocalStringManager.GetConfig("BlockButton_language", "Name_13"), LocalStringManager.GetConfig("BlockButton_language", "Summary_13"), LocalStringManager.GetConfig("BlockButton_language", "Desc_13"), -1, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_13")));
		_dataArray.Add(new BlockButtonItem(14, LocalStringManager.GetConfig("BlockButton_language", "Name_14"), LocalStringManager.GetConfig("BlockButton_language", "Summary_14"), LocalStringManager.GetConfig("BlockButton_language", "Desc_14"), -1, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_14")));
		_dataArray.Add(new BlockButtonItem(15, LocalStringManager.GetConfig("BlockButton_language", "Name_15"), LocalStringManager.GetConfig("BlockButton_language", "Summary_15"), LocalStringManager.GetConfig("BlockButton_language", "Desc_15"), -1, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_15")));
		_dataArray.Add(new BlockButtonItem(16, LocalStringManager.GetConfig("BlockButton_language", "Name_16"), LocalStringManager.GetConfig("BlockButton_language", "Summary_16"), LocalStringManager.GetConfig("BlockButton_language", "Desc_16"), -1, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_16")));
		_dataArray.Add(new BlockButtonItem(17, LocalStringManager.GetConfig("BlockButton_language", "Name_17"), LocalStringManager.GetConfig("BlockButton_language", "Summary_17"), LocalStringManager.GetConfig("BlockButton_language", "Desc_17"), -1, LocalStringManager.GetConfig("BlockButton_language", "TimeConsumeDesc_17")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<BlockButtonItem>(18);
		CreateItems0();
	}
}
