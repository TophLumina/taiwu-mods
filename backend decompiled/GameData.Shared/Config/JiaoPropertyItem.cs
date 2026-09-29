using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class JiaoPropertyItem : ConfigItem<JiaoPropertyItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string EventDescUp;

	public readonly string EventDescDown;

	public readonly int[] EventChange;

	public readonly int EscapeChange;

	public readonly int AggressivePropertyParam;

	public readonly int AggressiveComfortParam;

	public readonly int AggressiveNotComfortParam;

	public readonly int NeutralityPropertyParam;

	public readonly int ConservedPropertyParam;

	public readonly int ConservedTameParam;

	public readonly int MaxValue;

	public readonly short JiaoRecordTemplateId;

	public readonly short JiaoNurturanceTemplateId;

	public readonly string TipsIcon;

	public readonly string SpecialDescTitle;

	public readonly string SpecialDesc;

	public readonly bool IncreaseIsGood;

	public JiaoRecordItem JiaoRecordTemplate
	{
		[return: MaybeNull]
		get
		{
			return JiaoRecord.Instance.GetItemOrDefault(JiaoRecordTemplateId);
		}
	}

	public JiaoNurturanceItem JiaoNurturanceTemplate
	{
		[return: MaybeNull]
		get
		{
			return JiaoNurturance.Instance.GetItemOrDefault(JiaoNurturanceTemplateId);
		}
	}

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

	public override JiaoPropertyItem Duplicate(int templateId)
	{
		return new JiaoPropertyItem((short)templateId, this);
	}
}
