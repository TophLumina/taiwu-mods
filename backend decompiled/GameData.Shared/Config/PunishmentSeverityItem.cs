using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class PunishmentSeverityItem : ConfigItem<PunishmentSeverityItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 没收资源
	/// - 0:不没收, 1:没收一半,2全部没收
	/// </summary>
	public readonly sbyte ResourceConfiscation;

	/// <summary>
	/// 没收道具
	/// - 0:不没收, 1:没收一半,2:全部没收
	/// </summary>
	public readonly sbyte ItemConfiscation;

	/// <summary>
	/// 废除门派功法
	/// - 0:不废除,1:废除超出品级的功法,2:废除全部功法
	/// </summary>
	public readonly sbyte CombatSkillRevoke;

	/// <summary>
	/// 囚禁时间
	/// - 囚禁到门派监牢的时间.
	/// </summary>
	public readonly int PrisonTime;

	/// <summary>
	/// 逐出门派
	/// - 逐出门派成为乞丐, 同时会断绝所有师徒关系.
	/// </summary>
	public readonly bool Expel;

	/// <summary>
	/// 赏金时间
	/// - 犯罪秘闻公开后挂在通缉名单上的持续时间
	/// </summary>
	public readonly int BountyDuration;

	/// <summary>
	/// 名誉作用乘数
	/// - 在秘闻公开，判断犯罪给予名誉词条时的乘数
	/// </summary>
	public readonly int FameActionFactorInPunish;

	/// <summary>
	/// 各个立场试图逃离惩罚的概率
	/// - {刚正,仁善,中庸,叛逆,唯我}
	/// </summary>
	public readonly sbyte[] EscapePunishmentChance;

	/// <summary>
	/// 逃离时可选择的行为
	/// </summary>
	public readonly short[] EscapeActions;

	/// <summary>
	/// 太吾威望惩罚
	/// - 当太吾违反戒律时惩罚的基础威望数值
	/// </summary>
	public readonly int CommonAuthorityDelta;

	/// <summary>
	/// 太吾恩义惩罚
	/// - 当太吾违反戒律时惩罚的基础地区恩义数值
	/// </summary>
	public readonly int CommonSpiritualDebtDelta;

	/// <summary>
	/// 少林惩罚
	/// - 太吾与所有人的好感立即向陌路变化
	/// </summary>
	public readonly short ShaolinDelta;

	/// <summary>
	/// 元山惩罚
	/// - 心情和入魔值变化
	/// </summary>
	public readonly List<int> YuanshanDelta;

	/// <summary>
	/// 铸剑惩罚
	/// - 身龄变化
	/// </summary>
	public readonly short ZhujianDelta;

	/// <summary>
	/// 空桑惩罚
	/// - 立即随机受到相当于服食[参数]类8级毒药的毒素
	/// </summary>
	public readonly int KongsangDelta;

	/// <summary>
	/// 五仙惩罚
	/// - 给人物种下[参数]种成蛊
	/// </summary>
	public readonly int WuxianDelta;

	/// <summary>
	/// 血犼惩罚
	/// - 随机[参数]个身体部位受到4层外伤或内伤，同时根据受到外伤或内伤，向人物添加伤坏或剧痛的特性
	/// </summary>
	public readonly int XuehouDelta;

	/// <summary>
	/// 描述文本
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 名称颜色
	/// </summary>
	public readonly string NameColor;

	/// <summary>
	/// 惩罚描述
	/// </summary>
	public readonly string PunishmentDesc;

	/// <summary>
	/// 自首经历
	/// </summary>
	public readonly short NormalRecord;

	/// <summary>
	/// 被抓经历
	/// </summary>
	public readonly short ArrestedRecord;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="resourceConfiscation">没收资源 - 0:不没收, 1:没收一半,2全部没收</param>
	/// <param name="itemConfiscation">没收道具 - 0:不没收, 1:没收一半,2:全部没收</param>
	/// <param name="combatSkillRevoke">废除门派功法 - 0:不废除,1:废除超出品级的功法,2:废除全部功法</param>
	/// <param name="prisonTime">囚禁时间 - 囚禁到门派监牢的时间.</param>
	/// <param name="expel">逐出门派 - 逐出门派成为乞丐, 同时会断绝所有师徒关系.</param>
	/// <param name="bountyDuration">赏金时间 - 犯罪秘闻公开后挂在通缉名单上的持续时间</param>
	/// <param name="fameActionFactorInPunish">名誉作用乘数 - 在秘闻公开，判断犯罪给予名誉词条时的乘数</param>
	/// <param name="escapePunishmentChance">各个立场试图逃离惩罚的概率 - {刚正,仁善,中庸,叛逆,唯我}</param>
	/// <param name="escapeActions">逃离时可选择的行为</param>
	/// <param name="commonAuthorityDelta">太吾威望惩罚 - 当太吾违反戒律时惩罚的基础威望数值</param>
	/// <param name="commonSpiritualDebtDelta">太吾恩义惩罚 - 当太吾违反戒律时惩罚的基础地区恩义数值</param>
	/// <param name="shaolinDelta">少林惩罚 - 太吾与所有人的好感立即向陌路变化</param>
	/// <param name="yuanshanDelta">元山惩罚 - 心情和入魔值变化</param>
	/// <param name="zhujianDelta">铸剑惩罚 - 身龄变化</param>
	/// <param name="kongsangDelta">空桑惩罚 - 立即随机受到相当于服食[参数]类8级毒药的毒素</param>
	/// <param name="wuxianDelta">五仙惩罚 - 给人物种下[参数]种成蛊</param>
	/// <param name="xuehouDelta">血犼惩罚 - 随机[参数]个身体部位受到4层外伤或内伤，同时根据受到外伤或内伤，向人物添加伤坏或剧痛的特性</param>
	/// <param name="name">描述文本</param>
	/// <param name="nameColor">名称颜色</param>
	/// <param name="punishmentDesc">惩罚描述</param>
	/// <param name="normalRecord">自首经历</param>
	/// <param name="arrestedRecord">被抓经历</param>
	public PunishmentSeverityItem(sbyte templateId, sbyte resourceConfiscation, sbyte itemConfiscation, sbyte combatSkillRevoke, int prisonTime, bool expel, int bountyDuration, int fameActionFactorInPunish, sbyte[] escapePunishmentChance, short[] escapeActions, int commonAuthorityDelta, int commonSpiritualDebtDelta, short shaolinDelta, List<int> yuanshanDelta, short zhujianDelta, int kongsangDelta, int wuxianDelta, int xuehouDelta, string name, string nameColor, string punishmentDesc, short normalRecord, short arrestedRecord)
	{
		TemplateId = templateId;
		ResourceConfiscation = resourceConfiscation;
		ItemConfiscation = itemConfiscation;
		CombatSkillRevoke = combatSkillRevoke;
		PrisonTime = prisonTime;
		Expel = expel;
		BountyDuration = bountyDuration;
		FameActionFactorInPunish = fameActionFactorInPunish;
		EscapePunishmentChance = escapePunishmentChance;
		EscapeActions = escapeActions;
		CommonAuthorityDelta = commonAuthorityDelta;
		CommonSpiritualDebtDelta = commonSpiritualDebtDelta;
		ShaolinDelta = shaolinDelta;
		YuanshanDelta = yuanshanDelta;
		ZhujianDelta = zhujianDelta;
		KongsangDelta = kongsangDelta;
		WuxianDelta = wuxianDelta;
		XuehouDelta = xuehouDelta;
		Name = name;
		NameColor = nameColor;
		PunishmentDesc = punishmentDesc;
		NormalRecord = normalRecord;
		ArrestedRecord = arrestedRecord;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public PunishmentSeverityItem()
	{
		TemplateId = 0;
		ResourceConfiscation = 0;
		ItemConfiscation = 0;
		CombatSkillRevoke = 0;
		PrisonTime = 0;
		Expel = false;
		BountyDuration = 6;
		FameActionFactorInPunish = 0;
		EscapePunishmentChance = new sbyte[5] { 50, 50, 50, 50, 50 };
		EscapeActions = new short[0];
		CommonAuthorityDelta = 0;
		CommonSpiritualDebtDelta = 0;
		ShaolinDelta = 0;
		YuanshanDelta = new List<int>();
		ZhujianDelta = 0;
		KongsangDelta = 0;
		WuxianDelta = 0;
		XuehouDelta = 0;
		Name = null;
		NameColor = null;
		PunishmentDesc = null;
		NormalRecord = 0;
		ArrestedRecord = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public PunishmentSeverityItem(sbyte templateId, PunishmentSeverityItem other)
	{
		TemplateId = templateId;
		ResourceConfiscation = other.ResourceConfiscation;
		ItemConfiscation = other.ItemConfiscation;
		CombatSkillRevoke = other.CombatSkillRevoke;
		PrisonTime = other.PrisonTime;
		Expel = other.Expel;
		BountyDuration = other.BountyDuration;
		FameActionFactorInPunish = other.FameActionFactorInPunish;
		EscapePunishmentChance = other.EscapePunishmentChance;
		EscapeActions = other.EscapeActions;
		CommonAuthorityDelta = other.CommonAuthorityDelta;
		CommonSpiritualDebtDelta = other.CommonSpiritualDebtDelta;
		ShaolinDelta = other.ShaolinDelta;
		YuanshanDelta = other.YuanshanDelta;
		ZhujianDelta = other.ZhujianDelta;
		KongsangDelta = other.KongsangDelta;
		WuxianDelta = other.WuxianDelta;
		XuehouDelta = other.XuehouDelta;
		Name = other.Name;
		NameColor = other.NameColor;
		PunishmentDesc = other.PunishmentDesc;
		NormalRecord = other.NormalRecord;
		ArrestedRecord = other.ArrestedRecord;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override PunishmentSeverityItem Duplicate(int templateId)
	{
		return new PunishmentSeverityItem((sbyte)templateId, this);
	}
}
