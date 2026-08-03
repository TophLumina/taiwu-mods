using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.TwelveImmortals;

public abstract class TwelveImmortalsTrickBase : TwelveImmortalsBase
{
	private const int AddQiDisorderUnit = 100;

	protected int ReverseEffectUnit { get; private set; }

	protected TwelveImmortalsTrickBase()
	{
	}

	protected TwelveImmortalsTrickBase(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_GetTrick(OnGetTrick);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_GetTrick(OnGetTrick);
		base.OnDisable(context);
	}

	private void OnGetTrick(DataContext context, int charId, bool isAlly, sbyte trickType, bool usable)
	{
		if (base.IsDirect || charId != base.CharacterId)
		{
			return;
		}
		int addValue = CalcReverseAddEffectValue(trickType);
		if (addValue != 0)
		{
			if (addValue < 0)
			{
				DomainManager.Combat.ChangeDisorderOfQiRandomRecovery(context, base.CombatChar, -addValue * 100);
			}
			ReverseEffectUnit += addValue;
			OnReverseEffectChanged(context);
			ShowSpecialEffectTips(addValue > 0, 0, 1);
		}
	}

	private int CalcReverseAddEffectValue(sbyte newTrickType)
	{
		IReadOnlyDictionary<int, sbyte> tricks = base.CombatChar.GetTricks().Tricks;
		if (tricks == null || tricks.Count <= 1)
		{
			return 0;
		}
		if (tricks.Count == 9)
		{
			return -ReverseEffectUnit;
		}
		List<int> indexes = ObjectPool<List<int>>.Instance.Get();
		indexes.AddRange(tricks.Keys);
		bool isContinueTrick = tricks[indexes[indexes.Count - 2]] == newTrickType;
		ObjectPool<List<int>>.Instance.Return(indexes);
		return isContinueTrick ? 1 : 0;
	}

	protected abstract void OnReverseEffectChanged(DataContext context);
}
