using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Finger;

public class FuYinZhi : CombatSkillEffectBase
{
	private sbyte AffectOdds = 60;

	private int _affectEnemyId;

	public FuYinZhi()
	{
	}

	public FuYinZhi(CombatSkillKey skillKey)
		: base(skillKey, 13103, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_AddInjury(OnAddInjury);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_AddInjury(OnAddInjury);
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
				_affectEnemyId = base.CurrEnemyChar.GetId();
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

	private void OnAddInjury(DataContext context, CombatCharacter character, sbyte bodyPart, bool isInner, int value, bool changeToOld)
	{
		if (character.GetId() != _affectEnemyId || isInner == base.IsDirect || changeToOld)
		{
			return;
		}
		int changeCount = 0;
		for (int i = 0; i < value; i++)
		{
			if (changeCount >= base.EffectCount)
			{
				break;
			}
			if (context.Random.CheckPercentProb(AffectOdds))
			{
				changeCount++;
			}
		}
		if (changeCount > 0)
		{
			character.ChangeToOldInjury(context, bodyPart, isInner, changeCount);
			ShowSpecialEffectTips(0);
			ReduceEffectCount(changeCount);
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}
}
