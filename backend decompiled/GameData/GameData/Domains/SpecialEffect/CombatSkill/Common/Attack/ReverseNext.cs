using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class ReverseNext : CombatSkillEffectBase
{
	private const sbyte AddPower = 40;

	protected sbyte AffectSectId;

	protected sbyte AffectSkillType;

	private readonly List<short> _reversedSkillList = new List<short>();

	protected ReverseNext()
	{
	}

	protected ReverseNext(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(209, EDataModifyType.Custom, -1);
		CreateAffectedData(199, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_PrepareSkillEffectNotYetCreated(OnPrepareSkillEffectNotYetCreated);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_CastSkillAllEnd(OnCastSkillAllEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillEffectNotYetCreated(OnPrepareSkillEffectNotYetCreated);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_CastSkillAllEnd(OnCastSkillAllEnd);
	}

	private void OnPrepareSkillEffectNotYetCreated(DataContext context, CombatCharacter combatChar, short skillId)
	{
		if (combatChar.GetId() != base.CharacterId || base.CombatChar.GetAutoCastingSkill() || base.EffectCount <= 0)
		{
			return;
		}
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillId];
		if (skillConfig.SectId != AffectSectId || skillConfig.Type != AffectSkillType)
		{
			return;
		}
		CombatSkillKey skillKey = new CombatSkillKey(base.CharacterId, skillId);
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey);
		sbyte direction = skill.GetDirection();
		if (direction == (base.IsDirect ? 1 : 0) && !_reversedSkillList.Contains(skillId))
		{
			_reversedSkillList.Add(skillId);
			ReduceEffectCount();
			ShowSpecialEffectTips(0);
			InvalidateCache(context, 209);
			short effectTemplateId = (short)((direction == 0) ? skillConfig.DirectEffectID : skillConfig.ReverseEffectID);
			SpecialEffectItem effectConfig = Config.SpecialEffect.Instance[effectTemplateId];
			if (effectConfig.EffectActiveType == 1)
			{
				CombatSkillEffectBase skillEffect = (CombatSkillEffectBase)DomainManager.SpecialEffect.Get(skill.GetSpecialEffectId());
				skillEffect.SetIsDirect(context, base.IsDirect);
				DomainManager.Combat.ChangeSkillEffectDirection(context, base.CombatChar, new SkillEffectKey(skillId, !base.IsDirect), base.IsDirect);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power))
		{
			AddMaxEffectCount();
		}
	}

	private void OnCastSkillAllEnd(DataContext context, int charId, short skillId)
	{
		if (charId != base.CharacterId || !_reversedSkillList.Contains(skillId))
		{
			return;
		}
		_reversedSkillList.Remove(skillId);
		InvalidateCache(context, 209);
		CombatSkillKey skillKey = new CombatSkillKey(base.CharacterId, skillId);
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[skillId];
		GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey);
		short effectTemplateId = (short)((skill.GetDirection() == 0) ? skillConfig.DirectEffectID : skillConfig.ReverseEffectID);
		SpecialEffectItem effectConfig = Config.SpecialEffect.Instance[effectTemplateId];
		if (effectConfig.EffectActiveType == 1)
		{
			CombatSkillEffectBase skillEffect = (CombatSkillEffectBase)DomainManager.SpecialEffect.Get(skill.GetSpecialEffectId());
			if (skillEffect != null)
			{
				skillEffect.SetIsDirect(context, !base.IsDirect);
				DomainManager.Combat.ChangeSkillEffectDirection(context, base.CombatChar, new SkillEffectKey(skillId, base.IsDirect), !base.IsDirect);
			}
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !_reversedSkillList.Contains(dataKey.CombatSkillId))
		{
			return dataValue;
		}
		if (dataKey.FieldId == 209)
		{
			return (!base.IsDirect) ? 1 : 0;
		}
		return dataValue;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !_reversedSkillList.Contains(dataKey.CombatSkillId))
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return 40;
		}
		return 0;
	}
}
