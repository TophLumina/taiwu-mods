using System;
using Config;

namespace GameData.Domains.TaiwuEvent;

public readonly struct EventScriptId : IEquatable<EventScriptId>
{
	public readonly sbyte Type;

	public readonly EventScriptRef EventScriptRef;

	public readonly AdventureScriptRef AdventureScriptRef;

	public static readonly EventScriptId Invalid;

	public EventScriptId(sbyte type, EventScriptRef @ref)
	{
		Type = type;
		EventScriptRef = @ref;
		AdventureScriptRef = AdventureScriptRef.Invalid;
	}

	public EventScriptId(sbyte type, AdventureScriptRef @ref)
	{
		Type = type;
		EventScriptRef = EventScriptRef.Invalid;
		AdventureScriptRef = @ref;
	}

	public bool IsValid()
	{
		return Type != -1;
	}

	public static bool IsEventType(sbyte type)
	{
		if (type != 1 && type != 2 && type != 3 && type != 4)
		{
			return type == 5;
		}
		return true;
	}

	public static bool IsAdventureType(sbyte type)
	{
		if (type != 6 && type != 7 && type != 8 && type != 9)
		{
			return type == 10;
		}
		return true;
	}

	public static bool IsOptionType(sbyte type)
	{
		if (type != 3 && type != 4)
		{
			return type == 5;
		}
		return true;
	}

	public static bool IsConditionList(sbyte type)
	{
		if (type != 2 && type != 4 && type != 5)
		{
			return type == 6;
		}
		return true;
	}

	public bool Equals(EventScriptId other)
	{
		if (Type == other.Type)
		{
			return EventScriptRef.Equals(other.EventScriptRef);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is EventScriptId other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Type, EventScriptRef);
	}

	public override string ToString()
	{
		EventScriptTypeItem typeCfg = EventScriptType.Instance[Type];
		if (!IsAdventureType(Type))
		{
			return $"{typeCfg.Name} {EventScriptRef}";
		}
		return $"{typeCfg.Name} {AdventureScriptRef}";
	}

	public string GetFileName()
	{
		return Type switch
		{
			1 => EventScriptRef.Guid.ToString(), 
			2 => EventScriptRef.Guid.ToString() + "_condition", 
			3 => EventScriptRef.SubGuid.ToString(), 
			4 => EventScriptRef.SubGuid.ToString() + "_available", 
			5 => EventScriptRef.SubGuid.ToString() + "_visible", 
			_ => null, 
		};
	}

	static EventScriptId()
	{
		Invalid = new EventScriptId(-1, Guid.Empty);
	}
}
