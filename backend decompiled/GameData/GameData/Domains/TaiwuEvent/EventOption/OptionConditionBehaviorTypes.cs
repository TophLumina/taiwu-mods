using System;
using System.Text;
using Config;
using GameData.Domains.Character;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionBehaviorTypes : TaiwuEventOptionConditionBase
{
	public readonly sbyte[] BehaviorRange;

	public readonly Func<sbyte, sbyte, sbyte, sbyte, sbyte, bool> ConditionChecker;

	public OptionConditionBehaviorTypes(short id, sbyte b1, sbyte b2, sbyte b3, sbyte b4, sbyte b5, Func<sbyte, sbyte, sbyte, sbyte, sbyte, bool> checkFunc)
		: base(id)
	{
		BehaviorRange = new sbyte[5] { b1, b2, b3, b4, b5 };
		ConditionChecker = checkFunc;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		GameData.Domains.Character.Character character = box.GetCharacter();
		if (character != null)
		{
			return ConditionChecker(BehaviorRange[0], BehaviorRange[1], BehaviorRange[2], BehaviorRange[3], BehaviorRange[4]);
		}
		return false;
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		StringBuilder sb = new StringBuilder();
		int i = 0;
		sbyte[] behaviorRange = BehaviorRange;
		foreach (sbyte beh in behaviorRange)
		{
			if (beh >= 0)
			{
				if (i != 0)
				{
					sb.Append('、');
				}
				sb.Append(Config.BehaviorType.Instance[beh].Name);
				i++;
			}
		}
		return (Id, new string[1] { sb.ToString() });
	}
}
