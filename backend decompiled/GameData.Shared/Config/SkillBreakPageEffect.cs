using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakPageEffect : ConfigData<SkillBreakPageEffectItem, sbyte>
{
	public static SkillBreakPageEffect Instance = new SkillBreakPageEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "EffectNeigong", "EffectAttack", "EffectAgile", "EffectDefense", "EffectAssist", "TemplateId", "IsDirect", "PageId" };

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
		_dataArray.Add(new SkillBreakPageEffectItem(0, isDirect: true, 1, 0, 0, 0, 0, 0));
		_dataArray.Add(new SkillBreakPageEffectItem(1, isDirect: true, 2, 4, 10, 16, 22, 28));
		_dataArray.Add(new SkillBreakPageEffectItem(2, isDirect: true, 3, 5, 11, 17, 23, 29));
		_dataArray.Add(new SkillBreakPageEffectItem(3, isDirect: true, 4, 6, 12, 18, 24, 30));
		_dataArray.Add(new SkillBreakPageEffectItem(4, isDirect: true, 5, 1, 1, 1, 1, 1));
		_dataArray.Add(new SkillBreakPageEffectItem(5, isDirect: false, 1, 2, 2, 2, 2, 2));
		_dataArray.Add(new SkillBreakPageEffectItem(6, isDirect: false, 2, 7, 13, 19, 25, 31));
		_dataArray.Add(new SkillBreakPageEffectItem(7, isDirect: false, 3, 8, 14, 20, 26, 32));
		_dataArray.Add(new SkillBreakPageEffectItem(8, isDirect: false, 4, 9, 15, 21, 27, 33));
		_dataArray.Add(new SkillBreakPageEffectItem(9, isDirect: false, 5, 3, 3, 3, 3, 3));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SkillBreakPageEffectItem>(10);
		CreateItems0();
	}
}
