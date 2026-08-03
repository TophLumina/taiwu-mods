using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.RanChenZi;

public class JiuJianGuiShenXia : CombatSkillEffectBase
{
	public JiuJianGuiShenXia()
	{
	}

	public JiuJianGuiShenXia(CombatSkillKey skillKey)
		: base(skillKey, 17135, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		DomainManager.Combat.AddMoveDistInSkillPrepare(base.CombatChar, 1000, forward: true);
		DomainManager.Combat.AddMoveDistInSkillPrepare(base.CombatChar, 1000, forward: false);
		base.CombatChar.CanNormalAttackInPrepareSkill = true;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 145, base.SkillTemplateId), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 146, base.SkillTemplateId), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 217, base.SkillTemplateId), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 215, base.SkillTemplateId), EDataModifyType.Custom);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.CombatChar.CanNormalAttackInPrepareSkill = false;
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		sbyte taskStatus = DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(8).JuniorXiangshuTaskStatus;
		if (taskStatus > 4)
		{
			bool goodEnding = taskStatus == 6;
			if (goodEnding)
			{
				base.CombatChar.SkillPrepareTotalProgress /= 2;
			}
			else
			{
				base.CombatChar.SkillPrepareTotalProgress = base.CombatChar.SkillPrepareTotalProgress * 150 / 100;
			}
			ShowSpecialEffectTips(goodEnding, 1, 2);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			DomainManager.Combat.AddToCheckFallenSet(base.CurrEnemyChar.GetId());
			if (!DomainManager.Combat.CheckFallenImmediate(context))
			{
				base.CombatChar.ForceDefeat = true;
				base.CombatChar.Immortal = false;
				DomainManager.Combat.AddToCheckFallenSet(base.CombatChar.GetId());
			}
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 145 || dataKey.FieldId == 146)
		{
			return 10000;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 217 || dataKey.FieldId == 215)
		{
			return false;
		}
		return dataValue;
	}
}
