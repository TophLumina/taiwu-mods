using System;
using Config.Common;

namespace Config;

[Serializable]
public class WeaponUnlockEffectItem : ConfigItem<WeaponUnlockEffectItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 无视攻击范围
	/// - 判定是否可解封时忽略攻击范围判定（等价于攻击范围锁定为最大）
	/// </summary>
	public readonly bool IgnoreAttackRange;

	/// <summary>
	/// 消除身法
	/// </summary>
	public readonly bool ClearAgile;

	/// <summary>
	/// 消除护体
	/// </summary>
	public readonly bool ClearDefense;

	/// <summary>
	/// 变为旧伤
	/// </summary>
	public readonly bool ChangeToOld;

	/// <summary>
	/// 毒素倍率
	/// - 仅作用于武器施加的毒素
	/// </summary>
	public readonly int PoisonRatio;

	/// <summary>
	/// 施加破绽级别
	/// </summary>
	public readonly sbyte[] FlawLevels;

	/// <summary>
	/// 施加封穴级别
	/// </summary>
	public readonly sbyte[] AcupointLevels;

	/// <summary>
	/// 吸取真气比例
	/// </summary>
	public readonly int StealNeiliAllocationPercent;

	/// <summary>
	/// 封禁功法帧数
	/// </summary>
	public readonly int SilenceSkillFrame;

	/// <summary>
	/// 增加内息紊乱
	/// </summary>
	public readonly int AddQiDisorder;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 解封动画名
	/// </summary>
	public readonly string Animation;

	/// <summary>
	/// 解封特效名
	/// </summary>
	public readonly string Particle;

	/// <summary>
	/// 解封音效名
	/// </summary>
	public readonly string Sound;

	/// <summary>
	/// 解封表现距离
	/// - 按顺序分别为 ready、act1、act2、act3 节点时的表现距离
	/// </summary>
	public readonly sbyte[] DisplayPosition;

	/// <summary>
	/// 解封跳字
	/// </summary>
	public readonly short EffectId;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="ignoreAttackRange">无视攻击范围 - 判定是否可解封时忽略攻击范围判定（等价于攻击范围锁定为最大）</param>
	/// <param name="clearAgile">消除身法</param>
	/// <param name="clearDefense">消除护体</param>
	/// <param name="changeToOld">变为旧伤</param>
	/// <param name="poisonRatio">毒素倍率 - 仅作用于武器施加的毒素</param>
	/// <param name="flawLevels">施加破绽级别</param>
	/// <param name="acupointLevels">施加封穴级别</param>
	/// <param name="stealNeiliAllocationPercent">吸取真气比例</param>
	/// <param name="silenceSkillFrame">封禁功法帧数</param>
	/// <param name="addQiDisorder">增加内息紊乱</param>
	/// <param name="desc">描述</param>
	/// <param name="animation">解封动画名</param>
	/// <param name="particle">解封特效名</param>
	/// <param name="sound">解封音效名</param>
	/// <param name="displayPosition">解封表现距离 - 按顺序分别为 ready、act1、act2、act3 节点时的表现距离</param>
	/// <param name="effectId">解封跳字</param>
	public WeaponUnlockEffectItem(int templateId, bool ignoreAttackRange, bool clearAgile, bool clearDefense, bool changeToOld, int poisonRatio, sbyte[] flawLevels, sbyte[] acupointLevels, int stealNeiliAllocationPercent, int silenceSkillFrame, int addQiDisorder, string desc, string animation, string particle, string sound, sbyte[] displayPosition, short effectId)
	{
		TemplateId = templateId;
		IgnoreAttackRange = ignoreAttackRange;
		ClearAgile = clearAgile;
		ClearDefense = clearDefense;
		ChangeToOld = changeToOld;
		PoisonRatio = poisonRatio;
		FlawLevels = flawLevels;
		AcupointLevels = acupointLevels;
		StealNeiliAllocationPercent = stealNeiliAllocationPercent;
		SilenceSkillFrame = silenceSkillFrame;
		AddQiDisorder = addQiDisorder;
		Desc = desc;
		Animation = animation;
		Particle = particle;
		Sound = sound;
		DisplayPosition = displayPosition;
		EffectId = effectId;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public WeaponUnlockEffectItem()
	{
		TemplateId = 0;
		IgnoreAttackRange = false;
		ClearAgile = false;
		ClearDefense = false;
		ChangeToOld = false;
		PoisonRatio = 1;
		FlawLevels = new sbyte[0];
		AcupointLevels = new sbyte[0];
		StealNeiliAllocationPercent = 0;
		SilenceSkillFrame = 0;
		AddQiDisorder = 0;
		Desc = null;
		Animation = null;
		Particle = null;
		Sound = null;
		DisplayPosition = null;
		EffectId = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public WeaponUnlockEffectItem(int templateId, WeaponUnlockEffectItem other)
	{
		TemplateId = templateId;
		IgnoreAttackRange = other.IgnoreAttackRange;
		ClearAgile = other.ClearAgile;
		ClearDefense = other.ClearDefense;
		ChangeToOld = other.ChangeToOld;
		PoisonRatio = other.PoisonRatio;
		FlawLevels = other.FlawLevels;
		AcupointLevels = other.AcupointLevels;
		StealNeiliAllocationPercent = other.StealNeiliAllocationPercent;
		SilenceSkillFrame = other.SilenceSkillFrame;
		AddQiDisorder = other.AddQiDisorder;
		Desc = other.Desc;
		Animation = other.Animation;
		Particle = other.Particle;
		Sound = other.Sound;
		DisplayPosition = other.DisplayPosition;
		EffectId = other.EffectId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override WeaponUnlockEffectItem Duplicate(int templateId)
	{
		return new WeaponUnlockEffectItem(templateId, this);
	}
}
