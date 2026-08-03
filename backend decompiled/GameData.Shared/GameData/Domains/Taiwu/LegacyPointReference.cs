using System;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 遗惠点引用
/// </summary>
[Serializable]
public class LegacyPointReference
{
	/// <summary>
	/// 遗惠点模板 ID
	/// </summary>
	public short TemplateId { get; private set; }

	/// <summary>
	/// 战胜时的百分比
	/// </summary>
	public int WinPercent { get; private set; }

	/// <summary>
	/// 战败时的百分比
	/// </summary>
	public int FailPercent { get; private set; }

	/// <summary>
	/// 从配置创建的构造方法
	/// </summary>
	/// <param name="templateId"></param>
	/// <param name="winPercent"></param>
	/// <param name="failPercent"></param>
	public LegacyPointReference(short templateId, int winPercent, int failPercent)
	{
		TemplateId = templateId;
		WinPercent = winPercent;
		FailPercent = failPercent;
	}
}
