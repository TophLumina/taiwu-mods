using System.Collections.Generic;

namespace GameData.Domains.CombatSkill;

public static class CombatSkillDomainHelper
{
	/// <summary>
	/// 数据域所辖数据
	/// </summary>
	public static class DataIds
	{
		public const ushort CombatSkills = 0;
	}

	/// <summary>
	/// 数据域中的方法
	/// </summary>
	public static class MethodIds
	{
		public const ushort GetCombatSkillDisplayData = 0;

		public const ushort GetCombatSkillBreakStepCount = 1;

		public const ushort GetCharacterEquipCombatSkillDisplayData = 2;

		public const ushort GetCombatSkillDisplayDataOnce = 3;

		public const ushort GetEffectDescriptionData = 4;

		public const ushort CalcTaiwuExtraDeltaNeiliPerLoop = 5;

		public const ushort CalcTaiwuExtraDeltaNeiliAllocationPerLoop = 6;

		public const ushort GetCombatSkillPreviewDisplayDataOnce = 7;

		public const ushort GetCombatSkillBreakoutStepsMaxPower = 8;

		public const ushort GetCombatSkillBreakBonuses = 9;

		public const ushort SetActivePage = 10;

		public const ushort DeActivePage = 11;

		public const ushort CalcTaiwuCombatSkillBreakSuccessRate = 12;

		public const ushort CalcCombatSkillBreakAvailableStepsDisplayData = 13;

		public const ushort GetEquipCombatSkillDisplayData = 14;

		public const ushort GetCharacterMenuCombatSkillListItemDisplayData = 15;

		public const ushort GetLoopingTransferNeiliProportionOfFiveElementsDataForTaiwu = 16;

		public const ushort GetCombatSkillDisplayDataForPractice = 17;

		public const ushort CalcTaiwuExtraDeltaNeiliAllocationLoops = 18;

		public const ushort GetLearnedCombatSkillByType = 19;

		public const ushort GetCombatSkillDisplayDataForListOnce = 20;

		public const ushort GetCombatSkillDisplayDataForList = 21;

		public const ushort GetCombatSkillEquipment = 22;

		public const ushort GetCharacterEquipNeigongBreakList = 23;

		public const ushort GetCharacterEquipAssistanceBreakList = 24;
	}

	/// <summary>
	/// 数据域所辖数据的个数
	/// </summary>
	public const ushort DataCount = 1;

	/// <summary>
	/// 通过字段名获取数据 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort> { { "CombatSkills", 0 } };

	/// <summary>
	/// 通过数据 ID 获取对应的字段名.
	/// 字段名不一定要与字段的真实名称完全一致, 只要保证正反对应关系就行.
	/// </summary>
	public static readonly string[] DataId2FieldName = new string[1] { "CombatSkills" };

	/// <summary>
	/// DataId -&gt; 集合对象内的 FieldId -&gt; FieldName
	/// </summary>
	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[1][] { CombatSkillHelper.FieldId2FieldName };

	/// <summary>
	/// 通过数据域方法名获取数据域方法 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "GetCombatSkillDisplayData", 0 },
		{ "GetCombatSkillBreakStepCount", 1 },
		{ "GetCharacterEquipCombatSkillDisplayData", 2 },
		{ "GetCombatSkillDisplayDataOnce", 3 },
		{ "GetEffectDescriptionData", 4 },
		{ "CalcTaiwuExtraDeltaNeiliPerLoop", 5 },
		{ "CalcTaiwuExtraDeltaNeiliAllocationPerLoop", 6 },
		{ "GetCombatSkillPreviewDisplayDataOnce", 7 },
		{ "GetCombatSkillBreakoutStepsMaxPower", 8 },
		{ "GetCombatSkillBreakBonuses", 9 },
		{ "SetActivePage", 10 },
		{ "DeActivePage", 11 },
		{ "CalcTaiwuCombatSkillBreakSuccessRate", 12 },
		{ "CalcCombatSkillBreakAvailableStepsDisplayData", 13 },
		{ "GetEquipCombatSkillDisplayData", 14 },
		{ "GetCharacterMenuCombatSkillListItemDisplayData", 15 },
		{ "GetLoopingTransferNeiliProportionOfFiveElementsDataForTaiwu", 16 },
		{ "GetCombatSkillDisplayDataForPractice", 17 },
		{ "CalcTaiwuExtraDeltaNeiliAllocationLoops", 18 },
		{ "GetLearnedCombatSkillByType", 19 },
		{ "GetCombatSkillDisplayDataForListOnce", 20 },
		{ "GetCombatSkillDisplayDataForList", 21 },
		{ "GetCombatSkillEquipment", 22 },
		{ "GetCharacterEquipNeigongBreakList", 23 },
		{ "GetCharacterEquipAssistanceBreakList", 24 }
	};

	public static readonly string[] MethodId2MethodName = new string[25]
	{
		"GetCombatSkillDisplayData", "GetCombatSkillBreakStepCount", "GetCharacterEquipCombatSkillDisplayData", "GetCombatSkillDisplayDataOnce", "GetEffectDescriptionData", "CalcTaiwuExtraDeltaNeiliPerLoop", "CalcTaiwuExtraDeltaNeiliAllocationPerLoop", "GetCombatSkillPreviewDisplayDataOnce", "GetCombatSkillBreakoutStepsMaxPower", "GetCombatSkillBreakBonuses",
		"SetActivePage", "DeActivePage", "CalcTaiwuCombatSkillBreakSuccessRate", "CalcCombatSkillBreakAvailableStepsDisplayData", "GetEquipCombatSkillDisplayData", "GetCharacterMenuCombatSkillListItemDisplayData", "GetLoopingTransferNeiliProportionOfFiveElementsDataForTaiwu", "GetCombatSkillDisplayDataForPractice", "CalcTaiwuExtraDeltaNeiliAllocationLoops", "GetLearnedCombatSkillByType",
		"GetCombatSkillDisplayDataForListOnce", "GetCombatSkillDisplayDataForList", "GetCombatSkillEquipment", "GetCharacterEquipNeigongBreakList", "GetCharacterEquipAssistanceBreakList"
	};
}
