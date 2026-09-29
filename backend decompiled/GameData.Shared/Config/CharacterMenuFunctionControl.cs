using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterMenuFunctionControl : ConfigData<CharacterMenuFunctionControlItem, short>
{
	public static class DefKey
	{
		public const short ViewCombatBegin = 0;

		public const short ViewLifeSkillCombatBegin = 1;

		public const short ViewCombat = 2;

		public const short ViewDebate = 3;

		public const short ViewCricketCombat = 4;

		public const short ViewEventWindow = 5;

		public const short ViewSettlementBounty = 6;

		public const short ViewSettlementInformation = 7;

		public const short ViewExchange = 8;

		public const short ViewFollowing = 9;

		public const short ViewSwapSoul = 10;

		public const short ViewSettlementPrison = 11;

		public const short ViewBuildingManage = 12;

		public const short ViewShop = 13;

		public const short ViewRanshanThreeCorpses = 14;

		public const short AdventureMajorEvent = 15;
	}

	public static class DefValue
	{
		public static CharacterMenuFunctionControlItem ViewCombatBegin => Instance[(short)0];

		public static CharacterMenuFunctionControlItem ViewLifeSkillCombatBegin => Instance[(short)1];

		public static CharacterMenuFunctionControlItem ViewCombat => Instance[(short)2];

		public static CharacterMenuFunctionControlItem ViewDebate => Instance[(short)3];

		public static CharacterMenuFunctionControlItem ViewCricketCombat => Instance[(short)4];

		public static CharacterMenuFunctionControlItem ViewEventWindow => Instance[(short)5];

		public static CharacterMenuFunctionControlItem ViewSettlementBounty => Instance[(short)6];

		public static CharacterMenuFunctionControlItem ViewSettlementInformation => Instance[(short)7];

		public static CharacterMenuFunctionControlItem ViewExchange => Instance[(short)8];

		public static CharacterMenuFunctionControlItem ViewFollowing => Instance[(short)9];

		public static CharacterMenuFunctionControlItem ViewSwapSoul => Instance[(short)10];

		public static CharacterMenuFunctionControlItem ViewSettlementPrison => Instance[(short)11];

		public static CharacterMenuFunctionControlItem ViewBuildingManage => Instance[(short)12];

		public static CharacterMenuFunctionControlItem ViewShop => Instance[(short)13];

		public static CharacterMenuFunctionControlItem ViewRanshanThreeCorpses => Instance[(short)14];

		public static CharacterMenuFunctionControlItem AdventureMajorEvent => Instance[(short)15];
	}

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
		_dataArray.Add(new CharacterMenuFunctionControlItem(15, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.All, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None, ECharacterMenuFunctionControlType.None));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CharacterMenuFunctionControlItem>(16);
		CreateItems0();
	}
}
