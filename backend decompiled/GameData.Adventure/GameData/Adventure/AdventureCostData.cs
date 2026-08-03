using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureCostData : IMessage<AdventureCostData>, IMessage, IEquatable<AdventureCostData>, IDeepCloneable<AdventureCostData>, IBufferMessage
{
	private static readonly MessageParser<AdventureCostData> _parser = new MessageParser<AdventureCostData>(() => new AdventureCostData());

	private UnknownFieldSet _unknownFields;

	public const int CostTimeFieldNumber = 1;

	private int costTime_;

	public const int CostItemsFieldNumber = 2;

	private static readonly FieldCodec<AdventureCostItem> _repeated_costItems_codec = FieldCodec.ForMessage(18u, AdventureCostItem.Parser);

	private readonly RepeatedField<AdventureCostItem> costItems_ = new RepeatedField<AdventureCostItem>();

	public const int CostResourcesFieldNumber = 3;

	private static readonly FieldCodec<AdventureCostResource> _repeated_costResources_codec = FieldCodec.ForMessage(26u, AdventureCostResource.Parser);

	private readonly RepeatedField<AdventureCostResource> costResources_ = new RepeatedField<AdventureCostResource>();

	public const int CostExpFieldNumber = 4;

	private int costExp_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureCostData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[23];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int CostTime
	{
		get
		{
			return costTime_;
		}
		set
		{
			costTime_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureCostItem> CostItems => costItems_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureCostResource> CostResources => costResources_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int CostExp
	{
		get
		{
			return costExp_;
		}
		set
		{
			costExp_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCostData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCostData(AdventureCostData other)
		: this()
	{
		costTime_ = other.costTime_;
		costItems_ = other.costItems_.Clone();
		costResources_ = other.costResources_.Clone();
		costExp_ = other.costExp_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCostData Clone()
	{
		return new AdventureCostData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureCostData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureCostData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (CostTime != other.CostTime)
		{
			return false;
		}
		if (!costItems_.Equals(other.costItems_))
		{
			return false;
		}
		if (!costResources_.Equals(other.costResources_))
		{
			return false;
		}
		if (CostExp != other.CostExp)
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
		if (CostTime != 0)
		{
			hash ^= CostTime.GetHashCode();
		}
		hash ^= costItems_.GetHashCode();
		hash ^= costResources_.GetHashCode();
		if (CostExp != 0)
		{
			hash ^= CostExp.GetHashCode();
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
		if (CostTime != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(CostTime);
		}
		costItems_.WriteTo(ref output, _repeated_costItems_codec);
		costResources_.WriteTo(ref output, _repeated_costResources_codec);
		if (CostExp != 0)
		{
			output.WriteRawTag(32);
			output.WriteInt32(CostExp);
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
		if (CostTime != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(CostTime);
		}
		size += costItems_.CalculateSize(_repeated_costItems_codec);
		size += costResources_.CalculateSize(_repeated_costResources_codec);
		if (CostExp != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(CostExp);
		}
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureCostData other)
	{
		if (other != null)
		{
			if (other.CostTime != 0)
			{
				CostTime = other.CostTime;
			}
			costItems_.Add(other.costItems_);
			costResources_.Add(other.costResources_);
			if (other.CostExp != 0)
			{
				CostExp = other.CostExp;
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
			case 8u:
				CostTime = input.ReadInt32();
				break;
			case 18u:
				costItems_.AddEntriesFrom(ref input, _repeated_costItems_codec);
				break;
			case 26u:
				costResources_.AddEntriesFrom(ref input, _repeated_costResources_codec);
				break;
			case 32u:
				CostExp = input.ReadInt32();
				break;
			}
		}
	}
}
