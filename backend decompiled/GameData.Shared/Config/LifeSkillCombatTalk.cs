using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LifeSkillCombatTalk : ConfigData<LifeSkillCombatTalkItem, short>
{
	public static class DefKey
	{
		public const short Prepare_Prologue = 0;

		public const short Prepare_Ban = 1;

		public const short Prepare_Verify = 2;

		public const short Prepare_Give_Away = 3;

		public const short Prepare_Secret_Succeeded = 4;

		public const short Prepare_Tempt_Succeeded = 5;

		public const short Prepare_Secret_Failed = 6;

		public const short Prepare_Tempt_Failed = 7;

		public const short Prepare_Ai_Secret = 8;

		public const short Prepare_Ai_Tempt = 9;

		public const short Prepare_Decide_Theme = 10;

		public const short Combat_Prologue = 11;

		public const short Combat_CreateUnit = 12;

		public const short Combat_Conflict_Win = 13;

		public const short Combat_Conflict_Lose = 14;

		public const short Combat_Give_In = 15;

		public const short Combat_Force_Give_In = 16;

		public const short Combat_Refuse_Force_Give_In = 17;

		public const short Combat_Failed = 18;

		public const short Combat_Succeeded = 19;
	}

	public static class DefValue
	{
		public static LifeSkillCombatTalkItem Prepare_Prologue => Instance[(short)0];

		public static LifeSkillCombatTalkItem Prepare_Ban => Instance[(short)1];

		public static LifeSkillCombatTalkItem Prepare_Verify => Instance[(short)2];

		public static LifeSkillCombatTalkItem Prepare_Give_Away => Instance[(short)3];

		public static LifeSkillCombatTalkItem Prepare_Secret_Succeeded => Instance[(short)4];

		public static LifeSkillCombatTalkItem Prepare_Tempt_Succeeded => Instance[(short)5];

		public static LifeSkillCombatTalkItem Prepare_Secret_Failed => Instance[(short)6];

		public static LifeSkillCombatTalkItem Prepare_Tempt_Failed => Instance[(short)7];

		public static LifeSkillCombatTalkItem Prepare_Ai_Secret => Instance[(short)8];

		public static LifeSkillCombatTalkItem Prepare_Ai_Tempt => Instance[(short)9];

		public static LifeSkillCombatTalkItem Prepare_Decide_Theme => Instance[(short)10];

		public static LifeSkillCombatTalkItem Combat_Prologue => Instance[(short)11];

		public static LifeSkillCombatTalkItem Combat_CreateUnit => Instance[(short)12];

		public static LifeSkillCombatTalkItem Combat_Conflict_Win => Instance[(short)13];

		public static LifeSkillCombatTalkItem Combat_Conflict_Lose => Instance[(short)14];

		public static LifeSkillCombatTalkItem Combat_Give_In => Instance[(short)15];

		public static LifeSkillCombatTalkItem Combat_Force_Give_In => Instance[(short)16];

		public static LifeSkillCombatTalkItem Combat_Refuse_Force_Give_In => Instance[(short)17];

		public static LifeSkillCombatTalkItem Combat_Failed => Instance[(short)18];

		public static LifeSkillCombatTalkItem Combat_Succeeded => Instance[(short)19];
	}

	public static LifeSkillCombatTalk Instance = new LifeSkillCombatTalk();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "NormalContent", "JustContent", "KindContent", "EvenContent", "RebelContent", "EgoisticContent", "TemplateId" };

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
		_dataArray.Add(new LifeSkillCombatTalkItem(0, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_0"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_0"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_0"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_0"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_0"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_0"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_0")));
		_dataArray.Add(new LifeSkillCombatTalkItem(1, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_1"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_1"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_1"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_1"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_1"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_1"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_1")));
		_dataArray.Add(new LifeSkillCombatTalkItem(2, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_2"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_2"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_2"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_2"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_2"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_2"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_2")));
		_dataArray.Add(new LifeSkillCombatTalkItem(3, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_3"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_3"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_3"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_3"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_3"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_3"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_3")));
		_dataArray.Add(new LifeSkillCombatTalkItem(4, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_4"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_4"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_4"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_4"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_4"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_4"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_4")));
		_dataArray.Add(new LifeSkillCombatTalkItem(5, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_5"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_5"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_5"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_5"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_5"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_5"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_5")));
		_dataArray.Add(new LifeSkillCombatTalkItem(6, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_6"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_6"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_6"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_6"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_6"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_6"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_6")));
		_dataArray.Add(new LifeSkillCombatTalkItem(7, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_7"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_7"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_7"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_7"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_7"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_7"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_7")));
		_dataArray.Add(new LifeSkillCombatTalkItem(8, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_8"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_8"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_8"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_8"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_8"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_8"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_8")));
		_dataArray.Add(new LifeSkillCombatTalkItem(9, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_9"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_9"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_9"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_9"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_9"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_9"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_9")));
		_dataArray.Add(new LifeSkillCombatTalkItem(10, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_10"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_10"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_10"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_10"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_10"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_10"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_10")));
		_dataArray.Add(new LifeSkillCombatTalkItem(11, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_11"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_11"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_11"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_11"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_11"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_11"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_11")));
		_dataArray.Add(new LifeSkillCombatTalkItem(12, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_12"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_12"), needRepalceType: true, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_12"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_12"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_12"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_12"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_12")));
		_dataArray.Add(new LifeSkillCombatTalkItem(13, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_13"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_13"), needRepalceType: true, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_13"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_13"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_13"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_13"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_13")));
		_dataArray.Add(new LifeSkillCombatTalkItem(14, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_14"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_14"), needRepalceType: true, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_14"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_14"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_14"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_14"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_14")));
		_dataArray.Add(new LifeSkillCombatTalkItem(15, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_15"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_15"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_15"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_15"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_15"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_15"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_15")));
		_dataArray.Add(new LifeSkillCombatTalkItem(16, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_16"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_16"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_16"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_16"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_16"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_16"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_16")));
		_dataArray.Add(new LifeSkillCombatTalkItem(17, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_17"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_17"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_17"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_17"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_17"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_17"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_17")));
		_dataArray.Add(new LifeSkillCombatTalkItem(18, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_18"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_18"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_18"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_18"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_18"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_18"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_18")));
		_dataArray.Add(new LifeSkillCombatTalkItem(19, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "Name_19"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "NormalContent_19"), needRepalceType: false, LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "JustContent_19"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "KindContent_19"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EvenContent_19"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "RebelContent_19"), LocalStringManager.GetConfig("LifeSkillCombatTalk_language", "EgoisticContent_19")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<LifeSkillCombatTalkItem>(20);
		CreateItems0();
	}
}
