using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using Config;
using GameData.Serializer;

namespace GameData.Domains.Item;

/// <summary>
/// 促织战斗赌注
/// </summary>
public record struct Wager : ISerializableGameData
{
	/// <summary>
	/// 赌注品阶
	/// </summary>
	public sbyte Grade => CalcWagerGrade();

	public static readonly sbyte[] ResourceRandomWeight = new sbyte[8] { 1, 1, 1, 1, 1, 1, 6, 1 };

	public const sbyte ItemRandomWeight = 3;

	/// <summary>
	/// 立场类型对应押注比例范围
	/// </summary>
	public static readonly Vector2[] BehaviorValueRange = new Vector2[5]
	{
		new Vector2(0.9f, 1.1f),
		new Vector2(1f, 1.2f),
		new Vector2(0.8f, 1f),
		new Vector2(0.6f, 1.3f),
		new Vector2(0.7f, 0.9f)
	};

	/// <summary>
	/// 赌注类型
	/// </summary>
	public sbyte Type;

	/// <summary>
	/// 资源类型，仅当赌注类型为Resource时有效
	/// </summary>
	public sbyte WagerResourceType;

	/// <summary>
	/// 物品Key，仅当赌注类型为Item时有效
	/// </summary>
	public ItemKey ItemKey;

	/// <summary>
	/// 角色ID，仅当赌注类型为Character时有效
	/// </summary>
	public int CharId;

	/// <summary>
	/// 赌注数量，当赌注类型为Character时无效
	/// </summary>
	public int Count;

	/// <summary>
	/// 无效赌注
	/// </summary>
	public static readonly Wager Invalid = new Wager
	{
		Type = -1,
		WagerResourceType = -1,
		ItemKey = ItemKey.Invalid,
		CharId = -1,
		Count = 0
	};

	/// <summary>
	/// 创建资源类型赌注
	/// </summary>
	/// <param name="resourceType"></param>
	/// <param name="count"></param>
	/// <returns></returns>
	public static Wager CreateResource(sbyte resourceType, int count)
	{
		return new Wager
		{
			Type = 0,
			WagerResourceType = resourceType,
			ItemKey = ItemKey.Invalid,
			CharId = -1,
			Count = count
		};
	}

	/// <summary>
	/// 创建道具类型赌注
	/// </summary>
	/// <param name="itemKey"></param>
	/// <param name="count"></param>
	/// <returns></returns>
	public static Wager CreateItem(ItemKey itemKey, int count)
	{
		return new Wager
		{
			Type = 1,
			WagerResourceType = -1,
			ItemKey = itemKey,
			CharId = -1,
			Count = count
		};
	}

	/// <summary>
	/// 创建角色类型赌注
	/// </summary>
	/// <param name="charId"></param>
	/// <returns></returns>
	public static Wager CreateChar(int charId)
	{
		return new Wager
		{
			Type = 2,
			WagerResourceType = -1,
			ItemKey = ItemKey.Invalid,
			CharId = charId,
			Count = -1
		};
	}

	/// <summary>
	/// 创建历练类型赌注
	/// </summary>
	/// <param name="count"></param>
	/// <returns></returns>
	public static Wager CreateExp(int count)
	{
		return new Wager
		{
			Type = 3,
			WagerResourceType = -1,
			ItemKey = ItemKey.Invalid,
			CharId = -1,
			Count = count
		};
	}

	/// <summary>
	/// 计算赌注价格
	/// 赌注类型为道具或角色时必须传入对应参数
	/// </summary>
	public long CalcWagerValue(int itemPrice = 0, sbyte fame = 0, short attraction = 0, short physiologicalAge = 0, sbyte displayGender = -1, sbyte charGrade = 0)
	{
		return Type switch
		{
			0 => CricketSpecialConstants.ResourceToPrice(WagerResourceType, Count), 
			1 => (long)itemPrice * (long)Count, 
			2 => CharacterValue(fame, attraction, charGrade, displayGender, physiologicalAge), 
			3 => CricketSpecialConstants.ExpToPrice(Count), 
			_ => throw new Exception($"Invalid wager type {Type}"), 
		};
	}

	/// <summary>
	/// 人物身价 = 与人物身份品级对应的血露的价值 * (100 + 名誉的绝对值 + 魅力 / 9) / 100
	/// </summary>
	/// <param name="fame"></param>
	/// <param name="attraction"></param>
	/// <param name="charGrade"></param>
	/// <param name="displayGender"></param>
	/// <param name="physiologicalAge"></param>
	/// <returns></returns>
	public static long CharacterValue(int fame, int attraction, int charGrade, int displayGender, int physiologicalAge)
	{
		short targetBloodDewKey = 9;
		targetBloodDewKey = (short)(targetBloodDewKey + charGrade);
		return (long)Misc.Instance[targetBloodDewKey].BaseValue * (long)(100 + Math.Abs(fame) + attraction / 9) / 100;
	}

	/// <summary>
	/// 计算赌注品阶，无有效品阶时返回 -1
	/// </summary>
	private sbyte CalcWagerGrade()
	{
		return Type switch
		{
			1 => ItemTemplateHelper.GetGrade(ItemKey.ItemType, ItemKey.TemplateId), 
			0 => CricketSpecialConstants.ResourceToPriceGrade(WagerResourceType, Count), 
			3 => CricketSpecialConstants.ExpToPriceGrade(Count), 
			_ => -1, 
		};
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = ItemKey.GetSerializedSize() + 10;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (byte)Type;
		pCurrData++;
		*pCurrData = (byte)WagerResourceType;
		pCurrData++;
		pCurrData += ItemKey.Serialize(pCurrData);
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		*(int*)pCurrData = Count;
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
		Type = (sbyte)(*pCurrData);
		pCurrData++;
		WagerResourceType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += ItemKey.Deserialize(pCurrData);
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		Count = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	[CompilerGenerated]
	private bool PrintMembers(StringBuilder builder)
	{
		builder.Append("Type = ");
		builder.Append(Type.ToString());
		builder.Append(", WagerResourceType = ");
		builder.Append(WagerResourceType.ToString());
		builder.Append(", ItemKey = ");
		builder.Append(ItemKey.ToString());
		builder.Append(", CharId = ");
		builder.Append(CharId.ToString());
		builder.Append(", Count = ");
		builder.Append(Count.ToString());
		builder.Append(", Grade = ");
		builder.Append(Grade.ToString());
		return true;
	}
}
