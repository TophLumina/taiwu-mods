using GameData.Domains.Character;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Display;

/// <summary>
/// 旅人相关数据
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class TaiwuNeiliProportionDisplayData : ISerializableGameData
{
	/// <summary>
	/// 内力数据 - 当前值
	/// </summary>
	[SerializableGameDataField]
	public NeiliProportionOfFiveElements NeiliProportion;

	/// <summary>
	/// 内力数据 - 预览值
	/// </summary>
	[SerializableGameDataField]
	public NeiliProportionOfFiveElements NeiliProportionPreview;

	/// <summary>
	/// 内力传递方向 - 目标
	/// <see cref="!:GameData.Domains.CombatSkill.FiveElementType" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte DestType = -1;

	/// <summary>
	/// 内力传递方向 - 初始来源（此来源未必对应内力传递的目标）
	/// <see cref="!:GameData.Domains.CombatSkill.FiveElementType" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte TransferType;

	/// <summary>
	/// 内力传递数量
	/// </summary>
	[SerializableGameDataField]
	public sbyte Amount;

	/// <summary>
	/// 获取内力变化量
	/// </summary>
	/// <param name="neiliType"><see cref="!:GameData.Domains.CombatSkill.FiveElementType" /></param>
	public int this[int neiliType] => NeiliProportionPreview[neiliType] - NeiliProportion[neiliType];

	public TaiwuNeiliProportionDisplayData()
	{
	}

	public TaiwuNeiliProportionDisplayData(NeiliProportionOfFiveElements neiliProportion, sbyte destType, sbyte transferType, sbyte amount)
	{
		NeiliProportion = neiliProportion;
		NeiliProportionPreview = neiliProportion;
		if (amount > 0 && destType != -1 && transferType != -1)
		{
			NeiliProportionPreview.Transfer(destType, transferType, amount);
		}
		DestType = destType;
		TransferType = transferType;
		Amount = amount;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize += NeiliProportion.GetSerializedSize();
		totalSize += NeiliProportionPreview.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += NeiliProportion.Serialize(pCurrData);
		pCurrData += NeiliProportionPreview.Serialize(pCurrData);
		*pCurrData = (byte)DestType;
		pCurrData++;
		*pCurrData = (byte)TransferType;
		pCurrData++;
		*pCurrData = (byte)Amount;
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
		pCurrData += NeiliProportion.Deserialize(pCurrData);
		pCurrData += NeiliProportionPreview.Deserialize(pCurrData);
		DestType = (sbyte)(*pCurrData);
		pCurrData++;
		TransferType = (sbyte)(*pCurrData);
		pCurrData++;
		Amount = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
