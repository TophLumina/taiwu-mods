using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Defense;

public class DiZhaoXuanHuoYin : DefenseSkillBase
{
	private const sbyte AddDamagePercent = 15;

	private Injuries _injuriesBeforeAttacked;

	private bool _affected;

	public DiZhaoXuanHuoYin()
	{
	}

	public DiZhaoXuanHuoYin(CombatSkillKey skillKey)
		: base(skillKey, 16313)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		int[] enemyList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 70, -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_BounceInjury(OnBounceInjury);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_BounceInjury(OnBounceInjury);
	}

	private void OnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		if (defender == base.CombatChar)
		{
			_injuriesBeforeAttacked = base.CombatChar.GetInjuries();
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (defender == base.CombatChar)
		{
			_injuriesBeforeAttacked = base.CombatChar.GetInjuries();
		}
	}

	private void OnBounceInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount)
	{
		if (_affected && attackerId == base.CharacterId)
		{
			_affected = false;
			ShowSpecialEffectTips(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 70)
		{
			sbyte bodyPart = (sbyte)dataKey.CustomParam1;
			bool inner = dataKey.CustomParam0 == 1;
			int addValue = 15 * _injuriesBeforeAttacked.Get(bodyPart, inner);
			if (addValue > 0)
			{
				_affected = true;
			}
			return addValue;
		}
		return 0;
	}
}
