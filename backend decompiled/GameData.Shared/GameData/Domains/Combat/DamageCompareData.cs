using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 伤害计算数值对比显示数据
/// </summary>
[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class DamageCompareData : ISerializableGameData
{
	/// <summary>
	/// 单次攻击最大命中类型数
	/// </summary>
	private const int MaxHitType = 3;

	/// <summary>
	/// 是否玩家攻击
	/// </summary>
	[SerializableGameDataField]
	public bool IsAlly;

	/// <summary>
	/// 功法Id，小于零时为普攻
	/// </summary>
	[SerializableGameDataField]
	public short SkillId;

	/// <summary>
	/// 外伤攻击值
	/// </summary>
	[SerializableGameDataField]
	public int OuterAttackValue;

	/// <summary>
	/// 内伤攻击值
	/// </summary>
	[SerializableGameDataField]
	public int InnerAttackValue;

	/// <summary>
	/// 外伤防御值
	/// </summary>
	[SerializableGameDataField]
	public int OuterDefendValue;

	/// <summary>
	/// 内伤防御值
	/// </summary>
	[SerializableGameDataField]
	public int InnerDefendValue;

	/// <summary>
	/// 武器破甲
	/// </summary>
	[SerializableGameDataField]
	public int WeaponAttack;

	/// <summary>
	/// 武器坚韧
	/// </summary>
	[SerializableGameDataField]
	public int WeaponDefend;

	/// <summary>
	/// 防具破刃
	/// </summary>
	[SerializableGameDataField]
	public int ArmorAttack;

	/// <summary>
	/// 防具坚韧
	/// </summary>
	[SerializableGameDataField]
	public int ArmorDefend;

	/// <summary>
	/// 命中类型列表
	/// </summary>
	[SerializableGameDataField(ArrayElementsCount = 3)]
	public readonly sbyte[] HitType = new sbyte[3];

	/// <summary>
	/// 命中值列表
	/// </summary>
	[SerializableGameDataField(ArrayElementsCount = 3)]
	public readonly int[] HitValue = new int[3];

	/// <summary>
	/// 化解值列表
	/// </summary>
	[SerializableGameDataField(ArrayElementsCount = 3)]
	public readonly int[] AvoidValue = new int[3];

	public DamageCompareData()
	{
		Clear();
	}

	public void Clear()
	{
		SkillId = -1;
		OuterAttackValue = (InnerAttackValue = (OuterDefendValue = (InnerDefendValue = -1)));
		WeaponAttack = (WeaponDefend = (ArmorAttack = (ArmorDefend = -1)));
		for (int i = 0; i < 3; i++)
		{
			HitType[i] = -1;
			HitValue[i] = -1;
			AvoidValue[i] = -1;
		}
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 62;
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
		*pCurrData = (IsAlly ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = SkillId;
		pCurrData += 2;
		*(int*)pCurrData = OuterAttackValue;
		pCurrData += 4;
		*(int*)pCurrData = InnerAttackValue;
		pCurrData += 4;
		*(int*)pCurrData = OuterDefendValue;
		pCurrData += 4;
		*(int*)pCurrData = InnerDefendValue;
		pCurrData += 4;
		*(int*)pCurrData = WeaponAttack;
		pCurrData += 4;
		*(int*)pCurrData = WeaponDefend;
		pCurrData += 4;
		*(int*)pCurrData = ArmorAttack;
		pCurrData += 4;
		*(int*)pCurrData = ArmorDefend;
		pCurrData += 4;
		for (int i = 0; i < 3; i++)
		{
			pCurrData[i] = (byte)HitType[i];
		}
		pCurrData += 3;
		for (int j = 0; j < 3; j++)
		{
			((int*)pCurrData)[j] = HitValue[j];
		}
		pCurrData += 12;
		for (int k = 0; k < 3; k++)
		{
			((int*)pCurrData)[k] = AvoidValue[k];
		}
		pCurrData += 12;
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
		IsAlly = *pCurrData != 0;
		pCurrData++;
		SkillId = *(short*)pCurrData;
		pCurrData += 2;
		OuterAttackValue = *(int*)pCurrData;
		pCurrData += 4;
		InnerAttackValue = *(int*)pCurrData;
		pCurrData += 4;
		OuterDefendValue = *(int*)pCurrData;
		pCurrData += 4;
		InnerDefendValue = *(int*)pCurrData;
		pCurrData += 4;
		WeaponAttack = *(int*)pCurrData;
		pCurrData += 4;
		WeaponDefend = *(int*)pCurrData;
		pCurrData += 4;
		ArmorAttack = *(int*)pCurrData;
		pCurrData += 4;
		ArmorDefend = *(int*)pCurrData;
		pCurrData += 4;
		for (int i = 0; i < 3; i++)
		{
			HitType[i] = (sbyte)pCurrData[i];
		}
		pCurrData += 3;
		for (int j = 0; j < 3; j++)
		{
			HitValue[j] = ((int*)pCurrData)[j];
		}
		pCurrData += 12;
		for (int k = 0; k < 3; k++)
		{
			AvoidValue[k] = ((int*)pCurrData)[k];
		}
		pCurrData += 12;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
