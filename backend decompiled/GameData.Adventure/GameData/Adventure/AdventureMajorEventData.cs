using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureMajorEventData : IAdventureData, IMessage<AdventureMajorEventData>, IMessage, IEquatable<AdventureMajorEventData>, IDeepCloneable<AdventureMajorEventData>, IBufferMessage
{
	private static readonly MessageParser<AdventureMajorEventData> _parser = new MessageParser<AdventureMajorEventData>(() => new AdventureMajorEventData());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private int id_;

	public const int CostFieldNumber = 2;

	private AdventureCostData cost_;

	public const int NodesFieldNumber = 3;

	private static readonly FieldCodec<AdventureMajorEventNodeData> _repeated_nodes_codec = FieldCodec.ForMessage(26u, AdventureMajorEventNodeData.Parser);

	private readonly RepeatedField<AdventureMajorEventNodeData> nodes_ = new RepeatedField<AdventureMajorEventNodeData>();

	public const int ParametersFieldNumber = 4;

	private static readonly FieldCodec<AdventureParameterData> _repeated_parameters_codec = FieldCodec.ForMessage(34u, AdventureParameterData.Parser);

	private readonly RepeatedField<AdventureParameterData> parameters_ = new RepeatedField<AdventureParameterData>();

	public const int CharactersFieldNumber = 5;

	private static readonly FieldCodec<AdventureCharacterGroup> _repeated_characters_codec = FieldCodec.ForMessage(42u, AdventureCharacterGroup.Parser);

	private readonly RepeatedField<AdventureCharacterGroup> characters_ = new RepeatedField<AdventureCharacterGroup>();

	public const int StayMonthsFieldNumber = 6;

	private uint stayMonths_;

	public const int ReleasedFieldNumber = 7;

	private bool released_;

	public const int NameForProtoFieldNumber = 11;

	private AdventureLocalStringRef nameForProto_;

	public const int DescForProtoFieldNumber = 12;

	private AdventureLocalStringRef descForProto_;

	public const int DecorationsFieldNumber = 13;

	private static readonly FieldCodec<AdventureMajorEventDecorationData> _repeated_decorations_codec = FieldCodec.ForMessage(106u, AdventureMajorEventDecorationData.Parser);

	private readonly RepeatedField<AdventureMajorEventDecorationData> decorations_ = new RepeatedField<AdventureMajorEventDecorationData>();

	public const int EventTextureFieldNumber = 14;

	private string eventTexture_ = "";

	public const int ActiveActionFieldNumber = 21;

	private InstructionCompiled activeAction_;

	public const int RemoveActionFieldNumber = 22;

	private InstructionCompiled removeAction_;

	public const int TagsFieldNumber = 31;

	private static readonly FieldCodec<EAdventureTag> _repeated_tags_codec = FieldCodec.ForEnum(250u, (EAdventureTag x) => (int)x, (int x) => (EAdventureTag)x);

	private readonly RepeatedField<EAdventureTag> tags_ = new RepeatedField<EAdventureTag>();

	string IAdventureData.Name => Name;

	string IAdventureData.Desc => Desc;

	IReadOnlyList<EAdventureTag> IAdventureData.Tags => Tags;

	public string Name => NameForProto.Tr();

	public string Desc => DescForProto.Tr();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureMajorEventData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[17];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Id
	{
		get
		{
			return id_;
		}
		set
		{
			id_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCostData Cost
	{
		get
		{
			return cost_;
		}
		set
		{
			cost_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureMajorEventNodeData> Nodes => nodes_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureParameterData> Parameters => parameters_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureCharacterGroup> Characters => characters_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint StayMonths
	{
		get
		{
			return stayMonths_;
		}
		set
		{
			stayMonths_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Released
	{
		get
		{
			return released_;
		}
		set
		{
			released_ = value;
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
	public RepeatedField<AdventureMajorEventDecorationData> Decorations => decorations_;

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
	public InstructionCompiled ActiveAction
	{
		get
		{
			return activeAction_;
		}
		set
		{
			activeAction_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InstructionCompiled RemoveAction
	{
		get
		{
			return removeAction_;
		}
		set
		{
			removeAction_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<EAdventureTag> Tags => tags_;

	public void Save(string path)
	{
		Save(path, this);
	}

	public static void Save(string path, AdventureMajorEventData data)
	{
		using FileStream stream = new FileStream(path, FileMode.Create);
		using CodedOutputStream codedOutputStream = new CodedOutputStream(stream);
		codedOutputStream.Deterministic = true;
		data.WriteTo(codedOutputStream);
	}

	public static bool TryLoad(string path, out AdventureMajorEventData data)
	{
		data = null;
		if (!File.Exists(path))
		{
			return false;
		}
		using FileStream input = File.OpenRead(path);
		data = Parser.ParseFrom(input);
		return data != null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureMajorEventData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureMajorEventData(AdventureMajorEventData other)
		: this()
	{
		id_ = other.id_;
		cost_ = ((other.cost_ != null) ? other.cost_.Clone() : null);
		nodes_ = other.nodes_.Clone();
		parameters_ = other.parameters_.Clone();
		characters_ = other.characters_.Clone();
		stayMonths_ = other.stayMonths_;
		released_ = other.released_;
		nameForProto_ = ((other.nameForProto_ != null) ? other.nameForProto_.Clone() : null);
		descForProto_ = ((other.descForProto_ != null) ? other.descForProto_.Clone() : null);
		decorations_ = other.decorations_.Clone();
		eventTexture_ = other.eventTexture_;
		activeAction_ = ((other.activeAction_ != null) ? other.activeAction_.Clone() : null);
		removeAction_ = ((other.removeAction_ != null) ? other.removeAction_.Clone() : null);
		tags_ = other.tags_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureMajorEventData Clone()
	{
		return new AdventureMajorEventData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureMajorEventData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureMajorEventData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Id != other.Id)
		{
			return false;
		}
		if (!object.Equals(Cost, other.Cost))
		{
			return false;
		}
		if (!nodes_.Equals(other.nodes_))
		{
			return false;
		}
		if (!parameters_.Equals(other.parameters_))
		{
			return false;
		}
		if (!characters_.Equals(other.characters_))
		{
			return false;
		}
		if (StayMonths != other.StayMonths)
		{
			return false;
		}
		if (Released != other.Released)
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
		if (!decorations_.Equals(other.decorations_))
		{
			return false;
		}
		if (EventTexture != other.EventTexture)
		{
			return false;
		}
		if (!object.Equals(ActiveAction, other.ActiveAction))
		{
			return false;
		}
		if (!object.Equals(RemoveAction, other.RemoveAction))
		{
			return false;
		}
		if (!tags_.Equals(other.tags_))
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
		if (Id != 0)
		{
			hash ^= Id.GetHashCode();
		}
		if (cost_ != null)
		{
			hash ^= Cost.GetHashCode();
		}
		hash ^= nodes_.GetHashCode();
		hash ^= parameters_.GetHashCode();
		hash ^= characters_.GetHashCode();
		if (StayMonths != 0)
		{
			hash ^= StayMonths.GetHashCode();
		}
		if (Released)
		{
			hash ^= Released.GetHashCode();
		}
		if (nameForProto_ != null)
		{
			hash ^= NameForProto.GetHashCode();
		}
		if (descForProto_ != null)
		{
			hash ^= DescForProto.GetHashCode();
		}
		hash ^= decorations_.GetHashCode();
		if (EventTexture.Length != 0)
		{
			hash ^= EventTexture.GetHashCode();
		}
		if (activeAction_ != null)
		{
			hash ^= ActiveAction.GetHashCode();
		}
		if (removeAction_ != null)
		{
			hash ^= RemoveAction.GetHashCode();
		}
		hash ^= tags_.GetHashCode();
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
		if (Id != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(Id);
		}
		if (cost_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Cost);
		}
		nodes_.WriteTo(ref output, _repeated_nodes_codec);
		parameters_.WriteTo(ref output, _repeated_parameters_codec);
		characters_.WriteTo(ref output, _repeated_characters_codec);
		if (StayMonths != 0)
		{
			output.WriteRawTag(48);
			output.WriteUInt32(StayMonths);
		}
		if (Released)
		{
			output.WriteRawTag(56);
			output.WriteBool(Released);
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
		decorations_.WriteTo(ref output, _repeated_decorations_codec);
		if (EventTexture.Length != 0)
		{
			output.WriteRawTag(114);
			output.WriteString(EventTexture);
		}
		if (activeAction_ != null)
		{
			output.WriteRawTag(170, 1);
			output.WriteMessage(ActiveAction);
		}
		if (removeAction_ != null)
		{
			output.WriteRawTag(178, 1);
			output.WriteMessage(RemoveAction);
		}
		tags_.WriteTo(ref output, _repeated_tags_codec);
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
		if (Id != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(Id);
		}
		if (cost_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(Cost);
		}
		size += nodes_.CalculateSize(_repeated_nodes_codec);
		size += parameters_.CalculateSize(_repeated_parameters_codec);
		size += characters_.CalculateSize(_repeated_characters_codec);
		if (StayMonths != 0)
		{
			size += 1 + CodedOutputStream.ComputeUInt32Size(StayMonths);
		}
		if (Released)
		{
			size += 2;
		}
		if (nameForProto_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(NameForProto);
		}
		if (descForProto_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(DescForProto);
		}
		size += decorations_.CalculateSize(_repeated_decorations_codec);
		if (EventTexture.Length != 0)
		{
			size += 1 + CodedOutputStream.ComputeStringSize(EventTexture);
		}
		if (activeAction_ != null)
		{
			size += 2 + CodedOutputStream.ComputeMessageSize(ActiveAction);
		}
		if (removeAction_ != null)
		{
			size += 2 + CodedOutputStream.ComputeMessageSize(RemoveAction);
		}
		size += tags_.CalculateSize(_repeated_tags_codec);
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureMajorEventData other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Id != 0)
		{
			Id = other.Id;
		}
		if (other.cost_ != null)
		{
			if (cost_ == null)
			{
				Cost = new AdventureCostData();
			}
			Cost.MergeFrom(other.Cost);
		}
		nodes_.Add(other.nodes_);
		parameters_.Add(other.parameters_);
		characters_.Add(other.characters_);
		if (other.StayMonths != 0)
		{
			StayMonths = other.StayMonths;
		}
		if (other.Released)
		{
			Released = other.Released;
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
		decorations_.Add(other.decorations_);
		if (other.EventTexture.Length != 0)
		{
			EventTexture = other.EventTexture;
		}
		if (other.activeAction_ != null)
		{
			if (activeAction_ == null)
			{
				ActiveAction = new InstructionCompiled();
			}
			ActiveAction.MergeFrom(other.ActiveAction);
		}
		if (other.removeAction_ != null)
		{
			if (removeAction_ == null)
			{
				RemoveAction = new InstructionCompiled();
			}
			RemoveAction.MergeFrom(other.RemoveAction);
		}
		tags_.Add(other.tags_);
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
				Id = input.ReadInt32();
				break;
			case 18u:
				if (cost_ == null)
				{
					Cost = new AdventureCostData();
				}
				input.ReadMessage(Cost);
				break;
			case 26u:
				nodes_.AddEntriesFrom(ref input, _repeated_nodes_codec);
				break;
			case 34u:
				parameters_.AddEntriesFrom(ref input, _repeated_parameters_codec);
				break;
			case 42u:
				characters_.AddEntriesFrom(ref input, _repeated_characters_codec);
				break;
			case 48u:
				StayMonths = input.ReadUInt32();
				break;
			case 56u:
				Released = input.ReadBool();
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
				decorations_.AddEntriesFrom(ref input, _repeated_decorations_codec);
				break;
			case 114u:
				EventTexture = input.ReadString();
				break;
			case 170u:
				if (activeAction_ == null)
				{
					ActiveAction = new InstructionCompiled();
				}
				input.ReadMessage(ActiveAction);
				break;
			case 178u:
				if (removeAction_ == null)
				{
					RemoveAction = new InstructionCompiled();
				}
				input.ReadMessage(RemoveAction);
				break;
			case 248u:
			case 250u:
				tags_.AddEntriesFrom(ref input, _repeated_tags_codec);
				break;
			}
		}
	}
}
