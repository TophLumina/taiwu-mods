using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MiniGameYuanshan : ConfigData<MiniGameYuanshanItem, byte>
{
	public static class DefKey
	{
		public const byte Max = 3;
	}

	public static class DefValue
	{
		public static MiniGameYuanshanItem Max => Instance[(byte)3];
	}

	public static MiniGameYuanshan Instance = new MiniGameYuanshan();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TemplateId", "SwapCount", "SwapDuration", "GreyIcon", "Effect", "EnableEffect" };

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
		_dataArray.Add(new MiniGameYuanshanItem(0, LocalStringManager.GetConfig("MiniGameYuanshan_language", "Name_0"), 5, 1f, greyIcon: true, effect: false, new bool[8]));
		_dataArray.Add(new MiniGameYuanshanItem(1, LocalStringManager.GetConfig("MiniGameYuanshan_language", "Name_1"), 7, 0.75f, greyIcon: false, effect: false, new bool[8] { false, false, false, false, false, false, true, true }));
		_dataArray.Add(new MiniGameYuanshanItem(2, LocalStringManager.GetConfig("MiniGameYuanshan_language", "Name_2"), 10, 0.5f, greyIcon: false, effect: true, new bool[8] { false, false, false, false, true, true, true, true }));
		_dataArray.Add(new MiniGameYuanshanItem(3, LocalStringManager.GetConfig("MiniGameYuanshan_language", "Name_3"), 0, 0f, greyIcon: false, effect: true, new bool[8] { true, true, true, true, true, true, true, true }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MiniGameYuanshanItem>(4);
		CreateItems0();
	}
}
