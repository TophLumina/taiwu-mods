using GameData.Serializer;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 人物对物品喜恶的信息
/// </summary>
public class CharacterLoveAndHateItemInfo : ISerializableGameData
{
	/// <summary>
	/// 角色id
	/// </summary>
	[SerializableGameDataField]
	public int CharacterId;

	/// <summary>
	/// 是否已揭示喜爱物品类型
	/// </summary>
	[SerializableGameDataField]
	public bool LovingItemRevealed;

	/// <summary>
	/// 是否已揭示厌恶物品类型
	/// </summary>
	[SerializableGameDataField]
	public bool HatingItemRevealed;

	/// <summary>
	/// 是否需要播放初次揭示喜爱物品的特效
	/// </summary>
	[SerializableGameDataField]
	public bool NeedShowFirstRevealLovingEffect;

	/// <summary>
	/// 是否需要播放初次揭示厌恶物品类型的特效
	/// </summary>
	[SerializableGameDataField]
	public bool NeedShowFirstRevealHatingEffect;

	/// <summary>
	/// 喜爱物品子类型
	/// </summary>
	[SerializableGameDataField]
	public short LovingItemSubType;

	/// <summary>
	/// 厌恶物品子类型
	/// </summary>
	[SerializableGameDataField]
	public short HatingItemSubType;

	/// <summary>
	/// 喜恶过期时间
	/// </summary>
	[SerializableGameDataField]
	public int HobbyExpirationDate;

	/// <summary>
	/// 角色创建类型
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
		int totalSize = 17;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = CharacterId;
		byte* num = pData + 4;
		*num = (LovingItemRevealed ? ((byte)1) : ((byte)0));
		byte* num2 = num + 1;
		*num2 = (HatingItemRevealed ? ((byte)1) : ((byte)0));
		byte* num3 = num2 + 1;
		*num3 = (NeedShowFirstRevealLovingEffect ? ((byte)1) : ((byte)0));
		byte* num4 = num3 + 1;
		*num4 = (NeedShowFirstRevealHatingEffect ? ((byte)1) : ((byte)0));
		byte* num5 = num4 + 1;
		*(short*)num5 = LovingItemSubType;
		byte* num6 = num5 + 2;
		*(short*)num6 = HatingItemSubType;
		byte* num7 = num6 + 2;
		*(int*)num7 = HobbyExpirationDate;
		byte* num8 = num7 + 4;
		*num8 = CreatingType;
		int totalSize = (int)(num8 + 1 - pData);
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
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		LovingItemRevealed = *pCurrData != 0;
		pCurrData++;
		HatingItemRevealed = *pCurrData != 0;
		pCurrData++;
		NeedShowFirstRevealLovingEffect = *pCurrData != 0;
		pCurrData++;
		NeedShowFirstRevealHatingEffect = *pCurrData != 0;
		pCurrData++;
		LovingItemSubType = *(short*)pCurrData;
		pCurrData += 2;
		HatingItemSubType = *(short*)pCurrData;
		pCurrData += 2;
		HobbyExpirationDate = *(int*)pCurrData;
		pCurrData += 4;
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
