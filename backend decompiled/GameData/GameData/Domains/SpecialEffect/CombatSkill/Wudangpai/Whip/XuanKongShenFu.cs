using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Whip;

public class XuanKongShenFu : CombatSkillEffectBase
{
	private const sbyte AffectSkillCount = 3;

	private const int AddPowerPercent = 500;

	private const int ChangeDisorderOfQiUnit = 10;

	private int _addPower;

	public XuanKongShenFu()
	{
	}

	public XuanKongShenFu(CombatSkillKey skillKey)
		: base(skillKey, 4307, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		DoAffect(context);
		CreateAffectedData(199, EDataModifyType.Add, -1);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void DoAffect(DataContext context)
	{
		int removePowerCharId = (base.IsDirect ? base.CharacterId : base.CurrEnemyChar.GetId());
		List<CombatSkillKey> pool = ObjectPool<List<CombatSkillKey>>.Instance.Get();
		Dictionary<CombatSkillKey, SkillPowerChangeCollection> powerDict = (base.IsDirect ? DomainManager.Combat.GetAllSkillPowerReduceInCombat() : DomainManager.Combat.GetAllSkillPowerAddInCombat());
		pool.Clear();
		foreach (CombatSkillKey skillKey in powerDict.Keys)
		{
			if (skillKey.CharId == removePowerCharId)
			{
				pool.Add(skillKey);
			}
		}
		if (pool.Count > 0)
		{
			DoAffectImplement(context, pool);
		}
		ObjectPool<List<CombatSkillKey>>.Instance.Return(pool);
	}

	private void DoAffectImplement(DataContext context, List<CombatSkillKey> pool)
	{
		int removeCount = Math.Min(3, pool.Count);
		int reducePower = 0;
		for (int i = 0; i < removeCount; i++)
		{
			int index = context.Random.Next(0, pool.Count);
			SkillPowerChangeCollection removedCollection = (base.IsDirect ? DomainManager.Combat.RemoveSkillPowerReduceInCombat(context, pool[index]) : DomainManager.Combat.RemoveSkillPowerAddInCombat(context, pool[index]));
			pool.RemoveAt(index);
			if (removedCollection != null)
			{
				reducePower += Math.Abs(removedCollection.GetTotalChangeValue());
			}
		}
		_addPower = reducePower * 500 / 100;
		int changeDisorderOfQi = 10 * reducePower;
		if (changeDisorderOfQi > 0)
		{
			if (base.IsDirect)
			{
				DomainManager.Combat.ChangeDisorderOfQiRandomRecovery(context, base.CombatChar, -changeDisorderOfQi);
			}
			else
			{
				DomainManager.Combat.ChangeDisorderOfQiRandomRecovery(context, base.CurrEnemyChar, changeDisorderOfQi);
			}
		}
		if (!base.IsDirect)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CurrEnemyChar.GetId(), 199);
		}
		if (reducePower > 0)
		{
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.SkillKey == SkillKey && dataKey.FieldId == 199)
		{
			return _addPower;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
