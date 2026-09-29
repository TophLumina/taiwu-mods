using System;
using Config;
using GameData.Serializer;

namespace GameData.Domains.Combat;

public struct SkillEffectKey : ISerializableGameData, IEquatable<SkillEffectKey>
{
	public short SkillId;

	public bool IsDirect;

	public CombatSkillItem SkillConfig => Config.CombatSkill.Instance[SkillId];

	public int EffectId
	{
		get
		{
			if (!IsDirect)
			{
				return SkillConfig.ReverseEffectID;
			}
			return SkillConfig.DirectEffectID;
		}
	}

	public SpecialEffectItem EffectConfig => Config.SpecialEffect.Instance[EffectId];

	public SkillEffectKey(short skillId, bool isDirect)
	{
		SkillId = skillId;
		IsDirect = isDirect;
	}

	public static explicit operator ulong(SkillEffectKey value)
	{
		return (ulong)(((long)value.SkillId << 32) + ((!value.IsDirect) ? 1 : 0));
	}

	public static explicit operator SkillEffectKey(ulong value)
	{
		return new SkillEffectKey((short)(value >> 32), value % 2 == 0);
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 3;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = SkillId;
		pData[2] = (IsDirect ? ((byte)1) : ((byte)0));
		return GetSerializedSize();
	}

	public unsafe int Deserialize(byte* pData)
	{
		SkillId = *(short*)pData;
		IsDirect = pData[2] != 0;
		return GetSerializedSize();
	}

	public static bool operator ==(SkillEffectKey lhs, SkillEffectKey rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(SkillEffectKey lhs, SkillEffectKey rhs)
	{
		return !lhs.Equals(rhs);
	}

	public bool Equals(SkillEffectKey other)
	{
		if (SkillId == other.SkillId)
		{
			return IsDirect == other.IsDirect;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is SkillEffectKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (SkillId.GetHashCode() * 397) ^ IsDirect.GetHashCode();
	}
}
