using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Finger;

public class CuoShenZhi : BuffByNeiliAllocation
{
	private static readonly CValuePercent ProgressPercent = 75;

	public CuoShenZhi()
	{
	}

	public CuoShenZhi(CombatSkillKey skillKey)
		: base(skillKey, 13107)
	{
		RequireNeiliAllocationType = 1;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		base.OnDisable(context);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (SkillKey.IsMatch(charId, skillId) && base.Affecting)
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * ProgressPercent);
		}
	}
}
