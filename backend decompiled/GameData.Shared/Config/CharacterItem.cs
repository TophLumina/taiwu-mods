using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;
using Config.ConfigCells.Character;
using GameData.Domains.Character;
using GameData.Domains.Combat;

namespace Config;

[Serializable]
public class CharacterItem : ConfigItem<CharacterItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 姓
	/// </summary>
	public readonly string Surname;

	/// <summary>
	/// 名
	/// </summary>
	public readonly string GivenName;

	/// <summary>
	/// 代称
	/// </summary>
	public readonly string AnonymousTitle;

	/// <summary>
	/// 特殊战斗模型
	/// - 此处引用 Combat/CombatSkeleton 配置表，用于定制角色战斗模型相关参数，默认无需定制
	/// </summary>
	public readonly sbyte SpecialCombatSkeleton;

	/// <summary>
	/// 固定头像
	/// - 部分特殊人物的头像，不通过Avatar系统组合，直接显示NpcFace目录下对应名称的图片
	/// </summary>
	public readonly string FixedAvatarName;

	/// <summary>
	/// 固定立绘动画名
	/// - 部分npc的固定立绘是动态的
	/// </summary>
	public readonly string FixedAvatarSpineName;

	/// <summary>
	/// 固定立绘动画皮肤名
	/// - 如果使用动画，使用哪个皮肤
	/// </summary>
	public readonly string FixedAvatarSpineSkin;

	/// <summary>
	/// 生成方式
	/// - 生成角色时使用. 0: 固定角色 (不会重复创建的预设角色，如 Boss, 剧情人物等), 1: 智能角色 (随机姓名和属性, 有生活行为的角色), 2: 随机敌人 (无随机姓名, 属性随机),3: 固定敌人(可以重复创建的预设角色，如动物)
	/// </summary>
	public readonly byte CreatingType;

	/// <summary>
	/// 角色分组
	/// </summary>
	public readonly short GroupId;

	/// <summary>
	/// 战斗 Ai
	/// </summary>
	public readonly int CombatAi;

	/// <summary>
	/// 是否能战败
	/// </summary>
	public readonly bool CanDefeat;

	/// <summary>
	/// 是否可移动
	/// </summary>
	public readonly bool CanMove;

	/// <summary>
	/// 人物面板是否可见
	/// - 是否能打开人物面板看到其信息；凡是需要战斗的人物均为可见，其余剧情人物均不可见
	/// </summary>
	public readonly bool CanOpenCharacterMenu;

	/// <summary>
	/// 是否显示好感度
	/// </summary>
	public readonly bool IsFavorabilityDisplay;

	/// <summary>
	/// 是否隐藏年龄
	/// - 在角色界面不显示年龄
	/// </summary>
	public readonly bool HideAge;

	/// <summary>
	/// 是否使用石子、树枝、空手战斗
	/// </summary>
	public readonly bool AllowUseFreeWeapon;

	/// <summary>
	/// 是否会逃跑
	/// - 0：不会，1：会
	/// </summary>
	public readonly bool AllowEscape;

	/// <summary>
	/// 是否能说话
	/// - 是否能在战斗准备和战斗中说话，不能时，显示为“………………”，有特殊助战对话时，需此值为0才能显示特殊助战对话
	/// </summary>
	public readonly bool CanSpeak;

	/// <summary>
	/// 是否能作为传剑目标
	/// </summary>
	public readonly bool CanBeTaiwu;

	/// <summary>
	/// 是否能作为化魂肉体
	/// </summary>
	public readonly bool CanBePossessionBody;

	/// <summary>
	/// 是否能作为化魂灵魂
	/// </summary>
	public readonly bool CanBePossessionSoul;

	/// <summary>
	/// 特殊助战对话己方
	/// - 仅骷髅人或 CanSpeak 配置为 0 的角色有效，此处有配置时将替代默认的省略号文本
	/// </summary>
	public readonly string SpecialMuteBubbleSelf;

	/// <summary>
	/// 特殊助战对话敌方
	/// - 仅骷髅人或 CanSpeak 配置为 0 的角色有效，此处有配置时将替代默认的省略号文本
	/// </summary>
	public readonly string SpecialMuteBubbleEnemy;

	/// <summary>
	/// 特殊同道类型
	/// </summary>
	public readonly ECharacterSpecialTemmateType SpecialTemmateType;

	/// <summary>
	/// 固定角色在地图上是否显示名字
	/// </summary>
	public readonly bool FixedCharacterShowNameOnMap;

	/// <summary>
	/// 动物是否会发起动物袭击过月事件
	/// </summary>
	public readonly bool RandomAnimalAttack;

	/// <summary>
	/// 受失心魔加成
	/// </summary>
	public readonly bool XiangshuInfectedDemonBonus;

	/// <summary>
	/// 是否会疗伤驱毒
	/// - 0：不会，1：会
	/// </summary>
	public readonly bool AllowHeal;

	/// <summary>
	/// 是否能被捕捉
	/// - 角色在战斗中可以用绳索劫持
	/// </summary>
	public readonly bool CanBeKidnapped;

	/// <summary>
	/// 是否随机特性
	/// </summary>
	public readonly bool RandomFeaturesAtCreating;

	/// <summary>
	/// 特性列表
	/// - 关联到 CharacterFeature 表. 不支持填写相枢入魔相关特性, 这些特性是根据入魔值计算出来的.
	/// </summary>
	public readonly List<short> FeatureIds;

	/// <summary>
	/// 手下
	/// </summary>
	public readonly short MinionGroupId;

	/// <summary>
	/// 玄狱手下
	/// </summary>
	public readonly short ChallengeModeMinionGroupId;

	/// <summary>
	/// 随机敌人信息 ID
	/// - 关联到 RandomEnemy 表
	/// </summary>
	public readonly short RandomEnemyId;

	/// <summary>
	/// 所领导的巢穴类型 ID
	/// - 关联到 EnemyNest 表
	/// </summary>
	public readonly short LeadingEnemyNestId;

	/// <summary>
	/// 允许跳过指令 CD
	/// </summary>
	public readonly bool AllowFavorabilitySkipCd;

	/// <summary>
	/// 与主战角色初始好感权重
	/// - 依次为 [-30000, -18000]、(-18000, 0]、(0, 18000)、[18000, 30000] 四个区间的概率，随机选取区间后在区间内随机具体值
	/// </summary>
	public readonly sbyte[] RandomEnemyFavorability;

	/// <summary>
	/// 性别
	/// - 0: 女, 1: 男, -1: 不限制. 固定角色必须设置有效值.
	/// </summary>
	public readonly sbyte Gender;

	/// <summary>
	/// 预设体型
	/// - 0: 瘦, 1: 普通, 2: 胖, -1: 不限制. 固定角色必须设置有效值.
	/// </summary>
	public readonly sbyte PresetBodyType;

	/// <summary>
	/// 民族
	/// - 0: 汉族, 1: 藏族.
	/// </summary>
	public readonly sbyte Race;

	/// <summary>
	/// 异性相
	/// - 性征和性别是否相反
	/// </summary>
	public readonly bool Transgender;

	/// <summary>
	/// 双性向
	/// - 性取向是否同时包含同性和异性
	/// </summary>
	public readonly bool Bisexual;

	/// <summary>
	/// 预设名誉
	/// - 非智能角色的名誉不做计算, 直接使用预设名誉. [-100, 100].
	/// </summary>
	public readonly sbyte PresetFame;

	/// <summary>
	/// 心情
	/// - 取值范围 (-120, -90]: 悲极, (-90, -60]: 痛苦, (-60, -30]: 沮丧, (-30, 30): 寻常, [30, 60): 开怀, [60, 90): 欢喜, [90, 120): 乐极.
	/// </summary>
	public readonly sbyte Happiness;

	/// <summary>
	/// 基础魅力
	/// - 取值范围 [0, 900], 小于 0 表示随机. [0, 100): 非人, [100, 200): 可憎, [200, 300): 不扬, [300, 400): 寻常, [400, 500): 出众, [500, 600): 瑾瑜/瑶碧, [600, 700): 龙姿/凤仪, [700, 800): 绝世/出尘, [800, 900]: 天人. 固定角色必须设置有效值.
	/// </summary>
	public readonly short BaseAttraction;

	/// <summary>
	/// 基础立场
	/// - 取值范围 [-500, 500]. [-500, -375]: 唯我, (-375, -125]: 叛逆, (-125, 125): 中庸, [125, 375): 仁善, [375, 500]: 刚正.
	/// </summary>
	public readonly short BaseMorality;

	/// <summary>
	/// 真实年龄
	/// - 对于随机敌人, 必须填写有效年龄.
	/// </summary>
	public readonly short ActualAge;

	/// <summary>
	/// 当前年龄
	/// - 初始化时的当前年龄, 不设置时与真实年龄相同.
	/// </summary>
	public readonly short InitCurrAge;

	/// <summary>
	/// 当前健康
	/// - 以月为单位, 健康值小于等于 0 即死亡. 年龄换算为月后加上健康值不能超过最大健康. 表中的配置只对固定角色有效, 其他角色则是根据算法生成.
	/// </summary>
	public readonly short Health;

	/// <summary>
	/// 基础最大健康
	/// - 以月为单位. 表中的配置只对固定角色有效, 其他角色则是根据算法生成.
	/// </summary>
	public readonly short BaseMaxHealth;

	/// <summary>
	/// 出生月份
	/// - 正常取值范围 [0, 11], -1 表示随机出生月份.
	/// </summary>
	public readonly sbyte BirthMonth;

	/// <summary>
	/// 团体信息
	/// - 此字段自动生成, 实际配置字段为 "团体" 和 "阶层".
	/// </summary>
	public readonly OrganizationInfo OrganizationInfo;

	/// <summary>
	/// 特殊级别称谓
	/// - 特殊人物在门派中可能符合特定的阶层，但其级别称谓并不与一般门派身份相同，可能采用其他称谓，例如百花剧情角色玄无忧与白无恙其团体为百花谷，阶层为8，但其称谓应为“祖师”，故而加入此列，为存在特殊身份称谓的固定角色增加专属的级别称谓。
	/// </summary>
	public readonly string SpecialGradeName;

	/// <summary>
	/// 理想团体
	/// - 值为门派的团体模板 ID. 为无门无派表示没有理想门派，为None表示按照RandomIdealSects的配置进行生成。门派中人的理想门派可以和本门派不同, 但并不意味着此人会背叛师门.
	/// </summary>
	public readonly sbyte IdealSect;

	/// <summary>
	/// 可选随机理想团体
	/// - 不指定理想团体的情况下从该集合中抽取. 如果该集合也不配置则根据代码中的保底逻辑进行随机 (当前逻辑有可能不生成理想团体).
	/// </summary>
	public readonly List<sbyte> RandomIdealSects;

	/// <summary>
	/// 相枢类型
	/// - 0: 寻常 (但可能处于相枢入邪或入魔状态), 1: 相枢化身, 2: 相枢真身, 3: 紫竹化身.4: 练功房木人（需按练功房设置的精纯来设置boss能力）
	/// </summary>
	public readonly sbyte XiangshuType;

	/// <summary>
	/// 出家类型
	/// - 0: 未出家, 1: 非门派道人, 2: 非门派和尚, 129: 门派道人, 130: 门派和尚. 门派出家会赐法号, 非门派出家无法号.
	/// </summary>
	public readonly byte MonkType;

	/// <summary>
	/// 技艺兴趣
	/// - 感兴趣的技艺类型，不配置将随机生成
	/// </summary>
	public readonly sbyte LifeSkillTypeInterest;

	/// <summary>
	/// 武学兴趣
	/// - 感兴趣的武学类型，不配置将随机生成
	/// </summary>
	public readonly sbyte CombatSkillTypeInterest;

	/// <summary>
	/// 主要属性兴趣
	/// - 感兴趣的主要属性类型，不配置将自动生成
	/// </summary>
	public readonly sbyte MainAttributeInterest;

	/// <summary>
	/// 额外装备负重
	/// - 特殊角色的额外装备负重配置
	/// </summary>
	public readonly int ExtraEquipmentLoad;

	/// <summary>
	/// 固定武器发挥
	/// - 值不为-1时，人物的武器发挥、功法威力以此设定值为基础值，随后再计算各类特效的影响
	/// </summary>
	public readonly short FixWeaponPower;

	/// <summary>
	/// 固定防具发挥
	/// </summary>
	public readonly short FixArmorPower;

	/// <summary>
	/// 固定功法威力
	/// </summary>
	public readonly short FixCombatSkillPower;

	/// <summary>
	/// 基础主要属性
	/// - 此字段自动生成, 实际配置字段为从 "膂力" 到 "悟性" 的 6 个字段.
	/// </summary>
	public readonly MainAttributes BaseMainAttributes;

	/// <summary>
	/// 基础命中
	/// - 此字段自动生成, 实际配置字段为从 "力道" 到 "动心" 的 4 个字段.
	/// </summary>
	public readonly HitOrAvoidInts BaseHitValues;

	/// <summary>
	/// 基础攻击
	/// - 此字段自动生成, 实际配置字段为从 "破体" 到 "破气" 的 2 个字段.
	/// </summary>
	public readonly OuterAndInnerInts BasePenetrations;

	/// <summary>
	/// 基础化解
	/// - 此字段自动生成, 实际配置字段为从 "卸力" 到 "守心" 的 4 个字段.
	/// </summary>
	public readonly HitOrAvoidInts BaseAvoidValues;

	/// <summary>
	/// 基础防御
	/// - 此字段自动生成, 实际配置字段为从 "御体" 到 "御气" 的 2 个字段.
	/// </summary>
	public readonly OuterAndInnerInts BasePenetrationResists;

	/// <summary>
	/// 基础架势提气恢复
	/// - 此字段自动生成, 实际配置字段为 "架势" 和 "提气" 字段.
	/// </summary>
	public readonly OuterAndInnerShorts BaseRecoveryOfStanceAndBreath;

	/// <summary>
	/// 基础移动速度
	/// - 影响每次移动后的间隔帧数, 属性越高, 间隔帧数越低.
	/// </summary>
	public readonly short BaseMoveSpeed;

	/// <summary>
	/// 基础步伐稳健
	/// - 战斗中破绽的解除速度
	/// </summary>
	public readonly short BaseRecoveryOfFlaw;

	/// <summary>
	/// 基础施展速度
	/// - 功法准备速度
	/// </summary>
	public readonly short BaseCastSpeed;

	/// <summary>
	/// 基础引气冲关
	/// - 战斗中封穴的解除速度
	/// </summary>
	public readonly short BaseRecoveryOfBlockedAcupoint;

	/// <summary>
	/// 基础兵器切换
	/// - 切换武器的速度，越高切换越快.
	/// </summary>
	public readonly short BaseWeaponSwitchSpeed;

	/// <summary>
	/// 基础攻击速度
	/// - 普通攻击速度
	/// </summary>
	public readonly short BaseAttackSpeed;

	/// <summary>
	/// 基础内功发挥
	/// - 每个功法有一个初始的内功可变范围, 增加内功发挥以增加内功比例的变动范围. 必须大于等于 0, 为 0 表示所有功法都不能调整内功比例了.
	/// </summary>
	public readonly short BaseInnerRatio;

	/// <summary>
	/// 基础调息吐纳
	/// - 内息紊乱的恢复能力 (而不是每月的变化值), 必须大于等于 0.
	/// </summary>
	public readonly short BaseRecoveryOfQiDisorder;

	/// <summary>
	/// 基础毒素抵抗
	/// - 此字段自动生成, 实际配置字段为从 "烈" 到 "幻" 的 6 个字段.
	/// </summary>
	public readonly PoisonInts BasePoisonResists;

	/// <summary>
	/// 内伤
	/// </summary>
	public readonly bool InnerInjuryImmunity;

	/// <summary>
	/// 外伤
	/// </summary>
	public readonly bool OuterInjuryImmunity;

	/// <summary>
	/// 失神
	/// </summary>
	public readonly bool MindImmunity;

	/// <summary>
	/// 破绽
	/// </summary>
	public readonly bool FlawImmunity;

	/// <summary>
	/// 点穴
	/// </summary>
	public readonly bool AcupointImmunity;

	/// <summary>
	/// 重创
	/// </summary>
	public readonly bool FatalImmunity;

	/// <summary>
	/// 必死
	/// </summary>
	public readonly bool DieImmunity;

	/// <summary>
	/// 毒素免疫
	/// - 此字段自动生成, 实际配置字段为从 "烈" 到 "幻" 的 6 个字段.
	/// </summary>
	public readonly bool[] PoisonImmunities;

	/// <summary>
	/// 内息紊乱
	/// </summary>
	public readonly short DisorderOfQi;

	/// <summary>
	/// 左臂
	/// - 0: 残缺, 1: 完好
	/// </summary>
	public readonly bool HaveLeftArm;

	/// <summary>
	/// 右臂
	/// </summary>
	public readonly bool HaveRightArm;

	/// <summary>
	/// 左腿
	/// </summary>
	public readonly bool HaveLeftLeg;

	/// <summary>
	/// 右腿
	/// </summary>
	public readonly bool HaveRightLeg;

	/// <summary>
	/// 各部位伤势
	/// - 每个部位两个数值:外伤程度,内伤程度.伤势程度范围:[0,6],0表示未受伤.一共7个部位,分别为:胸背,腰腹,头颈,左臂,右臂,左腿,右腿.最终配置格式为:`{胸背外伤,胸背内伤,腰腹外伤,腰腹内伤,...}`.
	/// </summary>
	public readonly Injuries Injuries;

	/// <summary>
	/// 各部位受伤阈值
	/// - 每受一个相应的标记需要受到的伤害量
	/// </summary>
	public readonly DamageStepCollection DamageSteps;

	/// <summary>
	/// 额外真气
	/// </summary>
	public readonly NeiliAllocation ExtraNeiliAllocation;

	/// <summary>
	/// 额外内力
	/// - 通过周天运转之外的手段获得的内力
	/// </summary>
	public readonly int ExtraNeili;

	/// <summary>
	/// 精纯境界
	/// </summary>
	public readonly sbyte ConsummateLevel;

	/// <summary>
	/// 预设装备
	/// - 此字段自动生成, 实际配置字段为从 "武器1" 到 "口袋3" 的 17 个字段.
	/// </summary>
	public readonly PresetEquipmentItem[] PresetEquipment;

	/// <summary>
	/// 装备锁
	/// - 此字段自动生成, 实际配置字段为从 "武器1" 到 "口袋3" 的 17 个字段右边对应的列
	/// </summary>
	public readonly bool[] EquipmentLock;

	/// <summary>
	/// 预设行囊
	/// - 单个物品格式: {类型, 模板 ID, 数量}. 类型为字串形式, 参考物品子表表名. 模板 ID 参考各物品子表.
	/// </summary>
	public readonly List<PresetInventoryItem> PresetInventory;

	/// <summary>
	/// 作为主战角色的物品爆率修正比例
	/// - 配置为 100 时为无修正
	/// </summary>
	public readonly int DropRatePercentAsMainChar;

	/// <summary>
	/// 作为助战角色的物品爆率修正比例
	/// </summary>
	public readonly int DropRatePercentAsTeammate;

	/// <summary>
	/// 预设服食
	/// - 预设人物服食情况，在生成人物时按顺序令人物服食相应的道具
	/// </summary>
	public readonly List<PresetItemTemplateId> PresetEatingItems;

	/// <summary>
	/// 允许掉落王蛊
	/// </summary>
	public readonly bool AllowDropWugKing;

	/// <summary>
	/// 预设功法
	/// - 模板数据中单个功法的配置格式有以下五种:
	/// -     `功法模板 ID`
	/// -     `功法模板 ID, 已读总纲页数, 已读正练书页数, 已读逆练书页数`
	/// -     `功法模板 ID, 已读总纲页数, {正练页1是否已读, 页2, ...}, {逆练页1是否已读, 页2, ...}`
	/// -     `功法模板 ID, {总纲类型1是否已读, 类型2, ...}, 已读正练书页数, 已读逆练书页数`
	/// -     `功法模板 ID, {总纲类型1是否已读, 类型2, ...}, {正练页1是否已读, 页2, ...}, {逆练页1是否已读, 页2, ...}`
	/// - 已读总纲页数取值范围 [0, 5].
	/// - 已读正逆练书页数取值范围 [0, 5].
	/// - 总纲类型N是否已读: 指定位置的元素和指定位置的总纲类型对应, 0 为未读, 1 为已读.
	/// - 总纲类型: 0: 刚正, 1: 仁善, 2: 中庸, 3: 叛逆, 4: 唯我.
	/// - 正逆练页N是否已读: 指定位置的元素和指定位置的书页对应, 0 为未读, 1 为已读.
	/// - 示例：
	/// -     `{3}`: 功法模板 ID 3.
	/// -     `{5, 2, 3, 0}`: 功法模板 ID 5, 随机两个总纲已读, 正练随机 3 页已读, 逆练全部未读.
	/// -     `{2, {1,1,0,0,0}, {1,1,1,1,1}, {0,0,1,0,0}}`: 功法模板 ID 2, 已读总纲刚正及仁善, 正练全部已读, 逆练已读第 2 页.
	/// </summary>
	public readonly List<PresetCombatSkill> PresetCombatSkills;

	/// <summary>
	/// 额外功法栏位
	/// </summary>
	public readonly sbyte[] ExtraCombatSkillGrids;

	/// <summary>
	/// 禁用同道指令
	/// - 自动生成时不可选取此处配置的助战指令，仅非智能人物有效
	/// </summary>
	public readonly List<sbyte> DisableTeammateCommands;

	/// <summary>
	/// 预设同道指令
	/// - 如果此项不为空数组，则使用此项内的助战指令，替换系统根据人物特性生成的助战指令；仅非智能人物有效
	/// </summary>
	public readonly List<sbyte> PresetTeammateCommands;

	/// <summary>
	/// 预设内力五行属性
	/// - 只用于FixedCharacter，如果有配置则覆盖当前的内力五行属性
	/// - 金刚,紫霞,玄阴,纯阳,归元
	/// </summary>
	public readonly NeiliProportionOfFiveElements PresetNeiliProportionOfFiveElements;

	/// <summary>
	/// 理想真气分配比例
	/// - 用于替换内力五行类型赋予的真气分配比例，当为{0,0,0,0}时，使用内力类型表中的真气分配比例，否则使用人物表的真气分配比例
	/// </summary>
	public readonly sbyte[] IdeaAllocationProportion;

	/// <summary>
	/// 基础技艺资质
	/// - 此字段自动生成, 实际配置字段为从 "音律" 到 "杂学" 的 16 个字段.
	/// </summary>
	public readonly LifeSkillShorts BaseLifeSkillQualifications;

	/// <summary>
	/// 技艺资质成长
	/// - 0: 均衡, 1: 早熟, 2: 晚成
	/// </summary>
	public readonly sbyte LifeSkillQualificationGrowthType;

	/// <summary>
	/// 技艺
	/// - 模板数据中单个技艺的配置格式有以下两种:
	/// -     `技艺模板 ID, 已读页数`
	/// -     `技艺模板 ID, {页1是否已读, 页2, ...}`
	/// - 技艺模板 ID 参考 LifeSkill 表.
	/// - 已读页数取值范围: [0, 5].
	/// - 页N是否已读: 指定位置的元素和指定位置的书页对应, 0 为未读, 1 为已读.
	/// - 示例:
	/// -     `{5, 3}`: 技艺模板 ID 5, 随机三页已读.
	/// -     `{8, {1,1,0,0,0}}`: 技艺模板 ID 8, 前两页已读.
	/// </summary>
	public readonly List<GameData.Domains.Character.LifeSkillItem> LearnedLifeSkills;

	/// <summary>
	/// 简易技艺
	/// - 以16个参数简易的设定人物每种技艺已掌握的品级，如：6，表示人物已完全习会0~6级的对应技艺的所有书页，最终与LearnedLifeSkills参数共同决定人物习得的技艺情况，-1表示未习得任何技艺
	/// </summary>
	public readonly sbyte[] LearnedLifeSkillGrades;

	/// <summary>
	/// 基础武学资质
	/// - 此字段自动生成, 实际配置字段为从 "内功" 到 "乐器" 的 14 个字段.
	/// </summary>
	public readonly CombatSkillShorts BaseCombatSkillQualifications;

	/// <summary>
	/// 武学资质成长
	/// - 0: 均衡, 1: 早熟, 2: 晚成
	/// </summary>
	public readonly sbyte CombatSkillQualificationGrowthType;

	/// <summary>
	/// 持有资源
	/// - 此字段自动生成, 实际配置字段为从 "食材" 到 "威望" 的 8 个字段，人物生成时，以此为最初的持有资源
	/// </summary>
	public readonly ResourceInts Resources;

	/// <summary>
	/// 掉落资源
	/// - 此字段自动生成, 实际配置字段为从 "食材" 到 "威望" 的 8 个字段，用于影响人物在战斗、较艺、促织决斗后掉落的额外的资源和威望。
	/// </summary>
	public readonly ResourceInts DropResources;

	/// <summary>
	/// 喜好物品类型
	/// - 非智能角色可以手动指定其值, 参见 GameData.Domains.Item.ItemSubType.
	/// </summary>
	public readonly short LovingItemSubType;

	/// <summary>
	/// 厌恶物品类型
	/// - 非智能角色可以手动指定其值, 参见 GameData.Domains.Item.ItemSubType.
	/// </summary>
	public readonly short HatingItemSubType;

	/// <summary>
	/// 奇书堕魔外形
	/// </summary>
	public readonly bool ShowLegendaryBookConsumedCloth;

	/// <summary>
	/// 创建时的Avatar数据
	/// - 配置对应的资源路径，会使用该资源覆盖创建出的角色的外貌数据
	/// </summary>
	public readonly string AvatarDataPath;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="surname">姓</param>
	/// <param name="givenName">名</param>
	/// <param name="anonymousTitle">代称</param>
	/// <param name="specialCombatSkeleton">特殊战斗模型 - 此处引用 Combat/CombatSkeleton 配置表，用于定制角色战斗模型相关参数，默认无需定制</param>
	/// <param name="fixedAvatarName">固定头像 - 部分特殊人物的头像，不通过Avatar系统组合，直接显示NpcFace目录下对应名称的图片</param>
	/// <param name="fixedAvatarSpineName">固定立绘动画名 - 部分npc的固定立绘是动态的</param>
	/// <param name="fixedAvatarSpineSkin">固定立绘动画皮肤名 - 如果使用动画，使用哪个皮肤</param>
	/// <param name="creatingType">生成方式 - 生成角色时使用. 0: 固定角色 (不会重复创建的预设角色，如 Boss, 剧情人物等), 1: 智能角色 (随机姓名和属性, 有生活行为的角色), 2: 随机敌人 (无随机姓名, 属性随机),3: 固定敌人(可以重复创建的预设角色，如动物)</param>
	/// <param name="groupId">角色分组</param>
	/// <param name="combatAi">战斗 Ai</param>
	/// <param name="canDefeat">是否能战败</param>
	/// <param name="canMove">是否可移动</param>
	/// <param name="canOpenCharacterMenu">人物面板是否可见 - 是否能打开人物面板看到其信息；凡是需要战斗的人物均为可见，其余剧情人物均不可见</param>
	/// <param name="isFavorabilityDisplay">是否显示好感度</param>
	/// <param name="hideAge">是否隐藏年龄 - 在角色界面不显示年龄</param>
	/// <param name="allowUseFreeWeapon">是否使用石子、树枝、空手战斗</param>
	/// <param name="allowEscape">是否会逃跑 - 0：不会，1：会</param>
	/// <param name="canSpeak">是否能说话 - 是否能在战斗准备和战斗中说话，不能时，显示为“………………”，有特殊助战对话时，需此值为0才能显示特殊助战对话</param>
	/// <param name="canBeTaiwu">是否能作为传剑目标</param>
	/// <param name="canBePossessionBody">是否能作为化魂肉体</param>
	/// <param name="canBePossessionSoul">是否能作为化魂灵魂</param>
	/// <param name="specialMuteBubbleSelf">特殊助战对话己方 - 仅骷髅人或 CanSpeak 配置为 0 的角色有效，此处有配置时将替代默认的省略号文本</param>
	/// <param name="specialMuteBubbleEnemy">特殊助战对话敌方 - 仅骷髅人或 CanSpeak 配置为 0 的角色有效，此处有配置时将替代默认的省略号文本</param>
	/// <param name="specialTemmateType">特殊同道类型</param>
	/// <param name="fixedCharacterShowNameOnMap">固定角色在地图上是否显示名字</param>
	/// <param name="randomAnimalAttack">动物是否会发起动物袭击过月事件</param>
	/// <param name="xiangshuInfectedDemonBonus">受失心魔加成</param>
	/// <param name="allowHeal">是否会疗伤驱毒 - 0：不会，1：会</param>
	/// <param name="canBeKidnapped">是否能被捕捉 - 角色在战斗中可以用绳索劫持</param>
	/// <param name="randomFeaturesAtCreating">是否随机特性</param>
	/// <param name="featureIds">特性列表 - 关联到 CharacterFeature 表. 不支持填写相枢入魔相关特性, 这些特性是根据入魔值计算出来的.</param>
	/// <param name="minionGroupId">手下</param>
	/// <param name="challengeModeMinionGroupId">玄狱手下</param>
	/// <param name="randomEnemyId">随机敌人信息 ID - 关联到 RandomEnemy 表</param>
	/// <param name="leadingEnemyNestId">所领导的巢穴类型 ID - 关联到 EnemyNest 表</param>
	/// <param name="allowFavorabilitySkipCd">允许跳过指令 CD</param>
	/// <param name="randomEnemyFavorability">与主战角色初始好感权重 - 依次为 [-30000, -18000]、(-18000, 0]、(0, 18000)、[18000, 30000] 四个区间的概率，随机选取区间后在区间内随机具体值</param>
	/// <param name="gender">性别 - 0: 女, 1: 男, -1: 不限制. 固定角色必须设置有效值.</param>
	/// <param name="presetBodyType">预设体型 - 0: 瘦, 1: 普通, 2: 胖, -1: 不限制. 固定角色必须设置有效值.</param>
	/// <param name="race">民族 - 0: 汉族, 1: 藏族.</param>
	/// <param name="transgender">异性相 - 性征和性别是否相反</param>
	/// <param name="bisexual">双性向 - 性取向是否同时包含同性和异性</param>
	/// <param name="presetFame">预设名誉 - 非智能角色的名誉不做计算, 直接使用预设名誉. [-100, 100].</param>
	/// <param name="happiness">心情 - 取值范围 (-120, -90]: 悲极, (-90, -60]: 痛苦, (-60, -30]: 沮丧, (-30, 30): 寻常, [30, 60): 开怀, [60, 90): 欢喜, [90, 120): 乐极.</param>
	/// <param name="baseAttraction">基础魅力 - 取值范围 [0, 900], 小于 0 表示随机. [0, 100): 非人, [100, 200): 可憎, [200, 300): 不扬, [300, 400): 寻常, [400, 500): 出众, [500, 600): 瑾瑜/瑶碧, [600, 700): 龙姿/凤仪, [700, 800): 绝世/出尘, [800, 900]: 天人. 固定角色必须设置有效值.</param>
	/// <param name="baseMorality">基础立场 - 取值范围 [-500, 500]. [-500, -375]: 唯我, (-375, -125]: 叛逆, (-125, 125): 中庸, [125, 375): 仁善, [375, 500]: 刚正.</param>
	/// <param name="actualAge">真实年龄 - 对于随机敌人, 必须填写有效年龄.</param>
	/// <param name="initCurrAge">当前年龄 - 初始化时的当前年龄, 不设置时与真实年龄相同.</param>
	/// <param name="health">当前健康 - 以月为单位, 健康值小于等于 0 即死亡. 年龄换算为月后加上健康值不能超过最大健康. 表中的配置只对固定角色有效, 其他角色则是根据算法生成.</param>
	/// <param name="baseMaxHealth">基础最大健康 - 以月为单位. 表中的配置只对固定角色有效, 其他角色则是根据算法生成.</param>
	/// <param name="birthMonth">出生月份 - 正常取值范围 [0, 11], -1 表示随机出生月份.</param>
	/// <param name="organizationInfo">团体信息 - 此字段自动生成, 实际配置字段为 "团体" 和 "阶层".</param>
	/// <param name="specialGradeName">特殊级别称谓 - 特殊人物在门派中可能符合特定的阶层，但其级别称谓并不与一般门派身份相同，可能采用其他称谓，例如百花剧情角色玄无忧与白无恙其团体为百花谷，阶层为8，但其称谓应为“祖师”，故而加入此列，为存在特殊身份称谓的固定角色增加专属的级别称谓。</param>
	/// <param name="idealSect">理想团体 - 值为门派的团体模板 ID. 为无门无派表示没有理想门派，为None表示按照RandomIdealSects的配置进行生成。门派中人的理想门派可以和本门派不同, 但并不意味着此人会背叛师门.</param>
	/// <param name="randomIdealSects">可选随机理想团体 - 不指定理想团体的情况下从该集合中抽取. 如果该集合也不配置则根据代码中的保底逻辑进行随机 (当前逻辑有可能不生成理想团体).</param>
	/// <param name="xiangshuType">相枢类型 - 0: 寻常 (但可能处于相枢入邪或入魔状态), 1: 相枢化身, 2: 相枢真身, 3: 紫竹化身.4: 练功房木人（需按练功房设置的精纯来设置boss能力）</param>
	/// <param name="monkType">出家类型 - 0: 未出家, 1: 非门派道人, 2: 非门派和尚, 129: 门派道人, 130: 门派和尚. 门派出家会赐法号, 非门派出家无法号.</param>
	/// <param name="lifeSkillTypeInterest">技艺兴趣 - 感兴趣的技艺类型，不配置将随机生成</param>
	/// <param name="combatSkillTypeInterest">武学兴趣 - 感兴趣的武学类型，不配置将随机生成</param>
	/// <param name="mainAttributeInterest">主要属性兴趣 - 感兴趣的主要属性类型，不配置将自动生成</param>
	/// <param name="extraEquipmentLoad">额外装备负重 - 特殊角色的额外装备负重配置</param>
	/// <param name="fixWeaponPower">固定武器发挥 - 值不为-1时，人物的武器发挥、功法威力以此设定值为基础值，随后再计算各类特效的影响</param>
	/// <param name="fixArmorPower">固定防具发挥</param>
	/// <param name="fixCombatSkillPower">固定功法威力</param>
	/// <param name="baseMainAttributes">基础主要属性 - 此字段自动生成, 实际配置字段为从 "膂力" 到 "悟性" 的 6 个字段.</param>
	/// <param name="baseHitValues">基础命中 - 此字段自动生成, 实际配置字段为从 "力道" 到 "动心" 的 4 个字段.</param>
	/// <param name="basePenetrations">基础攻击 - 此字段自动生成, 实际配置字段为从 "破体" 到 "破气" 的 2 个字段.</param>
	/// <param name="baseAvoidValues">基础化解 - 此字段自动生成, 实际配置字段为从 "卸力" 到 "守心" 的 4 个字段.</param>
	/// <param name="basePenetrationResists">基础防御 - 此字段自动生成, 实际配置字段为从 "御体" 到 "御气" 的 2 个字段.</param>
	/// <param name="baseRecoveryOfStanceAndBreath">基础架势提气恢复 - 此字段自动生成, 实际配置字段为 "架势" 和 "提气" 字段.</param>
	/// <param name="baseMoveSpeed">基础移动速度 - 影响每次移动后的间隔帧数, 属性越高, 间隔帧数越低.</param>
	/// <param name="baseRecoveryOfFlaw">基础步伐稳健 - 战斗中破绽的解除速度</param>
	/// <param name="baseCastSpeed">基础施展速度 - 功法准备速度</param>
	/// <param name="baseRecoveryOfBlockedAcupoint">基础引气冲关 - 战斗中封穴的解除速度</param>
	/// <param name="baseWeaponSwitchSpeed">基础兵器切换 - 切换武器的速度，越高切换越快.</param>
	/// <param name="baseAttackSpeed">基础攻击速度 - 普通攻击速度</param>
	/// <param name="baseInnerRatio">基础内功发挥 - 每个功法有一个初始的内功可变范围, 增加内功发挥以增加内功比例的变动范围. 必须大于等于 0, 为 0 表示所有功法都不能调整内功比例了.</param>
	/// <param name="baseRecoveryOfQiDisorder">基础调息吐纳 - 内息紊乱的恢复能力 (而不是每月的变化值), 必须大于等于 0.</param>
	/// <param name="basePoisonResists">基础毒素抵抗 - 此字段自动生成, 实际配置字段为从 "烈" 到 "幻" 的 6 个字段.</param>
	/// <param name="innerInjuryImmunity">内伤</param>
	/// <param name="outerInjuryImmunity">外伤</param>
	/// <param name="mindImmunity">失神</param>
	/// <param name="flawImmunity">破绽</param>
	/// <param name="acupointImmunity">点穴</param>
	/// <param name="fatalImmunity">重创</param>
	/// <param name="dieImmunity">必死</param>
	/// <param name="poisonImmunities">毒素免疫 - 此字段自动生成, 实际配置字段为从 "烈" 到 "幻" 的 6 个字段.</param>
	/// <param name="disorderOfQi">内息紊乱</param>
	/// <param name="haveLeftArm">左臂 - 0: 残缺, 1: 完好</param>
	/// <param name="haveRightArm">右臂</param>
	/// <param name="haveLeftLeg">左腿</param>
	/// <param name="haveRightLeg">右腿</param>
	/// <param name="injuries">各部位伤势 - 每个部位两个数值:外伤程度,内伤程度.伤势程度范围:[0,6],0表示未受伤.一共7个部位,分别为:胸背,腰腹,头颈,左臂,右臂,左腿,右腿.最终配置格式为:`{胸背外伤,胸背内伤,腰腹外伤,腰腹内伤,...}`.</param>
	/// <param name="damageSteps">各部位受伤阈值 - 每受一个相应的标记需要受到的伤害量</param>
	/// <param name="extraNeiliAllocation">额外真气</param>
	/// <param name="extraNeili">额外内力 - 通过周天运转之外的手段获得的内力</param>
	/// <param name="consummateLevel">精纯境界</param>
	/// <param name="presetEquipment">预设装备 - 此字段自动生成, 实际配置字段为从 "武器1" 到 "口袋3" 的 17 个字段.</param>
	/// <param name="equipmentLock">装备锁 - 此字段自动生成, 实际配置字段为从 "武器1" 到 "口袋3" 的 17 个字段右边对应的列</param>
	/// <param name="presetInventory">预设行囊 - 单个物品格式: {类型, 模板 ID, 数量}. 类型为字串形式, 参考物品子表表名. 模板 ID 参考各物品子表.</param>
	/// <param name="dropRatePercentAsMainChar">作为主战角色的物品爆率修正比例 - 配置为 100 时为无修正</param>
	/// <param name="dropRatePercentAsTeammate">作为助战角色的物品爆率修正比例</param>
	/// <param name="presetEatingItems">预设服食 - 预设人物服食情况，在生成人物时按顺序令人物服食相应的道具</param>
	/// <param name="allowDropWugKing">允许掉落王蛊</param>
	/// <param name="presetCombatSkills">预设功法 - 模板数据中单个功法的配置格式有以下五种:     `功法模板 ID`     `功法模板 ID, 已读总纲页数, 已读正练书页数, 已读逆练书页数`     `功法模板 ID, 已读总纲页数, {正练页1是否已读, 页2, ...}, {逆练页1是否已读, 页2, ...}`     `功法模板 ID, {总纲类型1是否已读, 类型2, ...}, 已读正练书页数, 已读逆练书页数`     `功法模板 ID, {总纲类型1是否已读, 类型2, ...}, {正练页1是否已读, 页2, ...}, {逆练页1是否已读, 页2, ...}` 已读总纲页数取值范围 [0, 5]. 已读正逆练书页数取值范围 [0, 5]. 总纲类型N是否已读: 指定位置的元素和指定位置的总纲类型对应, 0 为未读, 1 为已读. 总纲类型: 0: 刚正, 1: 仁善, 2: 中庸, 3: 叛逆, 4: 唯我. 正逆练页N是否已读: 指定位置的元素和指定位置的书页对应, 0 为未读, 1 为已读. 示例：     `{3}`: 功法模板 ID 3.     `{5, 2, 3, 0}`: 功法模板 ID 5, 随机两个总纲已读, 正练随机 3 页已读, 逆练全部未读.     `{2, {1,1,0,0,0}, {1,1,1,1,1}, {0,0,1,0,0}}`: 功法模板 ID 2, 已读总纲刚正及仁善, 正练全部已读, 逆练已读第 2 页.</param>
	/// <param name="extraCombatSkillGrids">额外功法栏位</param>
	/// <param name="disableTeammateCommands">禁用同道指令 - 自动生成时不可选取此处配置的助战指令，仅非智能人物有效</param>
	/// <param name="presetTeammateCommands">预设同道指令 - 如果此项不为空数组，则使用此项内的助战指令，替换系统根据人物特性生成的助战指令；仅非智能人物有效</param>
	/// <param name="presetNeiliProportionOfFiveElements">预设内力五行属性 - 只用于FixedCharacter，如果有配置则覆盖当前的内力五行属性 金刚,紫霞,玄阴,纯阳,归元</param>
	/// <param name="ideaAllocationProportion">理想真气分配比例 - 用于替换内力五行类型赋予的真气分配比例，当为{0,0,0,0}时，使用内力类型表中的真气分配比例，否则使用人物表的真气分配比例</param>
	/// <param name="baseLifeSkillQualifications">基础技艺资质 - 此字段自动生成, 实际配置字段为从 "音律" 到 "杂学" 的 16 个字段.</param>
	/// <param name="lifeSkillQualificationGrowthType">技艺资质成长 - 0: 均衡, 1: 早熟, 2: 晚成</param>
	/// <param name="learnedLifeSkills">技艺 - 模板数据中单个技艺的配置格式有以下两种:     `技艺模板 ID, 已读页数`     `技艺模板 ID, {页1是否已读, 页2, ...}` 技艺模板 ID 参考 LifeSkill 表. 已读页数取值范围: [0, 5]. 页N是否已读: 指定位置的元素和指定位置的书页对应, 0 为未读, 1 为已读. 示例:     `{5, 3}`: 技艺模板 ID 5, 随机三页已读.     `{8, {1,1,0,0,0}}`: 技艺模板 ID 8, 前两页已读.</param>
	/// <param name="learnedLifeSkillGrades">简易技艺 - 以16个参数简易的设定人物每种技艺已掌握的品级，如：6，表示人物已完全习会0~6级的对应技艺的所有书页，最终与LearnedLifeSkills参数共同决定人物习得的技艺情况，-1表示未习得任何技艺</param>
	/// <param name="baseCombatSkillQualifications">基础武学资质 - 此字段自动生成, 实际配置字段为从 "内功" 到 "乐器" 的 14 个字段.</param>
	/// <param name="combatSkillQualificationGrowthType">武学资质成长 - 0: 均衡, 1: 早熟, 2: 晚成</param>
	/// <param name="resources">持有资源 - 此字段自动生成, 实际配置字段为从 "食材" 到 "威望" 的 8 个字段，人物生成时，以此为最初的持有资源</param>
	/// <param name="dropResources">掉落资源 - 此字段自动生成, 实际配置字段为从 "食材" 到 "威望" 的 8 个字段，用于影响人物在战斗、较艺、促织决斗后掉落的额外的资源和威望。</param>
	/// <param name="lovingItemSubType">喜好物品类型 - 非智能角色可以手动指定其值, 参见 GameData.Domains.Item.ItemSubType.</param>
	/// <param name="hatingItemSubType">厌恶物品类型 - 非智能角色可以手动指定其值, 参见 GameData.Domains.Item.ItemSubType.</param>
	/// <param name="showLegendaryBookConsumedCloth">奇书堕魔外形</param>
	/// <param name="avatarDataPath">创建时的Avatar数据 - 配置对应的资源路径，会使用该资源覆盖创建出的角色的外貌数据</param>
	public CharacterItem(short templateId, string surname, string givenName, string anonymousTitle, sbyte specialCombatSkeleton, string fixedAvatarName, string fixedAvatarSpineName, string fixedAvatarSpineSkin, byte creatingType, short groupId, int combatAi, bool canDefeat, bool canMove, bool canOpenCharacterMenu, bool isFavorabilityDisplay, bool hideAge, bool allowUseFreeWeapon, bool allowEscape, bool canSpeak, bool canBeTaiwu, bool canBePossessionBody, bool canBePossessionSoul, string specialMuteBubbleSelf, string specialMuteBubbleEnemy, ECharacterSpecialTemmateType specialTemmateType, bool fixedCharacterShowNameOnMap, bool randomAnimalAttack, bool xiangshuInfectedDemonBonus, bool allowHeal, bool canBeKidnapped, bool randomFeaturesAtCreating, List<short> featureIds, short minionGroupId, short challengeModeMinionGroupId, short randomEnemyId, short leadingEnemyNestId, bool allowFavorabilitySkipCd, sbyte[] randomEnemyFavorability, sbyte gender, sbyte presetBodyType, sbyte race, bool transgender, bool bisexual, sbyte presetFame, sbyte happiness, short baseAttraction, short baseMorality, short actualAge, short initCurrAge, short health, short baseMaxHealth, sbyte birthMonth, OrganizationInfo organizationInfo, string specialGradeName, sbyte idealSect, List<sbyte> randomIdealSects, sbyte xiangshuType, byte monkType, sbyte lifeSkillTypeInterest, sbyte combatSkillTypeInterest, sbyte mainAttributeInterest, int extraEquipmentLoad, short fixWeaponPower, short fixArmorPower, short fixCombatSkillPower, MainAttributes baseMainAttributes, HitOrAvoidInts baseHitValues, OuterAndInnerInts basePenetrations, HitOrAvoidInts baseAvoidValues, OuterAndInnerInts basePenetrationResists, OuterAndInnerShorts baseRecoveryOfStanceAndBreath, short baseMoveSpeed, short baseRecoveryOfFlaw, short baseCastSpeed, short baseRecoveryOfBlockedAcupoint, short baseWeaponSwitchSpeed, short baseAttackSpeed, short baseInnerRatio, short baseRecoveryOfQiDisorder, PoisonInts basePoisonResists, bool innerInjuryImmunity, bool outerInjuryImmunity, bool mindImmunity, bool flawImmunity, bool acupointImmunity, bool fatalImmunity, bool dieImmunity, bool[] poisonImmunities, short disorderOfQi, bool haveLeftArm, bool haveRightArm, bool haveLeftLeg, bool haveRightLeg, Injuries injuries, DamageStepCollection damageSteps, NeiliAllocation extraNeiliAllocation, int extraNeili, sbyte consummateLevel, PresetEquipmentItem[] presetEquipment, bool[] equipmentLock, List<PresetInventoryItem> presetInventory, int dropRatePercentAsMainChar, int dropRatePercentAsTeammate, List<PresetItemTemplateId> presetEatingItems, bool allowDropWugKing, List<PresetCombatSkill> presetCombatSkills, sbyte[] extraCombatSkillGrids, List<sbyte> disableTeammateCommands, List<sbyte> presetTeammateCommands, NeiliProportionOfFiveElements presetNeiliProportionOfFiveElements, sbyte[] ideaAllocationProportion, LifeSkillShorts baseLifeSkillQualifications, sbyte lifeSkillQualificationGrowthType, List<GameData.Domains.Character.LifeSkillItem> learnedLifeSkills, sbyte[] learnedLifeSkillGrades, CombatSkillShorts baseCombatSkillQualifications, sbyte combatSkillQualificationGrowthType, ResourceInts resources, ResourceInts dropResources, short lovingItemSubType, short hatingItemSubType, bool showLegendaryBookConsumedCloth, string avatarDataPath)
	{
		TemplateId = templateId;
		Surname = surname;
		GivenName = givenName;
		AnonymousTitle = anonymousTitle;
		SpecialCombatSkeleton = specialCombatSkeleton;
		FixedAvatarName = fixedAvatarName;
		FixedAvatarSpineName = fixedAvatarSpineName;
		FixedAvatarSpineSkin = fixedAvatarSpineSkin;
		CreatingType = creatingType;
		GroupId = groupId;
		CombatAi = combatAi;
		CanDefeat = canDefeat;
		CanMove = canMove;
		CanOpenCharacterMenu = canOpenCharacterMenu;
		IsFavorabilityDisplay = isFavorabilityDisplay;
		HideAge = hideAge;
		AllowUseFreeWeapon = allowUseFreeWeapon;
		AllowEscape = allowEscape;
		CanSpeak = canSpeak;
		CanBeTaiwu = canBeTaiwu;
		CanBePossessionBody = canBePossessionBody;
		CanBePossessionSoul = canBePossessionSoul;
		SpecialMuteBubbleSelf = specialMuteBubbleSelf;
		SpecialMuteBubbleEnemy = specialMuteBubbleEnemy;
		SpecialTemmateType = specialTemmateType;
		FixedCharacterShowNameOnMap = fixedCharacterShowNameOnMap;
		RandomAnimalAttack = randomAnimalAttack;
		XiangshuInfectedDemonBonus = xiangshuInfectedDemonBonus;
		AllowHeal = allowHeal;
		CanBeKidnapped = canBeKidnapped;
		RandomFeaturesAtCreating = randomFeaturesAtCreating;
		FeatureIds = featureIds;
		MinionGroupId = minionGroupId;
		ChallengeModeMinionGroupId = challengeModeMinionGroupId;
		RandomEnemyId = randomEnemyId;
		LeadingEnemyNestId = leadingEnemyNestId;
		AllowFavorabilitySkipCd = allowFavorabilitySkipCd;
		RandomEnemyFavorability = randomEnemyFavorability;
		Gender = gender;
		PresetBodyType = presetBodyType;
		Race = race;
		Transgender = transgender;
		Bisexual = bisexual;
		PresetFame = presetFame;
		Happiness = happiness;
		BaseAttraction = baseAttraction;
		BaseMorality = baseMorality;
		ActualAge = actualAge;
		InitCurrAge = initCurrAge;
		Health = health;
		BaseMaxHealth = baseMaxHealth;
		BirthMonth = birthMonth;
		OrganizationInfo = organizationInfo;
		SpecialGradeName = specialGradeName;
		IdealSect = idealSect;
		RandomIdealSects = randomIdealSects;
		XiangshuType = xiangshuType;
		MonkType = monkType;
		LifeSkillTypeInterest = lifeSkillTypeInterest;
		CombatSkillTypeInterest = combatSkillTypeInterest;
		MainAttributeInterest = mainAttributeInterest;
		ExtraEquipmentLoad = extraEquipmentLoad;
		FixWeaponPower = fixWeaponPower;
		FixArmorPower = fixArmorPower;
		FixCombatSkillPower = fixCombatSkillPower;
		BaseMainAttributes = baseMainAttributes;
		BaseHitValues = baseHitValues;
		BasePenetrations = basePenetrations;
		BaseAvoidValues = baseAvoidValues;
		BasePenetrationResists = basePenetrationResists;
		BaseRecoveryOfStanceAndBreath = baseRecoveryOfStanceAndBreath;
		BaseMoveSpeed = baseMoveSpeed;
		BaseRecoveryOfFlaw = baseRecoveryOfFlaw;
		BaseCastSpeed = baseCastSpeed;
		BaseRecoveryOfBlockedAcupoint = baseRecoveryOfBlockedAcupoint;
		BaseWeaponSwitchSpeed = baseWeaponSwitchSpeed;
		BaseAttackSpeed = baseAttackSpeed;
		BaseInnerRatio = baseInnerRatio;
		BaseRecoveryOfQiDisorder = baseRecoveryOfQiDisorder;
		BasePoisonResists = basePoisonResists;
		InnerInjuryImmunity = innerInjuryImmunity;
		OuterInjuryImmunity = outerInjuryImmunity;
		MindImmunity = mindImmunity;
		FlawImmunity = flawImmunity;
		AcupointImmunity = acupointImmunity;
		FatalImmunity = fatalImmunity;
		DieImmunity = dieImmunity;
		PoisonImmunities = poisonImmunities;
		DisorderOfQi = disorderOfQi;
		HaveLeftArm = haveLeftArm;
		HaveRightArm = haveRightArm;
		HaveLeftLeg = haveLeftLeg;
		HaveRightLeg = haveRightLeg;
		Injuries = injuries;
		DamageSteps = damageSteps;
		ExtraNeiliAllocation = extraNeiliAllocation;
		ExtraNeili = extraNeili;
		ConsummateLevel = consummateLevel;
		PresetEquipment = presetEquipment;
		EquipmentLock = equipmentLock;
		PresetInventory = presetInventory;
		DropRatePercentAsMainChar = dropRatePercentAsMainChar;
		DropRatePercentAsTeammate = dropRatePercentAsTeammate;
		PresetEatingItems = presetEatingItems;
		AllowDropWugKing = allowDropWugKing;
		PresetCombatSkills = presetCombatSkills;
		ExtraCombatSkillGrids = extraCombatSkillGrids;
		DisableTeammateCommands = disableTeammateCommands;
		PresetTeammateCommands = presetTeammateCommands;
		PresetNeiliProportionOfFiveElements = presetNeiliProportionOfFiveElements;
		IdeaAllocationProportion = ideaAllocationProportion;
		BaseLifeSkillQualifications = baseLifeSkillQualifications;
		LifeSkillQualificationGrowthType = lifeSkillQualificationGrowthType;
		LearnedLifeSkills = learnedLifeSkills;
		LearnedLifeSkillGrades = learnedLifeSkillGrades;
		BaseCombatSkillQualifications = baseCombatSkillQualifications;
		CombatSkillQualificationGrowthType = combatSkillQualificationGrowthType;
		Resources = resources;
		DropResources = dropResources;
		LovingItemSubType = lovingItemSubType;
		HatingItemSubType = hatingItemSubType;
		ShowLegendaryBookConsumedCloth = showLegendaryBookConsumedCloth;
		AvatarDataPath = avatarDataPath;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CharacterItem()
	{
		TemplateId = 0;
		Surname = null;
		GivenName = null;
		AnonymousTitle = null;
		SpecialCombatSkeleton = 0;
		FixedAvatarName = null;
		FixedAvatarSpineName = null;
		FixedAvatarSpineSkin = null;
		CreatingType = 0;
		GroupId = 0;
		CombatAi = 0;
		CanDefeat = true;
		CanMove = true;
		CanOpenCharacterMenu = true;
		IsFavorabilityDisplay = false;
		HideAge = true;
		AllowUseFreeWeapon = true;
		AllowEscape = false;
		CanSpeak = true;
		CanBeTaiwu = true;
		CanBePossessionBody = true;
		CanBePossessionSoul = true;
		SpecialMuteBubbleSelf = null;
		SpecialMuteBubbleEnemy = null;
		SpecialTemmateType = ECharacterSpecialTemmateType.Invalid;
		FixedCharacterShowNameOnMap = true;
		RandomAnimalAttack = false;
		XiangshuInfectedDemonBonus = false;
		AllowHeal = true;
		CanBeKidnapped = true;
		RandomFeaturesAtCreating = false;
		FeatureIds = new List<short>();
		MinionGroupId = 0;
		ChallengeModeMinionGroupId = 0;
		RandomEnemyId = 0;
		LeadingEnemyNestId = 0;
		AllowFavorabilitySkipCd = true;
		RandomEnemyFavorability = new sbyte[4] { 10, 30, 50, 10 };
		Gender = -1;
		PresetBodyType = -1;
		Race = 0;
		Transgender = false;
		Bisexual = false;
		PresetFame = 0;
		Happiness = 0;
		BaseAttraction = -1;
		BaseMorality = 0;
		ActualAge = -1;
		InitCurrAge = -1;
		Health = 0;
		BaseMaxHealth = 0;
		BirthMonth = -1;
		OrganizationInfo = new OrganizationInfo(0, 0, principal: true, -1);
		SpecialGradeName = null;
		IdealSect = 0;
		RandomIdealSects = new List<sbyte>();
		XiangshuType = 0;
		MonkType = 0;
		LifeSkillTypeInterest = 0;
		CombatSkillTypeInterest = 0;
		MainAttributeInterest = -1;
		ExtraEquipmentLoad = 0;
		FixWeaponPower = -1;
		FixArmorPower = -1;
		FixCombatSkillPower = -1;
		BaseMainAttributes = new MainAttributes(30, 30, 30, 30, 30, 30);
		BaseHitValues = new HitOrAvoidInts(default(int), default(int), default(int), default(int));
		BasePenetrations = new OuterAndInnerInts(0, 0);
		BaseAvoidValues = new HitOrAvoidInts(default(int), default(int), default(int), default(int));
		BasePenetrationResists = new OuterAndInnerInts(0, 0);
		BaseRecoveryOfStanceAndBreath = new OuterAndInnerShorts(100, 100);
		BaseMoveSpeed = 100;
		BaseRecoveryOfFlaw = 100;
		BaseCastSpeed = 100;
		BaseRecoveryOfBlockedAcupoint = 100;
		BaseWeaponSwitchSpeed = 100;
		BaseAttackSpeed = 100;
		BaseInnerRatio = 100;
		BaseRecoveryOfQiDisorder = 100;
		BasePoisonResists = new PoisonInts(default(int), default(int), default(int), default(int), default(int), default(int));
		InnerInjuryImmunity = false;
		OuterInjuryImmunity = false;
		MindImmunity = false;
		FlawImmunity = false;
		AcupointImmunity = false;
		FatalImmunity = false;
		DieImmunity = false;
		PoisonImmunities = new bool[6];
		DisorderOfQi = 0;
		HaveLeftArm = true;
		HaveRightArm = true;
		HaveLeftLeg = true;
		HaveRightLeg = true;
		Injuries = new Injuries(default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte));
		DamageSteps = new DamageStepCollection(200, 200, 160, 180, 180, 180, 180, 200, 200, 160, 180, 180, 180, 180, 200, 160);
		ExtraNeiliAllocation = new NeiliAllocation(0, 0, 0, 0);
		ExtraNeili = 0;
		ConsummateLevel = 0;
		PresetEquipment = new PresetEquipmentItem[17]
		{
			new PresetEquipmentItem("Weapon", -1),
			new PresetEquipmentItem("Weapon", -1),
			new PresetEquipmentItem("Weapon", -1),
			new PresetEquipmentItem("Armor", -1),
			new PresetEquipmentItem("Clothing", -1),
			new PresetEquipmentItem("Armor", -1),
			new PresetEquipmentItem("Armor", -1),
			new PresetEquipmentItem("Armor", -1),
			new PresetEquipmentItem("Accessory", -1),
			new PresetEquipmentItem("Accessory", -1),
			new PresetEquipmentItem("Accessory", -1),
			new PresetEquipmentItem("Carrier", -1),
			new PresetEquipmentItem("Carrier", -1),
			new PresetEquipmentItem("Carrier", -1),
			new PresetEquipmentItem("Accessory", -1),
			new PresetEquipmentItem("Accessory", -1),
			new PresetEquipmentItem("Accessory", -1)
		};
		EquipmentLock = new bool[17];
		PresetInventory = new List<PresetInventoryItem>();
		DropRatePercentAsMainChar = 100;
		DropRatePercentAsTeammate = 25;
		PresetEatingItems = new List<PresetItemTemplateId>();
		AllowDropWugKing = true;
		PresetCombatSkills = new List<PresetCombatSkill>();
		ExtraCombatSkillGrids = new sbyte[5];
		DisableTeammateCommands = new List<sbyte>();
		PresetTeammateCommands = new List<sbyte>();
		PresetNeiliProportionOfFiveElements = new NeiliProportionOfFiveElements(default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte));
		IdeaAllocationProportion = new sbyte[4];
		BaseLifeSkillQualifications = new LifeSkillShorts(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short));
		LifeSkillQualificationGrowthType = 0;
		LearnedLifeSkills = new List<GameData.Domains.Character.LifeSkillItem>();
		LearnedLifeSkillGrades = new sbyte[16]
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		};
		BaseCombatSkillQualifications = new CombatSkillShorts(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short));
		CombatSkillQualificationGrowthType = 0;
		Resources = new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int));
		DropResources = new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int));
		LovingItemSubType = -1;
		HatingItemSubType = -1;
		ShowLegendaryBookConsumedCloth = false;
		AvatarDataPath = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CharacterItem(short templateId, CharacterItem other)
	{
		TemplateId = templateId;
		Surname = other.Surname;
		GivenName = other.GivenName;
		AnonymousTitle = other.AnonymousTitle;
		SpecialCombatSkeleton = other.SpecialCombatSkeleton;
		FixedAvatarName = other.FixedAvatarName;
		FixedAvatarSpineName = other.FixedAvatarSpineName;
		FixedAvatarSpineSkin = other.FixedAvatarSpineSkin;
		CreatingType = other.CreatingType;
		GroupId = other.GroupId;
		CombatAi = other.CombatAi;
		CanDefeat = other.CanDefeat;
		CanMove = other.CanMove;
		CanOpenCharacterMenu = other.CanOpenCharacterMenu;
		IsFavorabilityDisplay = other.IsFavorabilityDisplay;
		HideAge = other.HideAge;
		AllowUseFreeWeapon = other.AllowUseFreeWeapon;
		AllowEscape = other.AllowEscape;
		CanSpeak = other.CanSpeak;
		CanBeTaiwu = other.CanBeTaiwu;
		CanBePossessionBody = other.CanBePossessionBody;
		CanBePossessionSoul = other.CanBePossessionSoul;
		SpecialMuteBubbleSelf = other.SpecialMuteBubbleSelf;
		SpecialMuteBubbleEnemy = other.SpecialMuteBubbleEnemy;
		SpecialTemmateType = other.SpecialTemmateType;
		FixedCharacterShowNameOnMap = other.FixedCharacterShowNameOnMap;
		RandomAnimalAttack = other.RandomAnimalAttack;
		XiangshuInfectedDemonBonus = other.XiangshuInfectedDemonBonus;
		AllowHeal = other.AllowHeal;
		CanBeKidnapped = other.CanBeKidnapped;
		RandomFeaturesAtCreating = other.RandomFeaturesAtCreating;
		FeatureIds = other.FeatureIds;
		MinionGroupId = other.MinionGroupId;
		ChallengeModeMinionGroupId = other.ChallengeModeMinionGroupId;
		RandomEnemyId = other.RandomEnemyId;
		LeadingEnemyNestId = other.LeadingEnemyNestId;
		AllowFavorabilitySkipCd = other.AllowFavorabilitySkipCd;
		RandomEnemyFavorability = other.RandomEnemyFavorability;
		Gender = other.Gender;
		PresetBodyType = other.PresetBodyType;
		Race = other.Race;
		Transgender = other.Transgender;
		Bisexual = other.Bisexual;
		PresetFame = other.PresetFame;
		Happiness = other.Happiness;
		BaseAttraction = other.BaseAttraction;
		BaseMorality = other.BaseMorality;
		ActualAge = other.ActualAge;
		InitCurrAge = other.InitCurrAge;
		Health = other.Health;
		BaseMaxHealth = other.BaseMaxHealth;
		BirthMonth = other.BirthMonth;
		OrganizationInfo = other.OrganizationInfo;
		SpecialGradeName = other.SpecialGradeName;
		IdealSect = other.IdealSect;
		RandomIdealSects = other.RandomIdealSects;
		XiangshuType = other.XiangshuType;
		MonkType = other.MonkType;
		LifeSkillTypeInterest = other.LifeSkillTypeInterest;
		CombatSkillTypeInterest = other.CombatSkillTypeInterest;
		MainAttributeInterest = other.MainAttributeInterest;
		ExtraEquipmentLoad = other.ExtraEquipmentLoad;
		FixWeaponPower = other.FixWeaponPower;
		FixArmorPower = other.FixArmorPower;
		FixCombatSkillPower = other.FixCombatSkillPower;
		BaseMainAttributes = other.BaseMainAttributes;
		BaseHitValues = other.BaseHitValues;
		BasePenetrations = other.BasePenetrations;
		BaseAvoidValues = other.BaseAvoidValues;
		BasePenetrationResists = other.BasePenetrationResists;
		BaseRecoveryOfStanceAndBreath = other.BaseRecoveryOfStanceAndBreath;
		BaseMoveSpeed = other.BaseMoveSpeed;
		BaseRecoveryOfFlaw = other.BaseRecoveryOfFlaw;
		BaseCastSpeed = other.BaseCastSpeed;
		BaseRecoveryOfBlockedAcupoint = other.BaseRecoveryOfBlockedAcupoint;
		BaseWeaponSwitchSpeed = other.BaseWeaponSwitchSpeed;
		BaseAttackSpeed = other.BaseAttackSpeed;
		BaseInnerRatio = other.BaseInnerRatio;
		BaseRecoveryOfQiDisorder = other.BaseRecoveryOfQiDisorder;
		BasePoisonResists = other.BasePoisonResists;
		InnerInjuryImmunity = other.InnerInjuryImmunity;
		OuterInjuryImmunity = other.OuterInjuryImmunity;
		MindImmunity = other.MindImmunity;
		FlawImmunity = other.FlawImmunity;
		AcupointImmunity = other.AcupointImmunity;
		FatalImmunity = other.FatalImmunity;
		DieImmunity = other.DieImmunity;
		PoisonImmunities = other.PoisonImmunities;
		DisorderOfQi = other.DisorderOfQi;
		HaveLeftArm = other.HaveLeftArm;
		HaveRightArm = other.HaveRightArm;
		HaveLeftLeg = other.HaveLeftLeg;
		HaveRightLeg = other.HaveRightLeg;
		Injuries = other.Injuries;
		DamageSteps = other.DamageSteps;
		ExtraNeiliAllocation = other.ExtraNeiliAllocation;
		ExtraNeili = other.ExtraNeili;
		ConsummateLevel = other.ConsummateLevel;
		PresetEquipment = other.PresetEquipment;
		EquipmentLock = other.EquipmentLock;
		PresetInventory = other.PresetInventory;
		DropRatePercentAsMainChar = other.DropRatePercentAsMainChar;
		DropRatePercentAsTeammate = other.DropRatePercentAsTeammate;
		PresetEatingItems = other.PresetEatingItems;
		AllowDropWugKing = other.AllowDropWugKing;
		PresetCombatSkills = other.PresetCombatSkills;
		ExtraCombatSkillGrids = other.ExtraCombatSkillGrids;
		DisableTeammateCommands = other.DisableTeammateCommands;
		PresetTeammateCommands = other.PresetTeammateCommands;
		PresetNeiliProportionOfFiveElements = other.PresetNeiliProportionOfFiveElements;
		IdeaAllocationProportion = other.IdeaAllocationProportion;
		BaseLifeSkillQualifications = other.BaseLifeSkillQualifications;
		LifeSkillQualificationGrowthType = other.LifeSkillQualificationGrowthType;
		LearnedLifeSkills = other.LearnedLifeSkills;
		LearnedLifeSkillGrades = other.LearnedLifeSkillGrades;
		BaseCombatSkillQualifications = other.BaseCombatSkillQualifications;
		CombatSkillQualificationGrowthType = other.CombatSkillQualificationGrowthType;
		Resources = other.Resources;
		DropResources = other.DropResources;
		LovingItemSubType = other.LovingItemSubType;
		HatingItemSubType = other.HatingItemSubType;
		ShowLegendaryBookConsumedCloth = other.ShowLegendaryBookConsumedCloth;
		AvatarDataPath = other.AvatarDataPath;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CharacterItem Duplicate(int templateId)
	{
		return new CharacterItem((short)templateId, this);
	}
}
