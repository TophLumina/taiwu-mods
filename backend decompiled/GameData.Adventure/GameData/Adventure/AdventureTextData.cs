using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureTextData : IMessage<AdventureTextData>, IMessage, IEquatable<AdventureTextData>, IDeepCloneable<AdventureTextData>, IBufferMessage
{
	private static readonly MessageParser<AdventureTextData> _parser = new MessageParser<AdventureTextData>(() => new AdventureTextData());

	private UnknownFieldSet _unknownFields;

	public const int KeyFieldNumber = 1;

	private string key_ = "";

	public const int TextForProtoFieldNumber = 2;

	private AdventureLocalStringRef textForProto_;

	public const int PriorityFieldNumber = 3;

	private int priority_;

	public const int OnlyOnceFieldNumber = 11;

	private bool onlyOnce_;

	public string Text => TextForProto.Tr();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureTextData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[26];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Key
	{
		get
		{
			return key_;
		}
		set
		{
			key_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureLocalStringRef TextForProto
	{
		get
		{
			return textForProto_;
		}
		set
		{
			textForProto_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Priority
	{
		get
		{
			return priority_;
		}
		set
		{
			priority_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool OnlyOnce
	{
		get
		{
			return onlyOnce_;
		}
		set
		{
			onlyOnce_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureTextData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureTextData(AdventureTextData other)
		: this()
	{
		key_ = other.key_;
		textForProto_ = ((other.textForProto_ != null) ? other.textForProto_.Clone() : null);
		priority_ = other.priority_;
		onlyOnce_ = other.onlyOnce_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureTextData Clone()
	{
		return new AdventureTextData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureTextData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureTextData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Key != other.Key)
		{
			return false;
		}
		if (!object.Equals(TextForProto, other.TextForProto))
		{
			return false;
		}
		if (Priority != other.Priority)
		{
			return false;
		}
		if (OnlyOnce != other.OnlyOnce)
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
		if (Key.Length != 0)
		{
			hash ^= Key.GetHashCode();
		}
		if (textForProto_ != null)
		{
			hash ^= TextForProto.GetHashCode();
		}
		if (Priority != 0)
		{
			hash ^= Priority.GetHashCode();
		}
		if (OnlyOnce)
		{
			hash ^= OnlyOnce.GetHashCode();
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
		if (Key.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Key);
		}
		if (textForProto_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(TextForProto);
		}
		if (Priority != 0)
		{
			output.WriteRawTag(24);
			output.WriteSInt32(Priority);
		}
		if (OnlyOnce)
		{
			output.WriteRawTag(88);
			output.WriteBool(OnlyOnce);
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
		if (Key.Length != 0)
		{
			size += 1 + CodedOutputStream.ComputeStringSize(Key);
		}
		if (textForProto_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(TextForProto);
		}
		if (Priority != 0)
		{
			size += 1 + CodedOutputStream.ComputeSInt32Size(Priority);
		}
		if (OnlyOnce)
		{
			size += 2;
		}
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureTextData other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Key.Length != 0)
		{
			Key = other.Key;
		}
		if (other.textForProto_ != null)
		{
			if (textForProto_ == null)
			{
				TextForProto = new AdventureLocalStringRef();
			}
			TextForProto.MergeFrom(other.TextForProto);
		}
		if (other.Priority != 0)
		{
			Priority = other.Priority;
		}
		if (other.OnlyOnce)
		{
			OnlyOnce = other.OnlyOnce;
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
				Key = input.ReadString();
				break;
			case 18u:
				if (textForProto_ == null)
				{
					TextForProto = new AdventureLocalStringRef();
				}
				input.ReadMessage(TextForProto);
				break;
			case 24u:
				Priority = input.ReadSInt32();
				break;
			case 88u:
				OnlyOnce = input.ReadBool();
				break;
			}
		}
	}
}
