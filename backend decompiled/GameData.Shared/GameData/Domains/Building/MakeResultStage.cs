using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Building;

/// <summary>
/// 制造结果的一个阶段的数据。目前共三个阶段：品级-1，原品级，品级+1
/// </summary>
[SerializableGameData]
public struct MakeResultStage : ISerializableGameData
{
	/// <summary>
	/// 本阶段的造诣需求
	/// </summary>
	[SerializableGameDataField]
	public int LifeSkillRequiredAttainment;

	/// <summary>
	/// 角色是否满足了本阶段造诣需求
	/// </summary>
	[SerializableGameDataField]
	public bool LifeSkillIsMeet;

	/// <summary>
	/// 物品模板ID
	/// </summary>
	[SerializableGameDataField]
	private short _templateId;

	/// <summary>
	/// 物品类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte ItemType;

	/// <summary>
	/// 未选二级分类时的物品模板
	/// </summary>
	[SerializableGameDataField]
	public List<short> TemplateIdList;

	/// <summary>
	/// 未选二级分类时，物品模板对应的制造子类模板列表，因为TIP要展示所有可能
	/// </summary>
	[SerializableGameDataField]
	public List<short> SubTypeIdList;

	/// <summary>
	/// 制造子类模板的ID，选择了二级分类时使用
	/// </summary>
	[SerializableGameDataField]
	public short SubTypeId;

	/// <summary>
	/// 是否已经完成初始化，用于判断结构体是否有效
	/// </summary>
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

	/// <summary>
	/// 获取物品品级与模板ID，如果是未选二级分类，返回列表的随机一项
	/// </summary>
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
