using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.Character.Alertness;

public class CharacterAlertnessRecordRenderInfo : RenderInfo
{
	public readonly int Date;

	public CharacterAlertnessRecordRenderInfo(short recordType, string text, int date)
		: base(recordType, text)
	{
		Date = date;
	}
}
