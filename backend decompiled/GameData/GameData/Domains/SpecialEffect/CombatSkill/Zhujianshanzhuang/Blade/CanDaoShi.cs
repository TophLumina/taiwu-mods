using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Blade;

public class CanDaoShi : BladeUnlockEffectBase
{
	private const int SilenceFrame = 1800;

	private int AddAttackRange => base.IsDirectOrReverseEffectDoubling ? 40 : 20;

	protected override IEnumerable<short> RequireWeaponTypes
	{
		get
		{
			yield return 0;
			yield return 2;
			yield return 12;
		}
	}

	public CanDaoShi()
	{
	}

	public CanDaoShi(CombatSkillKey skillKey)
		: base(skillKey, 9206)
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

	protected override bool CanDoAffect()
	{
		return base.CurrEnemyChar.GetAffectingMoveSkillId() >= 0;
	}

	public override void DoAffectAfterCost(DataContext context, int weaponIndex)
	{
		ShowSpecialEffectTips(base.IsDirect, 2, 1);
		short skillId = base.CurrEnemyChar.GetAffectingMoveSkillId();
		if (ClearAffectingAgileSkill(context, base.CurrEnemyChar))
		{
			DomainManager.Combat.AddGoneMadInjury(context, base.CurrEnemyChar, skillId);
			DomainManager.Combat.SilenceSkill(context, base.CurrEnemyChar, skillId, 1800);
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
