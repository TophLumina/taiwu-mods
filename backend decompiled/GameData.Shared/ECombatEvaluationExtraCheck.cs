/// <summary>
/// CombatEvaluation -&gt; ExtraCheck
/// </summary>
public enum ECombatEvaluationExtraCheck
{
	/// <summary>
	/// 未实装
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 特殊实现
	/// </summary>
	Extern,
	/// <summary>
	/// 无额外条件
	/// </summary>
	None,
	/// <summary>
	/// 技不如人
	/// </summary>
	Fail,
	/// <summary>
	/// 不分胜负
	/// </summary>
	Draw,
	/// <summary>
	/// 落荒而逃
	/// </summary>
	Flee,
	/// <summary>
	/// 克敌制胜
	/// </summary>
	Win,
	/// <summary>
	/// 强敌战斗
	/// </summary>
	FightSameLevel,
	/// <summary>
	/// 神剑归心
	/// </summary>
	BeatXiangShu,
	/// <summary>
	/// 以多欺少
	/// </summary>
	WinLess,
	/// <summary>
	/// 欺凌幼小
	/// </summary>
	WinChild,
	/// <summary>
	/// 装备凌弱
	/// </summary>
	WinWorseEquip,
	/// <summary>
	/// 真气凌弱
	/// </summary>
	WinLessNeili,
	/// <summary>
	/// 武学凌弱
	/// </summary>
	WinWorseSkill,
	/// <summary>
	/// 精纯凌弱
	/// </summary>
	WinLessConsummate,
	/// <summary>
	/// 趁人之危
	/// </summary>
	WinPregnant,
	/// <summary>
	/// 以少胜多
	/// </summary>
	WinMore,
	/// <summary>
	/// 初生之犊
	/// </summary>
	WinOlder,
	/// <summary>
	/// 装备胜强
	/// </summary>
	WinBetterEquip,
	/// <summary>
	/// 真气胜强
	/// </summary>
	WinMoreNeili,
	/// <summary>
	/// 武学胜强
	/// </summary>
	WinBetterSkill,
	/// <summary>
	/// 精纯胜强
	/// </summary>
	WinMoreConsummate,
	/// <summary>
	/// 河东狮吼
	/// </summary>
	WinInPregnant,
	/// <summary>
	/// 行侠仗义
	/// </summary>
	KillBad0,
	/// <summary>
	/// 消灭外道
	/// </summary>
	KillBad1,
	/// <summary>
	/// 伤天害理
	/// </summary>
	KillGood0,
	/// <summary>
	/// 杀害义士
	/// </summary>
	KillGood1,
	/// <summary>
	/// 狮相雄威0
	/// </summary>
	ShixiangBuff0,
	/// <summary>
	/// 狮相雄威1
	/// </summary>
	ShixiangBuff1,
	/// <summary>
	/// 狮相雄威2
	/// </summary>
	ShixiangBuff2,
	/// <summary>
	/// 木人训练
	/// </summary>
	PuppetCombat,
	/// <summary>
	/// 龙腾四海
	/// </summary>
	WinLoong,
	/// <summary>
	/// 九死一生
	/// </summary>
	CombatHard,
	/// <summary>
	/// 十死无生
	/// </summary>
	CombatVeryHard,
	/// <summary>
	/// 抵御侵袭
	/// </summary>
	OutBossCombat,
	/// <summary>
	/// 弱敌战斗
	/// </summary>
	FightLessLevel,
	/// <summary>
	/// 爪牙凌弱
	/// </summary>
	KillMinion0,
	/// <summary>
	/// 爪牙胜强
	/// </summary>
	KillMinion1,
	Count
}
