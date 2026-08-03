using GameData.Domains.Character;
using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 战斗结果快照（太吾状态相关）
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct CombatResultSnapshot : ISerializableGameData
{
	/// <summary>
	/// 历练值
	/// </summary>
	[SerializableGameDataField]
	public int Exp;

	/// <summary>
	/// 资源值
	/// </summary>
	[SerializableGameDataField]
	public ResourceInts Resource;

	/// <summary>
	/// 地区恩义
	/// </summary>
	[SerializableGameDataField]
	public int AreaSpiritualDebt;

	/// <summary>
	/// 最大可服食数量
	/// </summary>
	[SerializableGameDataField]
	public sbyte CanEatingMaxCount;

	/// <summary>
	/// 已服食物品数据
	/// </summary>
	[SerializableGameDataField]
	public EatingItems EatingItemList;

	/// <summary>
	/// 人物伤病数据
	/// </summary>
	[SerializableGameDataField]
	public Injuries Injuries;

	/// <summary>
	/// 人物中毒数据
	/// </summary>
	[SerializableGameDataField]
	public PoisonInts Poisons;

	/// <summary>
	/// 人物毒抗数据
	/// </summary>
	[SerializableGameDataField]
	public PoisonInts PoisonResists;

	/// <summary>
	/// 被额外设置为免疫的毒素类型配置
	/// </summary>
	[SerializableGameDataField]
	public byte ImmunePoisonExtra;

	/// <summary>
	/// 主要属性过月变化值
	/// </summary>
	[SerializableGameDataField]
	public MainAttributes MainAttribute;

	/// <summary>
	/// 内息紊乱
	/// </summary>
	[SerializableGameDataField]
	public short DisorderOfQi;

	/// <summary>
	/// 内息紊乱变化值
	/// </summary>
	[SerializableGameDataField]
	public short ChangeOfQiDisorder;

	/// <summary>
	/// 模板ID
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 显示年龄
	/// </summary>
	[SerializableGameDataField]
	public short DisplayAge;

	/// <summary>
	/// 实际年龄
	/// </summary>
	[SerializableGameDataField]
	public short ActualAge;

	/// <summary>
	/// 出生月份
	/// </summary>
	[SerializableGameDataField]
	public sbyte BirthMonth;

	/// <summary>
	/// 当前健康
	/// </summary>
	[SerializableGameDataField]
	public short Health;

	/// <summary>
	/// 剩余最大健康
	/// </summary>
	[SerializableGameDataField]
	public short LeftMaxHealth;

	/// <summary>
	/// 寿命值的每月变化量
	/// </summary>
	[SerializableGameDataField]
	public short HealthRecovery;

	/// <summary>
	/// 创建类型
	/// </summary>
	[SerializableGameDataField]
	public byte CreatingType;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 226;
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
		*(int*)pCurrData = Exp;
		pCurrData += 4;
		pCurrData += Resource.Serialize(pCurrData);
		*(int*)pCurrData = AreaSpiritualDebt;
		pCurrData += 4;
		*pCurrData = (byte)CanEatingMaxCount;
		pCurrData++;
		pCurrData += EatingItemList.Serialize(pCurrData);
		pCurrData += Injuries.Serialize(pCurrData);
		pCurrData += Poisons.Serialize(pCurrData);
		pCurrData += PoisonResists.Serialize(pCurrData);
		*pCurrData = ImmunePoisonExtra;
		pCurrData++;
		pCurrData += MainAttribute.Serialize(pCurrData);
		*(short*)pCurrData = DisorderOfQi;
		pCurrData += 2;
		*(short*)pCurrData = ChangeOfQiDisorder;
		pCurrData += 2;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*(short*)pCurrData = DisplayAge;
		pCurrData += 2;
		*(short*)pCurrData = ActualAge;
		pCurrData += 2;
		*pCurrData = (byte)BirthMonth;
		pCurrData++;
		*(short*)pCurrData = Health;
		pCurrData += 2;
		*(short*)pCurrData = LeftMaxHealth;
		pCurrData += 2;
		*(short*)pCurrData = HealthRecovery;
		pCurrData += 2;
		*pCurrData = CreatingType;
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
		Exp = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Resource.Deserialize(pCurrData);
		AreaSpiritualDebt = *(int*)pCurrData;
		pCurrData += 4;
		CanEatingMaxCount = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += EatingItemList.Deserialize(pCurrData);
		pCurrData += Injuries.Deserialize(pCurrData);
		pCurrData += Poisons.Deserialize(pCurrData);
		pCurrData += PoisonResists.Deserialize(pCurrData);
		ImmunePoisonExtra = *pCurrData;
		pCurrData++;
		pCurrData += MainAttribute.Deserialize(pCurrData);
		DisorderOfQi = *(short*)pCurrData;
		pCurrData += 2;
		ChangeOfQiDisorder = *(short*)pCurrData;
		pCurrData += 2;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		DisplayAge = *(short*)pCurrData;
		pCurrData += 2;
		ActualAge = *(short*)pCurrData;
		pCurrData += 2;
		BirthMonth = (sbyte)(*pCurrData);
		pCurrData++;
		Health = *(short*)pCurrData;
		pCurrData += 2;
		LeftMaxHealth = *(short*)pCurrData;
		pCurrData += 2;
		HealthRecovery = *(short*)pCurrData;
		pCurrData += 2;
		CreatingType = *pCurrData;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
