using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterMenuFunctionControlItem : ConfigItem<CharacterMenuFunctionControlItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 转赠
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Gift;

	/// <summary>
	/// 筛选
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Filter;

	/// <summary>
	/// 丢弃
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Drop;

	/// <summary>
	/// 投喂
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Feed;

	/// <summary>
	/// 查验
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Check;

	/// <summary>
	/// 修理
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Repair;

	/// <summary>
	/// 拆解
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Disassemble;

	/// <summary>
	/// 服食
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Eat;

	/// <summary>
	/// 交换
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Exchange;

	/// <summary>
	/// 拿取
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Take;

	/// <summary>
	/// 唬骗
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Scam;

	/// <summary>
	/// 偷窃
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Steal;

	/// <summary>
	/// 抢夺
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Rob;

	/// <summary>
	/// 地区主线
	/// </summary>
	public readonly ECharacterMenuFunctionControlType SectStory;

	/// <summary>
	/// 触发事件
	/// </summary>
	public readonly ECharacterMenuFunctionControlType EventTrigger;

	/// <summary>
	/// 突破
	/// </summary>
	public readonly ECharacterMenuFunctionControlType SkillBreak;

	/// <summary>
	/// 装备
	/// </summary>
	public readonly ECharacterMenuFunctionControlType ItemEquip;

	/// <summary>
	/// 运功
	/// </summary>
	public readonly ECharacterMenuFunctionControlType SkillEquip;

	/// <summary>
	/// 内力
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Neili;

	/// <summary>
	/// 用药
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Medicine;

	/// <summary>
	/// 诊疗
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Heal;

	/// <summary>
	/// 铭刻
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Inscribe;

	/// <summary>
	/// 交谈
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Chat;

	/// <summary>
	/// 指令
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Command;

	/// <summary>
	/// 遣离
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Leave;

	/// <summary>
	/// 批量操作
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Batch;

	/// <summary>
	/// 关押互动
	/// </summary>
	public readonly ECharacterMenuFunctionControlType Kidnapped;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="gift">转赠</param>
	/// <param name="filter">筛选</param>
	/// <param name="drop">丢弃</param>
	/// <param name="feed">投喂</param>
	/// <param name="check">查验</param>
	/// <param name="repair">修理</param>
	/// <param name="disassemble">拆解</param>
	/// <param name="eat">服食</param>
	/// <param name="exchange">交换</param>
	/// <param name="take">拿取</param>
	/// <param name="scam">唬骗</param>
	/// <param name="steal">偷窃</param>
	/// <param name="rob">抢夺</param>
	/// <param name="sectStory">地区主线</param>
	/// <param name="eventTrigger">触发事件</param>
	/// <param name="skillBreak">突破</param>
	/// <param name="itemEquip">装备</param>
	/// <param name="skillEquip">运功</param>
	/// <param name="neili">内力</param>
	/// <param name="medicine">用药</param>
	/// <param name="heal">诊疗</param>
	/// <param name="inscribe">铭刻</param>
	/// <param name="chat">交谈</param>
	/// <param name="command">指令</param>
	/// <param name="leave">遣离</param>
	/// <param name="batch">批量操作</param>
	/// <param name="kidnapped">关押互动</param>
	public CharacterMenuFunctionControlItem(short templateId, ECharacterMenuFunctionControlType gift, ECharacterMenuFunctionControlType filter, ECharacterMenuFunctionControlType drop, ECharacterMenuFunctionControlType feed, ECharacterMenuFunctionControlType check, ECharacterMenuFunctionControlType repair, ECharacterMenuFunctionControlType disassemble, ECharacterMenuFunctionControlType eat, ECharacterMenuFunctionControlType exchange, ECharacterMenuFunctionControlType take, ECharacterMenuFunctionControlType scam, ECharacterMenuFunctionControlType steal, ECharacterMenuFunctionControlType rob, ECharacterMenuFunctionControlType sectStory, ECharacterMenuFunctionControlType eventTrigger, ECharacterMenuFunctionControlType skillBreak, ECharacterMenuFunctionControlType itemEquip, ECharacterMenuFunctionControlType skillEquip, ECharacterMenuFunctionControlType neili, ECharacterMenuFunctionControlType medicine, ECharacterMenuFunctionControlType heal, ECharacterMenuFunctionControlType inscribe, ECharacterMenuFunctionControlType chat, ECharacterMenuFunctionControlType command, ECharacterMenuFunctionControlType leave, ECharacterMenuFunctionControlType batch, ECharacterMenuFunctionControlType kidnapped)
	{
		TemplateId = templateId;
		Gift = gift;
		Filter = filter;
		Drop = drop;
		Feed = feed;
		Check = check;
		Repair = repair;
		Disassemble = disassemble;
		Eat = eat;
		Exchange = exchange;
		Take = take;
		Scam = scam;
		Steal = steal;
		Rob = rob;
		SectStory = sectStory;
		EventTrigger = eventTrigger;
		SkillBreak = skillBreak;
		ItemEquip = itemEquip;
		SkillEquip = skillEquip;
		Neili = neili;
		Medicine = medicine;
		Heal = heal;
		Inscribe = inscribe;
		Chat = chat;
		Command = command;
		Leave = leave;
		Batch = batch;
		Kidnapped = kidnapped;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CharacterMenuFunctionControlItem()
	{
		TemplateId = 0;
		Gift = ECharacterMenuFunctionControlType.None;
		Filter = ECharacterMenuFunctionControlType.None;
		Drop = ECharacterMenuFunctionControlType.None;
		Feed = ECharacterMenuFunctionControlType.None;
		Check = ECharacterMenuFunctionControlType.None;
		Repair = ECharacterMenuFunctionControlType.None;
		Disassemble = ECharacterMenuFunctionControlType.None;
		Eat = ECharacterMenuFunctionControlType.None;
		Exchange = ECharacterMenuFunctionControlType.None;
		Take = ECharacterMenuFunctionControlType.None;
		Scam = ECharacterMenuFunctionControlType.None;
		Steal = ECharacterMenuFunctionControlType.None;
		Rob = ECharacterMenuFunctionControlType.None;
		SectStory = ECharacterMenuFunctionControlType.All;
		EventTrigger = ECharacterMenuFunctionControlType.All;
		SkillBreak = ECharacterMenuFunctionControlType.None;
		ItemEquip = ECharacterMenuFunctionControlType.None;
		SkillEquip = ECharacterMenuFunctionControlType.None;
		Neili = ECharacterMenuFunctionControlType.None;
		Medicine = ECharacterMenuFunctionControlType.None;
		Heal = ECharacterMenuFunctionControlType.None;
		Inscribe = ECharacterMenuFunctionControlType.None;
		Chat = ECharacterMenuFunctionControlType.None;
		Command = ECharacterMenuFunctionControlType.None;
		Leave = ECharacterMenuFunctionControlType.None;
		Batch = ECharacterMenuFunctionControlType.None;
		Kidnapped = ECharacterMenuFunctionControlType.None;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CharacterMenuFunctionControlItem(short templateId, CharacterMenuFunctionControlItem other)
	{
		TemplateId = templateId;
		Gift = other.Gift;
		Filter = other.Filter;
		Drop = other.Drop;
		Feed = other.Feed;
		Check = other.Check;
		Repair = other.Repair;
		Disassemble = other.Disassemble;
		Eat = other.Eat;
		Exchange = other.Exchange;
		Take = other.Take;
		Scam = other.Scam;
		Steal = other.Steal;
		Rob = other.Rob;
		SectStory = other.SectStory;
		EventTrigger = other.EventTrigger;
		SkillBreak = other.SkillBreak;
		ItemEquip = other.ItemEquip;
		SkillEquip = other.SkillEquip;
		Neili = other.Neili;
		Medicine = other.Medicine;
		Heal = other.Heal;
		Inscribe = other.Inscribe;
		Chat = other.Chat;
		Command = other.Command;
		Leave = other.Leave;
		Batch = other.Batch;
		Kidnapped = other.Kidnapped;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CharacterMenuFunctionControlItem Duplicate(int templateId)
	{
		return new CharacterMenuFunctionControlItem((short)templateId, this);
	}
}
