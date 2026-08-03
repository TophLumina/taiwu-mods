using GameData.Serializer;

namespace GameData.Domains.SpecialEffect;

[SerializableGameData(NotForDisplayModule = true)]
public class SpecialEffectWrapper : ISerializableGameData
{
	public SpecialEffectBase Effect;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = 4 + Effect.GetSerializedSize();
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = Effect.Type;
		pCurrData += 4;
		pCurrData += Effect.Serialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		int type = *(int*)pCurrData;
		pCurrData += 4;
		Effect = SpecialEffectType.CreateEffectObj(type);
		pCurrData += Effect.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
