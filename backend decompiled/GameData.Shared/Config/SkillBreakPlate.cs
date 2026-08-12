using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakPlate : ConfigData<SkillBreakPlateItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 演武
		/// </summary>
		public const sbyte Tutorial = 9;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 演武
		/// </summary>
		public static SkillBreakPlateItem Tutorial => Instance[(sbyte)9];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static SkillBreakPlate Instance = new SkillBreakPlate();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "PlateWidth", "PlateHeight", "CostExp", "TotalMaxPower", "BonusCount" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new SkillBreakPlateItem(0, 9, 11, 10, 40, 1));
		_dataArray.Add(new SkillBreakPlateItem(1, 9, 11, 30, 40, 1));
		_dataArray.Add(new SkillBreakPlateItem(2, 9, 11, 80, 40, 1));
		_dataArray.Add(new SkillBreakPlateItem(3, 13, 15, 150, 80, 2));
		_dataArray.Add(new SkillBreakPlateItem(4, 13, 15, 270, 80, 2));
		_dataArray.Add(new SkillBreakPlateItem(5, 13, 15, 420, 80, 2));
		_dataArray.Add(new SkillBreakPlateItem(6, 17, 19, 640, 120, 3));
		_dataArray.Add(new SkillBreakPlateItem(7, 17, 19, 900, 120, 3));
		_dataArray.Add(new SkillBreakPlateItem(8, 17, 19, 1300, 120, 3));
		_dataArray.Add(new SkillBreakPlateItem(9, 9, 11, 0, 40, 1));
		_dataArray.Add(new SkillBreakPlateItem(10, 9, 11, 10, 40, 3));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SkillBreakPlateItem>(11);
		CreateItems0();
	}
}
