using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.ShuFang;

public class KunLunShiErJinXianLing : CombatSkillEffectBase
{
	private const sbyte ReduceEffectRequireMarkCount = 3;

	public KunLunShiErJinXianLing()
	{
	}

	public KunLunShiErJinXianLing(CombatSkillKey skillKey)
		: base(skillKey, 17080, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AddMaxEffectCount();
		ShowSpecialEffectTips(0);
		CreateAffectedData(324, EDataModifyType.Custom, -1);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		if (base.CombatChar.BossConfig != null)
		{
			Events.RegisterHandler_AddMindDamage(OnAddMindDamageValue);
		}
		else
		{
			Events.RegisterHandler_AddDirectInjury(OnAddDirectInjury);
		}
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		if (base.CombatChar.BossConfig != null)
		{
			Events.UnRegisterHandler_AddMindDamage(OnAddMindDamageValue);
		}
		else
		{
			Events.UnRegisterHandler_AddDirectInjury(OnAddDirectInjury);
		}
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (!IsSrcSkillPerformed)
			{
				IsSrcSkillPerformed = true;
			}
			else
			{
				RemoveSelf(context);
			}
		}
	}

	private void OnAddMindDamageValue(DataContext context, int attackerId, int defenderId, int damageValue, int markCount, short combatSkillId)
	{
		if (defenderId == base.CharacterId && markCount >= 3)
		{
			ReduceEffectCount();
		}
	}

	private void OnAddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		if (defenderId == base.CharacterId && (outerMarkCount >= 3 || innerMarkCount >= 3))
		{
			ReduceEffectCount();
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 324 && dataKey.CustomParam2 == 1)
		{
			return false;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
