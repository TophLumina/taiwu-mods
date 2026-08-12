using System.Collections.Generic;

namespace GameData.Domains.LifeRecord.GeneralRecord;

/// <summary>
/// 通用记录文本渲染信息 (仅供前端使用)
/// </summary>
public class RenderInfo
{
	/// <summary>
	/// 记录类型 (即记录配置表中的模板 ID)
	/// </summary>
	public readonly short RecordType;

	/// <summary>
	/// 参数未被替换时的原始文本
	/// </summary>
	public readonly string Text;

	/// <summary>
	/// 实参集合.
	/// paramType: 参数类型. <see cref="T:GameData.Domains.LifeRecord.GeneralRecord.ParameterType" />.
	/// index: 该参数在同类参数列表中的索引.
	/// </summary>
	public readonly List<(sbyte paramType, int index)> Arguments;

	/// <summary>
	/// 通用记录文本渲染信息
	/// </summary>
	/// <param name="recordType">记录类型 (即记录配置表中的模板 ID)</param>
	/// <param name="text">参数未被替换时的原始文本</param>
	public RenderInfo(short recordType, string text)
	{
		RecordType = recordType;
		Text = text;
		Arguments = new List<(sbyte, int)>();
	}
}
