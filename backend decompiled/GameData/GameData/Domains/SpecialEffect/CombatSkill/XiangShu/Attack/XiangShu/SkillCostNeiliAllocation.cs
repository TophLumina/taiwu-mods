using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.XiangShu;

public class SkillCostNeiliAllocation : CombatSkillEffectBase
{
	protected sbyte CostNeiliAllocationPerGrade;

	private DataUid _enemyNeiliAllocationUid;

	protected SkillCostNeiliAllocation()
	{
	}

	protected SkillCostNeiliAllocation(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		if (IsSrcSkillPerformed)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyNeiliAllocationUid, base.DataHandlerKey);
		}
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (!IsSrcSkillPerformed)
		{
			if (PowerMatchAffectRequire(power))
			{
				IsSrcSkillPerformed = true;
				AddMaxEffectCount();
				AppendAffectedAllEnemyData(context, 231, EDataModifyType.Custom, -1);
				AppendAffect(context);
				UpdateEnemyUid(context, init: true);
				ShowSpecialEffectTips(0);
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (isAlly != base.CombatChar.IsAlly && IsSrcSkillPerformed && !DomainManager.Combat.GetElement_CombatCharacterDict(charId).GetAutoCastingSkill() && base.IsCurrent)
		{
			ReduceEffectCount();
		}
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (IsSrcSkillPerformed)
		{
			if (isAlly != base.CombatChar.IsAlly)
			{
				UpdateEnemyUid(context, init: false);
			}
			else
			{
				DomainManager.Combat.UpdateSkillCanUse(context, base.EnemyChar);
			}
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	private void OnEnemyNeiliAllocationChanged(DataContext context, DataUid dataUid)
	{
		DomainManager.Combat.UpdateSkillCanUse(context, DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly));
	}

	protected virtual void AppendAffect(DataContext context)
	{
	}

	private void UpdateEnemyUid(DataContext context, bool init)
	{
		CombatCharacter currEnemy = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		if (!init)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyNeiliAllocationUid, base.DataHandlerKey);
		}
		_enemyNeiliAllocationUid = new DataUid(8, 10, (ulong)currEnemy.GetId(), 3u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_enemyNeiliAllocationUid, base.DataHandlerKey, OnEnemyNeiliAllocationChanged);
		DomainManager.Combat.UpdateSkillCanUse(context, currEnemy);
	}

	public override (sbyte, sbyte) GetModifiedValue(AffectedDataKey dataKey, (sbyte, sbyte) dataValue)
	{
		if (!base.IsCurrent)
		{
			return dataValue;
		}
		CombatSkillItem skillConfig = Config.CombatSkill.Instance[dataKey.CombatSkillId];
		dataValue.Item1 = (sbyte)(skillConfig.EquipType - 1);
		dataValue.Item2 = (sbyte)(dataValue.Item2 + CostNeiliAllocationPerGrade * (skillConfig.Grade + 1));
		return dataValue;
	}
}
