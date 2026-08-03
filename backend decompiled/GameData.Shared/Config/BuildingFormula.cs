using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class BuildingFormula : ConfigData<BuildingFormulaItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 凤凰台效果公式
		/// </summary>
		public const int PhoenixPlatformEffect = 0;

		/// <summary>
		/// 方略室效果公式
		/// </summary>
		public const int StrategyRoomEffect = 1;

		/// <summary>
		/// 藏书阁效果公式
		/// </summary>
		public const int BookCollectionRoomEffect = 2;

		/// <summary>
		/// 画影轩效果公式
		/// </summary>
		public const int MakeupRoomEffect = 3;

		/// <summary>
		/// 生灭两星幡效果公式
		/// </summary>
		public const int BirthDeathStreamerEffect = 4;

		/// <summary>
		/// 阅经阁效果公式
		/// </summary>
		public const int SutraReadingRoomEffect = 5;

		/// <summary>
		/// 丹房效果公式
		/// </summary>
		public const int LifeElixirRoomEffect = 6;

		/// <summary>
		/// 太吾氏祠堂效果公式
		/// </summary>
		public const int TaiwuShrineEffect = 7;

		/// <summary>
		/// 普通功法研读类效果公式
		/// </summary>
		public const int CombatSkillReadingEffect = 8;

		/// <summary>
		/// 技艺研读类效果公式
		/// </summary>
		public const int LifeSkillReadingEffect = 9;

		/// <summary>
		/// 非太吾村资源生成规模
		/// </summary>
		public const int NonTaiwuVillageResourceInitLevel = 10;

		/// <summary>
		/// 太吾村资源生成规模
		/// </summary>
		public const int TaiwuVillageResourceInitLevel = 11;

		/// <summary>
		/// 盛世集录额外资源规模
		/// </summary>
		public const int ProtagonistConstructionExtraLevel = 45;

		/// <summary>
		/// 无用资源生成规模
		/// </summary>
		public const int UselessResourceInitLevel = 12;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 凤凰台效果公式
		/// </summary>
		public static BuildingFormulaItem PhoenixPlatformEffect => Instance[0];

		/// <summary>
		/// 方略室效果公式
		/// </summary>
		public static BuildingFormulaItem StrategyRoomEffect => Instance[1];

		/// <summary>
		/// 藏书阁效果公式
		/// </summary>
		public static BuildingFormulaItem BookCollectionRoomEffect => Instance[2];

		/// <summary>
		/// 画影轩效果公式
		/// </summary>
		public static BuildingFormulaItem MakeupRoomEffect => Instance[3];

		/// <summary>
		/// 生灭两星幡效果公式
		/// </summary>
		public static BuildingFormulaItem BirthDeathStreamerEffect => Instance[4];

		/// <summary>
		/// 阅经阁效果公式
		/// </summary>
		public static BuildingFormulaItem SutraReadingRoomEffect => Instance[5];

		/// <summary>
		/// 丹房效果公式
		/// </summary>
		public static BuildingFormulaItem LifeElixirRoomEffect => Instance[6];

		/// <summary>
		/// 太吾氏祠堂效果公式
		/// </summary>
		public static BuildingFormulaItem TaiwuShrineEffect => Instance[7];

		/// <summary>
		/// 普通功法研读类效果公式
		/// </summary>
		public static BuildingFormulaItem CombatSkillReadingEffect => Instance[8];

		/// <summary>
		/// 技艺研读类效果公式
		/// </summary>
		public static BuildingFormulaItem LifeSkillReadingEffect => Instance[9];

		/// <summary>
		/// 非太吾村资源生成规模
		/// </summary>
		public static BuildingFormulaItem NonTaiwuVillageResourceInitLevel => Instance[10];

		/// <summary>
		/// 太吾村资源生成规模
		/// </summary>
		public static BuildingFormulaItem TaiwuVillageResourceInitLevel => Instance[11];

		/// <summary>
		/// 盛世集录额外资源规模
		/// </summary>
		public static BuildingFormulaItem ProtagonistConstructionExtraLevel => Instance[45];

		/// <summary>
		/// 无用资源生成规模
		/// </summary>
		public static BuildingFormulaItem UselessResourceInitLevel => Instance[12];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static BuildingFormula Instance = new BuildingFormula();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Arguments", "TemplateId" };

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
		_dataArray.Add(new BuildingFormulaItem(0, EBuildingFormulaType.Formula3, new EBuildingFormulaArgType[1] { EBuildingFormulaArgType.TotalAttainment }, new int[2] { 200, 100 }, -1));
		_dataArray.Add(new BuildingFormulaItem(1, EBuildingFormulaType.Formula2, new EBuildingFormulaArgType[1] { EBuildingFormulaArgType.TotalAttainment }, new int[2] { 3, 100 }, -1));
		_dataArray.Add(new BuildingFormulaItem(2, EBuildingFormulaType.Formula1, new EBuildingFormulaArgType[1] { EBuildingFormulaArgType.TotalAttainment }, new int[0], -1));
		_dataArray.Add(new BuildingFormulaItem(3, EBuildingFormulaType.Formula3, new EBuildingFormulaArgType[1] { EBuildingFormulaArgType.TotalAttainment }, new int[2] { 600, 100 }, -1));
		_dataArray.Add(new BuildingFormulaItem(4, EBuildingFormulaType.Formula2, new EBuildingFormulaArgType[1] { EBuildingFormulaArgType.TotalAttainment }, new int[2] { 25, 10 }, -1));
		_dataArray.Add(new BuildingFormulaItem(5, EBuildingFormulaType.Formula2, new EBuildingFormulaArgType[1] { EBuildingFormulaArgType.TotalAttainment }, new int[2] { 15, 50 }, -1));
		_dataArray.Add(new BuildingFormulaItem(6, EBuildingFormulaType.Formula4, new EBuildingFormulaArgType[1] { EBuildingFormulaArgType.TotalAttainment }, new int[3] { 12, 12, 100 }, -1));
		_dataArray.Add(new BuildingFormulaItem(7, EBuildingFormulaType.Formula5, new EBuildingFormulaArgType[2]
		{
			EBuildingFormulaArgType.LeaderFameType,
			EBuildingFormulaArgType.TotalAttainment
		}, new int[3] { 5, 5, 100 }, -1));
		_dataArray.Add(new BuildingFormulaItem(8, EBuildingFormulaType.Formula2, new EBuildingFormulaArgType[1], new int[2] { 25, 25 }, 50));
		_dataArray.Add(new BuildingFormulaItem(9, EBuildingFormulaType.Formula2, new EBuildingFormulaArgType[1], new int[2] { 25, 25 }, 50));
		_dataArray.Add(new BuildingFormulaItem(10, EBuildingFormulaType.Formula6, null, new int[2] { 1, 21 }, 20));
		_dataArray.Add(new BuildingFormulaItem(11, EBuildingFormulaType.Formula7, null, new int[4] { 50, 1, 2, 6 }, 20));
		_dataArray.Add(new BuildingFormulaItem(12, EBuildingFormulaType.Formula6, null, new int[2] { 10, 21 }, 20));
		_dataArray.Add(new BuildingFormulaItem(13, EBuildingFormulaType.Formula8, null, new int[1] { 10 }, 600));
		_dataArray.Add(new BuildingFormulaItem(14, EBuildingFormulaType.Formula8, null, new int[1] { 2 }, 120));
		_dataArray.Add(new BuildingFormulaItem(15, EBuildingFormulaType.Formula8, null, new int[1] { 10 }, 600));
		_dataArray.Add(new BuildingFormulaItem(16, EBuildingFormulaType.Formula8, null, new int[1] { 6 }, 360));
		_dataArray.Add(new BuildingFormulaItem(17, EBuildingFormulaType.Formula8, null, new int[1] { 10 }, 600));
		_dataArray.Add(new BuildingFormulaItem(18, EBuildingFormulaType.Formula8, null, new int[1] { 4 }, 240));
		_dataArray.Add(new BuildingFormulaItem(19, EBuildingFormulaType.Formula8, null, new int[1] { 1 }, 60));
		_dataArray.Add(new BuildingFormulaItem(20, EBuildingFormulaType.Formula8, null, new int[1] { 5 }, 300));
		_dataArray.Add(new BuildingFormulaItem(21, EBuildingFormulaType.Formula3, null, new int[2] { 5, 10 }, 30));
		_dataArray.Add(new BuildingFormulaItem(22, EBuildingFormulaType.Formula8, null, new int[1] { 10 }, 600));
		_dataArray.Add(new BuildingFormulaItem(23, EBuildingFormulaType.Formula8, null, new int[1] { 1 }, 60));
		_dataArray.Add(new BuildingFormulaItem(24, EBuildingFormulaType.Formula8, null, new int[1] { 10 }, 600));
		_dataArray.Add(new BuildingFormulaItem(25, EBuildingFormulaType.Formula8, null, new int[1] { 30 }, 1800));
		_dataArray.Add(new BuildingFormulaItem(26, EBuildingFormulaType.Formula8, null, new int[1] { 10 }, 600));
		_dataArray.Add(new BuildingFormulaItem(27, EBuildingFormulaType.Formula8, null, new int[1] { 1 }, 60));
		_dataArray.Add(new BuildingFormulaItem(28, EBuildingFormulaType.Formula3, null, new int[2] { 5, 10 }, 30));
		_dataArray.Add(new BuildingFormulaItem(29, EBuildingFormulaType.Formula8, null, new int[1] { 10 }, 600));
		_dataArray.Add(new BuildingFormulaItem(30, EBuildingFormulaType.Formula8, null, new int[1] { 60 }, 3600));
		_dataArray.Add(new BuildingFormulaItem(31, EBuildingFormulaType.Formula8, null, new int[1] { 5 }, 300));
		_dataArray.Add(new BuildingFormulaItem(32, EBuildingFormulaType.Formula8, null, new int[1] { 2 }, 120));
		_dataArray.Add(new BuildingFormulaItem(33, EBuildingFormulaType.Formula8, null, new int[1] { 5 }, 300));
		_dataArray.Add(new BuildingFormulaItem(34, EBuildingFormulaType.Formula8, null, new int[1] { 1 }, 60));
		_dataArray.Add(new BuildingFormulaItem(35, EBuildingFormulaType.Formula3, null, new int[2] { 75, 100 }, 45));
		_dataArray.Add(new BuildingFormulaItem(36, EBuildingFormulaType.Formula3, null, new int[2] { 75, 100 }, 45));
		_dataArray.Add(new BuildingFormulaItem(37, EBuildingFormulaType.Formula3, null, new int[2] { 75, 100 }, 45));
		_dataArray.Add(new BuildingFormulaItem(38, EBuildingFormulaType.Formula3, null, new int[2] { 25, 100 }, 15));
		_dataArray.Add(new BuildingFormulaItem(39, EBuildingFormulaType.Formula3, null, new int[2] { 250, 100 }, 150));
		_dataArray.Add(new BuildingFormulaItem(40, EBuildingFormulaType.Formula3, null, new int[2] { 5, 10 }, 30));
		_dataArray.Add(new BuildingFormulaItem(41, EBuildingFormulaType.Formula8, null, new int[1] { 1 }, 60));
		_dataArray.Add(new BuildingFormulaItem(42, EBuildingFormulaType.Formula8, null, new int[1] { 1 }, 60));
		_dataArray.Add(new BuildingFormulaItem(43, EBuildingFormulaType.Formula8, null, new int[1] { 1 }, 60));
		_dataArray.Add(new BuildingFormulaItem(44, EBuildingFormulaType.Formula8, null, new int[1] { 1 }, 60));
		_dataArray.Add(new BuildingFormulaItem(45, EBuildingFormulaType.Formula9, null, new int[2] { 5, 11 }, 20));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<BuildingFormulaItem>(46);
		CreateItems0();
	}
}
