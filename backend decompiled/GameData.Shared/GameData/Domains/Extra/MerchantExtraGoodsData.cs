using System.Collections.Generic;
using System.Linq;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Extra;

[AutoGenerateSerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class MerchantExtraGoodsData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort NormalExtraGoods = 0;

		public const ushort CapitalistSkillExtraGoods = 1;

		public const ushort SeasonExtraGoods = 2;

		public const ushort SeasonTemplateId = 3;

		public const ushort SolarTermTemplateIdList = 4;

		public const ushort SolarTermExtraGoods0 = 5;

		public const ushort SolarTermExtraGoods1 = 6;

		public const ushort Count = 7;

		public static readonly string[] FieldId2FieldName = new string[7] { "NormalExtraGoods", "CapitalistSkillExtraGoods", "SeasonExtraGoods", "SeasonTemplateId", "SolarTermTemplateIdList", "SolarTermExtraGoods0", "SolarTermExtraGoods1" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public List<MerchantExtraGoodsItem> NormalExtraGoods = new List<MerchantExtraGoodsItem>();

	[SerializableGameDataField(FieldIndex = 1)]
	public List<MerchantExtraGoodsItem> CapitalistSkillExtraGoods = new List<MerchantExtraGoodsItem>();

	[SerializableGameDataField(FieldIndex = 2)]
	public List<MerchantExtraGoodsItem> SeasonExtraGoods = new List<MerchantExtraGoodsItem>();

	[SerializableGameDataField(FieldIndex = 3)]
	public sbyte SeasonTemplateId = -1;

	[SerializableGameDataField(FieldIndex = 4)]
	public List<sbyte> SolarTermTemplateIdList = new List<sbyte>();

	[SerializableGameDataField(FieldIndex = 5)]
	public List<MerchantExtraGoodsItem> SolarTermExtraGoods0 = new List<MerchantExtraGoodsItem>();

	[SerializableGameDataField(FieldIndex = 6)]
	public List<MerchantExtraGoodsItem> SolarTermExtraGoods1 = new List<MerchantExtraGoodsItem>();

	public sbyte GetSolarTermTemplateId(int index)
	{
		return SolarTermTemplateIdList.GetOrDefault<sbyte>(index, -1);
	}

	public List<MerchantExtraGoodsItem> GetSolarTermExtraGoods(int index)
	{
		return index switch
		{
			0 => SolarTermExtraGoods0, 
			1 => SolarTermExtraGoods1, 
			_ => null, 
		};
	}

	public int GetSolarTermExtraGoodsIndex(int itemId)
	{
		for (int i = 0; i < SolarTermTemplateIdList.Count; i++)
		{
			if (GetSolarTermExtraGoods(i).Any((MerchantExtraGoodsItem item) => item.Id == itemId))
			{
				return i;
			}
		}
		return -1;
	}

	public bool HasSolarTermExtraGoods()
	{
		for (int i = 0; i < SolarTermTemplateIdList.Count; i++)
		{
			if (GetSolarTermExtraGoods(i).Count > 0)
			{
				return true;
			}
		}
		return false;
	}

	private bool Check(List<MerchantExtraGoodsItem> list, int id, out int findIndex)
	{
		findIndex = list.FindIndex((MerchantExtraGoodsItem d) => d.Id == id);
		return findIndex >= 0;
	}

	public bool Check(int id, out MerchantExtraGoodsType type)
	{
		if (Check(NormalExtraGoods, id, out var findIndex))
		{
			type = MerchantExtraGoodsType.Normal;
			return true;
		}
		if (Check(CapitalistSkillExtraGoods, id, out findIndex))
		{
			type = MerchantExtraGoodsType.Capitalist;
			return true;
		}
		if (Check(SeasonExtraGoods, id, out findIndex))
		{
			type = MerchantExtraGoodsType.Season;
			return true;
		}
		for (int i = 0; i < SolarTermTemplateIdList.Count; i++)
		{
			List<MerchantExtraGoodsItem> list = GetSolarTermExtraGoods(i);
			if (Check(list, id, out findIndex))
			{
				type = MerchantExtraGoodsType.SolarTerm;
				return true;
			}
		}
		type = MerchantExtraGoodsType.None;
		return false;
	}

	public void Remove(int id)
	{
		if (Check(NormalExtraGoods, id, out var findIndex))
		{
			NormalExtraGoods.RemoveAt(findIndex);
			return;
		}
		if (Check(CapitalistSkillExtraGoods, id, out findIndex))
		{
			CapitalistSkillExtraGoods.RemoveAt(findIndex);
			return;
		}
		if (Check(SeasonExtraGoods, id, out findIndex))
		{
			SeasonExtraGoods.RemoveAt(findIndex);
			return;
		}
		for (int i = 0; i < SolarTermTemplateIdList.Count; i++)
		{
			List<MerchantExtraGoodsItem> list = GetSolarTermExtraGoods(i);
			if (Check(list, id, out findIndex))
			{
				list.RemoveAt(findIndex);
			}
		}
	}

	public void Clear()
	{
		NormalExtraGoods.Clear();
		CapitalistSkillExtraGoods.Clear();
		SeasonExtraGoods.Clear();
		for (int i = 0; i < SolarTermTemplateIdList.Count; i++)
		{
			GetSolarTermExtraGoods(i).Clear();
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize = ((NormalExtraGoods == null) ? (totalSize + 2) : (totalSize + (2 + 8 * NormalExtraGoods.Count)));
		totalSize = ((CapitalistSkillExtraGoods == null) ? (totalSize + 2) : (totalSize + (2 + 8 * CapitalistSkillExtraGoods.Count)));
		totalSize = ((SeasonExtraGoods == null) ? (totalSize + 2) : (totalSize + (2 + 8 * SeasonExtraGoods.Count)));
		totalSize = ((SolarTermTemplateIdList == null) ? (totalSize + 2) : (totalSize + (2 + SolarTermTemplateIdList.Count)));
		totalSize = ((SolarTermExtraGoods0 == null) ? (totalSize + 2) : (totalSize + (2 + 8 * SolarTermExtraGoods0.Count)));
		totalSize = ((SolarTermExtraGoods1 == null) ? (totalSize + 2) : (totalSize + (2 + 8 * SolarTermExtraGoods1.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 7;
		pCurrData += 2;
		if (NormalExtraGoods != null)
		{
			int elementsCount = NormalExtraGoods.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += NormalExtraGoods[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CapitalistSkillExtraGoods != null)
		{
			int elementsCount2 = CapitalistSkillExtraGoods.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += CapitalistSkillExtraGoods[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SeasonExtraGoods != null)
		{
			int elementsCount3 = SeasonExtraGoods.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData += SeasonExtraGoods[k].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)SeasonTemplateId;
		pCurrData++;
		if (SolarTermTemplateIdList != null)
		{
			int elementsCount4 = SolarTermTemplateIdList.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				*pCurrData = (byte)SolarTermTemplateIdList[l];
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SolarTermExtraGoods0 != null)
		{
			int elementsCount5 = SolarTermExtraGoods0.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				pCurrData += SolarTermExtraGoods0[m].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SolarTermExtraGoods1 != null)
		{
			int elementsCount6 = SolarTermExtraGoods1.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				pCurrData += SolarTermExtraGoods1[n].Serialize(pCurrData);
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

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (NormalExtraGoods == null)
				{
					NormalExtraGoods = new List<MerchantExtraGoodsItem>();
				}
				else
				{
					NormalExtraGoods.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					MerchantExtraGoodsItem element = default(MerchantExtraGoodsItem);
					pCurrData += element.Deserialize(pCurrData);
					NormalExtraGoods.Add(element);
				}
			}
			else
			{
				NormalExtraGoods?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (CapitalistSkillExtraGoods == null)
				{
					CapitalistSkillExtraGoods = new List<MerchantExtraGoodsItem>();
				}
				else
				{
					CapitalistSkillExtraGoods.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					MerchantExtraGoodsItem element2 = default(MerchantExtraGoodsItem);
					pCurrData += element2.Deserialize(pCurrData);
					CapitalistSkillExtraGoods.Add(element2);
				}
			}
			else
			{
				CapitalistSkillExtraGoods?.Clear();
			}
		}
		if (fieldCount > 2)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (SeasonExtraGoods == null)
				{
					SeasonExtraGoods = new List<MerchantExtraGoodsItem>();
				}
				else
				{
					SeasonExtraGoods.Clear();
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					MerchantExtraGoodsItem element3 = default(MerchantExtraGoodsItem);
					pCurrData += element3.Deserialize(pCurrData);
					SeasonExtraGoods.Add(element3);
				}
			}
			else
			{
				SeasonExtraGoods?.Clear();
			}
		}
		if (fieldCount > 3)
		{
			SeasonTemplateId = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 4)
		{
			ushort elementsCount4 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount4 > 0)
			{
				if (SolarTermTemplateIdList == null)
				{
					SolarTermTemplateIdList = new List<sbyte>();
				}
				else
				{
					SolarTermTemplateIdList.Clear();
				}
				for (int l = 0; l < elementsCount4; l++)
				{
					sbyte element4 = (sbyte)(*pCurrData);
					pCurrData++;
					SolarTermTemplateIdList.Add(element4);
				}
			}
			else
			{
				SolarTermTemplateIdList?.Clear();
			}
		}
		if (fieldCount > 5)
		{
			ushort elementsCount5 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount5 > 0)
			{
				if (SolarTermExtraGoods0 == null)
				{
					SolarTermExtraGoods0 = new List<MerchantExtraGoodsItem>();
				}
				else
				{
					SolarTermExtraGoods0.Clear();
				}
				for (int m = 0; m < elementsCount5; m++)
				{
					MerchantExtraGoodsItem element5 = default(MerchantExtraGoodsItem);
					pCurrData += element5.Deserialize(pCurrData);
					SolarTermExtraGoods0.Add(element5);
				}
			}
			else
			{
				SolarTermExtraGoods0?.Clear();
			}
		}
		if (fieldCount > 6)
		{
			ushort elementsCount6 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount6 > 0)
			{
				if (SolarTermExtraGoods1 == null)
				{
					SolarTermExtraGoods1 = new List<MerchantExtraGoodsItem>();
				}
				else
				{
					SolarTermExtraGoods1.Clear();
				}
				for (int n = 0; n < elementsCount6; n++)
				{
					MerchantExtraGoodsItem element6 = default(MerchantExtraGoodsItem);
					pCurrData += element6.Deserialize(pCurrData);
					SolarTermExtraGoods1.Add(element6);
				}
			}
			else
			{
				SolarTermExtraGoods1?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
