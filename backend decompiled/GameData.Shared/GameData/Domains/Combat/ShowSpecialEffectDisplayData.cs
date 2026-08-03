using Config;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 特效简述跳字显示数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct ShowSpecialEffectDisplayData : ISerializableGameData
{
	/// <summary>
	/// 无效值
	/// </summary>
	public static readonly ShowSpecialEffectDisplayData Invalid = new ShowSpecialEffectDisplayData
	{
		Index = -1,
		ItemData = ItemKey.Invalid,
		EffectDescription = CombatSkillEffectDescriptionDisplayData.Invalid
	};

	/// <summary>
	/// 特效简述索引
	/// </summary>
	[SerializableGameDataField]
	public int Index;

	/// <summary>
	/// 特效模板 ID
	/// </summary>
	[SerializableGameDataField]
	public int EffectId;

	/// <summary>
	/// 所用道具数据
	/// </summary>
	[SerializableGameDataField]
	public ItemKey ItemData;

	/// <summary>
	/// 特效描述数据
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillEffectDescriptionDisplayData EffectDescription;

	/// <summary>
	/// 检查简述索引
	/// </summary>
	/// <param name="effectId"></param>
	/// <param name="index"></param>
	/// <returns></returns>
	public static int CheckIndex(int effectId, byte index)
	{
		if (Config.SpecialEffect.Instance[effectId].ShortDesc.Length <= index)
		{
			return -1;
		}
		return index;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 16;
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
		*(int*)pCurrData = Index;
		pCurrData += 4;
		*(int*)pCurrData = EffectId;
		pCurrData += 4;
		pCurrData += ItemData.Serialize(pCurrData);
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
		Index = *(int*)pCurrData;
		pCurrData += 4;
		EffectId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += ItemData.Deserialize(pCurrData);
		pCurrData += EffectDescription.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
