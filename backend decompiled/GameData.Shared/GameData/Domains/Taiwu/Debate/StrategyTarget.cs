using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Debate;

/// <summary>
/// 策略的一组目标集合
/// </summary>
public class StrategyTarget : ISerializableGameData
{
	/// <summary>
	/// 类型
	/// </summary>
	[SerializableGameDataField]
	public int ObjectType;

	/// <summary>
	/// 集合
	/// </summary>
	[SerializableGameDataField]
	public List<ulong> List;

	/// <summary>
	/// 类型
	/// </summary>
	public EDebateStrategyTargetObjectType Type => (EDebateStrategyTargetObjectType)ObjectType;

	/// <summary>
	///
	/// </summary>
	/// <param name="type"></param>
	/// <param name="list"></param>
	public StrategyTarget(EDebateStrategyTargetObjectType type, List<ulong> list)
	{
		ObjectType = (int)type;
		List = list;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public StrategyTarget()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public StrategyTarget(StrategyTarget other)
	{
		ObjectType = other.ObjectType;
		List = ((other.List == null) ? null : new List<ulong>(other.List));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(StrategyTarget other)
	{
		ObjectType = other.ObjectType;
		List = ((other.List == null) ? null : new List<ulong>(other.List));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((List == null) ? (totalSize + 2) : (totalSize + (2 + 8 * List.Count)));
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
		*(int*)pCurrData = ObjectType;
		pCurrData += 4;
		if (List != null)
		{
			int elementsCount = List.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((long*)pCurrData)[i] = (long)List[i];
			}
			pCurrData += 8 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
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
		ObjectType = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (List == null)
			{
				List = new List<ulong>(elementsCount);
			}
			else
			{
				List.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				List.Add(((ulong*)pCurrData)[i]);
			}
			pCurrData += 8 * elementsCount;
		}
		else
		{
			List?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
