using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.HuanXin;

public class BiGuang : CombatSkillEffectBase
{
	private const sbyte ChangeStateCount = 2;

	private const short SilenceFrame = 600;

	public BiGuang()
	{
	}

	public BiGuang(CombatSkillKey skillKey)
		: base(skillKey, 17104, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		Dictionary<short, (short, bool, int)> selfStateDict = base.CombatChar.GetDebuffCombatStateCollection().StateDict;
		Dictionary<short, (short, bool, int)> enemyStateDict = enemyChar.GetBuffCombatStateCollection().StateDict;
		if (selfStateDict.Count > 0)
		{
			List<short> stateRandomPool = ObjectPool<List<short>>.Instance.Get();
			stateRandomPool.Clear();
			stateRandomPool.AddRange(selfStateDict.Keys);
			int changeCount = Math.Min(2, stateRandomPool.Count);
			for (int i = 0; i < changeCount; i++)
			{
				int index = context.Random.Next(0, stateRandomPool.Count);
				short key = stateRandomPool[index];
				stateRandomPool.RemoveAt(index);
				DomainManager.Combat.ReverseCombatState(context, base.CombatChar, 2, key);
			}
			ObjectPool<List<short>>.Instance.Return(stateRandomPool);
		}
		if (enemyStateDict.Count > 0)
		{
			List<short> stateRandomPool2 = ObjectPool<List<short>>.Instance.Get();
			stateRandomPool2.Clear();
			stateRandomPool2.AddRange(enemyStateDict.Keys);
			int changeCount2 = Math.Min(2, stateRandomPool2.Count);
			for (int j = 0; j < changeCount2; j++)
			{
				int index2 = context.Random.Next(0, stateRandomPool2.Count);
				short key2 = stateRandomPool2[index2];
				stateRandomPool2.RemoveAt(index2);
				DomainManager.Combat.ReverseCombatState(context, enemyChar, 1, key2);
			}
			ObjectPool<List<short>>.Instance.Return(stateRandomPool2);
		}
		if (selfStateDict.Count > 0 || enemyStateDict.Count > 0)
		{
			ShowSpecialEffectTips(0);
		}
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
		if (PowerMatchAffectRequire(power))
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			foreach (short banableSkillId in enemyChar.GetBanableSkillIds(3, -1))
			{
				DomainManager.Combat.SilenceSkill(context, enemyChar, banableSkillId, 600);
			}
			ShowSpecialEffectTips(1);
		}
		RemoveSelf(context);
	}
}
