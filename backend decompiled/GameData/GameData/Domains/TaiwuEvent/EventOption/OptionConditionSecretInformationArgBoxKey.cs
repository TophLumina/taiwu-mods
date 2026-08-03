using System;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.EventOption;

public class OptionConditionSecretInformationArgBoxKey : TaiwuEventOptionConditionBase
{
	public readonly string Key;

	public readonly string CharIdKey;

	public readonly sbyte TaiwuNameFormatIndex;

	public readonly Func<int, string, bool> ConditionChecker;

	public OptionConditionSecretInformationArgBoxKey(short id, string boxKey, string charIdKey, sbyte taiwuNameFormatIndex, Func<int, string, bool> checkFunc)
		: base(id)
	{
		Key = boxKey;
		CharIdKey = charIdKey;
		TaiwuNameFormatIndex = taiwuNameFormatIndex;
		ConditionChecker = checkFunc;
	}

	public override bool CheckCondition(EventArgBox box)
	{
		int secretInformationMetaDataId = -1;
		if (box.Get(Key, ref secretInformationMetaDataId))
		{
			return ConditionChecker(secretInformationMetaDataId, CharIdKey);
		}
		return false;
	}

	public override (short, string[]) GetDisplayData(EventArgBox box)
	{
		int secretInformationMetaDataId = -1;
		if (box.Get(Key, ref secretInformationMetaDataId))
		{
			EventArgBox metaDataArgBox = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetSecretInformationParameters(secretInformationMetaDataId);
			int charId = -1;
			if (metaDataArgBox.Get(CharIdKey, ref charId))
			{
				int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
				bool isTaiwu = charId == taiwuCharId;
				(string, string) nameTuple = DomainManager.Character.GetNameRelatedData(charId).GetDisplayName(isTaiwu);
				string charName = nameTuple.Item1 + nameTuple.Item2;
				if (-1 == TaiwuNameFormatIndex)
				{
					return (Id, new string[1] { charName });
				}
				string[] nameFormatArgs = new string[2] { charName, charName };
				if (nameFormatArgs.CheckIndex(TaiwuNameFormatIndex))
				{
					(string, string) taiwuNameTuple = DomainManager.Character.GetNameRelatedData(taiwuCharId).GetDisplayName(isTaiwu: true);
					nameFormatArgs[TaiwuNameFormatIndex] = taiwuNameTuple.Item1 + taiwuNameTuple.Item2;
				}
				return (Id, nameFormatArgs);
			}
		}
		return (Id, new string[1] { "role decode error" });
	}
}
