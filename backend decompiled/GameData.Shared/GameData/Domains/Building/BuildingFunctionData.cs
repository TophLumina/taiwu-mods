using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class BuildingFunctionData : ISerializableGameData
{
	[SerializableGameDataField]
	public bool JiaoPoolOpen;

	[SerializableGameDataField]
	public bool AtTaiwuVillage;

	[SerializableGameDataField]
	public bool CanTransfer;

	[SerializableGameDataField]
	public List<sbyte> XiangshuIdInKungfuRoom;

	[SerializableGameDataField]
	public List<short> CanPracticeSkills;

	[SerializableGameDataField]
	public short OrganizationTemplateIdOfTaiwuLocation;

	[SerializableGameDataField]
	public bool JingangFunctionOpen;

	[SerializableGameDataField]
	public bool JingangMonkSoul;

	[SerializableGameDataField]
	public bool FulongFunctionOpen;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		totalSize = ((XiangshuIdInKungfuRoom == null) ? (totalSize + 2) : (totalSize + (2 + XiangshuIdInKungfuRoom.Count)));
		totalSize = ((CanPracticeSkills == null) ? (totalSize + 2) : (totalSize + (2 + 2 * CanPracticeSkills.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (JiaoPoolOpen ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AtTaiwuVillage ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (CanTransfer ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (XiangshuIdInKungfuRoom != null)
		{
			int elementsCount = XiangshuIdInKungfuRoom.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*pCurrData = (byte)XiangshuIdInKungfuRoom[i];
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CanPracticeSkills != null)
		{
			int elementsCount2 = CanPracticeSkills.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*(short*)pCurrData = CanPracticeSkills[j];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = OrganizationTemplateIdOfTaiwuLocation;
		pCurrData += 2;
		*pCurrData = (JingangFunctionOpen ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (JingangMonkSoul ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (FulongFunctionOpen ? ((byte)1) : ((byte)0));
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
		JiaoPoolOpen = *pCurrData != 0;
		pCurrData++;
		AtTaiwuVillage = *pCurrData != 0;
		pCurrData++;
		CanTransfer = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (XiangshuIdInKungfuRoom == null)
			{
				XiangshuIdInKungfuRoom = new List<sbyte>();
			}
			else
			{
				XiangshuIdInKungfuRoom.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				sbyte element = (sbyte)(*pCurrData);
				pCurrData++;
				XiangshuIdInKungfuRoom.Add(element);
			}
		}
		else
		{
			XiangshuIdInKungfuRoom?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (CanPracticeSkills == null)
			{
				CanPracticeSkills = new List<short>();
			}
			else
			{
				CanPracticeSkills.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				short element2 = *(short*)pCurrData;
				pCurrData += 2;
				CanPracticeSkills.Add(element2);
			}
		}
		else
		{
			CanPracticeSkills?.Clear();
		}
		OrganizationTemplateIdOfTaiwuLocation = *(short*)pCurrData;
		pCurrData += 2;
		JingangFunctionOpen = *pCurrData != 0;
		pCurrData++;
		JingangMonkSoul = *pCurrData != 0;
		pCurrData++;
		FulongFunctionOpen = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
