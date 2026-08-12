using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Display;

/// <summary>
/// 代表一个身份下身份管理界面需要显示的数据
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class VillagerRoleTipsDisplayData : ISerializableGameData
{
	/// <summary>
	/// 对应身份id
	/// </summary>
	[SerializableGameDataField]
	public short RoleTemplateId;

	/// <summary>
	/// 需求的建筑类型，对应EBuildingBlockClass
	/// </summary>
	[SerializableGameDataField]
	public List<int> RelatedBuildingClassList;

	/// <summary>
	/// 具体建筑的加成列表
	/// first是建筑BuildingBlock的id，second是加成值
	/// </summary>
	[SerializableGameDataField]
	public List<IntPair> DetailList;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((RelatedBuildingClassList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * RelatedBuildingClassList.Count)));
		totalSize = ((DetailList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * DetailList.Count)));
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
		*(short*)pCurrData = RoleTemplateId;
		pCurrData += 2;
		if (RelatedBuildingClassList != null)
		{
			int elementsCount = RelatedBuildingClassList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = RelatedBuildingClassList[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (DetailList != null)
		{
			int elementsCount2 = DetailList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += DetailList[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
		RoleTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (RelatedBuildingClassList == null)
			{
				RelatedBuildingClassList = new List<int>(elementsCount);
			}
			else
			{
				RelatedBuildingClassList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				RelatedBuildingClassList.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			RelatedBuildingClassList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (DetailList == null)
			{
				DetailList = new List<IntPair>(elementsCount2);
			}
			else
			{
				DetailList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				IntPair element = default(IntPair);
				pCurrData += element.Deserialize(pCurrData);
				DetailList.Add(element);
			}
		}
		else
		{
			DetailList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
