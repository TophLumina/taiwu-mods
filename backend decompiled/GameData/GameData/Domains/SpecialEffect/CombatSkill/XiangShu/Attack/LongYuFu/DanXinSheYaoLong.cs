using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.LongYuFu;

public class DanXinSheYaoLong : CombatSkillEffectBase
{
	private const sbyte RequireInjury = 4;

	private const sbyte AffectSkillCount = 6;

	public DanXinSheYaoLong()
	{
	}

	public DanXinSheYaoLong(CombatSkillKey skillKey)
		: base(skillKey, 17125, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		int[] enemyList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 219, base.SkillTemplateId), EDataModifyType.Custom);
		for (int i = 0; i < enemyList.Length; i++)
		{
			if (enemyList[i] >= 0)
			{
				AffectDatas.Add(new AffectedDataKey(enemyList[i], 169, -1), EDataModifyType.Custom);
			}
		}
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		DomainManager.Combat.UpdateSkillCanUse(context, DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly));
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		Dictionary<SkillEffectKey, short> effectDict = enemyChar.GetSkillEffectCollection().EffectDict;
		if (base.CombatChar.GetInjuries().Get(2, isInnerInjury: false) >= 4 && effectDict != null && effectDict.Count > 0)
		{
			List<SkillEffectKey> effectRandomPool = ObjectPool<List<SkillEffectKey>>.Instance.Get();
			int affectCount = Math.Min(6, effectDict.Count);
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
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			DomainManager.Combat.UpdateSkillCanUse(context, DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly));
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.FieldId == 219)
		{
			return true;
		}
		if (dataKey.FieldId == 169 && !dataValue && dataKey.CustomParam0 == 2 && (base.CombatChar.GetPreparingSkillId() == base.SkillTemplateId || base.CombatChar.GetPerformingSkillId() == base.SkillTemplateId))
		{
			return true;
		}
		return dataValue;
	}
}
