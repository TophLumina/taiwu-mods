using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializableGameData(NotForArchive = true)]
public struct CombatSkillEffectData : ISerializableGameData
{
	[SerializableGameDataField]
	private sbyte _internalType;

	[SerializableGameDataField]
	private int _internalParam0;

	public ECombatSkillEffectType Type => (ECombatSkillEffectType)_internalType;

	public int Value => _internalParam0;

	public CombatSkillEffectData(ECombatSkillEffectType type, int param0)
	{
		_internalType = (sbyte)type;
		_internalParam0 = param0;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)_internalType;
		byte* num = pData + 1;
		*(int*)num = _internalParam0;
		int totalSize = (int)(num + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		_internalType = (sbyte)(*pCurrData);
		pCurrData++;
		_internalParam0 = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
