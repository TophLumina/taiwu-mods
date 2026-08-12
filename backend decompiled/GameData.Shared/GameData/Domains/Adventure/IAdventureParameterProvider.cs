using System.Collections.Generic;
using GameData.Adventure;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇变量提供者
/// </summary>
public interface IAdventureParameterProvider
{
	/// <summary>
	/// 变量核心库
	/// </summary>
	IReadOnlyList<AdventureParameterData> Parameters { get; }

	/// <summary>
	/// 获取变量值
	/// </summary>
	AdventureParameterValue? GetParameterOrNull(AdventureParameterKey key);

	/// <summary>
	/// 设置变量值
	/// </summary>
	void SetParameter(AdventureParameterKey key, AdventureParameterValue value);

	/// <summary>
	/// 移除变量值
	/// </summary>
	void RemoveParameter(AdventureParameterKey key);
}
