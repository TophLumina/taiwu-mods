using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;

namespace GameData.Adventure;

[DebuggerDisplay("{ToString(),nq}")]
public sealed class AdventureData : IAdventureData, IMessage<AdventureData>, IMessage, IEquatable<AdventureData>, IDeepCloneable<AdventureData>, IBufferMessage
{
	private static readonly MessageParser<AdventureData> _parser = new MessageParser<AdventureData>(() => new AdventureData());

	private UnknownFieldSet _unknownFields;

	public const int IdFieldNumber = 1;

	private int id_;

	public const int ReleasedFieldNumber = 2;

	private bool released_;

	public const int MinorVersionFieldNumber = 3;

	private int minorVersion_;

	public const int SizeFieldNumber = 11;

	private int size_;

	public const int NameForProtoFieldNumber = 12;

	private AdventureLocalStringRef nameForProto_;

	public const int DescForProtoFieldNumber = 13;

	private AdventureLocalStringRef descForProto_;

	public const int CustomTextsFieldNumber = 14;

	private static readonly FieldCodec<AdventureTextData> _repeated_customTexts_codec = FieldCodec.ForMessage(114u, AdventureTextData.Parser);

	private readonly RepeatedField<AdventureTextData> customTexts_ = new RepeatedField<AdventureTextData>();

	public const int StyleFieldNumber = 15;

	private uint style_;

	public const int EventTextureFieldNumber = 16;

	private string eventTexture_ = "";

	public const int DescTargetForProtoFieldNumber = 17;

	private AdventureLocalStringRef descTargetForProto_;

	public const int DescRewardForProtoFieldNumber = 18;

	private AdventureLocalStringRef descRewardForProto_;

	public const int GradeFieldNumber = 19;

	private int grade_;

	public const int GroupsFieldNumber = 21;

	private static readonly FieldCodec<AdventureGroupData> _repeated_groups_codec = FieldCodec.ForMessage(170u, AdventureGroupData.Parser);

	private readonly RepeatedField<AdventureGroupData> groups_ = new RepeatedField<AdventureGroupData>();

	public const int ActionsFieldNumber = 22;

	private static readonly FieldCodec<AdventureActionData> _repeated_actions_codec = FieldCodec.ForMessage(178u, AdventureActionData.Parser);

	private readonly RepeatedField<AdventureActionData> actions_ = new RepeatedField<AdventureActionData>();

	public const int ParametersFieldNumber = 23;

	private static readonly FieldCodec<AdventureParameterData> _repeated_parameters_codec = FieldCodec.ForMessage(186u, AdventureParameterData.Parser);

	private readonly RepeatedField<AdventureParameterData> parameters_ = new RepeatedField<AdventureParameterData>();

	public const int AutoEventsFieldNumber = 24;

	private static readonly FieldCodec<AdventureAutoEventData> _repeated_autoEvents_codec = FieldCodec.ForMessage(194u, AdventureAutoEventData.Parser);

	private readonly RepeatedField<AdventureAutoEventData> autoEvents_ = new RepeatedField<AdventureAutoEventData>();

	public const int CostFieldNumber = 25;

	private AdventureCostData cost_;

	public const int StayMonthsFieldNumber = 31;

	private uint stayMonths_;

	public const int CompatibleBlocksFieldNumber = 32;

	private static readonly FieldCodec<int> _repeated_compatibleBlocks_codec = FieldCodec.ForInt32(258u);

	private readonly RepeatedField<int> compatibleBlocks_ = new RepeatedField<int>();

	public const int AutoGenerateConditionFieldNumber = 33;

	private InstructionCompiled autoGenerateCondition_;

	public const int ActiveActionFieldNumber = 41;

	private InstructionCompiled activeAction_;

	public const int RemoveActionFieldNumber = 42;

	private InstructionCompiled removeAction_;

	public const int AdvanceMonthActionFieldNumber = 43;

	private InstructionCompiled advanceMonthAction_;

	public const int PreAdvanceMonthActionFieldNumber = 44;

	private InstructionCompiled preAdvanceMonthAction_;

	public const int FixAbnormalActionFieldNumber = 45;

	private InstructionCompiled fixAbnormalAction_;

	public const int LightingTaiwuFieldNumber = 51;

