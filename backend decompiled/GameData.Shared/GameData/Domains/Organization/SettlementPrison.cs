using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Organization;

/// <summary>
/// 监牢数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class SettlementPrison : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort LastBreakInDate = 0;

		public const ushort Prisoners = 1;

		public const ushort Bounties = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "LastBreakInDate", "Prisoners", "Bounties" };
	}

	/// <summary>
	/// 上次劫狱时间
	/// </summary>
	[SerializableGameDataField]
	public int LastBreakInDate;

	/// <summary>
	/// 关押的角色集合
	/// </summary>
	[SerializableGameDataField]
	public List<SettlementPrisoner> Prisoners;

	/// <summary>
	/// 悬赏的角色集合 (仅包含存档的犯罪记录)
	/// </summary>
	[SerializableGameDataField]
	public List<SettlementBounty> Bounties;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SettlementPrison()
	{
		LastBreakInDate = int.MinValue;
		Prisoners = new List<SettlementPrisoner>();
		Bounties = new List<SettlementBounty>();
	}

	/// <summary>
	/// 获取囚犯
	/// </summary>
	/// <param name="charId"></param>
	/// <returns></returns>
	public SettlementPrisoner GetPrisoner(int charId)
	{
		for (int i = Prisoners.Count - 1; i >= 0; i--)
		{
			SettlementPrisoner prisoner = Prisoners[i];
			if (prisoner.CharId == charId)
			{
				return prisoner;
			}
		}
		return null;
	}

	/// <summary>
	/// 获取赏金
	/// </summary>
	/// <param name="charId"></param>
	/// <returns></returns>
	public SettlementBounty GetBounty(int charId)
	{
		for (int i = Bounties.Count - 1; i >= 0; i--)
		{
			SettlementBounty bounty = Bounties[i];
			if (bounty.CharId == charId)
			{
				return bounty;
			}
		}
		return null;
	}

	/// <summary>
	/// 离线移除囚犯并返回被移除的囚犯数据.
	/// 如果该囚犯不存在，则返回 null.
	/// </summary>
	/// <param name="charId"></param>
	/// <returns></returns>
	public SettlementPrisoner OfflineRemovePrisoner(int charId)
	{
		for (int i = Prisoners.Count - 1; i >= 0; i--)
		{
			SettlementPrisoner prisoner = Prisoners[i];
			if (prisoner.CharId == charId)
			{
				Prisoners.RemoveAt(i);
				return prisoner;
			}
		}
		return null;
	}

	/// <summary>
	/// 离线移除赏金并返回被移除的赏金数据.
	/// 如果该赏金不存在，则返回 null.
	/// </summary>
	public SettlementBounty OfflineRemoveBounty(int charId)
	{
		for (int i = Bounties.Count - 1; i >= 0; i--)
		{
			SettlementBounty bounty = Bounties[i];
			if (bounty.CharId == charId)
			{
				Bounties.RemoveAt(i);
				return bounty;
			}
		}
		return null;
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SettlementPrison(SettlementPrison other)
	{
		LastBreakInDate = other.LastBreakInDate;
		if (other.Prisoners != null)
		{
			List<SettlementPrisoner> item = other.Prisoners;
			int elementsCount = item.Count;
			Prisoners = new List<SettlementPrisoner>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				Prisoners.Add(new SettlementPrisoner(item[i]));
			}
		}
		else
		{
			Prisoners = null;
		}
		if (other.Bounties != null)
		{
			List<SettlementBounty> item2 = other.Bounties;
			int elementsCount2 = item2.Count;
			Bounties = new List<SettlementBounty>(elementsCount2);
			for (int j = 0; j < elementsCount2; j++)
			{
				Bounties.Add(new SettlementBounty(item2[j]));
			}
		}
		else
		{
			Bounties = null;
		}
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SettlementPrison other)
	{
		LastBreakInDate = other.LastBreakInDate;
		if (other.Prisoners != null)
		{
			List<SettlementPrisoner> item = other.Prisoners;
			int elementsCount = item.Count;
			Prisoners = new List<SettlementPrisoner>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				Prisoners.Add(new SettlementPrisoner(item[i]));
			}
		}
		else
		{
			Prisoners = null;
		}
		if (other.Bounties != null)
		{
			List<SettlementBounty> item2 = other.Bounties;
			int elementsCount2 = item2.Count;
			Bounties = new List<SettlementBounty>(elementsCount2);
			for (int j = 0; j < elementsCount2; j++)
			{
				Bounties.Add(new SettlementBounty(item2[j]));
			}
		}
		else
		{
			Bounties = null;
		}
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 6;
		if (Prisoners != null)
		{
			totalSize += 2;
			int elementsCount = Prisoners.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				SettlementPrisoner element = Prisoners[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (Bounties != null)
		{
			totalSize += 2;
			int elementsCount2 = Bounties.Count;
			for (int j = 0; j < elementsCount2; j++)
			{
				SettlementBounty element2 = Bounties[j];
				totalSize = ((element2 == null) ? (totalSize + 2) : (totalSize + (2 + element2.GetSerializedSize())));
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		*(int*)pCurrData = LastBreakInDate;
		pCurrData += 4;
		if (Prisoners != null)
		{
			int elementsCount = Prisoners.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				SettlementPrisoner element = Prisoners[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
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
		if (Bounties != null)
		{
			int elementsCount2 = Bounties.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				SettlementBounty element2 = Bounties[j];
				if (element2 != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int subDataSize2 = element2.Serialize(pCurrData);
					pCurrData += subDataSize2;
					Tester.Assert(subDataSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)subDataSize2;
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
			LastBreakInDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (Prisoners == null)
				{
					Prisoners = new List<SettlementPrisoner>(elementsCount);
				}
				else
				{
					Prisoners.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort num = *(ushort*)pCurrData;
					pCurrData += 2;
					if (num > 0)
					{
						SettlementPrisoner element = new SettlementPrisoner();
						pCurrData += element.Deserialize(pCurrData);
						Prisoners.Add(element);
					}
					else
					{
						Prisoners.Add(null);
					}
				}
			}
			else
			{
				Prisoners?.Clear();
			}
		}
		if (fieldCount > 2)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (Bounties == null)
				{
					Bounties = new List<SettlementBounty>(elementsCount2);
				}
				else
				{
					Bounties.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					ushort num2 = *(ushort*)pCurrData;
					pCurrData += 2;
					if (num2 > 0)
					{
						SettlementBounty element2 = new SettlementBounty();
						pCurrData += element2.Deserialize(pCurrData);
						Bounties.Add(element2);
					}
					else
					{
						Bounties.Add(null);
					}
				}
			}
			else
			{
				Bounties?.Clear();
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
