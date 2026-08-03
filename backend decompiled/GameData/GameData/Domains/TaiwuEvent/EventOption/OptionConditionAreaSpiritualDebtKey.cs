using System;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Map;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionAreaSpiritualDebtKey : TaiwuEventOptionConditionBase
{
	[Obsolete]
	public readonly string AreaArgBoxKey;

	public readonly short SpiritualDebtValue;

	public readonly Func<MapAreaData, short, bool> ConditionChecker;

	public OptionConditionAreaSpiritualDebtKey(short id, string key, short spiritualDebtValue, Func<MapAreaData, short, bool> checkFunc)
		: base(id)
	{
		AreaArgBoxKey = key;
		SpiritualDebtValue = spiritualDebtValue;
		ConditionChecker = checkFunc;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location location = taiwuChar.GetLocation();
		MapAreaData areaData = DomainManager.Map.GetElement_Areas(location.AreaId);
		return ConditionChecker(areaData, SpiritualDebtValue);
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		string areaName = string.Empty;
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		Location location = taiwuChar.GetLocation();
		MapAreaData areaData = DomainManager.Map.GetElement_Areas(location.AreaId);
		MapAreaItem areaConfig = MapArea.Instance.GetItem(areaData.GetTemplateId());
		if (areaConfig != null)
		{
			areaName = areaConfig.Name;
		}
		return (Id, new string[2]
		{
			areaName,
			SpiritualDebtValue.ToString()
		});
	}
}
