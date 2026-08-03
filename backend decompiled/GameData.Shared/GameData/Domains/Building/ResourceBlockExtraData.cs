using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class ResourceBlockExtraData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort BuildingBlockKey = 0;

		public const ushort Progress = 1;

		public const ushort Cooldown = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "BuildingBlockKey", "Progress", "Cooldown" };
	}

	/// <summary>
	/// 产业建筑Key
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public BuildingBlockKey BuildingBlockKey;

	/// <summary>
	/// 心材制造概率(分子)
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public int Progress;

	/// <summary>
	/// 心材制造冷却
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public int Cooldown;

	public ResourceBlockExtraData()
	{
		BuildingBlockKey = BuildingBlockKey.Invalid;
		Progress = 0;
		Cooldown = 0;
	}

	public ResourceBlockExtraData(BuildingBlockKey blockKey)
	{
		BuildingBlockKey = blockKey;
		Progress = 0;
		Cooldown = 0;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
		totalSize += BuildingBlockKey.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		pCurrData += BuildingBlockKey.Serialize(pCurrData);
		*(int*)pCurrData = Progress;
		pCurrData += 4;
		*(int*)pCurrData = Cooldown;
		pCurrData += 4;
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
			pCurrData += BuildingBlockKey.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			Progress = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			Cooldown = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
