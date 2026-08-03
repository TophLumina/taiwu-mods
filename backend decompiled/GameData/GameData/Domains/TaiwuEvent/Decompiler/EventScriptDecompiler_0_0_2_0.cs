using System;
using System.Collections.Generic;
using System.IO;

namespace GameData.Domains.TaiwuEvent.Decompiler;

public class EventScriptDecompiler_0_0_2_0 : IEventScriptDecompiler
{
	public string Version => "0.0.2.0";

	public void DecompileMetaData(EventScriptRuntime runtime, BinaryReader binaryReader, EventScript script)
	{
		script.Labels = new Dictionary<string, int>();
		int count = binaryReader.ReadInt32();
		for (int i = 0; i < count; i++)
		{
			string label = binaryReader.ReadString();
			int index = binaryReader.ReadInt32();
			script.Labels.Add(label, index);
		}
	}

	public void DecompileMetaData(EventScriptRuntime runtime, BinaryReader binaryReader, EventConditionList conditionList)
	{
	}

	public EventInstruction DecompileInstruction(EventScriptRuntime runtime, BinaryReader binaryReader)
	{
		int indent = binaryReader.ReadInt32();
		string assignToVar = binaryReader.ReadString();
		int funcId = binaryReader.ReadInt32();
		int argCount = binaryReader.ReadInt32();
		string[] args = ((argCount > 0) ? new string[argCount] : Array.Empty<string>());
		for (int i = 0; i < argCount; i++)
		{
			args[i] = binaryReader.ReadString();
		}
		return runtime.CreateInst(funcId, indent, assignToVar, args);
	}

	public EventCondition DecompileCondition(EventScriptRuntime runtime, BinaryReader binaryReader)
	{
		int indent = binaryReader.ReadInt32();
		bool reverse = binaryReader.ReadBoolean();
		int funcId = binaryReader.ReadInt32();
		int argCount = binaryReader.ReadInt32();
		string[] args = ((argCount > 0) ? new string[argCount] : Array.Empty<string>());
		for (int i = 0; i < argCount; i++)
		{
			args[i] = binaryReader.ReadString();
		}
		return runtime.CreateCondition(funcId, indent, reverse, args);
	}
}
