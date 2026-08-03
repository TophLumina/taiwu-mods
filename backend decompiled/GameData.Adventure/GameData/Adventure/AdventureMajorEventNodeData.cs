using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureMajorEventNodeData : IMessage<AdventureMajorEventNodeData>, IMessage, IEquatable<AdventureMajorEventNodeData>, IDeepCloneable<AdventureMajorEventNodeData>, IBufferMessage
{
	private static readonly MessageParser<AdventureMajorEventNodeData> _parser = new MessageParser<AdventureMajorEventNodeData>(() => new AdventureMajorEventNodeData());

	private UnknownFieldSet _unknownFields;

	public const int TypeFieldNumber = 1;

	private EAdventureMajorEventNodeType type_;

	public const int XFieldNumber = 2;

	private float x_;

	public const int YFieldNumber = 3;

	private float y_;

	public const int KeyFieldNumber = 11;

	private string key_ = "";

	public const int NameForProtoFieldNumber = 12;

	private AdventureLocalStringRef nameForProto_;

	public const int DescForProtoFieldNumber = 13;

	private AdventureLocalStringRef descForProto_;

	public const int StyleFieldNumber = 14;

	private int style_;

	public const int AtmosphereTypeFieldNumber = 15;

	private int atmosphereType_;

	public const int EventGuidFieldNumber = 21;

	private string eventGuid_ = "";

	public const int EventTextureFieldNumber = 22;

	private string eventTexture_ = "";

	public const int NextNodesFieldNumber = 23;

	private static readonly FieldCodec<int> _repeated_nextNodes_codec = FieldCodec.ForInt32(186u);

	private readonly RepeatedField<int> nextNodes_ = new RepeatedField<int>();

	public const int RequirementsFieldNumber = 31;

	private AdventureMajorEventRequireData requirements_;

	public const int RewardsFieldNumber = 32;

	private static readonly FieldCodec<AdventureMajorEventRewardData> _repeated_rewards_codec = FieldCodec.ForMessage(258u, AdventureMajorEventRewardData.Parser);

	private readonly RepeatedField<AdventureMajorEventRewardData> rewards_ = new RepeatedField<AdventureMajorEventRewardData>();

	public string Name => NameForProto.Tr();

	public string Desc => DescForProto.Tr();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureMajorEventNodeData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[18];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EAdventureMajorEventNodeType Type
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
	public float X
	{
		get
		{
			return x_;
		}
		set
		{
			x_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public float Y
	{
		get
		{
			return y_;
		}
		set
		{
			y_ = value;
		}
	}

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
	public int AtmosphereType
	{
		get
		{
			return atmosphereType_;
		}
		set
		{
			atmosphereType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string EventGuid
	{
		get
		{
			return eventGuid_;
		}
		set
		{
			eventGuid_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string EventTexture
	{
		get
		{
			return eventTexture_;
		}
		set
		{
			eventTexture_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<int> NextNodes => nextNodes_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureMajorEventRequireData Requirements
	{
		get
		{
			return requirements_;
		}
		set
		{
			requirements_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureMajorEventRewardData> Rewards => rewards_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureMajorEventNodeData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureMajorEventNodeData(AdventureMajorEventNodeData other)
		: this()
	{
		type_ = other.type_;
		x_ = other.x_;
		y_ = other.y_;
		key_ = other.key_;
		nameForProto_ = ((other.nameForProto_ != null) ? other.nameForProto_.Clone() : null);
		descForProto_ = ((other.descForProto_ != null) ? other.descForProto_.Clone() : null);
		style_ = other.style_;
		atmosphereType_ = other.atmosphereType_;
		eventGuid_ = other.eventGuid_;
		eventTexture_ = other.eventTexture_;
		nextNodes_ = other.nextNodes_.Clone();
		requirements_ = ((other.requirements_ != null) ? other.requirements_.Clone() : null);
		rewards_ = other.rewards_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureMajorEventNodeData Clone()
	{
		return new AdventureMajorEventNodeData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureMajorEventNodeData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureMajorEventNodeData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Type != other.Type)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(X, other.X))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Y, other.Y))
		{
			return false;
		}
		if (Key != other.Key)
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
		if (Style != other.Style)
		{
			return false;
		}
		if (AtmosphereType != other.AtmosphereType)
		{
			return false;
		}
		if (EventGuid != other.EventGuid)
		{
			return false;
		}
		if (EventTexture != other.EventTexture)
		{
			return false;
		}
		if (!nextNodes_.Equals(other.nextNodes_))
		{
			return false;
		}
		if (!object.Equals(Requirements, other.Requirements))
		{
			return false;
		}
		if (!rewards_.Equals(other.rewards_))
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
		if (Type != EAdventureMajorEventNodeType.Start)
		{
			hash ^= Type.GetHashCode();
		}
		if (X != 0f)
		{
			hash ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(X);
		}
		if (Y != 0f)
		{
			hash ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Y);
		}
		if (Key.Length != 0)
		{
			hash ^= Key.GetHashCode();
		}
		if (nameForProto_ != null)
		{
			hash ^= NameForProto.GetHashCode();
		}
		if (descForProto_ != null)
		{
			hash ^= DescForProto.GetHashCode();
		}
		if (Style != 0)
		{
			hash ^= Style.GetHashCode();
		}
		if (AtmosphereType != 0)
		{
			hash ^= AtmosphereType.GetHashCode();
		}
		if (EventGuid.Length != 0)
		{
			hash ^= EventGuid.GetHashCode();
		}
		if (EventTexture.Length != 0)
		{
			hash ^= EventTexture.GetHashCode();
		}
		hash ^= nextNodes_.GetHashCode();
		if (requirements_ != null)
		{
			hash ^= Requirements.GetHashCode();
		}
		hash ^= rewards_.GetHashCode();
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
		if (Type != EAdventureMajorEventNodeType.Start)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Type);
		}
		if (X != 0f)
		{
			output.WriteRawTag(21);
			output.WriteFloat(X);
		}
		if (Y != 0f)
		{
			output.WriteRawTag(29);
			output.WriteFloat(Y);
		}
		if (Key.Length != 0)
		{
			output.WriteRawTag(90);
			output.WriteString(Key);
		}
		if (nameForProto_ != null)
		{
			output.WriteRawTag(98);
			output.WriteMessage(NameForProto);
		}
		if (descForProto_ != null)
		{
			output.WriteRawTag(106);
			output.WriteMessage(DescForProto);
		}
		if (Style != 0)
		{
			output.WriteRawTag(112);
			output.WriteInt32(Style);
		}
		if (AtmosphereType != 0)
		{
			output.WriteRawTag(120);
			output.WriteInt32(AtmosphereType);
		}
		if (EventGuid.Length != 0)
		{
			output.WriteRawTag(170, 1);
			output.WriteString(EventGuid);
		}
		if (EventTexture.Length != 0)
		{
			output.WriteRawTag(178, 1);
			output.WriteString(EventTexture);
		}
		nextNodes_.WriteTo(ref output, _repeated_nextNodes_codec);
		if (requirements_ != null)
		{
			output.WriteRawTag(250, 1);
			output.WriteMessage(Requirements);
		}
		rewards_.WriteTo(ref output, _repeated_rewards_codec);
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
		if (Type != EAdventureMajorEventNodeType.Start)
		{
			size += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
		}
		if (X != 0f)
		{
			size += 5;
		}
		if (Y != 0f)
		{
			size += 5;
		}
		if (Key.Length != 0)
		{
			size += 1 + CodedOutputStream.ComputeStringSize(Key);
		}
		if (nameForProto_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(NameForProto);
		}
		if (descForProto_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(DescForProto);
		}
		if (Style != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(Style);
		}
		if (AtmosphereType != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(AtmosphereType);
		}
		if (EventGuid.Length != 0)
		{
			size += 2 + CodedOutputStream.ComputeStringSize(EventGuid);
		}
		if (EventTexture.Length != 0)
		{
			size += 2 + CodedOutputStream.ComputeStringSize(EventTexture);
		}
		size += nextNodes_.CalculateSize(_repeated_nextNodes_codec);
		if (requirements_ != null)
		{
			size += 2 + CodedOutputStream.ComputeMessageSize(Requirements);
		}
		size += rewards_.CalculateSize(_repeated_rewards_codec);
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureMajorEventNodeData other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Type != EAdventureMajorEventNodeType.Start)
		{
			Type = other.Type;
		}
		if (other.X != 0f)
		{
			X = other.X;
		}
		if (other.Y != 0f)
		{
			Y = other.Y;
		}
		if (other.Key.Length != 0)
		{
			Key = other.Key;
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
		if (other.Style != 0)
		{
			Style = other.Style;
		}
		if (other.AtmosphereType != 0)
		{
			AtmosphereType = other.AtmosphereType;
		}
		if (other.EventGuid.Length != 0)
		{
			EventGuid = other.EventGuid;
		}
		if (other.EventTexture.Length != 0)
		{
			EventTexture = other.EventTexture;
		}
		nextNodes_.Add(other.nextNodes_);
		if (other.requirements_ != null)
		{
			if (requirements_ == null)
			{
				Requirements = new AdventureMajorEventRequireData();
			}
			Requirements.MergeFrom(other.Requirements);
		}
		rewards_.Add(other.rewards_);
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
			case 8u:
				Type = (EAdventureMajorEventNodeType)input.ReadEnum();
				break;
			case 21u:
				X = input.ReadFloat();
				break;
			case 29u:
				Y = input.ReadFloat();
				break;
			case 90u:
				Key = input.ReadString();
				break;
			case 98u:
				if (nameForProto_ == null)
				{
					NameForProto = new AdventureLocalStringRef();
				}
				input.ReadMessage(NameForProto);
				break;
			case 106u:
				if (descForProto_ == null)
				{
					DescForProto = new AdventureLocalStringRef();
				}
				input.ReadMessage(DescForProto);
				break;
			case 112u:
				Style = input.ReadInt32();
				break;
			case 120u:
				AtmosphereType = input.ReadInt32();
				break;
			case 170u:
				EventGuid = input.ReadString();
				break;
			case 178u:
				EventTexture = input.ReadString();
				break;
			case 184u:
			case 186u:
				nextNodes_.AddEntriesFrom(ref input, _repeated_nextNodes_codec);
				break;
			case 250u:
				if (requirements_ == null)
				{
					Requirements = new AdventureMajorEventRequireData();
				}
				input.ReadMessage(Requirements);
				break;
			case 258u:
				rewards_.AddEntriesFrom(ref input, _repeated_rewards_codec);
				break;
			}
		}
	}
}
