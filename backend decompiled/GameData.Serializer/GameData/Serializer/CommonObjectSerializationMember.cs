using System;
using System.Collections.Generic;
using System.Reflection;

namespace GameData.Serializer;

public readonly struct CommonObjectSerializationMember(string name, Func<object> getter, Action<object> setter, Type typeHint, MemberInfo memberInfo)
{
	public readonly string Name = name;

	public readonly Func<object> Getter = getter;

	public readonly Action<object> Setter = setter;

	public readonly Type TypeHint = typeHint;

	public readonly MemberInfo MemberInfo = memberInfo;

	public static CommonObjectSerializationMember Make<T>(string name, Func<T> getter, Action<T> setter)
	{
		return new CommonObjectSerializationMember(name, () => getter(), delegate(object v)
		{
			setter((T)v);
		}, typeof(T), null);
	}

	public static CommonObjectSerializationMember MakeSetOnly<T>(string name, Action<T> setter)
	{
		return Make(name, null, setter);
	}

	public static CommonObjectSerializationMember MakeListRefill<T>(string key, List<T> target)
	{
		return Make(key, () => target, delegate(List<T> v)
		{
			target.Clear();
			target.AddRange(v);
		});
	}

	public static CommonObjectSerializationMember MakeTypeHintOnly<T>(string name)
	{
		return new CommonObjectSerializationMember(name, null, null, typeof(T), null);
	}
}
