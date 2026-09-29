using System;
using Config.Common;

namespace Config;

[Serializable]
public class CombatItemUseItem : ConfigItem<CombatItemUseItem, short>
{
	public readonly short TemplateId;

	public readonly string Animation;

	public readonly string Particle;

	public readonly string Sound;

	public readonly string BeHitAnimation;

	public readonly short Distance;

	public CombatItemUseItem(short templateId, string animation, string particle, string sound, string beHitAnimation, short distance)
	{
		TemplateId = templateId;
		Animation = animation;
		Particle = particle;
		Sound = sound;
		BeHitAnimation = beHitAnimation;
		Distance = distance;
	}

	public CombatItemUseItem()
	{
		TemplateId = 0;
		Animation = null;
		Particle = null;
		Sound = null;
		BeHitAnimation = null;
		Distance = 0;
	}

	public CombatItemUseItem(short templateId, CombatItemUseItem other)
	{
		TemplateId = templateId;
		Animation = other.Animation;
		Particle = other.Particle;
		Sound = other.Sound;
		BeHitAnimation = other.BeHitAnimation;
		Distance = other.Distance;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CombatItemUseItem Duplicate(int templateId)
	{
		return new CombatItemUseItem((short)templateId, this);
	}
}
