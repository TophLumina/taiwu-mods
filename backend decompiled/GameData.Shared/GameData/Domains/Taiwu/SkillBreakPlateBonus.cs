using System;
using Config;
using GameData.Combat.Math;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 功法突破盘玄机格数据
/// </summary>
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

	/// <summary>
	/// 用于序列化的类型
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	private ESkillBreakPlateBonusType _internalType;

	/// <summary>
	/// 用于序列化的值一
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	private int _internalValue0;

	/// <summary>
	/// 用于序列化的值二
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	private int _internalValue1;

	/// <summary>
	/// 用于序列化的值三
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	private int _internalValue2;

	/// <summary>
	/// 用于序列化的值四
	/// </summary>
	[SerializableGameDataField(FieldIndex = 4)]
	private int _internalValue3;

	/// <summary>
	/// 无效值
	/// </summary>
	public static SkillBreakPlateBonus Invalid => default(SkillBreakPlateBonus);

	/// <summary>
	/// 玄机格类型
	/// </summary>
	public ESkillBreakPlateBonusType Type => _internalType;

	/// <summary>
	/// 影响范围
	/// </summary>
	public int ImpactRange => Type switch
	{
		ESkillBreakPlateBonusType.None => 0, 
		ESkillBreakPlateBonusType.Item => (Grade + 3) / 3, 
		ESkillBreakPlateBonusType.Relation => (FavorabilityLevel + 3) / 3, 
		ESkillBreakPlateBonusType.Exp => (ExpLevel + 3) / 3, 
		ESkillBreakPlateBonusType.Friend => (Grade + 3) / 3, 
		_ => 0, 
	};

	/// <summary>
	/// 玄机品级
	/// </summary>
	public sbyte Grade => (sbyte)MathUtils.Clamp(Type switch
	{
		ESkillBreakPlateBonusType.None => 0, 
		ESkillBreakPlateBonusType.Item => ItemTemplateHelper.GetGrade(ItemType, ItemTemplateId), 
		ESkillBreakPlateBonusType.Relation => FavorabilityLevel, 
		ESkillBreakPlateBonusType.Exp => ExpLevel, 
		ESkillBreakPlateBonusType.Friend => FriendAttainment / SkillBreakPlateConstants.FriendGradeDivisor - SkillBreakPlateConstants.FriendGradeMinus, 
		_ => 0, 
	}, 0, 8);

	/// <summary>
	/// 补正后的道具类玄机品级
	/// </summary>
	private int GradePlus2 => Grade + 2;

	/// <summary>
	/// 玄机效果
	/// </summary>
	public SkillBreakBonusEffectItem Effect => Type switch
	{
		ESkillBreakPlateBonusType.Item => SkillBreakBonusEffect.Instance[ItemTemplateHelper.GetBreakBonusEffect(ItemType, ItemTemplateId)], 
		ESkillBreakPlateBonusType.Relation => SkillBreakBonusEffect.Instance[(sbyte)((RelationType == 16384) ? 33 : 34)], 
		ESkillBreakPlateBonusType.Exp => SkillBreakBonusEffect.Instance[(sbyte)37], 
		ESkillBreakPlateBonusType.Friend => SkillBreakBonusEffect.Instance[(sbyte)47], 
		_ => null, 
	};

	/// <summary>
	/// 道具类型
	/// </summary>
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

	/// <summary>
	/// 道具模板 ID
	/// </summary>
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

	/// <summary>
	/// 药物作用类型
	/// </summary>
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

	/// <summary>
	/// 是否有关联人物
	/// </summary>
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

	/// <summary>
	/// 关系人物 ID
	/// </summary>
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

	/// <summary>
	/// 关系关联人物 ID
	/// </summary>
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

	/// <summary>
	/// 关系键
	/// </summary>
	public RelationKey RelationKey => new RelationKey(RelationCharId, RelationRelatedCharId);

	/// <summary>
	/// 关系类型
	/// </summary>
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

	/// <summary>
	/// 好感值
	/// </summary>
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

	/// <summary>
	/// 好感类型
	/// </summary>
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

	/// <summary>
	/// 关系级别（判断正负方向后的关系类型）
	/// </summary>
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

	/// <summary>
	/// 历练档位
	/// </summary>
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

	/// <summary>
	/// 亲友功法造诣值
	/// </summary>
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

	/// <inheritdoc />
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

	/// <summary>
	/// 基于道具创建
	/// </summary>
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

	/// <summary>
	/// 基于历练创建
	/// </summary>
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

	/// <summary>
	/// 基于关系创建
	/// </summary>
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

	/// <summary>
	/// 基于亲友创建
	/// </summary>
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

	/// <summary>
	/// 基于虚空亲友创建，少林佛像使用
	/// </summary>
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

	/// <summary>
	/// 判断是否需要移除当前玄机格加成数据
	/// </summary>
	/// <returns></returns>
	public bool ShouldBeRemoved()
	{
		return Type == ESkillBreakPlateBonusType.None;
	}

	/// <summary>
	/// 重置关系类玄机的角色 ID
	/// </summary>
	public SkillBreakPlateBonus ResetRelationCharIds()
	{
		if (HasRelationKey)
		{
			_internalValue2 = (_internalValue3 = -1);
		}
		return this;
	}

	/// <summary>
	/// 对于指定功法是否可用
	/// </summary>
	/// <param name="skillId">功法 ID</param>
	/// <returns></returns>
	public bool IsMatch(short skillId)
	{
		return Config.CombatSkill.Instance[skillId].MatchBreakPlateBonusEffect(Effect);
	}

	/// <summary>
	/// 获取玄机效果实现
	/// </summary>
	/// <param name="equipType">功法装配类型</param>
	/// <returns></returns>
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

	/// <summary>
	/// 计算加成的造诣需求
	/// </summary>
	public int CalcAddLifeSkillRequirement(sbyte equipType, ref LifeSkillShorts lifeSkillAttainments)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || implement.AddRequirementType < 0)
		{
			return 0;
		}
		return MathUtils.Max(lifeSkillAttainments[implement.AddRequirementType] * GradePlus2 / 100, 1);
	}

	/// <summary>
	/// 计算减少的提气值百分比
	/// </summary>
	public int CalcReduceCostBreath(sbyte equipType, ref LifeSkillShorts lifeSkillAttainments)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || implement.ReduceCostBreathType < 0)
		{
			return 0;
		}
		return MathUtils.Clamp(lifeSkillAttainments[implement.ReduceCostBreathType] * GradePlus2 / 1000, 1, 5);
	}

	/// <summary>
	/// 计算减少的架势值百分比
	/// </summary>
	public int CalcReduceCostStance(sbyte equipType, ref LifeSkillShorts lifeSkillAttainments)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || implement.ReduceCostStanceType < 0)
		{
			return 0;
		}
		return MathUtils.Clamp(lifeSkillAttainments[implement.ReduceCostStanceType] * GradePlus2 / 1000, 1, 5);
	}

	/// <summary>
	/// 计算减少的施展时间百分比
	/// </summary>
	public int CalcReduceCastFrame(sbyte equipType, ref LifeSkillShorts lifeSkillAttainments)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || implement.ReduceCastFrameType < 0)
		{
			return 0;
		}
		return MathUtils.Clamp(lifeSkillAttainments[implement.ReduceCastFrameType] * GradePlus2 / 500, 1, 10);
	}

	/// <summary>
	/// 计算增加的威力上限值
	/// </summary>
	public int CalcAddMaxPower(sbyte equipType, ref LifeSkillShorts lifeSkillAttainments)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || implement.AddMaxPowerType < 0)
		{
			return 0;
		}
		return MathUtils.Clamp(lifeSkillAttainments[implement.AddMaxPowerType] * GradePlus2 / 500, 1, 10);
	}

	/// <summary>
	/// 计算提高的伤势阈值百分比
	/// </summary>
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

	/// <summary>
	/// 计算提高的重创阈值百分比
	/// </summary>
	/// <param name="equipType"></param>
	/// <returns></returns>
	public int CalcAddFatalStep(sbyte equipType)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || !implement.AddFatalStep)
		{
			return 0;
		}
		return 5 + GradePlus2 * 2;
	}

	/// <summary>
	/// 计算提高的失神阈值百分比
	/// </summary>
	/// <param name="equipType"></param>
	/// <returns></returns>
	public int CalcAddMindStep(sbyte equipType)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || !implement.AddMindStep)
		{
			return 0;
		}
		return 5 + GradePlus2 * 2;
	}

	/// <summary>
	/// 计算运功加成数据
	/// </summary>
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

	/// <summary>
	/// 计算运功加成数据 - 药物类
	/// </summary>
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

	/// <summary>
	/// 计算运功加成数据 - 药物类 - 加成系数
	/// </summary>
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

	/// <summary>
	/// 计算运功加成数据 - 茶酒类
	/// </summary>
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

	/// <summary>
	/// 计算运功加成数据 - 食物类
	/// </summary>
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

	/// <summary>
	/// 计算运功加成数据 - 奇窍加成
	/// </summary>
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

	/// <summary>
	/// 计算运功加成数据 - 关系加成
	/// </summary>
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

	/// <summary>
	/// 计算减少的使用需求百分比
	/// </summary>
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

	/// <summary>
	/// 计算增加的威力值
	/// </summary>
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

	/// <summary>
	/// 计算增加的内外比例变化范围
	/// </summary>
	public int CalcInnerRatioChangeRange(sbyte equipType)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(equipType);
		if (implement == null || !implement.InnerRatioChangeRange)
		{
			return 0;
		}
		return GradePlus2 * 2;
	}

	/// <summary>
	/// 计算提供的功法栏位
	/// </summary>
	public sbyte CalcSpecificGridCount(sbyte equipType)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(0);
		if (implement != null)
		{
			return implement.SpecificGrids[equipType - 1];
		}
		return 0;
	}

	/// <summary>
	/// 计算提供的威力上限
	/// </summary>
	public short CalcAddOtherSkillMaxPower(sbyte equipType)
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(0);
		if (implement == null || implement.AddMaxPowerEquipType != equipType)
		{
			return 0;
		}
		return (short)MathUtils.Max(Grade - 2, 1);
	}

	/// <summary>
	/// 计算提供的内力总量
	/// </summary>
	public int CalcTotalObtainableNeili()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(0);
		if (implement == null || implement.TotalObtainableNeili <= 0)
		{
			return 0;
		}
		return GradePlus2 * implement.TotalObtainableNeili;
	}

	/// <summary>
	/// 计算攻击范围
	/// </summary>
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

	/// <summary>
	/// 计算提高伤害百分比加成
	/// </summary>
	public int CalcMakeDamage()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(1);
		if (implement == null || !implement.MakeDamage)
		{
			return 0;
		}
		return Grade + 3;
	}

	/// <summary>
	/// 计算总命中百分比加成
	/// </summary>
	public int CalcTotalHit()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(1);
		if (implement == null || !implement.AttackSkillHitFactor)
		{
			return 0;
		}
		return Grade + 3;
	}

	/// <summary>
	/// 计算功法毒素百分比加成
	/// </summary>
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

	/// <summary>
	/// 计算脚力持续消耗百分比加成
	/// </summary>
	public int CalcCostMobilityByFrame()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(2);
		if (implement == null || !implement.CostMobilityByFrame)
		{
			return 0;
		}
		return -(Grade + 3);
	}

	/// <summary>
	/// 计算脚力移动消耗百分比加成
	/// </summary>
	public int CalcCostMobilityByMove()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(2);
		if (implement == null || !implement.CostMobilityByMove)
		{
			return 0;
		}
		return -(Grade + 3);
	}

	/// <summary>
	/// 计算移动间隔影响百分比加成
	/// </summary>
	public int CalcCostMobilityByCast()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(2);
		if (implement == null || implement.CostMobilityByCastFactor <= 0)
		{
			return 0;
		}
		return -(Grade + 3) * implement.CostMobilityByCastFactor;
	}

	/// <summary>
	/// 计算身法命中百分比加成
	/// </summary>
	public int CalcAddHitOnCast()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(2);
		if (implement == null || !implement.AgileSkillHitFactor)
		{
			return 0;
		}
		return Grade + 3;
	}

	/// <summary>
	/// 计算反击威力百分比加成
	/// </summary>
	public int CalcFightBackPower()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(3);
		if (implement == null || !implement.FightBackPower)
		{
			return 0;
		}
		return (Grade + 3) * 2;
	}

	/// <summary>
	/// 计算反震威力百分比加成
	/// </summary>
	public int CalcBouncePower()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(3);
		if (implement == null || !implement.BouncePower)
		{
			return 0;
		}
		return (Grade + 3) * 2;
	}

	/// <summary>
	/// 计算防御系数百分比加成
	/// </summary>
	public int CalcAddPenetrateResist()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(3);
		if (implement == null || !implement.DefensePenetrateResistFactor)
		{
			return 0;
		}
		return Grade + 3;
	}

	/// <summary>
	/// 计算化解系数百分比加成
	/// </summary>
	public int CalcAddAvoidValueOnCast()
	{
		SkillBreakBonusEffectImplementItem implement = GetImplement(3);
		if (implement == null || !implement.DefenseAvoidFactor)
		{
			return 0;
		}
		return Grade + 3;
	}

	/// <inheritdoc />
	public bool Equals(SkillBreakPlateBonus other)
	{
		if (_internalType == other._internalType && _internalValue0 == other._internalValue0 && _internalValue1 == other._internalValue1 && _internalValue2 == other._internalValue2)
		{
			return _internalValue3 == other._internalValue3;
		}
		return false;
	}

	/// <inheritdoc />
	public override bool Equals(object obj)
	{
		if (obj is SkillBreakPlateBonus other)
		{
			return Equals(other);
		}
		return false;
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return (((((((_internalType.GetHashCode() * 397) ^ _internalValue0) * 397) ^ _internalValue1) * 397) ^ _internalValue2) * 397) ^ _internalValue3;
	}

	/// <summary>
	/// 等于
	/// </summary>
	public static bool operator ==(SkillBreakPlateBonus left, SkillBreakPlateBonus right)
	{
		return left.Equals(right);
	}

	/// <summary>
	/// 不等
	/// </summary>
	public static bool operator !=(SkillBreakPlateBonus left, SkillBreakPlateBonus right)
	{
		return !left.Equals(right);
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 19;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
