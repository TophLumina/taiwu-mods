using System.Runtime.InteropServices;

namespace GameData.GameDataBridge;

[StructLayout(LayoutKind.Explicit)]
public struct Operation
{
	[FieldOffset(0)]
	public byte Type;

	[FieldOffset(4)]
	public ushort DomainId;

	[FieldOffset(6)]
	public ushort DataId;

	[FieldOffset(8)]
	public ulong SubId0;

	[FieldOffset(16)]
	public uint SubId1;

	[FieldOffset(20)]
	public int ValueOffset;

	[FieldOffset(6)]
	public ushort MethodId;

	[FieldOffset(8)]
	public int ArgsCount;

	[FieldOffset(12)]
	public int ArgsOffset;

	[FieldOffset(16)]
	public int ListenerId;

	public static Operation CreateDataMonitor(ushort domainId, ushort dataId, ulong subId0, uint subId1)
	{
		Operation operation = default(Operation);
		operation.Type = 0;
		operation.DomainId = domainId;
		operation.MethodId = 0;
		operation.DataId = dataId;
		operation.ArgsCount = 0;
		operation.ArgsOffset = 0;
		operation.SubId0 = subId0;
		operation.ListenerId = 0;
		operation.SubId1 = subId1;
		operation.ValueOffset = 0;
		return operation;
	}

	public static Operation CreateDataUnMonitor(ushort domainId, ushort dataId, ulong subId0, uint subId1)
	{
		Operation operation = default(Operation);
		operation.Type = 1;
		operation.DomainId = domainId;
		operation.MethodId = 0;
		operation.DataId = dataId;
		operation.ArgsCount = 0;
		operation.ArgsOffset = 0;
		operation.SubId0 = subId0;
		operation.ListenerId = 0;
		operation.SubId1 = subId1;
		operation.ValueOffset = 0;
		return operation;
	}

	public static Operation CreateDataModification(ushort domainId, ushort dataId, ulong subId0, uint subId1, int valueOffset)
	{
		Operation operation = default(Operation);
		operation.Type = 2;
		operation.DomainId = domainId;
		operation.MethodId = 0;
		operation.DataId = dataId;
		operation.ArgsCount = 0;
		operation.ArgsOffset = 0;
		operation.SubId0 = subId0;
		operation.ListenerId = 0;
		operation.SubId1 = subId1;
		operation.ValueOffset = valueOffset;
		return operation;
	}

	public static Operation CreateMethodCall(int listenerId, ushort domainId, ushort methodId, int argsCount, int argsOffset)
	{
		Operation operation = default(Operation);
		operation.Type = 3;
		operation.DomainId = domainId;
		operation.DataId = 0;
		operation.MethodId = methodId;
		operation.SubId0 = 0uL;
		operation.ArgsCount = argsCount;
		operation.ArgsOffset = argsOffset;
		operation.SubId1 = 0u;
		operation.ListenerId = listenerId;
		operation.ValueOffset = 0;
		return operation;
	}
}
