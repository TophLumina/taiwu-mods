using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureMajorEventDecorationData : IMessage<AdventureMajorEventDecorationData>, IMessage, IEquatable<AdventureMajorEventDecorationData>, IDeepCloneable<AdventureMajorEventDecorationData>, IBufferMessage
{
	private static readonly MessageParser<AdventureMajorEventDecorationData> _parser = new MessageParser<AdventureMajorEventDecorationData>(() => new AdventureMajorEventDecorationData());

	private UnknownFieldSet _unknownFields;

	public const int ResourceFieldNumber = 1;

	private string resource_ = "";

	public const int XFieldNumber = 2;

	private float x_;

	public const int YFieldNumber = 3;

	private float y_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureMajorEventDecorationData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[21];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string Resource
	{
		get
		{
			return resource_;
		}
		set
		{
			resource_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public float X
	{
		get
		{
			return x_;
		}
		set
		{
			x_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public float Y
	{
		get
		{
			return y_;
		}
		set
		{
			y_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureMajorEventDecorationData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureMajorEventDecorationData(AdventureMajorEventDecorationData other)
		: this()
	{
		resource_ = other.resource_;
		x_ = other.x_;
		y_ = other.y_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureMajorEventDecorationData Clone()
	{
		return new AdventureMajorEventDecorationData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureMajorEventDecorationData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureMajorEventDecorationData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Resource != other.Resource)
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(X, other.X))
		{
			return false;
		}
		if (!ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Y, other.Y))
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
		if (Resource.Length != 0)
		{
			hash ^= Resource.GetHashCode();
		}
		if (X != 0f)
		{
			hash ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(X);
		}
		if (Y != 0f)
		{
			hash ^= ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Y);
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
		if (Resource.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteString(Resource);
		}
		if (X != 0f)
		{
			output.WriteRawTag(21);
			output.WriteFloat(X);
		}
		if (Y != 0f)
		{
			output.WriteRawTag(29);
			output.WriteFloat(Y);
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
		if (Resource.Length != 0)
		{
			size += 1 + CodedOutputStream.ComputeStringSize(Resource);
		}
		if (X != 0f)
		{
			size += 5;
		}
		if (Y != 0f)
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
	public void MergeFrom(AdventureMajorEventDecorationData other)
	{
		if (other != null)
		{
			if (other.Resource.Length != 0)
			{
				Resource = other.Resource;
			}
			if (other.X != 0f)
			{
				X = other.X;
			}
			if (other.Y != 0f)
			{
				Y = other.Y;
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
				Resource = input.ReadString();
				break;
			case 21u:
				X = input.ReadFloat();
				break;
			case 29u:
				Y = input.ReadFloat();
				break;
			}
		}
	}
}
