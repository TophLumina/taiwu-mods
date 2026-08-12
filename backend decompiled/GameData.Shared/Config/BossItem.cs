using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class BossItem : ConfigItem<BossItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 对应人物列表
	/// </summary>
	public readonly short[] CharacterIdList;

	/// <summary>
	/// 资源包名
	/// - Asset文件名
	/// </summary>
	public readonly string AssetFileName;

	/// <summary>
	/// 动画名前缀
	/// - 用于普攻、功法、移动等所有动画
	/// </summary>
	public readonly List<string> AniPrefix;

	/// <summary>
	/// 护体功法特效名前缀
	/// </summary>
	public readonly List<string> DefendSkillParticlePrefix;

	/// <summary>
	/// 护体功法音效名前缀
	/// </summary>
	public readonly List<string> DefendSkillSoundPrefix;

	/// <summary>
	/// 附属骨骼动画名前缀
	/// - 留空表示无附属骨骼
	/// </summary>
	public readonly List<string> PetAniPrefix;

	/// <summary>
	/// 普攻距离
	/// - 依次为每个阶段第1~3把武器的距离
	/// </summary>
	public readonly List<sbyte[]> AttackDistances;

	/// <summary>
	/// 攻击动作
	/// - BOSS各阶段普攻效果。配置值为动作/特效/音效名前缀，根据追击次数加上_0~5后缀为最终的动作/特效/音效名
	/// </summary>
	public readonly string AttackAnimation;

	/// <summary>
	/// 攻击特效列表
	/// </summary>
	public readonly List<string> AttackParticles;

	/// <summary>
	/// 攻击音效列表
	/// </summary>
	public readonly List<string> AttackSounds;

	/// <summary>
	/// 攻击效果名后缀
	/// - 依次为第1~3把武器。不用于音效
	/// </summary>
	public readonly List<string> AttackEffectPostfix;

	/// <summary>
	/// 内服特效列表
	/// </summary>
	public readonly List<string> EatParticles;

	/// <summary>
	/// 外敷特效列表
	/// </summary>
	public readonly List<string> TopicalParticles;

	/// <summary>
	/// 失败动作
	/// </summary>
	public readonly string FailAnimation;

	/// <summary>
	/// 失败特效列表
	/// - BOSS各阶段战败效果
	/// </summary>
	public readonly List<string> FailParticles;

	/// <summary>
	/// 失败音效列表
	/// </summary>
	public readonly List<string> FailSounds;

	/// <summary>
	/// 失败附属骨骼特效列表
	/// </summary>
	public readonly string[] FailPetParticles;

	/// <summary>
	/// 战斗配置
	/// - 仅用于GM指令，正式战斗时配置从外部传入
	/// </summary>
	public readonly short CombatConfig;

	/// <summary>
	/// 各阶段装备的摧破功法
	/// </summary>
	public readonly List<short[]> PhaseAttackSkills;

	/// <summary>
	/// 有无场景变化效果
	/// </summary>
	public readonly bool HasSceneChangeEffect;

	/// <summary>
	/// 蓄力移动特效
	/// </summary>
	public readonly List<string> JumpMoveParticles;

	/// <summary>
	/// 各阶段装备的武器
	/// - 留空则切阶段时不换武器
	/// </summary>
	public readonly List<short[]> PhaseWeapons;

	/// <summary>
	/// 各阶段战败时需播放的玩家动画
	/// </summary>
	public readonly List<string> FailPlayerAni;

	/// <summary>
	/// 各阶段战败表现需要的距离
	/// </summary>
	public readonly List<sbyte> FailAniDistance;

	/// <summary>
	/// 包含战败时玩家动画资源的功法
	/// </summary>
	public readonly short FailPlayerAssetSkill;

	/// <summary>
	/// 玩家可用剑柄施展的功法
	/// - {解1，劫1，解2，劫2}
	/// </summary>
	public readonly List<short> PlayerCastSkills;

	/// <summary>
	/// 动态立绘
	/// - {成年通常，成年笑，成年哭，未成年通常，未成年笑，未成年哭}
	/// </summary>
	public readonly List<string> DynamicIllustration;

	/// <summary>
	/// 剪影贴图
	/// </summary>
	public readonly List<string> ShadowTexture;

	/// <summary>
	/// 剪影位置
	/// - {成年笑，成年哭，未成年笑，未成年哭}
	/// </summary>
	public readonly List<short[]> ShadowPos;

	/// <summary>
	/// 剪影封条消散特效
	/// </summary>
	public readonly List<string> IllustrationUnlockParticle;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="characterIdList">对应人物列表</param>
	/// <param name="assetFileName">资源包名 - Asset文件名</param>
	/// <param name="aniPrefix">动画名前缀 - 用于普攻、功法、移动等所有动画</param>
	/// <param name="defendSkillParticlePrefix">护体功法特效名前缀</param>
	/// <param name="defendSkillSoundPrefix">护体功法音效名前缀</param>
	/// <param name="petAniPrefix">附属骨骼动画名前缀 - 留空表示无附属骨骼</param>
	/// <param name="attackDistances">普攻距离 - 依次为每个阶段第1~3把武器的距离</param>
	/// <param name="attackAnimation">攻击动作 - BOSS各阶段普攻效果。配置值为动作/特效/音效名前缀，根据追击次数加上_0~5后缀为最终的动作/特效/音效名</param>
	/// <param name="attackParticles">攻击特效列表</param>
	/// <param name="attackSounds">攻击音效列表</param>
	/// <param name="attackEffectPostfix">攻击效果名后缀 - 依次为第1~3把武器。不用于音效</param>
	/// <param name="eatParticles">内服特效列表</param>
	/// <param name="topicalParticles">外敷特效列表</param>
	/// <param name="failAnimation">失败动作</param>
	/// <param name="failParticles">失败特效列表 - BOSS各阶段战败效果</param>
	/// <param name="failSounds">失败音效列表</param>
	/// <param name="failPetParticles">失败附属骨骼特效列表</param>
	/// <param name="combatConfig">战斗配置 - 仅用于GM指令，正式战斗时配置从外部传入</param>
	/// <param name="phaseAttackSkills">各阶段装备的摧破功法</param>
	/// <param name="hasSceneChangeEffect">有无场景变化效果</param>
	/// <param name="jumpMoveParticles">蓄力移动特效</param>
	/// <param name="phaseWeapons">各阶段装备的武器 - 留空则切阶段时不换武器</param>
	/// <param name="failPlayerAni">各阶段战败时需播放的玩家动画</param>
	/// <param name="failAniDistance">各阶段战败表现需要的距离</param>
	/// <param name="failPlayerAssetSkill">包含战败时玩家动画资源的功法</param>
	/// <param name="playerCastSkills">玩家可用剑柄施展的功法 - {解1，劫1，解2，劫2}</param>
	/// <param name="dynamicIllustration">动态立绘 - {成年通常，成年笑，成年哭，未成年通常，未成年笑，未成年哭}</param>
	/// <param name="shadowTexture">剪影贴图</param>
	/// <param name="shadowPos">剪影位置 - {成年笑，成年哭，未成年笑，未成年哭}</param>
	/// <param name="illustrationUnlockParticle">剪影封条消散特效</param>
	public BossItem(sbyte templateId, short[] characterIdList, string assetFileName, List<string> aniPrefix, List<string> defendSkillParticlePrefix, List<string> defendSkillSoundPrefix, List<string> petAniPrefix, List<sbyte[]> attackDistances, string attackAnimation, List<string> attackParticles, List<string> attackSounds, List<string> attackEffectPostfix, List<string> eatParticles, List<string> topicalParticles, string failAnimation, List<string> failParticles, List<string> failSounds, string[] failPetParticles, short combatConfig, List<short[]> phaseAttackSkills, bool hasSceneChangeEffect, List<string> jumpMoveParticles, List<short[]> phaseWeapons, List<string> failPlayerAni, List<sbyte> failAniDistance, short failPlayerAssetSkill, List<short> playerCastSkills, List<string> dynamicIllustration, List<string> shadowTexture, List<short[]> shadowPos, List<string> illustrationUnlockParticle)
	{
		TemplateId = templateId;
		CharacterIdList = characterIdList;
		AssetFileName = assetFileName;
		AniPrefix = aniPrefix;
		DefendSkillParticlePrefix = defendSkillParticlePrefix;
		DefendSkillSoundPrefix = defendSkillSoundPrefix;
		PetAniPrefix = petAniPrefix;
		AttackDistances = attackDistances;
		AttackAnimation = attackAnimation;
		AttackParticles = attackParticles;
		AttackSounds = attackSounds;
		AttackEffectPostfix = attackEffectPostfix;
		EatParticles = eatParticles;
		TopicalParticles = topicalParticles;
		FailAnimation = failAnimation;
		FailParticles = failParticles;
		FailSounds = failSounds;
		FailPetParticles = failPetParticles;
		CombatConfig = combatConfig;
		PhaseAttackSkills = phaseAttackSkills;
		HasSceneChangeEffect = hasSceneChangeEffect;
		JumpMoveParticles = jumpMoveParticles;
		PhaseWeapons = phaseWeapons;
		FailPlayerAni = failPlayerAni;
		FailAniDistance = failAniDistance;
		FailPlayerAssetSkill = failPlayerAssetSkill;
		PlayerCastSkills = playerCastSkills;
		DynamicIllustration = dynamicIllustration;
		ShadowTexture = shadowTexture;
		ShadowPos = shadowPos;
		IllustrationUnlockParticle = illustrationUnlockParticle;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public BossItem()
	{
		TemplateId = 0;
		CharacterIdList = null;
		AssetFileName = null;
		AniPrefix = null;
		DefendSkillParticlePrefix = null;
		DefendSkillSoundPrefix = null;
		PetAniPrefix = null;
		AttackDistances = null;
		AttackAnimation = null;
		AttackParticles = null;
		AttackSounds = null;
		AttackEffectPostfix = null;
		EatParticles = null;
		TopicalParticles = null;
		FailAnimation = null;
		FailParticles = null;
		FailSounds = null;
		FailPetParticles = new string[1] { "" };
		CombatConfig = 0;
		PhaseAttackSkills = null;
		HasSceneChangeEffect = true;
		JumpMoveParticles = null;
		PhaseWeapons = null;
		FailPlayerAni = null;
		FailAniDistance = null;
		FailPlayerAssetSkill = 0;
		PlayerCastSkills = new List<short>();
		DynamicIllustration = null;
		ShadowTexture = null;
		ShadowPos = null;
		IllustrationUnlockParticle = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public BossItem(sbyte templateId, BossItem other)
	{
		TemplateId = templateId;
		CharacterIdList = other.CharacterIdList;
		AssetFileName = other.AssetFileName;
		AniPrefix = other.AniPrefix;
		DefendSkillParticlePrefix = other.DefendSkillParticlePrefix;
		DefendSkillSoundPrefix = other.DefendSkillSoundPrefix;
		PetAniPrefix = other.PetAniPrefix;
		AttackDistances = other.AttackDistances;
		AttackAnimation = other.AttackAnimation;
		AttackParticles = other.AttackParticles;
		AttackSounds = other.AttackSounds;
		AttackEffectPostfix = other.AttackEffectPostfix;
		EatParticles = other.EatParticles;
		TopicalParticles = other.TopicalParticles;
		FailAnimation = other.FailAnimation;
		FailParticles = other.FailParticles;
		FailSounds = other.FailSounds;
		FailPetParticles = other.FailPetParticles;
		CombatConfig = other.CombatConfig;
		PhaseAttackSkills = other.PhaseAttackSkills;
		HasSceneChangeEffect = other.HasSceneChangeEffect;
		JumpMoveParticles = other.JumpMoveParticles;
		PhaseWeapons = other.PhaseWeapons;
		FailPlayerAni = other.FailPlayerAni;
		FailAniDistance = other.FailAniDistance;
		FailPlayerAssetSkill = other.FailPlayerAssetSkill;
		PlayerCastSkills = other.PlayerCastSkills;
		DynamicIllustration = other.DynamicIllustration;
		ShadowTexture = other.ShadowTexture;
		ShadowPos = other.ShadowPos;
		IllustrationUnlockParticle = other.IllustrationUnlockParticle;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override BossItem Duplicate(int templateId)
	{
		return new BossItem((sbyte)templateId, this);
	}
}
