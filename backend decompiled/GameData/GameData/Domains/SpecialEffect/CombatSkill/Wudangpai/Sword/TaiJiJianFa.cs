using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Sword;

public class TaiJiJianFa : CombatSkillEffectBase
{
	private const sbyte ReduceHitOdds = -80;

	public TaiJiJianFa()
	{
	}

	public TaiJiJianFa(CombatSkillKey skillKey)
		: base(skillKey, 4206, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (!IsSrcSkillPerformed)
		{
			if (PowerMatchAffectRequire(power))
			{
				IsSrcSkillPerformed = true;
				AppendAffectedData(context, base.CharacterId, 107, EDataModifyType.TotalPercent, -1);
				AddMaxEffectCount();
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (IsSrcSkillPerformed && defender == base.CombatChar && pursueIndex <= 0 && attacker.NormalAttackHitType != 3)
		{
			if (!hit)
			{
				DomainManager.Combat.AddCombatState(context, base.CurrEnemyChar, 2, (short)(base.IsDirect ? 22 : 23));
				ShowSpecialEffectTips(0);
			}
			ReduceEffectCount();
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!IsSrcSkillPerformed || dataKey.CharId != base.CharacterId || dataKey.CombatSkillId >= 0)
		{
			return 0;
		}
		if (dataKey.FieldId == 107)
		{
			return -80;
		}
		return 0;
	}
}
