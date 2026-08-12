using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Building;

/// <summary>
/// 后端检查制造条件的接口参数
/// </summary>
public struct MakeConditionArguments : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharId;

	[SerializableGameDataField]
	public BuildingBlockKey BuildingBlockKey;

	[SerializableGameDataField]
	public ItemKey ToolKey;

	[SerializableGameDataField]
	public ItemKey MaterialKey;

	/// <summary>
	/// 制造次数
	/// </summary>
	[SerializableGameDataField]
	public short MakeCount;

	/// <summary>
	/// 资源份数，不是资源本身
	/// </summary>
	[SerializableGameDataField]
	public ResourceInts ResourceCount;

	/// <summary>
	/// 一级分类，用于检查药品是否为主方
	/// </summary>
	[SerializableGameDataField]
	public short MakeItemTypeId;

	/// <summary>
	/// 二级分类，制造的实际配置
	/// </summary>
	[SerializableGameDataField]
	public short MakeItemSubTypeId;

	/// <summary>
	/// 是否手动选择二级分类，如果是会增加造诣要求
	/// </summary>
	[SerializableGameDataField]
	public bool IsManual;

	/// <summary>
	/// 是否精益求精
	/// </summary>
	[SerializableGameDataField]
	public bool IsPerfect;

	/// <summary>
	/// 指定食物产物
	/// </summary>
	[SerializableGameDataField]
	public short ManulFoodTemplateId;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 70;
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
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		pCurrData += BuildingBlockKey.Serialize(pCurrData);
		pCurrData += ToolKey.Serialize(pCurrData);
		pCurrData += MaterialKey.Serialize(pCurrData);
		*(short*)pCurrData = MakeCount;
		pCurrData += 2;
		pCurrData += ResourceCount.Serialize(pCurrData);
		*(short*)pCurrData = MakeItemTypeId;
		pCurrData += 2;
		*(short*)pCurrData = MakeItemSubTypeId;
		pCurrData += 2;
		*pCurrData = (IsManual ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsPerfect ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = ManulFoodTemplateId;
		pCurrData += 2;
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += BuildingBlockKey.Deserialize(pCurrData);
		pCurrData += ToolKey.Deserialize(pCurrData);
		pCurrData += MaterialKey.Deserialize(pCurrData);
		MakeCount = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += ResourceCount.Deserialize(pCurrData);
		MakeItemTypeId = *(short*)pCurrData;
		pCurrData += 2;
		MakeItemSubTypeId = *(short*)pCurrData;
		pCurrData += 2;
		IsManual = *pCurrData != 0;
		pCurrData++;
		IsPerfect = *pCurrData != 0;
		pCurrData++;
		ManulFoodTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
