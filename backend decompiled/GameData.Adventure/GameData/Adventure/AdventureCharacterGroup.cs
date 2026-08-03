using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureCharacterGroup : IMessage<AdventureCharacterGroup>, IMessage, IEquatable<AdventureCharacterGroup>, IDeepCloneable<AdventureCharacterGroup>, IBufferMessage
{
	private static readonly MessageParser<AdventureCharacterGroup> _parser = new MessageParser<AdventureCharacterGroup>(() => new AdventureCharacterGroup());

	private UnknownFieldSet _unknownFields;

	public const int DataFieldNumber = 1;

	private AdventureCharacterData data_;

	public const int CountFieldNumber = 2;

	private int count_;

	public const int MajorFieldNumber = 3;

	private bool major_;

	public const int StayIndexFieldNumber = 4;

	private bool stayIndex_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureCharacterGroup> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[13];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCharacterData Data
	{
		get
		{
			return data_;
		}
		set
		{
			data_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Count
	{
		get
		{
			return count_;
		}
		set
		{
			count_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Major
	{
		get
		{
			return major_;
		}
		set
		{
			major_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool StayIndex
	{
		get
		{
			return stayIndex_;
		}
		set
		{
			stayIndex_ = value;
		}
	}

	public void HandleIndex(ref int index, ref int subIndex)
	{
		if (!StayIndex)
		{
			index++;
			subIndex = 0;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCharacterGroup()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCharacterGroup(AdventureCharacterGroup other)
		: this()
	{
		data_ = ((other.data_ != null) ? other.data_.Clone() : null);
		count_ = other.count_;
		major_ = other.major_;
		stayIndex_ = other.stayIndex_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCharacterGroup Clone()
	{
		return new AdventureCharacterGroup(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureCharacterGroup);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureCharacterGroup other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(Data, other.Data))
		{
			return false;
		}
		if (Count != other.Count)
		{
			return false;
		}
		if (Major != other.Major)
		{
			return false;
		}
		if (StayIndex != other.StayIndex)
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
		if (data_ != null)
		{
			hash ^= Data.GetHashCode();
		}
		if (Count != 0)
		{
			hash ^= Count.GetHashCode();
		}
		if (Major)
		{
			hash ^= Major.GetHashCode();
		}
		if (StayIndex)
		{
			hash ^= StayIndex.GetHashCode();
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
		if (data_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(Data);
		}
		if (Count != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(Count);
		}
		if (Major)
		{
			output.WriteRawTag(24);
			output.WriteBool(Major);
		}
		if (StayIndex)
		{
			output.WriteRawTag(32);
			output.WriteBool(StayIndex);
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
		if (data_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(Data);
		}
		if (Count != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(Count);
		}
		if (Major)
		{
			size += 2;
		}
		if (StayIndex)
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
	public void MergeFrom(AdventureCharacterGroup other)
	{
		if (other == null)
		{
			return;
		}
		if (other.data_ != null)
		{
			if (data_ == null)
			{
				Data = new AdventureCharacterData();
			}
			Data.MergeFrom(other.Data);
		}
		if (other.Count != 0)
		{
			Count = other.Count;
		}
		if (other.Major)
		{
			Major = other.Major;
		}
		if (other.StayIndex)
		{
			StayIndex = other.StayIndex;
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
				if (data_ == null)
				{
					Data = new AdventureCharacterData();
				}
				input.ReadMessage(Data);
				break;
			case 16u:
				Count = input.ReadInt32();
				break;
			case 24u:
				Major = input.ReadBool();
				break;
			case 32u:
				StayIndex = input.ReadBool();
				break;
			}
		}
	}
}
