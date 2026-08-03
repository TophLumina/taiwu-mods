using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureLightData : IMessage<AdventureLightData>, IMessage, IEquatable<AdventureLightData>, IDeepCloneable<AdventureLightData>, IBufferMessage
{
	private static readonly MessageParser<AdventureLightData> _parser = new MessageParser<AdventureLightData>(() => new AdventureLightData());

	private UnknownFieldSet _unknownFields;

	public const int ColorInHexFieldNumber = 1;

	private string colorInHex_ = "";

	public const int StrengthFieldNumber = 2;

	private float strength_;

	public const int HeightFieldNumber = 3;

	private float height_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureLightData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[6];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string ColorInHex
	{
		get
		{
			return colorInHex_;
		}
		set
		{
			colorInHex_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public float Strength
	{
		get
		{
			return strength_;
		}
		set
		{
			strength_ = value;
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
	public AdventureLightData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureLightData(AdventureLightData other)
		: this()
	{
		colorInHex_ = other.colorInHex_;
		strength_ = other.strength_;
		height_ = other.height_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureLightData Clone()
	{
		return new AdventureLightData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureLightData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureLightData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (ColorInHex != other.ColorInHex)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Strength, other.Strength))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Height, other.Height))
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
		if (ColorInHex.Length != 0)
		{
			hash ^= ColorInHex.GetHashCode();
		}
		if (Strength != 0f)
		{
			hash ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Strength);
		}
		if (Height != 0f)
		{
			hash ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Height);
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
		if (ColorInHex.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(ColorInHex);
		}
		if (Strength != 0f)
		{
			output.WriteRawTag(21);
			output.WriteFloat(Strength);
		}
		if (Height != 0f)
		{
			output.WriteRawTag(29);
			output.WriteFloat(Height);
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
		if (ColorInHex.Length != 0)
		{
			size += 1 + CodedOutputStream.ComputeStringSize(ColorInHex);
		}
		if (Strength != 0f)
		{
			size += 5;
		}
		if (Height != 0f)
		{
			size += 5;
		}
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureLightData other)
	{
		if (other != null)
		{
			if (other.ColorInHex.Length != 0)
			{
				ColorInHex = other.ColorInHex;
			}
			if (other.Strength != 0f)
			{
				Strength = other.Strength;
			}
			if (other.Height != 0f)
			{
				Height = other.Height;
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
				ColorInHex = input.ReadString();
				break;
			case 21u:
				Strength = input.ReadFloat();
				break;
			case 29u:
				Height = input.ReadFloat();
				break;
			}
		}
	}
}
