using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureElementMoveData : IMessage<AdventureElementMoveData>, IMessage, IEquatable<AdventureElementMoveData>, IDeepCloneable<AdventureElementMoveData>, IBufferMessage
{
	private static readonly MessageParser<AdventureElementMoveData> _parser = new MessageParser<AdventureElementMoveData>(() => new AdventureElementMoveData());

	private UnknownFieldSet _unknownFields;

	public const int MoveSpeedFieldNumber = 1;

	private int moveSpeed_;

	public const int MoveConditionFieldNumber = 2;

	private InstructionCompiled moveCondition_;

	public const int MoveTypeFieldNumber = 3;

	private EAdventureElementMoveType moveType_;

	public const int TargetElementIdFieldNumber = 4;

	private int targetElementId_;

	public const int TargetTagsFieldNumber = 5;

	private static readonly FieldCodec<string> _repeated_targetTags_codec = FieldCodec.ForString(42u);

	private readonly RepeatedField<string> targetTags_ = new RepeatedField<string>();

	public const int TargetGroupIdsFieldNumber = 6;

	private static readonly FieldCodec<int> _repeated_targetGroupIds_codec = FieldCodec.ForInt32(50u);

	private readonly RepeatedField<int> targetGroupIds_ = new RepeatedField<int>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureElementMoveData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[10];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MoveSpeed
	{
		get
		{
			return moveSpeed_;
		}
		set
		{
			moveSpeed_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InstructionCompiled MoveCondition
	{
		get
		{
			return moveCondition_;
		}
		set
		{
			moveCondition_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EAdventureElementMoveType MoveType
	{
		get
		{
			return moveType_;
		}
		set
		{
			moveType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int TargetElementId
	{
		get
		{
			return targetElementId_;
		}
		set
		{
			targetElementId_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<string> TargetTags => targetTags_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<int> TargetGroupIds => targetGroupIds_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureElementMoveData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureElementMoveData(AdventureElementMoveData other)
		: this()
	{
		moveSpeed_ = other.moveSpeed_;
		moveCondition_ = ((other.moveCondition_ != null) ? other.moveCondition_.Clone() : null);
		moveType_ = other.moveType_;
		targetElementId_ = other.targetElementId_;
		targetTags_ = other.targetTags_.Clone();
		targetGroupIds_ = other.targetGroupIds_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureElementMoveData Clone()
	{
		return new AdventureElementMoveData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureElementMoveData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureElementMoveData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (MoveSpeed != other.MoveSpeed)
		{
			return false;
		}
		if (!object.Equals(MoveCondition, other.MoveCondition))
		{
			return false;
		}
		if (MoveType != other.MoveType)
		{
			return false;
		}
		if (TargetElementId != other.TargetElementId)
		{
			return false;
		}
		if (!targetTags_.Equals(other.targetTags_))
		{
			return false;
		}
		if (!targetGroupIds_.Equals(other.targetGroupIds_))
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
		if (MoveSpeed != 0)
		{
			hash ^= MoveSpeed.GetHashCode();
		}
		if (moveCondition_ != null)
		{
			hash ^= MoveCondition.GetHashCode();
		}
		if (MoveType != EAdventureElementMoveType.Static)
		{
			hash ^= MoveType.GetHashCode();
		}
		if (TargetElementId != 0)
		{
			hash ^= TargetElementId.GetHashCode();
		}
		hash ^= targetTags_.GetHashCode();
		hash ^= targetGroupIds_.GetHashCode();
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
		if (MoveSpeed != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(MoveSpeed);
		}
		if (moveCondition_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(MoveCondition);
		}
		if (MoveType != EAdventureElementMoveType.Static)
		{
			output.WriteRawTag(24);
			output.WriteEnum((int)MoveType);
		}
		if (TargetElementId != 0)
		{
			output.WriteRawTag(32);
			output.WriteInt32(TargetElementId);
		}
		targetTags_.WriteTo(ref output, _repeated_targetTags_codec);
		targetGroupIds_.WriteTo(ref output, _repeated_targetGroupIds_codec);
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
		if (MoveSpeed != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(MoveSpeed);
		}
		if (moveCondition_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(MoveCondition);
		}
		if (MoveType != EAdventureElementMoveType.Static)
		{
			size += 1 + CodedOutputStream.ComputeEnumSize((int)MoveType);
		}
		if (TargetElementId != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(TargetElementId);
		}
		size += targetTags_.CalculateSize(_repeated_targetTags_codec);
		size += targetGroupIds_.CalculateSize(_repeated_targetGroupIds_codec);
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureElementMoveData other)
	{
		if (other == null)
		{
			return;
		}
		if (other.MoveSpeed != 0)
		{
			MoveSpeed = other.MoveSpeed;
		}
		if (other.moveCondition_ != null)
		{
			if (moveCondition_ == null)
			{
				MoveCondition = new InstructionCompiled();
			}
			MoveCondition.MergeFrom(other.MoveCondition);
		}
		if (other.MoveType != EAdventureElementMoveType.Static)
		{
			MoveType = other.MoveType;
		}
		if (other.TargetElementId != 0)
		{
			TargetElementId = other.TargetElementId;
		}
		targetTags_.Add(other.targetTags_);
		targetGroupIds_.Add(other.targetGroupIds_);
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
				MoveSpeed = input.ReadInt32();
				break;
			case 18u:
				if (moveCondition_ == null)
				{
					MoveCondition = new InstructionCompiled();
				}
				input.ReadMessage(MoveCondition);
				break;
			case 24u:
				MoveType = (EAdventureElementMoveType)input.ReadEnum();
				break;
			case 32u:
				TargetElementId = input.ReadInt32();
				break;
			case 42u:
				targetTags_.AddEntriesFrom(ref input, _repeated_targetTags_codec);
				break;
			case 48u:
			case 50u:
				targetGroupIds_.AddEntriesFrom(ref input, _repeated_targetGroupIds_codec);
				break;
			}
		}
	}
}
