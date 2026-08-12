using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.LongYuFu;

public class HuoRuiShaJiaoFeng : CombatSkillEffectBase
{
	private const sbyte RequireInjury = 4;

	private (int breath, int stance) _costBreathStance;

	public HuoRuiShaJiaoFeng()
	{
	}

	public HuoRuiShaJiaoFeng(CombatSkillKey skillKey)
		: base(skillKey, 17123, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		int[] enemyList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 219, base.SkillTemplateId), EDataModifyType.Custom);
		for (int i = 0; i < enemyList.Length; i++)
		{
			if (enemyList[i] >= 0)
			{
				AffectDatas.Add(new AffectedDataKey(enemyList[i], 169, -1), EDataModifyType.Custom);
			}
		}
		Events.RegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCostBreathAndStance(DataContext context, int charId, bool isAlly, int costBreath, int costStance, short skillId)
	{
		if (base.CharacterId == charId && skillId == base.SkillTemplateId)
		{
			_costBreathStance.breath = costBreath;
			_costBreathStance.stance = costStance;
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			DomainManager.Combat.UpdateSkillCanUse(context, DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly));
			Injuries injuries = base.CombatChar.GetInjuries();
			if (injuries.Get(3, isInnerInjury: false) >= 4 || injuries.Get(4, isInnerInjury: false) >= 4)
			{
				DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress);
				ChangeBreathValue(context, base.CombatChar, _costBreathStance.breath);
				ChangeStanceValue(context, base.CombatChar, _costBreathStance.stance);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			DomainManager.Combat.UpdateSkillCanUse(context, DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly));
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.FieldId == 219)
		{
			return true;
		}
		if (dataKey.FieldId == 169 && !dataValue && (dataKey.CustomParam0 == 3 || dataKey.CustomParam0 == 4) && (base.CombatChar.GetPreparingSkillId() == base.SkillTemplateId || base.CombatChar.GetPerformingSkillId() == base.SkillTemplateId))
		{
			return true;
		}
		return dataValue;
	}
}
