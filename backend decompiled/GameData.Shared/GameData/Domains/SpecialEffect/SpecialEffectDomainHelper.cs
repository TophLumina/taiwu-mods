using System.Collections.Generic;

namespace GameData.Domains.SpecialEffect;

public static class SpecialEffectDomainHelper
{
	public static class DataIds
	{
		public const ushort EffectDict = 0;

		public const ushort NextEffectId = 1;

		public const ushort AffectedDatas = 2;
	}

	public static class MethodIds
	{
		public const ushort GetAllCostNeiliEffectData = 0;

		public const ushort CostNeiliEffect = 1;

		public const ushort CanCostTrickDuringPreparingSkill = 2;

		public const ushort CostTrickDuringPreparingSkill = 3;
	}

	public const ushort DataCount = 3;

	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "EffectDict", 0 },
		{ "NextEffectId", 1 },
		{ "AffectedDatas", 2 }
	};

	public static readonly string[] DataId2FieldName = new string[3] { "EffectDict", "NextEffectId", "AffectedDatas" };

	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[3][]
	{
		null,
		null,
		AffectedDataHelper.FieldId2FieldName
	};

	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "GetAllCostNeiliEffectData", 0 },
		{ "CostNeiliEffect", 1 },
		{ "CanCostTrickDuringPreparingSkill", 2 },
		{ "CostTrickDuringPreparingSkill", 3 }
	};

	public static readonly string[] MethodId2MethodName = new string[4] { "GetAllCostNeiliEffectData", "CostNeiliEffect", "CanCostTrickDuringPreparingSkill", "CostTrickDuringPreparingSkill" };
}
