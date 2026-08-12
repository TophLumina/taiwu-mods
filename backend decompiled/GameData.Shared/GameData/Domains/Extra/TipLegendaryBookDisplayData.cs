using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Extra;

[AutoGenerateSerializableGameData]
public class TipLegendaryBookDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public ItemKey WeaponSlot;

	[SerializableGameDataField]
	public ShortList SkillSlot;

	[SerializableGameDataField]
	public int BonusCountYin;

	[SerializableGameDataField]
	public int BonusCountYang;

	[SerializableGameDataField]
	public int BreakPlateCount;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public TipLegendaryBookDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public TipLegendaryBookDisplayData(TipLegendaryBookDisplayData other)
	{
		WeaponSlot = other.WeaponSlot;
		SkillSlot = other.SkillSlot;
		BonusCountYin = other.BonusCountYin;
		BonusCountYang = other.BonusCountYang;
		BreakPlateCount = other.BreakPlateCount;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(TipLegendaryBookDisplayData other)
	{
		WeaponSlot = other.WeaponSlot;
		SkillSlot = other.SkillSlot;
		BonusCountYin = other.BonusCountYin;
		BonusCountYang = other.BonusCountYang;
		BreakPlateCount = other.BreakPlateCount;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		totalSize += WeaponSlot.GetSerializedSize();
		totalSize += SkillSlot.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += WeaponSlot.Serialize(pCurrData);
		int fieldSize = SkillSlot.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*(int*)pCurrData = BonusCountYin;
		pCurrData += 4;
		*(int*)pCurrData = BonusCountYang;
		pCurrData += 4;
		*(int*)pCurrData = BreakPlateCount;
		pCurrData += 4;
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
		pCurrData += WeaponSlot.Deserialize(pCurrData);
		pCurrData += SkillSlot.Deserialize(pCurrData);
		BonusCountYin = *(int*)pCurrData;
		pCurrData += 4;
		BonusCountYang = *(int*)pCurrData;
		pCurrData += 4;
		BreakPlateCount = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
