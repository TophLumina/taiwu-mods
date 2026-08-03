using System.Reflection;
using Config;
using GameData.Serializer;
using GameData.Utilities;
using GameData.Utilities.Mod;

namespace GameData.Domains.Mod;

/// <summary>
/// MOD 配置条目
/// </summary>
public class ModConfigItem : ICommonObjectSerializationAware
{
	internal static string ModIdentifier;

	/// <summary>
	/// 所属表名
	/// </summary>
	public string ConfigName;

	/// <summary>
	/// 已存在的配置条目模板引用名
	/// </summary>
	public string SrcConfigRefName;

	/// <summary>
	/// 新配置条目的引用名
	/// </summary>
	public string DestConfigRefName;

	/// <summary>
	/// 模板 Id
	/// </summary>
	public int TemplateId = -1;

	/// <summary>
	/// 数据表
	/// </summary>
	public ModConfigItemData Data;

	/// <summary>
	/// 合法
	/// </summary>
	public bool IsValid;

	/// <inheritdoc />
	public bool SkipMember(MemberInfo member, bool deserializing)
	{
		return member.Name == "Data";
	}

	/// <inheritdoc />
	public void DeserializingMissingField(CommonObjectSerializationMember member)
	{
		string name = member.Name;
		if (name == "ConfigName" || name == "DestConfigRefName")
		{
			AdaptableLog.Warning(ModIdentifier + ": cannot find the required field ConfigName.", appendWarningMessage: true);
			IsValid = false;
		}
	}

	/// <inheritdoc />
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

	/// <inheritdoc />
	public void InitializeOnDeserializing()
	{
		IsValid = true;
	}

	/// <inheritdoc />
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
