using System;
using Config;
using GameData.Combat.Math;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public struct SkillBreakPlateBonus : ISerializableGameData, IEquatable<SkillBreakPlateBonus>
{
	private static class FieldIds
	{
		public const ushort InternalType = 0;

		public const ushort InternalValue0 = 1;

		public const ushort InternalValue1 = 2;

		public const ushort InternalValue2 = 3;

		public const ushort InternalValue3 = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "InternalType", "InternalValue0", "InternalValue1", "InternalValue2", "InternalValue3" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	private ESkillBreakPlateBonusType _internalType;

	[SerializableGameDataField(FieldIndex = 1)]
	private int _internalValue0;

	[SerializableGameDataField(FieldIndex = 2)]
	private int _internalValue1;

	[SerializableGameDataField(FieldIndex = 3)]
	private int _internalValue2;

	[SerializableGameDataField(FieldIndex = 4)]
	private int _internalValue3;

	public static SkillBreakPlateBonus Invalid => default(SkillBreakPlateBonus);

	public ESkillBreakPlateBonusType Type => _internalType;

	public int ImpactRange => Type switch
	{
		ESkillBreakPlateBonusType.None => 0, 
		ESkillBreakPlateBonusType.Item => (Grade + 3) / 3, 
		ESkillBreakPlateBonusType.Relation => (FavorabilityLevel + 3) / 3, 
		ESkillBreakPlateBonusType.Exp => (ExpLevel + 3) / 3, 
		ESkillBreakPlateBonusType.Friend => (Grade + 3) / 3, 
		_ => 0, 
	};

	public sbyte Grade => (sbyte)MathUtils.Clamp(Type switch
	{
		ESkillBreakPlateBonusType.None => 0, 
		ESkillBreakPlateBonusType.Item => ItemTemplateHelper.GetGrade(ItemType, ItemTemplateId), 
		ESkillBreakPlateBonusType.Relation => FavorabilityLevel, 
		ESkillBreakPlateBonusType.Exp => ExpLevel, 
		ESkillBreakPlateBonusType.Friend => FriendAttainment / SkillBreakPlateConstants.FriendGradeDivisor - SkillBreakPlateConstants.FriendGradeMinus, 
		_ => 0, 
	}, 0, 8);

	private int GradePlus2 => Grade + 2;

	public SkillBreakBonusEffectItem Effect => Type switch
	{
		ESkillBreakPlateBonusType.Item => SkillBreakBonusEffect.Instance[ItemTemplateHelper.GetBreakBonusEffect(ItemType, ItemTemplateId)], 
		ESkillBreakPlateBonusType.Relation => SkillBreakBonusEffect.Instance[(sbyte)((RelationType == 16384) ? 33 : 34)], 
		ESkillBreakPlateBonusType.Exp => SkillBreakBonusEffect.Instance[(sbyte)37], 
		ESkillBreakPlateBonusType.Friend => SkillBreakBonusEffect.Instance[(sbyte)47], 
		_ => null, 
	};

	public sbyte ItemType
	{
		get
		{
			if (Type != ESkillBreakPlateBonusType.Item)
			{
				return -1;
			}
			return (sbyte)_internalValue0;
		}
	}

	public short ItemTemplateId
	{
		get
		{
			if (Type != ESkillBreakPlateBonusType.Item)
			{
				return -1;
			}
			return (short)_internalValue1;
		}
	}

	public EMedicineEffectType MedicineEffectType
	{
		get
		{
			if (ItemType == 8)
			{
				return Medicine.Instance[ItemTemplateId].EffectType;
			}
			return EMedicineEffectType.Invalid;
		}
	}

	public bool HasRelationKey
	{
		get
		{
			ESkillBreakPlateBonusType type = Type;
			if (type == ESkillBreakPlateBonusType.Relation || type == ESkillBreakPlateBonusType.Friend)
			{
				return true;
			}
			return false;
		}
	}

	public int RelationCharId
	{
		get
		{
			if (!HasRelationKey)
			{
				return -1;
			}
			return _internalValue2;
		}
	}

	public int RelationRelatedCharId
	{
		get
		{
			if (!HasRelationKey)
			{
				return -1;
			}
			return _internalValue3;
		}
	}

	public RelationKey RelationKey => new RelationKey(RelationCharId, RelationRelatedCharId);

	public ushort RelationType
	{
		get
		{
			if (Type != ESkillBreakPlateBonusType.Relation)
			{
				return ushort.MaxValue;
			}
			return (ushort)_internalValue0;
		}
	}

	public short Favorability
	{
		get
		{
			if (!HasRelationKey)
			{
				return short.MinValue;
			}
			return (short)_internalValue1;
		}
	}

	public sbyte FavorabilityType
	{
		get
		{
			if (!HasRelationKey)
			{
				return sbyte.MinValue;
			}
			return GameData.Domains.Character.Relation.FavorabilityType.GetFavorabilityType(Favorability);
		}
	}

	public sbyte FavorabilityLevel
	{
		get
		{
			if (Type != ESkillBreakPlateBonusType.Relation)
			{
				return -1;
			}
			if (RelationType != 16384)
			{
				return (sbyte)MathUtils.Max(-FavorabilityType, 0);
			}
			return (sbyte)MathUtils.Max(FavorabilityType, 0);
		}
	}

	public int ExpLevel
	{
		get
		{
			if (Type != ESkillBreakPlateBonusType.Exp)
			{
				return -1;
			}
			return _internalValue0;
		}
	}

	public int FriendAttainment
	{
		get
		{
			if (Type != ESkillBreakPlateBonusType.Friend)
			{
				return 0;
			}
			return _internalValue0;
		}
	}

	public override string ToString()
	{
		return Type switch
		{
			ESkillBreakPlateBonusType.Item => GameData.Domains.Item.ItemType.TypeId2TypeName[ItemType] + " - " + ItemTemplateHelper.GetName(ItemType, ItemTemplateId), 
			ESkillBreakPlateBonusType.Relation => $"{GameData.Domains.Character.Relation.RelationType.GetTypeName(RelationType)}-{RelationCharId}", 
			ESkillBreakPlateBonusType.Exp => $"Exp - {ExpLevel}", 
			_ => Type.ToString(), 
		};
	}

	public static SkillBreakPlateBonus CreateItem(sbyte itemType, short templateId)
	{
		if (!SkillBreakPlateConstants.IsBonusItem(itemType, templateId))
		{
			return Invalid;
		}
		return new SkillBreakPlateBonus
		{
			_internalType = ESkillBreakPlateBonusType.Item,
			_internalValue0 = itemType,
			_internalValue1 = templateId
		};
	}

	public static SkillBreakPlateBonus CreateExp(int level)
	{
		if (level < 0 || level >= SkillBreakPlateConstants.ExpLevelValues.Count)
		{
			return Invalid;
		}
		return new SkillBreakPlateBonus
		{
			_internalType = ESkillBreakPlateBonusType.Exp,
			_internalValue0 = level
		};
	}

	public static SkillBreakPlateBonus CreateRelation(RelationKey relation, ushort relationType, short favorability)
	{
		return new SkillBreakPlateBonus
		{
			_internalType = ESkillBreakPlateBonusType.Relation,
			_internalValue0 = relationType,
			_internalValue1 = favorability,
			_internalValue2 = relation.CharId,
			_internalValue3 = relation.RelatedCharId
		};
	}

	public static SkillBreakPlateBonus CreateFriend(RelationKey relation, short attainment, short favorability)
	{
		return new SkillBreakPlateBonus
		{
			_internalType = ESkillBreakPlateBonusType.Friend,
			_internalValue0 = attainment,
			_internalValue1 = favorability,
			_internalValue2 = relation.CharId,
			_internalValue3 = relation.RelatedCharId
		};
	}

	public static SkillBreakPlateBonus CreateFriendVirtual(short attainment, short favorability)
	{
		return new SkillBreakPlateBonus
		{
			_internalType = ESkillBreakPlateBonusType.Friend,
			_internalValue0 = attainment,
			_internalValue1 = favorability,
			_internalValue2 = -1,
			_internalValue3 = -1
		};
	}

	public bool ShouldBeRemoved()
	{
		return Type == ESkillBreakPlateBonusType.None;
	}

	public SkillBreakPlateBonus ResetRelationCharIds()
	{
		if (HasRelationKey)
		{
			_internalValue2 = (_internalValue3 = -1);
		}
		return this;
	}

	public bool IsMatch(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].MatchBreakPlateBonusEffect(Effect);
	}

	public SkillBreakBonusEffectImplementItem GetImplement(sbyte equipType)
	{
		SkillBreakBonusEffectItem effect = Effect;
		if (effect == null)
		{
			return null;
		}
		int implementId = effect.GetImplementId(equipType);
		if (implementId < 0)
		{
			return null;
		}
		return SkillBreakBonusEffectImplement.Instance[implementId];
	}

	public int CalcAddLifeSkillRequirement(sbyte equipType, ref LifeSkillShorts lifeSkillAttainments)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || implement.AddRequirementType < 0)
		{
			return 0;
		}
		return MathUtils.Max(lifeSkillAttainments[implement.AddRequirementType] * GradePlus2 / 100, 1);
	}

	public int CalcReduceCostBreath(sbyte equipType, ref LifeSkillShorts lifeSkillAttainments)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || implement.ReduceCostBreathType < 0)
		{
			return 0;
		}
		return MathUtils.Clamp(lifeSkillAttainments[implement.ReduceCostBreathType] * GradePlus2 / 1000, 1, 5);
	}

	public int CalcReduceCostStance(sbyte equipType, ref LifeSkillShorts lifeSkillAttainments)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || implement.ReduceCostStanceType < 0)
		{
			return 0;
		}
		return MathUtils.Clamp(lifeSkillAttainments[implement.ReduceCostStanceType] * GradePlus2 / 1000, 1, 5);
	}

	public int CalcReduceCastFrame(sbyte equipType, ref LifeSkillShorts lifeSkillAttainments)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || implement.ReduceCastFrameType < 0)
		{
			return 0;
		}
		return MathUtils.Clamp(lifeSkillAttainments[implement.ReduceCastFrameType] * GradePlus2 / 500, 1, 10);
	}

	public int CalcAddMaxPower(sbyte equipType, ref LifeSkillShorts lifeSkillAttainments)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || implement.AddMaxPowerType < 0)
		{
			return 0;
		}
		return MathUtils.Clamp(lifeSkillAttainments[implement.AddMaxPowerType] * GradePlus2 / 500, 1, 10);
	}

	public int CalcAddInjuryStep(sbyte equipType, bool inner)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || !implement.AddInjuryStep)
		{
			return 0;
		}
		EMedicineEffectType target = (inner ? EMedicineEffectType.RecoverInnerInjury : EMedicineEffectType.RecoverOuterInjury);
		if (MedicineEffectType != target)
		{
			return 0;
		}
		return 5 + GradePlus2 * 2;
	}

	public int CalcAddFatalStep(sbyte equipType)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || !implement.AddFatalStep)
		{
			return 0;
		}
		return 5 + GradePlus2 * 2;
	}

	public int CalcAddMindStep(sbyte equipType)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || !implement.AddMindStep)
		{
			return 0;
		}
		return 5 + GradePlus2 * 2;
	}

	public int CalcEquipAddProperty(sbyte equipType, ECharacterPropertyReferencedType type)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null)
		{
			return 0;
		}
		int value = 0;
		value += CalcEquipAddPropertyMedicine(implement, type);
		value += CalcEquipAddPropertyTeaWine(implement, type);
		value += CalcEquipAddPropertyFood(implement, type);
		if (equipType == 4)
		{
			value += CalcEquipAddPropertyAssist(implement, type);
		}
		return value + CalcEquipAddPropertyRelation(implement, type);
	}

	private int CalcEquipAddPropertyMedicine(SkillBreakBonusEffectImplementItem implement, ECharacterPropertyReferencedType type)
	{
		if (ItemType != 8)
		{
			return 0;
		}
		CValuePercent factor = CalcEquipAddPropertyMedicineFactor(implement, type);
		if (factor <= 0)
		{
			return 0;
		}
		MedicineItem config = Medicine.Instance[ItemTemplateId];
		if (config == null)
		{
			return 0;
		}
		if (!config.HasCharacterPropertyBonus(type))
		{
			return 0;
		}
		return GradePlus2 * factor;
	}

	private int CalcEquipAddPropertyMedicineFactor(SkillBreakBonusEffectImplementItem implement, ECharacterPropertyReferencedType type)
	{
		if (type.IsPenetrate())
		{
			return implement.PenetrateFactor;
		}
		if (type.IsPenetrateResist())
		{
			return implement.PenetrateResistFactor;
		}
		if (type.IsHit())
		{
			return implement.HitFactor;
		}
		if (type.IsAvoid())
		{
			return implement.AvoidFactor;
		}
		if (type.IsPoisonResist())
		{
			return implement.PoisonResistFactor;
		}
		if (!type.IsSubAttribute())
		{
			return 0;
		}
		return implement.SubAttributeFactor;
	}

	private int CalcEquipAddPropertyTeaWine(SkillBreakBonusEffectImplementItem implement, ECharacterPropertyReferencedType type)
	{
		if (ItemType != 9 || implement.SubAttributeFactor == 0 || !type.IsSubAttribute())
		{
			return 0;
		}
		if (TeaWine.Instance[ItemTemplateId].GetCharacterPropertyBonusInt(type) <= 0)
		{
			return 0;
		}
		CValuePercent factor = implement.SubAttributeFactor;
		return GradePlus2 * factor;
	}

	private int CalcEquipAddPropertyFood(SkillBreakBonusEffectImplementItem implement, ECharacterPropertyReferencedType type)
	{
		if (ItemType != 7 || !implement.AddMainAttribute || !type.IsMainAttribute())
		{
			return 0;
		}
		FoodItem config = Food.Instance[ItemTemplateId];
		if (config != null)
		{
			return config.MainAttributesRegen[(int)type] / 10;
		}
		return 0;
	}

	private int CalcEquipAddPropertyAssist(SkillBreakBonusEffectImplementItem implement, ECharacterPropertyReferencedType type)
	{
		int addValue = (Grade + 3) * 2;
		if ((type == ECharacterPropertyReferencedType.HitRateStrength || type == ECharacterPropertyReferencedType.AvoidRateStrength) ? true : false)
		{
			if (!implement.AddHitAvoidStrength)
			{
				return 0;
			}
			return addValue;
		}
		if ((type == ECharacterPropertyReferencedType.HitRateTechnique || type == ECharacterPropertyReferencedType.AvoidRateTechnique) ? true : false)
		{
			if (!implement.AddHitAvoidTechnique)
			{
				return 0;
			}
			return addValue;
		}
		if ((type == ECharacterPropertyReferencedType.HitRateSpeed || type == ECharacterPropertyReferencedType.AvoidRateSpeed) ? true : false)
		{
			if (!implement.AddHitAvoidSpeed)
			{
				return 0;
			}
			return addValue;
		}
		if ((type == ECharacterPropertyReferencedType.HitRateMind || type == ECharacterPropertyReferencedType.AvoidRateMind) ? true : false)
		{
			if (!implement.AddHitAvoidMind)
			{
				return 0;
			}
			return addValue;
		}
		return 0;
	}

	private int CalcEquipAddPropertyRelation(SkillBreakBonusEffectImplementItem implement, ECharacterPropertyReferencedType type)
	{
		if (Type != ESkillBreakPlateBonusType.Relation)
		{
			return 0;
		}
		if (implement.RelationAddHitMind && type == ECharacterPropertyReferencedType.HitRateMind)
		{
			if (Favorability <= 0)
			{
				return 0;
			}
			return Favorability / 1000;
		}
		if (implement.RelationAddAvoidMind && type == ECharacterPropertyReferencedType.AvoidRateMind)
		{
			if (Favorability >= 0)
			{
				return 0;
			}
			return -Favorability / 1000;
		}
		return 0;
	}

	public int CalcReduceRequirements(sbyte equipType)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || !implement.ReduceRequirements)
		{
			return 0;
		}
		if (Type == ESkillBreakPlateBonusType.Exp)
		{
			return SkillBreakPlateConstants.ExpEffectValues[ExpLevel];
		}
		return 0;
	}

	public int CalcAddPower(sbyte equipType)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || !implement.AddPower)
		{
			return 0;
		}
		if (Type != ESkillBreakPlateBonusType.Friend)
		{
			return 0;
		}
		int favorabilityValue = SkillBreakPlateConstants.FriendLevelValues.GetClampedIndexValue(FavorabilityType);
		int addPower = FriendAttainment * favorabilityValue / SkillBreakPlateConstants.FriendAddPowerDivisor;
		return SkillBreakPlateConstants.FriendAddPowerBase + MathUtils.Clamp(addPower, SkillBreakPlateConstants.FriendAddPowerExtraMin, SkillBreakPlateConstants.FriendAddPowerExtraMax);
	}

	public int CalcInnerRatioChangeRange(sbyte equipType)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || !implement.InnerRatioChangeRange)
		{
			return 0;
		}
		return GradePlus2 * 2;
	}

	public sbyte CalcSpecificGridCount(sbyte equipType)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(0);
		if (implement != null)
		{
			return implement.SpecificGrids[equipType - 1];
		}
		return 0;
	}

	public short CalcAddOtherSkillMaxPower(sbyte equipType)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(0);
		if (implement == null || implement.AddMaxPowerEquipType != equipType)
		{
			return 0;
		}
		return (short)MathUtils.Max(Grade - 2, 1);
	}

	public int CalcTotalObtainableNeili()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(0);
		if (implement == null || implement.TotalObtainableNeili <= 0)
		{
			return 0;
		}
		return GradePlus2 * implement.TotalObtainableNeili;
	}

	public int CalcAddAttackRange(bool forward)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(1);
		if (implement == null)
		{
			return 0;
		}
		if (forward ? (!implement.AttackRangeForward) : (!implement.AttackRangeBackward))
		{
			return 0;
		}
		return Grade;
	}

	public int CalcMakeDamage()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(1);
		if (implement == null || !implement.MakeDamage)
		{
			return 0;
		}
		return Grade + 3;
	}

	public int CalcTotalHit()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(1);
		if (implement == null || !implement.AttackSkillHitFactor)
		{
			return 0;
		}
		return Grade + 3;
	}

	public int CalcPoison(sbyte poisonType)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(1);
		if (implement == null || !implement.PoisonFactor)
		{
			return 0;
		}
		if (ItemType != 8)
		{
			return 0;
		}
		if (Medicine.Instance[ItemTemplateId]?.PoisonType != poisonType)
		{
			return 0;
		}
		return GradePlus2 * 2;
	}

	public int CalcCostMobilityByFrame()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(2);
		if (implement == null || !implement.CostMobilityByFrame)
		{
			return 0;
		}
		return -(Grade + 3);
	}

	public int CalcCostMobilityByMove()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(2);
		if (implement == null || !implement.CostMobilityByMove)
		{
			return 0;
		}
		return -(Grade + 3);
	}

	public int CalcCostMobilityByCast()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(2);
		if (implement == null || implement.CostMobilityByCastFactor <= 0)
		{
			return 0;
		}
		return -(Grade + 3) * implement.CostMobilityByCastFactor;
	}

	public int CalcAddHitOnCast()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(2);
		if (implement == null || !implement.AgileSkillHitFactor)
		{
			return 0;
		}
		return Grade + 3;
	}

	public int CalcFightBackPower()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(3);
		if (implement == null || !implement.FightBackPower)
		{
			return 0;
		}
		return (Grade + 3) * 2;
	}

	public int CalcBouncePower()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(3);
		if (implement == null || !implement.BouncePower)
		{
			return 0;
		}
		return (Grade + 3) * 2;
	}

	public int CalcAddPenetrateResist()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(3);
		if (implement == null || !implement.DefensePenetrateResistFactor)
		{
			return 0;
		}
		return Grade + 3;
	}

	public int CalcAddAvoidValueOnCast()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(3);
		if (implement == null || !implement.DefenseAvoidFactor)
		{
			return 0;
		}
		return Grade + 3;
	}

	public bool Equals(SkillBreakPlateBonus other)
	{
		if (_internalType == other._internalType && _internalValue0 == other._internalValue0 && _internalValue1 == other._internalValue1 && _internalValue2 == other._internalValue2)
		{
			return _internalValue3 == other._internalValue3;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is SkillBreakPlateBonus other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (((((((_internalType.GetHashCode() * 397) ^ _internalValue0) * 397) ^ _internalValue1) * 397) ^ _internalValue2) * 397) ^ _internalValue3;
	}

	public static bool operator ==(SkillBreakPlateBonus left, SkillBreakPlateBonus right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SkillBreakPlateBonus left, SkillBreakPlateBonus right)
	{
		return !left.Equals(right);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 19;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 5;
		byte* num = pData + 2;
		*num = (byte)(sbyte)_internalType;
		byte* num2 = num + 1;
		*(int*)num2 = _internalValue0;
		byte* num3 = num2 + 4;
		*(int*)num3 = _internalValue1;
		byte* num4 = num3 + 4;
		*(int*)num4 = _internalValue2;
		byte* num5 = num4 + 4;
		*(int*)num5 = _internalValue3;
		int totalSize = (int)(num5 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			_internalType = (ESkillBreakPlateBonusType)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			_internalValue0 = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			_internalValue1 = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 3)
		{
			_internalValue2 = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 4)
		{
			_internalValue3 = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
