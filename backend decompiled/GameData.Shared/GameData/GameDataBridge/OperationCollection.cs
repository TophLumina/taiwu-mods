using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.GameDataBridge;

public struct OperationCollection
{
	public readonly List<Operation> Operations;

	public readonly RawDataPool DataPool;

	public OperationCollection(int defaultCapacity)
	{
		Operations = new List<Operation>();
		DataPool = new RawDataPool(defaultCapacity);
	}

	public OperationCollection(List<Operation> operations, RawDataPool dataPool)
	{
		Operations = operations;
		DataPool = dataPool;
	}
}
