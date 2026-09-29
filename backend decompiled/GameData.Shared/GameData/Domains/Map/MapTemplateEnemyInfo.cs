using System;
using Config;
using GameData.Serializer;

namespace GameData.Domains.Map;

[Serializable]
public struct MapTemplateEnemyInfo : ISerializableGameData, IEquatable<MapTemplateEnemyInfo>
{
	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public short BlockId;

	[SerializableGameDataField]
	public short SourceAdventureBlockId;

	[SerializableGameDataField]
	public sbyte Duration;

	[SerializableGameDataField]
	public sbyte SourceType;

	public static readonly MapTemplateEnemyInfo Invalid = new MapTemplateEnemyInfo(-1, -1, -1, -1);

	public static sbyte DefaultDuration(int taiwuConsummateLevel)
	{
		return (sbyte)Math.Clamp(taiwuConsummateLevel * GlobalConfig.Instance.GeneratedXiangshuMinionDurationFactor / 100 / 2, 1, 12);
	}

	public bool IsValid()
	{
		if (TemplateId >= 0)
		{
			return BlockId >= 0;
		}
		return false;
	}

	public static MapTemplateEnemyInfo CreateDefault(short templateId, short blockId, sbyte duration = -1)
	{
		return new MapTemplateEnemyInfo(templateId, blockId, 0, -1, duration);
	}

	public static MapTemplateEnemyInfo CreateFromEnemyNest(short templateId, short blockId, short nestBlockId)
	{
		return new MapTemplateEnemyInfo(templateId, blockId, 1, nestBlockId);
	}

	public static MapTemplateEnemyInfo CreateFromHeavenlyTree(short templateId, short blockId, short treeBlockId)
	{
		return new MapTemplateEnemyInfo(templateId, blockId, 2, treeBlockId);
	}

	public static MapTemplateEnemyInfo CreateFromXiangshuInfectedDemon(short templateId, short blockId)
	{
		return new MapTemplateEnemyInfo(templateId, blockId, 3, -1);
	}

	public MapTemplateEnemyInfo(short templateId, short blockId, sbyte sourceType, short sourceAdventureBlockId)
		: this(templateId, blockId, sourceType, sourceAdventureBlockId, -1)
	{
	}

	public MapTemplateEnemyInfo(short templateId, short blockId, sbyte sourceType, short sourceAdventureBlockId, sbyte duration)
	{
		TemplateId = templateId;
		BlockId = blockId;
		SourceAdventureBlockId = sourceAdventureBlockId;
		Duration = duration;
		SourceType = sourceType;
	}

	public override string ToString()
	{
		CharacterItem template = Config.Character.Instance[TemplateId];
		return $"{template.Surname}{template.GivenName}, Pos:{BlockId}, Source:{TemplateEnemySourceType.GetName(SourceType)}({SourceAdventureBlockId}), Duration:{Duration}";
	}

	public bool Equals(MapTemplateEnemyInfo other)
	{
		if (TemplateId == other.TemplateId && BlockId == other.BlockId && SourceType == other.SourceType && SourceAdventureBlockId == other.SourceAdventureBlockId)
		{
			return Duration == other.Duration;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is MapTemplateEnemyInfo other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(TemplateId, BlockId, SourceAdventureBlockId, Duration, SourceType);
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = TemplateId;
		byte* num = pData + 2;
		*(short*)num = BlockId;
		byte* num2 = num + 2;
		*(short*)num2 = SourceAdventureBlockId;
		byte* num3 = num2 + 2;
		*num3 = (byte)Duration;
		byte* num4 = num3 + 1;
		*num4 = (byte)SourceType;
		int totalSize = (int)(num4 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		BlockId = *(short*)pCurrData;
		pCurrData += 2;
		SourceAdventureBlockId = *(short*)pCurrData;
		pCurrData += 2;
		Duration = (sbyte)(*pCurrData);
		pCurrData++;
		SourceType = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
