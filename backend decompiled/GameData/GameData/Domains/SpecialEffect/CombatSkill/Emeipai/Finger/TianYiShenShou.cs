using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Finger;

public class TianYiShenShou : CombatSkillEffectBase
{
	private const int AddDamagePercentPerTrick = 10;

	private const sbyte MaxFlawOrAcupointLevel = 3;

	private const sbyte MinFlawOrAcupointLevel = 0;

	private const int FlawOrAcupointLevelAttenuation = 3;

	private const int InevitableHitRequireCount = 2;

	private const int CertainCriticalRequireCount = 4;

	private int _costedTrickCount;

	public TianYiShenShou()
	{
	}

	public TianYiShenShou(CombatSkillKey skillKey)
		: base(skillKey, 2208, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(69, EDataModifyType.AddPercent, base.SkillTemplateId);
		CreateAffectedData(251, EDataModifyType.Custom, base.SkillTemplateId);
		CreateAffectedData(248, EDataModifyType.Custom, base.SkillTemplateId);
		CreateAffectedData(322, EDataModifyType.Custom, base.SkillTemplateId);
		Events.RegisterHandler_CostTrickDuringPreparingSkill(OnCostTrickDuringPreparingSkill);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CostTrickDuringPreparingSkill(OnCostTrickDuringPreparingSkill);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker != base.CombatChar || !DomainManager.Combat.InAttackRange(attacker) || _costedTrickCount <= 0)
		{
			return;
		}
		for (int i = 0; i < _costedTrickCount; i++)
		{
			ShowSpecialEffectTipsOnceInFrame(1);
			sbyte level = (sbyte)Math.Max(3 - i / 3, 0);
			if (base.IsDirect)
			{
				DomainManager.Combat.AddFlaw(context, defender, level, SkillKey, -1);
			}
			else
			{
				DomainManager.Combat.AddAcupoint(context, defender, level, SkillKey, -1);
			}
		}
	}

	private void OnCostTrickDuringPreparingSkill(DataContext context, int charId)
	{
		if (charId == base.CharacterId)
		{
			_costedTrickCount++;
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool _)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			_costedTrickCount = 0;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.SkillKey == SkillKey && dataKey.FieldId == 69)
		{
			return _costedTrickCount * 10;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey != SkillKey)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		if (dataKey.FieldId == 251 && _costedTrickCount >= 2)
		{
			ShowSpecialEffectTipsOnceInFrame(2);
		}
		if (dataKey.FieldId == 248 && _costedTrickCount >= 4)
		{
			ShowSpecialEffectTipsOnceInFrame(3);
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		bool result = fieldId switch
		{
			251 => dataValue || _costedTrickCount >= 2, 
			248 => dataValue || _costedTrickCount >= 4, 
			322 => true, 
			_ => base.GetModifiedValue(dataKey, dataValue), 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
