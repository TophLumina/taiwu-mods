using System.Collections.Generic;
using System.Linq;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;
using GameData.Domains.Story.MainStory;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.TwelveImmortals;

public class MoTianPoJin : TwelveImmortalsBase
{
	private int _extraAttackPartCount;

	private static bool DirectPredicate(GameData.Domains.Character.Character character)
	{
		return character.GetFeatureIds().Contains(861);
	}

	public MoTianPoJin()
	{
	}

	public MoTianPoJin(CombatSkillKey skillKey)
		: base(skillKey, 18005)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_extraAttackPartCount = base.TwelveImmortalsConfig.GetImpactRangeCharacters(CharObj).Count(DirectPredicate);
		CreateAffectedData(235, EDataModifyType.Custom, -1);
		Events.RegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.RegisterHandler_CombatCostNeiliConfirm(OnCombatCostNeiliConfirm);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.UnRegisterHandler_CombatCostNeiliConfirm(OnCombatCostNeiliConfirm);
		base.OnDisable(context);
	}

	private void OnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (attackerId != base.CharacterId || damageValue <= 0 || !base.IsDirect || _extraAttackPartCount <= 0)
		{
			return;
		}
		List<sbyte> pool = ObjectPool<List<sbyte>>.Instance.Get();
		for (sbyte i = 0; i < 7; i++)
		{
			if (i != bodyPart)
			{
				pool.Add(i);
			}
		}
		foreach (sbyte otherSidePart in RandomUtils.GetRandomUnrepeated(context.Random, _extraAttackPartCount, pool))
		{
			DomainManager.Combat.AddInjuryDamageValue(base.CombatChar, base.CurrEnemyChar, otherSidePart, (!isInner) ? damageValue : 0, isInner ? damageValue : 0, combatSkillId);
		}
		if (pool.Count > 0)
		{
			ShowSpecialEffectTips(0);
		}
		ObjectPool<List<sbyte>>.Instance.Return(pool);
	}

	private void OnCombatCostNeiliConfirm(DataContext context, int charId, short skillId, short effectId)
	{
		short defendSkillId = base.EnemyChar.GetAffectingDefendSkillId();
		if (charId == base.CharacterId && effectId == base.EffectId && defendSkillId >= 0)
		{
			CastBoostEffectDisplayData data = SkillKey.GetCostClearDefendData(skillId);
			CharObj.DirectlyChangeDisorderOfQi(context, data.AddQiDisorder);
			ShowSpecialEffectTips(0);
			if (DomainManager.Combat.ClearAffectingDefenseSkill(context, base.EnemyChar))
			{
				DomainManager.Combat.AddGoneMadInjury(context, base.EnemyChar, defendSkillId);
				ShowSpecialEffectTips(1);
			}
		}
	}

	public override List<CastBoostEffectDisplayData> GetModifiedValue(AffectedDataKey dataKey, List<CastBoostEffectDisplayData> dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 235 || dataKey.IsNormalAttack || base.IsDirect)
		{
			return dataValue;
		}
		dataValue.Add(SkillKey.GetCostClearDefendData(dataKey.CombatSkillId));
		return dataValue;
	}
}
