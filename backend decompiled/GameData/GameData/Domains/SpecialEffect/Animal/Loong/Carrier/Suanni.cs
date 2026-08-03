using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Carrier;

public class Suanni : CombatStateEffectBase
{
	private const int FatalDamageTotalPercent = 20;

	private const int ChangeToFatalOdds = 50;

	private bool _changeToFatal;

	protected override short CombatStateId => 203;

	public Suanni(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(89, EDataModifyType.Custom, -1);
		CreateAffectedAllEnemyData(191, EDataModifyType.TotalPercent, -1);
		Events.RegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_AttackSkillAttackBegin(OnAttackSkillAttackBegin);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_AttackSkillAttackBegin(OnAttackSkillAttackBegin);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		base.OnDisable(context);
	}

	private void OnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		if (attacker.GetId() == base.CharacterId)
		{
			_changeToFatal = context.Random.CheckPercentProb(50);
		}
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightback)
	{
		if (attacker.GetId() == base.CharacterId)
		{
			_changeToFatal = false;
		}
	}

	private void OnAttackSkillAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId, int index, bool hit)
	{
		if (attacker.GetId() == base.CharacterId)
		{
			_changeToFatal = context.Random.CheckPercentProb(50);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (context.AttackerId == base.CharacterId)
		{
			_changeToFatal = false;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId || dataKey.FieldId != 191)
		{
			return 0;
		}
		EDamageType damageType = (EDamageType)dataKey.CustomParam1;
		if (damageType != EDamageType.Direct)
		{
			return 0;
		}
		return 20;
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 89 || dataValue <= 0 || !_changeToFatal)
		{
			return dataValue;
		}
		bool isInner = dataKey.CustomParam1 == 1;
		sbyte bodyPart = (sbyte)dataKey.CustomParam2;
		CombatCharacter enemyChar = base.CurrEnemyChar;
		int value = (int)Math.Clamp(dataValue, 0L, 2147483647L);
		enemyChar.AddFatalDamage(base.CombatChar.GetDataContext(), value, isInner ? 1 : 0, bodyPart, dataKey.CombatSkillId);
		return 0L;
	}
}
