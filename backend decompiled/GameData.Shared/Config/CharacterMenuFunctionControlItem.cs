using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterMenuFunctionControlItem : ConfigItem<CharacterMenuFunctionControlItem, short>
{
	public readonly short TemplateId;

	public readonly ECharacterMenuFunctionControlType Gift;

	public readonly ECharacterMenuFunctionControlType Filter;

	public readonly ECharacterMenuFunctionControlType Drop;

	public readonly ECharacterMenuFunctionControlType Feed;

	public readonly ECharacterMenuFunctionControlType Check;

	public readonly ECharacterMenuFunctionControlType Repair;

	public readonly ECharacterMenuFunctionControlType Disassemble;

	public readonly ECharacterMenuFunctionControlType Eat;

	public readonly ECharacterMenuFunctionControlType Exchange;

	public readonly ECharacterMenuFunctionControlType Take;

	public readonly ECharacterMenuFunctionControlType Scam;

	public readonly ECharacterMenuFunctionControlType Steal;

	public readonly ECharacterMenuFunctionControlType Rob;

	public readonly ECharacterMenuFunctionControlType SectStory;

	public readonly ECharacterMenuFunctionControlType EventTrigger;

	public readonly ECharacterMenuFunctionControlType SkillBreak;

	public readonly ECharacterMenuFunctionControlType ItemEquip;

	public readonly ECharacterMenuFunctionControlType SkillEquip;

	public readonly ECharacterMenuFunctionControlType Neili;

	public readonly ECharacterMenuFunctionControlType Medicine;

	public readonly ECharacterMenuFunctionControlType Heal;

	public readonly ECharacterMenuFunctionControlType Inscribe;

	public readonly ECharacterMenuFunctionControlType Chat;

	public readonly ECharacterMenuFunctionControlType Command;

	public readonly ECharacterMenuFunctionControlType Leave;

	public readonly ECharacterMenuFunctionControlType Batch;

	public readonly ECharacterMenuFunctionControlType Kidnapped;

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

	public override CharacterMenuFunctionControlItem Duplicate(int templateId)
	{
		return new CharacterMenuFunctionControlItem((short)templateId, this);
	}
}
