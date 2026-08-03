using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 完整的伤害阈值显示数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class CompleteDamageStepDisplayData : ISerializableGameData
{
	/// <summary>
	/// 部位伤害阈值数据
	/// </summary>
	[SerializableGameDataField(ArrayElementsCount = 7)]
	public OuterAndInnerDamageStepDisplayData[] BodyPart = new OuterAndInnerDamageStepDisplayData[7];

	/// <summary>
	/// 心神伤害阈值数据
	/// </summary>
	[SerializableGameDataField]
	public DamageStepDisplayData Mind;

	/// <summary>
	/// 重创伤害阈值数据
	/// </summary>
	[SerializableGameDataField]
	public DamageStepDisplayData Fatal;

	/// <summary>
	/// 角色基础伤害阈值
	/// </summary>
	[SerializableGameDataField]
	public DamageStepCollection CharacterBaseDamageSteps;

	/// <summary>
	/// 角色精纯
	/// 用于计算精纯加成值
	/// </summary>
	[SerializableGameDataField]
	public sbyte CharacterConsummateLevel;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CompleteDamageStepDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CompleteDamageStepDisplayData(CompleteDamageStepDisplayData other)
	{
		OuterAndInnerDamageStepDisplayData[] item = other.BodyPart;
		int elementsCount = item.Length;
		BodyPart = new OuterAndInnerDamageStepDisplayData[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			BodyPart[i] = item[i];
		}
		Mind = other.Mind;
		Fatal = other.Fatal;
		CharacterBaseDamageSteps = new DamageStepCollection(other.CharacterBaseDamageSteps);
		CharacterConsummateLevel = other.CharacterConsummateLevel;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CompleteDamageStepDisplayData other)
	{
		OuterAndInnerDamageStepDisplayData[] item = other.BodyPart;
		int elementsCount = item.Length;
		BodyPart = new OuterAndInnerDamageStepDisplayData[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			BodyPart[i] = item[i];
		}
		Mind = other.Mind;
		Fatal = other.Fatal;
		CharacterBaseDamageSteps = new DamageStepCollection(other.CharacterBaseDamageSteps);
		CharacterConsummateLevel = other.CharacterConsummateLevel;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 449;
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
		Tester.Assert(BodyPart.Length == 7);
		for (int i = 0; i < 7; i++)
		{
			pCurrData += BodyPart[i].Serialize(pCurrData);
		}
		pCurrData += Mind.Serialize(pCurrData);
		pCurrData += Fatal.Serialize(pCurrData);
		pCurrData += CharacterBaseDamageSteps.Serialize(pCurrData);
		*pCurrData = (byte)CharacterConsummateLevel;
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
		if (BodyPart == null || BodyPart.Length != 7)
		{
			BodyPart = new OuterAndInnerDamageStepDisplayData[7];
		}
		for (int i = 0; i < 7; i++)
		{
			OuterAndInnerDamageStepDisplayData element = default(OuterAndInnerDamageStepDisplayData);
			pCurrData += element.Deserialize(pCurrData);
			BodyPart[i] = element;
		}
		pCurrData += Mind.Deserialize(pCurrData);
		pCurrData += Fatal.Deserialize(pCurrData);
		if (CharacterBaseDamageSteps == null)
		{
			CharacterBaseDamageSteps = new DamageStepCollection();
		}
		pCurrData += CharacterBaseDamageSteps.Deserialize(pCurrData);
		CharacterConsummateLevel = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
