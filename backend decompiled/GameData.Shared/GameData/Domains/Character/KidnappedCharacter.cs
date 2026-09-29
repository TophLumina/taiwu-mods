using System;
using Config;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

public class KidnappedCharacter : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharId;

	[SerializableGameDataField]
	public ItemKey RopeItemKey;

	[SerializableGameDataField]
	public int KidnapBeginDate;

	[SerializableGameDataField]
	public sbyte ExtraResistance;

	public const sbyte MinResistance = 0;

	public const sbyte MaxResistance = sbyte.MaxValue;

	public const sbyte EscapeThreshold = 100;

	public const int EscapeCertainlyResistance = 999;

	public const sbyte MaxEscapeRate = 100;

	public KidnappedCharacter(int charId, sbyte initialExtraResistance, ItemKey ropeItemKey, int kidnapBeginDate)
	{
		CharId = charId;
		RopeItemKey = ropeItemKey;
		KidnapBeginDate = kidnapBeginDate;
		ExtraResistance = initialExtraResistance;
	}

	public void OfflineChangeResistance(int delta)
	{
		ExtraResistance = (sbyte)MathUtils.Clamp(ExtraResistance + delta, 0, 127);
	}

	public bool WillEscape(int totalResistance)
	{
		return totalResistance >= 100;
	}

	public int CalcEscapeRate(int totalResistance, int exceedingAmount, bool isEscapeCertainly)
	{
		if (isEscapeCertainly)
		{
			return 100;
		}
		int reduceEscapeRate = GetRopeReduceEscapeRate();
		int rate = (totalResistance - 100) * (100 - reduceEscapeRate) / 100 + exceedingAmount * 20;
		int final = Math.Clamp(rate, 0, 100);
		MiscItem ropeConfig = Misc.Instance[RopeItemKey.TemplateId];
		string ropeText = $"{9 - ropeConfig.Grade}品{ropeConfig.Name}";
		AdaptableLog.Info($"逃跑概率：({totalResistance} - {(sbyte)100}) * (100 - {reduceEscapeRate}[{ropeText}]) / 100 + {exceedingAmount} * 20 = {rate}%，最终取{final}%");
		return final;
	}

	public int GetRopeReduceEscapeRate()
	{
		return Misc.Instance[RopeItemKey.TemplateId].ReduceEscapeRate;
	}

	public KidnappedCharacter()
	{
	}

	public KidnappedCharacter(KidnappedCharacter other)
	{
		CharId = other.CharId;
		RopeItemKey = other.RopeItemKey;
		KidnapBeginDate = other.KidnapBeginDate;
		ExtraResistance = other.ExtraResistance;
	}

	public void Assign(KidnappedCharacter other)
	{
		CharId = other.CharId;
		RopeItemKey = other.RopeItemKey;
		KidnapBeginDate = other.KidnapBeginDate;
		ExtraResistance = other.ExtraResistance;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 17;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		pCurrData += RopeItemKey.Serialize(pCurrData);
		*(int*)pCurrData = KidnapBeginDate;
		pCurrData += 4;
		*pCurrData = (byte)ExtraResistance;
		pCurrData++;
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += RopeItemKey.Deserialize(pCurrData);
		KidnapBeginDate = *(int*)pCurrData;
		pCurrData += 4;
		ExtraResistance = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
