using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Whip;

public class CuoDaoYinYangFuChen : CombatSkillEffectBase
{
	private const int SilenceFrame = 180;

	public CuoDaoYinYangFuChen()
	{
	}

	public CuoDaoYinYangFuChen(CombatSkillKey skillKey)
		: base(skillKey, 4304, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedAllEnemyData(285, EDataModifyType.Custom, -1);
		ShowSpecialEffectTips(0);
		Events.RegisterHandler_CompareDataCalcFinished(OnCompareDataCalcFinished);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CompareDataCalcFinished(OnCompareDataCalcFinished);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCompareDataCalcFinished(CombatContext context, DamageCompareData compareData)
	{
		if (context.Attacker == base.CombatChar && context.SkillTemplateId == base.SkillTemplateId)
		{
			if (base.IsDirect)
			{
				compareData.OuterDefendValue = compareData.InnerDefendValue;
			}
			else
			{
				compareData.InnerDefendValue = compareData.OuterDefendValue;
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		foreach (short banableSkillId in base.CurrEnemyChar.GetBanableSkillIds(4, -1))
		{
			GameData.Domains.CombatSkill.CombatSkill skill = DomainManager.CombatSkill.GetElement_CombatSkills((charId: base.CurrEnemyChar.GetId(), skillId: banableSkillId));
			if ((int)skill.GetDirection() == ((!base.IsDirect) ? 1 : 0))
			{
				DomainManager.Combat.SilenceSkill(context, base.CurrEnemyChar, banableSkillId, 180);
				ShowSpecialEffectTipsOnceInFrame(1);
			}
		}
		RemoveSelf(context);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.FieldId != 285)
		{
			return dataValue;
		}
		if (!DomainManager.CombatSkill.TryGetElement_CombatSkills(dataKey.SkillKey, out var skill))
		{
			return dataValue;
		}
		if ((int)skill.GetDirection() != ((!base.IsDirect) ? 1 : 0))
		{
			return dataValue;
		}
		return false;
	}
}
