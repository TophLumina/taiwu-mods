using Config;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

/// <summary>
/// 地图一个拾取物的数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class MapPickup : ISerializableGameData
{
	/// <summary>
	/// 拾取物的状态
	/// </summary>
	public enum EMapPickupState : sbyte
	{
		/// <summary>
		/// 未使用
		/// </summary>
		Unused,
		/// <summary>
		/// 已使用
		/// </summary>
		Used
	}

	/// <summary>
	/// 拾取物的类型
	/// </summary>
	public enum EMapPickupType : sbyte
	{
		/// <summary>
		/// 错误类型
		/// </summary>
		Invalid = -1,
		/// <summary>
		/// 资源
		/// </summary>
		Resource,
		/// <summary>
		/// 道具
		/// </summary>
		Item,
		/// <summary>
		/// 周天效果
		/// </summary>
		LoopEffect,
		/// <summary>
		/// 研读效果
		/// </summary>
		ReadEffect,
		/// <summary>
		/// 直接奖励历练
		/// </summary>
		ExpBonus,
		/// <summary>
		/// 直接奖励恩义
		/// </summary>
		DebtBonus,
		/// <summary>
		/// 事件
		/// </summary>
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

	/// <summary>
	/// 位置
	/// </summary>
	[SerializableGameDataField]
	private Location _location;

	/// <summary>
	/// 配置Id，对应<see cref="T:Config.MapPickupsItem" />
	/// </summary>
	[SerializableGameDataField]
	private short _templateId;

	/// <summary>
	/// 所属的相枢进度
	/// </summary>
	[SerializableGameDataField]
	private sbyte _xiangshuLevel;

	/// <summary>
	/// 状态 <see cref="T:GameData.Domains.Map.MapPickup.EMapPickupState" />
	/// </summary>
	[SerializableGameDataField]
	private sbyte _state;

	/// <summary>
	/// 如果是资源类型，存储资源的数量；
	/// 如果是物品类型，压缩存储物品类型和物品的TemplateId（高16位放sbyte，低16位放short）
	/// </summary>
	[SerializableGameDataField]
	private int _internalValue1;

	/// <summary>
	/// 根据过月时的地格资源计算的可见性
	/// 最终可见性要结合其他数据
	/// </summary>
	[SerializableGameDataField]
	private bool _visibleByResource;

	/// <summary>
	/// 暂时置之不理，不再显示。过月等时间可以去掉此状态。
	/// </summary>
	[SerializableGameDataField]
	private bool _ignored;

	/// <summary>
	/// 此拾取物是否需要打爪牙才能获取奖励
	/// </summary>
	[SerializableGameDataField]
	private bool _hasXiangshuMinion;

	/// <inheritdoc cref="F:GameData.Domains.Map.MapPickup._location" />
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

	/// <inheritdoc cref="F:GameData.Domains.Map.MapPickup._state" />
	public EMapPickupState State => (EMapPickupState)_state;

	/// <inheritdoc cref="F:GameData.Domains.Map.MapPickup._hasXiangshuMinion" />
	public bool HasXiangshuMinion => _hasXiangshuMinion;

	/// <inheritdoc cref="F:GameData.Domains.Map.MapPickup._visibleByResource" />
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

	/// <inheritdoc cref="F:GameData.Domains.Map.MapPickup._ignored" />
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

	/// <inheritdoc cref="F:GameData.Domains.Map.MapPickup._templateId" />
	public short TemplateId => _templateId;

	/// <inheritdoc cref="F:GameData.Domains.Map.MapPickup._xiangshuLevel" />
	public sbyte XiangshuLevel => _xiangshuLevel;

	/// <summary>
	/// 拾取物的配置
	/// </summary>
	public MapPickupsItem Template => MapPickups.Instance[_templateId];

	/// <summary>
	/// 拾取物的类型
	/// </summary>
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

	/// <summary>
	/// 是否是事件类型
	/// </summary>
	public bool IsEventType => Type == EMapPickupType.Event;

	/// <summary>
	/// 是否是一般类型
	/// </summary>
	public bool IsNormalType
	{
		get
		{
			EMapPickupType type = Type;
			bool flag = ((type == EMapPickupType.Invalid || type == EMapPickupType.Event) ? true : false);
			return !flag;
		}
	}

	/// <summary>
	/// 资源类拾取物的资源类型
	/// </summary>
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

	/// <summary>
	/// 资源类拾取物的资源数量
	/// </summary>
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

	/// <summary>
	/// 奖励的历练数值
	/// </summary>
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

	/// <summary>
	/// 奖励的恩义数值
	/// </summary>
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

	/// <summary>
	/// 道具类拾取物的道具类型
	/// </summary>
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

	/// <summary>
	/// 道具类拾取物的道具模板Id
	/// </summary>
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

	/// <summary>
	/// 从资源新建
	/// </summary>
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

	/// <summary>
	/// 从道具新建
	/// </summary>
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

	/// <summary>
	/// 创建周天效果的拾取物
	/// </summary>
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

	/// <summary>
	/// 创建研读效果的拾取物
	/// </summary>
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

	/// <summary>
	/// 生成一个历练奖励的拾取物
	/// </summary>
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

	/// <summary>
	/// 生成一个恩义奖励的拾取物
	/// </summary>
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

	/// <summary>
	/// 设置为已使用
	/// </summary>
	public void SetAsUsed()
	{
		_state = 1;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public MapPickup()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
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

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 17;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
