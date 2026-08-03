using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class InstructionCompiled : IMessage<InstructionCompiled>, IMessage, IEquatable<InstructionCompiled>, IDeepCloneable<InstructionCompiled>, IBufferMessage
{
	private static readonly MessageParser<InstructionCompiled> _parser = new MessageParser<InstructionCompiled>(() => new InstructionCompiled());

	private UnknownFieldSet _unknownFields;

	public const int EventScriptCompiledFieldNumber = 1;

	private ByteString eventScriptCompiled_ = ByteString.Empty;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<InstructionCompiled> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[29];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public ByteString EventScriptCompiled
	{
		get
		{
			return eventScriptCompiled_;
		}
		set
		{
			eventScriptCompiled_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	public byte[] CompiledCopy => EventScriptCompiled.ToByteArray();

	public ReadOnlySpan<byte> CompiledSpan => EventScriptCompiled.Span;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InstructionCompiled()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InstructionCompiled(InstructionCompiled other)
		: this()
	{
		eventScriptCompiled_ = other.eventScriptCompiled_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InstructionCompiled Clone()
	{
		return new InstructionCompiled(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as InstructionCompiled);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(InstructionCompiled other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (EventScriptCompiled != other.EventScriptCompiled)
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
		if (EventScriptCompiled.Length != 0)
		{
			hash ^= EventScriptCompiled.GetHashCode();
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
		if (EventScriptCompiled.Length != 0)
		{
			output.WriteRawTag(10);
			output.WriteBytes(EventScriptCompiled);
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
		if (EventScriptCompiled.Length != 0)
		{
			size += 1 + CodedOutputStream.ComputeBytesSize(EventScriptCompiled);
		}
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(InstructionCompiled other)
	{
		if (other != null)
		{
			if (other.EventScriptCompiled.Length != 0)
			{
				EventScriptCompiled = other.EventScriptCompiled;
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
			if (tag != 10)
			{
				_unknownFields = UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
			}
			else
			{
				EventScriptCompiled = input.ReadBytes();
			}
		}
	}

	public InstructionCompiled(byte[] bytes)
	{
		EventScriptCompiled = ByteString.CopyFrom(bytes);
	}
}
