using System.Collections.Generic;
using System.Linq;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Debate;

/// <summary>
/// 论点棋子
/// </summary>
public class Pawn : ISerializableGameData
{
	/// <summary>
	/// Id
	/// </summary>
	[SerializableGameDataField]
	public int Id;

	/// <summary>
	/// 坐标
	/// </summary>
	[SerializableGameDataField]
	public IntPair Coordinate;

	/// <summary>
	/// 是否属于太吾
	/// </summary>
	[SerializableGameDataField]
	public bool IsOwnedByTaiwu;

	/// <summary>
	/// 棋子基础论据
	/// </summary>
	[SerializableGameDataField]
	public int Bases;

	/// <summary>
	/// 是否揭示
	/// 注意：能看到的战斗力可能不等于实际战斗力，因为论点上隐藏的生效策略的数值不会显示
	/// </summary>
	[SerializableGameDataField]
	public bool IsRevealed;

	/// <summary>
	/// 是否存活
	/// </summary>
	[SerializableGameDataField]
	public bool IsAlive;

	/// <summary>
	/// 是否0论据
	/// 用于论战压力判断
	/// </summary>
	[SerializableGameDataField]
	public bool IsZero;

	/// <summary>
	/// 附着策略
	/// </summary>
	[SerializableGameDataField(ArrayElementsCount = 3)]
	public int[] Strategies = new int[3] { -1, -1, -1 };

	/// <summary>
	/// 唯我观众的场地效果
	/// </summary>
	public int NodeDamage;

	public bool Damaged;

	/// <summary>
	/// 是否停止前进
	/// 佛学2
	/// </summary>
	public bool IsHalt;

	/// <summary>
	/// 是否交换位置
	/// 佛学3
	/// </summary>
	public bool IsSwitchLocation;

	/// <summary>
	/// 是否免疫论战debuff
	/// 锻造1
	/// </summary>
	public bool IsImmuneDebuff;

	/// <summary>
	/// 是否死亡时回到随机己方空格同时论据减半
	/// 品鉴3
	/// </summary>
	public bool IsHalfImmuneRemove;

	/// <summary>
	/// 是否死亡时回到底线
	/// 锻造2
	/// </summary>
	public bool IsImmuneRemove;

	/// <summary>
	/// 造成伤害时对自己的结论点影响
	/// 医术3毒术3，按最终的伤害值进行百分比计算
	/// </summary>
	public int ChangeSelfGamePointByDamagePercent;

	/// <summary>
	/// 造成伤害时对自己的结论点影响，是否是太吾触发
	/// </summary>
	public bool ChangeSelfGamePointByDamagePercentIsCastedByTaiwu;

	/// <summary>
	/// 额外伤害列表
	/// </summary>
	public List<PawnDamageInfo> DamageList = new List<PawnDamageInfo>();

	/// <summary>
	/// 对自己的额外伤害
	/// 巧匠3
	/// </summary>
	public int DamageToSelf => DamageList.Where((PawnDamageInfo d) => d.IsToSelf).Sum((PawnDamageInfo d) => d.Damage);

	/// <summary>
	/// 对对方的额外伤害
	/// 诗书1
	/// TAIWU-37325 巧匠3不计入棋子伤害
	/// </summary>
	public int DamageToOpponent => DamageList.Where((PawnDamageInfo d) => !d.IsToSelf && !d.IsStrategyDamage).Sum((PawnDamageInfo d) => d.Damage);

	/// <summary>
	/// 重置策略临时值
	/// </summary>
	public void ResetNodeValue()
	{
		NodeDamage = 0;
		Damaged = false;
	}

	/// <summary>
	/// 重置策略临时值
	/// </summary>
	public void ResetStrategyValue()
	{
		IsHalt = false;
		IsSwitchLocation = false;
		IsHalfImmuneRemove = false;
		IsImmuneRemove = false;
		IsImmuneDebuff = false;
		ChangeSelfGamePointByDamagePercent = 0;
		DamageList.Clear();
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="id"></param>
	/// <param name="coordinate"></param>
	/// <param name="isOwnedByTaiwu"></param>
	/// <param name="bases"></param>
	public Pawn(int id, IntPair coordinate, bool isOwnedByTaiwu, int bases)
	{
		Id = id;
		Coordinate = coordinate;
		IsOwnedByTaiwu = isOwnedByTaiwu;
		Bases = bases;
		IsRevealed = false;
		IsAlive = true;
		IsZero = bases == 0;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public Pawn()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public Pawn(Pawn other)
	{
		Id = other.Id;
		Coordinate = other.Coordinate;
		IsOwnedByTaiwu = other.IsOwnedByTaiwu;
		Bases = other.Bases;
		IsRevealed = other.IsRevealed;
		IsAlive = other.IsAlive;
		IsZero = other.IsZero;
		int[] item = other.Strategies;
		int elementsCount = item.Length;
		Strategies = new int[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			Strategies[i] = item[i];
		}
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(Pawn other)
	{
		Id = other.Id;
		Coordinate = other.Coordinate;
		IsOwnedByTaiwu = other.IsOwnedByTaiwu;
		Bases = other.Bases;
		IsRevealed = other.IsRevealed;
		IsAlive = other.IsAlive;
		IsZero = other.IsZero;
		int[] item = other.Strategies;
		int elementsCount = item.Length;
		Strategies = new int[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			Strategies[i] = item[i];
		}
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 32;
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
		*(int*)pCurrData = Id;
		pCurrData += 4;
		pCurrData += Coordinate.Serialize(pCurrData);
		*pCurrData = (IsOwnedByTaiwu ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = Bases;
		pCurrData += 4;
		*pCurrData = (IsRevealed ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsAlive ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsZero ? ((byte)1) : ((byte)0));
		pCurrData++;
		Tester.Assert(Strategies.Length == 3);
		for (int i = 0; i < 3; i++)
		{
			((int*)pCurrData)[i] = Strategies[i];
		}
		pCurrData += 12;
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
		Id = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Coordinate.Deserialize(pCurrData);
		IsOwnedByTaiwu = *pCurrData != 0;
		pCurrData++;
		Bases = *(int*)pCurrData;
		pCurrData += 4;
		IsRevealed = *pCurrData != 0;
		pCurrData++;
		IsAlive = *pCurrData != 0;
		pCurrData++;
		IsZero = *pCurrData != 0;
		pCurrData++;
		if (Strategies == null || Strategies.Length != 3)
		{
			Strategies = new int[3];
		}
		for (int i = 0; i < 3; i++)
		{
			Strategies[i] = ((int*)pCurrData)[i];
		}
		pCurrData += 12;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
