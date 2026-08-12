using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Loong : ConfigData<LoongItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 白龙
		/// </summary>
		public const short While = 0;

		/// <summary>
		/// 黑龙
		/// </summary>
		public const short Black = 1;

		/// <summary>
		/// 青龙
		/// </summary>
		public const short Green = 2;

		/// <summary>
		/// 赤龙
		/// </summary>
		public const short Red = 3;

		/// <summary>
		/// 黄龙
		/// </summary>
		public const short Yellow = 4;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 白龙
		/// </summary>
		public static LoongItem While => Instance[(short)0];

		/// <summary>
		/// 黑龙
		/// </summary>
		public static LoongItem Black => Instance[(short)1];

		/// <summary>
		/// 青龙
		/// </summary>
		public static LoongItem Green => Instance[(short)2];

		/// <summary>
		/// 赤龙
		/// </summary>
		public static LoongItem Red => Instance[(short)3];

		/// <summary>
		/// 黄龙
		/// </summary>
		public static LoongItem Yellow => Instance[(short)4];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static Loong Instance = new Loong();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"CharTemplateId", "MinionCharTemplateId", "MapBlock", "ClothingTemplateId", "WorldState", "BlockEffectTip", "DebuffCountIncNotification", "DebuffCountDecNotification", "Jiao", "Task",
		"TemplateId", "PersonalityType", "PersonalityRequirement", "EnterCombatEffect", "EnterCombatSound", "DebuffMarkOnChar"
	};

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new LoongItem(0, 246, 251, 137, 0, 50, 75, 42, LocalStringManager.GetConfig("Loong_language", "BlockEffectTip_0"), 120, 125, "debuff_leisj", "Ambience_map_dragon_jin_appear", 0, 238, "fiveloong_mark_0"));
		_dataArray.Add(new LoongItem(1, 247, 252, 138, 1, 50, 76, 43, LocalStringManager.GetConfig("Loong_language", "BlockEffectTip_1"), 121, 126, "debuff_shuisj", "Ambience_map_dragon_shui_appear", 1, 239, "fiveloong_mark_2"));
		_dataArray.Add(new LoongItem(2, 248, 253, 139, 2, 50, 77, 44, LocalStringManager.GetConfig("Loong_language", "BlockEffectTip_2"), 123, 128, "debuff_fengsj", "Ambience_map_dragon_mu_appear", 2, 240, "fiveloong_mark_1"));
		_dataArray.Add(new LoongItem(3, 249, 254, 140, 3, 50, 78, 45, LocalStringManager.GetConfig("Loong_language", "BlockEffectTip_3"), 122, 127, "debuff_huosj", "Ambience_map_dragon_huo_appear", 3, 241, "fiveloong_mark_3"));
		_dataArray.Add(new LoongItem(4, 250, 255, 141, 4, 50, 79, 46, LocalStringManager.GetConfig("Loong_language", "BlockEffectTip_4"), 124, 129, "debuff_shasj", "Ambience_map_dragon_tu_appear", 4, 242, "fiveloong_mark_4"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<LoongItem>(5);
		CreateItems0();
	}
}
