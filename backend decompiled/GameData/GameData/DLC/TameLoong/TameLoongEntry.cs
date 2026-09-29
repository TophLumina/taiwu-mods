using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World.MonthlyEvent;
using GameData.GameDataBridge;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.DLC.TameLoong;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class TameLoongEntry : IDlcEntry, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort TameDict = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "TameDict" };
	}

	[SerializableGameDataField]
	public Dictionary<short, TameLoongData> TameDict = new Dictionary<short, TameLoongData>();

	public static TameLoongEntry Instance
	{
		[return: MaybeNull]
		get
		{
			TameLoongEntry data;
			return DomainManager.Extra.TryGetDlcEntry<TameLoongEntry>(5093830uL, out data) ? data : null;
		}
	}

	private IEnumerable<GameData.Domains.Character.Character> AllCricketPolymorphCharacters
	{
		get
		{
			foreach (TameLoongData polymorph in TameDict.Values)
			{
				if (DomainManager.Character.TryGetElement_Objects(polymorph.MaleCharacterId, out var male))
				{
					yield return male;
				}
				if (DomainManager.Character.TryGetElement_Objects(polymorph.FemaleCharacterId, out var female))
				{
					yield return female;
				}
				male = null;
				female = null;
			}
		}
	}

	private IEnumerable<GameData.Domains.Character.Character> AllDeadCricketPolymorphCharacters
	{
		get
		{
			foreach (TameLoongData polymorph in TameDict.Values)
			{
				if (!polymorph.ContainsState(EPolymorphState.Male) && DomainManager.Character.TryGetElement_Objects(polymorph.MaleCharacterId, out var male))
				{
					yield return male;
				}
				if (!polymorph.ContainsState(EPolymorphState.Female) && DomainManager.Character.TryGetElement_Objects(polymorph.FemaleCharacterId, out var female))
				{
					yield return female;
				}
				male = null;
				female = null;
			}
		}
	}

	public void OnLoadedArchiveData(bool firstEnable)
	{
	}

	public void OnEnterNewWorld()
	{
	}

	public void OnPostAdvanceMonth(DataContext context)
	{
		InvokeWaitForReturnPolymorphMonthlyEvent();
	}

	public void OnCrossArchive(DataContext context, IDlcEntry entryBeforeCrossArchive)
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(TameDict);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 1;
		pCurrData += 2;
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref TameDict);
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref TameDict);
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public static EGmCreateInventoryItemResult GmAddLoongCarrierToTaiwu(DataContext context, short carrierTemplateId)
	{
		short enemyTemplateId = TameLoongData.GetEnemyTemplateIdByCarrierTemplateId(carrierTemplateId);
		if (enemyTemplateId == -1)
		{
			return EGmCreateInventoryItemResult.Success;
		}
		TameLoongEntry entry = Instance;
		if (entry == null)
		{
			AdaptableLog.Warning("TameLoong DLC not installed.", appendWarningMessage: true);
			return EGmCreateInventoryItemResult.TameLoongDlcNotInstalled;
		}
		switch (PolymorphState(enemyTemplateId))
		{
		case 1:
			return EGmCreateInventoryItemResult.LoongAlreadyCarrier;
		case 2:
			return EGmCreateInventoryItemResult.LoongAlreadyPolymorph;
		default:
		{
			ItemKey itemKey = entry.ConvertLoongToItem(context, enemyTemplateId);
			if (!itemKey.IsValid() || !(DomainManager.Item.TryGetBaseItem(itemKey) is GameData.Domains.Item.Carrier))
			{
				AdaptableLog.Warning($"invalid loong carrier item {itemKey} for {enemyTemplateId}.", appendWarningMessage: true);
				return EGmCreateInventoryItemResult.LoongCarrierCreateFailed;
			}
			DefeatAppearedFiveLoong(context, enemyTemplateId);
			if (!ConvertLoongToCarrier(context, enemyTemplateId, addItemToInventory: true).IsValid())
			{
				AdaptableLog.Warning($"failed to add loong carrier {itemKey} to taiwu.", appendWarningMessage: true);
				return EGmCreateInventoryItemResult.LoongCarrierCreateFailed;
			}
			return EGmCreateInventoryItemResult.Success;
		}
		}
	}

	public static void DefeatAppearedFiveLoongByTaiwuCarriers(DataContext context)
	{
		TameLoongEntry entry = Instance;
		if (entry == null)
		{
			return;
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		for (short enemyTemplateId = 246; enemyTemplateId <= 250; enemyTemplateId++)
		{
			if (entry.TryGetItemData(enemyTemplateId, out var carrier) && carrier.Owner.OwnerId == taiwuCharId)
			{
				DefeatAppearedFiveLoong(context, enemyTemplateId);
			}
		}
	}

	private static void DefeatAppearedFiveLoong(DataContext context, short enemyTemplateId)
	{
		if (DomainManager.Extra.TryGetElement_FiveLoongDict(enemyTemplateId, out var _))
		{
			EventHelper.DefeatFiveLoong(enemyTemplateId);
		}
	}

	public static void SetOwner(DataContext context, GameData.Domains.Item.Carrier carrier, bool isTaiwu)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (isTaiwu)
		{
			ItemOwnerKey owner = carrier.Owner;
			if (owner.OwnerType == ItemOwnerType.TameLoong && owner.OwnerId == -1)
			{
				carrier.ResetOwner();
			}
			else if (carrier.Owner.OwnerId == taiwuCharId)
			{
				return;
			}
			GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
			taiwuChar.AddInventoryItem(context, carrier.GetItemKey(), 1);
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenGetItem_Item, new List<ItemDisplayData> { DomainManager.Item.GetItemDisplayData(carrier, 1, taiwuCharId, -1) }, arg2: false);
		}
		else if (carrier.Owner.OwnerType == ItemOwnerType.None)
		{
			carrier.SetOwner(ItemOwnerType.TameLoong, -1);
		}
	}

	public ItemKey ConvertLoongToItem(DataContext context, short enemyTemplateId)
	{
		if (!TameDict.TryGetValue(enemyTemplateId, out var loongData))
		{
			TameLoongData tameLoongData = new TameLoongData();
			tameLoongData.ItemKey = DomainManager.Item.CreateCarrier(context, TameLoongData.GetCarrierTemplateIdByEnemyTemplateId(enemyTemplateId));
			loongData = tameLoongData;
		}
		TameDict[enemyTemplateId] = loongData;
		return loongData.ItemKey;
	}

	public static int PolymorphState(short enemyTemplateId)
	{
		TameLoongEntry instance = Instance;
		if (instance == null || !instance.TameDict.TryGetValue(enemyTemplateId, out var polymorph))
		{
			return 0;
		}
		if ((polymorph.State & EPolymorphState.Dead) != EPolymorphState.None)
		{
			return 3;
		}
		if (polymorph.IsAlive)
		{
			return 2;
		}
		return 1;
	}

	public static bool IsLoongFree(short enemyTemplateId)
	{
		TameLoongEntry instance = Instance;
		TameLoongData data = default(TameLoongData);
		bool flag = instance == null || !instance.TameDict.TryGetValue(enemyTemplateId, out data);
		bool flag2 = flag;
		if (!flag2)
		{
			EPolymorphState state = data.State;
			bool flag3 = ((state == EPolymorphState.None || state == EPolymorphState.Dead) ? true : false);
			flag2 = flag3;
		}
		return flag2;
	}

	public static bool IsDeadTameLoongCharacter(int charId, short charTemplateId)
	{
		TameLoongData data = default(TameLoongData);
		return (Instance?.TameDict?.TryGetValue(TameLoongData.GetEnemyTemplateIdByCharacterTemplateId(charTemplateId), out data) ?? false) && !data.MatchCharacter(charId);
	}

	public bool IsAlivePolymorph(short enemyTemplateId)
	{
		TameLoongData data;
		return TameDict.TryGetValue(enemyTemplateId, out data) && data.IsAlive;
	}

	public bool TryGetItemData(short enemyTemplateId, out GameData.Domains.Item.Carrier carrier)
	{
		TameLoongEntry instance = Instance;
		if (instance == null || !instance.TameDict.TryGetValue(enemyTemplateId, out var data) || !data.ItemKey.IsValid() || !(DomainManager.Item.TryGetBaseItem(data.ItemKey) is GameData.Domains.Item.Carrier itemBase))
		{
			carrier = null;
			return false;
		}
		carrier = itemBase;
		return true;
	}

	public static ItemKey ConvertLoongToCarrier(DataContext context, short enemyTemplateId, bool addItemToInventory)
	{
		TameLoongEntry entry = Instance;
		if (entry == null)
		{
			AdaptableLog.Warning("FiveLoongDlcEntry invalid", appendWarningMessage: true);
			return ItemKey.Invalid;
		}
		if (!entry.TameDict.TryGetValue(enemyTemplateId, out var item))
		{
			item = new TameLoongData();
			entry.TameDict[enemyTemplateId] = item;
		}
		if (item.ItemKey == ItemKey.Invalid)
		{
			item.ItemKey = DomainManager.Item.CreateCarrier(context, TameLoongData.GetCarrierTemplateIdByEnemyTemplateId(enemyTemplateId));
		}
		else
		{
			EPolymorphState state = item.State;
			if (state != EPolymorphState.None && state != EPolymorphState.Dead)
			{
				AdaptableLog.Warning($"loong item {item.ItemKey} for {enemyTemplateId} has invalid state {item.State}: {item}!", appendWarningMessage: true);
				return ItemKey.Invalid;
			}
		}
		item.State = EPolymorphState.Returned;
		if (!(DomainManager.Item.TryGetBaseItem(item.ItemKey) is GameData.Domains.Item.Carrier itemBase))
		{
			AdaptableLog.Warning($"loong item {item.ItemKey} invalid!", appendWarningMessage: true);
			return ItemKey.Invalid;
		}
		if (addItemToInventory)
		{
			SetOwner(context, itemBase, isTaiwu: true);
		}
		itemBase.SetCurrDurability(itemBase.GetMaxDurability(), context);
		return (entry.TameDict[enemyTemplateId] = item).ItemKey;
	}

	public static bool Flee(DataContext context, ItemKey key)
	{
		short enemyTemplateId = TameLoongData.GetEnemyTemplateId(key);
		if (enemyTemplateId == -1)
		{
			return false;
		}
		if (!DomainManager.Item.TryGetElement_Carriers(key.Id, out var carrier))
		{
			AdaptableLog.Warning($"carrier {key} invalid, data corrupted.", appendWarningMessage: true);
			return true;
		}
		TameLoongEntry entry = Instance;
		if (entry == null)
		{
			AdaptableLog.Warning("TameLoong Dlc not installed, data corrupted.", appendWarningMessage: true);
			return true;
		}
		if (!entry.TameDict.TryGetValue(enemyTemplateId, out var data))
		{
			AdaptableLog.Warning($"enemyTemplateId {enemyTemplateId} invalid, data corrupted.", appendWarningMessage: true);
			return true;
		}
		if (data.ItemKey != key)
		{
			AdaptableLog.Warning($"enemyTemplateId {enemyTemplateId} records {data.ItemKey}, but {key} found, data corrupted.", appendWarningMessage: true);
			return true;
		}
		SetOwner(context, carrier, isTaiwu: false);
		data.State = EPolymorphState.Dead;
		entry.TameDict[enemyTemplateId] = data;
		return true;
	}

	public static GameData.Domains.Character.Character Polymorph(DataContext context, ItemKey key, sbyte gender)
	{
		TameLoongEntry entry = Instance;
		if (entry == null)
		{
			AdaptableLog.Warning("TameLoong DLC not installed.", appendWarningMessage: true);
			return null;
		}
		short characterTemplateId = TameLoongData.GetCharacterTemplateId(TameLoongData.GetEnemyTemplateId(key), gender);
		CharacterItem config = Config.Character.Instance.GetItemOrDefault(characterTemplateId);
		if (config == null)
		{
			AdaptableLog.Warning($"loong character templateId {characterTemplateId} = LoongPolymorphData.GetCharacterTemplateId(LoongPolymorphData.GetEnemyTemplateId({key}), {gender}) invalid.", appendWarningMessage: true);
			return null;
		}
		if (!DomainManager.Item.TryGetElement_Carriers(key.Id, out var carrier))
		{
			AdaptableLog.Warning($"Polymorph item {key} invalid", appendWarningMessage: true);
			return null;
		}
		short enemyTemplateId = TameLoongData.GetEnemyTemplateIdByCharacterTemplateId(characterTemplateId);
		if (entry.IsAlivePolymorph(enemyTemplateId))
		{
			AdaptableLog.Warning($"Loong {enemyTemplateId} is alive, should not perform polymorph.", appendWarningMessage: true);
			return null;
		}
		if (!entry.TameDict.TryGetValue(enemyTemplateId, out var polymorph))
		{
			polymorph = new TameLoongData();
		}
		if (polymorph.State != EPolymorphState.Returned)
		{
			AdaptableLog.Warning($"Loong {enemyTemplateId} in state {polymorph.State}, should be {EPolymorphState.Returned}.", appendWarningMessage: true);
			return null;
		}
		bool male = gender == 1;
		ref int charId = ref male ? ref polymorph.MaleCharacterId : ref polymorph.FemaleCharacterId;
		bool isFirstPolymorph = charId < 0;
		if (isFirstPolymorph)
		{
			charId = PolymorphHelper.CreatePolymorphCharacter(context, characterTemplateId);
		}
		if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			DomainManager.Character.UnhideCharacterOnMap(context, character, 128uL);
			if (!isFirstPolymorph)
			{
				DomainManager.LifeRecord.GetLifeRecordCollection().AddDLCLoongRetranmogrifyToHuman(charId, DomainManager.World.GetCurrDate(), DomainManager.Taiwu.GetTaiwu().GetValidLocation());
			}
			polymorph.State = (male ? EPolymorphState.Male : EPolymorphState.Female);
			PolymorphHelper.ResetPolymorphCharacter(context, charId);
			polymorph.ItemKey = key;
			SetOwner(context, carrier, isTaiwu: false);
			entry.TameDict[enemyTemplateId] = polymorph;
			return character;
		}
		AdaptableLog.Warning($"invalid character id {charId}", appendWarningMessage: true);
		return null;
	}

	public void InvokeWaitForReturnPolymorphMonthlyEvent()
	{
		MonthlyEventCollection monthlyEvent = DomainManager.World.GetMonthlyEventCollection();
		foreach (TameLoongData polymorph in TameDict.Values)
		{
			if (polymorph.ContainsState(EPolymorphState.WaitForReturn))
			{
				int charId = polymorph.CharacterId;
				if (charId >= 0)
				{
					monthlyEvent.AddDLCTameLoongPolymorphReturn(charId);
				}
			}
		}
	}

	public static ItemKey PolymorphReturn(DataContext context, GameData.Domains.Character.Character character, bool byDead = false, bool additem = true)
	{
		TameLoongEntry entry = Instance;
		if (entry == null)
		{
			AdaptableLog.Warning("TameLoong DLC not installed.", appendWarningMessage: true);
			return ItemKey.Invalid;
		}
		short enemyTemplateId = TameLoongData.GetEnemyTemplateIdByCharacterTemplateId(character.GetTemplateId());
		if (!entry.TameDict.TryGetValue(enemyTemplateId, out var polymorph))
		{
			AdaptableLog.Warning($"invalid PolymorphReturn called for {character}: enemyTemplateId {enemyTemplateId} has no data", appendWarningMessage: true);
			return ItemKey.Invalid;
		}
		if (!DomainManager.Item.TryGetElement_Carriers(polymorph.ItemKey.Id, out var carrier))
		{
			AdaptableLog.Warning($"invalid carrier item for {character}: enemyTemplateId {enemyTemplateId} has invalid ItemKey = {polymorph.ItemKey}", appendWarningMessage: true);
			return ItemKey.Invalid;
		}
		if (!polymorph.IsAlive)
		{
			AdaptableLog.Warning($"{character} has enemyTemplateId {enemyTemplateId} has invalid state {polymorph.State}", appendWarningMessage: true);
			return ItemKey.Invalid;
		}
		if (!byDead && additem)
		{
			SetOwner(context, carrier, isTaiwu: true);
		}
		polymorph.State = (byDead ? EPolymorphState.Dead : EPolymorphState.Returned);
		PolymorphHelper.PolymorphCharacterReturnToVoid(context, character);
		entry.TameDict[enemyTemplateId] = polymorph;
		return byDead ? ItemKey.Invalid : polymorph.ItemKey;
	}

	public static bool HandlePolymorphDead(DataContext context, GameData.Domains.Character.Character character)
	{
		short enemyTemplateId = TameLoongData.GetEnemyTemplateIdByCharacterTemplateId(character.GetTemplateId());
		if (enemyTemplateId == -1)
		{
			return false;
		}
		TameLoongEntry entry = Instance;
		if (entry == null)
		{
			return false;
		}
		if (!entry.TameDict.TryGetValue(enemyTemplateId, out var polymorph))
		{
			AdaptableLog.Warning($"invalid PolymorphReturn called for {character}: enemyTemplateId {enemyTemplateId} has no data", appendWarningMessage: true);
			return false;
		}
		PolymorphHelper.PolymorphCharacterReturnToVoid(context, character);
		polymorph.State |= EPolymorphState.WaitForReturn;
		entry.TameDict[enemyTemplateId] = polymorph;
		return true;
	}

	public void ClearAllDeadCricketPolymorphLegendaryBookStatus(DataContext context)
	{
		foreach (GameData.Domains.Character.Character character in AllDeadCricketPolymorphCharacters)
		{
			PolymorphHelper.ClearLegendaryBookStatus(context, character);
		}
	}
}
