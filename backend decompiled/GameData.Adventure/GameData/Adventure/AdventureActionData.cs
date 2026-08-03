using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureActionData : IMessage<AdventureActionData>, IMessage, IEquatable<AdventureActionData>, IDeepCloneable<AdventureActionData>, IBufferMessage
{
	private static readonly MessageParser<AdventureActionData> _parser = new MessageParser<AdventureActionData>(() => new AdventureActionData());

	private UnknownFieldSet _unknownFields;

	public const int KeyFieldNumber = 1;

	private string key_ = "";

	public const int TimeFieldNumber = 2;

	private int time_;

	public const int NameForProtoFieldNumber = 11;

	private AdventureLocalStringRef nameForProto_;

	public const int DescForProtoFieldNumber = 12;

	private AdventureLocalStringRef descForProto_;

	public const int IconFieldNumber = 13;

	private string icon_ = "";

	public string Name => NameForProto.Tr();

	public string Desc => DescForProto.Tr();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureActionData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[4];

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
	public int Time
	{
		get
		{
			return time_;
		}
		set
		{
			time_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureLocalStringRef NameForProto
	{
		get
		{
			return nameForProto_;
		}
		set
		{
			nameForProto_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureLocalStringRef DescForProto
	{
		get
		{
			return descForProto_;
		}
		set
		{
			descForProto_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Icon
	{
		get
		{
			return icon_;
		}
		set
		{
			icon_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureActionData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureActionData(AdventureActionData other)
		: this()
	{
		key_ = other.key_;
		time_ = other.time_;
		nameForProto_ = ((other.nameForProto_ != null) ? other.nameForProto_.Clone() : null);
		descForProto_ = ((other.descForProto_ != null) ? other.descForProto_.Clone() : null);
		icon_ = other.icon_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureActionData Clone()
	{
		return new AdventureActionData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureActionData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureActionData other)
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
		if (Time != other.Time)
		{
			return false;
		}
		if (!object.Equals(NameForProto, other.NameForProto))
		{
			return false;
		}
		if (!object.Equals(DescForProto, other.DescForProto))
		{
			return false;
		}
		if (Icon != other.Icon)
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
		if (Time != 0)
		{
			hash ^= Time.GetHashCode();
		}
		if (nameForProto_ != null)
		{
			hash ^= NameForProto.GetHashCode();
		}
		if (descForProto_ != null)
		{
			hash ^= DescForProto.GetHashCode();
		}
		if (Icon.Length != 0)
		{
			hash ^= Icon.GetHashCode();
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
		if (Time != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(Time);
		}
		if (nameForProto_ != null)
		{
			output.WriteRawTag(90);
			output.WriteMessage(NameForProto);
		}
		if (descForProto_ != null)
		{
			output.WriteRawTag(98);
			output.WriteMessage(DescForProto);
		}
		if (Icon.Length != 0)
		{
			output.WriteRawTag(106);
			output.WriteString(Icon);
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
		if (Time != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(Time);
		}
		if (nameForProto_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(NameForProto);
		}
		if (descForProto_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(DescForProto);
		}
		if (Icon.Length != 0)
		{
			size += 1 + CodedOutputStream.ComputeStringSize(Icon);
		}
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureActionData other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Key.Length != 0)
		{
			Key = other.Key;
		}
		if (other.Time != 0)
		{
			Time = other.Time;
		}
		if (other.nameForProto_ != null)
		{
			if (nameForProto_ == null)
			{
				NameForProto = new AdventureLocalStringRef();
			}
			NameForProto.MergeFrom(other.NameForProto);
		}
		if (other.descForProto_ != null)
		{
			if (descForProto_ == null)
			{
				DescForProto = new AdventureLocalStringRef();
			}
			DescForProto.MergeFrom(other.DescForProto);
		}
		if (other.Icon.Length != 0)
		{
			Icon = other.Icon;
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
			case 16u:
				Time = input.ReadInt32();
				break;
			case 90u:
				if (nameForProto_ == null)
				{
					NameForProto = new AdventureLocalStringRef();
				}
				input.ReadMessage(NameForProto);
				break;
			case 98u:
				if (descForProto_ == null)
				{
					DescForProto = new AdventureLocalStringRef();
				}
				input.ReadMessage(DescForProto);
				break;
			case 106u:
				Icon = input.ReadString();
				break;
			}
		}
	}
}
