using Config;
using GameData.Domains.Character.Relation;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;

namespace GameData.Domains.Taiwu;

public static class SkillBreakPlateBonusHelper
{
	public static SkillBreakPlateBonus CreateItem(ItemKey key)
	{
		return SkillBreakPlateBonus.CreateItem(key.ItemType, key.TemplateId);
	}

	public static SkillBreakPlateBonus CreateExp(int level)
	{
		return SkillBreakPlateBonus.CreateExp(level);
	}

	public static SkillBreakPlateBonus CreateRelation(int charId, int relatedCharId, ushort relationType)
	{
		if ((relationType != 16384 && relationType != 32768) || 1 == 0)
		{
			return SkillBreakPlateBonus.Invalid;
		}
		if (!DomainManager.Character.HasRelation(charId, relatedCharId, relationType) || !DomainManager.Character.HasRelation(relatedCharId, charId, relationType))
		{
			return SkillBreakPlateBonus.Invalid;
		}
		RelationKey relationKey = new RelationKey(charId, relatedCharId);
		short favorability = DomainManager.Character.GetFavorability(charId, relatedCharId);
		return SkillBreakPlateBonus.CreateRelation(relationKey, relationType, favorability);
	}

	public static SkillBreakPlateBonus CreateFriend(int charId, int relatedCharId, short skillId)
	{
		CombatSkillItem config = Config.CombatSkill.Instance[skillId];
		if (config == null)
		{
			return SkillBreakPlateBonus.Invalid;
		}
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return SkillBreakPlateBonus.Invalid;
		}
		if (character.GetCreatingType() != 1)
		{
			return SkillBreakPlateBonus.Invalid;
		}
		if (!character.GetLearnedCombatSkills().Contains(skillId))
		{
			return SkillBreakPlateBonus.Invalid;
		}
		if (!DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: charId, skillId: skillId), out var skill))
		{
			return SkillBreakPlateBonus.Invalid;
		}
		if (!CombatSkillStateHelper.IsBrokenOut(skill.GetActivationState()))
		{
			return SkillBreakPlateBonus.Invalid;
		}
		RelationKey relationKey = new RelationKey(charId, relatedCharId);
		short attainment = character.GetCombatSkillAttainment(config.Type);
		short favorability = DomainManager.Character.GetFavorability(charId, relatedCharId);
		return SkillBreakPlateBonus.CreateFriend(relationKey, attainment, favorability);
	}
}
