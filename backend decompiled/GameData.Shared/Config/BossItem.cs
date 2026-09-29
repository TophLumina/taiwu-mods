using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class BossItem : ConfigItem<BossItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly short[] CharacterIdList;

	public readonly string AssetFileName;

	public readonly List<string> AniPrefix;

	public readonly List<string> DefendSkillParticlePrefix;

	public readonly List<string> DefendSkillSoundPrefix;

	public readonly List<string> PetAniPrefix;

	public readonly List<sbyte[]> AttackDistances;

	public readonly string AttackAnimation;

	public readonly List<string> AttackParticles;

	public readonly List<string> AttackSounds;

	public readonly List<string> AttackEffectPostfix;

	public readonly List<string> EatParticles;

	public readonly List<string> TopicalParticles;

	public readonly string FailAnimation;

	public readonly List<string> FailParticles;

	public readonly List<string> FailSounds;

	public readonly string[] FailPetParticles;

	public readonly List<short> CombatConfig;

	public readonly List<short[]> PhaseAttackSkills;

	public readonly bool HasSceneChangeEffect;

	public readonly List<string> JumpMoveParticles;

	public readonly List<short[]> PhaseWeapons;

	public readonly List<string> FailPlayerAni;

	public readonly List<sbyte> FailAniDistance;

	public readonly short FailPlayerAssetSkill;

	public readonly List<short> PlayerCastSkills;

	public readonly List<string> DynamicIllustration;

	public readonly List<string> ShadowTexture;

	public readonly List<short[]> ShadowPos;

	public readonly List<string> IllustrationUnlockParticle;

	public BossItem(sbyte templateId, short[] characterIdList, string assetFileName, List<string> aniPrefix, List<string> defendSkillParticlePrefix, List<string> defendSkillSoundPrefix, List<string> petAniPrefix, List<sbyte[]> attackDistances, string attackAnimation, List<string> attackParticles, List<string> attackSounds, List<string> attackEffectPostfix, List<string> eatParticles, List<string> topicalParticles, string failAnimation, List<string> failParticles, List<string> failSounds, string[] failPetParticles, List<short> combatConfig, List<short[]> phaseAttackSkills, bool hasSceneChangeEffect, List<string> jumpMoveParticles, List<short[]> phaseWeapons, List<string> failPlayerAni, List<sbyte> failAniDistance, short failPlayerAssetSkill, List<short> playerCastSkills, List<string> dynamicIllustration, List<string> shadowTexture, List<short[]> shadowPos, List<string> illustrationUnlockParticle)
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
		CombatConfig = null;
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

	public override BossItem Duplicate(int templateId)
	{
		return new BossItem((sbyte)templateId, this);
	}
}
