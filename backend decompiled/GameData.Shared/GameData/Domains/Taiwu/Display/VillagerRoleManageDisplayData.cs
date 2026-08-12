using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Display;

/// <summary>
/// 代表一个身份下身份管理界面需要显示的数据
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class VillagerRoleManageDisplayData : ISerializableGameData
{
	/// <summary>
	/// 对应身份id
	/// </summary>
	[SerializableGameDataField]
	public short RoleTemplateId;

	/// <summary>
	/// 当前可用身份席位
	/// </summary>
	[Obsolete]
	[SerializableGameDataField]
	public int AvailableSeats;

	/// <summary>
	/// 已设置的村民角色Id
	/// </summary>
	/// <returns></returns>
	[SerializableGameDataField]
	public List<int> CharacterIds;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize = ((CharacterIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * CharacterIds.Count)));
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
		*(int*)pCurrData = AvailableSeats;
		pCurrData += 4;
		if (CharacterIds != null)
		{
			int elementsCount = CharacterIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = CharacterIds[i];
			}
			pCurrData += 4 * elementsCount;
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
		AvailableSeats = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (CharacterIds == null)
			{
				CharacterIds = new List<int>(elementsCount);
			}
			else
			{
				CharacterIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterIds.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			CharacterIds?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
