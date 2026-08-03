using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureMajorEventRewardData : IMessage<AdventureMajorEventRewardData>, IMessage, IEquatable<AdventureMajorEventRewardData>, IDeepCloneable<AdventureMajorEventRewardData>, IBufferMessage
{
	private static readonly MessageParser<AdventureMajorEventRewardData> _parser = new MessageParser<AdventureMajorEventRewardData>(() => new AdventureMajorEventRewardData());

	private UnknownFieldSet _unknownFields;

	public const int ItemFieldNumber = 1;

	private AdventureCostItem item_;

	public const int ResourceFieldNumber = 2;

	private AdventureResourceGroup resource_;

	public const int ExpFieldNumber = 21;

	private int exp_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureMajorEventRewardData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[20];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCostItem Item
	{
		get
		{
			return item_;
		}
		set
		{
			item_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureResourceGroup Resource
	{
		get
		{
			return resource_;
		}
		set
		{
			resource_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Exp
	{
		get
		{
			return exp_;
		}
		set
		{
			exp_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureMajorEventRewardData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureMajorEventRewardData(AdventureMajorEventRewardData other)
		: this()
	{
		item_ = ((other.item_ != null) ? other.item_.Clone() : null);
		resource_ = ((other.resource_ != null) ? other.resource_.Clone() : null);
		exp_ = other.exp_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureMajorEventRewardData Clone()
	{
		return new AdventureMajorEventRewardData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureMajorEventRewardData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureMajorEventRewardData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Item, other.Item))
		{
			return false;
		}
		if (!object.Equals(Resource, other.Resource))
		{
			return false;
		}
		if (Exp != other.Exp)
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
		if (item_ != null)
		{
			hash ^= Item.GetHashCode();
		}
		if (resource_ != null)
		{
			hash ^= Resource.GetHashCode();
		}
		if (Exp != 0)
		{
			hash ^= Exp.GetHashCode();
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
		if (item_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Item);
		}
		if (resource_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(Resource);
		}
		if (Exp != 0)
		{
			output.WriteRawTag(168, 1);
			output.WriteInt32(Exp);
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
		if (item_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(Item);
		}
		if (resource_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(Resource);
		}
		if (Exp != 0)
		{
			size += 2 + CodedOutputStream.ComputeInt32Size(Exp);
		}
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureMajorEventRewardData other)
	{
		if (other == null)
		{
			return;
		}
		if (other.item_ != null)
		{
			if (item_ == null)
			{
				Item = new AdventureCostItem();
			}
			Item.MergeFrom(other.Item);
		}
		if (other.resource_ != null)
		{
			if (resource_ == null)
			{
				Resource = new AdventureResourceGroup();
			}
			Resource.MergeFrom(other.Resource);
		}
		if (other.Exp != 0)
		{
			Exp = other.Exp;
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
				if (item_ == null)
				{
					Item = new AdventureCostItem();
				}
				input.ReadMessage(Item);
				break;
			case 18u:
				if (resource_ == null)
				{
					Resource = new AdventureResourceGroup();
				}
				input.ReadMessage(Resource);
				break;
			case 168u:
				Exp = input.ReadInt32();
				break;
			}
		}
	}
}
