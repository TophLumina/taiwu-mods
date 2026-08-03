using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Sword;

public class XuanMingJianQi : PoisonAddInjury
{
	private static readonly int[] AttackPrepareFrameAddPercent = new int[3] { 100, 150, 200 };

	private bool _affected;

	protected override bool AutoRemove => false;

	public XuanMingJianQi()
	{
	}

	public XuanMingJianQi(CombatSkillKey skillKey)
		: base(skillKey, 13207)
	{
		RequirePoisonType = 2;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedAllEnemyData(282, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		base.OnDisable(context);
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (_affected && defender == base.CombatChar)
		{
			ReduceEffectCount();
			_affected = false;
			ShowSpecialEffectTips(1);
		}
	}

	protected override void OnCastMaxPower(DataContext context)
	{
		AddMaxEffectCount();
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId != 282 || base.EffectCount <= 0 || !base.IsCurrent)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		if (!DomainManager.Combat.TryGetElement_CombatCharacterDict(dataKey.CharId, out var enemyChar))
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		if (enemyChar.IsAlly == base.CombatChar.IsAlly)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		CombatCharacter poisonChar = (base.IsDirect ? enemyChar : base.CombatChar);
		byte markCount = poisonChar.GetDefeatMarkCollection().PoisonMarkList[RequirePoisonType];
		if (markCount == 0)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		_affected = true;
		return AttackPrepareFrameAddPercent[markCount - 1];
	}
}
