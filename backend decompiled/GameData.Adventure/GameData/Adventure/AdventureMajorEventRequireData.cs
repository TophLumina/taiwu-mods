using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureMajorEventRequireData : IMessage<AdventureMajorEventRequireData>, IMessage, IEquatable<AdventureMajorEventRequireData>, IDeepCloneable<AdventureMajorEventRequireData>, IBufferMessage
{
	private static readonly MessageParser<AdventureMajorEventRequireData> _parser = new MessageParser<AdventureMajorEventRequireData>(() => new AdventureMajorEventRequireData());

	private UnknownFieldSet _unknownFields;

	public const int ItemsFieldNumber = 1;

	private static readonly FieldCodec<AdventureCostItem> _repeated_items_codec = FieldCodec.ForMessage(10u, AdventureCostItem.Parser);

	private readonly RepeatedField<AdventureCostItem> items_ = new RepeatedField<AdventureCostItem>();

	public const int PersonalitiesFieldNumber = 2;

	private static readonly FieldCodec<AdventureCostResource> _repeated_personalities_codec = FieldCodec.ForMessage(18u, AdventureCostResource.Parser);

	private readonly RepeatedField<AdventureCostResource> personalities_ = new RepeatedField<AdventureCostResource>();

	public const int LifeSkillAttainmentsFieldNumber = 3;

	private static readonly FieldCodec<AdventureCostResource> _repeated_lifeSkillAttainments_codec = FieldCodec.ForMessage(26u, AdventureCostResource.Parser);

	private readonly RepeatedField<AdventureCostResource> lifeSkillAttainments_ = new RepeatedField<AdventureCostResource>();

	public const int CombatSkillAttainmentsFieldNumber = 4;

	private static readonly FieldCodec<AdventureCostResource> _repeated_combatSkillAttainments_codec = FieldCodec.ForMessage(34u, AdventureCostResource.Parser);

	private readonly RepeatedField<AdventureCostResource> combatSkillAttainments_ = new RepeatedField<AdventureCostResource>();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureMajorEventRequireData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[19];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureCostItem> Items => items_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureCostResource> Personalities => personalities_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureCostResource> LifeSkillAttainments => lifeSkillAttainments_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureCostResource> CombatSkillAttainments => combatSkillAttainments_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureMajorEventRequireData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureMajorEventRequireData(AdventureMajorEventRequireData other)
		: this()
	{
		items_ = other.items_.Clone();
		personalities_ = other.personalities_.Clone();
		lifeSkillAttainments_ = other.lifeSkillAttainments_.Clone();
		combatSkillAttainments_ = other.combatSkillAttainments_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureMajorEventRequireData Clone()
	{
		return new AdventureMajorEventRequireData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureMajorEventRequireData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureMajorEventRequireData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!items_.Equals(other.items_))
		{
			return false;
		}
		if (!personalities_.Equals(other.personalities_))
		{
			return false;
		}
		if (!lifeSkillAttainments_.Equals(other.lifeSkillAttainments_))
		{
			return false;
		}
		if (!combatSkillAttainments_.Equals(other.combatSkillAttainments_))
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
		hash ^= items_.GetHashCode();
		hash ^= personalities_.GetHashCode();
		hash ^= lifeSkillAttainments_.GetHashCode();
		hash ^= combatSkillAttainments_.GetHashCode();
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
		items_.WriteTo(ref output, _repeated_items_codec);
		personalities_.WriteTo(ref output, _repeated_personalities_codec);
		lifeSkillAttainments_.WriteTo(ref output, _repeated_lifeSkillAttainments_codec);
		combatSkillAttainments_.WriteTo(ref output, _repeated_combatSkillAttainments_codec);
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
		size += items_.CalculateSize(_repeated_items_codec);
		size += personalities_.CalculateSize(_repeated_personalities_codec);
		size += lifeSkillAttainments_.CalculateSize(_repeated_lifeSkillAttainments_codec);
		size += combatSkillAttainments_.CalculateSize(_repeated_combatSkillAttainments_codec);
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureMajorEventRequireData other)
	{
		if (other != null)
		{
			items_.Add(other.items_);
			personalities_.Add(other.personalities_);
			lifeSkillAttainments_.Add(other.lifeSkillAttainments_);
			combatSkillAttainments_.Add(other.combatSkillAttainments_);
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
				items_.AddEntriesFrom(ref input, _repeated_items_codec);
				break;
			case 18u:
				personalities_.AddEntriesFrom(ref input, _repeated_personalities_codec);
				break;
			case 26u:
				lifeSkillAttainments_.AddEntriesFrom(ref input, _repeated_lifeSkillAttainments_codec);
				break;
			case 34u:
				combatSkillAttainments_.AddEntriesFrom(ref input, _repeated_combatSkillAttainments_codec);
				break;
			}
		}
	}
}
