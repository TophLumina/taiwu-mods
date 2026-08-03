using System;

namespace Config.ConfigCells;

/// <summary>
/// 敌人巢穴生成信息
/// </summary>
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
