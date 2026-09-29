using System;

namespace Config;

[Serializable]
public class TrickDistanceAdjust
{
	public sbyte TrickTemplateId;

	public short MinDistance;

	public short MaxDistance;

	public TrickDistanceAdjust(sbyte templateId, short minDistance, short maxDistance)
	{
		TrickTemplateId = templateId;
		MinDistance = minDistance;
		MaxDistance = maxDistance;
	}
}
