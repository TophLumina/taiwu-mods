using System.Reflection;

namespace GameData.ArchiveData;

public abstract class ArchiveFieldGroup
{
	public abstract int GetSerializedSizeWithoutHeader();

	public unsafe abstract int SerializeWithoutHeader(byte* pData);

	public unsafe abstract int DeserializeWithFieldIds(byte* pData, ushort[] fieldIds, int[] fixedFieldSizes);

	public static ushort[] GetFieldIds<T>()
	{
		FieldInfo fieldInfo = typeof(T).GetField("ArchiveFieldIds", BindingFlags.Static | BindingFlags.NonPublic);
		if (fieldInfo != null)
		{
			return fieldInfo.GetValue(null) as ushort[];
		}
		return null;
	}

	public static int[] GetFixedArchiveFieldSizes<T>()
	{
		FieldInfo fieldInfo = typeof(T).GetField("FixedArchiveFieldSizes", BindingFlags.Static | BindingFlags.NonPublic);
		if (fieldInfo != null)
		{
			return fieldInfo.GetValue(null) as int[];
		}
		return null;
	}
}
