using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Leg;

public class DaoDaChongTianZi : CombatSkillEffectBase
{
	private bool _canAffect;

	private bool _disableSkills;

	public DaoDaChongTianZi()
	{
	}

	public DaoDaChongTianZi(CombatSkillKey skillKey)
		: base(skillKey, 10300, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		_canAffect = !enemyChar.AiController.Memory.EnemyRecordDict[base.CharacterId].SkillRecord.ContainsKey(base.SkillTemplateId);
		CreateAffectedAllEnemyData(286, EDataModifyType.Custom, -1);
		CreateAffectedAllEnemyData(284, EDataModifyType.Custom, -1);
		if (_canAffect)
		{
			int[] charList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
			for (int i = 0; i < charList.Length; i++)
			{
				if (charList[i] >= 0)
				{
					DomainManager.Combat.GetElement_CombatCharacterDict(charList[i]).AiController.AllowDefense = false;
				}
			}
			Events.RegisterHandler_CompareDataCalcFinished(OnCompareDataCalcFinished);
			Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
			ShowSpecialEffectTips(0);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		if (_canAffect)
		{
			Events.UnRegisterHandler_CompareDataCalcFinished(OnCompareDataCalcFinished);
			Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		}
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCompareDataCalcFinished(CombatContext context, DamageCompareData compareData)
	{
		if (context.Attacker == base.CombatChar && context.SkillTemplateId == base.SkillTemplateId)
		{
			if (base.IsDirect)
			{
				compareData.OuterDefendValue /= 2;
			}
			else
			{
				compareData.InnerDefendValue /= 2;
			}
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker == base.CombatChar && skillId == base.SkillTemplateId)
		{
			_disableSkills = true;
			InvalidateCache(context, base.CurrEnemyChar.GetId(), 286);
			InvalidateCache(context, base.CurrEnemyChar.GetId(), 284);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (_canAffect)
		{
			int[] charList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
			for (int i = 0; i < charList.Length; i++)
			{
				if (charList[i] >= 0)
				{
					DomainManager.Combat.GetElement_CombatCharacterDict(charList[i]).AiController.AllowDefense = true;
				}
			}
			if (PowerMatchAffectRequire(power))
			{
				AddPowerDamageFatal(context, base.CurrEnemyChar);
			}
			_disableSkills = false;
		}
		RemoveSelf(context);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		ushort fieldId = dataKey.FieldId;
		if ((fieldId != 284 && fieldId != 286) || 1 == 0)
		{
			return dataValue;
		}
		return dataValue && !_disableSkills;
	}
}
