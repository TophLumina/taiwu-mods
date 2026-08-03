using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class SkillBreakPageEffectImplement : ConfigData<SkillBreakPageEffectImplementItem, sbyte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static SkillBreakPageEffectImplement Instance = new SkillBreakPageEffectImplement();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "EffectDesc", "TemplateId" };

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
		_dataArray.Add(new SkillBreakPageEffectImplementItem(0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(1, 0, 30, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(2, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(3, 0, -30, -10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(4, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(5, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(6, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(7, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), -20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(14, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, -20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(16, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(17, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, -10, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(21, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, -10, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(22, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, -20, 0, 0, 0, 0, 0, new string[1] { LocalStringManager.GetConfig("SkillBreakPageEffectImplement_language", "EffectDesc_22_0") }));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(23, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(24, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 25, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, -20, 0, 0, 0, 0, new string[1] { LocalStringManager.GetConfig("SkillBreakPageEffectImplement_language", "EffectDesc_25_0") }));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(26, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(27, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 25, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(28, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 20), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(29, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(20, 20, 20, 20), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -33, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 20), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(20, 20, 20, 20), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new string[0]));
		_dataArray.Add(new SkillBreakPageEffectImplementItem(33, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 0), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -33, new string[0]));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SkillBreakPageEffectImplementItem>(34);
		CreateItems0();
	}
}
