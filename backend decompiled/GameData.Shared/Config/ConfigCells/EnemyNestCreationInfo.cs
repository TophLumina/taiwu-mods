using System;

namespace Config.ConfigCells;

[Serializable]
public class EnemyNestCreationInfo
{
	public readonly short EnemyNest;

	public readonly int Interval;

	public EnemyNestCreationInfo()
	{
	}

	public EnemyNestCreationInfo(short templateId, int interval)
	{
		EnemyNest = templateId;
		Interval = interval;
	}
}
