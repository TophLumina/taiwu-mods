using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Polearm;

public class PengLaiXianChi : RawCreateUnlockEffectBase
{
	private int ReduceBreathStance => base.IsDirectOrReverseEffectDoubling ? (-50) : (-25);

	protected override IEnumerable<sbyte> RequireMainAttributeTypes { get; } = new sbyte[2] { 4, 5 };

	protected override int RequireMainAttributeValue => 65;

	public PengLaiXianChi()
	{
	}

	public PengLaiXianChi(CombatSkillKey skillKey)
		: base(skillKey, 9305)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(204, EDataModifyType.AddPercent, -1);
	}

	protected override void OnAffectedChanged(DataContext context)
	{
		base.OnAffectedChanged(context);
		InvalidateCache(context, 204);
		DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar, base.SkillTemplateId);
		if (base.Affected)
		{
			ShowSpecialEffectTips(base.IsDirect, 1, 0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.SkillKey != SkillKey || dataKey.FieldId != 204 || !base.Affected)
		{
			return 0;
		}
		return ReduceBreathStance;
	}
}
