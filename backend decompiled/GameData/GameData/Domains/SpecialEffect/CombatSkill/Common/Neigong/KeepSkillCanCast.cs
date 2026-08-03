using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

public class KeepSkillCanCast : CombatSkillEffectBase
{
	private const sbyte ReduceInterruptSilenceOdds = -60;

	private const sbyte BrokenCastReducePower = -20;

	private const sbyte DirectReduceFatalDamagePercent = 80;

	private const int AddGoneMadFactor = -50;

	protected sbyte RequireFiveElementsType;

	private short _affectingPowerSkillId;

	private sbyte CurrNeiliFiveElementsType => (sbyte)NeiliType.Instance[CharObj.GetNeiliType()].FiveElements;

	protected KeepSkillCanCast()
	{
	}

	protected KeepSkillCanCast(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		if (base.IsDirect)
		{
			CreateAffectedData(216, EDataModifyType.Add, -1);
			CreateAffectedData(218, EDataModifyType.TotalPercent, -1);
			CreateAffectedData(191, EDataModifyType.Custom, -1);
		}
		else
		{
			CreateAffectedData(219, EDataModifyType.Custom, -1);
			CreateAffectedData(199, EDataModifyType.AddPercent, -1);
		}
		if (!base.IsDirect)
		{
			Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
			Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		}
	}

	public override void OnDisable(DataContext context)
	{
		if (!base.IsDirect)
		{
			Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
			Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		}
	}

	private bool MatchRelatedFiveElementsType(short skillId)
	{
		return MatchRelatedFiveElementsType(base.EnemyChar.GetId(), skillId);
	}

	private bool MatchRelatedFiveElementsType(int charId, short skillId)
	{
		if (RequireFiveElementsType == 5)
		{
			return FiveElementsEquals(charId, skillId, RequireFiveElementsType);
		}
		return FiveElementsEquals(charId, skillId, RequireFiveElementsType) || FiveElementsEquals(charId, skillId, FiveElementsType.Countering[RequireFiveElementsType]) || FiveElementsEquals(charId, skillId, FiveElementsType.Produced[RequireFiveElementsType]);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (base.CharacterId == charId && CurrNeiliFiveElementsType == RequireFiveElementsType && !DomainManager.Combat.HasSkillNeedBodyPart(base.CombatChar, skillId, applyEffect: false))
		{
			_affectingPowerSkillId = skillId;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupt)
	{
		if (DomainManager.Combat.GetCombatCharacter(!isAlly, tryGetCoverCharacter: true) == base.CombatChar && !interrupt)
		{
			DoAffect(context, charId, skillId, power);
		}
		if (base.CharacterId == charId)
		{
			_affectingPowerSkillId = -1;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	private void DoAffect(DataContext context, int charId, short skillId, sbyte power)
	{
		if (MatchRelatedFiveElementsType(charId, skillId) && !PowerMatchAffectRequire(power) && CombatSkillEquipType.IsAttack(skillId))
		{
			CombatCharacter attacker = DomainManager.Combat.GetElement_CombatCharacterDict(charId);
			DomainManager.Combat.AddGoneMadInjury(context, attacker, skillId, -50);
			ShowSpecialEffectTips(1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (CurrNeiliFiveElementsType != RequireFiveElementsType)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if ((fieldId == 216 || fieldId == 218) ? true : false)
		{
			return -60;
		}
		if (dataKey.FieldId == 199 && dataKey.CombatSkillId == _affectingPowerSkillId)
		{
			return -20;
		}
		return 0;
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId < 0)
		{
			return dataValue;
		}
		if (!MatchRelatedFiveElementsType(dataKey.CombatSkillId))
		{
			return dataValue;
		}
		if (dataKey.FieldId == 191)
		{
			EDamageType damageType = (EDamageType)dataKey.CustomParam1;
			if (damageType != EDamageType.Direct)
			{
				return dataValue;
			}
			ShowSpecialEffectTips(0);
			return dataValue - dataValue * 80 / 100;
		}
		return dataValue;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		if (CurrNeiliFiveElementsType != RequireFiveElementsType)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 219)
		{
			return true;
		}
		return dataValue;
	}
}
