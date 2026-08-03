using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureBlockData : IMessage<AdventureBlockData>, IMessage, IEquatable<AdventureBlockData>, IDeepCloneable<AdventureBlockData>, IBufferMessage
{
	private AdventureBlockIndex? _cachedIndex;

	private static readonly MessageParser<AdventureBlockData> _parser = new MessageParser<AdventureBlockData>(() => new AdventureBlockData());

	private UnknownFieldSet _unknownFields;

	public const int IndexForProtoFieldNumber = 1;

	private AdventureBlockIndexForProto indexForProto_;

	public const int TimeCostFieldNumber = 2;

	private int timeCost_;

	public const int ElementCoreIdsFieldNumber = 3;

	private static readonly FieldCodec<int> _repeated_elementCoreIds_codec = FieldCodec.ForInt32(26u);

	private readonly RepeatedField<int> elementCoreIds_ = new RepeatedField<int>();

	public const int GroupIdsFieldNumber = 4;

	private static readonly FieldCodec<int> _repeated_groupIds_codec = FieldCodec.ForInt32(34u);

	private readonly RepeatedField<int> groupIds_ = new RepeatedField<int>();

	public const int BlockTypeFieldNumber = 11;

	private EAdventureBlockType blockType_;

	public const int EntryPriorityFieldNumber = 12;

	private int entryPriority_;

	public const int EnterConditionFieldNumber = 13;

	private InstructionCompiled enterCondition_;

	public const int ExitConditionFieldNumber = 14;

	private InstructionCompiled exitCondition_;

	public const int PassableConditionFieldNumber = 15;

	private InstructionCompiled passableCondition_;

	public const int HeightFieldNumber = 21;

	private float height_;

	public const int IconFieldNumber = 22;

	private string icon_ = "";

	public const int DecoratesFieldNumber = 23;

	private static readonly FieldCodec<string> _repeated_decorates_codec = FieldCodec.ForString(186u);

	private readonly RepeatedField<string> decorates_ = new RepeatedField<string>();

	public const int InCloudFieldNumber = 24;

	private bool inCloud_;

	public AdventureBlockIndex Index
	{
		get
		{
			AdventureBlockIndex valueOrDefault = _cachedIndex.GetValueOrDefault();
			if (!_cachedIndex.HasValue)
			{
				valueOrDefault = IndexForProto;
				_cachedIndex = valueOrDefault;
				return valueOrDefault;
			}
			return valueOrDefault;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureBlockData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[3];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureBlockIndexForProto IndexForProto
	{
		get
		{
			return indexForProto_;
		}
		set
		{
			indexForProto_ = value;
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
	public RepeatedField<int> ElementCoreIds => elementCoreIds_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<int> GroupIds => groupIds_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EAdventureBlockType BlockType
	{
		get
		{
			return blockType_;
		}
		set
		{
			blockType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int EntryPriority
	{
		get
		{
			return entryPriority_;
		}
		set
		{
			entryPriority_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InstructionCompiled EnterCondition
	{
		get
		{
			return enterCondition_;
		}
		set
		{
			enterCondition_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InstructionCompiled ExitCondition
	{
		get
		{
			return exitCondition_;
		}
		set
		{
			exitCondition_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InstructionCompiled PassableCondition
	{
		get
		{
			return passableCondition_;
		}
		set
		{
			passableCondition_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public float Height
	{
		get
		{
			return height_;
		}
		set
		{
			height_ = value;
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
	public RepeatedField<string> Decorates => decorates_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool InCloud
	{
		get
		{
			return inCloud_;
		}
		set
		{
			inCloud_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureBlockData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureBlockData(AdventureBlockData other)
		: this()
	{
		indexForProto_ = ((other.indexForProto_ != null) ? other.indexForProto_.Clone() : null);
		timeCost_ = other.timeCost_;
		elementCoreIds_ = other.elementCoreIds_.Clone();
		groupIds_ = other.groupIds_.Clone();
		blockType_ = other.blockType_;
		entryPriority_ = other.entryPriority_;
		enterCondition_ = ((other.enterCondition_ != null) ? other.enterCondition_.Clone() : null);
		exitCondition_ = ((other.exitCondition_ != null) ? other.exitCondition_.Clone() : null);
		passableCondition_ = ((other.passableCondition_ != null) ? other.passableCondition_.Clone() : null);
		height_ = other.height_;
		icon_ = other.icon_;
		decorates_ = other.decorates_.Clone();
		inCloud_ = other.inCloud_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureBlockData Clone()
	{
		return new AdventureBlockData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureBlockData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureBlockData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(IndexForProto, other.IndexForProto))
		{
			return false;
		}
		if (TimeCost != other.TimeCost)
		{
			return false;
		}
		if (!elementCoreIds_.Equals(other.elementCoreIds_))
		{
			return false;
		}
		if (!groupIds_.Equals(other.groupIds_))
		{
			return false;
		}
		if (BlockType != other.BlockType)
		{
			return false;
		}
		if (EntryPriority != other.EntryPriority)
		{
			return false;
		}
		if (!object.Equals(EnterCondition, other.EnterCondition))
		{
			return false;
		}
		if (!object.Equals(ExitCondition, other.ExitCondition))
		{
			return false;
		}
		if (!object.Equals(PassableCondition, other.PassableCondition))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Height, other.Height))
		{
			return false;
		}
		if (Icon != other.Icon)
		{
			return false;
		}
		if (!decorates_.Equals(other.decorates_))
		{
			return false;
		}
		if (InCloud != other.InCloud)
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
		if (indexForProto_ != null)
		{
			hash ^= IndexForProto.GetHashCode();
		}
		if (TimeCost != 0)
		{
			hash ^= TimeCost.GetHashCode();
		}
		hash ^= elementCoreIds_.GetHashCode();
		hash ^= groupIds_.GetHashCode();
		if (BlockType != EAdventureBlockType.None)
		{
			hash ^= BlockType.GetHashCode();
		}
		if (EntryPriority != 0)
		{
			hash ^= EntryPriority.GetHashCode();
		}
		if (enterCondition_ != null)
		{
			hash ^= EnterCondition.GetHashCode();
		}
		if (exitCondition_ != null)
		{
			hash ^= ExitCondition.GetHashCode();
		}
		if (passableCondition_ != null)
		{
			hash ^= PassableCondition.GetHashCode();
		}
		if (Height != 0f)
		{
			hash ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Height);
		}
		if (Icon.Length != 0)
		{
			hash ^= Icon.GetHashCode();
		}
		hash ^= decorates_.GetHashCode();
		if (InCloud)
		{
			hash ^= InCloud.GetHashCode();
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
		if (indexForProto_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(IndexForProto);
		}
		if (TimeCost != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(TimeCost);
		}
		elementCoreIds_.WriteTo(ref output, _repeated_elementCoreIds_codec);
		groupIds_.WriteTo(ref output, _repeated_groupIds_codec);
		if (BlockType != EAdventureBlockType.None)
		{
			output.WriteRawTag(88);
			output.WriteEnum((int)BlockType);
		}
		if (EntryPriority != 0)
		{
			output.WriteRawTag(96);
			output.WriteInt32(EntryPriority);
		}
		if (enterCondition_ != null)
		{
			output.WriteRawTag(106);
			output.WriteMessage(EnterCondition);
		}
		if (exitCondition_ != null)
		{
			output.WriteRawTag(114);
			output.WriteMessage(ExitCondition);
		}
		if (passableCondition_ != null)
		{
			output.WriteRawTag(122);
			output.WriteMessage(PassableCondition);
		}
		if (Height != 0f)
		{
			output.WriteRawTag(173, 1);
			output.WriteFloat(Height);
		}
		if (Icon.Length != 0)
		{
			output.WriteRawTag(178, 1);
			output.WriteString(Icon);
		}
		decorates_.WriteTo(ref output, _repeated_decorates_codec);
		if (InCloud)
		{
			output.WriteRawTag(192, 1);
			output.WriteBool(InCloud);
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
		if (indexForProto_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(IndexForProto);
		}
		if (TimeCost != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(TimeCost);
		}
		size += elementCoreIds_.CalculateSize(_repeated_elementCoreIds_codec);
		size += groupIds_.CalculateSize(_repeated_groupIds_codec);
		if (BlockType != EAdventureBlockType.None)
		{
			size += 1 + CodedOutputStream.ComputeEnumSize((int)BlockType);
		}
		if (EntryPriority != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(EntryPriority);
		}
		if (enterCondition_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(EnterCondition);
		}
		if (exitCondition_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(ExitCondition);
		}
		if (passableCondition_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(PassableCondition);
		}
		if (Height != 0f)
		{
			size += 6;
		}
		if (Icon.Length != 0)
		{
			size += 2 + CodedOutputStream.ComputeStringSize(Icon);
		}
		size += decorates_.CalculateSize(_repeated_decorates_codec);
		if (InCloud)
		{
			size += 3;
		}
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureBlockData other)
	{
		if (other == null)
		{
			return;
		}
		if (other.indexForProto_ != null)
		{
			if (indexForProto_ == null)
			{
				IndexForProto = new AdventureBlockIndexForProto();
			}
			IndexForProto.MergeFrom(other.IndexForProto);
		}
		if (other.TimeCost != 0)
		{
			TimeCost = other.TimeCost;
		}
		elementCoreIds_.Add(other.elementCoreIds_);
		groupIds_.Add(other.groupIds_);
		if (other.BlockType != EAdventureBlockType.None)
		{
			BlockType = other.BlockType;
		}
		if (other.EntryPriority != 0)
		{
			EntryPriority = other.EntryPriority;
		}
		if (other.enterCondition_ != null)
		{
			if (enterCondition_ == null)
			{
				EnterCondition = new InstructionCompiled();
			}
			EnterCondition.MergeFrom(other.EnterCondition);
		}
		if (other.exitCondition_ != null)
		{
			if (exitCondition_ == null)
			{
				ExitCondition = new InstructionCompiled();
			}
			ExitCondition.MergeFrom(other.ExitCondition);
		}
		if (other.passableCondition_ != null)
		{
			if (passableCondition_ == null)
			{
				PassableCondition = new InstructionCompiled();
			}
			PassableCondition.MergeFrom(other.PassableCondition);
		}
		if (other.Height != 0f)
		{
			Height = other.Height;
		}
		if (other.Icon.Length != 0)
		{
			Icon = other.Icon;
		}
		decorates_.Add(other.decorates_);
		if (other.InCloud)
		{
			InCloud = other.InCloud;
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
				if (indexForProto_ == null)
				{
					IndexForProto = new AdventureBlockIndexForProto();
				}
				input.ReadMessage(IndexForProto);
				break;
			case 16u:
				TimeCost = input.ReadInt32();
				break;
			case 24u:
			case 26u:
				elementCoreIds_.AddEntriesFrom(ref input, _repeated_elementCoreIds_codec);
				break;
			case 32u:
			case 34u:
				groupIds_.AddEntriesFrom(ref input, _repeated_groupIds_codec);
				break;
			case 88u:
				BlockType = (EAdventureBlockType)input.ReadEnum();
				break;
			case 96u:
				EntryPriority = input.ReadInt32();
				break;
			case 106u:
				if (enterCondition_ == null)
				{
					EnterCondition = new InstructionCompiled();
				}
				input.ReadMessage(EnterCondition);
				break;
			case 114u:
				if (exitCondition_ == null)
				{
					ExitCondition = new InstructionCompiled();
				}
				input.ReadMessage(ExitCondition);
				break;
			case 122u:
				if (passableCondition_ == null)
				{
					PassableCondition = new InstructionCompiled();
				}
				input.ReadMessage(PassableCondition);
				break;
			case 173u:
				Height = input.ReadFloat();
				break;
			case 178u:
				Icon = input.ReadString();
				break;
			case 186u:
				decorates_.AddEntriesFrom(ref input, _repeated_decorates_codec);
				break;
			case 192u:
				InCloud = input.ReadBool();
				break;
			}
		}
	}
}
