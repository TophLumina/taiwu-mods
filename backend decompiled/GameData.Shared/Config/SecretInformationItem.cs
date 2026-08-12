using System;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationItem : ConfigItem<SecretInformationItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 秘闻名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 参数
	/// - 自动生成
	/// </summary>
	public readonly sbyte[] Parameters;

	/// <summary>
	/// 参数在前端不显示（痛失骨肉父亲不可知、生下孩子父亲不可知 这类需要保存父亲参数但是前端又不显示父亲时使用）
	/// </summary>
	public readonly sbyte NotDisplayedParm;

	/// <summary>
	/// 参数Ui名
	/// - 自动生成
	/// </summary>
	public readonly string[] ParametersUiName;

	/// <summary>
	/// 显示尺寸因子
	/// - 注意此列为公式引用到sheet：BlockSizeArgs，因此不要直接在本sheet维护该列
	/// </summary>
	public readonly sbyte[] BlockSizeArgs;

	/// <summary>
	/// 涉及人物数
	/// </summary>
	public readonly byte InvolvedCharacterCount;

	/// <summary>
	/// 涉及物品数
	/// </summary>
	public readonly byte InvolvedItemCount;

	/// <summary>
	/// 涉及功法数
	/// </summary>
	public readonly byte InvolvedCombatSkillCount;

	/// <summary>
	/// 涉及技艺数
	/// </summary>
	public readonly byte InvolvedLifeSkillCount;

	/// <summary>
	/// 涉及位置数
	/// </summary>
	public readonly byte InvolvedLocationCount;

	/// <summary>
	/// 涉及资源类型数
	/// </summary>
	public readonly byte InvolvedResourceTypeCount;

	/// <summary>
	/// 涉及的数值数
	/// </summary>
	public readonly byte InvolvedIntegerDataCount;

	/// <summary>
	/// 自动公开
	/// </summary>
	public readonly bool AutoBroadCast;

	/// <summary>
	/// 消耗威望
	/// - 每次传播此秘闻需要消耗的威望
	/// </summary>
	public readonly short CostAuthority;

	/// <summary>
	/// 固定传播距离
	/// - 设定为负数以启用衰减原则
	/// </summary>
	public readonly sbyte DiffusionRange;

	/// <summary>
	/// 传播速度
	/// - 值越大，越能在一个月中传播给越多的人，如，传播速度5，表示一个月最多能传给5个人
	/// </summary>
	public readonly byte DiffusionSpeed;

	/// <summary>
	/// 名誉要求
	/// - 传播此秘闻的人物的名誉需&gt;=要求的名誉，未达到要求时，秘闻的传播需要的威望=消耗威望*(1+名誉相差的级别*2)
	/// </summary>
	public readonly sbyte FameThreshold;

	/// <summary>
	/// 人数上限
	/// - 当拥有此秘闻的人达到此人数限制，秘闻就被公示，被公示的秘闻可被所有人使用
	/// </summary>
	public readonly byte MaxPersonAmount;

	/// <summary>
	/// 持续时间
	/// - 达到持续时间后，秘闻过期；秘闻从公开秘闻、NPC的秘闻中移除，只有玩家的秘闻保留，但显示成灰色，无法使用
	/// - -1代表此秘闻不会过期
	/// </summary>
	public readonly short Duration;

	/// <summary>
	/// 初始传播群体
	/// - 产生秘闻时，自动依照设定好的概率分发给以下人群
	/// </summary>
	public readonly ESecretInformationInitialTarget InitialTarget;

	/// <summary>
	/// 传播群体参数索引
	/// - 决定秘闻产生时会分发给哪些人；数值代表前列的参数编号，填写即视为需要分发，并同时判定以此当事人为锚点的初始传播群体获得秘闻的概率；有两名同在一地的当事人时，此概率会判定两次
	/// </summary>
	public readonly int[] InitialTargetParameterIndices;

	/// <summary>
	/// 关系快照参数索引
	/// - 秘闻产生时，需要记录哪些当事人的关系快照
	/// </summary>
	public readonly int[] RelationshipSnapshotParameterIndices;

	/// <summary>
	/// 额外信息参数索引
	/// - 名誉类型、门派信息、是否出家
	/// </summary>
	public readonly int[] ExtraSnapshotParameterIndices;

	/// <summary>
	/// 无关者记录
	/// - 是否记录秘闻产生时与当事人没有特殊关系、但有好感记录的人群；此列目前没有意义，因为数据量过于庞大，所以所有的秘闻都不会记录
	/// </summary>
	public readonly bool IsGeneralRelationCharactersNeedSnapshot;

	/// <summary>
	/// 死活记录
	/// - 是否记录快照人物的死活，主要用于是否出轨的判定
	/// </summary>
	public readonly bool IsRelationCharactersAliveStateNeedSnapshot;

	/// <summary>
	/// 价值类型
	/// </summary>
	public readonly ESecretInformationValueType ValueType;

	/// <summary>
	/// 传播规则 Id
	/// </summary>
	public readonly short DisseminationId;

	/// <summary>
	/// 接受规则 Id
	/// </summary>
	public readonly short ReceptionId;

	/// <summary>
	/// 默认效果 Id
	/// - 未指定的需要策划手动判定
	/// </summary>
	public readonly short DefaultEffectId;

	/// <summary>
	/// 回应组Id
	/// - 使用秘闻时出现的回应组
	/// </summary>
	public readonly short StructGroupId;

	/// <summary>
	/// 门派惩罚规则 Id
	/// - 触发门派惩罚时调用的规则配置
	/// </summary>
	public readonly short SectPunishRuleId;

	/// <summary>
	/// 重要程度
	/// - 此数值越大，则秘闻会排在界面中越靠前的位置；如果两条秘闻权重相同，依然会按照此表中的模板id的顺序排列
	/// </summary>
	public readonly short SortValue;

	/// <summary>
	/// 基础概率（万分）
	/// - 秘闻在分发时需要检查此概率，如果不能通过，则不分发，防止太多垃圾秘闻被生成，挤占所有秘闻的展示空间
	/// </summary>
	public readonly short DiscoveryRate;

	/// <summary>
	/// 玩家参与（万分）
	/// - 如果玩家是秘闻的当事人，则应用此概率；否则最终的秘闻生成几率 = 秘闻的基础生成几率 * （100 + 百分比加成A + 百分比加成B）/ 100
	/// </summary>
	public readonly short DiscoveryRateTaiwu;

	/// <summary>
	/// 名誉系数（百分）
	/// - 所有当事人的名誉相加后的绝对值abs / 当事人数量 = 当事人名誉对秘闻生成几率的百分比加成A（最终取值范围0~100）
	/// </summary>
	public readonly short DiscoveryRateFactorA;

	/// <summary>
	/// 价值系数（百分）
	/// - 所有当事人、道具、资源、功法的级别相加 / 当事人、道具、资源、功法项数 = 涉及的道具或功法对秘闻生成几率的加成B（最终取值范围0~200）
	/// </summary>
	public readonly short DiscoveryRateFactorB;

	/// <summary>
	/// 关系系数（万分）
	/// - 当秘闻当事人在玩家的关系列表中，做为最小产生几率
	/// </summary>
	public readonly short DiscoveryRateFactorC;

	/// <summary>
	/// 公开说明
	/// </summary>
	public readonly string BroadcastDesc;

	/// <summary>
	/// 自动传播
	/// - 此秘闻是否可以通过Npc自动传播
	/// - 1:可以自动传播
	/// </summary>
	public readonly bool AutoDissemination;

	/// <summary>
	/// 一级筛选
	/// </summary>
	public readonly short GeneralFilterType;

	/// <summary>
	/// 详细筛选
	/// </summary>
	public readonly short DetailedFilterType;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">秘闻名称</param>
	/// <param name="desc">说明</param>
	/// <param name="parameters">参数 - 自动生成</param>
	/// <param name="notDisplayedParm">参数在前端不显示（痛失骨肉父亲不可知、生下孩子父亲不可知 这类需要保存父亲参数但是前端又不显示父亲时使用）</param>
	/// <param name="parametersUiName">参数Ui名 - 自动生成</param>
	/// <param name="blockSizeArgs">显示尺寸因子 - 注意此列为公式引用到sheet：BlockSizeArgs，因此不要直接在本sheet维护该列</param>
	/// <param name="involvedCharacterCount">涉及人物数</param>
	/// <param name="involvedItemCount">涉及物品数</param>
	/// <param name="involvedCombatSkillCount">涉及功法数</param>
	/// <param name="involvedLifeSkillCount">涉及技艺数</param>
	/// <param name="involvedLocationCount">涉及位置数</param>
	/// <param name="involvedResourceTypeCount">涉及资源类型数</param>
	/// <param name="involvedIntegerDataCount">涉及的数值数</param>
	/// <param name="autoBroadCast">自动公开</param>
	/// <param name="costAuthority">消耗威望 - 每次传播此秘闻需要消耗的威望</param>
	/// <param name="diffusionRange">固定传播距离 - 设定为负数以启用衰减原则</param>
	/// <param name="diffusionSpeed">传播速度 - 值越大，越能在一个月中传播给越多的人，如，传播速度5，表示一个月最多能传给5个人</param>
	/// <param name="fameThreshold">名誉要求 - 传播此秘闻的人物的名誉需&gt;=要求的名誉，未达到要求时，秘闻的传播需要的威望=消耗威望*(1+名誉相差的级别*2)</param>
	/// <param name="maxPersonAmount">人数上限 - 当拥有此秘闻的人达到此人数限制，秘闻就被公示，被公示的秘闻可被所有人使用</param>
	/// <param name="duration">持续时间 - 达到持续时间后，秘闻过期；秘闻从公开秘闻、NPC的秘闻中移除，只有玩家的秘闻保留，但显示成灰色，无法使用 -1代表此秘闻不会过期</param>
	/// <param name="initialTarget">初始传播群体 - 产生秘闻时，自动依照设定好的概率分发给以下人群</param>
	/// <param name="initialTargetParameterIndices">传播群体参数索引 - 决定秘闻产生时会分发给哪些人；数值代表前列的参数编号，填写即视为需要分发，并同时判定以此当事人为锚点的初始传播群体获得秘闻的概率；有两名同在一地的当事人时，此概率会判定两次</param>
	/// <param name="relationshipSnapshotParameterIndices">关系快照参数索引 - 秘闻产生时，需要记录哪些当事人的关系快照</param>
	/// <param name="extraSnapshotParameterIndices">额外信息参数索引 - 名誉类型、门派信息、是否出家</param>
	/// <param name="isGeneralRelationCharactersNeedSnapshot">无关者记录 - 是否记录秘闻产生时与当事人没有特殊关系、但有好感记录的人群；此列目前没有意义，因为数据量过于庞大，所以所有的秘闻都不会记录</param>
	/// <param name="isRelationCharactersAliveStateNeedSnapshot">死活记录 - 是否记录快照人物的死活，主要用于是否出轨的判定</param>
	/// <param name="valueType">价值类型</param>
	/// <param name="disseminationId">传播规则 Id</param>
	/// <param name="receptionId">接受规则 Id</param>
	/// <param name="defaultEffectId">默认效果 Id - 未指定的需要策划手动判定</param>
	/// <param name="structGroupId">回应组Id - 使用秘闻时出现的回应组</param>
	/// <param name="sectPunishRuleId">门派惩罚规则 Id - 触发门派惩罚时调用的规则配置</param>
	/// <param name="sortValue">重要程度 - 此数值越大，则秘闻会排在界面中越靠前的位置；如果两条秘闻权重相同，依然会按照此表中的模板id的顺序排列</param>
	/// <param name="discoveryRate">基础概率（万分） - 秘闻在分发时需要检查此概率，如果不能通过，则不分发，防止太多垃圾秘闻被生成，挤占所有秘闻的展示空间</param>
	/// <param name="discoveryRateTaiwu">玩家参与（万分） - 如果玩家是秘闻的当事人，则应用此概率；否则最终的秘闻生成几率 = 秘闻的基础生成几率 * （100 + 百分比加成A + 百分比加成B）/ 100</param>
	/// <param name="discoveryRateFactorA">名誉系数（百分） - 所有当事人的名誉相加后的绝对值abs / 当事人数量 = 当事人名誉对秘闻生成几率的百分比加成A（最终取值范围0~100）</param>
	/// <param name="discoveryRateFactorB">价值系数（百分） - 所有当事人、道具、资源、功法的级别相加 / 当事人、道具、资源、功法项数 = 涉及的道具或功法对秘闻生成几率的加成B（最终取值范围0~200）</param>
	/// <param name="discoveryRateFactorC">关系系数（万分） - 当秘闻当事人在玩家的关系列表中，做为最小产生几率</param>
	/// <param name="broadcastDesc">公开说明</param>
	/// <param name="autoDissemination">自动传播 - 此秘闻是否可以通过Npc自动传播 1:可以自动传播</param>
	/// <param name="generalFilterType">一级筛选</param>
	/// <param name="detailedFilterType">详细筛选</param>
	public SecretInformationItem(short templateId, string name, string desc, sbyte[] parameters, sbyte notDisplayedParm, string[] parametersUiName, sbyte[] blockSizeArgs, byte involvedCharacterCount, byte involvedItemCount, byte involvedCombatSkillCount, byte involvedLifeSkillCount, byte involvedLocationCount, byte involvedResourceTypeCount, byte involvedIntegerDataCount, bool autoBroadCast, short costAuthority, sbyte diffusionRange, byte diffusionSpeed, sbyte fameThreshold, byte maxPersonAmount, short duration, ESecretInformationInitialTarget initialTarget, int[] initialTargetParameterIndices, int[] relationshipSnapshotParameterIndices, int[] extraSnapshotParameterIndices, bool isGeneralRelationCharactersNeedSnapshot, bool isRelationCharactersAliveStateNeedSnapshot, ESecretInformationValueType valueType, short disseminationId, short receptionId, short defaultEffectId, short structGroupId, short sectPunishRuleId, short sortValue, short discoveryRate, short discoveryRateTaiwu, short discoveryRateFactorA, short discoveryRateFactorB, short discoveryRateFactorC, string broadcastDesc, bool autoDissemination, short generalFilterType, short detailedFilterType)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Parameters = parameters;
		NotDisplayedParm = notDisplayedParm;
		ParametersUiName = parametersUiName;
		BlockSizeArgs = blockSizeArgs;
		InvolvedCharacterCount = involvedCharacterCount;
		InvolvedItemCount = involvedItemCount;
		InvolvedCombatSkillCount = involvedCombatSkillCount;
		InvolvedLifeSkillCount = involvedLifeSkillCount;
		InvolvedLocationCount = involvedLocationCount;
		InvolvedResourceTypeCount = involvedResourceTypeCount;
		InvolvedIntegerDataCount = involvedIntegerDataCount;
		AutoBroadCast = autoBroadCast;
		CostAuthority = costAuthority;
		DiffusionRange = diffusionRange;
		DiffusionSpeed = diffusionSpeed;
		FameThreshold = fameThreshold;
		MaxPersonAmount = maxPersonAmount;
		Duration = duration;
		InitialTarget = initialTarget;
		InitialTargetParameterIndices = initialTargetParameterIndices;
		RelationshipSnapshotParameterIndices = relationshipSnapshotParameterIndices;
		ExtraSnapshotParameterIndices = extraSnapshotParameterIndices;
		IsGeneralRelationCharactersNeedSnapshot = isGeneralRelationCharactersNeedSnapshot;
		IsRelationCharactersAliveStateNeedSnapshot = isRelationCharactersAliveStateNeedSnapshot;
		ValueType = valueType;
		DisseminationId = disseminationId;
		ReceptionId = receptionId;
		DefaultEffectId = defaultEffectId;
		StructGroupId = structGroupId;
		SectPunishRuleId = sectPunishRuleId;
		SortValue = sortValue;
		DiscoveryRate = discoveryRate;
		DiscoveryRateTaiwu = discoveryRateTaiwu;
		DiscoveryRateFactorA = discoveryRateFactorA;
		DiscoveryRateFactorB = discoveryRateFactorB;
		DiscoveryRateFactorC = discoveryRateFactorC;
		BroadcastDesc = broadcastDesc;
		AutoDissemination = autoDissemination;
		GeneralFilterType = generalFilterType;
		DetailedFilterType = detailedFilterType;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SecretInformationItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Parameters = null;
		NotDisplayedParm = -1;
		ParametersUiName = null;
		BlockSizeArgs = null;
		InvolvedCharacterCount = 0;
		InvolvedItemCount = 0;
		InvolvedCombatSkillCount = 0;
		InvolvedLifeSkillCount = 0;
		InvolvedLocationCount = 0;
		InvolvedResourceTypeCount = 0;
		InvolvedIntegerDataCount = 0;
		AutoBroadCast = false;
		CostAuthority = 0;
		DiffusionRange = -1;
		DiffusionSpeed = 5;
		FameThreshold = -3;
		MaxPersonAmount = 10;
		Duration = 6;
		InitialTarget = ESecretInformationInitialTarget.None;
		InitialTargetParameterIndices = new int[1];
		RelationshipSnapshotParameterIndices = new int[0];
		ExtraSnapshotParameterIndices = new int[0];
		IsGeneralRelationCharactersNeedSnapshot = false;
		IsRelationCharactersAliveStateNeedSnapshot = false;
		ValueType = ESecretInformationValueType.Normal;
		DisseminationId = 0;
		ReceptionId = 0;
		DefaultEffectId = 0;
		StructGroupId = 0;
		SectPunishRuleId = 0;
		SortValue = 1;
		DiscoveryRate = 10000;
		DiscoveryRateTaiwu = 10000;
		DiscoveryRateFactorA = 1;
		DiscoveryRateFactorB = 25;
		DiscoveryRateFactorC = -1;
		BroadcastDesc = null;
		AutoDissemination = true;
		GeneralFilterType = 9;
		DetailedFilterType = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SecretInformationItem(short templateId, SecretInformationItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Parameters = other.Parameters;
		NotDisplayedParm = other.NotDisplayedParm;
		ParametersUiName = other.ParametersUiName;
		BlockSizeArgs = other.BlockSizeArgs;
		InvolvedCharacterCount = other.InvolvedCharacterCount;
		InvolvedItemCount = other.InvolvedItemCount;
		InvolvedCombatSkillCount = other.InvolvedCombatSkillCount;
		InvolvedLifeSkillCount = other.InvolvedLifeSkillCount;
		InvolvedLocationCount = other.InvolvedLocationCount;
		InvolvedResourceTypeCount = other.InvolvedResourceTypeCount;
		InvolvedIntegerDataCount = other.InvolvedIntegerDataCount;
		AutoBroadCast = other.AutoBroadCast;
		CostAuthority = other.CostAuthority;
		DiffusionRange = other.DiffusionRange;
		DiffusionSpeed = other.DiffusionSpeed;
		FameThreshold = other.FameThreshold;
		MaxPersonAmount = other.MaxPersonAmount;
		Duration = other.Duration;
		InitialTarget = other.InitialTarget;
		InitialTargetParameterIndices = other.InitialTargetParameterIndices;
		RelationshipSnapshotParameterIndices = other.RelationshipSnapshotParameterIndices;
		ExtraSnapshotParameterIndices = other.ExtraSnapshotParameterIndices;
		IsGeneralRelationCharactersNeedSnapshot = other.IsGeneralRelationCharactersNeedSnapshot;
		IsRelationCharactersAliveStateNeedSnapshot = other.IsRelationCharactersAliveStateNeedSnapshot;
		ValueType = other.ValueType;
		DisseminationId = other.DisseminationId;
		ReceptionId = other.ReceptionId;
		DefaultEffectId = other.DefaultEffectId;
		StructGroupId = other.StructGroupId;
		SectPunishRuleId = other.SectPunishRuleId;
		SortValue = other.SortValue;
		DiscoveryRate = other.DiscoveryRate;
		DiscoveryRateTaiwu = other.DiscoveryRateTaiwu;
		DiscoveryRateFactorA = other.DiscoveryRateFactorA;
		DiscoveryRateFactorB = other.DiscoveryRateFactorB;
		DiscoveryRateFactorC = other.DiscoveryRateFactorC;
		BroadcastDesc = other.BroadcastDesc;
		AutoDissemination = other.AutoDissemination;
		GeneralFilterType = other.GeneralFilterType;
		DetailedFilterType = other.DetailedFilterType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SecretInformationItem Duplicate(int templateId)
	{
		return new SecretInformationItem((short)templateId, this);
	}
}
