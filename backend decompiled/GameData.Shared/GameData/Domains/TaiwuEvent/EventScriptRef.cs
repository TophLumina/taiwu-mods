using System;

namespace GameData.Domains.TaiwuEvent;

public readonly struct EventScriptRef : IEquatable<EventScriptRef>
{
	public readonly Guid Guid;

	public readonly Guid SubGuid;

	public static readonly EventScriptRef Invalid;

	public bool HasSubGuid => SubGuid != Guid.Empty;

	public static implicit operator EventScriptRef(Guid guid)
	{
		return new EventScriptRef(guid);
	}

	public EventScriptRef(Guid guid)
	{
		Guid = guid;
		SubGuid = Guid.Empty;
	}

	public EventScriptRef(Guid guid, Guid subGuid)
	{
		Guid = guid;
		SubGuid = subGuid;
	}

	public EventScriptRef(string guid, string subGuid = null)
	{
		Guid = Guid.Parse(guid);
		SubGuid = ((subGuid == null) ? Guid.Empty : Guid.Parse(subGuid));
	}

	public override string ToString()
	{
		Guid subGuid = SubGuid;
		if (!subGuid.Equals(Guid.Empty))
		{
			return $"Event: {Guid} option {SubGuid}";
		}
		return $"Event: {Guid}";
	}

	public bool Equals(EventScriptRef other)
	{
		Guid guid = Guid;
		if (guid.Equals(other.Guid))
		{
			guid = SubGuid;
			return guid.Equals(other.SubGuid);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is EventScriptRef other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Guid, SubGuid);
	}

	static EventScriptRef()
	{
		Invalid = new EventScriptRef(Guid.Empty, Guid.Empty);
	}
}
