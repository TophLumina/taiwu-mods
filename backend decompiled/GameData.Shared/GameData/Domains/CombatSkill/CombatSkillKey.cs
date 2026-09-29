using System;
using Config;
using GameData.Serializer;

namespace GameData.Domains.CombatSkill;

public struct CombatSkillKey : ISerializableGameData, IEquatable<CombatSkillKey>
{
	public int CharId;

	public short SkillTemplateId;

	public static CombatSkillKey Invalid => new CombatSkillKey(-1, -1);

	public bool IsValid
	{
		get
		{
			if (CharId >= 0)
			{
				return SkillTemplateId >= 0;
			}
			return false;
		}
	}

	public bool IsMatch(int charId, short skillId)
	{
		if (CharId == charId)
		{
			return skillId == SkillTemplateId;
		}
		return false;
	}

	public CombatSkillKey(int charId, short skillTemplateId)
	{
		CharId = charId;
		SkillTemplateId = skillTemplateId;
	}

	public static explicit operator ulong(CombatSkillKey value)
	{
		return (ulong)(((long)value.SkillTemplateId << 32) + value.CharId);
	}

	public static explicit operator CombatSkillKey(ulong value)
	{
		return new CombatSkillKey((int)value, (short)(value >> 32));
	}

	public static implicit operator CombatSkillKey((int charId, short skillId) tup)
	{
		return new CombatSkillKey(tup.charId, tup.skillId);
	}

	public void Deconstruct(out int charId, out short skillId)
	{
		charId = CharId;
		skillId = SkillTemplateId;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 8;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = CharId;
		((short*)pData)[2] = SkillTemplateId;
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		CharId = *(int*)pData;
		SkillTemplateId = ((short*)pData)[2];
		return 8;
	}

	public static bool operator ==(CombatSkillKey lhs, CombatSkillKey rhs)
	{
		if (lhs.CharId == rhs.CharId)
		{
			return lhs.SkillTemplateId == rhs.SkillTemplateId;
		}
		return false;
	}

	public static bool operator !=(CombatSkillKey lhs, CombatSkillKey rhs)
	{
		if (lhs.CharId == rhs.CharId)
		{
			return lhs.SkillTemplateId != rhs.SkillTemplateId;
		}
		return true;
	}

	public bool Equals(CombatSkillKey other)
	{
		if (CharId == other.CharId)
		{
			return SkillTemplateId == other.SkillTemplateId;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is CombatSkillKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (CharId * 397) ^ SkillTemplateId.GetHashCode();
	}

	public override string ToString()
	{
		return $"CombatSkillKey[{CharId},{Config.CombatSkill.Instance[SkillTemplateId].Name}]";
	}
}
