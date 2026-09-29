using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GameData.Serializer;

public interface ICommonObjectSerializationAware
{
	bool IncludeNonPublic => false;

	bool SkipMember(MemberInfo member, bool deserializing)
	{
		return false;
	}

	IEnumerable<CommonObjectSerializationMember> ExtraMembers(bool deserializing)
	{
		return Enumerable.Empty<CommonObjectSerializationMember>();
	}

	bool DeserializingUnknownField(string name, out CommonObjectSerializationMember proc)
	{
		proc = default(CommonObjectSerializationMember);
		return false;
	}

	void DeserializingMissingField(CommonObjectSerializationMember member)
	{
	}

	void InitializeOnDeserializing()
	{
	}

	void FinishedDeserialization()
	{
	}
}
