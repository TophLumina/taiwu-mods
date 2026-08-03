using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.Character.Alertness;

/// <summary>
/// 戒心记录文本渲染信息 (仅供前端使用)
/// </summary>
public class CharacterAlertnessRecordRenderInfo : RenderInfo
{
	/// <summary>
	/// 发生日期
	/// </summary>
	public readonly int Date;

	/// <summary>
	/// 文本渲染信息
	/// </summary>
	/// <param name="recordType"></param>
	/// <param name="text"></param>
	/// <param name="date"></param>
	public CharacterAlertnessRecordRenderInfo(short recordType, string text, int date)
		: base(recordType, text)
	{
		Date = date;
	}
}
