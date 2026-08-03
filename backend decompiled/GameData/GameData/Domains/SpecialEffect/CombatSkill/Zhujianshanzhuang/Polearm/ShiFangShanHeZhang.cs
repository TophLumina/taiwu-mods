using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Polearm;

public class ShiFangShanHeZhang : RawCreateUnlockEffectBase
{
	private int AddAttackRange => base.IsDirectOrReverseEffectDoubling ? 40 : 20;

	protected override IEnumerable<sbyte> RequireMainAttributeTypes { get; } = new sbyte[1] { 3 };

	protected override int RequireMainAttributeValue => 75;

	public ShiFangShanHeZhang()
	{
	}

	public ShiFangShanHeZhang(CombatSkillKey skillKey)
		: base(skillKey, 9302)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(145, EDataModifyType.Add, base.SkillTemplateId);
		CreateAffectedData(146, EDataModifyType.Add, base.SkillTemplateId);
	}

	protected override void OnAffectedChanged(DataContext context)
	{
		base.OnAffectedChanged(context);
		InvalidateCache(context, 145);
		InvalidateCache(context, 146);
		if (base.Affected)
		{
			ShowSpecialEffectTips(base.IsDirect, 1, 0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		bool flag = dataKey.SkillKey != SkillKey;
		bool flag2 = flag;
		if (!flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = (uint)(fieldId - 145) <= 1u;
			flag2 = !flag3;
		}
		if (flag2 || !base.Affected)
		{
			return 0;
		}
		return AddAttackRange;
	}
}
