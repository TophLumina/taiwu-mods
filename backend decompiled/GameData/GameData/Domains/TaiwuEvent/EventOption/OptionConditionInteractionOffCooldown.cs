using System;
using Config;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionInteractionOffCooldown : TaiwuEventOptionConditionBase
{
	public readonly short InteractionTemplateId;

	public readonly Func<int, short, bool> ConditionChecker;

	public OptionConditionInteractionOffCooldown(short id, short interactionTemplateId, Func<int, short, bool> checkFunc)
		: base(id)
	{
		InteractionTemplateId = interactionTemplateId;
		ConditionChecker = checkFunc;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		int charId = -1;
		if (!box.Get(EventTriggerParameter.DefValue.CharacterId, ref charId))
		{
			return false;
		}
		return ConditionChecker(charId, InteractionTemplateId);
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		return (Id, Array.Empty<string>());
	}
}
