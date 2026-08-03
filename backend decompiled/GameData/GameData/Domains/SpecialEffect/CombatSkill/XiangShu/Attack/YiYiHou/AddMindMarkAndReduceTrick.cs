using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiYiHou;

public class AddMindMarkAndReduceTrick : CombatSkillEffectBase
{
	protected short AffectFrameCount;

	private int _frameCounter;

	protected AddMindMarkAndReduceTrick()
	{
	}

	protected AddMindMarkAndReduceTrick(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (base.CombatChar != combatChar || DomainManager.Combat.Pause)
		{
			return;
		}
		_frameCounter++;
		if (_frameCounter >= AffectFrameCount && DomainManager.Combat.InAttackRange(base.CombatChar))
		{
			_frameCounter = 0;
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			if (enemyChar.GetTricks().Tricks.Count > 0)
			{
				List<sbyte> trickTypeRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
				trickTypeRandomPool.Clear();
				trickTypeRandomPool.AddRange(enemyChar.GetTricks().Tricks.Values);
				DomainManager.Combat.RemoveTrick(context, enemyChar, trickTypeRandomPool[context.Random.Next(0, trickTypeRandomPool.Count)], 1, removedByAlly: false);
				ObjectPool<List<sbyte>>.Instance.Return(trickTypeRandomPool);
				ShowSpecialEffectTips(1);
			}
			AddPowerDamageMind(context, enemyChar);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}
}
