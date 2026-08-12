using System;

namespace GameData.Domains.TaiwuEvent.Enum;

/// <summary>
/// 一次性事件类型
/// </summary>
public static class OneShotEventType
{
	/// <summary>
	/// 名门 采擢荐进
	/// </summary>
	[Obsolete]
	public const int AristocratSkill1IsHinted = 1;

	/// <summary>
	/// 名门 显赫一方
	/// </summary>
	[Obsolete]
	public const int AristocratSkill2IsHinted = 2;

	/// <summary>
	/// 山人 休养生息
	/// </summary>
	[Obsolete]
	public const int SavageSkill1IsHinted = 3;

	/// <summary>
	/// 山人 因地制宜
	/// </summary>
	[Obsolete]
	public const int SavageSkill2IsHinted = 4;

	/// <summary>
	/// 才俊 礼乐之教
	/// </summary>
	[Obsolete]
	public const int LiteratiSkill1IsHinted = 5;

	/// <summary>
	/// 才俊 贤士典范
	/// </summary>
	[Obsolete]
	public const int LiteratiSkill2IsHinted = 6;

	/// <summary>
	/// 武师 侠士典范
	/// </summary>
	[Obsolete]
	public const int MartialArtistSkill2IsHinted = 7;

	/// <summary>
	/// 匠人 独具匠心
	/// </summary>
	[Obsolete]
	public const int CraftSkill1IsHinted = 8;

	/// <summary>
	/// 匠人 画龙点睛
	/// </summary>
	[Obsolete]
	public const int CraftSkill2IsHinted = 9;

	/// <summary>
	/// 平民 安居乐业
	/// </summary>
	[Obsolete]
	public const int CivilianSkill1IsHinted = 10;

	/// <summary>
	/// 平民 退隐江湖
	/// </summary>
	[Obsolete]
	public const int CivilianSkill2IsHinted = 11;

	/// <summary>
	/// 旅人 绘制地图
	/// </summary>
	[Obsolete]
	public const int TravelerSkill1IsHinted = 12;

	/// <summary>
	/// 旅人 山水秘径
	/// </summary>
	[Obsolete]
	public const int TravelerSkill2IsHinted = 13;

	/// <summary>
	/// 豪客 千杯不醉
	/// </summary>
	[Obsolete]
	public const int WineTasterSkill1IsHinted = 14;

	/// <summary>
	/// 豪客 豪侠传武
	/// </summary>
	[Obsolete]
	public const int WineTasterSkill2IsHinted = 15;

	/// <summary>
	/// 贵客 浸澈三魂
	/// </summary>
	[Obsolete]
	public const int TeaTasterSkill1IsHinted = 16;

	/// <summary>
	/// 贵客 仙人泼墨
	/// </summary>
	[Obsolete]
	public const int TeaTasterSkill3IsHinted = 17;

	/// <summary>
	/// 云游僧 导恶向善
	/// </summary>
	[Obsolete]
	public const int TravelingBuddhistMonkSkill1IsHinted = 18;

	/// <summary>
	/// 云游僧 无量浮屠
	/// </summary>
	[Obsolete]
	public const int TravelingBuddhistMonkSkill2IsHinted = 19;

	/// <summary>
	/// 云游道 占卜吉凶
	/// </summary>
	[Obsolete]
	public const int TravelingTaoistMonkSkill1IsHinted = 20;

	/// <summary>
	/// 云游道 易天改命
	/// </summary>
	[Obsolete]
	public const int TravelingTaoistMonkSkill2IsHinted = 21;

	/// <summary>
	/// 云游道 化外逍遥
	/// </summary>
	[Obsolete]
	public const int TravelingTaoistMonkSkill3IsHinted = 22;

	/// <summary>
	/// 猎户 召集野兽
	/// </summary>
	[Obsolete]
	public const int HunterSkill1IsHinted = 23;

