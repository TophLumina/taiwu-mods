using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Finger;

public class DaTaiYinYiMingZhi : CombatSkillEffectBase
{
	private const short CombatStatePower = 200;

	public DaTaiYinYiMingZhi()
	{
	}

	public DaTaiYinYiMingZhi(CombatSkillKey skillKey)
		: base(skillKey, 8207, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power))
			{
				NeiliAllocation neiliAllocation = base.CurrEnemyChar.GetNeiliAllocation();
				byte neiliAllocationType = (byte)(base.IsDirect ? 2 : 0);
				base.CurrEnemyChar.ChangeNeiliAllocation(context, neiliAllocationType, -neiliAllocation[neiliAllocationType], applySpecialEffect: false);
				DomainManager.Combat.AddCombatState(context, base.CurrEnemyChar, 0, 41, 200);
				ShowSpecialEffectTips(0);
			}
			RemoveSelf(context);
		}
	}
}
