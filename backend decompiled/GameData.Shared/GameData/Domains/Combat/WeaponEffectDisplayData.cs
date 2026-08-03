using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 武器特效显示数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct WeaponEffectDisplayData : ISerializableGameData
{
	/// <summary>
	/// 技能特效键
	/// </summary>
	[SerializableGameDataField]
	public SkillEffectKey EffectKey;

	/// <summary>
	/// 特效描述数据
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillEffectDescriptionDisplayData EffectDescription;

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public WeaponEffectDisplayData(WeaponEffectDisplayData other)
	{
		EffectKey = other.EffectKey;
		EffectDescription = new CombatSkillEffectDescriptionDisplayData(other.EffectDescription);
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(WeaponEffectDisplayData other)
	{
		EffectKey = other.EffectKey;
		EffectDescription = new CombatSkillEffectDescriptionDisplayData(other.EffectDescription);
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
		totalSize += EffectDescription.GetSerializedSize();
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
		pCurrData += EffectKey.Serialize(pCurrData);
		int fieldSize = EffectDescription.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
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
		pCurrData += EffectKey.Deserialize(pCurrData);
		pCurrData += EffectDescription.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
