using System;
using GameData.Domains.Map;

namespace GameData.Domains.Character;

public struct CharacterDeathInfo
{
	public int KillerId;

	public int AdventureId;

	public int DeathDate;

	public Location Location;

	[Obsolete("Death info must be created with a location.", true)]
	public CharacterDeathInfo()
	{
		throw new NotImplementedException("Death info must be created with a location.");
	}

	public CharacterDeathInfo(Location location)
	{
		DeathDate = ExternalDataBridge.Context.CurrDate;
		AdventureId = 0;
		KillerId = -1;
		Location = location;
	}

	public override string ToString()
	{
		return $"{{killer={KillerId}, location={Location}, adventure={AdventureId}}}";
	}
}
