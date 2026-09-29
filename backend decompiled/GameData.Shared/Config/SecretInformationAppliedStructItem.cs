using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationAppliedStructItem : ConfigItem<SecretInformationAppliedStructItem, short>
{
	public readonly short TemplateId;

	public readonly short GroupTemplateId;

	public readonly short ContentId1;

	public readonly short ContentId2;

	public readonly List<ShortList> ActorSectPunishSpecialCondition;

	public readonly List<ShortList> ExtraContentIds;

	public readonly sbyte TaiwuIndex;

	public readonly sbyte CharIndex;

	public readonly short[] Selection1;

	public readonly short[] Selection2;

	public readonly List<ShortList> ExtraSelections;

	public readonly short RelationValue;

	public readonly short[] BehaviorTypeValue;

	public SecretInformationAppliedStructItem GroupTemplate
	{
		[return: MaybeNull]
		get
		{
			return SecretInformationAppliedStruct.Instance.GetItemOrDefault(GroupTemplateId);
		}
	}

	public SecretInformationAppliedStructItem(short templateId, short groupTemplateId, short contentId1, short contentId2, List<ShortList> actorSectPunishSpecialCondition, List<ShortList> extraContentIds, sbyte taiwuIndex, sbyte charIndex, short[] selection1, short[] selection2, List<ShortList> extraSelections, short relationValue, short[] behaviorTypeValue)
	{
		TemplateId = templateId;
		GroupTemplateId = groupTemplateId;
		ContentId1 = contentId1;
		ContentId2 = contentId2;
		ActorSectPunishSpecialCondition = actorSectPunishSpecialCondition;
		ExtraContentIds = extraContentIds;
		TaiwuIndex = taiwuIndex;
		CharIndex = charIndex;
		Selection1 = selection1;
		Selection2 = selection2;
		ExtraSelections = extraSelections;
		RelationValue = relationValue;
		BehaviorTypeValue = behaviorTypeValue;
	}

	public SecretInformationAppliedStructItem()
	{
		TemplateId = 0;
		GroupTemplateId = 0;
		ContentId1 = 0;
		ContentId2 = 0;
		ActorSectPunishSpecialCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ExtraContentIds = new List<ShortList>
		{
			new ShortList(-1)
		};
		TaiwuIndex = 0;
		CharIndex = 0;
		Selection1 = new short[0];
		Selection2 = new short[0];
		ExtraSelections = new List<ShortList>
		{
			new ShortList(-1)
		};
		RelationValue = 0;
		BehaviorTypeValue = new short[5] { -1, -1, -1, -1, -1 };
	}

	public SecretInformationAppliedStructItem(short templateId, SecretInformationAppliedStructItem other)
	{
		TemplateId = templateId;
		GroupTemplateId = other.GroupTemplateId;
		ContentId1 = other.ContentId1;
		ContentId2 = other.ContentId2;
		ActorSectPunishSpecialCondition = other.ActorSectPunishSpecialCondition;
		ExtraContentIds = other.ExtraContentIds;
		TaiwuIndex = other.TaiwuIndex;
		CharIndex = other.CharIndex;
		Selection1 = other.Selection1;
		Selection2 = other.Selection2;
		ExtraSelections = other.ExtraSelections;
		RelationValue = other.RelationValue;
		BehaviorTypeValue = other.BehaviorTypeValue;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SecretInformationAppliedStructItem Duplicate(int templateId)
	{
		return new SecretInformationAppliedStructItem((short)templateId, this);
	}
}
