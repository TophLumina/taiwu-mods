using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.DefenseAndAssist;

public class XueOuPoShaFa : DefenseSkillBase
{
	private const sbyte StatePowerUnit = 50;

	private readonly List<int> _affectEnemyList = new List<int>();

	public XueOuPoShaFa()
	{
	}

	public XueOuPoShaFa(CombatSkillKey skillKey)
		: base(skillKey, 12704)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 114, -1), EDataModifyType.Custom);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_ChangeBossPhase(OnChangeBossPhase);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_ChangeBossPhase(OnChangeBossPhase);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (isFightBack && hit && attacker == base.CombatChar && base.CombatChar.GetAffectingDefendSkillId() == base.SkillTemplateId && base.CanAffect)
		{
			CombatCharacter enemyChar = base.CurrEnemyChar;
			DomainManager.Combat.AddCombatState(context, enemyChar, 2, (short)(base.IsDirect ? 64 : 65), 50);
			ShowSpecialEffectTips(0);
			if (!_affectEnemyList.Contains(enemyChar.GetId()))
			{
				_affectEnemyList.Add(enemyChar.GetId());
				DomainManager.Combat.AddCombatState(context, enemyChar, 0, (short)(base.IsDirect ? 66 : 67), 100, reverse: false, applyEffect: true, base.CharacterId);
			}
		}
	}

	private void OnChangeBossPhase(DataContext context)
	{
		_affectEnemyList.Clear();
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		EDamageType damageType = (EDamageType)dataKey.CustomParam0;
		if (dataKey.CharId != base.CharacterId || damageType != EDamageType.Direct || dataKey.CustomParam1 != ((!base.IsDirect) ? 1 : 0) || _affectEnemyList.Count == 0)
		{
			return dataValue;
		}
		sbyte bodyPart = (sbyte)dataKey.CustomParam2;
		int damageValue = (int)dataValue;
		DataContext context = DomainManager.Combat.Context;
		for (int i = 0; i < _affectEnemyList.Count; i++)
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetElement_CombatCharacterDict(_affectEnemyList[i]);
			DomainManager.Combat.RemoveCombatState(context, enemyChar, 0, (short)(base.IsDirect ? 66 : 67));
			DomainManager.Combat.AddInjuryDamageValue(base.CombatChar, enemyChar, bodyPart, base.IsDirect ? damageValue : 0, (!base.IsDirect) ? damageValue : 0, -1);
		}
		_affectEnemyList.Clear();
		ShowSpecialEffectTips(1);
		return 0L;
	}
}
