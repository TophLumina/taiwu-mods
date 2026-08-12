using System;
using GameData.Domains.Map;

namespace GameData.Domains.Character;

/// <summary>
/// 角色死亡信息
/// </summary>
public struct CharacterDeathInfo
{
	/// <summary>
	/// 杀死该角色的人
	/// </summary>
	public int KillerId;

	/// <summary>
	/// 奇遇
	/// </summary>
	public int AdventureId;

	/// <summary>
	/// 死亡日期
	/// </summary>
	public int DeathDate;

	/// <summary>
	/// 死亡地点
	/// </summary>
	public Location Location;

	/// <summary>
	/// 禁止不指定位置生成死亡信息
	/// </summary>
	/// <exception cref="T:System.NotImplementedException"></exception>
	[Obsolete("Death info must be created with a location.", true)]
	public CharacterDeathInfo()
	{
		throw new NotImplementedException("Death info must be created with a location.");
	}

	/// <summary>
	/// 默认死亡信息
	/// </summary>
	public CharacterDeathInfo(Location location)
	{
		DeathDate = ExternalDataBridge.Context.CurrDate;
		AdventureId = 0;
		KillerId = -1;
		Location = location;
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return $"{{killer={KillerId}, location={Location}, adventure={AdventureId}}}";
	}
}
