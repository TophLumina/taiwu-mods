using GameData.Domains.Character;
using GameData.Domains.Information;
using GameData.Domains.TaiwuEvent.EventHelper;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class InformationFunctions
{
	[EventFunction(593)]
	private static void StartInformationSelect(EventScriptRuntime runtime, GameData.Domains.Character.Character character, string saveKey, sbyte informationType)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.StartInformationSelect(character.GetId(), saveKey, isNormalInformation: true, informationType);
	}

	[EventFunction(595)]
	private static string ApplyNormalInformation(EventScriptRuntime runtime, GameData.Domains.Character.Character character, NormalInformation normalInformation, string effectiveGuid, string normalGuid, string ineffectiveGuid)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ApplyNormalInformation(character.GetId(), runtime.ArgBox, normalInformation, effectiveGuid, normalGuid, ineffectiveGuid);
	}
}
