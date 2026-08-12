using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class SecretInformationAppliedSelectionItem : ConfigItem<SecretInformationAppliedSelectionItem, short>
{
	/// <summary>
	/// 模板Id
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 通用
	/// - 当通用不为默认值时，无需读取后面的立场差分文本
	/// </summary>
	public readonly string Text;

	/// <summary>
	/// 立场
	/// </summary>
	public readonly string[] SelectionTexts;

	/// <summary>
	/// 互斥选项
	/// - 当某一选项可见并可用时，被它互斥的选项不会出现
	/// </summary>
	public readonly short[] MutexSelectionIds;

	/// <summary>
	/// 排序
	/// - 数字越大，选项所排的位置越靠后；-1默认排最后（但是因为现在的事件系统暂时做不到通过代码控制选项的生成和排序，所以一些带立场的选项会被排到前面，此顺序只能作为参考）
	/// </summary>
	public readonly short Priority;

	/// <summary>
	/// 耗时
	/// </summary>
	public readonly sbyte TimeCost;

	/// <summary>
	/// 消耗属性
	/// </summary>
	public readonly PropertyAndValue MainAttributeCost;

	/// <summary>
	/// 配置
	/// - 此项有内容时，必须满足全部条件选项才可见
	/// </summary>
	public readonly List<ShortList> SpecialConditionId;

	/// <summary>
	/// 配置2
	/// - 此项存在条件时，满足其一选项可见
	/// </summary>
	public readonly List<ShortList> SpecialConditionId2;

	public readonly sbyte[] FameConditions;

	/// <summary>
	/// 玩家立场
	/// </summary>
	public readonly short[] PlayerBehaviorTypeIds;

	/// <summary>
	/// 好感要求
	/// - 当人物对玩家的好感不低于要求的等级时，选项可用
	/// </summary>
	public readonly sbyte FavorabilityCondition;

	/// <summary>
	/// 结果事件1
	/// </summary>
	public readonly short ResultId1;

	/// <summary>
	/// 结果事件2
	/// </summary>
	public readonly short ResultId2;

	/// <summary>
	/// 结果2条件
	/// - 当对方对玩家的好感低于此好感等级时，跳转到结果事件2；喜爱4，亲密5，不渝6，其余数值参见FavorabilityType.cs
	/// </summary>
	public readonly sbyte[] Result2FavorabilityTypeCondition;

	/// <summary>
	/// 快捷键绑定
	/// - 绑定选择此选项的快捷键
	/// </summary>
	public readonly ESecretInformationAppliedSelectionHotKey HotKey;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板Id</param>
	/// <param name="text">通用 - 当通用不为默认值时，无需读取后面的立场差分文本</param>
	/// <param name="selectionTexts">立场</param>
	/// <param name="mutexSelectionIds">互斥选项 - 当某一选项可见并可用时，被它互斥的选项不会出现</param>
	/// <param name="priority">排序 - 数字越大，选项所排的位置越靠后；-1默认排最后（但是因为现在的事件系统暂时做不到通过代码控制选项的生成和排序，所以一些带立场的选项会被排到前面，此顺序只能作为参考）</param>
	/// <param name="timeCost">耗时</param>
	/// <param name="mainAttributeCost">消耗属性</param>
	/// <param name="specialConditionId">配置 - 此项有内容时，必须满足全部条件选项才可见</param>
	/// <param name="specialConditionId2">配置2 - 此项存在条件时，满足其一选项可见</param>
	/// <param name="fameConditions"></param>
	/// <param name="playerBehaviorTypeIds">玩家立场</param>
	/// <param name="favorabilityCondition">好感要求 - 当人物对玩家的好感不低于要求的等级时，选项可用</param>
	/// <param name="resultId1">结果事件1</param>
	/// <param name="resultId2">结果事件2</param>
	/// <param name="result2FavorabilityTypeCondition">结果2条件 - 当对方对玩家的好感低于此好感等级时，跳转到结果事件2；喜爱4，亲密5，不渝6，其余数值参见FavorabilityType.cs</param>
	/// <param name="hotKey">快捷键绑定 - 绑定选择此选项的快捷键</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SecretInformationAppliedSelectionItem Duplicate(int templateId)
	{
		return new SecretInformationAppliedSelectionItem((short)templateId, this);
	}
}
