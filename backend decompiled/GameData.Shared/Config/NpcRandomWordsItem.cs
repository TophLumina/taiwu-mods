using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class NpcRandomWordsItem : ConfigItem<NpcRandomWordsItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 对话
	/// </summary>
	public readonly string Words;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly ENpcRandomWordsType Type;

	/// <summary>
	/// 权重
	/// - 加入权重x后，此句台词出现的概率将为原有的x倍，权重越高的台词，出现的概率越高
	/// </summary>
	public readonly short Weight;

	/// <summary>
	/// 对方性别
	/// - 对方性别限制，-1:无限制，0:女，1:男
	/// </summary>
	public readonly sbyte TargetGender;

	/// <summary>
	/// 我方性别
	/// - 玩家人物的性别，-1:无限制，0:女，1:男
	/// </summary>
	public readonly sbyte SelfGender;

	/// <summary>
	/// 性取向
	/// - 对方的性取向，-1:无限制，0:异性恋，1:双性恋
	/// </summary>
	public readonly sbyte SexualOrientation;

	public readonly short AgeLimit;

	/// <summary>
	/// 立场
	/// - 对方的立场限制
	/// </summary>
	public readonly short[] BehaviorLimit;

	/// <summary>
	/// 特性
	/// - 对方的人物特性需要满足集合中的任意一个
	/// </summary>
	public readonly List<short> FeatureLimit;

	/// <summary>
	/// 属性
	/// - 某项基础属性满足数值条件才可以出现，格式为{属性名,比较方式,数值}，其中0为大于等于，1为小于等于；比如{主要属性-膂力,0,40}的含义为：需要膂力≥40
	/// </summary>
	public readonly short[] PropertyLimit;

	/// <summary>
	/// 好感
	/// - 对方对玩家的好感范围
	/// </summary>
	public readonly short[] FavorLimit;

	/// <summary>
	/// 关系
	/// - 玩家在对方的关系表中所占的位置，-1.不需要关系，0.敌人，1.朋友，2.祖辈，3.孙辈，4.义/继子女，5.血亲子女，6.配偶，7.血亲父母，8.义父母，9.继父母，10.手足，11.结义，12.单向爱慕，13.双向爱慕，14.恋爱DLC恋人转世初见，15.恋爱DLC恋人转世非初见，16.恋爱DLC太吾转世
	/// </summary>
	public readonly sbyte RelationLimit;

	/// <summary>
	/// 身份
	/// - 对方满足身份集合中的任意一个
	/// </summary>
	public readonly List<short> OrganizationGradeLimit;

	/// <summary>
	/// 称号
	/// - 太吾持有此称号
	/// </summary>
	public readonly List<short> TaiwuTitleLimit;

	/// <summary>
	/// 州域
	/// - 玩家当前所在的州域，旅行时不处于任何州域
	/// </summary>
	public readonly sbyte MapState;

	/// <summary>
	/// 地点
	/// - 包括影响范围，太吾村不属于镇村寨等其它类型
	/// </summary>
	public readonly ENpcRandomWordsLocation Location;

	/// <summary>
	/// 区域
	/// </summary>
	public readonly short MapAreaTemplateId;

	/// <summary>
	/// 是否门派
	/// - 门派定居点还是非门派定居点，并在影响范围内；区域填了此参数才会生效
	/// </summary>
	public readonly bool IsSectSettlement;

	/// <summary>
	/// 世界进度
	/// - 太吾精纯的范围，{精纯下限，精纯上限}，上下限均包含
	/// </summary>
	public readonly sbyte[] XiangshuProgressLimit;

	/// <summary>
	/// 门派名
	/// - 仅填入门派组织时有效，其余值均为不限定
	/// </summary>
	public readonly sbyte SectStoryOrganizationTemplateId;

	/// <summary>
	/// 状态
	/// - 规则： -1=不限定，0=未完成，1=好结局，2=坏结局
	/// </summary>
	public readonly sbyte SectStoryTaskStatus;

	/// <summary>
	/// 地区主线参数
	/// - 地主参数盒子中bool参数为true时通过，依赖地区主线结束状态  门派名  的填写
	/// </summary>
	public readonly string SectStoryBoolParam;

	/// <summary>
	/// 任务
	/// - 需要处于任一任务下
	/// </summary>
	public readonly List<int> NeedTaskInfos;

	/// <summary>
	/// 所属DLC
	/// </summary>
	public readonly uint DlcAppId;

	public NpcRandomWordsItem(short templateId, string words, ENpcRandomWordsType type, short weight, sbyte targetGender, sbyte selfGender, sbyte sexualOrientation, short ageLimit, short[] behaviorLimit, List<short> featureLimit, short[] propertyLimit, short[] favorLimit, sbyte relationLimit, List<short> organizationGradeLimit, List<short> taiwuTitleLimit, sbyte mapState, ENpcRandomWordsLocation location, short mapAreaTemplateId, bool isSectSettlement, sbyte[] xiangshuProgressLimit, sbyte sectStoryOrganizationTemplateId, sbyte sectStoryTaskStatus, string sectStoryBoolParam, List<int> needTaskInfos, uint dlcAppId)
	{
		TemplateId = templateId;
		Words = words;
		Type = type;
		Weight = weight;
		TargetGender = targetGender;
		SelfGender = selfGender;
		SexualOrientation = sexualOrientation;
		AgeLimit = ageLimit;
		BehaviorLimit = behaviorLimit;
		FeatureLimit = featureLimit;
		PropertyLimit = propertyLimit;
		FavorLimit = favorLimit;
		RelationLimit = relationLimit;
		OrganizationGradeLimit = organizationGradeLimit;
		TaiwuTitleLimit = taiwuTitleLimit;
		MapState = mapState;
		Location = location;
		MapAreaTemplateId = mapAreaTemplateId;
		IsSectSettlement = isSectSettlement;
		XiangshuProgressLimit = xiangshuProgressLimit;
		SectStoryOrganizationTemplateId = sectStoryOrganizationTemplateId;
		SectStoryTaskStatus = sectStoryTaskStatus;
		SectStoryBoolParam = sectStoryBoolParam;
		NeedTaskInfos = needTaskInfos;
		DlcAppId = dlcAppId;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public NpcRandomWordsItem()
	{
		TemplateId = 0;
		Words = null;
		Type = ENpcRandomWordsType.Invalid;
		Weight = 1;
		TargetGender = -1;
		SelfGender = -1;
		SexualOrientation = -1;
		AgeLimit = -1;
		BehaviorLimit = new short[2] { -500, 500 };
		FeatureLimit = new List<short>();
		PropertyLimit = null;
		FavorLimit = new short[2] { -30000, 30000 };
		RelationLimit = -1;
		OrganizationGradeLimit = new List<short>();
		TaiwuTitleLimit = new List<short>();
		MapState = 0;
		Location = ENpcRandomWordsLocation.None;
		MapAreaTemplateId = 0;
		IsSectSettlement = false;
		XiangshuProgressLimit = new sbyte[2] { 0, 18 };
		SectStoryOrganizationTemplateId = 0;
		SectStoryTaskStatus = -1;
		SectStoryBoolParam = null;
		NeedTaskInfos = new List<int>();
		DlcAppId = 0u;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public NpcRandomWordsItem(short templateId, NpcRandomWordsItem other)
	{
		TemplateId = templateId;
		Words = other.Words;
		Type = other.Type;
		Weight = other.Weight;
		TargetGender = other.TargetGender;
		SelfGender = other.SelfGender;
		SexualOrientation = other.SexualOrientation;
		AgeLimit = other.AgeLimit;
		BehaviorLimit = other.BehaviorLimit;
		FeatureLimit = other.FeatureLimit;
		PropertyLimit = other.PropertyLimit;
		FavorLimit = other.FavorLimit;
		RelationLimit = other.RelationLimit;
		OrganizationGradeLimit = other.OrganizationGradeLimit;
		TaiwuTitleLimit = other.TaiwuTitleLimit;
		MapState = other.MapState;
		Location = other.Location;
		MapAreaTemplateId = other.MapAreaTemplateId;
		IsSectSettlement = other.IsSectSettlement;
		XiangshuProgressLimit = other.XiangshuProgressLimit;
		SectStoryOrganizationTemplateId = other.SectStoryOrganizationTemplateId;
		SectStoryTaskStatus = other.SectStoryTaskStatus;
		SectStoryBoolParam = other.SectStoryBoolParam;
		NeedTaskInfos = other.NeedTaskInfos;
		DlcAppId = other.DlcAppId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override NpcRandomWordsItem Duplicate(int templateId)
	{
		return new NpcRandomWordsItem((short)templateId, this);
	}
}
