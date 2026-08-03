using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureElementVisibleData : IMessage<AdventureElementVisibleData>, IMessage, IEquatable<AdventureElementVisibleData>, IDeepCloneable<AdventureElementVisibleData>, IBufferMessage
{
	private static readonly MessageParser<AdventureElementVisibleData> _parser = new MessageParser<AdventureElementVisibleData>(() => new AdventureElementVisibleData());

	private UnknownFieldSet _unknownFields;

	public const int VisibleConditionFieldNumber = 1;

	private InstructionCompiled visibleCondition_;

	public const int VisibleIconFieldNumber = 2;

	private string visibleIcon_ = "";

	public const int HideProgressAndStateFieldNumber = 3;

	private bool hideProgressAndState_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureElementVisibleData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[11];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InstructionCompiled VisibleCondition
	{
		get
		{
			return visibleCondition_;
		}
		set
		{
			visibleCondition_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string VisibleIcon
	{
		get
		{
			return visibleIcon_;
		}
		set
		{
			visibleIcon_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool HideProgressAndState
	{
		get
		{
			return hideProgressAndState_;
		}
		set
		{
			hideProgressAndState_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureElementVisibleData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureElementVisibleData(AdventureElementVisibleData other)
		: this()
	{
		visibleCondition_ = ((other.visibleCondition_ != null) ? other.visibleCondition_.Clone() : null);
		visibleIcon_ = other.visibleIcon_;
		hideProgressAndState_ = other.hideProgressAndState_;
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureElementVisibleData Clone()
	{
		return new AdventureElementVisibleData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureElementVisibleData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureElementVisibleData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (!object.Equals(VisibleCondition, other.VisibleCondition))
		{
			return false;
		}
		if (VisibleIcon != other.VisibleIcon)
		{
			return false;
		}
		if (HideProgressAndState != other.HideProgressAndState)
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
		if (visibleCondition_ != null)
		{
			hash ^= VisibleCondition.GetHashCode();
		}
		if (VisibleIcon.Length != 0)
		{
			hash ^= VisibleIcon.GetHashCode();
		}
		if (HideProgressAndState)
		{
			hash ^= HideProgressAndState.GetHashCode();
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
		if (visibleCondition_ != null)
		{
			output.WriteRawTag(10);
			output.WriteMessage(VisibleCondition);
		}
		if (VisibleIcon.Length != 0)
		{
			output.WriteRawTag(18);
			output.WriteString(VisibleIcon);
		}
		if (HideProgressAndState)
		{
			output.WriteRawTag(24);
			output.WriteBool(HideProgressAndState);
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
		if (visibleCondition_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(VisibleCondition);
		}
		if (VisibleIcon.Length != 0)
		{
			size += 1 + CodedOutputStream.ComputeStringSize(VisibleIcon);
		}
		if (HideProgressAndState)
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
	public void MergeFrom(AdventureElementVisibleData other)
	{
		if (other == null)
		{
			return;
		}
		if (other.visibleCondition_ != null)
		{
			if (visibleCondition_ == null)
			{
				VisibleCondition = new InstructionCompiled();
			}
			VisibleCondition.MergeFrom(other.VisibleCondition);
		}
		if (other.VisibleIcon.Length != 0)
		{
			VisibleIcon = other.VisibleIcon;
		}
		if (other.HideProgressAndState)
		{
			HideProgressAndState = other.HideProgressAndState;
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
				if (visibleCondition_ == null)
				{
					VisibleCondition = new InstructionCompiled();
				}
				input.ReadMessage(VisibleCondition);
				break;
			case 18u:
				VisibleIcon = input.ReadString();
				break;
			case 24u:
				HideProgressAndState = input.ReadBool();
				break;
			}
		}
	}
}
