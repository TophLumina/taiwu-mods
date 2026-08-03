using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 私人关押囚犯的显示数据
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class KidnappedCharacterDisplayData : ISerializableGameData
{
	/// <summary>
	/// 人物显示数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData CharacterDisplayData;

	/// <summary>
	/// 关押数据
	/// </summary>
	[SerializableGameDataField]
	public KidnappedCharacter KidnappedCharacter;

	/// <summary>
	/// 总抵抗值=人物计算的+互动改变的
	/// </summary>
	[SerializableGameDataField]
	public int TotalResistance;

	/// <summary>
	/// 逃跑概率
	/// </summary>
	[SerializableGameDataField]
	public int EscapeRate;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		totalSize = ((CharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + CharacterDisplayData.GetSerializedSize())));
		totalSize = ((KidnappedCharacter == null) ? (totalSize + 2) : (totalSize + (2 + KidnappedCharacter.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (CharacterDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += KidnappedCharacter.Serialize(pCurrData);
		*(int*)pCurrData = TotalResistance;
		pCurrData += 4;
		*(int*)pCurrData = EscapeRate;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			CharacterDisplayData = new CharacterDisplayData();
			pCurrData += CharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			CharacterDisplayData = null;
		}
		KidnappedCharacter = new KidnappedCharacter();
		pCurrData += KidnappedCharacter.Deserialize(pCurrData);
		TotalResistance = *(int*)pCurrData;
		pCurrData += 4;
		EscapeRate = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
