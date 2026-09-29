using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class FameActionItem : ConfigItem<FameActionItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly sbyte Fame;

	public readonly short Duration;

	public readonly sbyte RepeatType;

	public readonly short MaxStackCount;

	public readonly short ReductionTime;

	public readonly int PositiveFameBonus;

	public readonly int NegativeFameBonus;

	public readonly bool HasJump;

	public readonly short GoodJumpId;

	public readonly short BadJumpId;

	public readonly short NormalJumpId;

	public readonly int GoodSectExtraLegacyPoint;

	public readonly int EvilSectExtraLegacyPoint;

	public FameActionItem GoodJump
	{
		[return: MaybeNull]
		get
		{
			return FameAction.Instance.GetItemOrDefault(GoodJumpId);
		}
	}

	public FameActionItem BadJump
	{
		[return: MaybeNull]
		get
		{
			return FameAction.Instance.GetItemOrDefault(BadJumpId);
		}
	}

	public FameActionItem NormalJump
	{
		[return: MaybeNull]
		get
		{
			return FameAction.Instance.GetItemOrDefault(NormalJumpId);
		}
	}

	public FameActionItem(short templateId, string name, sbyte fame, short duration, sbyte repeatType, short maxStackCount, short reductionTime, int positiveFameBonus, int negativeFameBonus, bool hasJump, short goodJumpId, short badJumpId, short normalJumpId, int goodSectExtraLegacyPoint, int evilSectExtraLegacyPoint)
	{
		TemplateId = templateId;
		Name = name;
		Fame = fame;
		Duration = duration;
		RepeatType = repeatType;
		MaxStackCount = maxStackCount;
		ReductionTime = reductionTime;
		PositiveFameBonus = positiveFameBonus;
		NegativeFameBonus = negativeFameBonus;
		HasJump = hasJump;
		GoodJumpId = goodJumpId;
		BadJumpId = badJumpId;
		NormalJumpId = normalJumpId;
		GoodSectExtraLegacyPoint = goodSectExtraLegacyPoint;
		EvilSectExtraLegacyPoint = evilSectExtraLegacyPoint;
	}

	public FameActionItem()
	{
		TemplateId = 0;
		Name = null;
		Fame = 0;
		Duration = 0;
		RepeatType = 0;
		MaxStackCount = 0;
		ReductionTime = 0;
		PositiveFameBonus = 0;
		NegativeFameBonus = 0;
		HasJump = false;
		GoodJumpId = 0;
		BadJumpId = 0;
		NormalJumpId = 0;
		GoodSectExtraLegacyPoint = 0;
		EvilSectExtraLegacyPoint = 0;
	}

	public FameActionItem(short templateId, FameActionItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Fame = other.Fame;
		Duration = other.Duration;
		RepeatType = other.RepeatType;
		MaxStackCount = other.MaxStackCount;
		ReductionTime = other.ReductionTime;
		PositiveFameBonus = other.PositiveFameBonus;
		NegativeFameBonus = other.NegativeFameBonus;
		HasJump = other.HasJump;
		GoodJumpId = other.GoodJumpId;
		BadJumpId = other.BadJumpId;
		NormalJumpId = other.NormalJumpId;
		GoodSectExtraLegacyPoint = other.GoodSectExtraLegacyPoint;
		EvilSectExtraLegacyPoint = other.EvilSectExtraLegacyPoint;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override FameActionItem Duplicate(int templateId)
	{
		return new FameActionItem((short)templateId, this);
	}
}
