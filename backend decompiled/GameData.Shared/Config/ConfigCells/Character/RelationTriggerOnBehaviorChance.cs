using System;

namespace Config.ConfigCells.Character;

[Serializable]
public class RelationTriggerOnBehaviorChance
{
	/// <summary>
	/// 默认机率 （万分之）
	/// </summary>
	public short DefaultProb;

	/// <summary>
	/// 血亲关系替换机率（万分之）
	/// </summary>
	public short BloodRelationsProb;

	/// <summary>
	/// 义亲关系替换机率（万分之）
	/// </summary>
	public short SwornOrAdoptiveRelationsProb;

	public RelationTriggerOnBehaviorChance(short defaultProb, short bloodRelationsProb, short swornOrAdoptiveRelationsProb)
	{
		DefaultProb = defaultProb;
		BloodRelationsProb = bloodRelationsProb;
		SwornOrAdoptiveRelationsProb = swornOrAdoptiveRelationsProb;
	}
}
