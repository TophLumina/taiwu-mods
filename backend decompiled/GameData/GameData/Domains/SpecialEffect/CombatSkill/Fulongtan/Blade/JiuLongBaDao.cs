using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Blade;

public class JiuLongBaDao : CombatSkillEffectBase
{
	private const sbyte MaxTransferCount = 9;

	private const int SilenceFrame = 3000;

	private const int TransferPowerRatio = 2;

	private int _addedPower;

	public JiuLongBaDao()
	{
	}

	public JiuLongBaDao(CombatSkillKey skillKey)
		: base(skillKey, 14207, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.Add);
		ChangePower(context);
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
			DomainManager.Combat.SilenceSkill(context, base.CombatChar, base.SkillTemplateId, 3000, -1);
			ShowSpecialEffectTips(1);
			RemoveSelf(context);
		}
	}

	private void ChangePower(DataContext context)
	{
		CombatCharacter enemyChar = base.CurrEnemyChar;
		Dictionary<CombatSkillKey, SkillPowerChangeCollection> powerDict = (base.IsDirect ? DomainManager.Combat.GetAllSkillPowerAddInCombat() : DomainManager.Combat.GetAllSkillPowerReduceInCombat());
		List<CombatSkillKey> preferredRandomPool = ObjectPool<List<CombatSkillKey>>.Instance.Get();
		List<CombatSkillKey> normalRandomPool = ObjectPool<List<CombatSkillKey>>.Instance.Get();
		int preferredCharId = (base.IsDirect ? enemyChar.GetId() : base.CombatChar.GetId());
		foreach (CombatSkillKey skillKey in powerDict.Keys)
		{
			if (skillKey.CharId == preferredCharId)
			{
				preferredRandomPool.Add(skillKey);
			}
			else
			{
				normalRandomPool.Add(skillKey);
			}
		}
		if (preferredRandomPool.Count > 0 || normalRandomPool.Count > 0)
		{
			foreach (CombatSkillKey skillKey2 in RandomUtils.GetRandomUnrepeated(context.Random, 9, preferredRandomPool, normalRandomPool))
			{
				SkillPowerChangeCollection powerChangeCollection = (base.IsDirect ? DomainManager.Combat.RemoveSkillPowerAddInCombat(context, skillKey2) : DomainManager.Combat.RemoveSkillPowerReduceInCombat(context, skillKey2));
				if (powerChangeCollection == null)
				{
					continue;
				}
				foreach (int powerChangeValue in powerChangeCollection.EffectDict.Values)
				{
					_addedPower += Math.Abs(powerChangeValue) * 2;
				}
			}
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			ShowSpecialEffectTips(0);
		}
		ObjectPool<List<CombatSkillKey>>.Instance.Return(preferredRandomPool);
		ObjectPool<List<CombatSkillKey>>.Instance.Return(normalRandomPool);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!dataKey.IsMatch(SkillKey) || dataKey.FieldId != 199)
		{
			return 0;
		}
		return _addedPower;
	}
}
