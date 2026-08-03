using System;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationDisseminationItem : ConfigItem<SecretInformationDisseminationItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 不相识的人
	/// - 传播几率(后同)
	/// </summary>
	public readonly short SfRateStr;

	/// <summary>
	/// 已相识的人
	/// - 传播距离0表示仅在人物所在格传播；没有固定传播距离的秘闻的传播距离均=从本格开始，每距离传播者多一距离的地格，传播几率-10，直到传播几率减为0，即为最后的传播距离
	/// </summary>
	public readonly short SfRateNStr;

	/// <summary>
	/// 行为方亲友
	/// </summary>
	public readonly short SfRateActFri;

	/// <summary>
	/// 行为方敌人
	/// </summary>
	public readonly short SfRateActEnm;

	/// <summary>
	/// 接受方亲友
	/// </summary>
	public readonly short SfRateUnaFri;

	/// <summary>
	/// 接受方敌人
	/// </summary>
	public readonly short SfRateUnaEnm;

	/// <summary>
	/// 赋性对传播几率的影响(冷静、热情、聪颖、勇壮、坚毅)
	/// - 百分比乘七元
	/// </summary>
	public readonly short[] SfPersonalityDiff;

	/// <summary>
	/// 立场对传播几率的影响(从刚正至唯我)
	/// </summary>
	public readonly short[] SfBehaviorTypeDiff;

	/// <summary>
	/// 不相识的人
	/// - short
	/// </summary>
	public readonly short TfRateStr;

	/// <summary>
	/// 已相识的人
	/// - 传播距离0表示仅在人物所在格传播；没有固定传播距离的秘闻的传播距离均=从本格开始，每距离传播者多一距离的地格，传播几率-10，直到传播几率减为0，即为最后的传播距离
	/// </summary>
	public readonly short TfRateNStr;

	/// <summary>
	/// 人物的亲友
	/// </summary>
	public readonly short TfRateItsFri;

	/// <summary>
	/// 人物的敌人
	/// </summary>
	public readonly short TfRateItsEnm;

	/// <summary>
	/// 行为方亲友
	/// </summary>
	public readonly short TfRateActFri;

	/// <summary>
	/// 行为方敌人
	/// </summary>
	public readonly short TfRateActEnm;

	/// <summary>
	/// 接受方亲友
	/// </summary>
	public readonly short TfRateUnaFri;

	/// <summary>
	/// 接受方敌人
	/// </summary>
	public readonly short TfRateUnaEnm;

	/// <summary>
	/// 与行为方为亲友
	/// </summary>
	public readonly short TfRateDiffWhenActFri;

	/// <summary>
	/// 与行为方为敌人
	/// </summary>
	public readonly short TfRateDiffWhenActEnm;

	/// <summary>
	/// 与接受方为亲友
	/// </summary>
	public readonly short TfRateDiffWhenUnaFri;

	/// <summary>
	/// 与接受方为敌人
	/// </summary>
	public readonly short TfRateDiffWhenUnaEnm;

	/// <summary>
	/// 赋性对传播几率的影响(冷静、热情、聪颖、勇壮、坚毅)
	/// - 百分比乘七元
	/// </summary>
	public readonly short[] TfPersonalityDiff;

	/// <summary>
	/// 立场对传播几率的影响(从刚正至唯我)
	/// </summary>
	public readonly short[] TfBehaviorTypeDiff;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="sfRateStr">不相识的人 - 传播几率(后同)</param>
	/// <param name="sfRateNStr">已相识的人 - 传播距离0表示仅在人物所在格传播；没有固定传播距离的秘闻的传播距离均=从本格开始，每距离传播者多一距离的地格，传播几率-10，直到传播几率减为0，即为最后的传播距离</param>
	/// <param name="sfRateActFri">行为方亲友</param>
	/// <param name="sfRateActEnm">行为方敌人</param>
	/// <param name="sfRateUnaFri">接受方亲友</param>
	/// <param name="sfRateUnaEnm">接受方敌人</param>
	/// <param name="sfPersonalityDiff">赋性对传播几率的影响(冷静、热情、聪颖、勇壮、坚毅) - 百分比乘七元</param>
	/// <param name="sfBehaviorTypeDiff">立场对传播几率的影响(从刚正至唯我)</param>
	/// <param name="tfRateStr">不相识的人 - short</param>
	/// <param name="tfRateNStr">已相识的人 - 传播距离0表示仅在人物所在格传播；没有固定传播距离的秘闻的传播距离均=从本格开始，每距离传播者多一距离的地格，传播几率-10，直到传播几率减为0，即为最后的传播距离</param>
	/// <param name="tfRateItsFri">人物的亲友</param>
	/// <param name="tfRateItsEnm">人物的敌人</param>
	/// <param name="tfRateActFri">行为方亲友</param>
	/// <param name="tfRateActEnm">行为方敌人</param>
	/// <param name="tfRateUnaFri">接受方亲友</param>
	/// <param name="tfRateUnaEnm">接受方敌人</param>
	/// <param name="tfRateDiffWhenActFri">与行为方为亲友</param>
	/// <param name="tfRateDiffWhenActEnm">与行为方为敌人</param>
	/// <param name="tfRateDiffWhenUnaFri">与接受方为亲友</param>
	/// <param name="tfRateDiffWhenUnaEnm">与接受方为敌人</param>
	/// <param name="tfPersonalityDiff">赋性对传播几率的影响(冷静、热情、聪颖、勇壮、坚毅) - 百分比乘七元</param>
	/// <param name="tfBehaviorTypeDiff">立场对传播几率的影响(从刚正至唯我)</param>
	public SecretInformationDisseminationItem(short templateId, short sfRateStr, short sfRateNStr, short sfRateActFri, short sfRateActEnm, short sfRateUnaFri, short sfRateUnaEnm, short[] sfPersonalityDiff, short[] sfBehaviorTypeDiff, short tfRateStr, short tfRateNStr, short tfRateItsFri, short tfRateItsEnm, short tfRateActFri, short tfRateActEnm, short tfRateUnaFri, short tfRateUnaEnm, short tfRateDiffWhenActFri, short tfRateDiffWhenActEnm, short tfRateDiffWhenUnaFri, short tfRateDiffWhenUnaEnm, short[] tfPersonalityDiff, short[] tfBehaviorTypeDiff)
	{
		TemplateId = templateId;
		SfRateStr = sfRateStr;
		SfRateNStr = sfRateNStr;
		SfRateActFri = sfRateActFri;
		SfRateActEnm = sfRateActEnm;
		SfRateUnaFri = sfRateUnaFri;
		SfRateUnaEnm = sfRateUnaEnm;
		SfPersonalityDiff = sfPersonalityDiff;
		SfBehaviorTypeDiff = sfBehaviorTypeDiff;
		TfRateStr = tfRateStr;
		TfRateNStr = tfRateNStr;
		TfRateItsFri = tfRateItsFri;
		TfRateItsEnm = tfRateItsEnm;
		TfRateActFri = tfRateActFri;
		TfRateActEnm = tfRateActEnm;
		TfRateUnaFri = tfRateUnaFri;
		TfRateUnaEnm = tfRateUnaEnm;
		TfRateDiffWhenActFri = tfRateDiffWhenActFri;
		TfRateDiffWhenActEnm = tfRateDiffWhenActEnm;
		TfRateDiffWhenUnaFri = tfRateDiffWhenUnaFri;
		TfRateDiffWhenUnaEnm = tfRateDiffWhenUnaEnm;
		TfPersonalityDiff = tfPersonalityDiff;
		TfBehaviorTypeDiff = tfBehaviorTypeDiff;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SecretInformationDisseminationItem()
	{
		TemplateId = 0;
		SfRateStr = -10000;
		SfRateNStr = -10000;
		SfRateActFri = -10000;
		SfRateActEnm = -10000;
		SfRateUnaFri = -10000;
		SfRateUnaEnm = -10000;
		SfPersonalityDiff = new short[5];
		SfBehaviorTypeDiff = new short[5];
		TfRateStr = -10000;
		TfRateNStr = -10000;
		TfRateItsFri = -10000;
		TfRateItsEnm = -10000;
		TfRateActFri = -10000;
		TfRateActEnm = -10000;
		TfRateUnaFri = -10000;
		TfRateUnaEnm = -10000;
		TfRateDiffWhenActFri = 0;
		TfRateDiffWhenActEnm = 0;
		TfRateDiffWhenUnaFri = 0;
		TfRateDiffWhenUnaEnm = 0;
		TfPersonalityDiff = new short[5];
		TfBehaviorTypeDiff = new short[5];
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public SecretInformationDisseminationItem(short templateId, SecretInformationDisseminationItem other)
	{
		TemplateId = templateId;
		SfRateStr = other.SfRateStr;
		SfRateNStr = other.SfRateNStr;
		SfRateActFri = other.SfRateActFri;
		SfRateActEnm = other.SfRateActEnm;
		SfRateUnaFri = other.SfRateUnaFri;
		SfRateUnaEnm = other.SfRateUnaEnm;
		SfPersonalityDiff = other.SfPersonalityDiff;
		SfBehaviorTypeDiff = other.SfBehaviorTypeDiff;
		TfRateStr = other.TfRateStr;
		TfRateNStr = other.TfRateNStr;
		TfRateItsFri = other.TfRateItsFri;
		TfRateItsEnm = other.TfRateItsEnm;
		TfRateActFri = other.TfRateActFri;
		TfRateActEnm = other.TfRateActEnm;
		TfRateUnaFri = other.TfRateUnaFri;
		TfRateUnaEnm = other.TfRateUnaEnm;
		TfRateDiffWhenActFri = other.TfRateDiffWhenActFri;
		TfRateDiffWhenActEnm = other.TfRateDiffWhenActEnm;
		TfRateDiffWhenUnaFri = other.TfRateDiffWhenUnaFri;
		TfRateDiffWhenUnaEnm = other.TfRateDiffWhenUnaEnm;
		TfPersonalityDiff = other.TfPersonalityDiff;
		TfBehaviorTypeDiff = other.TfBehaviorTypeDiff;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SecretInformationDisseminationItem Duplicate(int templateId)
	{
		return new SecretInformationDisseminationItem((short)templateId, this);
	}
}
