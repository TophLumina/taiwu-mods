using System;
using System.Collections.Generic;
using System.IO;

namespace GameData.Domains.TaiwuEvent.Decompiler;

public interface IEventScriptDecompiler
{
	string Version { get; }

	Dictionary<EventScriptId, EventScriptBase> DecompileEventScriptPackage(EventScriptRuntime runtime, BinaryReader binaryReader)
	{
		Dictionary<EventScriptId, EventScriptBase> scripts = new Dictionary<EventScriptId, EventScriptBase>();
		while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
		{
			EventScriptId id = DecompileScriptId(runtime, binaryReader);
			EventScriptBase script = (EventScriptId.IsConditionList(id.Type) ? ((EventScriptBase)DecompileConditionList(runtime, id, binaryReader)) : ((EventScriptBase)DecompileEventScript(runtime, id, binaryReader)));
			scripts.Add(script.Id, script);
		}
		return scripts;
	}

	EventConditionList DecompileConditionList(EventScriptRuntime runtime, EventScriptId id, BinaryReader binaryReader)
	{
		EventConditionList script = new EventConditionList();
		script.Id = id;
		DecompileMetaData(runtime, binaryReader, script);
		int instCount = binaryReader.ReadInt32();
		script.Conditions = new EventCondition[instCount];
		for (int i = 0; i < instCount; i++)
		{
			try
			{
				script.Conditions[i] = DecompileCondition(runtime, binaryReader);
			}
			catch (Exception innerException)
			{
				throw new TaiwuEventScriptException("Failed to decompile instruction.", script.Id, i, innerException);
			}
		}
		return script;
	}

	EventScript DecompileEventScript(EventScriptRuntime runtime, EventScriptId id, BinaryReader binaryReader)
	{
		EventScript script = new EventScript();
		script.Id = id;
		DecompileMetaData(runtime, binaryReader, script);
		int instCount = binaryReader.ReadInt32();
		script.Instructions = new EventInstruction[instCount];
		for (int i = 0; i < instCount; i++)
		{
			try
			{
				script.Instructions[i] = DecompileInstruction(runtime, binaryReader);
			}
			catch (Exception innerException)
			{
				throw new TaiwuEventScriptException("Failed to decompile instruction.", script.Id, i, innerException);
			}
		}
		return script;
	}

	EventScriptId DecompileScriptId(EventScriptRuntime runtime, BinaryReader binaryReader)
	{
		sbyte type = binaryReader.ReadSByte();
		if (EventScriptId.IsAdventureType(type))
		{
			string adventureDebugInfo = binaryReader.ReadString();
			return new EventScriptId(type, new AdventureScriptRef(adventureDebugInfo));
		}
		Span<byte> buffer = stackalloc byte[16];
		if (binaryReader.Read(buffer) < 16)
		{
			throw new Exception($"Failed read guid of size {16} at offset {binaryReader.BaseStream.Position}.");
		}
		Guid guid = new Guid(buffer);
		if (!EventScriptId.IsOptionType(type))
		{
			return new EventScriptId(type, guid);
		}
		if (binaryReader.Read(buffer) < 16)
		{
			throw new Exception($"Failed read guid of size {16} at offset {binaryReader.BaseStream.Position}.");
		}
		Guid subGuid = new Guid(buffer);
		return new EventScriptId(type, new EventScriptRef(guid, subGuid));
	}

	protected void DecompileMetaData(EventScriptRuntime runtime, BinaryReader binaryReader, EventScript script);

	protected void DecompileMetaData(EventScriptRuntime runtime, BinaryReader binaryReader, EventConditionList conditionList);

	protected EventInstruction DecompileInstruction(EventScriptRuntime runtime, BinaryReader binaryReader);

	protected EventCondition DecompileCondition(EventScriptRuntime runtime, BinaryReader binaryReader);
}
