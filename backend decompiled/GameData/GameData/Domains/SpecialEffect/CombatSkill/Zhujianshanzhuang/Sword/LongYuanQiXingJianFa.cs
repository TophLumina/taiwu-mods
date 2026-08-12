using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Sword;

public class LongYuanQiXingJianFa : SwordUnlockEffectBase
{
	private const int EffectReduceBreathStance = -30;

	private int SelfReduceBreathStance => base.IsDirectOrReverseEffectDoubling ? (-60) : (-30);

	protected override IEnumerable<sbyte> RequirePersonalityTypes
	{
		get
		{
			yield return 1;
		}
	}

	protected override int RequirePersonalityValue => 50;

	public LongYuanQiXingJianFa()
	{
	}

	public LongYuanQiXingJianFa(CombatSkillKey skillKey)
		: base(skillKey, 9104)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(204, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_CastSkillCosted(OnCastSkillCosted);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillCosted(OnCastSkillCosted);
		base.OnDisable(context);
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

	protected override void OnAddedEffectCount(DataContext context)
	{
		base.OnAddedEffectCount(context);
		InvalidateCache(context, 204);
		DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar);
	}

	private void OnCastSkillCosted(DataContext context, CombatCharacter combatChar, short skillId)
	{
		if (combatChar.GetId() == base.CharacterId && base.EffectCount > 0 && CombatSkillEquipType.IsAttack(skillId) && Config.CombatSkill.Instance[skillId].BreathStanceTotalCost > 0)
		{
			ReduceEffectCount();
			if (base.EffectCount <= 0)
			{
				InvalidateCache(context, 204);
				DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 204)
		{
			return 0;
		}
		if (dataKey.IsNormalAttack || !CombatSkillEquipType.IsAttack(dataKey.CombatSkillId))
		{
			return 0;
		}
		int value = 0;
		if (base.Affected && dataKey.CombatSkillId == base.SkillTemplateId)
		{
			value += SelfReduceBreathStance;
		}
		if (base.EffectCount > 0)
		{
			value += -30;
		}
		return value;
	}
}
