using System;
using GameData.Utilities;

namespace GameData.Domains.Character.Relation;

public class RelationTypeHelper
{
	public const ushort AllParentTypes = 73;

	public const ushort AllSiblingTypes = 292;

	public const ushort AllChildTypes = 146;

	public const ushort AllAdoptiveTypes = 448;

	public static ushort AddRelation(RelatedCharacters relatedChars, int relatedCharId, ushort oriTypes, ushort addingType)
	{
		Tester.Assert(addingType != 0);
		for (sbyte i = 0; i < 3; i++)
		{
			if (RelationType.ContainBloodRelatedRelations(addingType, i) && RelationType.ContainBloodRelatedRelations(oriTypes, i))
			{
				ushort oriBloodRelatedType = RelationType.GetBloodRelatedRelation(oriTypes, i);
				if (addingType < oriBloodRelatedType)
				{
					relatedChars.Remove(relatedCharId, oriBloodRelatedType);
					relatedChars.Add(relatedCharId, addingType);
					return (ushort)((oriTypes & ~oriBloodRelatedType) | addingType);
				}
				return oriTypes;
			}
		}
		relatedChars.Add(relatedCharId, addingType);
		return (ushort)(oriTypes | addingType);
	}

	public static bool AllowAddingRelation(int charId, int relatedCharId, ushort addingType)
	{
		return addingType switch
		{
			1 => AllowAddingBloodRelation(charId, relatedCharId, 1), 
			2 => false, 
			4 => false, 
			8 => AllowAddingStepRelation(charId, relatedCharId, 8), 
			16 => false, 
			32 => false, 
			64 => AllowAddingAdoptiveRelation(charId, relatedCharId, 64), 
			128 => false, 
			256 => false, 
			512 => AllowAddingSwornBrotherOrSisterRelation(charId, relatedCharId), 
			1024 => AllowAddingHusbandOrWifeRelation(charId, relatedCharId), 
			2048 => AllowAddingRelation_Direct(charId, relatedCharId, 2048), 
			4096 => AllowAddingRelation_Direct(charId, relatedCharId, 4096), 
			8192 => AllowAddingRelation_Direct(charId, relatedCharId, 8192), 
			16384 => AllowAddingAdoredRelation(charId, relatedCharId), 
			32768 => AllowAddingEnemyRelation(charId, relatedCharId), 
			_ => throw new Exception($"Unsupported addingType: {addingType}"), 
		};
	}

	public static bool AllowAddingBloodParentRelation(int charId, int relatedCharId)
	{
		return AllowAddingBloodRelation(charId, relatedCharId, 1);
	}

	public static bool AllowAddingBloodChildRelation(int charId, int relatedCharId)
	{
		return false;
	}

	public static bool AllowAddingBloodBrotherOrSisterRelation(int charId, int relatedCharId)
	{
		return false;
	}

	public static bool AllowAddingStepParentRelation(int charId, int relatedCharId)
	{
		return AllowAddingStepRelation(charId, relatedCharId, 8);
	}

	public static bool AllowAddingStepChildRelation(int charId, int relatedCharId)
	{
		return false;
	}

	public static bool AllowAddingStepBrotherOrSisterRelation(int charId, int relatedCharId)
	{
		return false;
	}

	public static bool AllowAddingAdoptiveParentRelation(int charId, int relatedCharId)
	{
		return AllowAddingAdoptiveRelation(charId, relatedCharId, 64);
	}

	public static bool AllowAddingAdoptiveChildRelation(int charId, int relatedCharId)
	{
		return AllowAddingAdoptiveRelation(charId, relatedCharId, 128);
	}

	public static bool AllowAddingAdoptiveBrotherOrSisterRelation(int charId, int relatedCharId)
	{
		return false;
	}

	public static bool AllowAddingSwornBrotherOrSisterRelation(int charId, int relatedCharId)
	{
		if (!DomainManager.Character.TryGetRelation(charId, relatedCharId, out var relation))
		{
			relation.RelationType = ushort.MaxValue;
		}
		if (DomainManager.Character.HasNominalBloodRelation(charId, relatedCharId, relation))
		{
			return false;
		}
		if (relation.RelationType == ushort.MaxValue)
		{
			return true;
		}
		ushort relationTypes = relation.RelationType;
		if (relationTypes == 0)
		{
			return true;
		}
		if ((relationTypes & 0x200) != 0)
		{
			return false;
		}
		if (RelationType.ContainBloodRelatedRelations(relationTypes))
		{
			return false;
		}
		return true;
	}

	public static bool AllowAddingHusbandOrWifeRelation(int charId, int relatedCharId)
	{
		if (DomainManager.Character.GetAliveSpouse(charId) >= 0 || DomainManager.Character.GetAliveSpouse(relatedCharId) >= 0)
		{
			return false;
		}
		if (!DomainManager.Character.TryGetRelation(charId, relatedCharId, out var relation))
		{
			relation.RelationType = ushort.MaxValue;
		}
		if (DomainManager.Character.HasNominalBloodRelation(charId, relatedCharId, relation))
		{
			return false;
		}
		if (relation.RelationType == ushort.MaxValue)
		{
			return true;
		}
		ushort relationTypes = relation.RelationType;
		if (relationTypes == 0)
		{
			return true;
		}
		if ((relationTypes & 0x400) != 0)
		{
			return false;
		}
		if (RelationType.ContainBloodExclusionRelations(relationTypes))
		{
			return false;
		}
		return true;
	}

