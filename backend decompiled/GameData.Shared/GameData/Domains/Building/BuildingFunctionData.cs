using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class BuildingFunctionData : ISerializableGameData
{
	/// <summary>
	/// 蛟池是否开启
	/// </summary>
	[SerializableGameDataField]
	public bool JiaoPoolOpen;

	/// <summary>
	/// 太吾当前在太吾村
	/// </summary>
	[SerializableGameDataField]
	public bool AtTaiwuVillage;

	/// <summary>
	/// 当前能否进行仓库存取
	/// </summary>
	[SerializableGameDataField]
	public bool CanTransfer;

	/// <summary>
	/// 练功房中紫竹化身的id
	/// </summary>
	[SerializableGameDataField]
	public List<sbyte> XiangshuIdInKungfuRoom;

	/// <summary>
	/// 练功房中可以练习的功法：太吾村练功房可以练所有学会的，门派只能练学会中属于当前门派的
	/// </summary>
	[SerializableGameDataField]
	public List<short> CanPracticeSkills;

	/// <summary>
	/// 太吾当前位置的定居点模板id
	/// </summary>
	[SerializableGameDataField]
	public short OrganizationTemplateIdOfTaiwuLocation;

	/// <summary>
	/// 金刚地主特殊互动按钮-化魂阁
	/// </summary>
	[SerializableGameDataField]
	public bool JingangFunctionOpen;

	/// <summary>
	/// 金刚地主互动按钮-高僧灵魂
	/// </summary>
	[SerializableGameDataField]
	public bool JingangMonkSoul;

	/// <summary>
	/// 伏龙特殊互动 身份和鸡
	/// </summary>
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
