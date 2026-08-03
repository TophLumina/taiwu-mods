using GameData.Adventure;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇参与者
/// </summary>
public interface IAdventureParticipant : IAdventureParameterProvider
{
	/// <summary>
	/// 当前所处位置
	/// </summary>
	AdventureBlockIndex Index { get; }
}
