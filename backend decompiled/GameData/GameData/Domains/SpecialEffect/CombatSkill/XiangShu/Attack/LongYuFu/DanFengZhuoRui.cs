using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.LongYuFu;

public class DanFengZhuoRui : CombatSkillEffectBase
{
	private const sbyte InjuryThreshold = 4;

	private const sbyte AddPrepareProgressUnit = 25;

	private const sbyte RecoverBreathStanceUnit = 25;

	private (int breath, int stance) _costBreathStance;

	public DanFengZhuoRui()
	{
	}

	public DanFengZhuoRui(CombatSkillKey skillKey)
		: base(skillKey, 17120, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	private void OnCostBreathAndStance(DataContext context, int charId, bool isAlly, int costBreath, int costStance, short skillId)
	{
		if (base.CharacterId == charId && skillId == base.SkillTemplateId)
		{
			_costBreathStance.breath = costBreath;
			_costBreathStance.stance = costStance;
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			Injuries injuries = base.CombatChar.GetInjuries();
			int addedInjury = 0;
			if (injuries.Get(3, isInnerInjury: false) < 4)
			{
				base.CombatChar.AddInjury(context, 3, isInner: false, 1, updateDefeatMark: true);
				addedInjury++;
			}
			if (injuries.Get(4, isInnerInjury: false) < 4)
			{
				base.CombatChar.AddInjury(context, 4, isInner: false, 1, updateDefeatMark: true);
				addedInjury++;
			}
			if (addedInjury > 0)
			{
				DomainManager.Combat.AddToCheckFallenSet(base.CombatChar.GetId());
				DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 25 * addedInjury / 100);
				ChangeBreathValue(context, base.CombatChar, _costBreathStance.breath * 25 * addedInjury / 100);
				ChangeStanceValue(context, base.CombatChar, _costBreathStance.stance * 25 * addedInjury / 100);
				ShowSpecialEffectTips(0);
			}
		}
	}
}
