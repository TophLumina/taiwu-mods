using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureParameterData : IMessage<AdventureParameterData>, IMessage, IEquatable<AdventureParameterData>, IDeepCloneable<AdventureParameterData>, IBufferMessage
{
	private static readonly MessageParser<AdventureParameterData> _parser = new MessageParser<AdventureParameterData>(() => new AdventureParameterData());

	private UnknownFieldSet _unknownFields;

	public const int KeyFieldNumber = 1;

	private string key_ = "";

	public const int TypeFieldNumber = 2;

	private EAdventureParameterType type_;

	public const int InitialValueFieldNumber = 3;

	private int initialValue_;

	public const int NameForProtoFieldNumber = 11;

	private AdventureLocalStringRef nameForProto_;

	public const int DescForProtoFieldNumber = 12;

	private AdventureLocalStringRef descForProto_;

	public const int IconFieldNumber = 13;

	private string icon_ = "";

	public const int StyleFieldNumber = 14;

	private int style_;

	public const int InfluenceBlockColorHexFieldNumber = 21;

	private string influenceBlockColorHex_ = "";

	public const int InfluenceEdgeColorHexFieldNumber = 22;

	private string influenceEdgeColorHex_ = "";

	public string Name => NameForProto.Tr();

	public string Desc => DescForProto.Tr();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureParameterData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[5];

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
	public EAdventureParameterType Type
	{
		get
		{
			return type_;
		}
		set
		{
			type_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int InitialValue
	{
		get
		{
			return initialValue_;
		}
		set
		{
			initialValue_ = value;
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
	public int Style
	{
		get
		{
			return style_;
		}
		set
		{
			style_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string InfluenceBlockColorHex
	{
		get
		{
			return influenceBlockColorHex_;
		}
		set
		{
			influenceBlockColorHex_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string InfluenceEdgeColorHex
	{
		get
		{
			return influenceEdgeColorHex_;
		}
		set
		{
			influenceEdgeColorHex_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureParameterData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureParameterData(AdventureParameterData other)
		: this()
	{
		key_ = other.key_;
		type_ = other.type_;
		initialValue_ = other.initialValue_;
		nameForProto_ = ((other.nameForProto_ != null) ? other.nameForProto_.Clone() : null);
		descForProto_ = ((other.descForProto_ != null) ? other.descForProto_.Clone() : null);
		icon_ = other.icon_;
		style_ = other.style_;
		influenceBlockColorHex_ = other.influenceBlockColorHex_;
		influenceEdgeColorHex_ = other.influenceEdgeColorHex_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureParameterData Clone()
	{
		return new AdventureParameterData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureParameterData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureParameterData other)
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
		if (Type != other.Type)
		{
			return false;
		}
		if (InitialValue != other.InitialValue)
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
		if (Style != other.Style)
		{
			return false;
		}
		if (InfluenceBlockColorHex != other.InfluenceBlockColorHex)
		{
			return false;
		}
		if (InfluenceEdgeColorHex != other.InfluenceEdgeColorHex)
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
		if (Type != EAdventureParameterType.Normal)
		{
			hash ^= Type.GetHashCode();
		}
		if (InitialValue != 0)
		{
			hash ^= InitialValue.GetHashCode();
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
		if (Style != 0)
		{
			hash ^= Style.GetHashCode();
		}
		if (InfluenceBlockColorHex.Length != 0)
		{
			hash ^= InfluenceBlockColorHex.GetHashCode();
		}
		if (InfluenceEdgeColorHex.Length != 0)
		{
			hash ^= InfluenceEdgeColorHex.GetHashCode();
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
		if (Type != EAdventureParameterType.Normal)
		{
			output.WriteRawTag(16);
			output.WriteEnum((int)Type);
		}
		if (InitialValue != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(InitialValue);
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
		if (Style != 0)
		{
			output.WriteRawTag(112);
			output.WriteInt32(Style);
		}
		if (InfluenceBlockColorHex.Length != 0)
		{
			output.WriteRawTag(170, 1);
			output.WriteString(InfluenceBlockColorHex);
		}
		if (InfluenceEdgeColorHex.Length != 0)
		{
			output.WriteRawTag(178, 1);
			output.WriteString(InfluenceEdgeColorHex);
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
		if (Type != EAdventureParameterType.Normal)
		{
			size += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
		}
		if (InitialValue != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(InitialValue);
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
		if (Style != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(Style);
		}
		if (InfluenceBlockColorHex.Length != 0)
		{
			size += 2 + CodedOutputStream.ComputeStringSize(InfluenceBlockColorHex);
		}
		if (InfluenceEdgeColorHex.Length != 0)
		{
			size += 2 + CodedOutputStream.ComputeStringSize(InfluenceEdgeColorHex);
		}
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureParameterData other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Key.Length != 0)
		{
			Key = other.Key;
		}
		if (other.Type != EAdventureParameterType.Normal)
		{
			Type = other.Type;
		}
		if (other.InitialValue != 0)
		{
			InitialValue = other.InitialValue;
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
		if (other.Style != 0)
		{
			Style = other.Style;
		}
		if (other.InfluenceBlockColorHex.Length != 0)
		{
			InfluenceBlockColorHex = other.InfluenceBlockColorHex;
		}
		if (other.InfluenceEdgeColorHex.Length != 0)
		{
			InfluenceEdgeColorHex = other.InfluenceEdgeColorHex;
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
				Type = (EAdventureParameterType)input.ReadEnum();
				break;
			case 24u:
				InitialValue = input.ReadInt32();
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
			case 112u:
				Style = input.ReadInt32();
				break;
			case 170u:
				InfluenceBlockColorHex = input.ReadString();
				break;
			case 178u:
				InfluenceEdgeColorHex = input.ReadString();
				break;
			}
		}
	}
}
