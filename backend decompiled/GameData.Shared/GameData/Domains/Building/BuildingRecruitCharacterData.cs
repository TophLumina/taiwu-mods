using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

/// <summary>
/// 某个类型建筑的招募角色信息
/// </summary>
[SerializableGameData(IsExtensible = true, NotRestrictCollectionSerializedSize = true)]
public class BuildingRecruitCharacterData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CharacterData = 0;

		public const ushort BuildingBlockKey = 1;

		public const ushort RecruitInfoIndex = 2;

		public const ushort RecruitLevel = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "CharacterData", "BuildingBlockKey", "RecruitInfoIndex", "RecruitLevel" };
	}

	/// <summary>
	/// 招募角色
	/// </summary>
	[SerializableGameDataField]
	public RecruitCharacterData CharacterData;

	/// <summary>
	/// 建筑Block
	/// </summary>
	[SerializableGameDataField]
	public BuildingBlockKey BuildingBlockKey;

	/// <summary>
	/// 索引
	/// </summary>
	[SerializableGameDataField]
	public int RecruitInfoIndex;

	/// <summary>
	/// //招募的人才等级 first是等级，second是存在时间，超过三个月会消失
	/// </summary>
	[SerializableGameDataField]
	public IntPair RecruitLevel;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public BuildingRecruitCharacterData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public BuildingRecruitCharacterData(BuildingRecruitCharacterData other)
	{
		CharacterData = new RecruitCharacterData(other.CharacterData);
		BuildingBlockKey = other.BuildingBlockKey;
		RecruitInfoIndex = other.RecruitInfoIndex;
		RecruitLevel = other.RecruitLevel;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(BuildingRecruitCharacterData other)
	{
		CharacterData = new RecruitCharacterData(other.CharacterData);
		BuildingBlockKey = other.BuildingBlockKey;
		RecruitInfoIndex = other.RecruitInfoIndex;
		RecruitLevel = other.RecruitLevel;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 22;
		totalSize = ((CharacterData == null) ? (totalSize + 2) : (totalSize + (2 + CharacterData.GetSerializedSize())));
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
		*(short*)pCurrData = 4;
		pCurrData += 2;
		if (CharacterData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CharacterData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += BuildingBlockKey.Serialize(pCurrData);
		*(int*)pCurrData = RecruitInfoIndex;
		pCurrData += 4;
		pCurrData += RecruitLevel.Serialize(pCurrData);
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
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				if (CharacterData == null)
				{
					CharacterData = new RecruitCharacterData();
				}
				pCurrData += CharacterData.Deserialize(pCurrData);
			}
			else
			{
				CharacterData = null;
			}
		}
		if (num > 1)
		{
			pCurrData += BuildingBlockKey.Deserialize(pCurrData);
		}
		if (num > 2)
		{
			RecruitInfoIndex = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 3)
		{
			pCurrData += RecruitLevel.Deserialize(pCurrData);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
