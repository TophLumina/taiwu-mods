using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.Organization.TaiwuVillageStoragesRecord;

public class TaiwuVillageStoragesRecordRenderInfo : RenderInfo
{
	public readonly int Date;

	public readonly sbyte StorageType;

	public TaiwuVillageStoragesRecordRenderInfo(short recordType, string text, int date, sbyte storageType)
		: base(recordType, text)
	{
		Date = date;
		StorageType = storageType;
	}
}
