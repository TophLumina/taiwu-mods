using System;

namespace Config;

/// <summary>
/// 式的范围调整
/// </summary>
[Serializable]
public class TrickDistanceAdjust
{
	/// <summary>
	/// 式的模板Id
	/// </summary>
	public sbyte TrickTemplateId;

	/// <summary>
	/// 最小范围调整
	/// </summary>
	public short MinDistance;

	/// <summary>
	/// 最大范围调整
	/// </summary>
	public short MaxDistance;

	/// <summary>
	/// 构造方法
	/// </summary>
	public TrickDistanceAdjust(sbyte templateId, short minDistance, short maxDistance)
	{
		TrickTemplateId = templateId;
		MinDistance = minDistance;
		MaxDistance = maxDistance;
	}
}
