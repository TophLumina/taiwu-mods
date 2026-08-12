using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.CombatSkill;

/// <summary>
/// 功法显示数据。用于向前端返回显示所需数据，使前端不必监听功法数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class CombatSkillDisplayData : ISerializableGameData, IFilterableCombatSkill
{
	/// <summary>
	/// 人物ID
	/// </summary>
	[SerializableGameDataField]
	public int CharId;

	/// <summary>
	/// 功法模板ID
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 修习等级
	/// </summary>
	[Obsolete("This field is deprecated in favour of the new combat skill.")]
	public sbyte PracticeLevel;

	/// <summary>
	/// 研读状态
	/// </summary>
	[SerializableGameDataField]
	public ushort ReadingState;

	/// <summary>
	/// 激活状态
	/// </summary>
	[SerializableGameDataField]
	public ushort ActivationState;

	/// <summary>
	/// 生效状态
	/// </summary>
	[SerializableGameDataField]
	public bool CanAffect;

	/// <summary>
	/// 冲突状态
	/// </summary>
	[SerializableGameDataField]
	public bool Conflicting;

	/// <summary>
	/// 占用格数
	/// </summary>
	[SerializableGameDataField]
	public sbyte GridCount;

	/// <summary>
	/// 威力
	/// </summary>
	[SerializableGameDataField]
	public short Power;

	/// <summary>
	/// 威力上限
	/// </summary>
	[SerializableGameDataField]
	public short MaxPower;

	/// <summary>
	/// 发挥威力
	/// </summary>
	[SerializableGameDataField]
	public short RequirementsPower;

	/// <summary>
	/// 使用需求
	/// </summary>
	[SerializableGameDataField]
	public List<(int type, int required, int actual)> Requirements;

	/// <summary>
	/// 突破格属性加成
	/// </summary>
	[SerializableGameDataField]
	public List<(short id, short bonus, bool isExtra)> BreakAddProperty;

	/// <summary>
	/// 真气属性加成，propertyId 强转为 <see cref="T:ECharacterPropertyReferencedType" /> 使用
	/// </summary>
	[SerializableGameDataField]
	public List<(short propertyId, int bonus)> NeiliAllocationAddProperty;

	/// <summary>
	/// 当前突破盘索引
	/// </summary>
	[SerializableGameDataField]
	public sbyte BreakPlateIndex;

	/// <summary>
	/// 特效类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte EffectType;

	/// <summary>
	/// 是否精解
	/// </summary>
	[SerializableGameDataField]
	public bool Mastered;

	/// <summary>
	/// 是否为预览精解数据
	/// </summary>
	[SerializableGameDataField]
	public bool PreviewMastered;

	/// <summary>
	/// 是否废除
	/// </summary>
	[SerializableGameDataField]
	public bool Revoked;

	/// <summary>
	/// 跳跃阈值，负数为不可设置，未设置时此处会返回默认值
	/// </summary>
	[SerializableGameDataField]
	public short JumpThreshold;

	/// <summary>
	/// 基础内功比例
	/// </summary>
	[SerializableGameDataField]
	public sbyte BaseInnerRatio;

	/// <summary>
	/// 内功比例变化范围
	/// </summary>
	[SerializableGameDataField]
	public sbyte InnerRatioChangeRange;

	/// <summary>
	/// 当前内功比例
	/// </summary>
	[SerializableGameDataField]
	public sbyte CurrInnerRatio;

	/// <summary>
	/// 期望内功比例
	/// </summary>
	[SerializableGameDataField]
	public sbyte ExpectInnerRatio;

	/// <summary>
	/// 参悟新法所需历练
	/// </summary>
	[SerializableGameDataField]
	public int NewUnderstandingNeedExp;

	/// <summary>
	/// 已经突破成功
	/// </summary>
	[SerializableGameDataField]
	public bool BreakSuccess;

	/// <summary>
	/// 特效描述数据
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillEffectDescriptionDisplayData EffectDescription;

	/// <summary>
	/// 伤害阈值加成数据
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillDamageStepBonusDisplayData DamageStepBonus;

	/// <summary>
	/// 各部位伤害阈值（强健）是否是当前生效的
	/// 索引0~6对应BodyPartType 7个部位，索引7对应重创，索引8对应失神
	/// </summary>
	[SerializableGameDataField]
	public List<bool> BodyPartDamageStepActive;

	/// <summary>
	/// 玄机品级
	/// </summary>
	[SerializableGameDataField]
	public List<sbyte> BreakBonusGrades;

	/// <summary>
	/// 功法是否装配中。
	/// 太吾的所有预设里包含都算；npc只有当前装配才算。
	/// </summary>
	[SerializableGameDataField]
	public bool IsInAnyEquipPlans;

	/// <summary>
	/// 是否包含峨眉独创心法
	/// </summary>
	[SerializableGameDataField]
	public bool HasSectEmeiSkillBreakBonus;

	/// <summary>
	/// 罗汉偶像Id
	/// </summary>
	[SerializableGameDataField]
	public sbyte LuohanId;

	/// <summary>
	/// 当前功法在奇书中占用的槽位对应的 LegendaryBookSlot TemplateId 列表。
	/// 为空表示该功法未放入奇书。
	/// </summary>
	[SerializableGameDataField]
	public List<short> LegendaryBookSlotIds;

	/// <summary>
	/// 可获得的最大内力值
	/// </summary>
	[SerializableGameDataField]
	public short MaxObtainableNeili;

	/// <summary>
	/// 已获得的内力值
	/// </summary>
	[SerializableGameDataField]
	public short ObtainedNeili;

	/// <summary>
	/// 专用功法格数
	/// </summary>
	[SerializableGameDataField]
	public sbyte[] SpecificGrids = new sbyte[4];

	/// <summary>
	/// 万用格数
	/// </summary>
	[SerializableGameDataField]
	public sbyte GenericGrid;

	/// <summary>
	/// 施展时最小攻击距离加成
	/// </summary>
	[SerializableGameDataField]
	public short AddAttackDistanceForward;

	/// <summary>
	/// 施展时最大攻击距离加成
	/// </summary>
	[SerializableGameDataField]
	public short AddAttackDistanceBackward;

	/// <summary>
	/// 力道命中
	/// </summary>
	[SerializableGameDataField]
	public int HitValueStrength;

	/// <summary>
	/// 精妙命中
	/// </summary>
	[SerializableGameDataField]
	public int HitValueTechnique;

	/// <summary>
	/// 迅疾命中
	/// </summary>
	[SerializableGameDataField]
	public int HitValueSpeed;

	/// <summary>
	/// 心神命中
	/// </summary>
	[SerializableGameDataField]
	public int HitValueMind;

	/// <summary>
	/// 破体
	/// </summary>
	[SerializableGameDataField]
	public int PenetrateValueOuter;

	/// <summary>
	/// 破气
	/// </summary>
	[SerializableGameDataField]
	public int PenetrateValueInner;

	/// <summary>
	/// 含有毒素
	/// </summary>
	[SerializableGameDataField]
	public PoisonsAndLevels Poisons;

	/// <summary>
	/// 成数分布
	/// </summary>
	[SerializableGameDataField]
	public HitOrAvoidInts HitDistribution;

	/// <summary>
	/// 攻击部位权重
	/// </summary>
	[SerializableGameDataField]
	public List<int> BodyPartWeights;

	/// <summary>
	/// 发挥十成威力次数，太吾专属数据
	/// </summary>
	[SerializableGameDataField]
	public sbyte FullPowerCastTimes;

	/// <summary>
	/// 功法是否被收藏，太吾专属数据
	/// </summary>
	[SerializableGameDataField]
	public bool IsFavorite;

	/// <summary>
	/// 蓄力移动速度
	/// </summary>
	[SerializableGameDataField]
	public int JumpSpeed;

	/// <summary>
	/// 移动速度加成值
	/// </summary>
	[SerializableGameDataField]
	public short AddMoveSpeed;

	/// <summary>
	/// 移动速度百分比加成值
	/// </summary>
	[SerializableGameDataField]
	public short AddPercentMoveSpeed;

	/// <summary>
	/// 力道加成值
	/// </summary>
	[SerializableGameDataField]
	public int AddHitStrength;

	/// <summary>
	/// 精妙加成值
	/// </summary>
	[SerializableGameDataField]
	public int AddHitTechnique;

	/// <summary>
	/// 迅疾加成值
	/// </summary>
	[SerializableGameDataField]
	public int AddHitSpeed;

	/// <summary>
	/// 动心加成值
	/// </summary>
	[SerializableGameDataField]
	public int AddHitMind;

	/// <summary>
	/// 御气加成值
	/// </summary>
	[SerializableGameDataField]
	public int AddInnerDef;

	/// <summary>
	/// 御体加成值
	/// </summary>
	[SerializableGameDataField]
	public int AddOuterDef;

	/// <summary>
	/// 卸力加成值
	/// </summary>
	[SerializableGameDataField]
	public int AddAvoidStrength;

	/// <summary>
	/// 拆招加成值
	/// </summary>
	[SerializableGameDataField]
	public int AddAvoidTechnique;

	/// <summary>
	/// 闪避加成值
	/// </summary>
	[SerializableGameDataField]
	public int AddAvoidSpeed;

	/// <summary>
	/// 守心加成值
	/// </summary>
	[SerializableGameDataField]
	public int AddAvoidMind;

	/// <summary>
	/// 外伤反震威力
	/// </summary>
	[SerializableGameDataField]
	public int BouncePowerOuter;

	/// <summary>
	/// 内伤反震威力
	/// </summary>
	[SerializableGameDataField]
	public int BouncePowerInner;

	/// <summary>
	/// 反震距离
	/// </summary>
	[SerializableGameDataField]
	public short BounceDistance;

	/// <summary>
	/// 反击威力
	/// </summary>
	[SerializableGameDataField]
	public int FightbackPower;

	/// <summary>
	/// 持续时间
	/// </summary>
	[SerializableGameDataField]
	public short EffectDuration;

	/// <summary>
	/// 施展消耗移动力
	/// </summary>
	[SerializableGameDataField]
	public short CostMobility;

	/// <summary>
	/// 施展消耗移动力字体类型。0-战斗外、1-够、2-不够
	/// </summary>
	[SerializableGameDataField]
	public sbyte CostMobilityFontType;

	/// <summary>
	/// 施展消耗式
	/// </summary>
	[SerializableGameDataField]
	public List<NeedTrick> CostTricks;

	/// <summary>
	/// 施展消耗式字体类型。0-战斗外、1-够、2-不够
	/// </summary>
	[SerializableGameDataField]
	public List<sbyte> CostTricksFontType;

	/// <summary>
	/// 施展消耗提气
	/// </summary>
	[SerializableGameDataField]
	public sbyte CostBreath;

	/// <summary>
	/// 施展消耗提气字体类型。0-战斗外、1-够、2-不够
	/// </summary>
	[SerializableGameDataField]
	public sbyte CostBreathFontType;

	/// <summary>
	/// 施展消耗架势
	/// </summary>
	[SerializableGameDataField]
	public sbyte CostStance;

	/// <summary>
	/// 施展消耗架势字体类型。0-战斗外、1-够、2-不够
	/// </summary>
	[SerializableGameDataField]
	public sbyte CostStanceFontType;

	/// <summary>
	/// 施展消耗真气(类型, 真气值)
	/// </summary>
	[SerializableGameDataField]
	public (sbyte, sbyte) CostNeiliAllocation;

	/// <summary>
	/// 施展消耗真气字体类型。0-战斗外、1-够、2-不够
	/// </summary>
	[SerializableGameDataField]
	public sbyte CostNeiliAllocationFontType;

	/// <summary>
	/// 施展消耗武器耐久字体类型。0-战斗外、1-够、2-不够
	/// </summary>
	[SerializableGameDataField]
	public sbyte CostWeaponDurabilityFontType;

	/// <summary>
	/// 施展消耗蛊引字体类型。0-战斗外、1-够、2-不够
	/// </summary>
	[SerializableGameDataField]
	public sbyte CostWugFontType;

	/// <summary>
	/// 实际五行转移目标，太吾需要考虑周天策略等，下同
	/// </summary>
	[SerializableGameDataField]
	public sbyte FiveElementDestTypeWhileLooping;

	/// <summary>
	/// 实际五行转移类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte FiveElementTransferTypeWhileLooping;

	/// <summary>
	/// 功法效果数据
	/// </summary>
	[SerializableGameDataField]
	public List<CombatSkillEffectData> EffectData;

	short IFilterableCombatSkill.TemplateId => TemplateId;

	sbyte IFilterableCombatSkill.Type => SkillConfig.Type;

	sbyte IFilterableCombatSkill.SectId => SkillConfig.SectId;

	ushort IFilterableCombatSkill.ActivationState => ActivationState;

	bool IFilterableCombatSkill.IsInAnyEquipPlans => IsInAnyEquipPlans;

	bool IFilterableCombatSkill.HasSectEmeiSkillBreakBonus => HasSectEmeiSkillBreakBonus;

	short IFilterableCombatSkill.Power => Power;

	List<sbyte> IFilterableCombatSkill.BreakBonusGrades => BreakBonusGrades;

	ushort IFilterableCombatSkill.ReadingState => ReadingState;

	short IFilterableCombatSkill.MaxObtainableNeili => MaxObtainableNeili;

	short IFilterableCombatSkill.ObtainedNeili => ObtainedNeili;

	int IFilterableCombatSkill.CombatSkillProficiency
	{
		get
		{
			if (Requirements != null)
			{
				foreach (var req in Requirements)
				{
					if (req.type == 110)
					{
						return req.actual;
					}
				}
			}
			return 0;
		}
	}

	sbyte IFilterableCombatSkill.FiveElementTransferTypeWhileLooping
	{
		get
		{
			return FiveElementTransferTypeWhileLooping;
		}
		set
		{
			FiveElementTransferTypeWhileLooping = value;
		}
	}

	sbyte IFilterableCombatSkill.FiveElementDestTypeWhileLooping
	{
		get
		{
			return FiveElementDestTypeWhileLooping;
		}
		set
		{
			FiveElementDestTypeWhileLooping = value;
		}
	}

	private CombatSkillItem SkillConfig => Config.CombatSkill.Instance[TemplateId];

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CombatSkillDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CombatSkillDisplayData(CombatSkillDisplayData other)
	{
		CharId = other.CharId;
		TemplateId = other.TemplateId;
		ReadingState = other.ReadingState;
		ActivationState = other.ActivationState;
		CanAffect = other.CanAffect;
		Conflicting = other.Conflicting;
		GridCount = other.GridCount;
		Power = other.Power;
		MaxPower = other.MaxPower;
		RequirementsPower = other.RequirementsPower;
		Requirements = ((other.Requirements == null) ? null : new List<(int, int, int)>(other.Requirements));
		BreakAddProperty = ((other.BreakAddProperty == null) ? null : new List<(short, short, bool)>(other.BreakAddProperty));
		NeiliAllocationAddProperty = ((other.NeiliAllocationAddProperty == null) ? null : new List<(short, int)>(other.NeiliAllocationAddProperty));
		BreakPlateIndex = other.BreakPlateIndex;
		EffectType = other.EffectType;
		Mastered = other.Mastered;
		PreviewMastered = other.PreviewMastered;
		Revoked = other.Revoked;
		JumpThreshold = other.JumpThreshold;
		BaseInnerRatio = other.BaseInnerRatio;
		InnerRatioChangeRange = other.InnerRatioChangeRange;
		CurrInnerRatio = other.CurrInnerRatio;
		ExpectInnerRatio = other.ExpectInnerRatio;
		NewUnderstandingNeedExp = other.NewUnderstandingNeedExp;
		BreakSuccess = other.BreakSuccess;
		EffectDescription = new CombatSkillEffectDescriptionDisplayData(other.EffectDescription);
		DamageStepBonus = other.DamageStepBonus;
		BodyPartDamageStepActive = ((other.BodyPartDamageStepActive == null) ? null : new List<bool>(other.BodyPartDamageStepActive));
		BreakBonusGrades = ((other.BreakBonusGrades == null) ? null : new List<sbyte>(other.BreakBonusGrades));
		IsInAnyEquipPlans = other.IsInAnyEquipPlans;
		HasSectEmeiSkillBreakBonus = other.HasSectEmeiSkillBreakBonus;
		LuohanId = other.LuohanId;
		LegendaryBookSlotIds = ((other.LegendaryBookSlotIds == null) ? null : new List<short>(other.LegendaryBookSlotIds));
		MaxObtainableNeili = other.MaxObtainableNeili;
		ObtainedNeili = other.ObtainedNeili;
		sbyte[] item = other.SpecificGrids;
		int elementsCount = item.Length;
		SpecificGrids = new sbyte[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			SpecificGrids[i] = item[i];
		}
		GenericGrid = other.GenericGrid;
		AddAttackDistanceForward = other.AddAttackDistanceForward;
		AddAttackDistanceBackward = other.AddAttackDistanceBackward;
		HitValueStrength = other.HitValueStrength;
		HitValueTechnique = other.HitValueTechnique;
		HitValueSpeed = other.HitValueSpeed;
		HitValueMind = other.HitValueMind;
		PenetrateValueOuter = other.PenetrateValueOuter;
		PenetrateValueInner = other.PenetrateValueInner;
		Poisons = other.Poisons;
		HitDistribution = other.HitDistribution;
		BodyPartWeights = ((other.BodyPartWeights == null) ? null : new List<int>(other.BodyPartWeights));
		FullPowerCastTimes = other.FullPowerCastTimes;
		IsFavorite = other.IsFavorite;
		JumpSpeed = other.JumpSpeed;
		AddMoveSpeed = other.AddMoveSpeed;
		AddPercentMoveSpeed = other.AddPercentMoveSpeed;
		AddHitStrength = other.AddHitStrength;
		AddHitTechnique = other.AddHitTechnique;
		AddHitSpeed = other.AddHitSpeed;
		AddHitMind = other.AddHitMind;
		AddInnerDef = other.AddInnerDef;
		AddOuterDef = other.AddOuterDef;
		AddAvoidStrength = other.AddAvoidStrength;
		AddAvoidTechnique = other.AddAvoidTechnique;
		AddAvoidSpeed = other.AddAvoidSpeed;
		AddAvoidMind = other.AddAvoidMind;
		BouncePowerOuter = other.BouncePowerOuter;
		BouncePowerInner = other.BouncePowerInner;
		BounceDistance = other.BounceDistance;
		FightbackPower = other.FightbackPower;
		EffectDuration = other.EffectDuration;
		CostMobility = other.CostMobility;
		CostMobilityFontType = other.CostMobilityFontType;
		CostTricks = ((other.CostTricks == null) ? null : new List<NeedTrick>(other.CostTricks));
		CostTricksFontType = ((other.CostTricksFontType == null) ? null : new List<sbyte>(other.CostTricksFontType));
		CostBreath = other.CostBreath;
		CostBreathFontType = other.CostBreathFontType;
		CostStance = other.CostStance;
		CostStanceFontType = other.CostStanceFontType;
		CostNeiliAllocation = other.CostNeiliAllocation;
		CostNeiliAllocationFontType = other.CostNeiliAllocationFontType;
		CostWeaponDurabilityFontType = other.CostWeaponDurabilityFontType;
		CostWugFontType = other.CostWugFontType;
		FiveElementDestTypeWhileLooping = other.FiveElementDestTypeWhileLooping;
		FiveElementTransferTypeWhileLooping = other.FiveElementTransferTypeWhileLooping;
		EffectData = ((other.EffectData == null) ? null : new List<CombatSkillEffectData>(other.EffectData));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CombatSkillDisplayData other)
	{
		CharId = other.CharId;
		TemplateId = other.TemplateId;
		ReadingState = other.ReadingState;
		ActivationState = other.ActivationState;
		CanAffect = other.CanAffect;
		Conflicting = other.Conflicting;
		GridCount = other.GridCount;
		Power = other.Power;
		MaxPower = other.MaxPower;
		RequirementsPower = other.RequirementsPower;
		Requirements = ((other.Requirements == null) ? null : new List<(int, int, int)>(other.Requirements));
		BreakAddProperty = ((other.BreakAddProperty == null) ? null : new List<(short, short, bool)>(other.BreakAddProperty));
		NeiliAllocationAddProperty = ((other.NeiliAllocationAddProperty == null) ? null : new List<(short, int)>(other.NeiliAllocationAddProperty));
		BreakPlateIndex = other.BreakPlateIndex;
		EffectType = other.EffectType;
		Mastered = other.Mastered;
		PreviewMastered = other.PreviewMastered;
		Revoked = other.Revoked;
		JumpThreshold = other.JumpThreshold;
		BaseInnerRatio = other.BaseInnerRatio;
		InnerRatioChangeRange = other.InnerRatioChangeRange;
		CurrInnerRatio = other.CurrInnerRatio;
		ExpectInnerRatio = other.ExpectInnerRatio;
		NewUnderstandingNeedExp = other.NewUnderstandingNeedExp;
		BreakSuccess = other.BreakSuccess;
		EffectDescription = new CombatSkillEffectDescriptionDisplayData(other.EffectDescription);
		DamageStepBonus = other.DamageStepBonus;
		BodyPartDamageStepActive = ((other.BodyPartDamageStepActive == null) ? null : new List<bool>(other.BodyPartDamageStepActive));
		BreakBonusGrades = ((other.BreakBonusGrades == null) ? null : new List<sbyte>(other.BreakBonusGrades));
		IsInAnyEquipPlans = other.IsInAnyEquipPlans;
		HasSectEmeiSkillBreakBonus = other.HasSectEmeiSkillBreakBonus;
		LuohanId = other.LuohanId;
		LegendaryBookSlotIds = ((other.LegendaryBookSlotIds == null) ? null : new List<short>(other.LegendaryBookSlotIds));
		MaxObtainableNeili = other.MaxObtainableNeili;
		ObtainedNeili = other.ObtainedNeili;
		sbyte[] item = other.SpecificGrids;
		int elementsCount = item.Length;
		SpecificGrids = new sbyte[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			SpecificGrids[i] = item[i];
		}
		GenericGrid = other.GenericGrid;
		AddAttackDistanceForward = other.AddAttackDistanceForward;
		AddAttackDistanceBackward = other.AddAttackDistanceBackward;
		HitValueStrength = other.HitValueStrength;
		HitValueTechnique = other.HitValueTechnique;
		HitValueSpeed = other.HitValueSpeed;
		HitValueMind = other.HitValueMind;
		PenetrateValueOuter = other.PenetrateValueOuter;
		PenetrateValueInner = other.PenetrateValueInner;
		Poisons = other.Poisons;
		HitDistribution = other.HitDistribution;
		BodyPartWeights = ((other.BodyPartWeights == null) ? null : new List<int>(other.BodyPartWeights));
		FullPowerCastTimes = other.FullPowerCastTimes;
		IsFavorite = other.IsFavorite;
		JumpSpeed = other.JumpSpeed;
		AddMoveSpeed = other.AddMoveSpeed;
		AddPercentMoveSpeed = other.AddPercentMoveSpeed;
		AddHitStrength = other.AddHitStrength;
		AddHitTechnique = other.AddHitTechnique;
		AddHitSpeed = other.AddHitSpeed;
		AddHitMind = other.AddHitMind;
		AddInnerDef = other.AddInnerDef;
		AddOuterDef = other.AddOuterDef;
		AddAvoidStrength = other.AddAvoidStrength;
		AddAvoidTechnique = other.AddAvoidTechnique;
		AddAvoidSpeed = other.AddAvoidSpeed;
		AddAvoidMind = other.AddAvoidMind;
		BouncePowerOuter = other.BouncePowerOuter;
		BouncePowerInner = other.BouncePowerInner;
		BounceDistance = other.BounceDistance;
		FightbackPower = other.FightbackPower;
		EffectDuration = other.EffectDuration;
		CostMobility = other.CostMobility;
		CostMobilityFontType = other.CostMobilityFontType;
		CostTricks = ((other.CostTricks == null) ? null : new List<NeedTrick>(other.CostTricks));
		CostTricksFontType = ((other.CostTricksFontType == null) ? null : new List<sbyte>(other.CostTricksFontType));
		CostBreath = other.CostBreath;
		CostBreathFontType = other.CostBreathFontType;
		CostStance = other.CostStance;
		CostStanceFontType = other.CostStanceFontType;
		CostNeiliAllocation = other.CostNeiliAllocation;
		CostNeiliAllocationFontType = other.CostNeiliAllocationFontType;
		CostWeaponDurabilityFontType = other.CostWeaponDurabilityFontType;
		CostWugFontType = other.CostWugFontType;
		FiveElementDestTypeWhileLooping = other.FiveElementDestTypeWhileLooping;
		FiveElementTransferTypeWhileLooping = other.FiveElementTransferTypeWhileLooping;
		EffectData = ((other.EffectData == null) ? null : new List<CombatSkillEffectData>(other.EffectData));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 201;
		if (Requirements != null)
		{
			totalSize += 2;
			int elementsCount = Requirements.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				(int, int, int) element = Requirements[i];
				totalSize += SerializationHelper.GetSerializedSize(element);
			}
		}
		else
		{
			totalSize += 2;
		}
		if (BreakAddProperty != null)
		{
			totalSize += 2;
			int elementsCount2 = BreakAddProperty.Count;
			for (int j = 0; j < elementsCount2; j++)
			{
				(short, short, bool) element2 = BreakAddProperty[j];
				totalSize += SerializationHelper.GetSerializedSize(element2);
			}
		}
		else
		{
			totalSize += 2;
		}
		if (NeiliAllocationAddProperty != null)
		{
			totalSize += 2;
			int elementsCount3 = NeiliAllocationAddProperty.Count;
			for (int k = 0; k < elementsCount3; k++)
			{
				(short, int) element3 = NeiliAllocationAddProperty[k];
				totalSize += SerializationHelper.GetSerializedSize(element3);
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += EffectDescription.GetSerializedSize();
		totalSize = ((BodyPartDamageStepActive == null) ? (totalSize + 2) : (totalSize + (2 + BodyPartDamageStepActive.Count)));
		totalSize = ((BreakBonusGrades == null) ? (totalSize + 2) : (totalSize + (2 + BreakBonusGrades.Count)));
		totalSize = ((LegendaryBookSlotIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LegendaryBookSlotIds.Count)));
		totalSize = ((SpecificGrids == null) ? (totalSize + 2) : (totalSize + (2 + SpecificGrids.Length)));
		totalSize = ((BodyPartWeights == null) ? (totalSize + 2) : (totalSize + (2 + 4 * BodyPartWeights.Count)));
		totalSize = ((CostTricks == null) ? (totalSize + 2) : (totalSize + (2 + 4 * CostTricks.Count)));
		totalSize = ((CostTricksFontType == null) ? (totalSize + 2) : (totalSize + (2 + CostTricksFontType.Count)));
		totalSize = ((EffectData == null) ? (totalSize + 2) : (totalSize + (2 + 8 * EffectData.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*(ushort*)pCurrData = ReadingState;
		pCurrData += 2;
		*(ushort*)pCurrData = ActivationState;
		pCurrData += 2;
		*pCurrData = (CanAffect ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (Conflicting ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)GridCount;
		pCurrData++;
		*(short*)pCurrData = Power;
		pCurrData += 2;
		*(short*)pCurrData = MaxPower;
		pCurrData += 2;
		*(short*)pCurrData = RequirementsPower;
		pCurrData += 2;
		if (Requirements != null)
		{
			int elementsCount = Requirements.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				(int, int, int) element = Requirements[i];
				pCurrData += SerializationHelper.Serialize(pCurrData, element);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (BreakAddProperty != null)
		{
			int elementsCount2 = BreakAddProperty.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				(short, short, bool) element2 = BreakAddProperty[j];
				pCurrData += SerializationHelper.Serialize(pCurrData, element2);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (NeiliAllocationAddProperty != null)
		{
			int elementsCount3 = NeiliAllocationAddProperty.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				(short, int) element3 = NeiliAllocationAddProperty[k];
				pCurrData += SerializationHelper.Serialize(pCurrData, element3);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)BreakPlateIndex;
		pCurrData++;
		*pCurrData = (byte)EffectType;
		pCurrData++;
		*pCurrData = (Mastered ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (PreviewMastered ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (Revoked ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = JumpThreshold;
		pCurrData += 2;
		*pCurrData = (byte)BaseInnerRatio;
		pCurrData++;
		*pCurrData = (byte)InnerRatioChangeRange;
		pCurrData++;
		*pCurrData = (byte)CurrInnerRatio;
		pCurrData++;
		*pCurrData = (byte)ExpectInnerRatio;
		pCurrData++;
		*(int*)pCurrData = NewUnderstandingNeedExp;
		pCurrData += 4;
		*pCurrData = (BreakSuccess ? ((byte)1) : ((byte)0));
		pCurrData++;
		int fieldSize = EffectDescription.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		pCurrData += DamageStepBonus.Serialize(pCurrData);
		if (BodyPartDamageStepActive != null)
		{
			int elementsCount4 = BodyPartDamageStepActive.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				pCurrData[l] = (BodyPartDamageStepActive[l] ? ((byte)1) : ((byte)0));
			}
			pCurrData += elementsCount4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (BreakBonusGrades != null)
		{
			int elementsCount5 = BreakBonusGrades.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				pCurrData[m] = (byte)BreakBonusGrades[m];
			}
			pCurrData += elementsCount5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsInAnyEquipPlans ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (HasSectEmeiSkillBreakBonus ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)LuohanId;
		pCurrData++;
		if (LegendaryBookSlotIds != null)
		{
			int elementsCount6 = LegendaryBookSlotIds.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				((short*)pCurrData)[n] = LegendaryBookSlotIds[n];
			}
			pCurrData += 2 * elementsCount6;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = MaxObtainableNeili;
		pCurrData += 2;
		*(short*)pCurrData = ObtainedNeili;
		pCurrData += 2;
		if (SpecificGrids != null)
		{
			int elementsCount7 = SpecificGrids.Length;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				pCurrData[num] = (byte)SpecificGrids[num];
			}
			pCurrData += elementsCount7;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)GenericGrid;
		pCurrData++;
		*(short*)pCurrData = AddAttackDistanceForward;
		pCurrData += 2;
		*(short*)pCurrData = AddAttackDistanceBackward;
		pCurrData += 2;
		*(int*)pCurrData = HitValueStrength;
		pCurrData += 4;
		*(int*)pCurrData = HitValueTechnique;
		pCurrData += 4;
		*(int*)pCurrData = HitValueSpeed;
		pCurrData += 4;
		*(int*)pCurrData = HitValueMind;
		pCurrData += 4;
		*(int*)pCurrData = PenetrateValueOuter;
		pCurrData += 4;
		*(int*)pCurrData = PenetrateValueInner;
		pCurrData += 4;
		pCurrData += Poisons.Serialize(pCurrData);
		pCurrData += HitDistribution.Serialize(pCurrData);
		if (BodyPartWeights != null)
		{
			int elementsCount8 = BodyPartWeights.Count;
			Tester.Assert(elementsCount8 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount8;
			pCurrData += 2;
			for (int num2 = 0; num2 < elementsCount8; num2++)
			{
				((int*)pCurrData)[num2] = BodyPartWeights[num2];
			}
			pCurrData += 4 * elementsCount8;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)FullPowerCastTimes;
		pCurrData++;
		*pCurrData = (IsFavorite ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = JumpSpeed;
		pCurrData += 4;
		*(short*)pCurrData = AddMoveSpeed;
		pCurrData += 2;
		*(short*)pCurrData = AddPercentMoveSpeed;
		pCurrData += 2;
		*(int*)pCurrData = AddHitStrength;
		pCurrData += 4;
		*(int*)pCurrData = AddHitTechnique;
		pCurrData += 4;
		*(int*)pCurrData = AddHitSpeed;
		pCurrData += 4;
		*(int*)pCurrData = AddHitMind;
		pCurrData += 4;
		*(int*)pCurrData = AddInnerDef;
		pCurrData += 4;
		*(int*)pCurrData = AddOuterDef;
		pCurrData += 4;
		*(int*)pCurrData = AddAvoidStrength;
		pCurrData += 4;
		*(int*)pCurrData = AddAvoidTechnique;
		pCurrData += 4;
		*(int*)pCurrData = AddAvoidSpeed;
		pCurrData += 4;
		*(int*)pCurrData = AddAvoidMind;
		pCurrData += 4;
		*(int*)pCurrData = BouncePowerOuter;
		pCurrData += 4;
		*(int*)pCurrData = BouncePowerInner;
		pCurrData += 4;
		*(short*)pCurrData = BounceDistance;
		pCurrData += 2;
		*(int*)pCurrData = FightbackPower;
		pCurrData += 4;
		*(short*)pCurrData = EffectDuration;
		pCurrData += 2;
		*(short*)pCurrData = CostMobility;
		pCurrData += 2;
		*pCurrData = (byte)CostMobilityFontType;
		pCurrData++;
		if (CostTricks != null)
		{
			int elementsCount9 = CostTricks.Count;
			Tester.Assert(elementsCount9 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount9;
			pCurrData += 2;
			for (int num3 = 0; num3 < elementsCount9; num3++)
			{
				pCurrData += CostTricks[num3].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CostTricksFontType != null)
		{
			int elementsCount10 = CostTricksFontType.Count;
			Tester.Assert(elementsCount10 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount10;
			pCurrData += 2;
			for (int num4 = 0; num4 < elementsCount10; num4++)
			{
				pCurrData[num4] = (byte)CostTricksFontType[num4];
			}
			pCurrData += elementsCount10;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)CostBreath;
		pCurrData++;
		*pCurrData = (byte)CostBreathFontType;
		pCurrData++;
		*pCurrData = (byte)CostStance;
		pCurrData++;
		*pCurrData = (byte)CostStanceFontType;
		pCurrData++;
		pCurrData += SerializationHelper.Serialize(pCurrData, CostNeiliAllocation);
		*pCurrData = (byte)CostNeiliAllocationFontType;
		pCurrData++;
		*pCurrData = (byte)CostWeaponDurabilityFontType;
		pCurrData++;
		*pCurrData = (byte)CostWugFontType;
		pCurrData++;
		*pCurrData = (byte)FiveElementDestTypeWhileLooping;
		pCurrData++;
		*pCurrData = (byte)FiveElementTransferTypeWhileLooping;
		pCurrData++;
		if (EffectData != null)
		{
			int elementsCount11 = EffectData.Count;
			Tester.Assert(elementsCount11 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount11;
			pCurrData += 2;
			for (int num5 = 0; num5 < elementsCount11; num5++)
			{
				pCurrData += EffectData[num5].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ReadingState = *(ushort*)pCurrData;
		pCurrData += 2;
		ActivationState = *(ushort*)pCurrData;
		pCurrData += 2;
		CanAffect = *pCurrData != 0;
		pCurrData++;
		Conflicting = *pCurrData != 0;
		pCurrData++;
		GridCount = (sbyte)(*pCurrData);
		pCurrData++;
		Power = *(short*)pCurrData;
		pCurrData += 2;
		MaxPower = *(short*)pCurrData;
		pCurrData += 2;
		RequirementsPower = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Requirements == null)
			{
				Requirements = new List<(int, int, int)>(elementsCount);
			}
			else
			{
				Requirements.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += SerializationHelper.Deserialize(pCurrData, out (int, int, int) tuple);
				Requirements.Add(tuple);
			}
		}
		else
		{
			Requirements?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (BreakAddProperty == null)
			{
				BreakAddProperty = new List<(short, short, bool)>(elementsCount2);
			}
			else
			{
				BreakAddProperty.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += SerializationHelper.Deserialize(pCurrData, out (short, short, bool) tuple2);
				BreakAddProperty.Add(tuple2);
			}
		}
		else
		{
			BreakAddProperty?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (NeiliAllocationAddProperty == null)
			{
				NeiliAllocationAddProperty = new List<(short, int)>(elementsCount3);
			}
			else
			{
				NeiliAllocationAddProperty.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData += SerializationHelper.Deserialize(pCurrData, out (short, int) tuple3);
				NeiliAllocationAddProperty.Add(tuple3);
			}
		}
		else
		{
			NeiliAllocationAddProperty?.Clear();
		}
		BreakPlateIndex = (sbyte)(*pCurrData);
		pCurrData++;
		EffectType = (sbyte)(*pCurrData);
		pCurrData++;
		Mastered = *pCurrData != 0;
		pCurrData++;
		PreviewMastered = *pCurrData != 0;
		pCurrData++;
		Revoked = *pCurrData != 0;
		pCurrData++;
		JumpThreshold = *(short*)pCurrData;
		pCurrData += 2;
		BaseInnerRatio = (sbyte)(*pCurrData);
		pCurrData++;
		InnerRatioChangeRange = (sbyte)(*pCurrData);
		pCurrData++;
		CurrInnerRatio = (sbyte)(*pCurrData);
		pCurrData++;
		ExpectInnerRatio = (sbyte)(*pCurrData);
		pCurrData++;
		NewUnderstandingNeedExp = *(int*)pCurrData;
		pCurrData += 4;
		BreakSuccess = *pCurrData != 0;
		pCurrData++;
		pCurrData += EffectDescription.Deserialize(pCurrData);
		pCurrData += DamageStepBonus.Deserialize(pCurrData);
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (BodyPartDamageStepActive == null)
			{
				BodyPartDamageStepActive = new List<bool>(elementsCount4);
			}
			else
			{
				BodyPartDamageStepActive.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				BodyPartDamageStepActive.Add(pCurrData[l] != 0);
			}
			pCurrData += (int)elementsCount4;
		}
		else
		{
			BodyPartDamageStepActive?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (BreakBonusGrades == null)
			{
				BreakBonusGrades = new List<sbyte>(elementsCount5);
			}
			else
			{
				BreakBonusGrades.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				BreakBonusGrades.Add((sbyte)pCurrData[m]);
			}
			pCurrData += (int)elementsCount5;
		}
		else
		{
			BreakBonusGrades?.Clear();
		}
		IsInAnyEquipPlans = *pCurrData != 0;
		pCurrData++;
		HasSectEmeiSkillBreakBonus = *pCurrData != 0;
		pCurrData++;
		LuohanId = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (LegendaryBookSlotIds == null)
			{
				LegendaryBookSlotIds = new List<short>(elementsCount6);
			}
			else
			{
				LegendaryBookSlotIds.Clear();
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				LegendaryBookSlotIds.Add(((short*)pCurrData)[n]);
			}
			pCurrData += 2 * elementsCount6;
		}
		else
		{
			LegendaryBookSlotIds?.Clear();
		}
		MaxObtainableNeili = *(short*)pCurrData;
		pCurrData += 2;
		ObtainedNeili = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount7 > 0)
		{
			if (SpecificGrids == null || SpecificGrids.Length != elementsCount7)
			{
				SpecificGrids = new sbyte[elementsCount7];
			}
			for (int num = 0; num < elementsCount7; num++)
			{
				SpecificGrids[num] = (sbyte)pCurrData[num];
			}
			pCurrData += (int)elementsCount7;
		}
		else
		{
			SpecificGrids = null;
		}
		GenericGrid = (sbyte)(*pCurrData);
		pCurrData++;
		AddAttackDistanceForward = *(short*)pCurrData;
		pCurrData += 2;
		AddAttackDistanceBackward = *(short*)pCurrData;
		pCurrData += 2;
		HitValueStrength = *(int*)pCurrData;
		pCurrData += 4;
		HitValueTechnique = *(int*)pCurrData;
		pCurrData += 4;
		HitValueSpeed = *(int*)pCurrData;
		pCurrData += 4;
		HitValueMind = *(int*)pCurrData;
		pCurrData += 4;
		PenetrateValueOuter = *(int*)pCurrData;
		pCurrData += 4;
		PenetrateValueInner = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Poisons.Deserialize(pCurrData);
		pCurrData += HitDistribution.Deserialize(pCurrData);
		ushort elementsCount8 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount8 > 0)
		{
			if (BodyPartWeights == null)
			{
				BodyPartWeights = new List<int>(elementsCount8);
			}
			else
			{
				BodyPartWeights.Clear();
			}
			for (int num2 = 0; num2 < elementsCount8; num2++)
			{
				BodyPartWeights.Add(((int*)pCurrData)[num2]);
			}
			pCurrData += 4 * elementsCount8;
		}
		else
		{
			BodyPartWeights?.Clear();
		}
		FullPowerCastTimes = (sbyte)(*pCurrData);
		pCurrData++;
		IsFavorite = *pCurrData != 0;
		pCurrData++;
		JumpSpeed = *(int*)pCurrData;
		pCurrData += 4;
		AddMoveSpeed = *(short*)pCurrData;
		pCurrData += 2;
		AddPercentMoveSpeed = *(short*)pCurrData;
		pCurrData += 2;
		AddHitStrength = *(int*)pCurrData;
		pCurrData += 4;
		AddHitTechnique = *(int*)pCurrData;
		pCurrData += 4;
		AddHitSpeed = *(int*)pCurrData;
		pCurrData += 4;
		AddHitMind = *(int*)pCurrData;
		pCurrData += 4;
		AddInnerDef = *(int*)pCurrData;
		pCurrData += 4;
		AddOuterDef = *(int*)pCurrData;
		pCurrData += 4;
		AddAvoidStrength = *(int*)pCurrData;
		pCurrData += 4;
		AddAvoidTechnique = *(int*)pCurrData;
		pCurrData += 4;
		AddAvoidSpeed = *(int*)pCurrData;
		pCurrData += 4;
		AddAvoidMind = *(int*)pCurrData;
		pCurrData += 4;
		BouncePowerOuter = *(int*)pCurrData;
		pCurrData += 4;
		BouncePowerInner = *(int*)pCurrData;
		pCurrData += 4;
		BounceDistance = *(short*)pCurrData;
		pCurrData += 2;
		FightbackPower = *(int*)pCurrData;
		pCurrData += 4;
		EffectDuration = *(short*)pCurrData;
		pCurrData += 2;
		CostMobility = *(short*)pCurrData;
		pCurrData += 2;
		CostMobilityFontType = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount9 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount9 > 0)
		{
			if (CostTricks == null)
			{
				CostTricks = new List<NeedTrick>(elementsCount9);
			}
			else
			{
				CostTricks.Clear();
			}
			for (int num3 = 0; num3 < elementsCount9; num3++)
			{
				NeedTrick element = default(NeedTrick);
				pCurrData += element.Deserialize(pCurrData);
				CostTricks.Add(element);
			}
		}
		else
		{
			CostTricks?.Clear();
		}
		ushort elementsCount10 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount10 > 0)
		{
			if (CostTricksFontType == null)
			{
				CostTricksFontType = new List<sbyte>(elementsCount10);
			}
			else
			{
				CostTricksFontType.Clear();
			}
			for (int num4 = 0; num4 < elementsCount10; num4++)
			{
				CostTricksFontType.Add((sbyte)pCurrData[num4]);
			}
			pCurrData += (int)elementsCount10;
		}
		else
		{
			CostTricksFontType?.Clear();
		}
		CostBreath = (sbyte)(*pCurrData);
		pCurrData++;
		CostBreathFontType = (sbyte)(*pCurrData);
		pCurrData++;
		CostStance = (sbyte)(*pCurrData);
		pCurrData++;
		CostStanceFontType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += SerializationHelper.Deserialize(pCurrData, out CostNeiliAllocation);
		CostNeiliAllocationFontType = (sbyte)(*pCurrData);
		pCurrData++;
		CostWeaponDurabilityFontType = (sbyte)(*pCurrData);
		pCurrData++;
		CostWugFontType = (sbyte)(*pCurrData);
		pCurrData++;
		FiveElementDestTypeWhileLooping = (sbyte)(*pCurrData);
		pCurrData++;
		FiveElementTransferTypeWhileLooping = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount11 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount11 > 0)
		{
			if (EffectData == null)
			{
				EffectData = new List<CombatSkillEffectData>(elementsCount11);
			}
			else
			{
				EffectData.Clear();
			}
			for (int num5 = 0; num5 < elementsCount11; num5++)
			{
				CombatSkillEffectData element2 = default(CombatSkillEffectData);
				pCurrData += element2.Deserialize(pCurrData);
				EffectData.Add(element2);
			}
		}
		else
		{
			EffectData?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
