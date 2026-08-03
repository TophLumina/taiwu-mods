using System;
using Config;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 被劫持的角色的信息
/// </summary>
public class KidnappedCharacter : ISerializableGameData
{
	/// <summary>
	/// 角色 Id
	/// </summary>
	[SerializableGameDataField]
	public int CharId;

	/// <summary>
	/// 绳索物品 Id
	/// </summary>
	[SerializableGameDataField]
	public ItemKey RopeItemKey;

	/// <summary>
	/// 劫持开始日期
	/// </summary>
	[SerializableGameDataField]
	public int KidnapBeginDate;

	/// <summary>
	/// 私人关押的囚犯额外抵抗值，仅有互动增减，不会过月变化。对监牢关押的囚犯无效。
	/// </summary>
	[SerializableGameDataField]
	public sbyte ExtraResistance;

	/// <summary>
	/// 最小额外抵抗值
	/// </summary>
	public const sbyte MinResistance = 0;

	/// <summary>
	/// 最大额外抵抗值
	/// </summary>
	public const sbyte MaxResistance = sbyte.MaxValue;

	/// <summary>
	/// 总抵抗值大于该值时人物将尝试逃跑
	/// </summary>
	public const sbyte EscapeThreshold = 100;

	/// <summary>
	/// 必定逃跑角色的抵抗值
	/// </summary>
	public const int EscapeCertainlyResistance = 999;

	/// <summary>
	/// 最大逃跑成功率
	/// </summary>
	public const sbyte MaxEscapeRate = 100;

	public KidnappedCharacter(int charId, sbyte initialExtraResistance, ItemKey ropeItemKey, int kidnapBeginDate)
	{
		CharId = charId;
		RopeItemKey = ropeItemKey;
		KidnapBeginDate = kidnapBeginDate;
		ExtraResistance = initialExtraResistance;
	}

	/// <summary>
	/// 离线修改额外抵抗值
	/// </summary>
	/// <param name="delta"></param>
	public void OfflineChangeResistance(int delta)
	{
		ExtraResistance = (sbyte)MathUtils.Clamp(ExtraResistance + delta, 0, 127);
	}

	/// <summary>
	/// 是否进行逃跑，要抵抗值达到阈值
	/// </summary>
	/// <param name="totalResistance"></param>
	/// <returns></returns>
	public bool WillEscape(int totalResistance)
	{
		return totalResistance >= 100;
	}

	/// <summary>
	/// 计算关押人物的逃跑概率，包括私人和监牢
	/// </summary>
	/// <param name="totalResistance"></param>
	/// <param name="exceedingAmount"></param>
	/// <param name="isEscapeCertainly"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public KidnappedCharacter()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public KidnappedCharacter(KidnappedCharacter other)
	{
		CharId = other.CharId;
		RopeItemKey = other.RopeItemKey;
		KidnapBeginDate = other.KidnapBeginDate;
		ExtraResistance = other.ExtraResistance;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(KidnappedCharacter other)
	{
		CharId = other.CharId;
		RopeItemKey = other.RopeItemKey;
		KidnapBeginDate = other.KidnapBeginDate;
		ExtraResistance = other.ExtraResistance;
	}

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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
