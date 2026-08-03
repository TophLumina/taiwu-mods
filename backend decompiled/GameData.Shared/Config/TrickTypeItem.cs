using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TrickTypeItem : ConfigItem<TrickTypeItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 中文名称
	/// - 不需要翻译的使用场景使用此列
	/// </summary>
	public readonly string ChineseName;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 化解类型
	/// - 0-卸力、1-拆招、2-闪避、3-守心
	/// </summary>
	public readonly sbyte AvoidType;

	/// <summary>
	/// 攻击时的表现距离
	/// </summary>
	public readonly sbyte[] AttackDistance;

	/// <summary>
	/// 攻击动作列表
	/// - 配置值为动作/特效/音效名前缀，根据追击次数加上_0~5后缀为最终的动作/特效/音效名
	/// </summary>
	public readonly string[] AttackAnimations;

	/// <summary>
	/// 攻击特效列表
	/// </summary>
	public readonly string[] AttackParticles;

	/// <summary>
	/// 攻击音效列表
	/// </summary>
	public readonly string[] SoundEffects;

	/// <summary>
	/// 攻击部位概率分布
	/// - 由辅助配置列P-V组合，不可直接配置此列
	/// - 对应Combat/BodyPart表中的模板ID
	/// </summary>
	public readonly sbyte[] InjuryPartAtkRateDistribution;

	/// <summary>
	/// 装备损坏概率
	/// </summary>
	public readonly sbyte EquipmentBreakOdds;

	/// <summary>
	/// 字体颜色
	/// </summary>
	public readonly string FontColor;

	/// <summary>
	/// 背景图标
	/// - 用于战斗中的显示
	/// </summary>
	public readonly string BackIcon;

	/// <summary>
	/// 大背景图标
	/// </summary>
	public readonly string BigBackIcon;

	/// <summary>
	/// 化解得式的背景图标
	/// </summary>
	public readonly string AvoidBackIcon;

	/// <summary>
	/// 化解得式的大背景图标
	/// </summary>
	public readonly string AvoidBigBackIcon;

	/// <summary>
	/// 处决动作
	/// - 使用对应式处决时，从列表中随机一个效果播放
	/// </summary>
	public readonly List<StringList> ExecuteAni;

	/// <summary>
	/// 处决特效
	/// </summary>
	public readonly List<StringList> ExecuteParticle;

	/// <summary>
	/// 处决音效
	/// </summary>
	public readonly List<StringList> ExecuteSound;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="chineseName">中文名称 - 不需要翻译的使用场景使用此列</param>
	/// <param name="icon">图标</param>
	/// <param name="desc">描述</param>
	/// <param name="avoidType">化解类型 - 0-卸力、1-拆招、2-闪避、3-守心</param>
	/// <param name="attackDistance">攻击时的表现距离</param>
	/// <param name="attackAnimations">攻击动作列表 - 配置值为动作/特效/音效名前缀，根据追击次数加上_0~5后缀为最终的动作/特效/音效名</param>
	/// <param name="attackParticles">攻击特效列表</param>
	/// <param name="soundEffects">攻击音效列表</param>
	/// <param name="injuryPartAtkRateDistribution">攻击部位概率分布 - 由辅助配置列P-V组合，不可直接配置此列 对应Combat/BodyPart表中的模板ID</param>
	/// <param name="equipmentBreakOdds">装备损坏概率</param>
	/// <param name="fontColor">字体颜色</param>
	/// <param name="backIcon">背景图标 - 用于战斗中的显示</param>
	/// <param name="bigBackIcon">大背景图标</param>
	/// <param name="avoidBackIcon">化解得式的背景图标</param>
	/// <param name="avoidBigBackIcon">化解得式的大背景图标</param>
	/// <param name="executeAni">处决动作 - 使用对应式处决时，从列表中随机一个效果播放</param>
	/// <param name="executeParticle">处决特效</param>
	/// <param name="executeSound">处决音效</param>
	public TrickTypeItem(sbyte templateId, string name, string chineseName, string icon, string desc, sbyte avoidType, sbyte[] attackDistance, string[] attackAnimations, string[] attackParticles, string[] soundEffects, sbyte[] injuryPartAtkRateDistribution, sbyte equipmentBreakOdds, string fontColor, string backIcon, string bigBackIcon, string avoidBackIcon, string avoidBigBackIcon, List<StringList> executeAni, List<StringList> executeParticle, List<StringList> executeSound)
	{
		TemplateId = templateId;
		Name = name;
		ChineseName = chineseName;
		Icon = icon;
		Desc = desc;
		AvoidType = avoidType;
		AttackDistance = attackDistance;
		AttackAnimations = attackAnimations;
		AttackParticles = attackParticles;
		SoundEffects = soundEffects;
		InjuryPartAtkRateDistribution = injuryPartAtkRateDistribution;
		EquipmentBreakOdds = equipmentBreakOdds;
		FontColor = fontColor;
		BackIcon = backIcon;
		BigBackIcon = bigBackIcon;
		AvoidBackIcon = avoidBackIcon;
		AvoidBigBackIcon = avoidBigBackIcon;
		ExecuteAni = executeAni;
		ExecuteParticle = executeParticle;
		ExecuteSound = executeSound;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public TrickTypeItem()
	{
		TemplateId = 0;
		Name = null;
		ChineseName = null;
		Icon = null;
		Desc = null;
		AvoidType = -1;
		AttackDistance = new sbyte[2];
		AttackAnimations = new string[0];
		AttackParticles = new string[0];
		SoundEffects = new string[0];
		InjuryPartAtkRateDistribution = new sbyte[7] { 80, 80, 20, 60, 60, 60, 60 };
		EquipmentBreakOdds = 0;
		FontColor = null;
		BackIcon = null;
		BigBackIcon = null;
		AvoidBackIcon = null;
		AvoidBigBackIcon = null;
		ExecuteAni = new List<StringList>();
		ExecuteParticle = new List<StringList>();
		ExecuteSound = new List<StringList>();
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public TrickTypeItem(sbyte templateId, TrickTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ChineseName = other.ChineseName;
		Icon = other.Icon;
		Desc = other.Desc;
		AvoidType = other.AvoidType;
		AttackDistance = other.AttackDistance;
		AttackAnimations = other.AttackAnimations;
		AttackParticles = other.AttackParticles;
		SoundEffects = other.SoundEffects;
		InjuryPartAtkRateDistribution = other.InjuryPartAtkRateDistribution;
		EquipmentBreakOdds = other.EquipmentBreakOdds;
		FontColor = other.FontColor;
		BackIcon = other.BackIcon;
		BigBackIcon = other.BigBackIcon;
		AvoidBackIcon = other.AvoidBackIcon;
		AvoidBigBackIcon = other.AvoidBigBackIcon;
		ExecuteAni = other.ExecuteAni;
		ExecuteParticle = other.ExecuteParticle;
		ExecuteSound = other.ExecuteSound;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TrickTypeItem Duplicate(int templateId)
	{
		return new TrickTypeItem((sbyte)templateId, this);
	}
}
