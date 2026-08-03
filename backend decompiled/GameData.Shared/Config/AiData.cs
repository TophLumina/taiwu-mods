using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AiData : ConfigData<AiDataItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 太吾
		/// </summary>
		public const int Taiwu = 0;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 太吾
		/// </summary>
		public static AiDataItem Taiwu => Instance[0];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AiData Instance = new AiData();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "GroupId", "TemplateId", "Path" };

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
		_dataArray.Add(new AiDataItem(0, "taiwu", 1));
		_dataArray.Add(new AiDataItem(1, "sect-story/baihua-anonym-escape", 1));
		_dataArray.Add(new AiDataItem(2, "sword-tomb/monv", 1));
		_dataArray.Add(new AiDataItem(3, "sword-tomb/dayue-yaochang", 1));
		_dataArray.Add(new AiDataItem(4, "sword-tomb/jiuhan", 1));
		_dataArray.Add(new AiDataItem(5, "sword-tomb/jin-huanger", 1));
		_dataArray.Add(new AiDataItem(6, "sword-tomb/yi-yihou", 1));
		_dataArray.Add(new AiDataItem(7, "sword-tomb/wei-qi", 1));
		_dataArray.Add(new AiDataItem(8, "sword-tomb/yixiang", 1));
		_dataArray.Add(new AiDataItem(9, "sword-tomb/xuefeng", 1));
		_dataArray.Add(new AiDataItem(10, "sword-tomb/shufang", 1));
		_dataArray.Add(new AiDataItem(11, "main-story/huanxin", 1));
		_dataArray.Add(new AiDataItem(12, "main-story/xiangshu", 1));
		_dataArray.Add(new AiDataItem(13, "tutorial/little-monk", 1));
		_dataArray.Add(new AiDataItem(14, "sect-story/baihua-anonym", 1));
		_dataArray.Add(new AiDataItem(15, "sect-story/shaolin-slayer-trial-demon0", 1));
		_dataArray.Add(new AiDataItem(16, "sect-story/shaolin-slayer-trial-demon3", 1));
		_dataArray.Add(new AiDataItem(17, "sect-story/shaolin-slayer-trial-demon6", 1));
		_dataArray.Add(new AiDataItem(18, "sect-story/shaolin-slayer-trial-demon7", 1));
		_dataArray.Add(new AiDataItem(19, "sect-story/shaolin-slayer-trial-demon11", 1));
		_dataArray.Add(new AiDataItem(20, "sect-story/shaolin-slayer-trial-demon2", 1));
		_dataArray.Add(new AiDataItem(21, "sect-story/shaolin-slayer-trial-demon4", 1));
		_dataArray.Add(new AiDataItem(22, "sect-story/shaolin-slayer-trial-demon17", 1));
		_dataArray.Add(new AiDataItem(23, "sect-story/shaolin-slayer-trial-demon10", 1));
		_dataArray.Add(new AiDataItem(24, "sect-story/shaolin-slayer-trial-demon12", 1));
		_dataArray.Add(new AiDataItem(25, "sect-story/zhujian-gear-mate-play", 1));
		_dataArray.Add(new AiDataItem(26, "main-story/twelve-immortals", 1));
		_dataArray.Add(new AiDataItem(27, "main-story/xiangshu-real", 1));
		_dataArray.Add(new AiDataItem(28, "main-story/heavenly-emperor", 1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AiDataItem>(29);
		CreateItems0();
	}
}
