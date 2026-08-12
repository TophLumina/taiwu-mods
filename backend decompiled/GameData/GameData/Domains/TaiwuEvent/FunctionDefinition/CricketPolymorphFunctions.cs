using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.GameDataBridge;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class CricketPolymorphFunctions
{
	[EventFunction(730)]
	private static ItemKey CricketPolymorphReturnByDead(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		return DomainManager.Taiwu.CricketPolymorphReturn(runtime.Context, character, byDead: true);
	}

	[EventFunction(732)]
	public static int CricketPolymorph(EventScriptRuntime runtime, ItemKey itemKey, sbyte gender)
	{
		if (gender < 0)
		{
			gender = (sbyte)(runtime.Context.Random.NextBool() ? 1 : 0);
		}
		if (!DomainManager.Taiwu.CricketPolymorph(runtime.Context, itemKey, gender))
		{
			return -1;
		}
		if (!DomainManager.Taiwu.TryGetCricketPolymorph(itemKey.Id, out var polymorph))
		{
			return -1;
		}
		return polymorph.CurrentCharacterId;
	}

	[EventFunction(824)]
	public static void CricketPolymorphEffect(EventScriptRuntime runtime, ItemKey itemKey, GameData.Domains.Character.Character character, string afterEvent)
	{
		short colorId = 0;
		short partId = 0;
		if (DomainManager.Item.TryGetElement_Crickets(itemKey.Id, out var cricket))
		{
			colorId = cricket.GetColorId();
			partId = cricket.GetPartId();
		}
		DomainManager.TaiwuEvent.SetListenerWithActionName(afterEvent, runtime.ArgBox, "CricketPolymorphEffectOver");
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.CricketPolymorphEffect, itemKey.Id, (int)colorId, (int)partId, character.GetId());
	}
}
