using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LifeRecordItem : ConfigItem<LifeRecordItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 显示名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 参数
	/// - 此字段自动生成, 其数据来自 "参数0" 到 "参数3" 共 4 个字段.
	/// </summary>
	public readonly string[] Parameters;

	/// <summary>
	/// 是否来源经历
	/// - 只有来源经历才会有添加方法, 其关联经历都是被动添加的. 如果一个经历既是来源经历, 又是关联经历, 那么就设置为来源经历.
	/// </summary>
	public readonly bool IsSourceRecord;

	/// <summary>
	/// 关联经历
	/// - 参与经历的另一个角色所对应的经历. 对于经历 A 的关联经历 B 来说, A 也是 B 的关联经历.
	/// </summary>
	public readonly List<short> RelatedIds;

	/// <summary>
	/// 所需好感
	/// - 其他角色查看该条经历所需要的好感. [-30000, -6000]: 仇恨, (-6000, 6000): 陌路, [6000, 10000): 冷淡, [10000, 14000): 融洽, [14000, 18000): 热忱, [18000, 22000): 喜爱, [22000, 26000): 亲密, [26000, 30000]: 不渝.
	/// - 注意：出生经历的好感度可见性在代码里硬编码的，需要修改就联系程序
	/// - 注意：这个值只有大于0才有效，小于0视为这条经历不需要好感要求直接可见
	/// </summary>
	public readonly short RequiredFavorability;

	/// <summary>
	/// 得分类型
	/// - 类型为绝对值时，此月得分固定为此经历的得分分值，有多个绝对值时，取最小的
	/// </summary>
	public readonly ELifeRecordScoreType ScoreType;

	/// <summary>
	/// 得分
	/// - 经历得分将影响经历界面展示时的背景，50分为普通经历无背景，高于50分则为蓝色背景，则此经历对人物是正面，低于50分为红色背景，表负面；得分类型可能为普通值或者计算值，计算值此处应填-1，一般的普通之经历的分值范围为[0,90]。具体的分数在经历视图切换至折线图时，将作为折线上下波动的计算依据。
	/// </summary>
	public readonly short Score;

	/// <summary>
	/// 梦回事件优先度
	/// </summary>
	public readonly sbyte DreamBackEventPriority;

	/// <summary>
	/// 显示类别
	/// </summary>
	public readonly ELifeRecordDisplayType DisplayType;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">显示名称</param>
	/// <param name="desc">描述</param>
	/// <param name="parameters">参数 - 此字段自动生成, 其数据来自 "参数0" 到 "参数3" 共 4 个字段.</param>
	/// <param name="isSourceRecord">是否来源经历 - 只有来源经历才会有添加方法, 其关联经历都是被动添加的. 如果一个经历既是来源经历, 又是关联经历, 那么就设置为来源经历.</param>
	/// <param name="relatedIds">关联经历 - 参与经历的另一个角色所对应的经历. 对于经历 A 的关联经历 B 来说, A 也是 B 的关联经历.</param>
	/// <param name="requiredFavorability">所需好感 - 其他角色查看该条经历所需要的好感. [-30000, -6000]: 仇恨, (-6000, 6000): 陌路, [6000, 10000): 冷淡, [10000, 14000): 融洽, [14000, 18000): 热忱, [18000, 22000): 喜爱, [22000, 26000): 亲密, [26000, 30000]: 不渝. 注意：出生经历的好感度可见性在代码里硬编码的，需要修改就联系程序 注意：这个值只有大于0才有效，小于0视为这条经历不需要好感要求直接可见</param>
	/// <param name="scoreType">得分类型 - 类型为绝对值时，此月得分固定为此经历的得分分值，有多个绝对值时，取最小的</param>
	/// <param name="score">得分 - 经历得分将影响经历界面展示时的背景，50分为普通经历无背景，高于50分则为蓝色背景，则此经历对人物是正面，低于50分为红色背景，表负面；得分类型可能为普通值或者计算值，计算值此处应填-1，一般的普通之经历的分值范围为[0,90]。具体的分数在经历视图切换至折线图时，将作为折线上下波动的计算依据。</param>
	/// <param name="dreamBackEventPriority">梦回事件优先度</param>
	/// <param name="displayType">显示类别</param>
	public LifeRecordItem(short templateId, string name, string desc, string[] parameters, bool isSourceRecord, List<short> relatedIds, short requiredFavorability, ELifeRecordScoreType scoreType, short score, sbyte dreamBackEventPriority, ELifeRecordDisplayType displayType)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Parameters = parameters;
		IsSourceRecord = isSourceRecord;
		RelatedIds = relatedIds;
		RequiredFavorability = requiredFavorability;
		ScoreType = scoreType;
		Score = score;
		DreamBackEventPriority = dreamBackEventPriority;
		DisplayType = displayType;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public LifeRecordItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Parameters = new string[6] { "", "", "", "", "", "" };
		IsSourceRecord = true;
		RelatedIds = new List<short>();
		RequiredFavorability = -30000;
		ScoreType = ELifeRecordScoreType.Invalid;
		Score = -1;
		DreamBackEventPriority = -1;
		DisplayType = ELifeRecordDisplayType.NoCategory;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public LifeRecordItem(short templateId, LifeRecordItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Parameters = other.Parameters;
		IsSourceRecord = other.IsSourceRecord;
		RelatedIds = other.RelatedIds;
		RequiredFavorability = other.RequiredFavorability;
		ScoreType = other.ScoreType;
		Score = other.Score;
		DreamBackEventPriority = other.DreamBackEventPriority;
		DisplayType = other.DisplayType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override LifeRecordItem Duplicate(int templateId)
	{
		return new LifeRecordItem((short)templateId, this);
	}

	public bool CheckParameterCount(int count)
	{
		if (count == 0 || !string.IsNullOrEmpty(Parameters[count - 1]))
		{
			if (count != Parameters.Length)
			{
				return string.IsNullOrEmpty(Parameters[count]);
			}
			return true;
		}
		return false;
	}
}
