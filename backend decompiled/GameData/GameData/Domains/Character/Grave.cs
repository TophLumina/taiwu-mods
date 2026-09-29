using System;
using GameData.Common;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Character;

[SerializableGameData(NotForDisplayModule = true)]
public class Grave : BaseGameDataObject, ISerializableGameData
{
	internal class FixedFieldInfos
	{
		public const uint Id_Offset = 0u;

		public const int Id_Size = 4;

		public const uint Location_Offset = 4u;

		public const int Location_Size = 4;

		public const uint Level_Offset = 8u;

		public const int Level_Size = 1;

		public const uint Durability_Offset = 9u;

		public const int Durability_Size = 2;

		public const uint Resources_Offset = 11u;

		public const int Resources_Size = 32;

		public const uint SkeletonCharId_Offset = 43u;

		public const int SkeletonCharId_Size = 4;
	}

	[CollectionObjectField(false, true, false, true, false)]
	private int _id;

	[CollectionObjectField(false, true, false, false, false)]
	private Location _location;

	[CollectionObjectField(false, true, false, false, false)]
	private sbyte _level;

	[CollectionObjectField(false, true, false, false, false)]
	private short _durability;

	[CollectionObjectField(false, true, false, false, false)]
	private Inventory _inventory;

	[CollectionObjectField(false, true, false, false, false)]
	private ResourceInts _resources;

	[CollectionObjectField(false, true, false, false, false)]
	private int _skeletonCharId;

	public const int FixedSize = 47;

	public const int DynamicCount = 1;

	private static readonly ushort[] ArchiveFieldIds = new ushort[7] { 0, 1, 2, 3, 5, 6, 4 };

	private static readonly int[] FixedArchiveFieldSizes = new int[6] { 4, 4, 1, 2, 32, 4 };

	public Grave(DataContext context, Character character, Location location, sbyte level)
	{
		_id = character.GetId();
		_location = location;
		_level = level;
		_durability = GlobalConfig.Instance.GraveDurabilities[_level];
		if (character.GetCreatingType() == 1)
		{
			_inventory = character.GetInventory();
			foreach (ItemKey itemKey in _inventory.Items.Keys)
			{
				ItemBase item = DomainManager.Item.GetBaseItem(itemKey);
				item.RemoveOwner(ItemOwnerType.CharacterInventory, _id);
				item.SetOwner(ItemOwnerType.Grave, _id);
			}
			if (!character.IsBoss())
			{
				PutEquipmentIntoInventory(character.GetEquipment(), _inventory);
			}
		}
		else
		{
			_inventory = character.GetInventory();
			foreach (ItemKey itemKey2 in _inventory.Items.Keys)
			{
				ItemBase item2 = DomainManager.Item.GetBaseItem(itemKey2);
				item2.RemoveOwner(ItemOwnerType.CharacterInventory, _id);
				item2.SetOwner(ItemOwnerType.Grave, _id);
			}
			character.SetInventory(new Inventory(), context);
		}
		RemoveEatingItems(context, ref character.GetEatingItems());
		_resources = character.GetResources();
		_skeletonCharId = -1;
	}

	public void RemoveInventoryItem(DataContext context, ItemKey itemKey, int amount, bool deleteItem = false)
	{
		if (amount > 0)
		{
			DomainManager.Item.RemoveOwner(itemKey, ItemOwnerType.Grave, _id);
			_inventory.OfflineRemove(itemKey, amount);
			SetInventory(_inventory, context);
			if (deleteItem)
			{
				DomainManager.Item.RemoveItem(context, itemKey);
			}
		}
	}

	public static sbyte CalcGraveLevel(int moneyAvailable)
	{
		if (moneyAvailable < GlobalConfig.Instance.GraveLevelMoneyCosts[1])
		{
			return 0;
		}
		if (moneyAvailable < GlobalConfig.Instance.GraveLevelMoneyCosts[2])
		{
			return 1;
		}
		if (moneyAvailable < GlobalConfig.Instance.GraveLevelMoneyCosts[3])
		{
			return 2;
		}
		return 3;
	}

	private void PutEquipmentIntoInventory(ItemKey[] equipment, Inventory inventory)
	{
		for (int i = 0; i < 17; i++)
		{
			ItemKey itemKey = equipment[i];
			if (itemKey.IsValid())
			{
				EquipmentBase baseEquipment = DomainManager.Item.GetBaseEquipment(itemKey);
				baseEquipment.RemoveOwner(ItemOwnerType.CharacterEquipment, _id);
				baseEquipment.SetOwner(ItemOwnerType.Grave, _id);
				inventory.Items.Add(itemKey, 1);
			}
		}
	}

