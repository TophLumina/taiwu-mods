using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureNullableLightData : IMessage<AdventureNullableLightData>, IMessage, IEquatable<AdventureNullableLightData>, IDeepCloneable<AdventureNullableLightData>, IBufferMessage
{
	private static readonly MessageParser<AdventureNullableLightData> _parser = new MessageParser<AdventureNullableLightData>(() => new AdventureNullableLightData());

	private UnknownFieldSet _unknownFields;

	public const int HasValueFieldNumber = 1;

	private bool hasValue_;

	public const int LightDataFieldNumber = 2;

	private AdventureLightData lightData_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureNullableLightData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[8];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HasValue
	{
		get
		{
			return hasValue_;
		}
		set
		{
			hasValue_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureLightData LightData
	{
		get
		{
			return lightData_;
		}
		set
		{
			lightData_ = value;
		}
	}

	public AdventureNullableLightData(AdventureLightData lightData)
	{
		HasValue = lightData != null;
		LightData = lightData;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureNullableLightData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureNullableLightData(AdventureNullableLightData other)
		: this()
	{
		hasValue_ = other.hasValue_;
		lightData_ = ((other.lightData_ != null) ? other.lightData_.Clone() : null);
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureNullableLightData Clone()
	{
		return new AdventureNullableLightData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureNullableLightData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureNullableLightData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (HasValue != other.HasValue)
		{
			return false;
		}
		if (!object.Equals(LightData, other.LightData))
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
		if (HasValue)
		{
			hash ^= HasValue.GetHashCode();
		}
		if (lightData_ != null)
		{
			hash ^= LightData.GetHashCode();
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
		if (HasValue)
		{
			output.WriteRawTag(8);
			output.WriteBool(HasValue);
		}
		if (lightData_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(LightData);
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
		if (HasValue)
		{
			size += 2;
		}
		if (lightData_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(LightData);
		}
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureNullableLightData other)
	{
		if (other == null)
		{
			return;
		}
		if (other.HasValue)
		{
			HasValue = other.HasValue;
		}
		if (other.lightData_ != null)
		{
			if (lightData_ == null)
			{
				LightData = new AdventureLightData();
			}
			LightData.MergeFrom(other.LightData);
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
			case 8u:
				HasValue = input.ReadBool();
				break;
			case 18u:
				if (lightData_ == null)
				{
					LightData = new AdventureLightData();
				}
				input.ReadMessage(LightData);
				break;
			}
		}
	}
}
