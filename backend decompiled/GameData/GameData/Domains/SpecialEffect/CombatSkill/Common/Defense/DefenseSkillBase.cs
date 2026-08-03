using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

public class DefenseSkillBase : CombatSkillEffectBase
{
	protected bool AutoRemove = true;

	protected bool ListenCanAffectChange = false;

	protected bool CanAffect => base.SkillData.GetCanAffect() && base.CombatChar.GetAffectingDefendSkillId() == base.SkillTemplateId;

	protected DefenseSkillBase()
	{
	}

	protected DefenseSkillBase(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		DataUid defendSkillUid = ParseCombatCharacterDataUid(63);
		AutoMonitor(defendSkillUid, OnDefendSkillChanged);
		if (ListenCanAffectChange)
		{
			DataUid defendSkillCanAffectUid = ParseCombatSkillDataUid(9);
			AutoMonitor(defendSkillCanAffectUid, OnDefendSkillCanAffectChanged);
		}
	}

	private void OnDefendSkillChanged(DataContext context, DataUid dataUid)
	{
		if (base.CombatChar.GetAffectingDefendSkillId() != base.SkillTemplateId && AutoRemove)
		{
			RemoveSelf(context);
		}
	}

	protected virtual void OnDefendSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
	}
}
