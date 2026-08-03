using System;
using GameData.Adventure;

namespace GameData.Domains.Adventure;

public class AdventureExternalBridgeImplement : IAdventureExternalBridge
{
	public string Tr(AdventureLocalStringRef @ref)
	{
		if (@ref != null)
		{
			return LocalStringManager.GetConfig("AdventureCore_language", @ref.Key);
		}
		return string.Empty;
	}

	public void LogException(string message)
	{
		throw new Exception(message);
	}
}
