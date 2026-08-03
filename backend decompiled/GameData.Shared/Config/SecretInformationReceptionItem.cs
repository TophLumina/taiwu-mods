using System;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationReceptionItem : ConfigItem<SecretInformationReceptionItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 不相识的人
	/// - 当传播者和被传播者为对应关系时，增加传播被接受的概率
	/// </summary>
	public readonly short NoRateRt;

	/// <summary>
	/// 已相识的人
	/// </summary>
	public readonly short RateRt;

	/// <summary>
	/// 人物的亲友
	/// - 双方为亲友关系，包括父母、子女、手足、结义、夫妻、单/双向爱慕、朋友、师承关系
	/// </summary>
	public readonly short RateItsFriRt;

	/// <summary>
	/// 人物的敌人
	/// - 包括单向仇敌和双向仇敌
	/// </summary>
	public readonly short RateItsEnmRt;

	/// <summary>
	/// 七元赋性系数
	/// - 人物七元赋性依照对应赋性数值*配置系数的加成，
	/// - 配置顺序为{冷静系数,聪颖系数,热情系数,勇壮系数,坚毅系数}
	/// </summary>
	public readonly short[] PersonalityTypeRt;

	/// <summary>
	/// 太吾
	/// - 被传播者不同立场时，对不同来源者的接受程度(从刚正至唯我)
	/// - 获得对应概率后判定是否为副职，*对应系数
	/// </summary>
	public readonly short[] SourceTaiwu;

	/// <summary>
	/// 门派-8
	/// - 门派上3阶为来源者
	/// </summary>
	public readonly short[] SourceOrg8;

	/// <summary>
	/// 门派-7
	/// </summary>
	public readonly short[] SourceOrg7;

	/// <summary>
	/// 门派-6
	/// </summary>
	public readonly short[] SourceOrg6;

	/// <summary>
	/// 城镇-8
	/// - 城镇上3阶为来源者
	/// </summary>
	public readonly short[] SourceCity8;

	/// <summary>
	/// 城镇-7
	/// </summary>
	public readonly short[] SourceCity7;

	/// <summary>
	/// 城镇-6
	/// </summary>
	public readonly short[] SourceCity6;

	/// <summary>
	/// 门派-5
	/// - 门派中3阶为来源者
	/// </summary>
	public readonly short[] SourceOrg5;

	/// <summary>
	/// 门派-4
	/// </summary>
	public readonly short[] SourceOrg4;

	/// <summary>
	/// 门派-3
	/// </summary>
	public readonly short[] SourceOrg3;

	/// <summary>
	/// 城镇-5
	/// - 城镇中3阶为来源者
	/// </summary>
	public readonly short[] SourceCity5;

	/// <summary>
	/// 城镇-4
	/// </summary>
	public readonly short[] SourceCity4;

	/// <summary>
	/// 城镇-3
	/// </summary>
	public readonly short[] SourceCity3;

	/// <summary>
	/// 门派-2
	/// - 门派下3阶为来源者
	/// </summary>
	public readonly short[] SourceOrgLow2;

	/// <summary>
	/// 门派-1
	/// </summary>
	public readonly short[] SourceOrgLow1;

	/// <summary>
	/// 门派-0
	/// </summary>
	public readonly short[] SourceOrgLow0;

	/// <summary>
	/// 城镇-2
	/// - 城镇下3阶为来源者
	/// </summary>
	public readonly short[] SourceCityLow2;

	/// <summary>
	/// 城镇-1
	/// </summary>
	public readonly short[] SourceCityLow1;

	/// <summary>
	/// 城镇-0
	/// </summary>
	public readonly short[] SourceCityLow0;

	/// <summary>
	/// 副职
	/// - 判定来源者是否为正/副，若为副*下列系数
	/// </summary>
	public readonly byte SourcePrincipal;

	/// <summary>
	/// 秘闻行为者
	/// - 此Npc为秘闻行为者。当人物满足对应关系时，增加对应概率数值
	/// </summary>
	public readonly short DisRateAct;

	/// <summary>
	/// 秘闻接受者
	/// - 此Npc为秘闻接受者
	/// </summary>
	public readonly short DisRateUna;

	/// <summary>
	/// 秘闻无关者
	/// - 此Npc为和秘闻行为者、接收者无任何关系
	/// </summary>
	public readonly short DisNoRate;

	/// <summary>
	/// 行为方亲友
	/// - 此Npc为行为者的亲友
	/// </summary>
	public readonly short DisRateActFri;

	/// <summary>
	/// 行为方敌人
	/// - 此Npc为行为方敌人
	/// </summary>
	public readonly short DisRateActEn;

	/// <summary>
	/// 行为方爱慕
	/// - 此Npc为行为方爱慕
	/// </summary>
	public readonly short DisRateActAd;

	/// <summary>
	/// 行为方相好
	/// - 此Npc为行为方相好
	/// </summary>
	public readonly short DisRateActLo;

	/// <summary>
	/// 行为方掌门
	/// - 此Npc为行为方掌门
	/// </summary>
	public readonly short DisRateActLe;

	/// <summary>
	/// 接受者亲友
	/// - 此Npc为接受者的亲友
	/// </summary>
	public readonly short DisRateUnaFri;

	/// <summary>
	/// 接受者敌人
	/// - 此Npc为接受者敌人
	/// </summary>
	public readonly short DisRateUnaEn;

	/// <summary>
	/// 接受者爱慕
	/// - 此Npc为接受者爱慕
	/// </summary>
	public readonly short DisRateUnaAd;

	/// <summary>
	/// 接受者相好
	/// - 此Npc为接受者相好
	/// </summary>
	public readonly short DisRateUnaLo;

	/// <summary>
	/// 接受者掌门
	/// - 此Npc为接受者掌门
	/// </summary>
	public readonly short DisRateUnaLe;

	/// <summary>
	/// 人物赋性(涉事)
	/// </summary>
	public readonly short[] PersonalityTypeDisForRelationForInvolved;

	/// <summary>
	/// 人物立场(涉事)
	/// - 该列由公式生成，禁止手动填写
	/// </summary>
	public readonly short[] BehaviorTypeDisForRelationForInvolved;

	/// <summary>
	/// 人物赋性(不涉事)
	/// </summary>
	public readonly short[] PersonalityTypeDisForRelationForUninvolved;

	/// <summary>
	/// 人物立场(不涉事)
	/// - 该列由公式生成，禁止手动填写
	/// </summary>
	public readonly short[] BehaviorTypeDisForRelationForUninvolved;

	/// <summary>
	/// 赋性对传播几率的影响
	/// - 配置顺序为{冷静系数,聪颖系数,热情系数,勇壮系数,坚毅系数，福缘系数,合道系数}
	/// </summary>
	public readonly short[] PersonalityTypeDisForRelationForEffective;

	/// <summary>
	/// 立场对传播几率的影响
	/// </summary>
	public readonly short[] BehaviorTypeDisForRelationForEffective;

	/// <summary>
	/// 赋性对传播几率的影响
	/// - 配置顺序为{冷静系数,聪颖系数,热情系数,勇壮系数,坚毅系数，福缘系数,合道系数}
	/// </summary>
	public readonly short[] PersonalityTypeDisForNonRelation;

	/// <summary>
	/// 立场对传播几率的影响
	/// </summary>
	public readonly short[] BehaviorTypeDisForNonRelation;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="noRateRt">不相识的人 - 当传播者和被传播者为对应关系时，增加传播被接受的概率</param>
	/// <param name="rateRt">已相识的人</param>
	/// <param name="rateItsFriRt">人物的亲友 - 双方为亲友关系，包括父母、子女、手足、结义、夫妻、单/双向爱慕、朋友、师承关系</param>
	/// <param name="rateItsEnmRt">人物的敌人 - 包括单向仇敌和双向仇敌</param>
	/// <param name="personalityTypeRt">七元赋性系数 - 人物七元赋性依照对应赋性数值*配置系数的加成， 配置顺序为{冷静系数,聪颖系数,热情系数,勇壮系数,坚毅系数}</param>
	/// <param name="sourceTaiwu">太吾 - 被传播者不同立场时，对不同来源者的接受程度(从刚正至唯我) 获得对应概率后判定是否为副职，*对应系数</param>
	/// <param name="sourceOrg8">门派-8 - 门派上3阶为来源者</param>
	/// <param name="sourceOrg7">门派-7</param>
	/// <param name="sourceOrg6">门派-6</param>
	/// <param name="sourceCity8">城镇-8 - 城镇上3阶为来源者</param>
	/// <param name="sourceCity7">城镇-7</param>
	/// <param name="sourceCity6">城镇-6</param>
	/// <param name="sourceOrg5">门派-5 - 门派中3阶为来源者</param>
	/// <param name="sourceOrg4">门派-4</param>
	/// <param name="sourceOrg3">门派-3</param>
	/// <param name="sourceCity5">城镇-5 - 城镇中3阶为来源者</param>
	/// <param name="sourceCity4">城镇-4</param>
	/// <param name="sourceCity3">城镇-3</param>
	/// <param name="sourceOrgLow2">门派-2 - 门派下3阶为来源者</param>
	/// <param name="sourceOrgLow1">门派-1</param>
	/// <param name="sourceOrgLow0">门派-0</param>
	/// <param name="sourceCityLow2">城镇-2 - 城镇下3阶为来源者</param>
	/// <param name="sourceCityLow1">城镇-1</param>
	/// <param name="sourceCityLow0">城镇-0</param>
	/// <param name="sourcePrincipal">副职 - 判定来源者是否为正/副，若为副*下列系数</param>
	/// <param name="disRateAct">秘闻行为者 - 此Npc为秘闻行为者。当人物满足对应关系时，增加对应概率数值</param>
	/// <param name="disRateUna">秘闻接受者 - 此Npc为秘闻接受者</param>
	/// <param name="disNoRate">秘闻无关者 - 此Npc为和秘闻行为者、接收者无任何关系</param>
	/// <param name="disRateActFri">行为方亲友 - 此Npc为行为者的亲友</param>
	/// <param name="disRateActEn">行为方敌人 - 此Npc为行为方敌人</param>
	/// <param name="disRateActAd">行为方爱慕 - 此Npc为行为方爱慕</param>
	/// <param name="disRateActLo">行为方相好 - 此Npc为行为方相好</param>
	/// <param name="disRateActLe">行为方掌门 - 此Npc为行为方掌门</param>
	/// <param name="disRateUnaFri">接受者亲友 - 此Npc为接受者的亲友</param>
	/// <param name="disRateUnaEn">接受者敌人 - 此Npc为接受者敌人</param>
	/// <param name="disRateUnaAd">接受者爱慕 - 此Npc为接受者爱慕</param>
	/// <param name="disRateUnaLo">接受者相好 - 此Npc为接受者相好</param>
	/// <param name="disRateUnaLe">接受者掌门 - 此Npc为接受者掌门</param>
	/// <param name="personalityTypeDisForRelationForInvolved">人物赋性(涉事)</param>
	/// <param name="behaviorTypeDisForRelationForInvolved">人物立场(涉事) - 该列由公式生成，禁止手动填写</param>
	/// <param name="personalityTypeDisForRelationForUninvolved">人物赋性(不涉事)</param>
	/// <param name="behaviorTypeDisForRelationForUninvolved">人物立场(不涉事) - 该列由公式生成，禁止手动填写</param>
	/// <param name="personalityTypeDisForRelationForEffective">赋性对传播几率的影响 - 配置顺序为{冷静系数,聪颖系数,热情系数,勇壮系数,坚毅系数，福缘系数,合道系数}</param>
	/// <param name="behaviorTypeDisForRelationForEffective">立场对传播几率的影响</param>
	/// <param name="personalityTypeDisForNonRelation">赋性对传播几率的影响 - 配置顺序为{冷静系数,聪颖系数,热情系数,勇壮系数,坚毅系数，福缘系数,合道系数}</param>
	/// <param name="behaviorTypeDisForNonRelation">立场对传播几率的影响</param>
	public SecretInformationReceptionItem(short templateId, short noRateRt, short rateRt, short rateItsFriRt, short rateItsEnmRt, short[] personalityTypeRt, short[] sourceTaiwu, short[] sourceOrg8, short[] sourceOrg7, short[] sourceOrg6, short[] sourceCity8, short[] sourceCity7, short[] sourceCity6, short[] sourceOrg5, short[] sourceOrg4, short[] sourceOrg3, short[] sourceCity5, short[] sourceCity4, short[] sourceCity3, short[] sourceOrgLow2, short[] sourceOrgLow1, short[] sourceOrgLow0, short[] sourceCityLow2, short[] sourceCityLow1, short[] sourceCityLow0, byte sourcePrincipal, short disRateAct, short disRateUna, short disNoRate, short disRateActFri, short disRateActEn, short disRateActAd, short disRateActLo, short disRateActLe, short disRateUnaFri, short disRateUnaEn, short disRateUnaAd, short disRateUnaLo, short disRateUnaLe, short[] personalityTypeDisForRelationForInvolved, short[] behaviorTypeDisForRelationForInvolved, short[] personalityTypeDisForRelationForUninvolved, short[] behaviorTypeDisForRelationForUninvolved, short[] personalityTypeDisForRelationForEffective, short[] behaviorTypeDisForRelationForEffective, short[] personalityTypeDisForNonRelation, short[] behaviorTypeDisForNonRelation)
	{
		TemplateId = templateId;
		NoRateRt = noRateRt;
		RateRt = rateRt;
		RateItsFriRt = rateItsFriRt;
		RateItsEnmRt = rateItsEnmRt;
		PersonalityTypeRt = personalityTypeRt;
		SourceTaiwu = sourceTaiwu;
		SourceOrg8 = sourceOrg8;
		SourceOrg7 = sourceOrg7;
		SourceOrg6 = sourceOrg6;
		SourceCity8 = sourceCity8;
		SourceCity7 = sourceCity7;
		SourceCity6 = sourceCity6;
		SourceOrg5 = sourceOrg5;
		SourceOrg4 = sourceOrg4;
		SourceOrg3 = sourceOrg3;
		SourceCity5 = sourceCity5;
		SourceCity4 = sourceCity4;
		SourceCity3 = sourceCity3;
		SourceOrgLow2 = sourceOrgLow2;
		SourceOrgLow1 = sourceOrgLow1;
		SourceOrgLow0 = sourceOrgLow0;
		SourceCityLow2 = sourceCityLow2;
		SourceCityLow1 = sourceCityLow1;
		SourceCityLow0 = sourceCityLow0;
		SourcePrincipal = sourcePrincipal;
		DisRateAct = disRateAct;
		DisRateUna = disRateUna;
		DisNoRate = disNoRate;
		DisRateActFri = disRateActFri;
		DisRateActEn = disRateActEn;
		DisRateActAd = disRateActAd;
		DisRateActLo = disRateActLo;
		DisRateActLe = disRateActLe;
		DisRateUnaFri = disRateUnaFri;
		DisRateUnaEn = disRateUnaEn;
		DisRateUnaAd = disRateUnaAd;
		DisRateUnaLo = disRateUnaLo;
		DisRateUnaLe = disRateUnaLe;
		PersonalityTypeDisForRelationForInvolved = personalityTypeDisForRelationForInvolved;
		BehaviorTypeDisForRelationForInvolved = behaviorTypeDisForRelationForInvolved;
		PersonalityTypeDisForRelationForUninvolved = personalityTypeDisForRelationForUninvolved;
		BehaviorTypeDisForRelationForUninvolved = behaviorTypeDisForRelationForUninvolved;
		PersonalityTypeDisForRelationForEffective = personalityTypeDisForRelationForEffective;
		BehaviorTypeDisForRelationForEffective = behaviorTypeDisForRelationForEffective;
		PersonalityTypeDisForNonRelation = personalityTypeDisForNonRelation;
		BehaviorTypeDisForNonRelation = behaviorTypeDisForNonRelation;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SecretInformationReceptionItem()
	{
		TemplateId = 0;
		NoRateRt = 0;
		RateRt = 0;
		RateItsFriRt = 0;
		RateItsEnmRt = 0;
		PersonalityTypeRt = null;
		SourceTaiwu = new short[5];
		SourceOrg8 = new short[5];
		SourceOrg7 = new short[5];
		SourceOrg6 = new short[5];
		SourceCity8 = new short[5];
		SourceCity7 = new short[5];
		SourceCity6 = new short[5];
		SourceOrg5 = new short[5];
		SourceOrg4 = new short[5];
		SourceOrg3 = new short[5];
		SourceCity5 = new short[5];
		SourceCity4 = new short[5];
		SourceCity3 = new short[5];
		SourceOrgLow2 = new short[5];
		SourceOrgLow1 = new short[5];
		SourceOrgLow0 = new short[5];
		SourceCityLow2 = new short[5];
		SourceCityLow1 = new short[5];
		SourceCityLow0 = new short[5];
		SourcePrincipal = 100;
		DisRateAct = 0;
		DisRateUna = 0;
		DisNoRate = 0;
		DisRateActFri = 0;
		DisRateActEn = 0;
		DisRateActAd = 0;
		DisRateActLo = 0;
		DisRateActLe = 0;
		DisRateUnaFri = 0;
		DisRateUnaEn = 0;
		DisRateUnaAd = 0;
		DisRateUnaLo = 0;
		DisRateUnaLe = 0;
		PersonalityTypeDisForRelationForInvolved = null;
		BehaviorTypeDisForRelationForInvolved = new short[5];
		PersonalityTypeDisForRelationForUninvolved = null;
		BehaviorTypeDisForRelationForUninvolved = new short[5];
		PersonalityTypeDisForRelationForEffective = new short[7];
		BehaviorTypeDisForRelationForEffective = new short[5];
		PersonalityTypeDisForNonRelation = new short[7];
		BehaviorTypeDisForNonRelation = new short[5];
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SecretInformationReceptionItem(short templateId, SecretInformationReceptionItem other)
	{
		TemplateId = templateId;
		NoRateRt = other.NoRateRt;
		RateRt = other.RateRt;
		RateItsFriRt = other.RateItsFriRt;
		RateItsEnmRt = other.RateItsEnmRt;
		PersonalityTypeRt = other.PersonalityTypeRt;
		SourceTaiwu = other.SourceTaiwu;
		SourceOrg8 = other.SourceOrg8;
		SourceOrg7 = other.SourceOrg7;
		SourceOrg6 = other.SourceOrg6;
		SourceCity8 = other.SourceCity8;
		SourceCity7 = other.SourceCity7;
		SourceCity6 = other.SourceCity6;
		SourceOrg5 = other.SourceOrg5;
		SourceOrg4 = other.SourceOrg4;
		SourceOrg3 = other.SourceOrg3;
		SourceCity5 = other.SourceCity5;
		SourceCity4 = other.SourceCity4;
		SourceCity3 = other.SourceCity3;
		SourceOrgLow2 = other.SourceOrgLow2;
		SourceOrgLow1 = other.SourceOrgLow1;
		SourceOrgLow0 = other.SourceOrgLow0;
		SourceCityLow2 = other.SourceCityLow2;
		SourceCityLow1 = other.SourceCityLow1;
		SourceCityLow0 = other.SourceCityLow0;
		SourcePrincipal = other.SourcePrincipal;
		DisRateAct = other.DisRateAct;
		DisRateUna = other.DisRateUna;
		DisNoRate = other.DisNoRate;
		DisRateActFri = other.DisRateActFri;
		DisRateActEn = other.DisRateActEn;
		DisRateActAd = other.DisRateActAd;
		DisRateActLo = other.DisRateActLo;
		DisRateActLe = other.DisRateActLe;
		DisRateUnaFri = other.DisRateUnaFri;
		DisRateUnaEn = other.DisRateUnaEn;
		DisRateUnaAd = other.DisRateUnaAd;
		DisRateUnaLo = other.DisRateUnaLo;
		DisRateUnaLe = other.DisRateUnaLe;
		PersonalityTypeDisForRelationForInvolved = other.PersonalityTypeDisForRelationForInvolved;
		BehaviorTypeDisForRelationForInvolved = other.BehaviorTypeDisForRelationForInvolved;
		PersonalityTypeDisForRelationForUninvolved = other.PersonalityTypeDisForRelationForUninvolved;
		BehaviorTypeDisForRelationForUninvolved = other.BehaviorTypeDisForRelationForUninvolved;
		PersonalityTypeDisForRelationForEffective = other.PersonalityTypeDisForRelationForEffective;
		BehaviorTypeDisForRelationForEffective = other.BehaviorTypeDisForRelationForEffective;
		PersonalityTypeDisForNonRelation = other.PersonalityTypeDisForNonRelation;
		BehaviorTypeDisForNonRelation = other.BehaviorTypeDisForNonRelation;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SecretInformationReceptionItem Duplicate(int templateId)
	{
		return new SecretInformationReceptionItem((short)templateId, this);
	}
}
