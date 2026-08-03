using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.LongYuFu;

public class HuoLongFenXin : CombatSkillEffectBase
{
	private const sbyte InjuryThreshold = 4;

	private const sbyte AffectSkillCount = 3;

	public HuoLongFenXin()
	{
	}

	public HuoLongFenXin(CombatSkillKey skillKey)
		: base(skillKey, 17122, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		if (base.CombatChar.GetInjuries().Get(2, isInnerInjury: false) < 4)
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			Dictionary<SkillEffectKey, short> effectDict = enemyChar.GetSkillEffectCollection().EffectDict;
			if (effectDict != null && effectDict.Count > 0)
			{
				List<SkillEffectKey> effectRandomPool = ObjectPool<List<SkillEffectKey>>.Instance.Get();
				int affectCount = Math.Min(3, effectDict.Count);
				effectRandomPool.Clear();
				effectRandomPool.AddRange(effectDict.Keys);
				for (int i = 0; i < affectCount; i++)
				{
					int index = context.Random.Next(effectRandomPool.Count);
					SkillEffectKey effectKey = effectRandomPool[index];
					effectRandomPool.RemoveAt(index);
					DomainManager.Combat.ChangeSkillEffectToMinCount(context, enemyChar, effectKey);
					DomainManager.Combat.AddGoneMadInjury(context, enemyChar, effectKey.SkillId);
				}
				ObjectPool<List<SkillEffectKey>>.Instance.Return(effectRandomPool);
				DomainManager.Combat.AddToCheckFallenSet(enemyChar.GetId());
				ShowSpecialEffectTips(0);
			}
			base.CombatChar.AddInjury(context, 2, isInner: false, 1, updateDefeatMark: true);
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
