using GameData.Domains.Character.Relation;

namespace GameData.Domains.Organization;

public static class FactionLeaderPriorityType
{
	public const sbyte Invalid = -1;

	public const sbyte Parent = 0;

	public const sbyte Mentor = 1;

	public const sbyte Spouse = 2;

	public const sbyte Sibling = 3;

	public const sbyte SwornSibling = 4;

	public const sbyte SameGradeGeneral = 5;

	public static sbyte GetFactionLeaderPriorityType(ushort relationType)
	{
		if (relationType == 0)
		{
			return 5;
		}
		if (RelationType.ContainParentRelations(relationType))
		{
			return 0;
		}
		if (RelationType.HasRelation(relationType, 2048))
		{
			return 1;
		}
		if (RelationType.HasRelation(relationType, 1024))
		{
			return 2;
		}
		if (RelationType.ContainBrotherOrSisterRelations(relationType))
		{
			return 3;
		}
		if (RelationType.HasRelation(relationType, 512))
		{
			return 4;
		}
		return 5;
	}
}
