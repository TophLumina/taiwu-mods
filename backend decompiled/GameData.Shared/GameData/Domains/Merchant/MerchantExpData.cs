using System;
using System.Linq;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Merchant;

[AutoGenerateSerializableGameData(NotRestrictCollectionSerializedSize = true, IsExtensible = true)]
public class MerchantExpData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort CharId = 0;

		public const ushort Favorabilitys = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "CharId", "Favorabilitys" };
	}

	/// <summary>
	/// 角色ID
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public int CharId;

	/// <summary>
	/// 商会好感
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public int[] Favorabilitys;

	public MerchantExpData(int charId, sbyte merchantLevel)
	{
		CharId = charId;
		Favorabilitys = new int[7];
		sbyte favorabilityLevel = GetFavorabilityLevelByMerchantLevel(merchantLevel);
		int favorability = GlobalConfig.Instance.MerchantFavorabilityMoneyRequirements[favorabilityLevel];
		for (int i = 0; i < 7; i++)
		{
			Favorabilitys[i] = favorability;
		}
	}

	/// <summary>
	/// 获取商店等级，0-5级，6级只有总部有
	/// 映射关系：商会好感=&gt;商会好感等级=&gt;商店等级
	/// </summary>
	/// <param name="merchantType"></param>
	/// <returns></returns>
	public sbyte GetMerchantLevel(sbyte merchantType)
	{
		sbyte favorabilityLevel = GetFavorabilityLevel(merchantType);
		sbyte level = 0;
		for (sbyte i = 0; i < GlobalConfig.MerchantLevelNeedFavorabilityLevel.Length; i++)
		{
			sbyte need = GlobalConfig.MerchantLevelNeedFavorabilityLevel[i];
			if (favorabilityLevel >= need)
			{
				level = i;
			}
		}
		return Math.Min(level, Convert.ToSByte(5));
	}

	public void SetFavorability(sbyte merchantType, int value)
	{
		int max = GlobalConfig.Instance.MerchantFavorabilityMoneyRequirements.Last();
		Favorabilitys[merchantType] = Math.Clamp(value, 0, max);
	}

	public int GetFavorability(sbyte merchantType)
	{
		return Favorabilitys[merchantType];
	}

	/// <summary>
	/// 获取好感等级，0-10级
	/// </summary>
	/// <param name="merchantType"></param>
	/// <returns></returns>
	public sbyte GetFavorabilityLevel(sbyte merchantType)
	{
		int favorability = Favorabilitys[merchantType];
		sbyte level = 0;
		for (sbyte i = 0; i < GlobalConfig.Instance.MerchantFavorabilityMoneyRequirements.Length; i++)
		{
			int req = GlobalConfig.Instance.MerchantFavorabilityMoneyRequirements[i];
			if (favorability >= req)
			{
				level = Convert.ToSByte(i + 1);
			}
		}
		return level;
	}

	private sbyte GetFavorabilityLevelByMerchantLevel(sbyte merchantLevel)
	{
		return GlobalConfig.MerchantLevelNeedFavorabilityLevel[merchantLevel];
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public MerchantExpData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public MerchantExpData(MerchantExpData other)
	{
		CharId = other.CharId;
		int[] item = other.Favorabilitys;
		int elementsCount = item.Length;
		Favorabilitys = new int[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			Favorabilitys[i] = item[i];
		}
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(MerchantExpData other)
	{
		CharId = other.CharId;
		int[] item = other.Favorabilitys;
		int elementsCount = item.Length;
		Favorabilitys = new int[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			Favorabilitys[i] = item[i];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize = ((Favorabilitys == null) ? (totalSize + 2) : (totalSize + (2 + 4 * Favorabilitys.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 2;
		pCurrData += 2;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		if (Favorabilitys != null)
		{
			int elementsCount = Favorabilitys.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(int*)pCurrData = Favorabilitys[i];
				pCurrData += 4;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			CharId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (Favorabilitys == null || Favorabilitys.Length != elementsCount)
				{
					Favorabilitys = new int[elementsCount];
				}
				for (int i = 0; i < elementsCount; i++)
				{
					Favorabilitys[i] = *(int*)pCurrData;
					pCurrData += 4;
				}
			}
			else
			{
				Favorabilitys = null;
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
