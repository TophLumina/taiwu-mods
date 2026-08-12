using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Whip;

public class WuDangTieFuChen : CombatSkillEffectBase
{
	private sbyte _affectBodyPart;

	public WuDangTieFuChen()
	{
	}

	public WuDangTieFuChen(CombatSkillKey skillKey)
		: base(skillKey, 4301, -1)
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
		FlawOrAcupointCollection acupointCollection = defender.GetAcupointCollection();
		List<sbyte> maxAcupointPartRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
		int maxAcupointLevelSum = 0;
		maxAcupointPartRandomPool.Clear();
		for (sbyte part = 0; part < 7; part++)
		{
			List<FlawOrAcupointEntry> acupointList = acupointCollection.BodyPartDict[part];
			int levelSum = 0;
			for (int i = 0; i < acupointList.Count; i++)
			{
				levelSum += acupointList[i].Level + 1;
			}
			if (levelSum != 0 && levelSum >= maxAcupointLevelSum)
			{
				if (levelSum > maxAcupointLevelSum)
				{
					maxAcupointPartRandomPool.Clear();
					maxAcupointLevelSum = levelSum;
				}
				maxAcupointPartRandomPool.Add(part);
			}
		}
		if (maxAcupointPartRandomPool.Count > 0)
		{
			_affectBodyPart = maxAcupointPartRandomPool[context.Random.Next(0, maxAcupointPartRandomPool.Count)];
			if (base.IsDirect)
			{
				attacker.SkillAttackBodyPart = _affectBodyPart;
			}
		}
		ObjectPool<List<sbyte>>.Instance.Return(maxAcupointPartRandomPool);
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (context.SkillKey != SkillKey || index != 3 || _affectBodyPart < 0 || context.Attacker.GetAttackSkillPower() == 0)
		{
			return;
		}
		if (base.IsDirect)
		{
			FlawOrAcupointCollection acupointCollection = context.Defender.GetAcupointCollection();
			List<FlawOrAcupointEntry> acupointList = acupointCollection.BodyPartDict[_affectBodyPart];
			for (int i = 0; i < acupointList.Count; i++)
			{
				FlawOrAcupointEntry acupoint = acupointList[i];
				acupoint.LeftFrame = acupoint.TotalFrame;
				acupointList[i] = acupoint;
			}
			context.Defender.SetAcupointCollection(acupointCollection, context);
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
