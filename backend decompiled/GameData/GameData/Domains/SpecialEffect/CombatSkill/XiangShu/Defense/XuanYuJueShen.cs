using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Defense;

public class XuanYuJueShen : DefenseSkillBase
{
	private const sbyte AffectFrame = 60;

	private const sbyte AddPoison = 100;

	private int _frameCounter;

	public XuanYuJueShen()
	{
	}

	public XuanYuJueShen(CombatSkillKey skillKey)
		: base(skillKey, 16309)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_frameCounter = 0;
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
		ShowSpecialEffectTips(0);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (base.CombatChar != combatChar || DomainManager.Combat.Pause)
		{
			return;
		}
		_frameCounter++;
		if (_frameCounter < 60 || !base.CanAffect)
		{
			return;
		}
		_frameCounter = 0;
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		switch (enemyChar.GetCharacter().GetBehaviorType())
		{
		case 0:
			enemyChar.AddRandomInjury(context, inner: false);
			break;
		case 1:
			enemyChar.AddRandomInjury(context, inner: true);
			break;
		case 2:
		{
			for (sbyte type = 0; type < 6; type++)
			{
				DomainManager.Combat.AddPoison(context, base.CombatChar, enemyChar, type, 3, 100, -1);
			}
			break;
		}
		case 3:
			DomainManager.Combat.AddAcupoint(context, enemyChar, 2, new CombatSkillKey(-1, -1), -1);
			break;
		case 4:
			DomainManager.Combat.AddFlaw(context, enemyChar, 2, new CombatSkillKey(-1, -1), -1);
			break;
		}
	}
}
