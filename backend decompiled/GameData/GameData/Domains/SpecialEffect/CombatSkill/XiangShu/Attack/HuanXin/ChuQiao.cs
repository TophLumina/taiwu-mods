using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.HuanXin;

public class ChuQiao : CombatSkillEffectBase
{
	private const sbyte ChangeStateCount = 2;

	public ChuQiao()
	{
	}

	public ChuQiao(CombatSkillKey skillKey)
		: base(skillKey, 17101, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Dictionary<short, (short, bool, int)> stateDict = base.CombatChar.GetDebuffCombatStateCollection().StateDict;
		if (stateDict.Count > 0)
		{
			List<short> stateRandomPool = ObjectPool<List<short>>.Instance.Get();
			stateRandomPool.Clear();
			stateRandomPool.AddRange(stateDict.Keys);
			int changeCount = Math.Min(2, stateRandomPool.Count);
			for (int i = 0; i < changeCount; i++)
			{
				int index = context.Random.Next(0, stateRandomPool.Count);
				short key = stateRandomPool[index];
				stateRandomPool.RemoveAt(index);
				DomainManager.Combat.ReverseCombatState(context, base.CombatChar, 2, key);
			}
			ObjectPool<List<short>>.Instance.Return(stateRandomPool);
			if (changeCount > 0)
			{
				ShowSpecialEffectTips(0);
			}
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
