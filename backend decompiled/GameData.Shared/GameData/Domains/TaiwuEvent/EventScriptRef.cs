using System;

namespace GameData.Domains.TaiwuEvent;

public readonly struct EventScriptRef : IEquatable<EventScriptRef>
{
	/// <summary>
	/// GUID.
	/// 对于全局事件脚本该字段代表脚本本身的Guid.
	/// 对于其它事件脚本, 该字段代表脚本绑定的事件页 (TaiwuEvent) 的Guid.
	/// </summary>
	public readonly Guid Guid;

	/// <summary>
	/// 附属GUID.
	/// 对于事件选项的脚本, 该字段代表选项的 Guid.
	/// 其它情况该字段为空.
	/// </summary>
	public readonly Guid SubGuid;

	/// <summary>
	/// 无效引用
	/// </summary>
	public static readonly EventScriptRef Invalid;

	public bool HasSubGuid => SubGuid != Guid.Empty;

	/// <summary>
	/// 可直接从单个 Guid 隐式转换
	/// </summary>
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

	/// <inheritdoc />
	public override string ToString()
	{
		Guid subGuid = SubGuid;
		if (!subGuid.Equals(Guid.Empty))
		{
			return $"Event: {Guid} option {SubGuid}";
		}
		return $"Event: {Guid}";
	}

	/// <inheritdoc />
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

	/// <inheritdoc />
	public override bool Equals(object obj)
	{
		if (obj is EventScriptRef other)
		{
			return Equals(other);
		}
		return false;
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return HashCode.Combine(Guid, SubGuid);
	}

	static EventScriptRef()
	{
		Invalid = new EventScriptRef(Guid.Empty, Guid.Empty);
	}
}
