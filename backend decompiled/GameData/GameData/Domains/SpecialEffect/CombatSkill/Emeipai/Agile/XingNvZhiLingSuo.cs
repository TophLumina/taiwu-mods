using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Agile;

public class XingNvZhiLingSuo : AgileSkillBase
{
	private const int MaxChangeDistance = 2;

	private bool _needAffect;

	public XingNvZhiLingSuo()
	{
	}

	public XingNvZhiLingSuo(CombatSkillKey skillKey)
		: base(skillKey, 2504)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(157, EDataModifyType.Custom, -1);
		Events.RegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		base.OnDisable(context);
	}

	private void OnNormalAttackCalcHitEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, int pursueIndex, bool hit, bool isFightback, bool isMind)
	{
		if ((base.IsDirect ? attacker : defender) == base.CombatChar && hit && pursueIndex <= 0)
		{
			_needAffect = true;
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if ((base.IsDirect ? attacker : defender) == base.CombatChar && _needAffect)
		{
			ShowSpecialEffectTips(0);
			DoChangeDistance(context);
			_needAffect = false;
		}
	}

	private void DoChangeDistance(DataContext context)
	{
		short target = base.CombatChar.GetAttackRange().Average;
		short current = DomainManager.Combat.GetCurrentDistance();
		if (current != target)
		{
			int delta = Math.Min(2, Math.Abs(target - current)) * Math.Sign(target - current);
			DomainManager.Combat.ChangeDistance(context, base.CombatChar, delta);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 157 || !_needAffect)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		return false;
	}
}
