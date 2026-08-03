using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.DefenseAndAssist;

public class ShiErJingDaNuoYi : DefenseSkillBase
{
	private const int HealAcupointSpeedAddPercent = 200;

	public ShiErJingDaNuoYi()
	{
	}

	public ShiErJingDaNuoYi(CombatSkillKey skillKey)
		: base(skillKey, 3505)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(134, EDataModifyType.Custom, -1);
		CreateAffectedData(299, EDataModifyType.AddPercent, -1);
		ShowSpecialEffectTips(1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 299 || !base.CanAffect)
		{
			return 0;
		}
		return 200;
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataValue <= 0 || !base.CanAffect)
		{
			return dataValue;
		}
		DataContext context = DomainManager.Combat.Context;
		sbyte bodyPart = (sbyte)dataKey.CustomParam0;
		CombatCharacter affectChar = (base.IsDirect ? base.CombatChar : base.CurrEnemyChar);
		byte[] acupointCount = affectChar.GetAcupointCount();
		if (bodyPart < 0)
		{
			List<sbyte> partRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
			partRandomPool.Clear();
			for (sbyte part = 0; part < 7; part++)
			{
				if (!base.IsDirect || acupointCount[part] > 0)
				{
					partRandomPool.Add(part);
				}
			}
			if (partRandomPool.Count > 0)
			{
				bodyPart = partRandomPool[context.Random.Next(partRandomPool.Count)];
			}
			ObjectPool<List<sbyte>>.Instance.Return(partRandomPool);
		}
		if (bodyPart < 0)
		{
			return 0;
		}
		if (base.IsDirect)
		{
			if (acupointCount[bodyPart] > 0)
			{
				DomainManager.Combat.RemoveAcupoint(context, affectChar, bodyPart, 0, raiseEvent: false);
				ShowSpecialEffectTips(0);
			}
		}
		else
		{
			DomainManager.Combat.AddAcupoint(context, affectChar, (sbyte)dataKey.CustomParam1, new CombatSkillKey(-1, -1), bodyPart, 1, raiseEvent: false);
			ShowSpecialEffectTips(0);
		}
		return 0;
	}
}