	private unsafe static void RemoveEatingItems(DataContext context, ref EatingItems eatingItems)
	{
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = (ItemKey)eatingItems.ItemKeys[i];
			if (itemKey.IsValid())
			{
				DomainManager.Item.RemoveItem(context, itemKey);
			}
		}
	}

	public override string ToString()
	{
		DeadCharacter deadChar = DomainManager.Character.TryGetDeadCharacter(_id);
		return (deadChar == null) ? _id.ToString() : $"{deadChar}({_id})";
	}

	public int GetId()
	{
		return _id;
	}

	public Location GetLocation()
	{
		return _location;
	}

	public void SetLocation(Location location, DataContext context)
	{
		_location = location;
		SetModifiedAndInvalidateInfluencedCache(1, context);
	}

	public sbyte GetLevel()
	{
		return _level;
	}

	public void SetLevel(sbyte level, DataContext context)
	{
		_level = level;
		SetModifiedAndInvalidateInfluencedCache(2, context);
	}

	public short GetDurability()
	{
		return _durability;
	}

	public void SetDurability(short durability, DataContext context)
	{
		_durability = durability;
		SetModifiedAndInvalidateInfluencedCache(3, context);
	}

	public Inventory GetInventory()
	{
		return _inventory;
	}

	public void SetInventory(Inventory inventory, DataContext context)
	{
		_inventory = inventory;
		SetModifiedAndInvalidateInfluencedCache(4, context);
	}

	public ref ResourceInts GetResources()
	{
		return ref _resources;
	}

	public void SetResources(ref ResourceInts resources, DataContext context)
	{
		_resources = resources;
		SetModifiedAndInvalidateInfluencedCache(5, context);
	}

	public int GetSkeletonCharId()
	{
		return _skeletonCharId;
	}

	public void SetSkeletonCharId(int skeletonCharId, DataContext context)
	{
		_skeletonCharId = skeletonCharId;
		SetModifiedAndInvalidateInfluencedCache(6, context);
	}

	public Grave()
	{
		_inventory = new Inventory();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return 4 + ArchiveFieldIds.Length * 2 + 4 + FixedArchiveFieldSizes.Length * 4 + GetSerializedSizeWithoutHeader();
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		int length = (*(int*)pCurrData = ArchiveFieldIds.Length);
		pCurrData += 4;
		int fieldIdContentSize = length * 2;
		fixed (ushort* archiveFieldIds = ArchiveFieldIds)
		{
			void* pFieldId = archiveFieldIds;
			Buffer.MemoryCopy(pFieldId, pCurrData, fieldIdContentSize, fieldIdContentSize);
		}
		pCurrData += fieldIdContentSize;
		int fixedFieldSizesLength = (*(int*)pCurrData = FixedArchiveFieldSizes.Length);
		pCurrData += 4;
		int fieldSizeContentSize = fixedFieldSizesLength * 4;
		fixed (int* fixedArchiveFieldSizes = FixedArchiveFieldSizes)
		{
			void* pFieldSize = fixedArchiveFieldSizes;
			Buffer.MemoryCopy(pFieldSize, pCurrData, fieldSizeContentSize, fieldSizeContentSize);
		}
		pCurrData += fieldSizeContentSize;
		pCurrData += SerializeWithoutHeader(pCurrData);
		return (int)(pCurrData - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		int length = *(int*)pCurrData;
		pCurrData += 4;
		int fieldIdContentSize = length * 2;
		ushort[] fieldIds = new ushort[length];
		fixed (ushort* ptr = fieldIds)
		{
			void* pFieldId = ptr;
			Buffer.MemoryCopy(pCurrData, pFieldId, fieldIdContentSize, fieldIdContentSize);
		}
		pCurrData += fieldIdContentSize;
		int fixedFieldSizesLength = *(int*)pCurrData;
		pCurrData += 4;
		int fieldSizeContentSize = fixedFieldSizesLength * 4;
		int[] fieldSizes = new int[fixedFieldSizesLength];
		fixed (int* ptr2 = fieldSizes)
		{
			void* pFieldSize = ptr2;
			Buffer.MemoryCopy(pCurrData, pFieldSize, fieldSizeContentSize, fieldSizeContentSize);
		}
		pCurrData += fieldSizeContentSize;
		pCurrData += DeserializeWithFieldIds(pCurrData, fieldIds, fieldSizes);
		return (int)(pCurrData - pData);
	}

	public override int GetSerializedSizeWithoutHeader()
	{
		int totalSize = 51;
		int dataSize = _inventory.GetSerializedSize();
		return totalSize + dataSize;
	}

	public unsafe override int SerializeWithoutHeader(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = _id;
		pCurrData += 4;
		pCurrData += _location.Serialize(pCurrData);
		*pCurrData = (byte)_level;
		pCurrData++;
		*(short*)pCurrData = _durability;
		pCurrData += 2;
		pCurrData += _resources.Serialize(pCurrData);
		*(int*)pCurrData = _skeletonCharId;
		pCurrData += 4;
		byte* pBegin = pCurrData;
		pCurrData += 4;
		pCurrData += _inventory.Serialize(pCurrData);
		int fieldSize = (int)(pCurrData - pBegin - 4);
		if (fieldSize > 4194304)
		{
			throw new Exception($"Size of field {"_inventory"} must be less than {4096}KB");
		}
		*(int*)pBegin = fieldSize;
		return (int)(pCurrData - pData);
	}

	public unsafe override int DeserializeWithFieldIds(byte* pData, ushort[] fieldIds, int[] fixedFieldSizes)
	{
		byte* pCurrData = pData;
		for (int fieldIndex = 0; fieldIndex < fieldIds.Length; fieldIndex++)
		{
			switch (fieldIds[fieldIndex])
			{
			case 0:
				_id = *(int*)pCurrData;
				pCurrData += 4;
				continue;
			case 1:
				pCurrData += _location.Deserialize(pCurrData);
				continue;
			case 2:
				_level = (sbyte)(*pCurrData);
				pCurrData++;
				continue;
			case 3:
				_durability = *(short*)pCurrData;
				pCurrData += 2;
				continue;
			case 5:
				pCurrData += _resources.Deserialize(pCurrData);
				continue;
			case 6:
				_skeletonCharId = *(int*)pCurrData;
				pCurrData += 4;
				continue;
			case 4:
				pCurrData += 4;
				pCurrData += _inventory.Deserialize(pCurrData);
				continue;
			}
			if (fieldIndex < fixedFieldSizes.Length)
			{
				int fieldSize = fixedFieldSizes[fieldIndex];
				pCurrData += fieldSize;
			}
			else
			{
				int fieldSize2 = *(int*)pCurrData;
				pCurrData += 4;
				pCurrData += fieldSize2;
			}
		}
		return (int)(pCurrData - pData);
	}
}
