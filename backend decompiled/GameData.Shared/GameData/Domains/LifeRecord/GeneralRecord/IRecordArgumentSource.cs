using GameData.Domains.Map;

namespace GameData.Domains.LifeRecord.GeneralRecord;

public interface IRecordArgumentSource
{
	int GetCharacterArg();

	short GetAdventureArg();

	short GetSettlementArg();

	Location GetLocationArg();

	sbyte GetLifeSkillTypeArg();
}
