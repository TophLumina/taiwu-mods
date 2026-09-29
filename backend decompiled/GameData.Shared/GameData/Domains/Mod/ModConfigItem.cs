using System.Reflection;
using Config;
using GameData.Serializer;
using GameData.Utilities;
using GameData.Utilities.Mod;

namespace GameData.Domains.Mod;

public class ModConfigItem : ICommonObjectSerializationAware
{
	internal static string ModIdentifier;

	public string ConfigName;

	public string SrcConfigRefName;

	public string DestConfigRefName;

	public int TemplateId = -1;

	public ModConfigItemData Data;

	public bool IsValid;

	public bool SkipMember(MemberInfo member, bool deserializing)
	{
		return member.Name == "Data";
	}

	public void DeserializingMissingField(CommonObjectSerializationMember member)
	{
		string name = member.Name;
		if (name == "ConfigName" || name == "DestConfigRefName")
		{
			AdaptableLog.Warning(ModIdentifier + ": cannot find the required field ConfigName.", appendWarningMessage: true);
			IsValid = false;
		}
	}

	public bool DeserializingUnknownField(string name, out CommonObjectSerializationMember proc)
	{
		if ("Data" == name)
		{
			if (ConfigCollection.NameMap.TryGetValue(ConfigName, out var configData))
			{
				ModConfigItemData.CurrentParsingConfigType = configData.GetConfigItem(0).GetType();
				proc = CommonObjectSerializationMember.MakeSetOnly(name, delegate(ModConfigItemData t)
				{
					Data = t;
				});
				return true;
			}
			AdaptableLog.Warning(ModIdentifier + ": field ConfigName has an invalid value.", appendWarningMessage: true);
		}
		proc = default(CommonObjectSerializationMember);
		return false;
	}

	public void InitializeOnDeserializing()
	{
		IsValid = true;
	}

	public void FinishedDeserialization()
	{
		if (ConfigName == null)
		{
			AdaptableLog.Warning(ModIdentifier + ": the required field ConfigName is null or empty.", appendWarningMessage: true);
			IsValid = false;
		}
		else if (DestConfigRefName == null)
		{
			AdaptableLog.Warning(ModIdentifier + ": the required field DestConfigRefName is null or empty.", appendWarningMessage: true);
			IsValid = false;
		}
	}
}
