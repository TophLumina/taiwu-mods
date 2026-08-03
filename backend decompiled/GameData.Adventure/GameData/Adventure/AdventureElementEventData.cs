using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureElementEventData : IMessage<AdventureElementEventData>, IMessage, IEquatable<AdventureElementEventData>, IDeepCloneable<AdventureElementEventData>, IBufferMessage
{
	private static readonly MessageParser<AdventureElementEventData> _parser = new MessageParser<AdventureElementEventData>(() => new AdventureElementEventData());

	private UnknownFieldSet _unknownFields;

	public const int EventFieldNumber = 1;

	private AdventureEventData event_;

	public const int TriggerTypeFieldNumber = 2;

	private EAdventureElementEventTriggerType triggerType_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureElementEventData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[16];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureEventData Event
	{
		get
		{
			return event_;
		}
		set
		{
			event_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EAdventureElementEventTriggerType TriggerType
	{
		get
		{
			return triggerType_;
		}
		set
		{
			triggerType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureElementEventData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureElementEventData(AdventureElementEventData other)
		: this()
	{
		event_ = ((other.event_ != null) ? other.event_.Clone() : null);
		triggerType_ = other.triggerType_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureElementEventData Clone()
	{
		return new AdventureElementEventData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureElementEventData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureElementEventData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Event, other.Event))
		{
			return false;
		}
		if (TriggerType != other.TriggerType)
		{
			return false;
		}
		return object.Equals(_unknownFields, other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override int GetHashCode()
	{
		int hash = 1;
		if (event_ != null)
		{
			hash ^= Event.GetHashCode();
		}
		if (TriggerType != EAdventureElementEventTriggerType.Undefined)
		{
			hash ^= TriggerType.GetHashCode();
		}
		if (_unknownFields != null)
		{
			hash ^= _unknownFields.GetHashCode();
		}
		return hash;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override string ToString()
	{
		return JsonFormatter.ToDiagnosticString(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void WriteTo(CodedOutputStream output)
	{
		output.WriteRawMessage(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	void IBufferMessage.InternalWriteTo(ref WriteContext output)
	{
		if (event_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Event);
		}
		if (TriggerType != EAdventureElementEventTriggerType.Undefined)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)TriggerType);
		}
		if (_unknownFields != null)
		{
			_unknownFields.WriteTo(ref output);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int CalculateSize()
	{
		int size = 0;
		if (event_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(Event);
		}
		if (TriggerType != EAdventureElementEventTriggerType.Undefined)
		{
			size += 1 + CodedOutputStream.ComputeEnumSize((int)TriggerType);
		}
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureElementEventData other)
	{
		if (other == null)
		{
			return;
		}
		if (other.event_ != null)
		{
			if (event_ == null)
			{
				Event = new AdventureEventData();
			}
			Event.MergeFrom(other.Event);
		}
		if (other.TriggerType != EAdventureElementEventTriggerType.Undefined)
		{
			TriggerType = other.TriggerType;
		}
		_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(CodedInputStream input)
	{
		input.ReadRawMessage(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	void IBufferMessage.InternalMergeFrom(ref ParseContext input)
	{
		uint tag;
		while ((tag = input.ReadTag()) != 0 && (tag & 7) != 4)
		{
			switch (tag)
			{
			default:
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
				break;
			case 10u:
				if (event_ == null)
				{
					Event = new AdventureEventData();
				}
				input.ReadMessage(Event);
				break;
			case 16u:
				TriggerType = (EAdventureElementEventTriggerType)input.ReadEnum();
				break;
			}
		}
	}
}
