using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class CharacterTableDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharId;

	[SerializableGameDataField]
	public byte CreatingType;

	[SerializableGameDataField]
	public NameRelatedData NameData;

	[SerializableGameDataField]
	public AvatarRelatedData AvatarData;

	[SerializableGameDataField]
	public bool IsDisplayData;

	[SerializableGameDataField]
	public Dictionary<int, int> ElementIntData;

	[SerializableGameDataField]
	public Dictionary<int, OrganizationInfo> ElementOrgData;

	[SerializableGameDataField]
	public Dictionary<int, CharacterTableLocationData> ElementLocationData;

	[SerializableGameDataField]
	public Dictionary<int, CharacterTableWorkData> ElementWorkData;

	public int GetInt(short type)
	{
		return ElementIntData[type];
	}

	public OrganizationInfo GetOrg(short type)
	{
		return ElementOrgData[type];
	}

	public CharacterTableLocationData GetLocation(short type)
	{
		return ElementLocationData[type];
	}

	public CharacterTableWorkData GetWork(short type)
	{
		return ElementWorkData[type];
	}

	public void SetInt(short type, int data)
	{
		if (ElementIntData == null)
		{
			ElementIntData = new Dictionary<int, int>();
		}
		ElementIntData[type] = data;
	}

	public void SetOrg(short type, OrganizationInfo data)
	{
		if (ElementOrgData == null)
		{
			ElementOrgData = new Dictionary<int, OrganizationInfo>();
		}
		ElementOrgData[type] = data;
	}

	public void SetLocation(short type, CharacterTableLocationData data)
	{
		if (ElementLocationData == null)
		{
			ElementLocationData = new Dictionary<int, CharacterTableLocationData>();
		}
		ElementLocationData[type] = data;
	}

	public void SetWork(short type, CharacterTableWorkData data)
	{
		if (ElementWorkData == null)
		{
			ElementWorkData = new Dictionary<int, CharacterTableWorkData>();
		}
		ElementWorkData[type] = data;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 38;
		totalSize = ((AvatarData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarData.GetSerializedSize())));
		totalSize += 4;
		if (ElementIntData != null)
		{
			foreach (KeyValuePair<int, int> elementIntDatum in ElementIntData)
			{
				_ = elementIntDatum;
				totalSize += 4;
				totalSize += 4;
			}
		}
		totalSize += 4;
		if (ElementOrgData != null)
		{
			foreach (KeyValuePair<int, OrganizationInfo> pair in ElementOrgData)
			{
				totalSize += 4;
				totalSize += pair.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (ElementLocationData != null)
		{
			foreach (KeyValuePair<int, CharacterTableLocationData> pair2 in ElementLocationData)
			{
				totalSize += 4;
				totalSize += pair2.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (ElementWorkData != null)
		{
			foreach (KeyValuePair<int, CharacterTableWorkData> pair3 in ElementWorkData)
			{
				totalSize += 4;
				totalSize += pair3.Value.GetSerializedSize();
			}
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		*pCurrData = CreatingType;
		pCurrData++;
		pCurrData += NameData.Serialize(pCurrData);
		if (AvatarData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = AvatarData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsDisplayData ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (ElementIntData != null)
		{
			*(int*)pCurrData = ElementIntData.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, int> pair in ElementIntData)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
				*(int*)pCurrData = pair.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (ElementOrgData != null)
		{
			*(int*)pCurrData = ElementOrgData.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, OrganizationInfo> pair2 in ElementOrgData)
			{
				*(int*)pCurrData = pair2.Key;
				pCurrData += 4;
				pCurrData += pair2.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (ElementLocationData != null)
		{
			*(int*)pCurrData = ElementLocationData.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, CharacterTableLocationData> pair3 in ElementLocationData)
			{
				*(int*)pCurrData = pair3.Key;
				pCurrData += 4;
				pCurrData += pair3.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (ElementWorkData != null)
		{
			*(int*)pCurrData = ElementWorkData.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, CharacterTableWorkData> pair4 in ElementWorkData)
			{
				*(int*)pCurrData = pair4.Key;
				pCurrData += 4;
				pCurrData += pair4.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		CreatingType = *pCurrData;
		pCurrData++;
		pCurrData += NameData.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			AvatarData = new AvatarRelatedData();
			pCurrData += AvatarData.Deserialize(pCurrData);
		}
		else
		{
			AvatarData = null;
		}
		IsDisplayData = *pCurrData != 0;
		pCurrData++;
		int ElementIntDataElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (ElementIntDataElementsCount > 0)
		{
			if (ElementIntData == null)
			{
				ElementIntData = new Dictionary<int, int>();
			}
			else
			{
				ElementIntData.Clear();
			}
			for (int i = 0; i < ElementIntDataElementsCount; i++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				int value = *(int*)pCurrData;
				pCurrData += 4;
				ElementIntData.Add(key, value);
			}
		}
		else
		{
			ElementIntData?.Clear();
		}
		int ElementOrgDataElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (ElementOrgDataElementsCount > 0)
		{
			if (ElementOrgData == null)
			{
				ElementOrgData = new Dictionary<int, OrganizationInfo>();
			}
			else
			{
				ElementOrgData.Clear();
			}
			for (int j = 0; j < ElementOrgDataElementsCount; j++)
			{
				int key2 = *(int*)pCurrData;
				pCurrData += 4;
				OrganizationInfo value2 = default(OrganizationInfo);
				pCurrData += value2.Deserialize(pCurrData);
				ElementOrgData.Add(key2, value2);
			}
		}
		else
		{
			ElementOrgData?.Clear();
		}
		int ElementLocationDataElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (ElementLocationDataElementsCount > 0)
		{
			if (ElementLocationData == null)
			{
				ElementLocationData = new Dictionary<int, CharacterTableLocationData>();
			}
			else
			{
				ElementLocationData.Clear();
			}
			for (int k = 0; k < ElementLocationDataElementsCount; k++)
			{
				int key3 = *(int*)pCurrData;
				pCurrData += 4;
				CharacterTableLocationData value3 = new CharacterTableLocationData();
				pCurrData += value3.Deserialize(pCurrData);
				ElementLocationData.Add(key3, value3);
			}
		}
		else
		{
			ElementLocationData?.Clear();
		}
		int ElementWorkDataElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (ElementWorkDataElementsCount > 0)
		{
			if (ElementWorkData == null)
			{
				ElementWorkData = new Dictionary<int, CharacterTableWorkData>();
			}
			else
			{
				ElementWorkData.Clear();
			}
			for (int l = 0; l < ElementWorkDataElementsCount; l++)
			{
				int key4 = *(int*)pCurrData;
				pCurrData += 4;
				CharacterTableWorkData value4 = default(CharacterTableWorkData);
				pCurrData += value4.Deserialize(pCurrData);
				ElementWorkData.Add(key4, value4);
			}
		}
		else
		{
			ElementWorkData?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
