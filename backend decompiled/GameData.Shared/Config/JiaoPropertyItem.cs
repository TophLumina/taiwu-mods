using System;
using Config.Common;

namespace Config;

[Serializable]
public class JiaoPropertyItem : ConfigItem<JiaoPropertyItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 显示名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 事件中增加描述
	/// </summary>
	public readonly string EventDescUp;

	/// <summary>
	/// 事件中减少描述
	/// </summary>
	public readonly string EventDescDown;

	/// <summary>
	/// 事件基础增长数值
	/// - 仅用于养育计算的中间值，/100等于其他系统内的实际数值
	/// </summary>
	public readonly int[] EventChange;

	/// <summary>
	/// 逃跑抓回变化数值基础
	/// </summary>
	public readonly int EscapeChange;

	/// <summary>
	/// 激进属性参数
	/// </summary>
	public readonly int AggressivePropertyParam;

	/// <summary>
	/// 激进失败安抚
	/// </summary>
	public readonly int AggressiveComfortParam;

	/// <summary>
	/// 激进失败不安抚
	/// </summary>
	public readonly int AggressiveNotComfortParam;

	/// <summary>
	/// 中立属性参数
	/// </summary>
	public readonly int NeutralityPropertyParam;

	/// <summary>
	/// 保守属性参数
	/// </summary>
	public readonly int ConservedPropertyParam;

	/// <summary>
	/// 保守驯服度参数
	/// </summary>
	public readonly int ConservedTameParam;

	/// <summary>
	/// 最大值
	/// </summary>
	public readonly int MaxValue;

	/// <summary>
	/// 养成事件中的对应选项
	/// </summary>
	public readonly short JiaoRecordTemplateId;

	/// <summary>
	/// 对养成方针的引用
	/// </summary>
	public readonly short JiaoNurturanceTemplateId;

	/// <summary>
	/// 属性在Tips中对应的Icon
	/// </summary>
	public readonly string TipsIcon;

	/// <summary>
	/// 特殊说明标题
	/// </summary>
	public readonly string SpecialDescTitle;

	/// <summary>
	/// 特殊说明
	/// </summary>
	public readonly string SpecialDesc;

	/// <summary>
	/// 正方向是数值增加吗
	/// </summary>
	public readonly bool IncreaseIsGood;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">显示名称</param>
	/// <param name="eventDescUp">事件中增加描述</param>
	/// <param name="eventDescDown">事件中减少描述</param>
	/// <param name="eventChange">事件基础增长数值 - 仅用于养育计算的中间值，/100等于其他系统内的实际数值</param>
	/// <param name="escapeChange">逃跑抓回变化数值基础</param>
	/// <param name="aggressivePropertyParam">激进属性参数</param>
	/// <param name="aggressiveComfortParam">激进失败安抚</param>
	/// <param name="aggressiveNotComfortParam">激进失败不安抚</param>
	/// <param name="neutralityPropertyParam">中立属性参数</param>
	/// <param name="conservedPropertyParam">保守属性参数</param>
	/// <param name="conservedTameParam">保守驯服度参数</param>
	/// <param name="maxValue">最大值</param>
	/// <param name="jiaoRecordTemplateId">养成事件中的对应选项</param>
	/// <param name="jiaoNurturanceTemplateId">对养成方针的引用</param>
	/// <param name="tipsIcon">属性在Tips中对应的Icon</param>
	/// <param name="specialDescTitle">特殊说明标题</param>
	/// <param name="specialDesc">特殊说明</param>
	/// <param name="increaseIsGood">正方向是数值增加吗</param>
	public JiaoPropertyItem(short templateId, string name, string eventDescUp, string eventDescDown, int[] eventChange, int escapeChange, int aggressivePropertyParam, int aggressiveComfortParam, int aggressiveNotComfortParam, int neutralityPropertyParam, int conservedPropertyParam, int conservedTameParam, int maxValue, short jiaoRecordTemplateId, short jiaoNurturanceTemplateId, string tipsIcon, string specialDescTitle, string specialDesc, bool increaseIsGood)
	{
		TemplateId = templateId;
		Name = name;
		EventDescUp = eventDescUp;
		EventDescDown = eventDescDown;
		EventChange = eventChange;
		EscapeChange = escapeChange;
		AggressivePropertyParam = aggressivePropertyParam;
		AggressiveComfortParam = aggressiveComfortParam;
		AggressiveNotComfortParam = aggressiveNotComfortParam;
		NeutralityPropertyParam = neutralityPropertyParam;
		ConservedPropertyParam = conservedPropertyParam;
		ConservedTameParam = conservedTameParam;
		MaxValue = maxValue;
		JiaoRecordTemplateId = jiaoRecordTemplateId;
		JiaoNurturanceTemplateId = jiaoNurturanceTemplateId;
		TipsIcon = tipsIcon;
		SpecialDescTitle = specialDescTitle;
		SpecialDesc = specialDesc;
		IncreaseIsGood = increaseIsGood;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public JiaoPropertyItem()
	{
		TemplateId = 0;
		Name = null;
		EventDescUp = null;
		EventDescDown = null;
		EventChange = new int[0];
		EscapeChange = 0;
		AggressivePropertyParam = 0;
		AggressiveComfortParam = 0;
		AggressiveNotComfortParam = 0;
		NeutralityPropertyParam = 0;
		ConservedPropertyParam = 0;
		ConservedTameParam = 0;
		MaxValue = 0;
		JiaoRecordTemplateId = 0;
		JiaoNurturanceTemplateId = 0;
		TipsIcon = null;
		SpecialDescTitle = null;
		SpecialDesc = null;
		IncreaseIsGood = true;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public JiaoPropertyItem(short templateId, JiaoPropertyItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		EventDescUp = other.EventDescUp;
		EventDescDown = other.EventDescDown;
		EventChange = other.EventChange;
		EscapeChange = other.EscapeChange;
		AggressivePropertyParam = other.AggressivePropertyParam;
		AggressiveComfortParam = other.AggressiveComfortParam;
		AggressiveNotComfortParam = other.AggressiveNotComfortParam;
		NeutralityPropertyParam = other.NeutralityPropertyParam;
		ConservedPropertyParam = other.ConservedPropertyParam;
		ConservedTameParam = other.ConservedTameParam;
		MaxValue = other.MaxValue;
		JiaoRecordTemplateId = other.JiaoRecordTemplateId;
		JiaoNurturanceTemplateId = other.JiaoNurturanceTemplateId;
		TipsIcon = other.TipsIcon;
		SpecialDescTitle = other.SpecialDescTitle;
		SpecialDesc = other.SpecialDesc;
		IncreaseIsGood = other.IncreaseIsGood;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override JiaoPropertyItem Duplicate(int templateId)
	{
		return new JiaoPropertyItem((short)templateId, this);
	}
}
