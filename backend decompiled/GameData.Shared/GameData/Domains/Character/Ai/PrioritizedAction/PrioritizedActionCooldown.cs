using System;
using GameData.Serializer;

namespace GameData.Domains.Character.Ai.PrioritizedAction;

[Serializable]
public struct PrioritizedActionCooldown(short templateId, int cooldown) : ISerializableGameData, IEquatable<PrioritizedActionCooldown>
{
	public short TemplateId = templateId;

	public int Cooldown = cooldown;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 6;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = TemplateId;
		*(int*)(pData + 2) = Cooldown;
		return 6;
	}

	public unsafe int Deserialize(byte* pData)
	{
		TemplateId = *(short*)pData;
		Cooldown = *(int*)(pData + 2);
		return 6;
	}

	public static bool operator ==(PrioritizedActionCooldown a, PrioritizedActionCooldown b)
	{
		return a.TemplateId == b.TemplateId;
	}

	public static bool operator !=(PrioritizedActionCooldown a, PrioritizedActionCooldown b)
	{
		return a.TemplateId != b.TemplateId;
	}

	public bool Equals(PrioritizedActionCooldown other)
	{
		return TemplateId == other.TemplateId;
	}

	public override bool Equals(object obj)
	{
		if (obj is PrioritizedActionCooldown other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (TemplateId * 397) ^ Cooldown;
	}
}
