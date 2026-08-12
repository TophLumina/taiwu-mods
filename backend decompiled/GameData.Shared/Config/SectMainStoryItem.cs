using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SectMainStoryItem : ConfigItem<SectMainStoryItem, sbyte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 剧情解锁logo
	/// </summary>
	public readonly string UnlockStoryLogo;

	/// <summary>
	/// 剧情解锁BG
	/// </summary>
	public readonly string UnlockStoryBg;

	/// <summary>
	/// 剧情解锁文本
	/// </summary>
	public readonly string UnlockStoryDesc;

	/// <summary>
	/// 主线任务链
	/// - 该组织对应地区主线的主任务链, 用于判定世界状态的显示.尚未对外开放的门派不填该列.
	/// </summary>
	public readonly int[] TaskChains;

	/// <summary>
	/// 主线任务世界状态
	/// - 地区主线可开启时的世界状态显示.尚未对外开放的门派不填该列.
	/// </summary>
	public readonly sbyte TaskReadyWorldState;

	/// <summary>
	/// 主线结局见闻昌盛
	/// - 地区主线最终昌盛或衰落结局所调用的见闻.尚未对外开放的门派不填该列.
	/// </summary>
	public readonly List<short> GoodEndingsInformation;

	/// <summary>
	/// 主线结局见闻衰落
	/// - 地区主线最终昌盛或衰落结局所调用的见闻.尚未对外开放的门派不填该列.
	/// </summary>
	public readonly List<short> BadEndingsInformation;

	/// <summary>
	/// 主线结局过月事件昌盛
	/// </summary>
	public readonly short GoodEndingMonthlyEvent;

	/// <summary>
	/// 主线结局过月事件衰落
	/// </summary>
	public readonly short BadEndingMonthlyEvent;

	/// <summary>
	/// 好结局日期参数盒子Key
	/// </summary>
	public readonly string GoodEndDateKey;

	/// <summary>
	/// 坏结局日期参数盒子Key
	/// </summary>
	public readonly string BadEndDateKey;

	/// <summary>
	/// 解锁要求击败剑冢数
	/// - 含初始剧情剑冢
	/// </summary>
	public readonly int RequireDefeatSwordTombCount;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="unlockStoryLogo">剧情解锁logo</param>
	/// <param name="unlockStoryBg">剧情解锁BG</param>
	/// <param name="unlockStoryDesc">剧情解锁文本</param>
	/// <param name="taskChains">主线任务链 - 该组织对应地区主线的主任务链, 用于判定世界状态的显示.尚未对外开放的门派不填该列.</param>
	/// <param name="taskReadyWorldState">主线任务世界状态 - 地区主线可开启时的世界状态显示.尚未对外开放的门派不填该列.</param>
	/// <param name="goodEndingsInformation">主线结局见闻昌盛 - 地区主线最终昌盛或衰落结局所调用的见闻.尚未对外开放的门派不填该列.</param>
	/// <param name="badEndingsInformation">主线结局见闻衰落 - 地区主线最终昌盛或衰落结局所调用的见闻.尚未对外开放的门派不填该列.</param>
	/// <param name="goodEndingMonthlyEvent">主线结局过月事件昌盛</param>
	/// <param name="badEndingMonthlyEvent">主线结局过月事件衰落</param>
	/// <param name="goodEndDateKey">好结局日期参数盒子Key</param>
	/// <param name="badEndDateKey">坏结局日期参数盒子Key</param>
	/// <param name="requireDefeatSwordTombCount">解锁要求击败剑冢数 - 含初始剧情剑冢</param>
	public SectMainStoryItem(sbyte templateId, string name, string unlockStoryLogo, string unlockStoryBg, string unlockStoryDesc, int[] taskChains, sbyte taskReadyWorldState, List<short> goodEndingsInformation, List<short> badEndingsInformation, short goodEndingMonthlyEvent, short badEndingMonthlyEvent, string goodEndDateKey, string badEndDateKey, int requireDefeatSwordTombCount)
	{
		TemplateId = templateId;
		Name = name;
		UnlockStoryLogo = unlockStoryLogo;
		UnlockStoryBg = unlockStoryBg;
		UnlockStoryDesc = unlockStoryDesc;
		TaskChains = taskChains;
		TaskReadyWorldState = taskReadyWorldState;
		GoodEndingsInformation = goodEndingsInformation;
		BadEndingsInformation = badEndingsInformation;
		GoodEndingMonthlyEvent = goodEndingMonthlyEvent;
		BadEndingMonthlyEvent = badEndingMonthlyEvent;
		GoodEndDateKey = goodEndDateKey;
		BadEndDateKey = badEndDateKey;
		RequireDefeatSwordTombCount = requireDefeatSwordTombCount;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SectMainStoryItem()
	{
		TemplateId = 0;
		Name = null;
		UnlockStoryLogo = null;
		UnlockStoryBg = null;
		UnlockStoryDesc = null;
		TaskChains = null;
		TaskReadyWorldState = 0;
		GoodEndingsInformation = null;
		BadEndingsInformation = null;
		GoodEndingMonthlyEvent = 0;
		BadEndingMonthlyEvent = 0;
		GoodEndDateKey = null;
		BadEndDateKey = null;
		RequireDefeatSwordTombCount = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SectMainStoryItem(sbyte templateId, SectMainStoryItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		UnlockStoryLogo = other.UnlockStoryLogo;
		UnlockStoryBg = other.UnlockStoryBg;
		UnlockStoryDesc = other.UnlockStoryDesc;
		TaskChains = other.TaskChains;
		TaskReadyWorldState = other.TaskReadyWorldState;
		GoodEndingsInformation = other.GoodEndingsInformation;
		BadEndingsInformation = other.BadEndingsInformation;
		GoodEndingMonthlyEvent = other.GoodEndingMonthlyEvent;
		BadEndingMonthlyEvent = other.BadEndingMonthlyEvent;
		GoodEndDateKey = other.GoodEndDateKey;
		BadEndDateKey = other.BadEndDateKey;
		RequireDefeatSwordTombCount = other.RequireDefeatSwordTombCount;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SectMainStoryItem Duplicate(int templateId)
	{
		return new SectMainStoryItem((sbyte)templateId, this);
	}
}
