using System;
using Config.Common;

namespace Config;

[Serializable]
public class FameActionItem : ConfigItem<FameActionItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 名誉增减
	/// - 值为0时，Tips上不显示名誉增减，这类词条通常是正名誉加成或负名誉加成或两者皆有的情况，需要转而显示名誉加成情况
	/// </summary>
	public readonly sbyte Fame;

	/// <summary>
	/// 持续时间
	/// - 单位月
	/// </summary>
	public readonly short Duration;

	/// <summary>
	/// 重复模式
	/// - 0: 时间重置, 1: 时间增加.
	/// </summary>
	public readonly sbyte RepeatType;

	/// <summary>
	/// 最大叠加次数
	/// </summary>
	public readonly short MaxStackCount;

	/// <summary>
	/// 消减时间
	/// - 通过某些行为消减持续时间时的基础值, 单位为月.
	/// </summary>
	public readonly short ReductionTime;

	/// <summary>
	/// 正名誉加成
	/// - 需设定最低-100
	/// </summary>
	public readonly int PositiveFameBonus;

	/// <summary>
	/// 负名誉加成
	/// - 需设定最低-100
	/// </summary>
	public readonly int NegativeFameBonus;

	/// <summary>
	/// 有跳转
	/// - 会根据对方的善恶进跳转到不同的行
	/// </summary>
	public readonly bool HasJump;

	/// <summary>
	/// 善
	/// - 对方为善时跳转到的模板 ID. 若有跳转, 小于 0 表示不记录.
	/// </summary>
	public readonly short GoodJumpId;

	/// <summary>
	/// 恶
	/// - 对方为恶时跳转到的模板 ID. 若有跳转, 小于 0 表示不记录.
	/// </summary>
	public readonly short BadJumpId;

	/// <summary>
	/// 无
	/// - 对方为默默无闻时跳转到的模板 ID. 若有跳转, 小于 0 表示不记录.
	/// </summary>
	public readonly short NormalJumpId;

	/// <summary>
	/// 正派星运
	/// - 正派人物每次获得对应名誉时累积的星运数值
	/// </summary>
	public readonly int GoodSectExtraLegacyPoint;

	/// <summary>
	/// 邪派星运
	/// - 邪派人物每次获得对应名誉时累积的星运数值
	/// </summary>
	public readonly int EvilSectExtraLegacyPoint;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="fame">名誉增减 - 值为0时，Tips上不显示名誉增减，这类词条通常是正名誉加成或负名誉加成或两者皆有的情况，需要转而显示名誉加成情况</param>
	/// <param name="duration">持续时间 - 单位月</param>
	/// <param name="repeatType">重复模式 - 0: 时间重置, 1: 时间增加.</param>
	/// <param name="maxStackCount">最大叠加次数</param>
	/// <param name="reductionTime">消减时间 - 通过某些行为消减持续时间时的基础值, 单位为月.</param>
	/// <param name="positiveFameBonus">正名誉加成 - 需设定最低-100</param>
	/// <param name="negativeFameBonus">负名誉加成 - 需设定最低-100</param>
	/// <param name="hasJump">有跳转 - 会根据对方的善恶进跳转到不同的行</param>
	/// <param name="goodJumpId">善 - 对方为善时跳转到的模板 ID. 若有跳转, 小于 0 表示不记录.</param>
	/// <param name="badJumpId">恶 - 对方为恶时跳转到的模板 ID. 若有跳转, 小于 0 表示不记录.</param>
	/// <param name="normalJumpId">无 - 对方为默默无闻时跳转到的模板 ID. 若有跳转, 小于 0 表示不记录.</param>
	/// <param name="goodSectExtraLegacyPoint">正派星运 - 正派人物每次获得对应名誉时累积的星运数值</param>
	/// <param name="evilSectExtraLegacyPoint">邪派星运 - 邪派人物每次获得对应名誉时累积的星运数值</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override FameActionItem Duplicate(int templateId)
	{
		return new FameActionItem((short)templateId, this);
	}
}
