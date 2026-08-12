using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.ShuFang;

public class MoTongShu : CombatSkillEffectBase
{
	private const sbyte AffectSkillCount = 4;

	private const sbyte ReducePower = -30;

	public MoTongShu()
	{
	}

	public MoTongShu(CombatSkillKey skillKey)
		: base(skillKey, 17084, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		SkillEffectKey effectKey = new SkillEffectKey(base.SkillTemplateId, base.IsDirect);
		List<short> skillRandomPool = ObjectPool<List<short>>.Instance.Get();
		skillRandomPool.Clear();
		for (sbyte equipType = 1; equipType <= 4; equipType++)
		{
			skillRandomPool.AddRange(enemyChar.GetCombatSkillList(equipType));
		}
		skillRandomPool.RemoveAll((short id) => id < 0);
		int affectCount = Math.Min(4, skillRandomPool.Count);
		for (int i = 0; i < affectCount; i++)
		{
			int index = context.Random.Next(skillRandomPool.Count);
			DomainManager.Combat.ReduceSkillPowerInCombat(context, new CombatSkillKey(enemyChar.GetId(), skillRandomPool[index]), effectKey, -30);
			skillRandomPool.RemoveAt(index);
		}
		ObjectPool<List<short>>.Instance.Return(skillRandomPool);
		ShowSpecialEffectTips(0);
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
