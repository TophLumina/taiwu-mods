using System.Text;
using GameData.Adventure;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇地格
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class AdventureBlock : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort InternalIndex = 0;

		public const ushort InternalStatusType = 1;

		public const ushort SpecialIcon = 2;

		public const ushort SpecialParticle = 3;

		public const ushort InCloud = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "InternalIndex", "InternalStatusType", "SpecialIcon", "SpecialParticle", "InCloud" };
	}

	/// <summary>
	/// 地格位置
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	private AdventureBlockIndex _internalIndex;

	/// <summary>
	/// 用于序列化的类型
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	private int _internalStatusType;

	/// <summary>
	/// 地皮（覆盖 <see cref="P:GameData.Adventure.AdventureBlockData.Icon" />）
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public string SpecialIcon;

	/// <summary>
	/// 氛围特效
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	public string SpecialParticle;

	/// <summary>
	/// 被云雾笼罩
	/// </summary>
	[SerializableGameDataField(FieldIndex = 4)]
	public bool InCloud;

	/// <summary>
	/// 入口优先级，仅在后端使用
	/// </summary>
	public int EntryPriority;

	/// <summary>
	/// 索引
	/// </summary>
	public AdventureBlockIndex Index => _internalIndex;

	/// <summary>
	/// 类型
	/// </summary>
	private EAdventureBlockStatusType StatusType
	{
		get
		{
			return (EAdventureBlockStatusType)_internalStatusType;
		}
		set
		{
			_internalStatusType = (int)value;
		}
	}

	/// <summary>
	/// 基于位置构造奇遇地格
	/// </summary>
	public AdventureBlock(AdventureBlockIndex index)
	{
		_internalIndex = index;
	}

	/// <summary>
	/// 是否处于某个状态
	/// </summary>
	/// <param name="statusType"></param>
	/// <returns></returns>
	public bool ContainStatus(EAdventureBlockStatusType statusType)
	{
		return (StatusType & statusType) == statusType;
	}

	/// <summary>
	/// 基于数据构造奇遇地格
	/// </summary>
	public AdventureBlock(AdventureBlockData data)
	{
		_internalIndex = data.Index;
		EntryPriority = data.EntryPriority;
		InCloud = data.InCloud;
	}

	/// <summary>
	/// 更新状态信息
	/// </summary>
	/// <param name="bridge"></param>
	/// <param name="adventureId"></param>
	/// <param name="data"></param>
	public bool UpdateStatus(IAdventureDomainBridge bridge, int adventureId, AdventureBlockData data)
	{
		EAdventureBlockStatusType statusType = EAdventureBlockStatusType.None;
		if (data.BlockType.Contains(EAdventureBlockType.In) && bridge.Check(data.EnterCondition, adventureId, Index))
		{
			statusType |= EAdventureBlockStatusType.In;
		}
		if (data.BlockType.Contains(EAdventureBlockType.Out) && bridge.Check(data.ExitCondition, adventureId, Index))
		{
			statusType |= EAdventureBlockStatusType.Out;
		}
		if (bridge.Check(data.PassableCondition, adventureId, Index))
		{
			statusType |= EAdventureBlockStatusType.Passable;
		}
		if (statusType == StatusType)
		{
			return false;
		}
		StatusType = statusType;
		return true;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public AdventureBlock()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public AdventureBlock(AdventureBlock other)
	{
		_internalIndex = other._internalIndex;
		_internalStatusType = other._internalStatusType;
		SpecialIcon = other.SpecialIcon;
		SpecialParticle = other.SpecialParticle;
		InCloud = other.InCloud;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(AdventureBlock other)
	{
		_internalIndex = other._internalIndex;
		_internalStatusType = other._internalStatusType;
		SpecialIcon = other.SpecialIcon;
		SpecialParticle = other.SpecialParticle;
		InCloud = other.InCloud;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 7;
		totalSize += ((AdventureBlockIndexForSerialize)_internalIndex).GetSerializedSize();
		totalSize = ((SpecialIcon == null) ? (totalSize + 2) : (totalSize + (2 + 2 * SpecialIcon.Length)));
		totalSize = ((SpecialParticle == null) ? (totalSize + 2) : (totalSize + (2 + 2 * SpecialParticle.Length)));
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
		*(short*)pCurrData = 5;
		pCurrData += 2;
		int fieldSize = ((AdventureBlockIndexForSerialize)_internalIndex).Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*(int*)pCurrData = _internalStatusType;
		pCurrData += 4;
		if (SpecialIcon != null)
		{
			int elementsCount = SpecialIcon.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = SpecialIcon)
			{
				for (int i = 0; i < elementsCount; i++)
				{
					((short*)pCurrData)[i] = (short)pChar[i];
				}
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SpecialParticle != null)
		{
			int elementsCount2 = SpecialParticle.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			fixed (char* pChar2 = SpecialParticle)
			{
				for (int j = 0; j < elementsCount2; j++)
				{
					((short*)pCurrData)[j] = (short)pChar2[j];
				}
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (InCloud ? ((byte)1) : ((byte)0));
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
			AdventureBlockIndexForSerialize field = _internalIndex;
			pCurrData += field.Deserialize(pCurrData);
			_internalIndex = field;
		}
		if (num > 1)
		{
			_internalStatusType = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				int fieldSize = 2 * elementsCount;
				SpecialIcon = Encoding.Unicode.GetString(pCurrData, fieldSize);
				pCurrData += fieldSize;
			}
			else
			{
				SpecialIcon = null;
			}
		}
		if (num > 3)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				int fieldSize2 = 2 * elementsCount2;
				SpecialParticle = Encoding.Unicode.GetString(pCurrData, fieldSize2);
				pCurrData += fieldSize2;
			}
			else
			{
				SpecialParticle = null;
			}
		}
		if (num > 4)
		{
			InCloud = *pCurrData != 0;
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
