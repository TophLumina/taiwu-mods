using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.MoNv;

public class AddPoison : CombatSkillEffectBase
{
	private const short AffectFrameCount = 30;

	private const short PoisonPercent = 20;

	protected sbyte PoisonTypeCount;

	private int _frameCounter;

	protected AddPoison()
	{
	}

	protected AddPoison(CombatSkillKey skillKey, int type)
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

	private unsafe void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (base.CombatChar != combatChar || DomainManager.Combat.Pause)
		{
			return;
		}
		_frameCounter++;
		if (_frameCounter >= 30 && DomainManager.Combat.InAttackRange(base.CombatChar))
		{
			_frameCounter = 0;
			PoisonsAndLevels skillPoisons = base.SkillInstance.GetPoisons();
			int skillPower = base.SkillInstance.GetPower();
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			List<sbyte> typeList = ObjectPool<List<sbyte>>.Instance.Get();
			typeList.Clear();
			for (sbyte type = 0; type < 6; type++)
			{
				typeList.Add(type);
			}
			while (typeList.Count > PoisonTypeCount)
			{
				typeList.RemoveAt(context.Random.Next(typeList.Count));
			}
			for (int i = 0; i < typeList.Count; i++)
			{
				sbyte type2 = typeList[i];
				DomainManager.Combat.AddPoison(context, base.CombatChar, enemyChar, type2, skillPoisons.Levels[type2], skillPoisons.Values[type2] * skillPower / 100 * 20 / 100, base.SkillTemplateId);
			}
			ObjectPool<List<sbyte>>.Instance.Return(typeList);
			DomainManager.Combat.AddToCheckFallenSet(enemyChar.GetId());
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
