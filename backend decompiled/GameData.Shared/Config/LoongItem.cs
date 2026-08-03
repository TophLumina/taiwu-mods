using System;
using Config.Common;

namespace Config;

[Serializable]
public class LoongItem : ConfigItem<LoongItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 人物表模板ID
	/// - 关联其立绘以及战斗相关的属性
	/// </summary>
	public readonly short CharTemplateId;

	/// <summary>
	/// 下属
	/// - 关联人物表
	/// </summary>
	public readonly short MinionCharTemplateId;

	/// <summary>
	/// 地块
	/// - 此神龙所盘踞地形
	/// </summary>
	public readonly short MapBlock;

	/// <summary>
	/// 免伤七元类型
	/// </summary>
	public readonly sbyte PersonalityType;

	/// <summary>
	/// 免伤七元判定值
	/// - 赋性小于此列值的人物将受到损伤
	/// </summary>
	public readonly sbyte PersonalityRequirement;

	/// <summary>
	/// 免伤服饰
	/// </summary>
	public readonly short ClothingTemplateId;

	/// <summary>
	/// 受伤后显示的世界状态
	/// </summary>
	public readonly short WorldState;

	/// <summary>
	/// 地块神力
	/// - 关联人物tips
	/// </summary>
	public readonly string BlockEffectTip;

	/// <summary>
	/// 层数叠加时显示的即时通知
	/// </summary>
	public readonly short DebuffCountIncNotification;

	/// <summary>
	/// 层数消减时的即时通知
	/// </summary>
	public readonly short DebuffCountDecNotification;

	/// <summary>
	/// 战前特效命名
	/// </summary>
	public readonly string EnterCombatEffect;

	/// <summary>
	/// 战前特效音效命名
	/// </summary>
	public readonly string EnterCombatSound;

	/// <summary>
	/// 蛟卵属性
	/// - 击败此神龙时掉落的蛟卵孵化出的蛟，关联Jiao配置表
	/// </summary>
	public readonly short Jiao;

	/// <summary>
	/// 神龙任务
	/// - 此神龙出现在地图上时，对应生成此任务提醒玩家前往击败此神龙；关联任务主表
	/// </summary>
	public readonly short Task;

	/// <summary>
	/// 神龙之害标记
	/// - 当人物持有神龙debuff的时候立绘和人物列表会出现此圆圆的标记，外罩对应特效
	/// </summary>
	public readonly string DebuffMarkOnChar;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="charTemplateId">人物表模板ID - 关联其立绘以及战斗相关的属性</param>
	/// <param name="minionCharTemplateId">下属 - 关联人物表</param>
	/// <param name="mapBlock">地块 - 此神龙所盘踞地形</param>
	/// <param name="personalityType">免伤七元类型</param>
	/// <param name="personalityRequirement">免伤七元判定值 - 赋性小于此列值的人物将受到损伤</param>
	/// <param name="clothingTemplateId">免伤服饰</param>
	/// <param name="worldState">受伤后显示的世界状态</param>
	/// <param name="blockEffectTip">地块神力 - 关联人物tips</param>
	/// <param name="debuffCountIncNotification">层数叠加时显示的即时通知</param>
	/// <param name="debuffCountDecNotification">层数消减时的即时通知</param>
	/// <param name="enterCombatEffect">战前特效命名</param>
	/// <param name="enterCombatSound">战前特效音效命名</param>
	/// <param name="jiao">蛟卵属性 - 击败此神龙时掉落的蛟卵孵化出的蛟，关联Jiao配置表</param>
	/// <param name="task">神龙任务 - 此神龙出现在地图上时，对应生成此任务提醒玩家前往击败此神龙；关联任务主表</param>
	/// <param name="debuffMarkOnChar">神龙之害标记 - 当人物持有神龙debuff的时候立绘和人物列表会出现此圆圆的标记，外罩对应特效</param>
	public LoongItem(short templateId, short charTemplateId, short minionCharTemplateId, short mapBlock, sbyte personalityType, sbyte personalityRequirement, short clothingTemplateId, short worldState, string blockEffectTip, short debuffCountIncNotification, short debuffCountDecNotification, string enterCombatEffect, string enterCombatSound, short jiao, short task, string debuffMarkOnChar)
	{
		TemplateId = templateId;
		CharTemplateId = charTemplateId;
		MinionCharTemplateId = minionCharTemplateId;
		MapBlock = mapBlock;
		PersonalityType = personalityType;
		PersonalityRequirement = personalityRequirement;
		ClothingTemplateId = clothingTemplateId;
		WorldState = worldState;
		BlockEffectTip = blockEffectTip;
		DebuffCountIncNotification = debuffCountIncNotification;
		DebuffCountDecNotification = debuffCountDecNotification;
		EnterCombatEffect = enterCombatEffect;
		EnterCombatSound = enterCombatSound;
		Jiao = jiao;
		Task = task;
		DebuffMarkOnChar = debuffMarkOnChar;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public LoongItem()
	{
		TemplateId = 0;
		CharTemplateId = 0;
		MinionCharTemplateId = 0;
		MapBlock = 0;
		PersonalityType = 0;
		PersonalityRequirement = 0;
		ClothingTemplateId = 0;
		WorldState = 0;
		BlockEffectTip = null;
		DebuffCountIncNotification = 0;
		DebuffCountDecNotification = 0;
		EnterCombatEffect = null;
		EnterCombatSound = null;
		Jiao = 0;
		Task = 0;
		DebuffMarkOnChar = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public LoongItem(short templateId, LoongItem other)
	{
		TemplateId = templateId;
		CharTemplateId = other.CharTemplateId;
		MinionCharTemplateId = other.MinionCharTemplateId;
		MapBlock = other.MapBlock;
		PersonalityType = other.PersonalityType;
		PersonalityRequirement = other.PersonalityRequirement;
		ClothingTemplateId = other.ClothingTemplateId;
		WorldState = other.WorldState;
		BlockEffectTip = other.BlockEffectTip;
		DebuffCountIncNotification = other.DebuffCountIncNotification;
		DebuffCountDecNotification = other.DebuffCountDecNotification;
		EnterCombatEffect = other.EnterCombatEffect;
		EnterCombatSound = other.EnterCombatSound;
		Jiao = other.Jiao;
		Task = other.Task;
		DebuffMarkOnChar = other.DebuffMarkOnChar;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override LoongItem Duplicate(int templateId)
	{
		return new LoongItem((short)templateId, this);
	}
}
