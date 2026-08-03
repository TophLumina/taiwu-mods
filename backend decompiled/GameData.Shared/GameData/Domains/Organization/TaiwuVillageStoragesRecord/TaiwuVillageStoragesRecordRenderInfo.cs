using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.Organization.TaiwuVillageStoragesRecord;

/// <summary>
/// 太吾村库房记录文本渲染信息 (仅供前端使用)
/// </summary>
public class TaiwuVillageStoragesRecordRenderInfo : RenderInfo
{
	/// <summary>
	/// 发生日期
	/// </summary>
	public readonly int Date;

	/// <summary>
	/// 库房类型
	/// </summary>
	public readonly sbyte StorageType;

	/// <summary>
	/// 文本渲染信息
	/// </summary>
	/// <param name="recordType"></param>
	/// <param name="text"></param>
	/// <param name="date"></param>
	/// <param name="storageType"></param>
	public TaiwuVillageStoragesRecordRenderInfo(short recordType, string text, int date, sbyte storageType)
		: base(recordType, text)
	{
		Date = date;
		StorageType = storageType;
	}
}
