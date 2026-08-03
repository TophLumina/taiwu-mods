using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventurePointLightData : IMessage<AdventurePointLightData>, IMessage, IEquatable<AdventurePointLightData>, IDeepCloneable<AdventurePointLightData>, IBufferMessage
{
	private AdventureBlockIndex? _cachedIndex;

	private static readonly MessageParser<AdventurePointLightData> _parser = new MessageParser<AdventurePointLightData>(() => new AdventurePointLightData());

	private UnknownFieldSet _unknownFields;

	public const int IndexForProtoFieldNumber = 1;

	private AdventureBlockIndexForProto indexForProto_;

	public const int LightDataFieldNumber = 2;

	private AdventureLightData lightData_;

	public const int RangeFieldNumber = 3;

	private int range_;

	public AdventureBlockIndex Index
	{
		get
		{
			AdventureBlockIndex valueOrDefault = _cachedIndex.GetValueOrDefault();
			if (!_cachedIndex.HasValue)
			{
				valueOrDefault = IndexForProto;
				_cachedIndex = valueOrDefault;
				return valueOrDefault;
			}
			return valueOrDefault;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventurePointLightData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[7];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureBlockIndexForProto IndexForProto
	{
		get
		{
			return indexForProto_;
		}
		set
		{
			indexForProto_ = value;
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

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Range
	{
		get
		{
			return range_;
		}
		set
		{
			range_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventurePointLightData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventurePointLightData(AdventurePointLightData other)
		: this()
	{
		indexForProto_ = ((other.indexForProto_ != null) ? other.indexForProto_.Clone() : null);
		lightData_ = ((other.lightData_ != null) ? other.lightData_.Clone() : null);
		range_ = other.range_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventurePointLightData Clone()
	{
		return new AdventurePointLightData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventurePointLightData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventurePointLightData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(IndexForProto, other.IndexForProto))
		{
			return false;
		}
		if (!object.Equals(LightData, other.LightData))
		{
			return false;
		}
		if (Range != other.Range)
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
		if (indexForProto_ != null)
		{
			hash ^= IndexForProto.GetHashCode();
		}
		if (lightData_ != null)
		{
			hash ^= LightData.GetHashCode();
		}
		if (Range != 0)
		{
			hash ^= Range.GetHashCode();
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
		if (indexForProto_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(IndexForProto);
		}
		if (lightData_ != null)
		{
			output.WriteRawTag(18);
			output.WriteMessage(LightData);
		}
		if (Range != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(Range);
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
		if (indexForProto_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(IndexForProto);
		}
		if (lightData_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(LightData);
		}
		if (Range != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(Range);
		}
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventurePointLightData other)
	{
		if (other == null)
		{
			return;
		}
		if (other.indexForProto_ != null)
		{
			if (indexForProto_ == null)
			{
				IndexForProto = new AdventureBlockIndexForProto();
			}
			IndexForProto.MergeFrom(other.IndexForProto);
		}
		if (other.lightData_ != null)
		{
			if (lightData_ == null)
			{
				LightData = new AdventureLightData();
			}
			LightData.MergeFrom(other.LightData);
		}
		if (other.Range != 0)
		{
			Range = other.Range;
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
				if (indexForProto_ == null)
				{
					IndexForProto = new AdventureBlockIndexForProto();
				}
				input.ReadMessage(IndexForProto);
				break;
			case 18u:
				if (lightData_ == null)
				{
					LightData = new AdventureLightData();
				}
				input.ReadMessage(LightData);
				break;
			case 24u:
				Range = input.ReadInt32();
				break;
			}
		}
	}
}
