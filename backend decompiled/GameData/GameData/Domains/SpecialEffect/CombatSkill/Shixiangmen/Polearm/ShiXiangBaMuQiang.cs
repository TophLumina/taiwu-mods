using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Polearm;

public class ShiXiangBaMuQiang : CombatSkillEffectBase
{
	private const sbyte StatePowerChangePercent = 10;

	public ShiXiangBaMuQiang()
	{
	}

	public ShiXiangBaMuQiang(CombatSkillKey skillKey)
		: base(skillKey, 6302, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (power > 0)
		{
			sbyte stateType = (sbyte)(base.IsDirect ? 1 : 2);
			CombatStateCollection stateCollection = base.CombatChar.GetCombatStateCollection(stateType);
			if (stateCollection.StateDict.Count > 0)
			{
				List<short> randomPool = ObjectPool<List<short>>.Instance.Get();
				randomPool.Clear();
				randomPool.AddRange(stateCollection.StateDict.Keys);
				short stateId = randomPool[context.Random.Next(0, randomPool.Count)];
				int changePower = (int)Math.Ceiling((float)(stateCollection.StateDict[stateId].power * 10 * power) / 1000f);
				ObjectPool<List<short>>.Instance.Return(randomPool);
				if (changePower > 0)
				{
					DomainManager.Combat.AddCombatState(context, base.CombatChar, stateType, stateId, base.IsDirect ? changePower : (-changePower), reverse: false, applyEffect: false);
					ShowSpecialEffectTips(0);
				}
			}
		}
		RemoveSelf(context);
	}
}
