using System.Collections.Generic;
using GameData.DLC.TameLoong;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.GameDataBridge;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class TameLoongFunctions
{
	[EventFunction(923)]
	public static bool GotJiaoEgg(EventScriptRuntime runtime)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GotJiaoEgg();
	}

	[EventFunction(936)]
	public static bool GotLoongScale(EventScriptRuntime runtime)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GotLoongScale();
	}

	[EventFunction(924)]
	public static bool HaveDefeatFiveLoong(EventScriptRuntime runtime)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.HaveDefeatFiveLoong();
	}

	[EventFunction(922)]
	public static bool IsItemKeyLoongCarrier(EventScriptRuntime runtime, ItemKey key)
	{
		return TameLoongData.GetEnemyTemplateId(key) != -1;
	}

	[EventFunction(914)]
	private static ItemKey ConvertLoongToCarrier(EventScriptRuntime runtime, short enemyTemplateId, bool addItem = true)
	{
		return TameLoongEntry.ConvertLoongToCarrier(runtime.Context, enemyTemplateId, addItem);
	}

	[EventFunction(917)]
	public static int Polymorph(EventScriptRuntime runtime, ItemKey itemKey, sbyte gender, bool anonymous, string afterEvent = "")
	{
		if (gender < 0)
		{
			gender = (sbyte)(runtime.Context.Random.NextBool() ? 1 : 0);
		}
		int id = TameLoongEntry.Polymorph(runtime.Context, itemKey, gender).GetId();
		DomainManager.TaiwuEvent.SetListenerWithActionName(afterEvent, runtime.ArgBox, "CricketPolymorphEffectOver");
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.LoongPolymorphEffect, TameLoongData.GetEnemyTemplateId(itemKey), id, anonymous);
		runtime.ToEvent();
		return id;
	}

	[EventFunction(918)]
	public static ItemKey PolymorphReturn(EventScriptRuntime runtime, GameData.Domains.Character.Character character, bool byDead = false, bool addItem = false)
	{
		return TameLoongEntry.PolymorphReturn(runtime.Context, character, byDead, addItem);
	}

	[EventFunction(944)]
	public static short GetLoongEnemyTemplateId(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		return TameLoongData.GetEnemyTemplateIdByCharacterTemplateId(character.GetTemplateId());
	}

	[EventFunction(930)]
	public static void FreeFiveLoongCarrier(EventScriptRuntime runtime, ItemKey key)
	{
		TameLoongEntry.Flee(runtime.Context, key);
	}

	[EventFunction(916)]
	public static int PolymorphState(EventScriptRuntime runtime, short enemyTemplateId)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.LoongPolymorphState(enemyTemplateId);
	}

	[EventFunction(915)]
	public static int GetFiveLoongCharacterCreated(EventScriptRuntime runtime, short enemyTemplateId)
	{
		TameLoongEntry instance = TameLoongEntry.Instance;
		if (instance != null)
		{
			Dictionary<short, TameLoongData> dict = instance.TameDict;
			if (dict != null && dict.TryGetValue(enemyTemplateId, out var polymorph))
			{
				bool flag = polymorph.MaleCharacterId != -1;
				bool flag2 = polymorph.FemaleCharacterId != -1;
				if (1 == 0)
				{
				}
				int result = ((!flag) ? (flag2 ? 2 : 0) : ((!flag2) ? 1 : 3));
				if (1 == 0)
				{
				}
				return result;
			}
		}
		return 0;
	}

	[EventFunction(942)]
	public static bool GetFiveLoongCharacter(EventScriptRuntime runtime, short enemyTemplateId, string argKey)
	{
		TameLoongEntry instance = TameLoongEntry.Instance;
		if (instance != null)
		{
			Dictionary<short, TameLoongData> dict = instance.TameDict;
			if (dict != null && dict.TryGetValue(enemyTemplateId, out var polymorph) && DomainManager.Character.TryGetElement_Objects(polymorph.CharacterId, out var ch))
			{
				runtime.ArgBox.Set(argKey, ch.GetId());
				return true;
			}
		}
		return false;
	}

	[EventFunction(937)]
	public static int GetLoongByEnemyId(EventScriptRuntime runtime, short characterTemplateId)
	{
		if (1 == 0)
		{
		}
		int result = characterTemplateId switch
		{
			246 => 0, 
			247 => 1, 
			248 => 2, 
			249 => 3, 
			250 => 4, 
			_ => -1, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	[EventFunction(946)]
	public static int GetLoongEnemyTemplateIdByItemKey(EventScriptRuntime runtime, ItemKey key)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetLoongEnemyTemplateIdByItemKey(key);
	}

	[EventFunction(939)]
	public static bool CanTameLoong(EventScriptRuntime runtime)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CanTameLoong();
	}

	[EventFunction(949)]
	public static bool CharacterIsLoong(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CharacterIsLoong(character);
	}

	[EventFunction(952)]
	public static void ApplyMonthlyEventAnimalTamingResult(EventScriptRuntime runtime, int combatResult)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ApplyMonthlyEventAnimalTamingResult(runtime.ArgBox, combatResult);
	}

	[EventFunction(953)]
	public static void JumpToMonthlyEventAnimalTamingEvent(EventScriptRuntime runtime, string playerWin, string enemyWin, string playerFlee, string enemyFlee, string playerDie, string enemyDie, string captured)
	{
		int res = 0;
		runtime.ArgBox.Get("CombatResult", ref res);
		string nextEvent;
		if (runtime.ArgBox.Get("ItemKeySeizeCarrierInCombat", out ItemKey _))
		{
			nextEvent = captured;
		}
		else
		{
			if (1 == 0)
			{
			}
			string text = res switch
			{
				0 => playerWin, 
				1 => enemyWin, 
				2 => playerFlee, 
				3 => enemyFlee, 
				4 => playerDie, 
				_ => enemyDie, 
			};
			if (1 == 0)
			{
			}
			nextEvent = text;
		}
		runtime.ToEvent(nextEvent);
	}

	[EventFunction(954)]
	public static void StartMonthlyEventAnimalTamingEventCombat(EventScriptRuntime runtime, string afterEvent, short combatConfig)
	{
		short characterTemplateId = -1;
		runtime.ArgBox.Get("MonthlyEvent_arg0", ref characterTemplateId);
		runtime.ArgBox.Get("MonthlyEvent_arg2", out ItemKey itemKey);
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.StartCombat(GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateAnimal(TameLoongData.GetFleeAnimalId(characterTemplateId), itemKey).GetId(), combatConfig, afterEvent, runtime.ArgBox);
	}

	[EventFunction(961)]
	public static void DefeatFiveLoong(EventScriptRuntime runtime, short loongTemplateId, string nextEvent)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.RecordRoleFameAction(taiwu, 78, -1, 1);
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.RemoveSingleMapAnimalOnBlock(taiwu.GetLocation(), loongTemplateId);
		int minionLoongCount = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.DefeatFiveLoong(loongTemplateId);
		List<(ItemKey, int)> showItemData = new List<(ItemKey, int)>();
		ItemKey loongScale = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddItemToRole(taiwu, 12, 276, minionLoongCount + GlobalConfig.Instance.DefeatLoongGetScaleCount, -1);
		showItemData.Add((loongScale, minionLoongCount + GlobalConfig.Instance.DefeatLoongGetScaleCount));
		for (int i = 0; i < minionLoongCount; i++)
		{
			ItemKey minionLoongJiaoEgg = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.DefeatLoongGetJiaoEgg((short)(loongTemplateId + 5), -1);
			if (minionLoongJiaoEgg.IsValid())
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddItemToRole(taiwu, minionLoongJiaoEgg, 1, -1);
				showItemData.Add((minionLoongJiaoEgg, 1));
			}
		}
		ItemKey jiaoEggMale = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.DefeatLoongGetJiaoEgg(loongTemplateId, 1);
		showItemData.Add((jiaoEggMale, 1));
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddItemToRole(taiwu, jiaoEggMale, 1, -1);
		ItemKey jiaoEggFemale = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.DefeatLoongGetJiaoEgg(loongTemplateId, 0);
		showItemData.Add((jiaoEggFemale, 1));
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddItemToRole(taiwu, jiaoEggFemale, 1, -1);
		runtime.ArgBox.Set("GetLoongScale", arg: true);
		runtime.ArgBox.Set("GotLoongScale", GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GotLoongScale());
		runtime.ArgBox.Set("GotJiaoEgg", GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GotJiaoEgg());
		EventArgBox argBox = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetFiveLoongEventArgBox();
		argBox.Set("ConchShip_PresetKey_FiveLoongDlcGotLoongScale", arg: true);
		argBox.Set("ConchShip_PresetKey_FiveLoongDlcHaveDefeatFiveLoong", arg: true);
		argBox = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetFiveLoongEventArgBox();
		argBox.Set("ConchShip_PresetKey_FiveLoongDlcGotJiaoEgg", arg: true);
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetJiaoPoolOpen();
		short clothingTemplateId = (short)(loongTemplateId - 246 + 75);
		if (!GameData.Domains.TaiwuEvent.EventHelper.EventHelper.IsTaiwuHasItem(3, clothingTemplateId))
		{
			ItemKey cloth = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddItemToRole(taiwu, 3, clothingTemplateId, 1, -1);
			showItemData.Add((cloth, 1));
		}
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetFiveLoongEventArgBox(argBox);
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ShowGetItemPageForItems(showItemData, nextEvent, runtime.ArgBox);
		runtime.ToEvent();
	}
}
