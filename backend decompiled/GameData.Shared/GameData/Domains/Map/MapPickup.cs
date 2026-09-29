using Config;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

[SerializableGameData(IsExtensible = true)]
public class MapPickup : ISerializableGameData
{
	public enum EMapPickupState : sbyte
	{
		Unused,
		Used
	}

	public enum EMapPickupType : sbyte
	{
		Invalid = -1,
		Resource,
		Item,
		LoopEffect,
		ReadEffect,
		ExpBonus,
		DebtBonus,
		Event
	}

	private static class FieldIds
	{
		public const ushort Location = 0;

		public const ushort TemplateId = 1;

		public const ushort XiangshuLevel = 2;

		public const ushort State = 3;

		public const ushort InternalValue1 = 4;

		public const ushort VisibleByResource = 5;

		public const ushort Ignored = 6;

		public const ushort HasXiangshuMinion = 7;

		public const ushort Count = 8;

		public static readonly string[] FieldId2FieldName = new string[8] { "Location", "TemplateId", "XiangshuLevel", "State", "InternalValue1", "VisibleByResource", "Ignored", "HasXiangshuMinion" };
	}

	[SerializableGameDataField]
	private Location _location;

	[SerializableGameDataField]
	private short _templateId;

	[SerializableGameDataField]
	private sbyte _xiangshuLevel;

	[SerializableGameDataField]
	private sbyte _state;

	[SerializableGameDataField]
	private int _internalValue1;

	[SerializableGameDataField]
	private bool _visibleByResource;

	[SerializableGameDataField]
	private bool _ignored;

	[SerializableGameDataField]
	private bool _hasXiangshuMinion;

	public Location Location
	{
		get
		{
			return _location;
		}
		set
		{
			_location = value;
		}
	}

	public EMapPickupState State => (EMapPickupState)_state;

	public bool HasXiangshuMinion => _hasXiangshuMinion;

	public bool VisibleByResource
	{
		get
		{
			return _visibleByResource;
		}
		set
		{
			_visibleByResource = value;
		}
	}

	public bool Ignored
	{
		get
		{
			return _ignored;
		}
		set
		{
			_ignored = value;
		}
	}

	public short TemplateId => _templateId;

	public sbyte XiangshuLevel => _xiangshuLevel;

	public MapPickupsItem Template => MapPickups.Instance[_templateId];

	public EMapPickupType Type
	{
		get
		{
			MapPickupsItem template = Template;
			if (template.Type == EMapPickupsType.Event)
			{
				return EMapPickupType.Event;
			}
			if (template.LoopEffect)
			{
				return EMapPickupType.LoopEffect;
			}
			if (template.ReadEffect)
			{
				return EMapPickupType.ReadEffect;
			}
			if (template.IsExpBonus)
			{
				return EMapPickupType.ExpBonus;
			}
			if (template.IsDebtBonus)
			{
				return EMapPickupType.DebtBonus;
			}
			if (template.BonusCount.Length != 0)
			{
				return EMapPickupType.Resource;
			}
			if (template.ItemGrade.Length != 0)
			{
				return EMapPickupType.Item;
			}
			return EMapPickupType.Invalid;
		}
	}

	public bool IsEventType => Type == EMapPickupType.Event;

	public bool IsNormalType
	{
		get
		{
			EMapPickupType type = Type;
			bool flag = ((type == EMapPickupType.Invalid || type == EMapPickupType.Event) ? true : false);
			return !flag;
		}
	}

	public sbyte ResourceType
	{
		get
		{
			if (Type == EMapPickupType.Resource)
			{
				return _templateId switch
				{
					0 => 0, 
					1 => 1, 
					2 => 2, 
					3 => 3, 
					4 => 4, 
					5 => 5, 
					6 => 6, 
					7 => 7, 
					_ => -1, 
				};
			}
			return -1;
		}
	}

	public int ResourceCount
	{
		get
		{
			if (Type == EMapPickupType.Resource && ResourceType != -1)
			{
				return _internalValue1;
			}
			return -1;
		}
	}

	public int ExpCount
	{
		get
		{
			if (Type != EMapPickupType.ExpBonus)
			{
				return -1;
			}
			return _internalValue1;
		}
	}

	public int DebtCount
	{
		get
		{
			if (Type != EMapPickupType.DebtBonus)
			{
				return -1;
			}
			return _internalValue1;
		}
	}

	public sbyte ItemType
	{
		get
		{
			if (Type == EMapPickupType.Item)
			{
				return (sbyte)(_internalValue1 >> 16);
			}
			return -1;
		}
	}

	public short ItemTemplateId
	{
		get
		{
			if (Type == EMapPickupType.Item)
			{
				return (short)(_internalValue1 & 0xFFFF);
			}
			return -1;
		}
		set
		{
			if (Type == EMapPickupType.Item)
			{
				_internalValue1 = (_internalValue1 & -65536) | (ushort)value;
			}
			else
			{
				AdaptableLog.Warning("Error to set " + Location.ToString() + ", maybe lost " + value, appendWarningMessage: true);
			}
		}
	}

