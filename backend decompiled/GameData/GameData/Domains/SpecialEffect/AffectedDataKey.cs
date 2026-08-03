using System;
using Config;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect;

public readonly struct AffectedDataKey : IEquatable<AffectedDataKey>
{
	public readonly int CharId;

	public readonly short CombatSkillId;

	public readonly ushort FieldId;

	public readonly int CustomParam0;

	public readonly int CustomParam1;

	public readonly int CustomParam2;

	public CombatSkillKey SkillKey => new CombatSkillKey(CharId, CombatSkillId);

	public CombatSkillItem SkillTemplate => Config.CombatSkill.Instance[CombatSkillId];

	public bool IsNormalAttack => CombatSkillId < 0;

	public bool IsMatch(CombatSkillKey skillKey)
	{
		return CharId == skillKey.CharId && CombatSkillId == skillKey.SkillTemplateId;
	}

	public AffectedDataKey(int charId, ushort fieldId, short combatSkillId = -1, int customParam0 = -1, int customParam1 = -1, int customParam2 = -1)
	{
		CharId = charId;
		CombatSkillId = combatSkillId;
		FieldId = fieldId;
		CustomParam0 = customParam0;
		CustomParam1 = customParam1;
		CustomParam2 = customParam2;
	}

	public bool Equals(AffectedDataKey other)
	{
		return CharId == other.CharId && FieldId == other.FieldId;
	}

	public override bool Equals(object obj)
	{
		return obj is AffectedDataKey other && Equals(other);
	}

	public override int GetHashCode()
	{
		int hashCode = CharId;
		return (hashCode * 397) ^ FieldId.GetHashCode();
	}
}
