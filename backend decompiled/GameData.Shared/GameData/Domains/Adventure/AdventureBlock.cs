using System.Text;
using GameData.Adventure;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Adventure;

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

	[SerializableGameDataField(FieldIndex = 0)]
	private AdventureBlockIndex _internalIndex;

	[SerializableGameDataField(FieldIndex = 1)]
	private int _internalStatusType;

	[SerializableGameDataField(FieldIndex = 2)]
	public string SpecialIcon;

	[SerializableGameDataField(FieldIndex = 3)]
	public string SpecialParticle;

	[SerializableGameDataField(FieldIndex = 4)]
	public bool InCloud;

	public int EntryPriority;

	public AdventureBlockIndex Index => _internalIndex;

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

	public AdventureBlock(AdventureBlockIndex index)
	{
		_internalIndex = index;
	}

	public bool ContainStatus(EAdventureBlockStatusType statusType)
	{
		return (StatusType & statusType) == statusType;
	}

	public AdventureBlock(AdventureBlockData data)
	{
		_internalIndex = data.Index;
		EntryPriority = data.EntryPriority;
		InCloud = data.InCloud;
	}

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

	public AdventureBlock()
	{
	}

	public AdventureBlock(AdventureBlock other)
	{
		_internalIndex = other._internalIndex;
		_internalStatusType = other._internalStatusType;
		SpecialIcon = other.SpecialIcon;
		SpecialParticle = other.SpecialParticle;
		InCloud = other.InCloud;
	}

	public void Assign(AdventureBlock other)
	{
		_internalIndex = other._internalIndex;
		_internalStatusType = other._internalStatusType;
		SpecialIcon = other.SpecialIcon;
		SpecialParticle = other.SpecialParticle;
		InCloud = other.InCloud;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

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
