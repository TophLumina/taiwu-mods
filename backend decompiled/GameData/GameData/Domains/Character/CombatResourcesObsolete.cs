using System;
using GameData.Serializer;

namespace GameData.Domains.Character;

[SerializableGameData(NotForDisplayModule = true)]
[Obsolete("This class is only for archive module. Cannot use to do anything.")]
public class CombatResourcesObsolete : ISerializableGameData
{
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 2;
	}

	public unsafe int Serialize(byte* pData)
	{
		return 2;
	}

	public unsafe int Deserialize(byte* pData)
	{
		return 2;
	}
}
