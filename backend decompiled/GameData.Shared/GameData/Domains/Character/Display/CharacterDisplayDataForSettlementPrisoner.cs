using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 囚犯人物显示数据
/// </summary>
[AutoGenerateSerializableGameData]
public class CharacterDisplayDataForSettlementPrisoner : ISerializableGameData
{
	/// <summary>
	/// 监牢关押数据
	/// </summary>
	[SerializableGameDataField]
	public SettlementPrisoner SettlementPrisoner;

	/// <summary>
	/// 抵抗值
	/// </summary>
	[SerializableGameDataField]
	public int Resistance;

	/// <summary>
	/// 逃跑概率
	/// </summary>
	[SerializableGameDataField]
	public int EscapeRate;

	/// <summary>
	/// 定居点随机名称 ID.
	/// 小于 0 表示该定居点使用固定名称.
	/// </summary>
	[SerializableGameDataField]
	public short RandomNameId = -1;

	/// <summary>
	/// 是否已入魔
	/// </summary>
	[SerializableGameDataField]
	public bool CompletelyInfected;

	/// <summary>
	/// 是否是奇书持有者
	/// </summary>
	[SerializableGameDataField]
	public bool OwningBook;

	/// <summary>
	/// 人物关押数据，只复用其中的人物信息
	/// </summary>
	[SerializableGameDataField]
	public KidnapCharDisplayData KidnapCharDisplayData;

	/// <summary>
	/// Npc被关押的监牢等级.
	/// </summary>
	public PrisonType PrisonType
	{
		get
		{
			if (SettlementPrisoner.PunishmentSeverity == 0)
			{
				return PrisonType.Invalid;
			}
			if (SettlementPrisoner.PunishmentType == 40)
			{
				return PrisonType.Infected;
			}
			return (PrisonType)(KidnapCharDisplayData.OrganizationInfo.Grade / 3);
		}
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CharacterDisplayDataForSettlementPrisoner()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CharacterDisplayDataForSettlementPrisoner(CharacterDisplayDataForSettlementPrisoner other)
	{
		SettlementPrisoner = new SettlementPrisoner(other.SettlementPrisoner);
		Resistance = other.Resistance;
		EscapeRate = other.EscapeRate;
		RandomNameId = other.RandomNameId;
		CompletelyInfected = other.CompletelyInfected;
		OwningBook = other.OwningBook;
		KidnapCharDisplayData = new KidnapCharDisplayData(other.KidnapCharDisplayData);
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CharacterDisplayDataForSettlementPrisoner other)
	{
		SettlementPrisoner = new SettlementPrisoner(other.SettlementPrisoner);
		Resistance = other.Resistance;
		EscapeRate = other.EscapeRate;
		RandomNameId = other.RandomNameId;
		CompletelyInfected = other.CompletelyInfected;
		OwningBook = other.OwningBook;
		KidnapCharDisplayData = new KidnapCharDisplayData(other.KidnapCharDisplayData);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		totalSize = ((SettlementPrisoner == null) ? (totalSize + 2) : (totalSize + (2 + SettlementPrisoner.GetSerializedSize())));
		totalSize = ((KidnapCharDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + KidnapCharDisplayData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (SettlementPrisoner != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = SettlementPrisoner.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = Resistance;
		pCurrData += 4;
		*(int*)pCurrData = EscapeRate;
		pCurrData += 4;
		*(short*)pCurrData = RandomNameId;
		pCurrData += 2;
		*pCurrData = (CompletelyInfected ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (OwningBook ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (KidnapCharDisplayData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = KidnapCharDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
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
			SettlementPrisoner = new SettlementPrisoner();
			pCurrData += SettlementPrisoner.Deserialize(pCurrData);
		}
		else
		{
			SettlementPrisoner = null;
		}
		Resistance = *(int*)pCurrData;
		pCurrData += 4;
		EscapeRate = *(int*)pCurrData;
		pCurrData += 4;
		RandomNameId = *(short*)pCurrData;
		pCurrData += 2;
		CompletelyInfected = *pCurrData != 0;
		pCurrData++;
		OwningBook = *pCurrData != 0;
		pCurrData++;
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			KidnapCharDisplayData = new KidnapCharDisplayData();
			pCurrData += KidnapCharDisplayData.Deserialize(pCurrData);
		}
		else
		{
			KidnapCharDisplayData = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
