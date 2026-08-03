using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureGroupData : IMessage<AdventureGroupData>, IMessage, IEquatable<AdventureGroupData>, IDeepCloneable<AdventureGroupData>, IBufferMessage
{
	private static readonly MessageParser<AdventureGroupData> _parser = new MessageParser<AdventureGroupData>(() => new AdventureGroupData());

	private UnknownFieldSet _unknownFields;

	public const int BlocksFieldNumber = 1;

	private static readonly FieldCodec<AdventureBlockData> _repeated_blocks_codec = FieldCodec.ForMessage(10u, AdventureBlockData.Parser);

	private readonly RepeatedField<AdventureBlockData> blocks_ = new RepeatedField<AdventureBlockData>();

	public const int WeightFieldNumber = 2;

	private uint weight_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureGroupData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[2];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureBlockData> Blocks => blocks_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint Weight
	{
		get
		{
			return weight_;
		}
		set
		{
			weight_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureGroupData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureGroupData(AdventureGroupData other)
		: this()
	{
		blocks_ = other.blocks_.Clone();
		weight_ = other.weight_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureGroupData Clone()
	{
		return new AdventureGroupData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureGroupData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureGroupData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!blocks_.Equals(other.blocks_))
		{
			return false;
		}
		if (Weight != other.Weight)
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
		hash ^= blocks_.GetHashCode();
		if (Weight != 0)
		{
			hash ^= Weight.GetHashCode();
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
		blocks_.WriteTo(ref output, _repeated_blocks_codec);
		if (Weight != 0)
		{
			output.WriteRawTag(16);
			output.WriteUInt32(Weight);
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
		size += blocks_.CalculateSize(_repeated_blocks_codec);
		if (Weight != 0)
		{
			size += 1 + CodedOutputStream.ComputeUInt32Size(Weight);
		}
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureGroupData other)
	{
		if (other != null)
		{
			blocks_.Add(other.blocks_);
			if (other.Weight != 0)
			{
				Weight = other.Weight;
			}
			_unknownFields = UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
		}
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
				blocks_.AddEntriesFrom(ref input, _repeated_blocks_codec);
				break;
			case 16u:
				Weight = input.ReadUInt32();
				break;
			}
		}
	}
}
