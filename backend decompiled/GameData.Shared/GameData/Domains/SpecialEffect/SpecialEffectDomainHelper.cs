using System.Collections.Generic;

namespace GameData.Domains.SpecialEffect;

public static class SpecialEffectDomainHelper
{
	/// <summary>
	/// 数据域所辖数据
	/// </summary>
	public static class DataIds
	{
		public const ushort EffectDict = 0;

		public const ushort NextEffectId = 1;

		public const ushort AffectedDatas = 2;
	}

	/// <summary>
	/// 数据域中的方法
	/// </summary>
	public static class MethodIds
	{
		public const ushort GetAllCostNeiliEffectData = 0;

		public const ushort CostNeiliEffect = 1;

		public const ushort CanCostTrickDuringPreparingSkill = 2;

		public const ushort CostTrickDuringPreparingSkill = 3;
	}

	/// <summary>
	/// 数据域所辖数据的个数
	/// </summary>
	public const ushort DataCount = 3;

	/// <summary>
	/// 通过字段名获取数据 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "EffectDict", 0 },
		{ "NextEffectId", 1 },
		{ "AffectedDatas", 2 }
	};

	/// <summary>
	/// 通过数据 ID 获取对应的字段名.
	/// 字段名不一定要与字段的真实名称完全一致, 只要保证正反对应关系就行.
	/// </summary>
	public static readonly string[] DataId2FieldName = new string[3] { "EffectDict", "NextEffectId", "AffectedDatas" };

	/// <summary>
	/// DataId -&gt; 集合对象内的 FieldId -&gt; FieldName
	/// </summary>
	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[3][]
	{
		null,
		null,
		AffectedDataHelper.FieldId2FieldName
	};

	/// <summary>
	/// 通过数据域方法名获取数据域方法 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "GetAllCostNeiliEffectData", 0 },
		{ "CostNeiliEffect", 1 },
		{ "CanCostTrickDuringPreparingSkill", 2 },
		{ "CostTrickDuringPreparingSkill", 3 }
	};

	public static readonly string[] MethodId2MethodName = new string[4] { "GetAllCostNeiliEffectData", "CostNeiliEffect", "CanCostTrickDuringPreparingSkill", "CostTrickDuringPreparingSkill" };
}
