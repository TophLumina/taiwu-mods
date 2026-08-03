using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.Information.Collection;

public class SecretInformationRenderInfo : RenderInfo
{
	public readonly int Date;

	public SecretInformationRenderInfo(short recordType, string text, int date)
		: base(recordType, text)
	{
		Date = date;
	}
}
