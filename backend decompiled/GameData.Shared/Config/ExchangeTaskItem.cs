using System;
using Config.Common;

namespace Config;

[Serializable]
public class ExchangeTaskItem : ConfigItem<ExchangeTaskItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 任务提示文本
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 优势值加成
	/// - 正值为太吾增加，负值为对方增加
	/// </summary>
	public readonly int Advantage;

	/// <summary>
	/// 可加成次数
	/// - 一次交换可触发的数量上限，为-1时为无限
	/// </summary>
	public readonly int Limit;

	/// <summary>
	/// 在太吾将获得物品时生效
	/// - 对应Count &gt; 0
	/// </summary>
	public readonly bool ForTaiwuWillGainItem;

	/// <summary>
	/// 对库房生效
	/// </summary>
	public readonly bool ForTreasury;

	/// <summary>
	/// 对个人生效
	/// </summary>
	public readonly bool ForCharacter;

	/// <summary>
	/// 喜爱
	/// </summary>
	public readonly bool IsTargetLoveItem;

	/// <summary>
	/// 厌恶
	/// </summary>
	public readonly bool IsTargetHateItem;

	/// <summary>
	/// 物品品级符合
	/// - 和赠予物品的限制条件一致，物品品级+2≥此人身份品阶
	/// </summary>
	public readonly bool IsTaiwuItemGradeExceedTargetGrade;

	/// <summary>
	/// 此物品已佩戴
	/// </summary>
	public readonly bool IsTargetEquip;

	/// <summary>
	/// 俘虏为关系者
	/// - 进行交换的俘虏是此人的关系人（包括父母、结义、夫妻、子女、仇敌、朋友、爱慕、师承、手足）
	/// </summary>
	public readonly bool IsTargetHasRelationToKidnapper;

	/// <summary>
	/// 类型
	/// - 进行交换的物品类型是什么（子类型）
	/// </summary>
	public readonly short ItemSubType;

	/// <summary>
	/// 可出现的立场
	/// - 若填写，则对库房不生效
	/// </summary>
	public readonly sbyte[] MeetBehaviourType;

	/// <summary>
	/// 可出现的势力
	/// </summary>
	public readonly short[] MeetOrganization;

	/// <summary>
	/// 可出现的身份品级
	/// </summary>
	public readonly sbyte[] MeetGrade;

	/// <summary>
	/// 可出现的名誉
	/// </summary>
	public readonly sbyte[] MeetFameLevel;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="desc">任务提示文本</param>
	/// <param name="advantage">优势值加成 - 正值为太吾增加，负值为对方增加</param>
	/// <param name="limit">可加成次数 - 一次交换可触发的数量上限，为-1时为无限</param>
	/// <param name="forTaiwuWillGainItem">在太吾将获得物品时生效 - 对应Count &gt; 0</param>
	/// <param name="forTreasury">对库房生效</param>
	/// <param name="forCharacter">对个人生效</param>
	/// <param name="isTargetLoveItem">喜爱</param>
	/// <param name="isTargetHateItem">厌恶</param>
	/// <param name="isTaiwuItemGradeExceedTargetGrade">物品品级符合 - 和赠予物品的限制条件一致，物品品级+2≥此人身份品阶</param>
	/// <param name="isTargetEquip">此物品已佩戴</param>
	/// <param name="isTargetHasRelationToKidnapper">俘虏为关系者 - 进行交换的俘虏是此人的关系人（包括父母、结义、夫妻、子女、仇敌、朋友、爱慕、师承、手足）</param>
	/// <param name="itemSubType">类型 - 进行交换的物品类型是什么（子类型）</param>
	/// <param name="meetBehaviourType">可出现的立场 - 若填写，则对库房不生效</param>
	/// <param name="meetOrganization">可出现的势力</param>
	/// <param name="meetGrade">可出现的身份品级</param>
	/// <param name="meetFameLevel">可出现的名誉</param>
	public ExchangeTaskItem(int templateId, string desc, int advantage, int limit, bool forTaiwuWillGainItem, bool forTreasury, bool forCharacter, bool isTargetLoveItem, bool isTargetHateItem, bool isTaiwuItemGradeExceedTargetGrade, bool isTargetEquip, bool isTargetHasRelationToKidnapper, short itemSubType, sbyte[] meetBehaviourType, short[] meetOrganization, sbyte[] meetGrade, sbyte[] meetFameLevel)
	{
		TemplateId = templateId;
		Desc = desc;
		Advantage = advantage;
		Limit = limit;
		ForTaiwuWillGainItem = forTaiwuWillGainItem;
		ForTreasury = forTreasury;
		ForCharacter = forCharacter;
		IsTargetLoveItem = isTargetLoveItem;
		IsTargetHateItem = isTargetHateItem;
		IsTaiwuItemGradeExceedTargetGrade = isTaiwuItemGradeExceedTargetGrade;
		IsTargetEquip = isTargetEquip;
		IsTargetHasRelationToKidnapper = isTargetHasRelationToKidnapper;
		ItemSubType = itemSubType;
		MeetBehaviourType = meetBehaviourType;
		MeetOrganization = meetOrganization;
		MeetGrade = meetGrade;
		MeetFameLevel = meetFameLevel;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ExchangeTaskItem()
	{
		TemplateId = 0;
		Desc = null;
		Advantage = 0;
		Limit = -1;
		ForTaiwuWillGainItem = false;
		ForTreasury = false;
		ForCharacter = false;
		IsTargetLoveItem = false;
		IsTargetHateItem = false;
		IsTaiwuItemGradeExceedTargetGrade = false;
		IsTargetEquip = false;
		IsTargetHasRelationToKidnapper = false;
		ItemSubType = 0;
		MeetBehaviourType = null;
		MeetOrganization = null;
		MeetGrade = null;
		MeetFameLevel = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public ExchangeTaskItem(int templateId, ExchangeTaskItem other)
	{
		TemplateId = templateId;
		Desc = other.Desc;
		Advantage = other.Advantage;
		Limit = other.Limit;
		ForTaiwuWillGainItem = other.ForTaiwuWillGainItem;
		ForTreasury = other.ForTreasury;
		ForCharacter = other.ForCharacter;
		IsTargetLoveItem = other.IsTargetLoveItem;
		IsTargetHateItem = other.IsTargetHateItem;
		IsTaiwuItemGradeExceedTargetGrade = other.IsTaiwuItemGradeExceedTargetGrade;
		IsTargetEquip = other.IsTargetEquip;
		IsTargetHasRelationToKidnapper = other.IsTargetHasRelationToKidnapper;
		ItemSubType = other.ItemSubType;
		MeetBehaviourType = other.MeetBehaviourType;
		MeetOrganization = other.MeetOrganization;
		MeetGrade = other.MeetGrade;
		MeetFameLevel = other.MeetFameLevel;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ExchangeTaskItem Duplicate(int templateId)
	{
		return new ExchangeTaskItem(templateId, this);
	}
}
