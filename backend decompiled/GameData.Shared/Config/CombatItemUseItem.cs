using System;
using Config.Common;

namespace Config;

[Serializable]
public class CombatItemUseItem : ConfigItem<CombatItemUseItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 动画
	/// </summary>
	public readonly string Animation;

	/// <summary>
	/// 特效
	/// </summary>
	public readonly string Particle;

	/// <summary>
	/// 音效
	/// </summary>
	public readonly string Sound;

	/// <summary>
	/// 命中动画
	/// - 如果有，配在成功对应的行上
	/// </summary>
	public readonly string BeHitAnimation;

	/// <summary>
	/// 表现距离
	/// </summary>
	public readonly short Distance;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="animation">动画</param>
	/// <param name="particle">特效</param>
	/// <param name="sound">音效</param>
	/// <param name="beHitAnimation">命中动画 - 如果有，配在成功对应的行上</param>
	/// <param name="distance">表现距离</param>
	public CombatItemUseItem(short templateId, string animation, string particle, string sound, string beHitAnimation, short distance)
	{
		TemplateId = templateId;
		Animation = animation;
		Particle = particle;
		Sound = sound;
		BeHitAnimation = beHitAnimation;
		Distance = distance;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CombatItemUseItem()
	{
		TemplateId = 0;
		Animation = null;
		Particle = null;
		Sound = null;
		BeHitAnimation = null;
		Distance = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CombatItemUseItem Duplicate(int templateId)
	{
		return new CombatItemUseItem((short)templateId, this);
	}
}