	public static bool AllowAddingMentorRelation(int charId, int relatedCharId)
	{
		return AllowAddingRelation_Direct(charId, relatedCharId, 2048);
	}

	public static bool AllowAddingMenteeRelation(int charId, int relatedCharId)
	{
		return AllowAddingRelation_Direct(charId, relatedCharId, 4096);
	}

	public static bool AllowAddingFriendRelation(int charId, int relatedCharId)
	{
		return AllowAddingRelation_Direct(charId, relatedCharId, 8192);
	}

	public static bool AllowAddingAdoredRelation(int charId, int relatedCharId)
	{
		if (!AllowAddingRelation_Direct(charId, relatedCharId, 16384))
		{
			return false;
		}
		if (DomainManager.Character.TryGetElement_Objects(charId, out var selfChar) && DomainManager.Character.TryGetElement_Objects(relatedCharId, out var relatedChar))
		{
			if (selfChar.GetFeatureIds().Contains(741))
			{
				return relatedChar.GetFeatureIds().Contains(740);
			}
			if (relatedChar.GetFeatureIds().Contains(741))
			{
				return selfChar.GetFeatureIds().Contains(740);
			}
		}
		return true;
	}

	public static bool AllowAddingEnemyRelation(int charId, int relatedCharId)
	{
		if (!AllowAddingRelation_Direct(charId, relatedCharId, 32768))
		{
			return false;
		}
		if (DomainManager.Character.TryGetElement_Objects(charId, out var selfChar) && DomainManager.Character.TryGetElement_Objects(relatedCharId, out var relatedChar))
		{
			if (selfChar.GetFeatureIds().Contains(740))
			{
				return relatedChar.GetFeatureIds().Contains(741);
			}
			if (relatedChar.GetFeatureIds().Contains(740))
			{
				return selfChar.GetFeatureIds().Contains(741);
			}
		}
		return true;
	}

	private static bool AllowAddingRelation_Direct(int charId, int relatedCharId, ushort addingType)
	{
		if (!DomainManager.Character.TryGetRelation(charId, relatedCharId, out var relation))
		{
			return true;
		}
		ushort relationTypes = relation.RelationType;
		if (relationTypes == 0)
		{
			return true;
		}
		if ((relationTypes & addingType) != 0)
		{
			return false;
		}
		return true;
	}

	private static bool AllowAddingBloodRelation(int charId, int relatedCharId, ushort addingType)
	{
		if (addingType == 1 && DomainManager.Character.HasEnoughBloodParents(charId))
		{
			return false;
		}
		if (!DomainManager.Character.TryGetRelation(charId, relatedCharId, out var relation))
		{
			relation.RelationType = ushort.MaxValue;
		}
		if (DomainManager.Character.HasNominalBloodRelation(charId, relatedCharId, relation))
		{
			return false;
		}
		if (relation.RelationType == ushort.MaxValue)
		{
			return true;
		}
		ushort relationTypes = relation.RelationType;
		if (relationTypes == 0)
		{
			return true;
		}
		if (addingType == 1 && RelationType.ContainParentRelations(relationTypes))
		{
			return true;
		}
		if (addingType == 2 && RelationType.ContainChildRelations(relationTypes))
		{
			return true;
		}
		if (addingType == 4 && RelationType.ContainBrotherOrSisterRelations(relationTypes))
		{
			return true;
		}
		if (RelationType.ContainBloodExclusionRelations(relationTypes))
		{
			return false;
		}
		return true;
	}

	private static bool AllowAddingStepRelation(int charId, int relatedCharId, ushort addingType)
	{
		if (!DomainManager.Character.TryGetRelation(charId, relatedCharId, out var relation))
		{
			relation.RelationType = ushort.MaxValue;
		}
		if (DomainManager.Character.HasNominalBloodRelation(charId, relatedCharId, relation))
		{
			return false;
		}
		if (relation.RelationType == ushort.MaxValue)
		{
			return true;
		}
		ushort relationTypes = relation.RelationType;
		if (relationTypes == 0)
		{
			return true;
		}
		if ((relationTypes & addingType) != 0)
		{
			return false;
		}
		if (addingType == 8 && (relationTypes & 8) != 0)
		{
			return false;
		}
		if (addingType == 16 && (relationTypes & 0x10) != 0)
		{
			return false;
		}
		if (addingType == 32 && (relationTypes & 0x20) != 0)
		{
			return false;
		}
		return true;
	}

	private static bool AllowAddingAdoptiveRelation(int charId, int relatedCharId, ushort addingType)
	{
		if (!DomainManager.Character.TryGetRelation(charId, relatedCharId, out var relation))
		{
			relation.RelationType = ushort.MaxValue;
		}
		if (DomainManager.Character.HasNominalBloodRelation(charId, relatedCharId, relation))
		{
			return false;
		}
		if (relation.RelationType == ushort.MaxValue)
		{
			return true;
		}
		ushort relationTypes = relation.RelationType;
		if (relationTypes == 0)
		{
			return true;
		}
		if ((relationTypes & addingType) != 0)
		{
			return false;
		}
		if (RelationType.ContainBloodExclusionRelations(relationTypes))
		{
			return false;
		}
		return true;
	}
}
