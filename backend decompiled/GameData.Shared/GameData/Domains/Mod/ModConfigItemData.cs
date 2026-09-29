using System;
using System.Collections.Generic;
using System.Reflection;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Mod;

public class ModConfigItemData : ICommonObjectSerializationAware
{
	internal static Type CurrentParsingConfigType;

	private Dictionary<string, object> _fields;

	public IReadOnlyDictionary<string, object> Fields => _fields ?? (_fields = new Dictionary<string, object>());

	public void InitializeOnDeserializing()
	{
		_fields = new Dictionary<string, object>();
	}

	public bool DeserializingUnknownField(string name, out CommonObjectSerializationMember proc)
	{
		FieldInfo fieldInfo = CurrentParsingConfigType.GetField(name, (BindingFlags)(-1));
		if (fieldInfo == null)
		{
			AdaptableLog.Warning(name + " cannot be found as a field of " + CurrentParsingConfigType.Name);
			proc = default(CommonObjectSerializationMember);
			return false;
		}
		proc = new CommonObjectSerializationMember(fieldInfo.Name, () => _fields[name], delegate(object v)
		{
			_fields[name] = v;
		}, fieldInfo.FieldType, fieldInfo);
		return true;
	}
}
