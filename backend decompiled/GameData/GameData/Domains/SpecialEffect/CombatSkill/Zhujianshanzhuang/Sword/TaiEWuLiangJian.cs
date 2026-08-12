using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Sword;

public class TaiEWuLiangJian : SwordUnlockEffectBase
{
	private const int EffectAddAttackRange = 20;

	private int SelfAddAttackRange => base.IsDirectOrReverseEffectDoubling ? 40 : 20;

	protected override IEnumerable<sbyte> RequirePersonalityTypes
	{
		get
		{
			yield return 2;
			yield return 3;
			yield return 0;
			yield return 1;
			yield return 4;
		}
	}

	protected override int RequirePersonalityValue => 30;

	public TaiEWuLiangJian()
	{
	}

	public TaiEWuLiangJian(CombatSkillKey skillKey)
		: base(skillKey, 9105)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(145, EDataModifyType.Add, base.SkillTemplateId);
		CreateAffectedData(146, EDataModifyType.Add, base.SkillTemplateId);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	protected override void OnAffectedChanged(DataContext context)
	{
		base.OnAffectedChanged(context);
		InvalidAllCaches(context);
		if (base.Affected)
		{
			ShowSpecialEffectTips(base.IsDirect, 1, 0);
		}
	}

	protected override void OnAddedEffectCount(DataContext context)
	{
		base.OnAddedEffectCount(context);
		InvalidAllCaches(context);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && CombatSkillEquipType.IsAttack(skillId) && base.EffectCount > 0)
		{
			ReduceEffectCount();
			if (base.EffectCount == 0)
			{
				InvalidAllCaches(context);
			}
		}
	}

	private void InvalidAllCaches(DataContext context)
	{
		InvalidateCache(context, 145);
		InvalidateCache(context, 146);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		bool flag = dataKey.CharId != base.CharacterId || dataKey.IsNormalAttack;
		bool flag2 = flag;
		if (!flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = (uint)(fieldId - 145) <= 1u;
			flag2 = !flag3;
		}
		if (flag2)
		{
			return 0;
		}
		int addRange = 0;
		if (dataKey.CombatSkillId == base.SkillTemplateId && base.Affected)
		{
			addRange += SelfAddAttackRange;
		}
		if (base.EffectCount > 0)
		{
			addRange += 20;
		}
		return addRange;
	}
}
