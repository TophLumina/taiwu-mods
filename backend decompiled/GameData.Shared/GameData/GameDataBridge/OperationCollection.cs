using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.GameDataBridge;

/// <summary>
/// 表现模块向数据模块发送的数据操作集合
/// </summary>
public struct OperationCollection
{
	/// <summary>
	/// 操作集合
	/// </summary>
	public readonly List<Operation> Operations;

	/// <summary>
	/// 数据池
	/// </summary>
	public readonly RawDataPool DataPool;

	/// <summary>
	/// 表现模块向数据模块发送的数据操作集合
	/// </summary>
	/// <param name="defaultCapacity"></param>
	public OperationCollection(int defaultCapacity)
	{
		Operations = new List<Operation>();
		DataPool = new RawDataPool(defaultCapacity);
	}

	/// <summary>
	/// 表现模块向数据模块发送的数据操作集合
	/// </summary>
	/// <param name="operations"></param>
	/// <param name="dataPool"></param>
	public OperationCollection(List<Operation> operations, RawDataPool dataPool)
	{
		Operations = operations;
		DataPool = dataPool;
	}
}
