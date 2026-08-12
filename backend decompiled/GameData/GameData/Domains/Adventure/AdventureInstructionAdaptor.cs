using System;
using System.Collections.Generic;
using System.IO;
using GameData.Adventure;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.TaiwuEvent.Decompiler;
using GameData.Utilities;

namespace GameData.Domains.Adventure;

public static class AdventureInstructionAdaptor
{
	private static readonly IEventScriptDecompiler Decompiler = new EventScriptDecompiler_0_0_2_0();

	private static readonly Dictionary<InstructionCompiled, EventScriptBase> CachedScripts = new Dictionary<InstructionCompiled, EventScriptBase>();

	private static EventScriptRuntime Runtime => DomainManager.TaiwuEvent.ScriptRuntime;

	public static bool Check(this InstructionCompiled ins, int adventureId)
	{
		EventArgBox args = DomainManager.TaiwuEvent.GetEventArgBox();
		args.Set("ConchShipPresetKey_AdventureId", adventureId);
		bool result = ins.Check(args);
		DomainManager.TaiwuEvent.ReturnArgBox(args);
		return result;
	}

	public static bool Check(this InstructionCompiled ins, int adventureId, AdventureBlockIndex index)
	{
		EventArgBox args = DomainManager.TaiwuEvent.GetEventArgBox();
		args.Set("ConchShipPresetKey_AdventureId", adventureId);
		args.Set("ConchShipPresetKey_BlockIndex", (AdventureBlockIndexForSerialize)index);
		bool result = ins.Check(args);
		DomainManager.TaiwuEvent.ReturnArgBox(args);
		return result;
	}

	public static bool Check(this InstructionCompiled ins, int adventureId, int elementId)
	{
		EventArgBox args = DomainManager.TaiwuEvent.GetEventArgBox();
		args.Set("ConchShipPresetKey_AdventureId", adventureId);
		args.Set("ConchShipPresetKey_ElementId", elementId);
		bool result = ins.Check(args);
		DomainManager.TaiwuEvent.ReturnArgBox(args);
		return result;
	}

	public static bool Check(this InstructionCompiled ins, EventArgBox args)
	{
		if (ins.CompiledSpan.Length <= 0)
		{
			return true;
		}
		EventScriptBase script = CachedScripts.GetValueOrDefault(ins) ?? ins.Decompile();
		CachedScripts[ins] = script;
		try
		{
			if (!(script is EventConditionList condition))
			{
				throw new Exception("Script type incompatibility by " + script.GetType().FullName);
			}
			return Runtime.CheckConditionList(condition, args);
		}
		catch (Exception value)
		{
			string debug = script.Id.AdventureScriptRef.DebugInfo;
			AdaptableLog.Warning($"Failed to check condition at {debug}, fallback to false, ex={value}", appendWarningMessage: true);
			return false;
		}
	}

	public static void Execute(this InstructionCompiled ins, int adventureId)
	{
		EventArgBox args = DomainManager.TaiwuEvent.GetEventArgBox();
		args.Set("ConchShipPresetKey_AdventureId", adventureId);
		ins.Execute(args);
		DomainManager.TaiwuEvent.ReturnArgBox(args);
	}

	public static void Execute(this InstructionCompiled ins, AdventureMajorEvent majorEvent)
	{
		EventArgBox args = DomainManager.TaiwuEvent.GetEventArgBox();
		args.Set("ConchShipPresetKey_MajorEvent", majorEvent);
		ins.Execute(args);
		DomainManager.TaiwuEvent.ReturnArgBox(args);
	}

	public static void Execute(this InstructionCompiled ins, AdventureRuntime adventure, EAdventureRemoveType type, bool running)
	{
		EventArgBox args = DomainManager.TaiwuEvent.GetEventArgBox();
		args.Set("ConchShipPresetKey_AdventureId", adventure.Id);
		args.Set("ConchShipPresetKey_RemoveType", (int)type);
		args.Set("ConchShipPresetKey_IsTimeout", type == EAdventureRemoveType.Timeout);
		args.Set("ConchShipPresetKey_IsRunning", running);
		ins.Execute(args);
		DomainManager.TaiwuEvent.ReturnArgBox(args);
	}

	public static void Execute(this InstructionCompiled ins, AdventureMajorEvent majorEvent, EAdventureRemoveType type, EventArgBox extraArgs)
	{
		EventArgBox args = DomainManager.TaiwuEvent.GetEventArgBox();
		extraArgs?.CloneTo(args);
		args.Set("ConchShipPresetKey_MajorEvent", majorEvent);
		args.Set("ConchShipPresetKey_RemoveType", (int)type);
		args.Set("ConchShipPresetKey_IsTimeout", type == EAdventureRemoveType.Timeout);
		args.Set("ConchShipPresetKey_IsRunning", args.GetBool("ConchShipPresetKey_IsRunning"));
		ins.Execute(args);
		DomainManager.TaiwuEvent.ReturnArgBox(args);
	}

	public static void Execute(this InstructionCompiled ins, EventArgBox args)
	{
		if (ins.CompiledSpan.Length <= 0)
		{
			return;
		}
		EventScriptBase script = CachedScripts.GetValueOrDefault(ins) ?? ins.Decompile();
		CachedScripts[ins] = script;
		try
		{
			if (!(script is EventScript eventScript))
			{
				throw new Exception("Script type incompatibility by " + script.GetType().FullName);
			}
			Runtime.ExecuteScript(eventScript, args);
		}
		catch (Exception value)
		{
			string debug = script.Id.AdventureScriptRef.DebugInfo;
			AdaptableLog.Warning($"Failed to execute script at {debug}, fallback to none, ex={value}", appendWarningMessage: true);
		}
	}

	private static EventScriptBase Decompile(this InstructionCompiled ins)
	{
		using MemoryStream stream = new MemoryStream(ins.CompiledCopy);
		using BinaryReader reader = new BinaryReader(stream);
		EventScriptId scriptId = Decompiler.DecompileScriptId(Runtime, reader);
		return EventScriptId.IsConditionList(scriptId.Type) ? ((EventScriptBase)Decompiler.DecompileConditionList(Runtime, scriptId, reader)) : ((EventScriptBase)Decompiler.DecompileEventScript(Runtime, scriptId, reader));
	}
}
