using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class ReduceEnemyTrick : CombatSkillEffectBase
{
	protected sbyte AffectTrickType;

	protected ReduceEnemyTrick()
	{
	}

	protected ReduceEnemyTrick(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
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
				if (base.IsDirect)
				{
					CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly, tryGetCoverCharacter: true);
					if (DomainManager.Combat.IsCurrentCombatCharacter(enemyChar) && enemyChar.GetTrickCount(AffectTrickType) > 0 && DomainManager.Combat.StealTrick(context, base.CombatChar, enemyChar, AffectTrickType, 1))
					{
						ShowSpecialEffectTips(0);
					}
					RemoveSelf(context);
				}
				else
				{
					IsSrcSkillPerformed = true;
					AppendAffectedAllEnemyData(context, 138, EDataModifyType.Custom, -1);
					AddMaxEffectCount();
				}
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

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.FieldId == 138 && dataKey.CustomParam2 == 1)
		{
			DataContext context = DomainManager.Combat.Context;
			if (dataKey.CustomParam0 == AffectTrickType)
			{
				ShowSpecialEffectTips(0);
				ReduceEffectCount();
				return false;
			}
		}
		return dataValue;
	}
}
