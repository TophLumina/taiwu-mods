using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Adventure.EnemyNest;

public abstract class FiveElementsStoneBase : CombatStateEffectBase
{
	private const int FrameDuration = 600;

	private const int QiDisorderDelta = 150;

	private const int AddInjuryCount = 1;

	protected abstract sbyte StoneFiveElementsType { get; }

	protected FiveElementsStoneBase()
	{
	}

	protected FiveElementsStoneBase(int charId)
		: base(charId)
	{
	}

	private bool IsNegative(sbyte fiveElementsType)
	{
		return fiveElementsType == FiveElementsType.Countering[StoneFiveElementsType];
	}

	private bool IsPositive(sbyte fiveElementsType)
	{
		return fiveElementsType == FiveElementsType.Producing[StoneFiveElementsType];
	}

	protected override IEnumerable<int> CalcFrameCounterPeriods()
	{
		yield return 600;
	}

	public override void OnProcess(DataContext context, int counterType)
	{
		DoAffect(context);
	}

	private void DoAffect(DataContext context)
	{
		sbyte fiveElementsType = (sbyte)NeiliType.Instance[base.CombatChar.GetNeiliType()].FiveElements;
		if (IsNegative(fiveElementsType))
		{
			DomainManager.Combat.ChangeDisorderOfQiRandomRecovery(context, base.CombatChar, 150);
			for (int i = 0; i < 1; i++)
			{
				Injuries injuries = base.CombatChar.GetInjuries();
				bool inner = context.Random.RandomIsInner(injuries.AnyInner, injuries.AnyOuter);
				base.CombatChar.AddRandomInjury(context, inner);
			}
		}
		else if (IsPositive(fiveElementsType))
		{
			DomainManager.Combat.ChangeDisorderOfQiRandomRecovery(context, base.CombatChar, -150);
			base.CombatChar.RemoveRandomInjury(context);
		}
	}
}