	/// <summary>
	/// 猎户 驾驭野兽
	/// </summary>
	[Obsolete]
	public const int HunterSkill2IsHinted = 24;

	/// <summary>
	/// 道长 驱邪法事
	/// </summary>
	[Obsolete]
	public const int TaoistMonkSkill1IsHinted = 25;

	/// <summary>
	/// 道长 天劫符箓
	/// </summary>
	[Obsolete]
	public const int TaoistMonkSkill2IsHinted = 26;

	/// <summary>
	/// 高僧 传法渡人
	/// </summary>
	[Obsolete]
	public const int BuddhistMonkSkill1IsHinted = 27;

	/// <summary>
	/// 高僧 超度法会
	/// </summary>
	[Obsolete]
	public const int BuddhistMonkSkill2IsHinted = 28;

	/// <summary>
	/// 乞丐 芜行俚语
	/// </summary>
	[Obsolete]
	public const int BeggarSkill1IsHinted = 29;

	/// <summary>
	/// 乞丐 万千兄弟
	/// </summary>
	[Obsolete]
	public const int BeggarSkill2IsHinted = 30;

	/// <summary>
	/// 大夫 游医义诊
	/// </summary>
	[Obsolete]
	public const int DoctorSkill1IsHinted = 31;

	/// <summary>
	/// 大夫 枯木回春
	/// </summary>
	[Obsolete]
	public const int DoctorSkill2IsHinted = 32;

	/// <summary>
	/// 富商 召集商队
	/// </summary>
	[Obsolete]
	public const int CapitalistSkill1IsHinted = 33;

	/// <summary>
	/// 富商 聚宝纳福
	/// </summary>
	[Obsolete]
	public const int CapitalistSkill2IsHinted = 34;

	/// <summary>
	/// 王公 封侯拜相
	/// </summary>
	[Obsolete]
	public const int DukeSkill1IsHinted = 35;

	/// <summary>
	/// 王公 纳贡收礼
	/// </summary>
	[Obsolete]
	public const int DukeSkill2IsHinted = 36;

	/// <summary>
	/// 道长-获得天劫符箓 提示事件1（通过石牢杀死入魔人）
	/// </summary>
	public const int TaoistMonkGetTianJieFuLu1 = 37;

	/// <summary>
	///  道长-获得天劫符箓 提示事件2（其他杀死入魔人）
	/// </summary>
	public const int TaoistMonkGetTianJieFuLu2 = 38;

	/// <summary>
	/// 道长-获得天劫符箓 提示事件3 (数量达到99）
	/// 事件中已无调用
	/// </summary>
	[Obsolete]
	public const int TaoistMonkGetTianJieFuLu3 = 39;

	/// <summary>
	/// 高僧超度人数达到一百
	/// </summary>
	[Obsolete]
	public const int SavedCountReachHundred = 40;

	/// <summary>
	/// 武师  保镖护院
	/// </summary>
	[Obsolete]
	public const int MartialArtistSkill1IsHinted = 41;

	/// <summary>
	/// 云游僧四技能解锁事件(拜访寺庙达到15座)
	/// </summary>
	[Obsolete]
	public const int TravelingBuddhistMonkSkill3IsHinted = 42;

	private const int ProfessionRelatedOneShotEventBegin = 1;

	private const int ProfessionRelatedOneShotEventEnd = 42;

	/// <summary>
	/// 璇女地区主线里-过月事件-魔念侵扰
	/// </summary>
	public const int MirrorCreatedImpostureXiangshuInfected = 43;

	/// <summary>
	/// 主线 - 驱魔之法
	/// </summary>
	public const int MainStoryExorcism = 44;

	/// <summary>
	/// 指定一次性事件类型是为志向相关
	/// </summary>
	/// <param name="oneShotEventType"></param>
	public static bool IsProfessionRelatedOneShotEvent(int oneShotEventType)
	{
		if (oneShotEventType >= 1)
		{
			return oneShotEventType <= 42;
		}
		return false;
	}
}
