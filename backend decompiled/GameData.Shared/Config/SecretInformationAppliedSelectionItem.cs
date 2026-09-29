using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class SecretInformationAppliedSelectionItem : ConfigItem<SecretInformationAppliedSelectionItem, short>
{
	public readonly short TemplateId;

	public readonly string Text;

	public readonly string[] SelectionTexts;

	public readonly short[] MutexSelectionIds;

	public readonly short Priority;

	public readonly sbyte TimeCost;

	public readonly PropertyAndValue MainAttributeCost;

	public readonly List<ShortList> SpecialConditionId;

	public readonly List<ShortList> SpecialConditionId2;

	public readonly sbyte[] FameConditions;

	public readonly short[] PlayerBehaviorTypeIds;

	public readonly sbyte FavorabilityCondition;

	public readonly short ResultId1;

	public readonly short ResultId2;

	public readonly sbyte[] Result2FavorabilityTypeCondition;

	public readonly ESecretInformationAppliedSelectionHotKey HotKey;

	public SecretInformationAppliedSelectionItem(short templateId, string text, string[] selectionTexts, short[] mutexSelectionIds, short priority, sbyte timeCost, PropertyAndValue mainAttributeCost, List<ShortList> specialConditionId, List<ShortList> specialConditionId2, sbyte[] fameConditions, short[] playerBehaviorTypeIds, sbyte favorabilityCondition, short resultId1, short resultId2, sbyte[] result2FavorabilityTypeCondition, ESecretInformationAppliedSelectionHotKey hotKey)
	{
		TemplateId = templateId;
		Text = text;
		SelectionTexts = selectionTexts;
		MutexSelectionIds = mutexSelectionIds;
		Priority = priority;
		TimeCost = timeCost;
		MainAttributeCost = mainAttributeCost;
		SpecialConditionId = specialConditionId;
		SpecialConditionId2 = specialConditionId2;
		FameConditions = fameConditions;
		PlayerBehaviorTypeIds = playerBehaviorTypeIds;
		FavorabilityCondition = favorabilityCondition;
		ResultId1 = resultId1;
		ResultId2 = resultId2;
		Result2FavorabilityTypeCondition = result2FavorabilityTypeCondition;
		HotKey = hotKey;
	}

	public SecretInformationAppliedSelectionItem()
	{
		TemplateId = 0;
		Text = null;
		SelectionTexts = null;
		MutexSelectionIds = new short[0];
		Priority = 0;
		TimeCost = 0;
		MainAttributeCost = default(PropertyAndValue);
		SpecialConditionId = new List<ShortList>
		{
			new ShortList(-1)
		};
		SpecialConditionId2 = new List<ShortList>
		{
			new ShortList(-1)
		};
		FameConditions = new sbyte[4] { -1, -1, -1, -1 };
		PlayerBehaviorTypeIds = new short[0];
		FavorabilityCondition = -6;
		ResultId1 = 0;
		ResultId2 = 0;
		Result2FavorabilityTypeCondition = new sbyte[5] { -6, -6, -6, -6, -6 };
		HotKey = ESecretInformationAppliedSelectionHotKey.Unbound;
	}

	public SecretInformationAppliedSelectionItem(short templateId, SecretInformationAppliedSelectionItem other)
	{
		TemplateId = templateId;
		Text = other.Text;
		SelectionTexts = other.SelectionTexts;
		MutexSelectionIds = other.MutexSelectionIds;
		Priority = other.Priority;
		TimeCost = other.TimeCost;
		MainAttributeCost = other.MainAttributeCost;
		SpecialConditionId = other.SpecialConditionId;
		SpecialConditionId2 = other.SpecialConditionId2;
		FameConditions = other.FameConditions;
		PlayerBehaviorTypeIds = other.PlayerBehaviorTypeIds;
		FavorabilityCondition = other.FavorabilityCondition;
		ResultId1 = other.ResultId1;
		ResultId2 = other.ResultId2;
		Result2FavorabilityTypeCondition = other.Result2FavorabilityTypeCondition;
		HotKey = other.HotKey;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SecretInformationAppliedSelectionItem Duplicate(int templateId)
	{
		return new SecretInformationAppliedSelectionItem((short)templateId, this);
	}
}
