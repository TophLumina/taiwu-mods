using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 角色姓名法号和生死相关数据 (前端生成姓名法号所需要的数据)
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true)]
public struct NameAndLifeRelatedData : ISerializableGameData
{
	/// <summary>
	/// 角色姓名法号相关数据
	/// </summary>
	[SerializableGameDataField]
	public NameRelatedData NameRelatedData;

	/// <summary>
	/// 生死状态.
	/// <see cref="T:GameData.Domains.Character.LifeState" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte LifeState;

	/// <summary>
	/// 是否有坟墓
	/// 有坟墓的死人可以在经历页签跳转到死人经历
	/// </summary>
	[SerializableGameDataField]
	public bool HasTomb;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize += NameRelatedData.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += NameRelatedData.Serialize(pCurrData);
		*pCurrData = (byte)LifeState;
		pCurrData++;
		*pCurrData = (HasTomb ? ((byte)1) : ((byte)0));
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
		pCurrData += NameRelatedData.Deserialize(pCurrData);
		LifeState = (sbyte)(*pCurrData);
		pCurrData++;
		HasTomb = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
