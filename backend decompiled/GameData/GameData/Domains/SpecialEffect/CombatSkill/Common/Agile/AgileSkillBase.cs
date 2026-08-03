using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

public class AgileSkillBase : CombatSkillEffectBase
{
	protected bool AutoRemove = true;

	protected bool AgileSkillChanged = false;

	protected bool ListenCanAffectChange = false;

	protected bool CanAffect => base.SkillData.GetCanAffect() && base.CombatChar.GetAffectingMoveSkillId() == base.SkillTemplateId;

	protected AgileSkillBase()
	{
	}

	protected AgileSkillBase(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		base.CombatChar.SetAffectingMoveSkillId(base.CombatChar.GetAffectingMoveSkillId(), context);
		DataUid moveSkillUid = ParseCombatCharacterDataUid(62);
		AutoMonitor(moveSkillUid, OnMoveSkillChanged);
		if (ListenCanAffectChange)
		{
			DataUid canAffectUid = ParseCombatSkillDataUid(9);
			AutoMonitor(canAffectUid, OnMoveSkillCanAffectChanged);
		}
	}

	protected virtual void OnMoveSkillChanged(DataContext context, DataUid dataUid)
	{
		if (base.CombatChar.GetAffectingMoveSkillId() != base.SkillTemplateId)
		{
			if (AutoRemove)
			{
				RemoveSelf(context);
			}
			else
			{
				AgileSkillChanged = true;
			}
		}
	}

	protected virtual void OnMoveSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
	}
}
