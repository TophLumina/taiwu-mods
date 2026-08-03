using System.Collections.Generic;
using GameData.Adventure;
using GameData.Domains.Map;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇运行时
/// </summary>
public interface IAdventureRuntime : IAdventureParameterProvider
{
	/// <summary>
	/// 实例 ID
	/// </summary>
	int Id { get; }

	/// <summary>
	/// 核心 ID
	/// </summary>
	int CoreId { get; }

	/// <summary>
	/// 核心数据
	/// </summary>
	IAdventureData Core => ExternalDataBridge.Context.AdventureCore.GetAdventureAny(CoreId);

	/// <summary>
	/// 地图位置
	/// </summary>
	Location MapLocation { get; }

	/// <summary>
	/// 剩余持续时间，负数为无限
	/// </summary>
	int RemainMonths { get; }

	/// <summary>
	/// 是否所有必要人物均已拉取
	/// </summary>
	bool Satisfied { get; }

	/// <summary>
	/// 当前状态类型
	/// </summary>
	EAdventureStatusType StatusType { get; }

	/// <summary>
	/// 获取所有拉取到的智能人物
	/// </summary>
	void CollectCharacters(ICollection<int> characters);

	/// <summary>
	/// 抓取指定批次的人物
	/// </summary>
	bool CallCharacters(IAdventureContextBridge context, EAdventureCharacterType type);

	/// <summary>
	/// 设置状态类型
	/// </summary>
	void SetStatusType(IAdventureContextBridge context, EAdventureStatusType statusType);

	/// <summary>
	/// 是否临时人物
	/// </summary>
	bool IsTemporaryCharacter(int charId);

	/// <summary>
	/// 是否智能人物
	/// </summary>
	bool IsCalledCharacter(int charId);
}
