using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JinHuangEr;

public class AddFlaw : CombatSkillEffectBase
{
	private const short AffectFrameCount = 180;

	private const sbyte FlawLevel = 2;

	protected sbyte FlawCount;

	private int _frameCounter;

	private bool _registeredStateMachineUpdateEnd;

	protected AddFlaw()
	{
	}

	protected AddFlaw(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_registeredStateMachineUpdateEnd = false;
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
		if (_registeredStateMachineUpdateEnd)
		{
			Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (!IsSrcSkillPerformed)
		{
			if (!interrupted)
			{
				IsSrcSkillPerformed = true;
				_frameCounter = 0;
				_registeredStateMachineUpdateEnd = true;
				AddMaxEffectCount();
				Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (!interrupted)
		{
			RemoveSelf(context);
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (base.CombatChar != combatChar || DomainManager.Combat.Pause)
		{
			return;
		}
		_frameCounter++;
		if (_frameCounter >= 180)
		{
			_frameCounter = 0;
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			for (int i = 0; i < FlawCount; i++)
			{
				DomainManager.Combat.AddFlaw(context, enemyChar, 2, SkillKey, -1);
			}
			DomainManager.Combat.AddToCheckFallenSet(enemyChar.GetId());
			ShowSpecialEffectTips(0);
			ReduceEffectCount();
		}
	}
}
