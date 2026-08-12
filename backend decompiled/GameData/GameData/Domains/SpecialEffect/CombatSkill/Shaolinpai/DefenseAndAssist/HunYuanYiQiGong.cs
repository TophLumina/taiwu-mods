using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.DefenseAndAssist;

public class HunYuanYiQiGong : DefenseSkillBase
{
	private const sbyte AddBounceDamage = 100;

	private bool _canAffectCurrAttack;

	private bool _affected;

	public HunYuanYiQiGong()
	{
	}

	public HunYuanYiQiGong(CombatSkillKey skillKey)
		: base(skillKey, 1507)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		Events.RegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		if (base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 241, -1), EDataModifyType.Custom);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 131, -1), EDataModifyType.Custom);
			Events.RegisterHandler_CompareDataCalcFinished(OnCompareDataCalcFinished);
		}
		else
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 70, -1), EDataModifyType.AddPercent);
			Events.RegisterHandler_BounceInjury(OnBounceInjury);
		}
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		if (base.IsDirect)
		{
			Events.UnRegisterHandler_CompareDataCalcFinished(OnCompareDataCalcFinished);
		}
		else
		{
			Events.UnRegisterHandler_BounceInjury(OnBounceInjury);
		}
	}

	private void OnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		if (defender == base.CombatChar && attacker.NormalAttackBodyPart >= 0)
		{
			_canAffectCurrAttack = base.CombatChar.GetAcupointCount()[attacker.NormalAttackBodyPart] == 0;
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (defender == base.CombatChar && Config.CombatSkill.Instance[skillId].EquipType == 1 && attacker.SkillAttackBodyPart >= 0)
		{
			_canAffectCurrAttack = base.CombatChar.GetAcupointCount()[attacker.SkillAttackBodyPart] == 0;
		}
	}

	private void OnCompareDataCalcFinished(CombatContext context, DamageCompareData compareData)
	{
		if (base.CombatChar == context.Defender && base.CanAffect)
		{
			int transferValue = compareData.InnerDefendValue / 2;
			compareData.OuterDefendValue += transferValue;
			compareData.InnerDefendValue -= transferValue;
			ShowSpecialEffectTips(0);
		}
	}

	private void OnBounceInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount)
	{
		if (_affected)
		{
			_affected = false;
			ShowSpecialEffectTips(0);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !_canAffectCurrAttack || !base.CanAffect)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 131)
		{
			return false;
		}
		EDamageType damageType = (EDamageType)dataKey.CustomParam1;
		if (dataKey.FieldId == 241 && damageType == EDamageType.Direct)
		{
			ShowSpecialEffectTips(1);
			return true;
		}
		return dataValue;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !_canAffectCurrAttack || dataKey.CustomParam0 != 1 || !base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 70)
		{
			_affected = true;
			return 100;
		}
		return 0;
	}
}
