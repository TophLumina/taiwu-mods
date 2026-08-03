using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureBlockIndexForProto : IMessage<AdventureBlockIndexForProto>, IMessage, IEquatable<AdventureBlockIndexForProto>, IDeepCloneable<AdventureBlockIndexForProto>, IBufferMessage
{
	private static readonly MessageParser<AdventureBlockIndexForProto> _parser = new MessageParser<AdventureBlockIndexForProto>(() => new AdventureBlockIndexForProto());

	private UnknownFieldSet _unknownFields;

	public const int GxFieldNumber = 1;

	private int gx_;

	public const int GyFieldNumber = 2;

	private int gy_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureBlockIndexForProto> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[0];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Gx
	{
		get
		{
			return gx_;
		}
		set
		{
			gx_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Gy
	{
		get
		{
			return gy_;
		}
		set
		{
			gy_ = value;
		}
	}

	public static implicit operator AdventureBlockIndex(AdventureBlockIndexForProto proto)
	{
		return new AdventureBlockIndex(proto.Gx, proto.Gy);
	}

	public static implicit operator AdventureBlockIndexForProto(AdventureBlockIndex index)
	{
		return new AdventureBlockIndexForProto
		{
			Gx = index.Gx,
			Gy = index.Gy
		};
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureBlockIndexForProto()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureBlockIndexForProto(AdventureBlockIndexForProto other)
		: this()
	{
		gx_ = other.gx_;
		gy_ = other.gy_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureBlockIndexForProto Clone()
	{
		return new AdventureBlockIndexForProto(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureBlockIndexForProto);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureBlockIndexForProto other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Gx != other.Gx)
		{
			return false;
		}
		if (Gy != other.Gy)
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
		if (Gx != 0)
		{
			hash ^= Gx.GetHashCode();
		}
		if (Gy != 0)
		{
			hash ^= Gy.GetHashCode();
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
		if (Gx != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(Gx);
		}
		if (Gy != 0)
		{
			output.WriteRawTag(16);
			output.WriteInt32(Gy);
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
		if (Gx != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(Gx);
		}
		if (Gy != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(Gy);
		}
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureBlockIndexForProto other)
	{
		if (other != null)
		{
			if (other.Gx != 0)
			{
				Gx = other.Gx;
			}
			if (other.Gy != 0)
			{
				Gy = other.Gy;
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
				Gx = input.ReadInt32();
				break;
			case 16u:
				Gy = input.ReadInt32();
				break;
			}
		}
	}
}
