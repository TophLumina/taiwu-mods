using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Building;

[SerializableGameData]
public struct MakeResultStage : ISerializableGameData
{
	[SerializableGameDataField]
	public int LifeSkillRequiredAttainment;

	[SerializableGameDataField]
	public bool LifeSkillIsMeet;

	[SerializableGameDataField]
	private short _templateId;

	[SerializableGameDataField]
	public sbyte ItemType;

	[SerializableGameDataField]
	public List<short> TemplateIdList;

	[SerializableGameDataField]
	public List<short> SubTypeIdList;

	[SerializableGameDataField]
	public short SubTypeId;

	[SerializableGameDataField]
	public bool IsInit;

	public short TemplateId => _templateId;

	public MakeResultStage(int lifeSkillRequiredAttainment, bool lifeSkillIsMeet, sbyte itemType, short templateId, short subTypeId)
	{
		LifeSkillRequiredAttainment = lifeSkillRequiredAttainment;
		LifeSkillIsMeet = lifeSkillIsMeet;
		ItemType = itemType;
		_templateId = templateId;
		TemplateIdList = null;
		SubTypeIdList = null;
		SubTypeId = subTypeId;
		IsInit = true;
	}

	public MakeResultStage(int lifeSkillRequiredAttainment, bool lifeSkillIsMeet, sbyte itemType, List<short> templateIdList, List<short> subTypeIdList)
	{
		LifeSkillRequiredAttainment = lifeSkillRequiredAttainment;
		LifeSkillIsMeet = lifeSkillIsMeet;
		ItemType = itemType;
		TemplateIdList = templateIdList;
		SubTypeIdList = subTypeIdList;
		_templateId = -1;
		SubTypeId = -1;
		IsInit = true;
	}

	public (sbyte, short) GetGradeAndId(IRandomSource randomSource)
	{
		if (TemplateIdList != null && TemplateIdList.Count > 0)
		{
			_templateId = TemplateIdList.GetRandom(randomSource);
		}
		return (ItemTemplateHelper.GetGrade(ItemType, _templateId), _templateId);
	}

	public override string ToString()
	{
		string str = string.Empty;
		string itemName = string.Empty;
		if (TemplateIdList != null && TemplateIdList.Count > 0)
		{
			foreach (short id in TemplateIdList)
			{
				itemName = ItemTemplateHelper.GetName(ItemType, id);
				str = str + itemName + " ";
			}
		}
		else
		{
			itemName = ItemTemplateHelper.GetName(ItemType, _templateId);
			str = str + itemName + " ";
		}
		return str;
	}

	public MakeResultStage(MakeResultStage other)
	{
		LifeSkillRequiredAttainment = other.LifeSkillRequiredAttainment;
		LifeSkillIsMeet = other.LifeSkillIsMeet;
		_templateId = other._templateId;
		ItemType = other.ItemType;
		TemplateIdList = new List<short>(other.TemplateIdList);
		SubTypeIdList = new List<short>(other.SubTypeIdList);
		SubTypeId = other.SubTypeId;
		IsInit = other.IsInit;
	}

	public void Assign(MakeResultStage other)
	{
		LifeSkillRequiredAttainment = other.LifeSkillRequiredAttainment;
		LifeSkillIsMeet = other.LifeSkillIsMeet;
		_templateId = other._templateId;
		ItemType = other.ItemType;
		TemplateIdList = new List<short>(other.TemplateIdList);
		SubTypeIdList = new List<short>(other.SubTypeIdList);
		SubTypeId = other.SubTypeId;
		IsInit = other.IsInit;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 11;
		totalSize = ((TemplateIdList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * TemplateIdList.Count)));
		totalSize = ((SubTypeIdList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * SubTypeIdList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = LifeSkillRequiredAttainment;
		pCurrData += 4;
		*pCurrData = (LifeSkillIsMeet ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = _templateId;
		pCurrData += 2;
		*pCurrData = (byte)ItemType;
		pCurrData++;
		if (TemplateIdList != null)
		{
			int elementsCount = TemplateIdList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = TemplateIdList[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SubTypeIdList != null)
		{
			int elementsCount2 = SubTypeIdList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((short*)pCurrData)[j] = SubTypeIdList[j];
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = SubTypeId;
		pCurrData += 2;
		*pCurrData = (IsInit ? ((byte)1) : ((byte)0));
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
		LifeSkillRequiredAttainment = *(int*)pCurrData;
		pCurrData += 4;
		LifeSkillIsMeet = *pCurrData != 0;
		pCurrData++;
		_templateId = *(short*)pCurrData;
		pCurrData += 2;
		ItemType = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (TemplateIdList == null)
			{
				TemplateIdList = new List<short>(elementsCount);
			}
			else
			{
				TemplateIdList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				TemplateIdList.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			TemplateIdList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (SubTypeIdList == null)
			{
				SubTypeIdList = new List<short>(elementsCount2);
			}
			else
			{
				SubTypeIdList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				SubTypeIdList.Add(((short*)pCurrData)[j]);
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			SubTypeIdList?.Clear();
		}
		SubTypeId = *(short*)pCurrData;
		pCurrData += 2;
		IsInit = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
