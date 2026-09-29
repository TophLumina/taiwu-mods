using System;

namespace Config.ConfigCells.Character;

[Serializable]
public class RelationTriggerOnBehaviorChance
{
	public short DefaultProb;

	public short BloodRelationsProb;

	public short SwornOrAdoptiveRelationsProb;

	public RelationTriggerOnBehaviorChance(short defaultProb, short bloodRelationsProb, short swornOrAdoptiveRelationsProb)
	{
		DefaultProb = defaultProb;
		BloodRelationsProb = bloodRelationsProb;
		SwornOrAdoptiveRelationsProb = swornOrAdoptiveRelationsProb;
	}
}
