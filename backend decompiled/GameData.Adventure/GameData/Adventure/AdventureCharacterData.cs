using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureCharacterData : IMessage<AdventureCharacterData>, IMessage, IEquatable<AdventureCharacterData>, IDeepCloneable<AdventureCharacterData>, IBufferMessage
{
	private static readonly MessageParser<AdventureCharacterData> _parser = new MessageParser<AdventureCharacterData>(() => new AdventureCharacterData());

	private UnknownFieldSet _unknownFields;

	public const int TypeFieldNumber = 1;

	private EAdventureCharacterType type_;

	public const int FilterRuleTemplateIdFieldNumber = 2;

	private int filterRuleTemplateId_;

	public const int SearchRangeTypeFieldNumber = 3;

	private int searchRangeType_;

	public CharacterFilterKey FilterKey => new CharacterFilterKey((short)FilterRuleTemplateId, (sbyte)SearchRangeType);

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureCharacterData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[12];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public EAdventureCharacterType Type
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
	public int FilterRuleTemplateId
	{
		get
		{
			return filterRuleTemplateId_;
		}
		set
		{
			filterRuleTemplateId_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int SearchRangeType
	{
		get
		{
			return searchRangeType_;
		}
		set
		{
			searchRangeType_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCharacterData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCharacterData(AdventureCharacterData other)
		: this()
	{
		type_ = other.type_;
		filterRuleTemplateId_ = other.filterRuleTemplateId_;
		searchRangeType_ = other.searchRangeType_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCharacterData Clone()
	{
		return new AdventureCharacterData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureCharacterData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureCharacterData other)
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
		if (FilterRuleTemplateId != other.FilterRuleTemplateId)
		{
			return false;
		}
		if (SearchRangeType != other.SearchRangeType)
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
		if (Type != EAdventureCharacterType.Invalid)
		{
			hash ^= Type.GetHashCode();
		}
		if (FilterRuleTemplateId != 0)
		{
			hash ^= FilterRuleTemplateId.GetHashCode();
		}
		if (SearchRangeType != 0)
		{
			hash ^= SearchRangeType.GetHashCode();
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
		if (Type != EAdventureCharacterType.Invalid)
		{
			output.WriteRawTag(8);
			output.WriteEnum((int)Type);
		}
		if (FilterRuleTemplateId != 0)
		{
			output.WriteRawTag(16);
			output.WriteSInt32(FilterRuleTemplateId);
		}
		if (SearchRangeType != 0)
		{
			output.WriteRawTag(24);
			output.WriteSInt32(SearchRangeType);
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
		if (Type != EAdventureCharacterType.Invalid)
		{
			size += 1 + CodedOutputStream.ComputeEnumSize((int)Type);
		}
		if (FilterRuleTemplateId != 0)
		{
			size += 1 + CodedOutputStream.ComputeSInt32Size(FilterRuleTemplateId);
		}
		if (SearchRangeType != 0)
		{
			size += 1 + CodedOutputStream.ComputeSInt32Size(SearchRangeType);
		}
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureCharacterData other)
	{
		if (other != null)
		{
			if (other.Type != EAdventureCharacterType.Invalid)
			{
				Type = other.Type;
			}
			if (other.FilterRuleTemplateId != 0)
			{
				FilterRuleTemplateId = other.FilterRuleTemplateId;
			}
			if (other.SearchRangeType != 0)
			{
				SearchRangeType = other.SearchRangeType;
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
				Type = (EAdventureCharacterType)input.ReadEnum();
				break;
			case 16u:
				FilterRuleTemplateId = input.ReadSInt32();
				break;
			case 24u:
				SearchRangeType = input.ReadSInt32();
				break;
			}
		}
	}
}
