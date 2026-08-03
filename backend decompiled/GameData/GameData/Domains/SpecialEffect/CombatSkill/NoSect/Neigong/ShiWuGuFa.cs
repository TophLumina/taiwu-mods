using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.Neigong;

public class ShiWuGuFa : CombatSkillEffectBase
{
	private short _castingBeGoneMadSkillId;

	private const int CostBreathAndStanceAddPercent = -50;

	private const int PrepareTotalProgressAddPercent = 25;

	private static bool IsAttack(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].EquipType == 1;
	}

	public ShiWuGuFa()
	{
	}

	public ShiWuGuFa(CombatSkillKey skillKey)
		: base(skillKey, 4, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(217, EDataModifyType.Custom, base.SkillTemplateId);
		CreateAffectedData(304, EDataModifyType.Custom, -1);
		CreateAffectedData(208, EDataModifyType.Custom, -1);
		CreateAffectedData(204, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(212, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_AttackSkillAttackHit(OnAttackSkillAttackHit);
		Events.RegisterHandler_CastSkillAllEnd(OnCastSkillAllEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_AttackSkillAttackHit(OnAttackSkillAttackHit);
		Events.UnRegisterHandler_CastSkillAllEnd(OnCastSkillAllEnd);
		base.OnDisable(context);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && IsAttack(skillId))
		{
			ShowSpecialEffectTips(0);
		}
	}

	private void OnAttackSkillAttackHit(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId, int index, bool critical)
	{
		if (defender.GetId() == base.CharacterId && skillId == defender.GetPreparingSkillId() && index == 3 && IsAttack(skillId))
		{
			DomainManager.Combat.AddGoneMadInjury(context, defender, base.SkillTemplateId);
			ShowSpecialEffectTips(1);
			_castingBeGoneMadSkillId = defender.GetPreparingSkillId();
		}
	}

	private void OnCastSkillAllEnd(DataContext context, int charId, short skillId)
	{
		if (charId == base.CharacterId)
		{
			_castingBeGoneMadSkillId = -1;
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey != SkillKey || dataKey.FieldId != 217)
		{
			return dataValue;
		}
		return false;
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 304)
		{
			return dataValue;
		}
		return (_castingBeGoneMadSkillId != dataKey.CombatSkillId) ? dataValue : 0;
	}

	public override List<NeedTrick> GetModifiedValue(AffectedDataKey dataKey, List<NeedTrick> dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		dataValue.Clear();
		return dataValue;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !IsAttack(dataKey.CombatSkillId))
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result = fieldId switch
		{
			204 => -50, 
			212 => 25, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