	private AdventureLightData lightingTaiwu_;

	public const int LightingWorldFieldNumber = 52;

	private AdventureLightData lightingWorld_;

	public const int LightingRotateFieldNumber = 53;

	private bool lightingRotate_;

	public const int LightingRotateAngleFieldNumber = 54;

	private int lightingRotateAngle_;

	public const int LightingPointsFieldNumber = 55;

	private static readonly FieldCodec<AdventurePointLightData> _repeated_lightingPoints_codec = FieldCodec.ForMessage(442u, AdventurePointLightData.Parser);

	private readonly RepeatedField<AdventurePointLightData> lightingPoints_ = new RepeatedField<AdventurePointLightData>();

	public const int TagsFieldNumber = 61;

	private static readonly FieldCodec<EAdventureTag> _repeated_tags_codec = FieldCodec.ForEnum(490u, (EAdventureTag x) => (int)x, (int x) => (EAdventureTag)x);

	private readonly RepeatedField<EAdventureTag> tags_ = new RepeatedField<EAdventureTag>();

	string IAdventureData.Name => Name;

	string IAdventureData.Desc => Desc;

	IReadOnlyList<EAdventureTag> IAdventureData.Tags => Tags;

	public string Name => NameForProto.Tr();

	public string Desc => DescForProto.Tr();

	public string DescTarget => DescTargetForProto.Tr();

