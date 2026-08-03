using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Whip;

public class WuGongSuo : CombatSkillEffectBase
{
	private sbyte _affectBodyPart;

	public WuGongSuo()
	{
	}

	public WuGongSuo(CombatSkillKey skillKey)
		: base(skillKey, 12401, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_affectBodyPart = -1;
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker != base.CombatChar || skillId != base.SkillTemplateId)
		{
			return;
		}
		FlawOrAcupointCollection flawCollection = defender.GetFlawCollection();
		List<sbyte> maxFlawPartRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		int maxFlawLevelSum = 0;
		maxFlawPartRandomPool.Clear();
		for (sbyte part = 0; part < 7; part++)
		{
			List<FlawOrAcupointEntry> flawList = flawCollection.BodyPartDict[part];
			int levelSum = 0;
			for (int i = 0; i < flawList.Count; i++)
			{
				levelSum += flawList[i].Level + 1;
			}
			if (levelSum != 0 && levelSum >= maxFlawLevelSum)
			{
				if (levelSum > maxFlawLevelSum)
				{
					maxFlawPartRandomPool.Clear();
					maxFlawLevelSum = levelSum;
				}
				maxFlawPartRandomPool.Add(part);
			}
		}
		if (maxFlawPartRandomPool.Count > 0)
		{
			_affectBodyPart = maxFlawPartRandomPool[context.Random.Next(0, maxFlawPartRandomPool.Count)];
			if (base.IsDirect)
			{
				attacker.SkillAttackBodyPart = _affectBodyPart;
			}
		}
		ObjectPool<List<sbyte>>.Instance.Return(maxFlawPartRandomPool);
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (context.SkillKey != SkillKey || index != 3 || _affectBodyPart < 0 || context.Attacker.GetAttackSkillPower() == 0)
		{
			return;
		}
		if (base.IsDirect)
		{
			FlawOrAcupointCollection flawCollection = context.Defender.GetFlawCollection();
			List<FlawOrAcupointEntry> flawList = flawCollection.BodyPartDict[_affectBodyPart];
			for (int i = 0; i < flawList.Count; i++)
			{
				FlawOrAcupointEntry flaw = flawList[i];
				flaw.LeftFrame = flaw.TotalFrame;
				flawList[i] = flaw;
			}
			context.Defender.SetFlawCollection(flawCollection, context);
		}
		else
		{
			DomainManager.Combat.DoSkillHit(context.Attacker, context.Defender, base.SkillTemplateId, _affectBodyPart, hitType);
		}
		ShowSpecialEffectTips(0);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}
}