	public static MapPickup CreateResource(Location location, short templateId, int resourceCount, sbyte xiangshuProgress, bool hasXiangshuMinion)
	{
		Tester.Assert(MapPickups.Instance[templateId].BonusCount.Length != 0);
		Tester.Assert(resourceCount > 0);
		return new MapPickup
		{
			_location = location,
			_templateId = templateId,
			_internalValue1 = resourceCount,
			_state = 0,
			_xiangshuLevel = xiangshuProgress,
			_hasXiangshuMinion = hasXiangshuMinion
		};
	}

	public static MapPickup CreateItem(Location location, short templateId, sbyte itemType, short itemTemplateId, sbyte xiangshuProgress, bool hasXiangshuMinion)
	{
		Tester.Assert(MapPickups.Instance[templateId].ItemGrade.Length != 0);
		Tester.Assert(ItemTemplateHelper.CheckTemplateValid(itemType, itemTemplateId), $"invalid item: {itemType}, {itemTemplateId}");
		return new MapPickup
		{
			_location = location,
			_templateId = templateId,
			_internalValue1 = ((itemType << 16) | (itemTemplateId & 0xFFFF)),
			_state = 0,
			_xiangshuLevel = xiangshuProgress,
			_hasXiangshuMinion = hasXiangshuMinion
		};
	}

	public static MapPickup CreateLoopEffect(Location location, short templateId, sbyte xiangshuProgress, bool hasXiangshuMinion)
	{
		Tester.Assert(MapPickups.Instance[templateId].LoopEffect);
		return new MapPickup
		{
			_location = location,
			_templateId = templateId,
			_internalValue1 = 0,
			_state = 0,
			_xiangshuLevel = xiangshuProgress,
			_hasXiangshuMinion = hasXiangshuMinion
		};
	}

	public static MapPickup CreateReadEffect(Location location, short templateId, sbyte xiangshuProgress, bool hasXiangshuMinion)
	{
		Tester.Assert(MapPickups.Instance[templateId].ReadEffect);
		return new MapPickup
		{
			_location = location,
			_templateId = templateId,
			_internalValue1 = 0,
			_state = 0,
			_xiangshuLevel = xiangshuProgress,
			_hasXiangshuMinion = hasXiangshuMinion
		};
	}

	public static MapPickup CreateExpBonus(Location location, short templateId, int expCount, sbyte xiangshuProgress, bool hasXiangshuMinion)
	{
		Tester.Assert(MapPickups.Instance[templateId].IsExpBonus);
		return new MapPickup
		{
			_location = location,
			_templateId = templateId,
			_internalValue1 = expCount,
			_state = 0,
			_xiangshuLevel = xiangshuProgress,
			_hasXiangshuMinion = hasXiangshuMinion
		};
	}

	public static MapPickup CreateDebtBonus(Location location, short templateId, int debtCount, sbyte xiangshuProgress, bool hasXiangshuMinion)
	{
		Tester.Assert(MapPickups.Instance[templateId].IsDebtBonus);
		return new MapPickup
		{
			_location = location,
			_templateId = templateId,
			_internalValue1 = debtCount,
			_state = 0,
			_xiangshuLevel = xiangshuProgress,
			_hasXiangshuMinion = hasXiangshuMinion
		};
	}

	public void SetAsUsed()
	{
		_state = 1;
	}

	public MapPickup()
	{
	}

	public MapPickup(MapPickup other)
	{
		_location = other._location;
		_templateId = other._templateId;
		_xiangshuLevel = other._xiangshuLevel;
		_state = other._state;
		_internalValue1 = other._internalValue1;
		_visibleByResource = other._visibleByResource;
		_ignored = other._ignored;
		_hasXiangshuMinion = other._hasXiangshuMinion;
	}

	public void Assign(MapPickup other)
	{
		_location = other._location;
		_templateId = other._templateId;
		_xiangshuLevel = other._xiangshuLevel;
		_state = other._state;
		_internalValue1 = other._internalValue1;
		_visibleByResource = other._visibleByResource;
		_ignored = other._ignored;
		_hasXiangshuMinion = other._hasXiangshuMinion;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 17;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 8;
		pCurrData += 2;
		pCurrData += _location.Serialize(pCurrData);
		*(short*)pCurrData = _templateId;
		pCurrData += 2;
		*pCurrData = (byte)_xiangshuLevel;
		pCurrData++;
		*pCurrData = (byte)_state;
		pCurrData++;
		*(int*)pCurrData = _internalValue1;
		pCurrData += 4;
		*pCurrData = (_visibleByResource ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (_ignored ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (_hasXiangshuMinion ? ((byte)1) : ((byte)0));
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			pCurrData += _location.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			_templateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 2)
		{
			_xiangshuLevel = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 3)
		{
			_state = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 4)
		{
			_internalValue1 = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 5)
		{
			_visibleByResource = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 6)
		{
			_ignored = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 7)
		{
			_hasXiangshuMinion = *pCurrData != 0;
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
