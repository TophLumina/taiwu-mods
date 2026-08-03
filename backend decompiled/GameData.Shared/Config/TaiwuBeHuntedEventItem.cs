using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TaiwuBeHuntedEventItem : ConfigItem<TaiwuBeHuntedEventItem, short>
{
	/// <summary>
	/// ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 首事件
	/// </summary>
	public readonly string HeadEvent;

	/// <summary>
	/// 拒捕事件
	/// </summary>
	public readonly string ResistEvent;

	/// <summary>
	/// 拒捕战胜
	/// </summary>
	public readonly string ResistWinEvent;

	/// <summary>
	/// 拒捕战败
	/// </summary>
	public readonly string ResistLoseEvent;

	/// <summary>
	/// 说服事件
	/// </summary>
	public readonly string PersuadeEvent;

	/// <summary>
	/// 较艺技艺类型
	/// </summary>
	public readonly List<sbyte> LifeSkillCombatTypes;

	/// <summary>
	/// 说服成功
	/// </summary>
	public readonly string PersuadeWinEvent;

	/// <summary>
	/// 说服失败
	/// </summary>
	public readonly string PersuadeLoseEvent;

	/// <summary>
	/// 收买事件
	/// </summary>
	public readonly string BribeEvent;

	/// <summary>
	/// 确认收买
	/// </summary>
	public readonly string BribeConfirmEvent;

	/// <summary>
	/// 投降事件
	/// </summary>
	public readonly string SurrenderEvent;

	/// <summary>
	/// 处罚事件1
	/// </summary>
	public readonly string PunishEvent1;

	/// <summary>
	/// 处罚事件2
	/// </summary>
	public readonly string PunishEvent2;

	/// <summary>
	/// 处罚事件3
	/// </summary>
	public readonly string PunishEvent3;

	/// <summary>
	/// 库房战败事件
	/// - （战败后直接跳转到此事件，再跳转处罚事件3）
	/// </summary>
	public readonly string PunishEvent4;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">ID</param>
	/// <param name="name">名称</param>
	/// <param name="headEvent">首事件</param>
	/// <param name="resistEvent">拒捕事件</param>
	/// <param name="resistWinEvent">拒捕战胜</param>
	/// <param name="resistLoseEvent">拒捕战败</param>
	/// <param name="persuadeEvent">说服事件</param>
	/// <param name="lifeSkillCombatTypes">较艺技艺类型</param>
	/// <param name="persuadeWinEvent">说服成功</param>
	/// <param name="persuadeLoseEvent">说服失败</param>
	/// <param name="bribeEvent">收买事件</param>
	/// <param name="bribeConfirmEvent">确认收买</param>
	/// <param name="surrenderEvent">投降事件</param>
	/// <param name="punishEvent1">处罚事件1</param>
	/// <param name="punishEvent2">处罚事件2</param>
	/// <param name="punishEvent3">处罚事件3</param>
	/// <param name="punishEvent4">库房战败事件 - （战败后直接跳转到此事件，再跳转处罚事件3）</param>
	public TaiwuBeHuntedEventItem(short templateId, string name, string headEvent, string resistEvent, string resistWinEvent, string resistLoseEvent, string persuadeEvent, List<sbyte> lifeSkillCombatTypes, string persuadeWinEvent, string persuadeLoseEvent, string bribeEvent, string bribeConfirmEvent, string surrenderEvent, string punishEvent1, string punishEvent2, string punishEvent3, string punishEvent4)
	{
		TemplateId = templateId;
		Name = name;
		HeadEvent = headEvent;
		ResistEvent = resistEvent;
		ResistWinEvent = resistWinEvent;
		ResistLoseEvent = resistLoseEvent;
		PersuadeEvent = persuadeEvent;
		LifeSkillCombatTypes = lifeSkillCombatTypes;
		PersuadeWinEvent = persuadeWinEvent;
		PersuadeLoseEvent = persuadeLoseEvent;
		BribeEvent = bribeEvent;
		BribeConfirmEvent = bribeConfirmEvent;
		SurrenderEvent = surrenderEvent;
		PunishEvent1 = punishEvent1;
		PunishEvent2 = punishEvent2;
		PunishEvent3 = punishEvent3;
		PunishEvent4 = punishEvent4;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public TaiwuBeHuntedEventItem()
	{
		TemplateId = 0;
		Name = null;
		HeadEvent = null;
		ResistEvent = null;
		ResistWinEvent = null;
		ResistLoseEvent = null;
		PersuadeEvent = null;
		LifeSkillCombatTypes = null;
		PersuadeWinEvent = null;
		PersuadeLoseEvent = null;
		BribeEvent = null;
		BribeConfirmEvent = null;
		SurrenderEvent = null;
		PunishEvent1 = null;
		PunishEvent2 = null;
		PunishEvent3 = null;
		PunishEvent4 = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public TaiwuBeHuntedEventItem(short templateId, TaiwuBeHuntedEventItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		HeadEvent = other.HeadEvent;
		ResistEvent = other.ResistEvent;
		ResistWinEvent = other.ResistWinEvent;
		ResistLoseEvent = other.ResistLoseEvent;
		PersuadeEvent = other.PersuadeEvent;
		LifeSkillCombatTypes = other.LifeSkillCombatTypes;
		PersuadeWinEvent = other.PersuadeWinEvent;
		PersuadeLoseEvent = other.PersuadeLoseEvent;
		BribeEvent = other.BribeEvent;
		BribeConfirmEvent = other.BribeConfirmEvent;
		SurrenderEvent = other.SurrenderEvent;
		PunishEvent1 = other.PunishEvent1;
		PunishEvent2 = other.PunishEvent2;
		PunishEvent3 = other.PunishEvent3;
		PunishEvent4 = other.PunishEvent4;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override TaiwuBeHuntedEventItem Duplicate(int templateId)
	{
		return new TaiwuBeHuntedEventItem((short)templateId, this);
	}
}
