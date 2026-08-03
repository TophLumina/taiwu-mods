using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterMenuFunctionControl : ConfigData<CharacterMenuFunctionControlItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 战斗准备
		/// </summary>
		public const short ViewCombatBegin = 0;

		/// <summary>
		/// 较艺准备
		/// </summary>
		public const short ViewLifeSkillCombatBegin = 1;

		/// <summary>
		/// 战斗环节
		/// </summary>
		public const short ViewCombat = 2;

		/// <summary>
		/// 较艺环节
		/// </summary>
		public const short ViewDebate = 3;

		/// <summary>
		/// 促织环节
		/// </summary>
		public const short ViewCricketCombat = 4;

		/// <summary>
		/// 事件互动
		/// </summary>
		public const short ViewEventWindow = 5;

		/// <summary>
		/// 监牢悬赏界面
		/// </summary>
		public const short ViewSettlementBounty = 6;

		/// <summary>
		/// 势力情报界面
		/// </summary>
		public const short ViewSettlementInformation = 7;

		/// <summary>
		/// 交换物品界面
		/// </summary>
		public const short ViewExchange = 8;

		/// <summary>
		/// 关注人物界面
		/// </summary>
		public const short ViewFollowing = 9;

		/// <summary>
		/// 化魂界面
		/// </summary>
		public const short ViewSwapSoul = 10;

		/// <summary>
		/// 监牢界面
		/// </summary>
		public const short ViewSettlementPrison = 11;

		/// <summary>
		/// 产业经营界面
		/// </summary>
		public const short ViewBuildingManage = 12;

		/// <summary>
		/// 商店购买界面
		/// </summary>
		public const short ViewShop = 13;

		/// <summary>
		/// 奇书断执界面
		/// </summary>
		public const short ViewRanshanThreeCorpses = 14;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 战斗准备
		/// </summary>
		public static CharacterMenuFunctionControlItem ViewCombatBegin => Instance[(short)0];

		/// <summary>
		/// 较艺准备
		/// </summary>
		public static CharacterMenuFunctionControlItem ViewLifeSkillCombatBegin => Instance[(short)1];

		/// <summary>
		/// 战斗环节
		/// </summary>
		public static CharacterMenuFunctionControlItem ViewCombat => Instance[(short)2];

		/// <summary>
		/// 较艺环节
		/// </summary>
		public static CharacterMenuFunctionControlItem ViewDebate => Instance[(short)3];

		/// <summary>
		/// 促织环节
		/// </summary>
		public static CharacterMenuFunctionControlItem ViewCricketCombat => Instance[(short)4];

		/// <summary>
		/// 事件互动
		/// </summary>
		public static CharacterMenuFunctionControlItem ViewEventWindow => Instance[(short)5];

		/// <summary>
		/// 监牢悬赏界面
		/// </summary>
		public static CharacterMenuFunctionControlItem ViewSettlementBounty => Instance[(short)6];

		/// <summary>
		/// 势力情报界面
		/// </summary>
		public static CharacterMenuFunctionControlItem ViewSettlementInformation => Instance[(short)7];

		/// <summary>
		/// 交换物品界面
		/// </summary>
		public static CharacterMenuFunctionControlItem ViewExchange => Instance[(short)8];

		/// <summary>
		/// 关注人物界面
		/// </summary>
		public static CharacterMenuFunctionControlItem ViewFollowing => Instance[(short)9];

		/// <summary>
		/// 化魂界面
		/// </summary>
		public static CharacterMenuFunctionControlItem ViewSwapSoul => Instance[(short)10];

		/// <summary>
		/// 监牢界面
		/// </summary>
		public static CharacterMenuFunctionControlItem ViewSettlementPrison => Instance[(short)11];

		/// <summary>
		/// 产业经营界面
		/// </summary>
		public static CharacterMenuFunctionControlItem ViewBuildingManage => Instance[(short)12];

		/// <summary>
		/// 商店购买界面
		/// </summary>
		public static CharacterMenuFunctionControlItem ViewShop => Instance[(short)13];

		/// <summary>
		/// 奇书断执界面
		/// </summary>
		public static CharacterMenuFunctionControlItem ViewRanshanThreeCorpses => Instance[(short)14];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CharacterMenuFunctionControl Instance = new CharacterMenuFunctionControl();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Gift", "Filter", "Drop", "Feed", "Check", "Repair", "Disassemble", "Eat", "Exchange", "Take",
		"Scam", "Steal", "Rob", "SectStory", "EventTrigger", "SkillBreak", "ItemEquip", "SkillEquip", "Neili", "Medicine",
		"Heal", "Inscribe", "Chat", "Command", "Leave", "Batch", "Kidnapped", "TemplateId"
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
		_dataArray.Add(new CharacterMenuFunctionControlItem(0, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.NotTaiwu, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.NotTaiwu, ECharacterMenuFunctionControlType.NotTaiwu, ECharacterMenuFunctionControlType.NotTaiwu, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.NotTaiwu, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Teammate, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.NotTaiwu));
		_dataArray.Add(new CharacterMenuFunctionControlItem(1, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.NotTaiwu, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.NotTaiwu, ECharacterMenuFunctionControlType.NotTaiwu, ECharacterMenuFunctionControlType.NotTaiwu, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.NotTaiwu, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Teammate, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.NotTaiwu));
		_dataArray.Add(new CharacterMenuFunctionControlItem(2, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All));
		_dataArray.Add(new CharacterMenuFunctionControlItem(3, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All));
		_dataArray.Add(new CharacterMenuFunctionControlItem(4, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All));
		_dataArray.Add(new CharacterMenuFunctionControlItem(5, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.Other, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.Other));
		_dataArray.Add(new CharacterMenuFunctionControlItem(6, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All));
		_dataArray.Add(new CharacterMenuFunctionControlItem(7, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All));
		_dataArray.Add(new CharacterMenuFunctionControlItem(8, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All));
		_dataArray.Add(new CharacterMenuFunctionControlItem(9, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All));
		_dataArray.Add(new CharacterMenuFunctionControlItem(10, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All));
		_dataArray.Add(new CharacterMenuFunctionControlItem(11, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All));
		_dataArray.Add(new CharacterMenuFunctionControlItem(12, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All));
		_dataArray.Add(new CharacterMenuFunctionControlItem(13, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All));
		_dataArray.Add(new CharacterMenuFunctionControlItem(14, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CharacterMenuFunctionControlItem>(15);
		CreateItems0();
	}
}
