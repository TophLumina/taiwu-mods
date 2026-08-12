using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.FistAndPalm;

public class HuaLongZhang : CombatSkillEffectBase
{
	private bool _changedSkill;

	private static CValuePercent AddPowerPercent => 10;

	public HuaLongZhang()
	{
	}

	public HuaLongZhang(CombatSkillKey skillKey)
		: base(skillKey, 14108, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 156, -1), EDataModifyType.Custom);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power))
		{
			if (!_changedSkill)
			{
				AddMaxEffectCount();
			}
			else
			{
				CombatCharacter enemyChar = base.CurrEnemyChar;
				DomainManager.Combat.ClearAffectingDefenseSkill(context, enemyChar);
				ClearAffectingAgileSkill(context, enemyChar);
				ChangeMobilityValue(context, enemyChar, -enemyChar.GetMobilityValue());
				ShowSpecialEffectTips(1);
			}
		}
		_changedSkill = false;
		DomainManager.Combat.RemoveSkillPowerReplaceInCombat(context, SkillKey);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || base.EffectCount == 0 || dataValue == base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 156)
		{
			DataContext context = DomainManager.Combat.Context;
			CombatSkillKey powerSkillKey = new CombatSkillKey(base.CharacterId, (short)dataValue);
			GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(powerSkillKey);
			if (DomainManager.CombatSkill.GetSkillType(base.CharacterId, (short)dataValue) == 3 && skill.GetDirection() == base.SkillInstance.GetDirection())
			{
				_changedSkill = true;
				int addPower = base.SkillInstance.GetPower() * AddPowerPercent;
				DomainManager.Combat.AddSkillPowerInCombat(context, powerSkillKey, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), addPower);
				DomainManager.Combat.SetSkillPowerReplaceInCombat(context, SkillKey, powerSkillKey);
				ShowSpecialEffectTips(0);
				ReduceEffectCount();
				return base.SkillTemplateId;
			}
		}
		return dataValue;
	}
}
