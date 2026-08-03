using System;

namespace GameData.Domains.Character;

/// <summary>
/// 年龄影响因素
/// </summary>
[Flags]
public enum AgeAffector : byte
{
	/// <summary>
	/// 无
	/// </summary>
	None = 0,
	/// <summary>
	/// 道长特效
	/// </summary>
	TaoismPassive = 1,
	/// <summary>
	/// 云游道4技能
	/// </summary>
	TaoismActive = 2,
	/// <summary>
	/// 洗髓经
	/// </summary>
	MaleKeepYoung = 4,
	/// <summary>
	/// 大太阴
	/// </summary>
	FemaleKeepYoung = 8
}