	public string DescReward => DescRewardForProto.Tr();

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageParser<AdventureData> Parser => _parser;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public static MessageDescriptor Descriptor => AdventureReflection.Descriptor.MessageTypes[1];

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	MessageDescriptor IMessage.Descriptor => Descriptor;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Id
	{
		get
		{
			return id_;
		}
		set
		{
			id_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Released
	{
		get
		{
			return released_;
		}
		set
		{
			released_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int MinorVersion
	{
		get
		{
			return minorVersion_;
		}
		set
		{
			minorVersion_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Size
	{
		get
		{
			return size_;
		}
		set
		{
			size_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureLocalStringRef NameForProto
	{
		get
		{
			return nameForProto_;
		}
		set
		{
			nameForProto_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureLocalStringRef DescForProto
	{
		get
		{
			return descForProto_;
		}
		set
		{
			descForProto_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureTextData> CustomTexts => customTexts_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint Style
	{
		get
		{
			return style_;
		}
		set
		{
			style_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public string EventTexture
	{
		get
		{
			return eventTexture_;
		}
		set
		{
			eventTexture_ = ProtoPreconditions.CheckNotNull(value, "value");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureLocalStringRef DescTargetForProto
	{
		get
		{
			return descTargetForProto_;
		}
		set
		{
			descTargetForProto_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureLocalStringRef DescRewardForProto
	{
		get
		{
			return descRewardForProto_;
		}
		set
		{
			descRewardForProto_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int Grade
	{
		get
		{
			return grade_;
		}
		set
		{
			grade_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureGroupData> Groups => groups_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureActionData> Actions => actions_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureParameterData> Parameters => parameters_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventureAutoEventData> AutoEvents => autoEvents_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureCostData Cost
	{
		get
		{
			return cost_;
		}
		set
		{
			cost_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public uint StayMonths
	{
		get
		{
			return stayMonths_;
		}
		set
		{
			stayMonths_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<int> CompatibleBlocks => compatibleBlocks_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InstructionCompiled AutoGenerateCondition
	{
		get
		{
			return autoGenerateCondition_;
		}
		set
		{
			autoGenerateCondition_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InstructionCompiled ActiveAction
	{
		get
		{
			return activeAction_;
		}
		set
		{
			activeAction_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InstructionCompiled RemoveAction
	{
		get
		{
			return removeAction_;
		}
		set
		{
			removeAction_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InstructionCompiled AdvanceMonthAction
	{
		get
		{
			return advanceMonthAction_;
		}
		set
		{
			advanceMonthAction_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InstructionCompiled PreAdvanceMonthAction
	{
		get
		{
			return preAdvanceMonthAction_;
		}
		set
		{
			preAdvanceMonthAction_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public InstructionCompiled FixAbnormalAction
	{
		get
		{
			return fixAbnormalAction_;
		}
		set
		{
			fixAbnormalAction_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureLightData LightingTaiwu
	{
		get
		{
			return lightingTaiwu_;
		}
		set
		{
			lightingTaiwu_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureLightData LightingWorld
	{
		get
		{
			return lightingWorld_;
		}
		set
		{
			lightingWorld_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool LightingRotate
	{
		get
		{
			return lightingRotate_;
		}
		set
		{
			lightingRotate_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public int LightingRotateAngle
	{
		get
		{
			return lightingRotateAngle_;
		}
		set
		{
			lightingRotateAngle_ = value;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<AdventurePointLightData> LightingPoints => lightingPoints_;

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public RepeatedField<EAdventureTag> Tags => tags_;

	public void Save(string path)
	{
		Save(path, this);
	}

	public static void Save(string path, AdventureData data)
	{
		using FileStream stream = new FileStream(path, FileMode.Create);
		using CodedOutputStream codedOutputStream = new CodedOutputStream(stream);
		codedOutputStream.Deterministic = true;
		data.WriteTo(codedOutputStream);
	}

	public static bool TryLoad(string path, out AdventureData data)
	{
		data = null;
		if (!File.Exists(path))
		{
			return false;
		}
		using FileStream input = File.OpenRead(path);
		data = Parser.ParseFrom(input);
		return data != null;
	}

	private static bool IsTrivial(EAdventureTag tag)
	{
		bool flag = (uint)tag <= 1u;
		return !flag;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureData()
	{
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureData(AdventureData other)
		: this()
	{
		id_ = other.id_;
		released_ = other.released_;
		minorVersion_ = other.minorVersion_;
		size_ = other.size_;
		nameForProto_ = ((other.nameForProto_ != null) ? other.nameForProto_.Clone() : null);
		descForProto_ = ((other.descForProto_ != null) ? other.descForProto_.Clone() : null);
		customTexts_ = other.customTexts_.Clone();
		style_ = other.style_;
		eventTexture_ = other.eventTexture_;
		descTargetForProto_ = ((other.descTargetForProto_ != null) ? other.descTargetForProto_.Clone() : null);
		descRewardForProto_ = ((other.descRewardForProto_ != null) ? other.descRewardForProto_.Clone() : null);
		grade_ = other.grade_;
		groups_ = other.groups_.Clone();
		actions_ = other.actions_.Clone();
		parameters_ = other.parameters_.Clone();
		autoEvents_ = other.autoEvents_.Clone();
		cost_ = ((other.cost_ != null) ? other.cost_.Clone() : null);
		stayMonths_ = other.stayMonths_;
		compatibleBlocks_ = other.compatibleBlocks_.Clone();
		autoGenerateCondition_ = ((other.autoGenerateCondition_ != null) ? other.autoGenerateCondition_.Clone() : null);
		activeAction_ = ((other.activeAction_ != null) ? other.activeAction_.Clone() : null);
		removeAction_ = ((other.removeAction_ != null) ? other.removeAction_.Clone() : null);
		advanceMonthAction_ = ((other.advanceMonthAction_ != null) ? other.advanceMonthAction_.Clone() : null);
		preAdvanceMonthAction_ = ((other.preAdvanceMonthAction_ != null) ? other.preAdvanceMonthAction_.Clone() : null);
		fixAbnormalAction_ = ((other.fixAbnormalAction_ != null) ? other.fixAbnormalAction_.Clone() : null);
		lightingTaiwu_ = ((other.lightingTaiwu_ != null) ? other.lightingTaiwu_.Clone() : null);
		lightingWorld_ = ((other.lightingWorld_ != null) ? other.lightingWorld_.Clone() : null);
		lightingRotate_ = other.lightingRotate_;
		lightingRotateAngle_ = other.lightingRotateAngle_;
		lightingPoints_ = other.lightingPoints_.Clone();
		tags_ = other.tags_.Clone();
		_unknownFields = UnknownFieldSet.Clone(other._unknownFields);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public AdventureData Clone()
	{
		return new AdventureData(this);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public override bool Equals(object other)
	{
		return Equals(other as AdventureData);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public bool Equals(AdventureData other)
	{
		if (other == null)
		{
			return false;
		}
		if (other == this)
		{
			return true;
		}
		if (Id != other.Id)
		{
			return false;
		}
		if (Released != other.Released)
		{
			return false;
		}
		if (MinorVersion != other.MinorVersion)
		{
			return false;
		}
		if (Size != other.Size)
		{
			return false;
		}
		if (!object.Equals(NameForProto, other.NameForProto))
		{
			return false;
		}
		if (!object.Equals(DescForProto, other.DescForProto))
		{
			return false;
		}
		if (!customTexts_.Equals(other.customTexts_))
		{
			return false;
		}
		if (Style != other.Style)
		{
			return false;
		}
		if (EventTexture != other.EventTexture)
		{
			return false;
		}
		if (!object.Equals(DescTargetForProto, other.DescTargetForProto))
		{
			return false;
		}
		if (!object.Equals(DescRewardForProto, other.DescRewardForProto))
		{
			return false;
		}
		if (Grade != other.Grade)
		{
			return false;
		}
		if (!groups_.Equals(other.groups_))
		{
			return false;
		}
		if (!actions_.Equals(other.actions_))
		{
			return false;
		}
		if (!parameters_.Equals(other.parameters_))
		{
			return false;
		}
		if (!autoEvents_.Equals(other.autoEvents_))
		{
			return false;
		}
		if (!object.Equals(Cost, other.Cost))
		{
			return false;
		}
		if (StayMonths != other.StayMonths)
		{
			return false;
		}
		if (!compatibleBlocks_.Equals(other.compatibleBlocks_))
		{
			return false;
		}
		if (!object.Equals(AutoGenerateCondition, other.AutoGenerateCondition))
		{
			return false;
		}
		if (!object.Equals(ActiveAction, other.ActiveAction))
		{
			return false;
		}
		if (!object.Equals(RemoveAction, other.RemoveAction))
		{
			return false;
		}
		if (!object.Equals(AdvanceMonthAction, other.AdvanceMonthAction))
		{
			return false;
		}
		if (!object.Equals(PreAdvanceMonthAction, other.PreAdvanceMonthAction))
		{
			return false;
		}
		if (!object.Equals(FixAbnormalAction, other.FixAbnormalAction))
		{
			return false;
		}
		if (!object.Equals(LightingTaiwu, other.LightingTaiwu))
		{
			return false;
		}
		if (!object.Equals(LightingWorld, other.LightingWorld))
		{
			return false;
		}
		if (LightingRotate != other.LightingRotate)
		{
			return false;
		}
		if (LightingRotateAngle != other.LightingRotateAngle)
		{
			return false;
		}
		if (!lightingPoints_.Equals(other.lightingPoints_))
		{
			return false;
		}
		if (!tags_.Equals(other.tags_))
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
		if (Id != 0)
		{
			hash ^= Id.GetHashCode();
		}
		if (Released)
		{
			hash ^= Released.GetHashCode();
		}
		if (MinorVersion != 0)
		{
			hash ^= MinorVersion.GetHashCode();
		}
		if (Size != 0)
		{
			hash ^= Size.GetHashCode();
		}
		if (nameForProto_ != null)
		{
			hash ^= NameForProto.GetHashCode();
		}
		if (descForProto_ != null)
		{
			hash ^= DescForProto.GetHashCode();
		}
		hash ^= customTexts_.GetHashCode();
		if (Style != 0)
		{
			hash ^= Style.GetHashCode();
		}
		if (EventTexture.Length != 0)
		{
			hash ^= EventTexture.GetHashCode();
		}
		if (descTargetForProto_ != null)
		{
			hash ^= DescTargetForProto.GetHashCode();
		}
		if (descRewardForProto_ != null)
		{
			hash ^= DescRewardForProto.GetHashCode();
		}
		if (Grade != 0)
		{
			hash ^= Grade.GetHashCode();
		}
		hash ^= groups_.GetHashCode();
		hash ^= actions_.GetHashCode();
		hash ^= parameters_.GetHashCode();
		hash ^= autoEvents_.GetHashCode();
		if (cost_ != null)
		{
			hash ^= Cost.GetHashCode();
		}
		if (StayMonths != 0)
		{
			hash ^= StayMonths.GetHashCode();
		}
		hash ^= compatibleBlocks_.GetHashCode();
		if (autoGenerateCondition_ != null)
		{
			hash ^= AutoGenerateCondition.GetHashCode();
		}
		if (activeAction_ != null)
		{
			hash ^= ActiveAction.GetHashCode();
		}
		if (removeAction_ != null)
		{
			hash ^= RemoveAction.GetHashCode();
		}
		if (advanceMonthAction_ != null)
		{
			hash ^= AdvanceMonthAction.GetHashCode();
		}
		if (preAdvanceMonthAction_ != null)
		{
			hash ^= PreAdvanceMonthAction.GetHashCode();
		}
		if (fixAbnormalAction_ != null)
		{
			hash ^= FixAbnormalAction.GetHashCode();
		}
		if (lightingTaiwu_ != null)
		{
			hash ^= LightingTaiwu.GetHashCode();
		}
		if (lightingWorld_ != null)
		{
			hash ^= LightingWorld.GetHashCode();
		}
		if (LightingRotate)
		{
			hash ^= LightingRotate.GetHashCode();
		}
		if (LightingRotateAngle != 0)
		{
			hash ^= LightingRotateAngle.GetHashCode();
		}
		hash ^= lightingPoints_.GetHashCode();
		hash ^= tags_.GetHashCode();
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
		if (Id != 0)
		{
			output.WriteRawTag(8);
			output.WriteInt32(Id);
		}
		if (Released)
		{
			output.WriteRawTag(16);
			output.WriteBool(Released);
		}
		if (MinorVersion != 0)
		{
			output.WriteRawTag(24);
			output.WriteInt32(MinorVersion);
		}
		if (Size != 0)
		{
			output.WriteRawTag(88);
			output.WriteInt32(Size);
		}
		if (nameForProto_ != null)
		{
			output.WriteRawTag(98);
			output.WriteMessage(NameForProto);
		}
		if (descForProto_ != null)
		{
			output.WriteRawTag(106);
			output.WriteMessage(DescForProto);
		}
		customTexts_.WriteTo(ref output, _repeated_customTexts_codec);
		if (Style != 0)
		{
			output.WriteRawTag(120);
			output.WriteUInt32(Style);
		}
		if (EventTexture.Length != 0)
		{
			output.WriteRawTag(130, 1);
			output.WriteString(EventTexture);
		}
		if (descTargetForProto_ != null)
		{
			output.WriteRawTag(138, 1);
			output.WriteMessage(DescTargetForProto);
		}
		if (descRewardForProto_ != null)
		{
			output.WriteRawTag(146, 1);
			output.WriteMessage(DescRewardForProto);
		}
		if (Grade != 0)
		{
			output.WriteRawTag(152, 1);
			output.WriteInt32(Grade);
		}
		groups_.WriteTo(ref output, _repeated_groups_codec);
		actions_.WriteTo(ref output, _repeated_actions_codec);
		parameters_.WriteTo(ref output, _repeated_parameters_codec);
		autoEvents_.WriteTo(ref output, _repeated_autoEvents_codec);
		if (cost_ != null)
		{
			output.WriteRawTag(202, 1);
			output.WriteMessage(Cost);
		}
		if (StayMonths != 0)
		{
			output.WriteRawTag(248, 1);
			output.WriteUInt32(StayMonths);
		}
		compatibleBlocks_.WriteTo(ref output, _repeated_compatibleBlocks_codec);
		if (autoGenerateCondition_ != null)
		{
			output.WriteRawTag(138, 2);
			output.WriteMessage(AutoGenerateCondition);
		}
		if (activeAction_ != null)
		{
			output.WriteRawTag(202, 2);
			output.WriteMessage(ActiveAction);
		}
		if (removeAction_ != null)
		{
			output.WriteRawTag(210, 2);
			output.WriteMessage(RemoveAction);
		}
		if (advanceMonthAction_ != null)
		{
			output.WriteRawTag(218, 2);
			output.WriteMessage(AdvanceMonthAction);
		}
		if (preAdvanceMonthAction_ != null)
		{
			output.WriteRawTag(226, 2);
			output.WriteMessage(PreAdvanceMonthAction);
		}
		if (fixAbnormalAction_ != null)
		{
			output.WriteRawTag(234, 2);
			output.WriteMessage(FixAbnormalAction);
		}
		if (lightingTaiwu_ != null)
		{
			output.WriteRawTag(154, 3);
			output.WriteMessage(LightingTaiwu);
		}
		if (lightingWorld_ != null)
		{
			output.WriteRawTag(162, 3);
			output.WriteMessage(LightingWorld);
		}
		if (LightingRotate)
		{
			output.WriteRawTag(168, 3);
			output.WriteBool(LightingRotate);
		}
		if (LightingRotateAngle != 0)
		{
			output.WriteRawTag(176, 3);
			output.WriteSInt32(LightingRotateAngle);
		}
		lightingPoints_.WriteTo(ref output, _repeated_lightingPoints_codec);
		tags_.WriteTo(ref output, _repeated_tags_codec);
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
		if (Id != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(Id);
		}
		if (Released)
		{
			size += 2;
		}
		if (MinorVersion != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(MinorVersion);
		}
		if (Size != 0)
		{
			size += 1 + CodedOutputStream.ComputeInt32Size(Size);
		}
		if (nameForProto_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(NameForProto);
		}
		if (descForProto_ != null)
		{
			size += 1 + CodedOutputStream.ComputeMessageSize(DescForProto);
		}
		size += customTexts_.CalculateSize(_repeated_customTexts_codec);
		if (Style != 0)
		{
			size += 1 + CodedOutputStream.ComputeUInt32Size(Style);
		}
		if (EventTexture.Length != 0)
		{
			size += 2 + CodedOutputStream.ComputeStringSize(EventTexture);
		}
		if (descTargetForProto_ != null)
		{
			size += 2 + CodedOutputStream.ComputeMessageSize(DescTargetForProto);
		}
		if (descRewardForProto_ != null)
		{
			size += 2 + CodedOutputStream.ComputeMessageSize(DescRewardForProto);
		}
		if (Grade != 0)
		{
			size += 2 + CodedOutputStream.ComputeInt32Size(Grade);
		}
		size += groups_.CalculateSize(_repeated_groups_codec);
		size += actions_.CalculateSize(_repeated_actions_codec);
		size += parameters_.CalculateSize(_repeated_parameters_codec);
		size += autoEvents_.CalculateSize(_repeated_autoEvents_codec);
		if (cost_ != null)
		{
			size += 2 + CodedOutputStream.ComputeMessageSize(Cost);
		}
		if (StayMonths != 0)
		{
			size += 2 + CodedOutputStream.ComputeUInt32Size(StayMonths);
		}
		size += compatibleBlocks_.CalculateSize(_repeated_compatibleBlocks_codec);
		if (autoGenerateCondition_ != null)
		{
			size += 2 + CodedOutputStream.ComputeMessageSize(AutoGenerateCondition);
		}
		if (activeAction_ != null)
		{
			size += 2 + CodedOutputStream.ComputeMessageSize(ActiveAction);
		}
		if (removeAction_ != null)
		{
			size += 2 + CodedOutputStream.ComputeMessageSize(RemoveAction);
		}
		if (advanceMonthAction_ != null)
		{
			size += 2 + CodedOutputStream.ComputeMessageSize(AdvanceMonthAction);
		}
		if (preAdvanceMonthAction_ != null)
		{
			size += 2 + CodedOutputStream.ComputeMessageSize(PreAdvanceMonthAction);
		}
		if (fixAbnormalAction_ != null)
		{
			size += 2 + CodedOutputStream.ComputeMessageSize(FixAbnormalAction);
		}
		if (lightingTaiwu_ != null)
		{
			size += 2 + CodedOutputStream.ComputeMessageSize(LightingTaiwu);
		}
		if (lightingWorld_ != null)
		{
			size += 2 + CodedOutputStream.ComputeMessageSize(LightingWorld);
		}
		if (LightingRotate)
		{
			size += 3;
		}
		if (LightingRotateAngle != 0)
		{
			size += 2 + CodedOutputStream.ComputeSInt32Size(LightingRotateAngle);
		}
		size += lightingPoints_.CalculateSize(_repeated_lightingPoints_codec);
		size += tags_.CalculateSize(_repeated_tags_codec);
		if (_unknownFields != null)
		{
			size += _unknownFields.CalculateSize();
		}
		return size;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("protoc", null)]
	public void MergeFrom(AdventureData other)
	{
		if (other == null)
		{
			return;
		}
		if (other.Id != 0)
		{
			Id = other.Id;
		}
		if (other.Released)
		{
			Released = other.Released;
		}
		if (other.MinorVersion != 0)
		{
			MinorVersion = other.MinorVersion;
		}
		if (other.Size != 0)
		{
			Size = other.Size;
		}
		if (other.nameForProto_ != null)
		{
			if (nameForProto_ == null)
			{
				NameForProto = new AdventureLocalStringRef();
			}
			NameForProto.MergeFrom(other.NameForProto);
		}
		if (other.descForProto_ != null)
		{
			if (descForProto_ == null)
			{
				DescForProto = new AdventureLocalStringRef();
			}
			DescForProto.MergeFrom(other.DescForProto);
		}
		customTexts_.Add(other.customTexts_);
		if (other.Style != 0)
		{
			Style = other.Style;
		}
		if (other.EventTexture.Length != 0)
		{
			EventTexture = other.EventTexture;
		}
		if (other.descTargetForProto_ != null)
		{
			if (descTargetForProto_ == null)
			{
				DescTargetForProto = new AdventureLocalStringRef();
			}
			DescTargetForProto.MergeFrom(other.DescTargetForProto);
		}
		if (other.descRewardForProto_ != null)
		{
			if (descRewardForProto_ == null)
			{
				DescRewardForProto = new AdventureLocalStringRef();
			}
			DescRewardForProto.MergeFrom(other.DescRewardForProto);
		}
		if (other.Grade != 0)
		{
			Grade = other.Grade;
		}
		groups_.Add(other.groups_);
		actions_.Add(other.actions_);
		parameters_.Add(other.parameters_);
		autoEvents_.Add(other.autoEvents_);
		if (other.cost_ != null)
		{
			if (cost_ == null)
			{
				Cost = new AdventureCostData();
			}
			Cost.MergeFrom(other.Cost);
		}
		if (other.StayMonths != 0)
		{
			StayMonths = other.StayMonths;
		}
		compatibleBlocks_.Add(other.compatibleBlocks_);
		if (other.autoGenerateCondition_ != null)
		{
			if (autoGenerateCondition_ == null)
			{
				AutoGenerateCondition = new InstructionCompiled();
			}
			AutoGenerateCondition.MergeFrom(other.AutoGenerateCondition);
		}
		if (other.activeAction_ != null)
		{
			if (activeAction_ == null)
			{
				ActiveAction = new InstructionCompiled();
			}
			ActiveAction.MergeFrom(other.ActiveAction);
		}
		if (other.removeAction_ != null)
		{
			if (removeAction_ == null)
			{
				RemoveAction = new InstructionCompiled();
			}
			RemoveAction.MergeFrom(other.RemoveAction);
		}
		if (other.advanceMonthAction_ != null)
		{
			if (advanceMonthAction_ == null)
			{
				AdvanceMonthAction = new InstructionCompiled();
			}
			AdvanceMonthAction.MergeFrom(other.AdvanceMonthAction);
		}
		if (other.preAdvanceMonthAction_ != null)
		{
			if (preAdvanceMonthAction_ == null)
			{
				PreAdvanceMonthAction = new InstructionCompiled();
			}
			PreAdvanceMonthAction.MergeFrom(other.PreAdvanceMonthAction);
		}
		if (other.fixAbnormalAction_ != null)
		{
			if (fixAbnormalAction_ == null)
			{
				FixAbnormalAction = new InstructionCompiled();
			}
			FixAbnormalAction.MergeFrom(other.FixAbnormalAction);
		}
		if (other.lightingTaiwu_ != null)
		{
			if (lightingTaiwu_ == null)
			{
				LightingTaiwu = new AdventureLightData();
			}
			LightingTaiwu.MergeFrom(other.LightingTaiwu);
		}
		if (other.lightingWorld_ != null)
		{
			if (lightingWorld_ == null)
			{
				LightingWorld = new AdventureLightData();
			}
			LightingWorld.MergeFrom(other.LightingWorld);
		}
		if (other.LightingRotate)
		{
			LightingRotate = other.LightingRotate;
		}
		if (other.LightingRotateAngle != 0)
		{
			LightingRotateAngle = other.LightingRotateAngle;
		}
		lightingPoints_.Add(other.lightingPoints_);
		tags_.Add(other.tags_);
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
				Id = input.ReadInt32();
				break;
			case 16u:
				Released = input.ReadBool();
				break;
			case 24u:
				MinorVersion = input.ReadInt32();
				break;
			case 88u:
				Size = input.ReadInt32();
				break;
			case 98u:
				if (nameForProto_ == null)
				{
					NameForProto = new AdventureLocalStringRef();
				}
				input.ReadMessage(NameForProto);
				break;
			case 106u:
				if (descForProto_ == null)
				{
					DescForProto = new AdventureLocalStringRef();
				}
				input.ReadMessage(DescForProto);
				break;
			case 114u:
				customTexts_.AddEntriesFrom(ref input, _repeated_customTexts_codec);
				break;
			case 120u:
				Style = input.ReadUInt32();
				break;
			case 130u:
				EventTexture = input.ReadString();
				break;
			case 138u:
				if (descTargetForProto_ == null)
				{
					DescTargetForProto = new AdventureLocalStringRef();
				}
				input.ReadMessage(DescTargetForProto);
				break;
			case 146u:
				if (descRewardForProto_ == null)
				{
					DescRewardForProto = new AdventureLocalStringRef();
				}
				input.ReadMessage(DescRewardForProto);
				break;
			case 152u:
				Grade = input.ReadInt32();
				break;
			case 170u:
				groups_.AddEntriesFrom(ref input, _repeated_groups_codec);
				break;
			case 178u:
				actions_.AddEntriesFrom(ref input, _repeated_actions_codec);
				break;
			case 186u:
				parameters_.AddEntriesFrom(ref input, _repeated_parameters_codec);
				break;
			case 194u:
				autoEvents_.AddEntriesFrom(ref input, _repeated_autoEvents_codec);
				break;
			case 202u:
				if (cost_ == null)
				{
					Cost = new AdventureCostData();
				}
				input.ReadMessage(Cost);
				break;
			case 248u:
				StayMonths = input.ReadUInt32();
				break;
			case 256u:
			case 258u:
				compatibleBlocks_.AddEntriesFrom(ref input, _repeated_compatibleBlocks_codec);
				break;
			case 266u:
				if (autoGenerateCondition_ == null)
				{
					AutoGenerateCondition = new InstructionCompiled();
				}
				input.ReadMessage(AutoGenerateCondition);
				break;
			case 330u:
				if (activeAction_ == null)
				{
					ActiveAction = new InstructionCompiled();
				}
				input.ReadMessage(ActiveAction);
				break;
			case 338u:
				if (removeAction_ == null)
				{
					RemoveAction = new InstructionCompiled();
				}
				input.ReadMessage(RemoveAction);
				break;
			case 346u:
				if (advanceMonthAction_ == null)
				{
					AdvanceMonthAction = new InstructionCompiled();
				}
				input.ReadMessage(AdvanceMonthAction);
				break;
			case 354u:
				if (preAdvanceMonthAction_ == null)
				{
					PreAdvanceMonthAction = new InstructionCompiled();
				}
				input.ReadMessage(PreAdvanceMonthAction);
				break;
			case 362u:
				if (fixAbnormalAction_ == null)
				{
					FixAbnormalAction = new InstructionCompiled();
				}
				input.ReadMessage(FixAbnormalAction);
				break;
			case 410u:
				if (lightingTaiwu_ == null)
				{
					LightingTaiwu = new AdventureLightData();
				}
				input.ReadMessage(LightingTaiwu);
				break;
			case 418u:
				if (lightingWorld_ == null)
				{
					LightingWorld = new AdventureLightData();
				}
				input.ReadMessage(LightingWorld);
				break;
			case 424u:
				LightingRotate = input.ReadBool();
				break;
			case 432u:
				LightingRotateAngle = input.ReadSInt32();
				break;
			case 442u:
				lightingPoints_.AddEntriesFrom(ref input, _repeated_lightingPoints_codec);
				break;
			case 488u:
			case 490u:
				tags_.AddEntriesFrom(ref input, _repeated_tags_codec);
				break;
			}
		}
	}
}
