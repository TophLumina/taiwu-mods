using System.Runtime.CompilerServices;
using System.Text;
using Config;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.Combat.Ai.Selector;

public readonly record struct CombatSkillSelectorContext(CombatSkillKey SkillKey)
{
	public short TemplateId => SkillKey.SkillTemplateId;

	public CombatSkillItem Template => Config.CombatSkill.Instance[SkillKey.SkillTemplateId];

	public GameData.Domains.CombatSkill.CombatSkill CombatSkill => DomainManager.CombatSkill.GetElement_CombatSkills(SkillKey);

	public readonly CombatSkillKey SkillKey = SkillKey;

	[CompilerGenerated]
	private bool PrintMembers(StringBuilder builder)
	{
		builder.Append("SkillKey = ");
		builder.Append(SkillKey.ToString());
		builder.Append(", TemplateId = ");
		builder.Append(TemplateId.ToString());
		builder.Append(", Template = ");
		builder.Append(Template);
		builder.Append(", CombatSkill = ");
		builder.Append(CombatSkill);
		return true;
	}

	[CompilerGenerated]
	public void Deconstruct(out CombatSkillKey SkillKey)
	{
		SkillKey = this.SkillKey;
	}
}
