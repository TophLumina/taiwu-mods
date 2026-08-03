using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Extra;

/// <summary>
/// 额外商品信息的集合
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class MerchantExtraGoodsData : ISerializableGameData
{
	/// <summary>
	/// 额外商品类型
	/// </summary>
	public enum ExtraGoodsType
	{
		None,
		/// <summary>
		/// 普通设定
		/// </summary>
		Normal,
		/// <summary>
		/// 富商志向
		/// </summary>
		Capitalist,
		/// <summary>
		/// 季节
		/// </summary>
		Season
	}

	private static class FieldIds
	{
		public const ushort NormalExtraGoods = 0;

		public const ushort CapitalistSkillExtraGoods = 1;

		public const ushort SeasonExtraGoods = 2;

		public const ushort SeasonTemplateId = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "NormalExtraGoods", "CapitalistSkillExtraGoods", "SeasonExtraGoods", "SeasonTemplateId" };
	}

	/// <summary>
	/// 普通额外商品信息的集合
	/// </summary>
	[SerializableGameDataField]
	public List<MerchantExtraGoodsItem> NormalExtraGoods = new List<MerchantExtraGoodsItem>();

	/// <summary>
	/// 富商技能的额外商品信息的集合
	/// </summary>
	[SerializableGameDataField]
	public List<MerchantExtraGoodsItem> CapitalistSkillExtraGoods = new List<MerchantExtraGoodsItem>();

	/// <summary>
	/// 季节额外商品信息的集合
	/// </summary>
	[SerializableGameDataField]
	public List<MerchantExtraGoodsItem> SeasonExtraGoods = new List<MerchantExtraGoodsItem>();

	/// <summary>
	/// 季节模板ID
	/// </summary>
	[SerializableGameDataField]
	public sbyte SeasonTemplateId = -1;

	/// <summary>
	/// 检查是否为额外商品
	/// </summary>
	private bool Check(List<MerchantExtraGoodsItem> list, int id, out int findIndex)
	{
		findIndex = list.FindIndex((MerchantExtraGoodsItem d) => d.Id == id);
		return findIndex >= 0;
	}

	/// <summary>
	/// 检查是否为额外商品
	/// </summary>
	public bool Check(int id, out ExtraGoodsType type)
	{
		if (Check(NormalExtraGoods, id, out var findIndex))
		{
			type = ExtraGoodsType.Normal;
			return true;
		}
		if (Check(CapitalistSkillExtraGoods, id, out findIndex))
		{
			type = ExtraGoodsType.Capitalist;
			return true;
		}
		if (Check(SeasonExtraGoods, id, out findIndex))
		{
			type = ExtraGoodsType.Season;
			return true;
		}
		type = ExtraGoodsType.None;
		return false;
	}

	/// <summary>
	/// 移除额外商品
	/// </summary>
	public void Remove(int id)
	{
		if (Check(NormalExtraGoods, id, out var findIndex))
		{
			NormalExtraGoods.RemoveAt(findIndex);
		}
		if (Check(CapitalistSkillExtraGoods, id, out findIndex))
		{
			CapitalistSkillExtraGoods.RemoveAt(findIndex);
		}
		if (Check(SeasonExtraGoods, id, out findIndex))
		{
			SeasonExtraGoods.RemoveAt(findIndex);
		}
	}

	/// <summary>
	/// 清除额外商品
	/// </summary>
	public void Clear()
	{
		NormalExtraGoods.Clear();
		CapitalistSkillExtraGoods.Clear();
		SeasonExtraGoods.Clear();
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public MerchantExtraGoodsData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public MerchantExtraGoodsData(MerchantExtraGoodsData other)
	{
		NormalExtraGoods = ((other.NormalExtraGoods == null) ? null : new List<MerchantExtraGoodsItem>(other.NormalExtraGoods));
		CapitalistSkillExtraGoods = ((other.CapitalistSkillExtraGoods == null) ? null : new List<MerchantExtraGoodsItem>(other.CapitalistSkillExtraGoods));
		SeasonExtraGoods = ((other.SeasonExtraGoods == null) ? null : new List<MerchantExtraGoodsItem>(other.SeasonExtraGoods));
		SeasonTemplateId = other.SeasonTemplateId;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(MerchantExtraGoodsData other)
	{
		NormalExtraGoods = ((other.NormalExtraGoods == null) ? null : new List<MerchantExtraGoodsItem>(other.NormalExtraGoods));
		CapitalistSkillExtraGoods = ((other.CapitalistSkillExtraGoods == null) ? null : new List<MerchantExtraGoodsItem>(other.CapitalistSkillExtraGoods));
		SeasonExtraGoods = ((other.SeasonExtraGoods == null) ? null : new List<MerchantExtraGoodsItem>(other.SeasonExtraGoods));
		SeasonTemplateId = other.SeasonTemplateId;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize = ((NormalExtraGoods == null) ? (totalSize + 2) : (totalSize + (2 + 8 * NormalExtraGoods.Count)));
		totalSize = ((CapitalistSkillExtraGoods == null) ? (totalSize + 2) : (totalSize + (2 + 8 * CapitalistSkillExtraGoods.Count)));
		totalSize = ((SeasonExtraGoods == null) ? (totalSize + 2) : (totalSize + (2 + 8 * SeasonExtraGoods.Count)));
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
		*(short*)pCurrData = 4;
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
					NormalExtraGoods = new List<MerchantExtraGoodsItem>(elementsCount);
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
					CapitalistSkillExtraGoods = new List<MerchantExtraGoodsItem>(elementsCount2);
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
					SeasonExtraGoods = new List<MerchantExtraGoodsItem>(elementsCount3);
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
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
