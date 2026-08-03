using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureCostItem : IMessage<AdventureCostItem>, IMessage, IEquatable<AdventureCostItem>, IDeepCloneable<AdventureCostItem>, IBufferMessage
{
	private static readonly MessageParser<AdventureCostItem> _parser = new MessageParser<AdventureCostItem>(() => new AdventureCostItem());

	private UnknownFieldSet _unknownFields;

	public const int AvailableItemsFieldNumber = 1;

	private static readonly FieldCodec<AdventureItemReference> _repeated_availableItems_codec = FieldCodec.ForMessage(10u, AdventureItemReference.Parser);

	private readonly RepeatedField<AdventureItemReference> availableItems_ = new RepeatedField<AdventureItemReference>();

	public const int NoCostFieldNumber = 2;

	private bool noCost_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureCostItem> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[24];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureItemReference> AvailableItems => availableItems_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool NoCost
	{
		get
		{
			return noCost_;
		}
		set
		{
			noCost_ = value;
		}
	}

	public bool Contains(sbyte itemType, short templateId)
	{
		RepeatedField<AdventureItemReference> availableItems = AvailableItems;
		if (availableItems == null || availableItems.Count <= 0)
		{
			return false;
		}
		foreach (AdventureItemReference availableItem in AvailableItems)
		{
			if (availableItem.Type == itemType && availableItem.TemplateId == templateId)
			{
				return true;
			}
		}
		return false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCostItem()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCostItem(AdventureCostItem other)
		: this()
	{
		availableItems_ = other.availableItems_.Clone();
		noCost_ = other.noCost_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCostItem Clone()
	{
		return new AdventureCostItem(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureCostItem);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureCostItem other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!availableItems_.Equals(other.availableItems_))
		{
			return false;
		}
		if (NoCost != other.NoCost)
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
		hash ^= availableItems_.GetHashCode();
		if (NoCost)
		{
			hash ^= NoCost.GetHashCode();
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
		availableItems_.WriteTo(ref output, _repeated_availableItems_codec);
		if (NoCost)
		{
			output.WriteRawTag(16);
			output.WriteBool(NoCost);
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
		size += availableItems_.CalculateSize(_repeated_availableItems_codec);
		if (NoCost)
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
	public void MergeFrom(AdventureCostItem other)
	{
		if (other != null)
		{
			availableItems_.Add(other.availableItems_);
			if (other.NoCost)
			{
				NoCost = other.NoCost;
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
				availableItems_.AddEntriesFrom(ref input, _repeated_availableItems_codec);
				break;
			case 16u:
				NoCost = input.ReadBool();
				break;
			}
		}
	}
}
