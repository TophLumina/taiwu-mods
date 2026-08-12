using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.LongYuFu;

public class ChiNiZhengYi : CombatSkillEffectBase
{
	private const sbyte InjuryThreshold = 4;

	private const sbyte PowerCountPerInjury = 2;

	public ChiNiZhengYi()
	{
	}

	public ChiNiZhengYi(CombatSkillKey skillKey)
		: base(skillKey, 17121, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Injuries injuries = base.CombatChar.GetInjuries();
		int addedInjury = 0;
		if (injuries.Get(5, isInnerInjury: false) < 4)
		{
			base.CombatChar.AddInjury(context, 5, isInner: false, 1, updateDefeatMark: true);
			addedInjury++;
		}
		if (injuries.Get(6, isInnerInjury: false) < 4)
		{
			base.CombatChar.AddInjury(context, 6, isInner: false, 1, updateDefeatMark: true);
			addedInjury++;
		}
		if (addedInjury > 0)
		{
			int enemyCharId = base.CurrEnemyChar.GetId();
			Dictionary<CombatSkillKey, SkillPowerChangeCollection> powerDict = DomainManager.Combat.GetAllSkillPowerAddInCombat();
			List<CombatSkillKey> srcSkillRandomPool = ObjectPool<List<CombatSkillKey>>.Instance.Get();
			srcSkillRandomPool.Clear();
			foreach (CombatSkillKey skillKey in powerDict.Keys)
			{
				if (skillKey.CharId == enemyCharId)
				{
					srcSkillRandomPool.Add(skillKey);
				}
			}
			if (srcSkillRandomPool.Count > 0)
			{
				int transferCount = Math.Min(2 * addedInjury, srcSkillRandomPool.Count);
				for (int i = 0; i < transferCount; i++)
				{
					int index = context.Random.Next(0, srcSkillRandomPool.Count);
					CombatSkillKey srcKey = srcSkillRandomPool[index];
					SkillPowerChangeCollection powerAddCollection = DomainManager.Combat.RemoveSkillPowerAddInCombat(context, srcKey);
					srcSkillRandomPool.RemoveAt(index);
					if (powerAddCollection != null)
					{
						DomainManager.Combat.AddSkillPowerInCombat(context, SkillKey, new SkillEffectKey(base.SkillTemplateId, isDirect: true), powerAddCollection.GetTotalChangeValue());
					}
				}
				ShowSpecialEffectTips(0);
			}
			ObjectPool<List<CombatSkillKey>>.Instance.Return(srcSkillRandomPool);
			DomainManager.Combat.AddToCheckFallenSet(base.CombatChar.GetId());
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}
}
