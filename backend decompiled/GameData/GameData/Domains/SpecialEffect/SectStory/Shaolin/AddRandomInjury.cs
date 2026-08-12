using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.SectStory.Shaolin;

public class AddRandomInjury : DemonSlayerTrialEffectBase
{
	private readonly int _bodyPartCount;

	private readonly int _outerInjuryLevel;

	private readonly int _innerInjuryLevel;

	public AddRandomInjury(int charId, IReadOnlyList<int> parameters)
		: base(charId)
	{
		_bodyPartCount = parameters[0];
		_outerInjuryLevel = parameters[1];
		_innerInjuryLevel = parameters[2];
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		List<sbyte> bodyParts = ObjectPool<List<sbyte>>.Instance.Get();
		bodyParts.Clear();
		for (sbyte i = 0; i < 7; i++)
		{
			bodyParts.Add(i);
		}
		Injuries injuries = base.CombatChar.GetInjuries();
		foreach (sbyte bodyPart in RandomUtils.GetRandomUnrepeated(context.Random, _bodyPartCount, bodyParts))
		{
			(sbyte outer, sbyte inner) tuple = injuries.Get(bodyPart);
			sbyte outer = tuple.outer;
			sbyte inner = tuple.inner;
			sbyte addOuter = (sbyte)Math.Min(6 - outer, _outerInjuryLevel);
			sbyte addInner = (sbyte)Math.Min(6 - inner, _innerInjuryLevel);
			int addFatal = _outerInjuryLevel + _innerInjuryLevel - addOuter - addInner;
			if (addOuter > 0)
			{
				base.CombatChar.AddInjury(context, bodyPart, isInner: false, addOuter);
			}
			if (addInner > 0)
			{
				base.CombatChar.AddInjury(context, bodyPart, isInner: true, addInner);
			}
			if (addFatal > 0)
			{
				base.CombatChar.AddFatalMark(context, addFatal, -1, -1);
			}
		}
		DomainManager.Combat.UpdateBodyDefeatMark(context, base.CombatChar);
		ObjectPool<List<sbyte>>.Instance.Return(bodyParts);
	}
}
