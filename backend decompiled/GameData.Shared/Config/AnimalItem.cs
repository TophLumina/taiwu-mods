using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class AnimalItem : ConfigItem<AnimalItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly short[] CharacterIdList;

	public readonly string AssetFileName;

	public readonly string AniPrefix;

	public readonly List<sbyte> AttackDistances;

	public readonly List<string> AttackParticles;

	public readonly List<string> AttackSounds;

	public readonly string BlockSound;

	public readonly List<string> JumpMoveParticles;

	public readonly List<string> StepSound;

	public readonly List<string> TeammateCommandBackCharEnterSound;

	public readonly short CatchEffect;

	public readonly short CarrierId;

	public readonly string FailParticle;

	public readonly string FailSound;

	public readonly bool IsElite;

	public CarrierItem Carrier
	{
		[return: MaybeNull]
		get
		{
			return Config.Carrier.Instance.GetItemOrDefault(CarrierId);
		}
	}

	public AnimalItem(sbyte templateId, short[] characterIdList, string assetFileName, string aniPrefix, List<sbyte> attackDistances, List<string> attackParticles, List<string> attackSounds, string blockSound, List<string> jumpMoveParticles, List<string> stepSound, List<string> teammateCommandBackCharEnterSound, short catchEffect, short carrierId, string failParticle, string failSound, bool isElite)
	{
		TemplateId = templateId;
		CharacterIdList = characterIdList;
		AssetFileName = assetFileName;
		AniPrefix = aniPrefix;
		AttackDistances = attackDistances;
		AttackParticles = attackParticles;
		AttackSounds = attackSounds;
		BlockSound = blockSound;
		JumpMoveParticles = jumpMoveParticles;
		StepSound = stepSound;
		TeammateCommandBackCharEnterSound = teammateCommandBackCharEnterSound;
		CatchEffect = catchEffect;
		CarrierId = carrierId;
		FailParticle = failParticle;
		FailSound = failSound;
		IsElite = isElite;
	}

	public AnimalItem()
	{
		TemplateId = 0;
		CharacterIdList = null;
		AssetFileName = null;
		AniPrefix = null;
		AttackDistances = null;
		AttackParticles = null;
		AttackSounds = null;
		BlockSound = null;
		JumpMoveParticles = null;
		StepSound = null;
		TeammateCommandBackCharEnterSound = null;
		CatchEffect = 0;
		CarrierId = 0;
		FailParticle = null;
		FailSound = null;
		IsElite = false;
	}

	public AnimalItem(sbyte templateId, AnimalItem other)
	{
		TemplateId = templateId;
		CharacterIdList = other.CharacterIdList;
		AssetFileName = other.AssetFileName;
		AniPrefix = other.AniPrefix;
		AttackDistances = other.AttackDistances;
		AttackParticles = other.AttackParticles;
		AttackSounds = other.AttackSounds;
		BlockSound = other.BlockSound;
		JumpMoveParticles = other.JumpMoveParticles;
		StepSound = other.StepSound;
		TeammateCommandBackCharEnterSound = other.TeammateCommandBackCharEnterSound;
		CatchEffect = other.CatchEffect;
		CarrierId = other.CarrierId;
		FailParticle = other.FailParticle;
		FailSound = other.FailSound;
		IsElite = other.IsElite;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AnimalItem Duplicate(int templateId)
	{
		return new AnimalItem((sbyte)templateId, this);
	}
}
