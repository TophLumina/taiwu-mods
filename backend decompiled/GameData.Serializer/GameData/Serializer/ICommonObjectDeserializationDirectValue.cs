namespace GameData.Serializer;

public interface ICommonObjectDeserializationDirectValue : ICommonObjectSerializationAware
{
	void OnUnknownFieldGet(string name, object value);
}
