using System.Collections.Generic;
using GameData.DLC.FiveLoong;
using GameData.Serializer;

namespace GameData.Domains.Item;

[SerializableGameData(NoCopyConstructors = true, NotForDisplayModule = true, IsExtensible = true)]
public class ItemGroupPackage : ISerializableGameData
{
	private static class ItemBaseDictSerializationHandler
	{
		public static int GetSerializedSize(Dictionary<int, ItemBase> target)
		{
			if (target == null)
			{
				return 4;
			}
			int size = 4;
			foreach (KeyValuePair<int, ItemBase> pair in target)
			{
				size += 4;
				size++;
				size += ((ISerializableGameData)pair.Value).GetSerializedSize();
			}
			return size;
		}

		public unsafe static int Serialize(byte* pData, Dictionary<int, ItemBase> target)
		{
			byte* pCurrData = pData;
			if (target != null)
			{
				*(int*)pCurrData = target.Count;
				pCurrData += 4;
				foreach (KeyValuePair<int, ItemBase> pair in target)
				{
					*(int*)pCurrData = pair.Key;
					pCurrData += 4;
					*pCurrData += (byte)pair.Value.GetItemType();
					pCurrData++;
					pCurrData += ((ISerializableGameData)pair.Value).Serialize(pCurrData);
				}
			}
			else
			{
				*(int*)pCurrData = 0;
				pCurrData += 4;
			}
			return (int)(pCurrData - pData);
		}

		public unsafe static int Deserialize(byte* pData, ref Dictionary<int, ItemBase> target)
		{
			byte* pCurrData = pData;
			int count = *(int*)pCurrData;
			pCurrData += 4;
			if (count > 0)
			{
				if (target == null)
				{
					target = new Dictionary<int, ItemBase>();
				}
				else
				{
					target.Clear();
				}
				for (int i = 0; i < count; i++)
				{
					int key = *(int*)pCurrData;
					pCurrData += 4;
					sbyte itemType = (sbyte)(*pCurrData);
					pCurrData++;
					if (1 == 0)
					{
					}
					ItemBase itemBase = itemType switch
					{
						0 => new Weapon(), 
						1 => new Armor(), 
						2 => new Accessory(), 
						3 => new Clothing(), 
						4 => new Carrier(), 
						5 => new Material(), 
						6 => new CraftTool(), 
						7 => new Food(), 
						8 => new Medicine(), 
						9 => new TeaWine(), 
						10 => new SkillBook(), 
						11 => new Cricket(), 
						12 => new Misc(), 
						_ => throw ItemTemplateHelper.CreateItemTypeException(itemType), 
					};
					if (1 == 0)
					{
					}
					ItemBase value = itemBase;
					pCurrData += ((ISerializableGameData)value).Deserialize(pCurrData);
					target.Add(key, value);
				}
			}
			else
			{
				target?.Clear();
			}
			return (int)(pCurrData - pData);
		}
	}

	private static class FieldIds
	{
		public const ushort Items = 0;

		public const ushort RefiningEffects = 1;

		public const ushort FullPoisonEffects = 2;

		public const ushort CricketIsSmart = 3;

		public const ushort CricketIsIdentified = 4;

		public const ushort CarrierTamePoint = 5;

		public const ushort Jiaos = 6;

		public const ushort ChildrenOfLoong = 7;

		public const ushort JiaoKeyToId = 8;

		public const ushort ChildrenOfLoongKeyToId = 9;

		public const ushort ClothingDisplayModifications = 10;

		public const ushort MysteryEffects = 11;

		public const ushort Count = 12;

		public static readonly string[] FieldId2FieldName = new string[12]
		{
			"Items", "RefiningEffects", "FullPoisonEffects", "CricketIsSmart", "CricketIsIdentified", "CarrierTamePoint", "Jiaos", "ChildrenOfLoong", "JiaoKeyToId", "ChildrenOfLoongKeyToId",
			"ClothingDisplayModifications", "MysteryEffects"
		};
	}

	[SerializableGameDataField(SerializationHandler = "ItemBaseDictSerializationHandler")]
	public Dictionary<int, ItemBase> Items = new Dictionary<int, ItemBase>();

	[SerializableGameDataField]
	public Dictionary<int, RefiningEffects> RefiningEffects;

	[SerializableGameDataField]
	public Dictionary<int, FullPoisonEffects> FullPoisonEffects;

	[SerializableGameDataField]
	public Dictionary<int, MysteryData> MysteryEffects;

	[SerializableGameDataField]
	public Dictionary<int, bool> CricketIsSmart = new Dictionary<int, bool>();

	[SerializableGameDataField]
	public Dictionary<int, bool> CricketIsIdentified = new Dictionary<int, bool>();

	[SerializableGameDataField]
	public Dictionary<int, int> CarrierTamePoint = new Dictionary<int, int>();

	[SerializableGameDataField]
	public Dictionary<int, Jiao> Jiaos = new Dictionary<int, Jiao>();

	[SerializableGameDataField]
	public Dictionary<int, ChildrenOfLoong> ChildrenOfLoong = new Dictionary<int, ChildrenOfLoong>();

	[SerializableGameDataField]
	public Dictionary<ItemKey, int> JiaoKeyToId = new Dictionary<ItemKey, int>();

	[SerializableGameDataField]
	public Dictionary<ItemKey, int> ChildrenOfLoongKeyToId = new Dictionary<ItemKey, int>();

	[SerializableGameDataField]
	public Dictionary<int, short> ClothingDisplayModifications;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize += ItemBaseDictSerializationHandler.GetSerializedSize(Items);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(RefiningEffects);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(FullPoisonEffects);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(CricketIsSmart);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(CricketIsIdentified);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(CarrierTamePoint);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(Jiaos);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(ChildrenOfLoong);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(JiaoKeyToId);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(ChildrenOfLoongKeyToId);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(ClothingDisplayModifications);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(MysteryEffects);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 12;
		pCurrData += 2;
		pCurrData += ItemBaseDictSerializationHandler.Serialize(pCurrData, Items);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref RefiningEffects);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref FullPoisonEffects);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref CricketIsSmart);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref CricketIsIdentified);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref CarrierTamePoint);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref Jiaos);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref ChildrenOfLoong);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref JiaoKeyToId);
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref ChildrenOfLoongKeyToId);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref ClothingDisplayModifications);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref MysteryEffects);
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
			pCurrData += ItemBaseDictSerializationHandler.Deserialize(pCurrData, ref Items);
		}
		if (fieldCount > 1)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref RefiningEffects);
		}
		if (fieldCount > 2)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref FullPoisonEffects);
		}
		if (fieldCount > 3)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref CricketIsSmart);
		}
		if (fieldCount > 4)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref CricketIsIdentified);
		}
		if (fieldCount > 5)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref CarrierTamePoint);
		}
		if (fieldCount > 6)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref Jiaos);
		}
		if (fieldCount > 7)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref ChildrenOfLoong);
		}
		if (fieldCount > 8)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref JiaoKeyToId);
		}
		if (fieldCount > 9)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref ChildrenOfLoongKeyToId);
		}
		if (fieldCount > 10)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref ClothingDisplayModifications);
		}
		if (fieldCount > 11)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref MysteryEffects);
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
