using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ChallengeMode : ConfigData<ChallengeModeItem, int>
{
	public static ChallengeMode Instance = new ChallengeMode();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "Type", "Icon" };

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
		_dataArray.Add(new ChallengeModeItem(0, EChallengeModeType.Required, EChallengeModeImplement.LimitedNeiliAllocation, 0, "ui9_icon_challenge_mode_0", LocalStringManager.GetConfig("ChallengeMode_language", "Name_0"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_0")));
		_dataArray.Add(new ChallengeModeItem(1, EChallengeModeType.Required, EChallengeModeImplement.DamageStep, 0, "ui9_icon_challenge_mode_1", LocalStringManager.GetConfig("ChallengeMode_language", "Name_1"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_1")));
		_dataArray.Add(new ChallengeModeItem(2, EChallengeModeType.Required, EChallengeModeImplement.InfectedDemon, 0, "ui9_icon_challenge_mode_2", LocalStringManager.GetConfig("ChallengeMode_language", "Name_2"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_2")));
		_dataArray.Add(new ChallengeModeItem(3, EChallengeModeType.Required, EChallengeModeImplement.ScarMark, 0, "ui9_icon_challenge_mode_3", LocalStringManager.GetConfig("ChallengeMode_language", "Name_3"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_3")));
		_dataArray.Add(new ChallengeModeItem(4, EChallengeModeType.Required, EChallengeModeImplement.BuildingWorkHard, 0, "ui9_icon_challenge_mode_4", LocalStringManager.GetConfig("ChallengeMode_language", "Name_4"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_4")));
		_dataArray.Add(new ChallengeModeItem(5, EChallengeModeType.Required, EChallengeModeImplement.MoreAlertness, 0, "ui9_icon_challenge_mode_5", LocalStringManager.GetConfig("ChallengeMode_language", "Name_5"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_5")));
		_dataArray.Add(new ChallengeModeItem(6, EChallengeModeType.Required, EChallengeModeImplement.LockWorldSettings, 0, "ui9_icon_challenge_mode_6", LocalStringManager.GetConfig("ChallengeMode_language", "Name_6"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_6")));
		_dataArray.Add(new ChallengeModeItem(7, EChallengeModeType.Required, EChallengeModeImplement.DreamBackNoCarryOver, 0, "ui9_icon_challenge_mode_7", LocalStringManager.GetConfig("ChallengeMode_language", "Name_7"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_7")));
		_dataArray.Add(new ChallengeModeItem(8, EChallengeModeType.Optional, EChallengeModeImplement.LegendaryBookLimitation, 2, "ui9_icon_challenge_mode_8", LocalStringManager.GetConfig("ChallengeMode_language", "Name_8"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_8")));
		_dataArray.Add(new ChallengeModeItem(9, EChallengeModeType.Optional, EChallengeModeImplement.Attainment, 3, "ui9_icon_challenge_mode_9", LocalStringManager.GetConfig("ChallengeMode_language", "Name_9"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_9")));
		_dataArray.Add(new ChallengeModeItem(10, EChallengeModeType.Optional, EChallengeModeImplement.ItemAndResourceAmountLess, 3, "ui9_icon_challenge_mode_10", LocalStringManager.GetConfig("ChallengeMode_language", "Name_10"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_10")));
		_dataArray.Add(new ChallengeModeItem(11, EChallengeModeType.Optional, EChallengeModeImplement.CostResources, 4, "ui9_icon_challenge_mode_11", LocalStringManager.GetConfig("ChallengeMode_language", "Name_11"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_11")));
		_dataArray.Add(new ChallengeModeItem(12, EChallengeModeType.Optional, EChallengeModeImplement.BuildingAreaLimit, 6, "ui9_icon_challenge_mode_12", LocalStringManager.GetConfig("ChallengeMode_language", "Name_12"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_12")));
		_dataArray.Add(new ChallengeModeItem(13, EChallengeModeType.Optional, EChallengeModeImplement.ProfessionSkillRequiresExp, 2, "ui9_icon_challenge_mode_13", LocalStringManager.GetConfig("ChallengeMode_language", "Name_13"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_13")));
		_dataArray.Add(new ChallengeModeItem(14, EChallengeModeType.Optional, EChallengeModeImplement.QiDisorder, 2, "ui9_icon_challenge_mode_14", LocalStringManager.GetConfig("ChallengeMode_language", "Name_14"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_14")));
		_dataArray.Add(new ChallengeModeItem(15, EChallengeModeType.Optional, EChallengeModeImplement.XiangshuMinion, 2, "ui9_icon_challenge_mode_15", LocalStringManager.GetConfig("ChallengeMode_language", "Name_15"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_15")));
		_dataArray.Add(new ChallengeModeItem(16, EChallengeModeType.Optional, EChallengeModeImplement.AdvanceMonthWorsen, 2, "ui9_icon_challenge_mode_16", LocalStringManager.GetConfig("ChallengeMode_language", "Name_16"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_16")));
		_dataArray.Add(new ChallengeModeItem(17, EChallengeModeType.Optional, EChallengeModeImplement.TaiwuVowLimition, 3, "ui9_icon_challenge_mode_17", LocalStringManager.GetConfig("ChallengeMode_language", "Name_17"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_17")));
		_dataArray.Add(new ChallengeModeItem(18, EChallengeModeType.Optional, EChallengeModeImplement.CricketFairCombat, 4, "ui9_icon_challenge_mode_18", LocalStringManager.GetConfig("ChallengeMode_language", "Name_18"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_18")));
		_dataArray.Add(new ChallengeModeItem(19, EChallengeModeType.Optional, EChallengeModeImplement.SuccessorOfXiangshu, 3, "ui9_icon_challenge_mode_19", LocalStringManager.GetConfig("ChallengeMode_language", "Name_19"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_19")));
		_dataArray.Add(new ChallengeModeItem(20, EChallengeModeType.Bonus, EChallengeModeImplement.WugKing, -6, "ui9_icon_challenge_mode_20", LocalStringManager.GetConfig("ChallengeMode_language", "Name_20"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_20")));
		_dataArray.Add(new ChallengeModeItem(21, EChallengeModeType.Bonus, EChallengeModeImplement.ReincarnationBonus, -12, "ui9_icon_challenge_mode_21", LocalStringManager.GetConfig("ChallengeMode_language", "Name_21"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_21")));
		_dataArray.Add(new ChallengeModeItem(22, EChallengeModeType.Bonus, EChallengeModeImplement.Exp, -3, "ui9_icon_challenge_mode_22", LocalStringManager.GetConfig("ChallengeMode_language", "Name_22"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_22")));
		_dataArray.Add(new ChallengeModeItem(23, EChallengeModeType.Bonus, EChallengeModeImplement.MoneyAndResources, -3, "ui9_icon_challenge_mode_23", LocalStringManager.GetConfig("ChallengeMode_language", "Name_23"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_23")));
		_dataArray.Add(new ChallengeModeItem(24, EChallengeModeType.Bonus, EChallengeModeImplement.AutoReadBook, -6, "ui9_icon_challenge_mode_24", LocalStringManager.GetConfig("ChallengeMode_language", "Name_24"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_24")));
		_dataArray.Add(new ChallengeModeItem(25, EChallengeModeType.Bonus, EChallengeModeImplement.MoreActionPoint, -6, "ui9_icon_challenge_mode_25", LocalStringManager.GetConfig("ChallengeMode_language", "Name_25"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_25")));
		_dataArray.Add(new ChallengeModeItem(26, EChallengeModeType.Optional, EChallengeModeImplement.Invalid, 3, "ui9_icon_challenge_mode_26", LocalStringManager.GetConfig("ChallengeMode_language", "Name_26"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_26")));
		_dataArray.Add(new ChallengeModeItem(27, EChallengeModeType.Optional, EChallengeModeImplement.Invalid, 3, "ui9_icon_challenge_mode_27", LocalStringManager.GetConfig("ChallengeMode_language", "Name_27"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_27")));
		_dataArray.Add(new ChallengeModeItem(28, EChallengeModeType.Bonus, EChallengeModeImplement.Invalid, -6, "ui9_icon_challenge_mode_28", LocalStringManager.GetConfig("ChallengeMode_language", "Name_28"), LocalStringManager.GetConfig("ChallengeMode_language", "Desc_28")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ChallengeModeItem>(29);
		CreateItems0();
	}
}
