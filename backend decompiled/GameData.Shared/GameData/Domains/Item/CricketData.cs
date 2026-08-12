using GameData.Combat.Cricket;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Item;

/// <summary>
/// 蛐蛐显示数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class CricketData : ISerializableGameData
{
	/// <summary>
	/// 伤残
	/// 各种属性的损伤值. 属性索引: 0: 耐力, 1: 斗性, 2: 气势, 3: 角力, 4: 牙钳.
	/// </summary>
	[SerializableGameDataField]
	public short[] Injuries;

	/// <summary>
	/// 胜场
	/// </summary>
	[SerializableGameDataField]
	public short WinsCount;

	/// <summary>
	/// 败场
	/// </summary>
	[SerializableGameDataField]
	public short LossesCount;

	/// <summary>
	/// 最后强敌颜色
	/// </summary>
	[SerializableGameDataField]
	public short BestEnemyColorId;

	/// <summary>
	/// 最后强敌部件
	/// </summary>
	[SerializableGameDataField]
	public short BestEnemyPartId;

	/// <summary>
	/// 年龄进度
	/// </summary>
	[SerializableGameDataField]
	public int AgeProgress;

	/// <summary>
	/// 年龄上限
	/// </summary>
	[SerializableGameDataField]
	public short MaxAge;

	/// <summary>
	/// 是否神采非凡
	/// </summary>
	[SerializableGameDataField]
	public bool IsSmart;

	/// <summary>
	/// 是否已鉴别
	/// </summary>
	[SerializableGameDataField]
	public bool IsIdentified;

	/// <summary>
	/// 价值
	/// </summary>
	[SerializableGameDataField]
	public int CricketValue;

	/// <summary>
	/// 灵性值
	/// </summary>
	[SerializableGameDataField]
	public int Spirit;

	/// <summary>
	/// 灵性增加属性值
	/// </summary>
	[SerializableGameDataField]
	public CricketSpiritProperty SpiritAddProperties;

	/// <summary>
	/// 产地州域 <see cref="T:Config.MapState" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte OriginState;

	/// <summary>
	/// 自定义名字Id
	/// </summary>
	[SerializableGameDataField]
	public int NameId;

	/// <summary>
	/// 耐力伤残
	/// </summary>
	public short InjuryHp => Injuries[0];

	/// <summary>
	/// 斗性伤残
	/// </summary>
	public short InjurySp => Injuries[1];

	/// <summary>
	/// 气势伤残
	/// </summary>
	public short InjuryVigor => Injuries[2];

	/// <summary>
	/// 角力伤残
	/// </summary>
	public short InjuryStrength => Injuries[3];

	/// <summary>
	/// 牙钳伤残
	/// </summary>
	public short InjuryBite => Injuries[4];

	/// <summary>
	/// 年龄文本
	/// </summary>
	public string AgeStr => AgeProgress.ToQuotientRemainderString(GlobalConfig.Instance.CricketAgeProgressPerYear);

	/// <summary>
	/// 寿终正寝
	/// </summary>
	public bool NaturalDeath => AgeProgress >= MaxAge * GlobalConfig.Instance.CricketAgeProgressPerYear;

	/// <summary>
	/// 隐式转换为促织伤势数据
	/// </summary>
	public static implicit operator CricketInjury(CricketData data)
	{
		return new CricketInjury
		{
			Hp = data.InjuryHp,
			Sp = data.InjurySp,
			Vigor = data.InjuryVigor,
			Strength = data.InjuryStrength,
			Bite = data.InjuryBite
		};
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CricketData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CricketData(CricketData other)
	{
		short[] item = other.Injuries;
		int elementsCount = item.Length;
		Injuries = new short[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			Injuries[i] = item[i];
		}
		WinsCount = other.WinsCount;
		LossesCount = other.LossesCount;
		BestEnemyColorId = other.BestEnemyColorId;
		BestEnemyPartId = other.BestEnemyPartId;
		AgeProgress = other.AgeProgress;
		MaxAge = other.MaxAge;
		IsSmart = other.IsSmart;
		IsIdentified = other.IsIdentified;
		CricketValue = other.CricketValue;
		Spirit = other.Spirit;
		SpiritAddProperties = new CricketSpiritProperty(other.SpiritAddProperties);
		OriginState = other.OriginState;
		NameId = other.NameId;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CricketData other)
	{
		short[] item = other.Injuries;
		int elementsCount = item.Length;
		Injuries = new short[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			Injuries[i] = item[i];
		}
		WinsCount = other.WinsCount;
		LossesCount = other.LossesCount;
		BestEnemyColorId = other.BestEnemyColorId;
		BestEnemyPartId = other.BestEnemyPartId;
		AgeProgress = other.AgeProgress;
		MaxAge = other.MaxAge;
		IsSmart = other.IsSmart;
		IsIdentified = other.IsIdentified;
		CricketValue = other.CricketValue;
		Spirit = other.Spirit;
		SpiritAddProperties = new CricketSpiritProperty(other.SpiritAddProperties);
		OriginState = other.OriginState;
		NameId = other.NameId;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 29;
		totalSize = ((Injuries == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Injuries.Length)));
		totalSize = ((SpiritAddProperties == null) ? (totalSize + 2) : (totalSize + (2 + SpiritAddProperties.GetSerializedSize())));
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
		if (Injuries != null)
		{
			int elementsCount = Injuries.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = Injuries[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = WinsCount;
		pCurrData += 2;
		*(short*)pCurrData = LossesCount;
		pCurrData += 2;
		*(short*)pCurrData = BestEnemyColorId;
		pCurrData += 2;
		*(short*)pCurrData = BestEnemyPartId;
		pCurrData += 2;
		*(int*)pCurrData = AgeProgress;
		pCurrData += 4;
		*(short*)pCurrData = MaxAge;
		pCurrData += 2;
		*pCurrData = (IsSmart ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsIdentified ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = CricketValue;
		pCurrData += 4;
		*(int*)pCurrData = Spirit;
		pCurrData += 4;
		if (SpiritAddProperties != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = SpiritAddProperties.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)OriginState;
		pCurrData++;
		*(int*)pCurrData = NameId;
		pCurrData += 4;
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Injuries == null || Injuries.Length != elementsCount)
			{
				Injuries = new short[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				Injuries[i] = ((short*)pCurrData)[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			Injuries = null;
		}
		WinsCount = *(short*)pCurrData;
		pCurrData += 2;
		LossesCount = *(short*)pCurrData;
		pCurrData += 2;
		BestEnemyColorId = *(short*)pCurrData;
		pCurrData += 2;
		BestEnemyPartId = *(short*)pCurrData;
		pCurrData += 2;
		AgeProgress = *(int*)pCurrData;
		pCurrData += 4;
		MaxAge = *(short*)pCurrData;
		pCurrData += 2;
		IsSmart = *pCurrData != 0;
		pCurrData++;
		IsIdentified = *pCurrData != 0;
		pCurrData++;
		CricketValue = *(int*)pCurrData;
		pCurrData += 4;
		Spirit = *(int*)pCurrData;
		pCurrData += 4;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (SpiritAddProperties == null)
			{
				SpiritAddProperties = new CricketSpiritProperty();
			}
			pCurrData += SpiritAddProperties.Deserialize(pCurrData);
		}
		else
		{
			SpiritAddProperties = null;
		}
		OriginState = (sbyte)(*pCurrData);
		pCurrData++;
		NameId = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
