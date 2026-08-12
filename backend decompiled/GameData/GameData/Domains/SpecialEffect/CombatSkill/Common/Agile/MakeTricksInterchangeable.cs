using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

public class MakeTricksInterchangeable : AgileSkillBase
{
	private const sbyte ReverseAffectOdds = 50;

	protected List<sbyte> AffectTrickTypes;

	private sbyte _needAddTrick;

	protected MakeTricksInterchangeable()
	{
	}

	protected MakeTricksInterchangeable(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
		ListenCanAffectChange = base.IsDirect;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (base.IsDirect)
		{
			OnMoveSkillCanAffectChanged(context, default(DataUid));
			ShowSpecialEffectTips(0);
		}
		else
		{
			Events.RegisterHandler_GetTrick(OnGetTrick);
		}
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		if (base.IsDirect)
		{
			base.CombatChar.InterchangeableTricks.Clear();
			DomainManager.Combat.RemoveOverflowTrick(context, base.CombatChar, updateFieldAndSkill: true);
		}
		else
		{
			Events.UnRegisterHandler_GetTrick(OnGetTrick);
		}
	}

	private void OnGetTrick(DataContext context, int charId, bool isAlly, sbyte trickType, bool usable)
	{
		if (isAlly != base.CombatChar.IsAlly && base.CanAffect && AffectTrickTypes.Contains(trickType) && !base.CombatChar.IsTrickUseless(trickType) && context.Random.CheckPercentProb(50))
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			if (DomainManager.Combat.RemoveTrick(context, enemyChar, trickType, 1, removedByAlly: false))
			{
				_needAddTrick = trickType;
				Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
				ShowSpecialEffectTips(0);
			}
		}
	}

	protected override void OnMoveSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
		base.CombatChar.InterchangeableTricks.Clear();
		if (base.CanAffect)
		{
			base.CombatChar.InterchangeableTricks.AddRange(AffectTrickTypes);
		}
		DomainManager.Combat.RemoveOverflowTrick(context, base.CombatChar, updateFieldAndSkill: true);
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		DomainManager.Combat.AddTrick(context, base.CombatChar, _needAddTrick);
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}
}
