using System;
using Config.Common;

namespace Config;

[Serializable]
public class MiniGameYuanshanItem : ConfigItem<MiniGameYuanshanItem, byte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly byte TemplateId;

	/// <summary>
	/// 感应程度名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 交换位置次数
	/// </summary>
	public readonly int SwapCount;

	/// <summary>
	/// 交换位置用时
	/// </summary>
	public readonly float SwapDuration;

	/// <summary>
	/// 感应程度图标置灰
	/// </summary>
	public readonly bool GreyIcon;

	/// <summary>
	/// 特效启用状态
	/// </summary>
	public readonly bool Effect;

	/// <summary>
	/// 黄光特效展示状态
	/// </summary>
	public readonly bool[] EnableEffect;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">感应程度名称</param>
	/// <param name="swapCount">交换位置次数</param>
	/// <param name="swapDuration">交换位置用时</param>
	/// <param name="greyIcon">感应程度图标置灰</param>
	/// <param name="effect">特效启用状态</param>
	/// <param name="enableEffect">黄光特效展示状态</param>
	public MiniGameYuanshanItem(byte templateId, string name, int swapCount, float swapDuration, bool greyIcon, bool effect, bool[] enableEffect)
	{
		TemplateId = templateId;
		Name = name;
		SwapCount = swapCount;
		SwapDuration = swapDuration;
		GreyIcon = greyIcon;
		Effect = effect;
		EnableEffect = enableEffect;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MiniGameYuanshanItem()
	{
		TemplateId = 0;
		Name = null;
		SwapCount = 0;
		SwapDuration = 0f;
		GreyIcon = false;
		Effect = false;
		EnableEffect = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MiniGameYuanshanItem(byte templateId, MiniGameYuanshanItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		SwapCount = other.SwapCount;
		SwapDuration = other.SwapDuration;
		GreyIcon = other.GreyIcon;
		Effect = other.Effect;
		EnableEffect = other.EnableEffect;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MiniGameYuanshanItem Duplicate(int templateId)
	{
		return new MiniGameYuanshanItem((byte)templateId, this);
	}
}
