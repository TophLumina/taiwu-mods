using System.Collections.Generic;

namespace GameData.Domains.CombatSkill;

public static class CombatSkillHelper
{
	public static class FieldIds
	{
		public const ushort Id = 0;

		public const ushort ReadingState = 1;

		public const ushort ActivationState = 2;

		public const ushort ForcedBreakoutStepsCount = 3;

		public const ushort BreakoutStepsCount = 4;

		public const ushort InnerRatio = 5;

		public const ushort ObtainedNeili = 6;

		public const ushort Revoked = 7;

		public const ushort SpecialEffectId = 8;

		public const ushort Power = 9;

		public const ushort MaxPower = 10;

		public const ushort RequirementPercent = 11;

		public const ushort Direction = 12;

		public const ushort BaseScore = 13;

		public const ushort CurrInnerRatio = 14;

		public const ushort HitValue = 15;

		public const ushort Penetrations = 16;

		public const ushort CostBreathAndStancePercent = 17;

		public const ushort CostBreathPercent = 18;

		public const ushort CostStancePercent = 19;

		public const ushort CostMobilityPercent = 20;

		public const ushort AddHitValueOnCast = 21;

		public const ushort AddPenetrateResist = 22;

		public const ushort AddAvoidValueOnCast = 23;

		public const ushort FightBackPower = 24;

		public const ushort BouncePower = 25;

		public const ushort RequirementsPower = 26;

		public const ushort PlateAddMaxPower = 27;
	}

	public const ushort ArchiveFieldsCount = 9;

	public const ushort CacheFieldsCount = 19;

	public const ushort PureTemplateFieldsCount = 0;

	public const ushort WritableFieldsCount = 28;

	public const ushort ReadonlyFieldsCount = 0;

	public static readonly Dictionary<string, ushort> FieldName2FieldId = new Dictionary<string, ushort>
	{
		{ "Id", 0 },
		{ "ReadingState", 1 },
		{ "ActivationState", 2 },
		{ "ForcedBreakoutStepsCount", 3 },
		{ "BreakoutStepsCount", 4 },
		{ "InnerRatio", 5 },
		{ "ObtainedNeili", 6 },
		{ "Revoked", 7 },
		{ "SpecialEffectId", 8 },
		{ "Power", 9 },
		{ "MaxPower", 10 },
		{ "RequirementPercent", 11 },
		{ "Direction", 12 },
		{ "BaseScore", 13 },
		{ "CurrInnerRatio", 14 },
		{ "HitValue", 15 },
		{ "Penetrations", 16 },
		{ "CostBreathAndStancePercent", 17 },
		{ "CostBreathPercent", 18 },
		{ "CostStancePercent", 19 },
		{ "CostMobilityPercent", 20 },
		{ "AddHitValueOnCast", 21 },
		{ "AddPenetrateResist", 22 },
		{ "AddAvoidValueOnCast", 23 },
		{ "FightBackPower", 24 },
		{ "BouncePower", 25 },
		{ "RequirementsPower", 26 },
		{ "PlateAddMaxPower", 27 }
	};

	public static readonly string[] FieldId2FieldName = new string[28]
	{
		"Id", "ReadingState", "ActivationState", "ForcedBreakoutStepsCount", "BreakoutStepsCount", "InnerRatio", "ObtainedNeili", "Revoked", "SpecialEffectId", "Power",
		"MaxPower", "RequirementPercent", "Direction", "BaseScore", "CurrInnerRatio", "HitValue", "Penetrations", "CostBreathAndStancePercent", "CostBreathPercent", "CostStancePercent",
		"CostMobilityPercent", "AddHitValueOnCast", "AddPenetrateResist", "AddAvoidValueOnCast", "FightBackPower", "BouncePower", "RequirementsPower", "PlateAddMaxPower"
	};
}
