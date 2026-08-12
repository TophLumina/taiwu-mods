using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureElementData : IMessage<AdventureElementData>, IMessage, IEquatable<AdventureElementData>, IDeepCloneable<AdventureElementData>, IBufferMessage
{
	private static readonly MessageParser<AdventureElementData> _parser = new MessageParser<AdventureElementData>(() => new AdventureElementData());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private int id_;

	public const int NameForProtoFieldNumber = 2;

	private AdventureLocalStringRef nameForProto_;

	public const int DescForProtoFieldNumber = 3;

	private AdventureLocalStringRef descForProto_;

	public const int IconFieldNumber = 4;

	private string icon_ = "";

	public const int CreatingTypeFieldNumber = 5;

	private EAdventureElementCreatingType creatingType_;

	public const int CharacterIdFieldNumber = 6;

	private int characterId_;

	public const int CharacterDataFieldNumber = 7;

	private AdventureCharacterData characterData_;

	public const int CharacterKeyFieldNumber = 17;

	private string characterKey_ = "";

	public const int TimeCostFieldNumber = 8;

	private int timeCost_;

	public const int TagsFieldNumber = 9;

	private static readonly FieldCodec<string> _repeated_tags_codec = FieldCodec.ForString(74u);

	private readonly RepeatedField<string> tags_ = new RepeatedField<string>();

	public const int MoveDataFieldNumber = 10;

	private static readonly FieldCodec<AdventureElementMoveData> _repeated_moveData_codec = FieldCodec.ForMessage(82u, AdventureElementMoveData.Parser);

	private readonly RepeatedField<AdventureElementMoveData> moveData_ = new RepeatedField<AdventureElementMoveData>();

	public const int VisibleConditionFieldNumber = 11;

	private static readonly FieldCodec<AdventureElementVisibleData> _repeated_visibleCondition_codec = FieldCodec.ForMessage(90u, AdventureElementVisibleData.Parser);

	private readonly RepeatedField<AdventureElementVisibleData> visibleCondition_ = new RepeatedField<AdventureElementVisibleData>();

	public const int EventsFieldNumber = 12;

	private static readonly FieldCodec<AdventureElementEventData> _repeated_events_codec = FieldCodec.ForMessage(98u, AdventureElementEventData.Parser);

	private readonly RepeatedField<AdventureElementEventData> events_ = new RepeatedField<AdventureElementEventData>();

	public const int ParametersFieldNumber = 13;

	private static readonly FieldCodec<AdventureParameterData> _repeated_parameters_codec = FieldCodec.ForMessage(106u, AdventureParameterData.Parser);

	private readonly RepeatedField<AdventureParameterData> parameters_ = new RepeatedField<AdventureParameterData>();

	public const int VisiblePriorityFieldNumber = 14;

	private int visiblePriority_;

	public const int VisibleIgnoreSortingFieldNumber = 15;

	private bool visibleIgnoreSorting_;

	public const int LightDataForProtoFieldNumber = 16;

	private AdventureNullableLightData lightDataForProto_;

	public bool LightDataHasValue => LightDataForProto.HasValue;

	public AdventureLightData LightData
	{
		get
		{
			if (!LightDataForProto.HasValue)
			{
				return AdventureExternalBridge.LogException<AdventureLightData>(Id.ToString(), null);
			}
			return LightDataForProto.LightData;
		}
	}

	public string Name => NameForProto.Tr();

	public string Desc => DescForProto.Tr();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureElementData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[9];

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
	public EAdventureElementCreatingType CreatingType
	{
		get
		{
			return creatingType_;
		}
		set
		{
			creatingType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int CharacterId
	{
		get
		{
			return characterId_;
		}
		set
		{
			characterId_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCharacterData CharacterData
	{
		get
		{
			return characterData_;
		}
		set
		{
			characterData_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string CharacterKey
	{
		get
		{
			return characterKey_;
		}
		set
		{
			characterKey_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int TimeCost
	{
		get
		{
			return timeCost_;
		}
		set
		{
			timeCost_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<string> Tags => tags_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureElementMoveData> MoveData => moveData_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureElementVisibleData> VisibleCondition => visibleCondition_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureElementEventData> Events => events_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureParameterData> Parameters => parameters_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int VisiblePriority
	{
		get
		{
			return visiblePriority_;
		}
		set
		{
			visiblePriority_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool VisibleIgnoreSorting
	{
		get
		{
			return visibleIgnoreSorting_;
		}
		set
		{
			visibleIgnoreSorting_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureNullableLightData LightDataForProto
	{
		get
		{
			return lightDataForProto_;
		}
		set
		{
			lightDataForProto_ = value;
		}
	}

	public void Save(string path)
	{
		Save(path, this);
	}

	public static void Save(string path, AdventureElementData data)
	{
		using FileStream stream = new FileStream(path, FileMode.Create);
		using CodedOutputStream codedOutputStream = new CodedOutputStream(stream);
		codedOutputStream.Deterministic = true;
		data.WriteTo(codedOutputStream);
	}

	public static bool TryLoad(string path, out AdventureElementData data)
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
	public AdventureElementData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureElementData(AdventureElementData other)
		: this()
	{
		id_ = other.id_;
		nameForProto_ = ((other.nameForProto_ != null) ? other.nameForProto_.Clone() : null);
		descForProto_ = ((other.descForProto_ != null) ? other.descForProto_.Clone() : null);
		icon_ = other.icon_;
		creatingType_ = other.creatingType_;
		characterId_ = other.characterId_;
		characterData_ = ((other.characterData_ != null) ? other.characterData_.Clone() : null);
		characterKey_ = other.characterKey_;
		timeCost_ = other.timeCost_;
		tags_ = other.tags_.Clone();
		moveData_ = other.moveData_.Clone();
		visibleCondition_ = other.visibleCondition_.Clone();
		events_ = other.events_.Clone();
		parameters_ = other.parameters_.Clone();
		visiblePriority_ = other.visiblePriority_;
		visibleIgnoreSorting_ = other.visibleIgnoreSorting_;
		lightDataForProto_ = ((other.lightDataForProto_ != null) ? other.lightDataForProto_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureElementData Clone()
	{
		return new AdventureElementData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureElementData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureElementData other)
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
		if (CreatingType != other.CreatingType)
		{
			return false;
		}
		if (CharacterId != other.CharacterId)
		{
			return false;
		}
		if (!object.Equals(CharacterData, other.CharacterData))
		{
			return false;
		}
		if (CharacterKey != other.CharacterKey)
		{
			return false;
		}
		if (TimeCost != other.TimeCost)
		{
			return false;
		}
		if (!tags_.Equals(other.tags_))
		{
			return false;
		}
		if (!moveData_.Equals(other.moveData_))
		{
			return false;
		}
		if (!visibleCondition_.Equals(other.visibleCondition_))
		{
			return false;
		}
		if (!events_.Equals(other.events_))
		{
			return false;
		}
		if (!parameters_.Equals(other.parameters_))
		{
			return false;
		}
		if (VisiblePriority != other.VisiblePriority)
		{
			return false;
		}
		if (VisibleIgnoreSorting != other.VisibleIgnoreSorting)
		{
			return false;
		}
		if (!object.Equals(LightDataForProto, other.LightDataForProto))
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
		if (CreatingType != EAdventureElementCreatingType.Inherit)
		{
			hash ^= CreatingType.GetHashCode();
		}
		if (CharacterId != 0)
		{
			hash ^= CharacterId.GetHashCode();
		}
		if (characterData_ != null)
		{
			hash ^= CharacterData.GetHashCode();
		}
		if (CharacterKey.Length != 0)
		{
			hash ^= CharacterKey.GetHashCode();
		}
		if (TimeCost != 0)
		{
			hash ^= TimeCost.GetHashCode();
		}
		hash ^= tags_.GetHashCode();
		hash ^= moveData_.GetHashCode();
		hash ^= visibleCondition_.GetHashCode();
		hash ^= events_.GetHashCode();
		hash ^= parameters_.GetHashCode();
		if (VisiblePriority != 0)
		{
			hash ^= VisiblePriority.GetHashCode();
		}
		if (VisibleIgnoreSorting)
		{
			hash ^= VisibleIgnoreSorting.GetHashCode();
		}
		if (lightDataForProto_ != null)
		{
			hash ^= LightDataForProto.GetHashCode();
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
		if (Id != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(Id);
		}
		if (nameForProto_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(NameForProto);
		}
		if (descForProto_ != null)
		{
			output.WriteRawTag(26);
			output.WriteMessage(DescForProto);
		}
		if (Icon.Length != 0)
		{
			output.WriteRawTag(34);
			output.WriteString(Icon);
		}
		if (CreatingType != EAdventureElementCreatingType.Inherit)
		{
			output.WriteRawTag(40);
			output.WriteEnum((int)CreatingType);
		}
		if (CharacterId != 0)
		{
			output.WriteRawTag(48);
			output.WriteSInt32(CharacterId);
		}
		if (characterData_ != null)
		{
			output.WriteRawTag(58);
			output.WriteMessage(CharacterData);
		}
		if (TimeCost != 0)
		{
			output.WriteRawTag(64);
			output.WriteInt32(TimeCost);
		}
		tags_.WriteTo(ref output, _repeated_tags_codec);
		moveData_.WriteTo(ref output, _repeated_moveData_codec);
		visibleCondition_.WriteTo(ref output, _repeated_visibleCondition_codec);
		events_.WriteTo(ref output, _repeated_events_codec);
		parameters_.WriteTo(ref output, _repeated_parameters_codec);
		if (VisiblePriority != 0)
		{
			output.WriteRawTag(112);
			output.WriteInt32(VisiblePriority);
		}
		if (VisibleIgnoreSorting)
		{
			output.WriteRawTag(120);
			output.WriteBool(VisibleIgnoreSorting);
		}
		if (lightDataForProto_ != null)
		{
			output.WriteRawTag(130, 1);
			output.WriteMessage(LightDataForProto);
		}
		if (CharacterKey.Length != 0)
		{
			output.WriteRawTag(138, 1);
			output.WriteString(CharacterKey);
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
		if (Id != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(Id);
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
		if (CreatingType != EAdventureElementCreatingType.Inherit)
		{
			size += 1 + CodedOutputStream.ComputeEnumSize((int)CreatingType);
		}
		if (CharacterId != 0)
		{
			size += 1 + CodedOutputStream.ComputeSInt32Size(CharacterId);
		}
		if (characterData_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(CharacterData);
		}
		if (CharacterKey.Length != 0)
		{
			size += 2 + CodedOutputStream.ComputeStringSize(CharacterKey);
		}
		if (TimeCost != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(TimeCost);
		}
		size += tags_.CalculateSize(_repeated_tags_codec);
		size += moveData_.CalculateSize(_repeated_moveData_codec);
		size += visibleCondition_.CalculateSize(_repeated_visibleCondition_codec);
		size += events_.CalculateSize(_repeated_events_codec);
		size += parameters_.CalculateSize(_repeated_parameters_codec);
		if (VisiblePriority != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(VisiblePriority);
		}
		if (VisibleIgnoreSorting)
		{
			size += 2;
		}
		if (lightDataForProto_ != null)
		{
			size += 2 + CodedOutputStream.ComputeMessageSize(LightDataForProto);
		}
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureElementData other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Id != 0)
		{
			Id = other.Id;
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
		if (other.CreatingType != EAdventureElementCreatingType.Inherit)
		{
			CreatingType = other.CreatingType;
		}
		if (other.CharacterId != 0)
		{
			CharacterId = other.CharacterId;
		}
		if (other.characterData_ != null)
		{
			if (characterData_ == null)
			{
				CharacterData = new AdventureCharacterData();
			}
			CharacterData.MergeFrom(other.CharacterData);
		}
		if (other.CharacterKey.Length != 0)
		{
			CharacterKey = other.CharacterKey;
		}
		if (other.TimeCost != 0)
		{
			TimeCost = other.TimeCost;
		}
		tags_.Add(other.tags_);
		moveData_.Add(other.moveData_);
		visibleCondition_.Add(other.visibleCondition_);
		events_.Add(other.events_);
		parameters_.Add(other.parameters_);
		if (other.VisiblePriority != 0)
		{
			VisiblePriority = other.VisiblePriority;
		}
		if (other.VisibleIgnoreSorting)
		{
			VisibleIgnoreSorting = other.VisibleIgnoreSorting;
		}
		if (other.lightDataForProto_ != null)
		{
			if (lightDataForProto_ == null)
			{
				LightDataForProto = new AdventureNullableLightData();
			}
			LightDataForProto.MergeFrom(other.LightDataForProto);
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
			case 8u:
				Id = input.ReadInt32();
				break;
			case 18u:
				if (nameForProto_ == null)
				{
					NameForProto = new AdventureLocalStringRef();
				}
				input.ReadMessage(NameForProto);
				break;
			case 26u:
				if (descForProto_ == null)
				{
					DescForProto = new AdventureLocalStringRef();
				}
				input.ReadMessage(DescForProto);
				break;
			case 34u:
				Icon = input.ReadString();
				break;
			case 40u:
				CreatingType = (EAdventureElementCreatingType)input.ReadEnum();
				break;
			case 48u:
				CharacterId = input.ReadSInt32();
				break;
			case 58u:
				if (characterData_ == null)
				{
					CharacterData = new AdventureCharacterData();
				}
				input.ReadMessage(CharacterData);
				break;
			case 64u:
				TimeCost = input.ReadInt32();
				break;
			case 74u:
				tags_.AddEntriesFrom(ref input, _repeated_tags_codec);
				break;
			case 82u:
				moveData_.AddEntriesFrom(ref input, _repeated_moveData_codec);
				break;
			case 90u:
				visibleCondition_.AddEntriesFrom(ref input, _repeated_visibleCondition_codec);
				break;
			case 98u:
				events_.AddEntriesFrom(ref input, _repeated_events_codec);
				break;
			case 106u:
				parameters_.AddEntriesFrom(ref input, _repeated_parameters_codec);
				break;
			case 112u:
				VisiblePriority = input.ReadInt32();
				break;
			case 120u:
				VisibleIgnoreSorting = input.ReadBool();
				break;
			case 130u:
				if (lightDataForProto_ == null)
				{
					LightDataForProto = new AdventureNullableLightData();
				}
				input.ReadMessage(LightDataForProto);
				break;
			case 138u:
				CharacterKey = input.ReadString();
				break;
			}
		}
	}
}
