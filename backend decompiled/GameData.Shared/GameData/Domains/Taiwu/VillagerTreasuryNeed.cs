using System.Collections.Generic;
using GameData.Domains.Character.Ai;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 太吾村民的公库需求数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class VillagerTreasuryNeed : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort PersonalNeeds = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "PersonalNeeds" };
	}

	/// <summary>
	/// 需求等待时间
	/// </summary>
	[SerializableGameDataField]
	public List<PersonalNeed> PersonalNeeds;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public VillagerTreasuryNeed()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public VillagerTreasuryNeed(VillagerTreasuryNeed other)
	{
		PersonalNeeds = ((other.PersonalNeeds == null) ? null : new List<PersonalNeed>(other.PersonalNeeds));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(VillagerTreasuryNeed other)
	{
		PersonalNeeds = ((other.PersonalNeeds == null) ? null : new List<PersonalNeed>(other.PersonalNeeds));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((PersonalNeeds == null) ? (totalSize + 2) : (totalSize + (2 + 8 * PersonalNeeds.Count)));
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
		*(short*)pCurrData = 1;
		pCurrData += 2;
		if (PersonalNeeds != null)
		{
			int elementsCount = PersonalNeeds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += PersonalNeeds[i].Serialize(pCurrData);
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (PersonalNeeds == null)
				{
					PersonalNeeds = new List<PersonalNeed>(elementsCount);
				}
				else
				{
					PersonalNeeds.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					PersonalNeed element = default(PersonalNeed);
					pCurrData += element.Deserialize(pCurrData);
					PersonalNeeds.Add(element);
				}
			}
			else
			{
				PersonalNeeds?.Clear();
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
