using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.RanChenZi;

public class YiJianRongChenYin : CombatSkillEffectBase
{
	private const sbyte AddHitOdds = 100;

	private const sbyte ReduceHitOdds = -50;

	private bool _affected;

	public YiJianRongChenYin()
	{
	}

	public YiJianRongChenYin(CombatSkillKey skillKey)
		: base(skillKey, 17130, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_affected = false;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 74, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 107, -1), EDataModifyType.TotalPercent);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (!IsSrcSkillPerformed)
		{
			IsSrcSkillPerformed = true;
			AddMaxEffectCount();
			ShowSpecialEffectTips(0);
			sbyte taskStatus = DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(6).JuniorXiangshuTaskStatus;
			if (taskStatus > 4)
			{
				bool goodEnding = taskStatus == 6;
				if (goodEnding)
				{
					DomainManager.Combat.RemoveAllAcupoint(context, base.CurrEnemyChar);
				}
				else
				{
					DomainManager.Combat.AddAcupoint(context, base.CurrEnemyChar, 3, SkillKey, -1);
				}
				ShowSpecialEffectTips(goodEnding, 1, 2);
			}
		}
		else
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

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (_affected)
		{
			_affected = false;
			ReduceEffectCount();
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (_affected)
		{
			_affected = false;
			ReduceEffectCount();
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		_affected = true;
		return (dataKey.FieldId == 74) ? 100 : (-50);
	}
}
