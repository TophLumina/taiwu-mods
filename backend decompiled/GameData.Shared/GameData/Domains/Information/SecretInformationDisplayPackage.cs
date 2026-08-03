using System;
using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Information;

/// <summary>
/// 秘闻显示数据包
/// <para>避免了第二次获取人物数据的步骤, 同时减少了直接把该数据内置在 <see cref="T:GameData.Domains.Information.SecretInformationDisplayData" /> 中产生的冗余</para>
/// </summary>
public class SecretInformationDisplayPackage : ISerializableGameData
{
	/// <summary>
	/// 所属秘闻显示对象
	/// </summary>
	[SerializableGameDataField]
	public readonly List<SecretInformationDisplayData> SecretInformationDisplayDataList = new List<SecretInformationDisplayData>();

	/// <summary>
	/// 本包秘闻显示对象所需的角色数据
	/// </summary>
	[SerializableGameDataField]
	public readonly IDictionary<int, CharacterDisplayData> CharacterData = new Dictionary<int, CharacterDisplayData>();

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (SecretInformationDisplayDataList != null)
		{
			totalSize += 2;
			int elementsCount = SecretInformationDisplayDataList.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				SecretInformationDisplayData element = SecretInformationDisplayDataList[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (CharacterData != null)
		{
			totalSize += 2;
			foreach (KeyValuePair<int, CharacterDisplayData> element2 in CharacterData)
			{
				totalSize += 4;
				totalSize += 4;
				totalSize += element2.Value.GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (SecretInformationDisplayDataList != null)
		{
			int elementsCount = SecretInformationDisplayDataList.Count;
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				SecretInformationDisplayData element = SecretInformationDisplayDataList[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					*(ushort*)intPtr = (ushort)subDataSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CharacterData != null)
		{
			byte* displayDataBuffer = stackalloc byte[65535];
			int elementsCount2 = CharacterData.Count;
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			foreach (KeyValuePair<int, CharacterDisplayData> element2 in CharacterData)
			{
				*(int*)pCurrData = element2.Key;
				pCurrData += 4;
				int displayDataSize = (*(int*)pCurrData = element2.Value.Serialize(displayDataBuffer));
				pCurrData += 4;
				Buffer.MemoryCopy(displayDataBuffer, pCurrData, displayDataSize, displayDataSize);
				pCurrData += displayDataSize;
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

	/// <inheritdoc />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			SecretInformationDisplayDataList.Clear();
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					SecretInformationDisplayData element = new SecretInformationDisplayData();
					pCurrData += element.Deserialize(pCurrData);
					SecretInformationDisplayDataList.Add(element);
				}
				else
				{
					SecretInformationDisplayDataList.Add(null);
				}
			}
		}
		else
		{
			SecretInformationDisplayDataList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			CharacterData.Clear();
			for (int j = 0; j < elementsCount2; j++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				int displayDataSize = *(int*)pCurrData;
				pCurrData += 4;
				byte* pValue = pCurrData;
				CharacterDisplayData element2 = new CharacterDisplayData();
				int elementSize = element2.Deserialize(pCurrData);
				CharacterData.Add(key, element2);
				if (elementSize != displayDataSize)
				{
					AdaptableLog.Error(string.Format("{0} {1} size: {2}, should be: {3}", "Deserialize", "CharacterDisplayData", elementSize, displayDataSize));
				}
				pCurrData = pValue + displayDataSize;
			}
		}
		else
		{
			CharacterData?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
