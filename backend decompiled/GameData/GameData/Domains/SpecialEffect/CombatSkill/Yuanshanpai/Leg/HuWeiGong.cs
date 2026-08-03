using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Leg;

public class HuWeiGong : CombatSkillEffectBase
{
	private const sbyte AddAttackRange = 30;

	private const sbyte PrepareProgressPercent = 50;

	private bool _addingRange;

	public HuWeiGong()
	{
	}

	public HuWeiGong(CombatSkillKey skillKey)
		: base(skillKey, 5102, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AddMaxEffectCount(autoRemoveOnNoCount: false);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 145, base.SkillTemplateId), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 146, base.SkillTemplateId), EDataModifyType.Add);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (defender.GetId() == base.CharacterId && base.EffectCount > 0)
		{
			TryAutoCast(context);
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && base.CombatChar.GetAutoCastingSkill())
		{
			ReduceEffectCount();
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 / 100);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			_addingRange = false;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 145);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 146);
			if (PowerMatchAffectRequire(power) && !base.CombatChar.GetAutoCastingSkill())
			{
				DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), 1);
			}
		}
		else if (isAlly != base.CombatChar.IsAlly && base.EffectCount > 0 && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			TryAutoCast(context);
		}
	}

	private void TryAutoCast(DataContext context)
	{
		OuterAndInnerShorts attackRange = base.CombatChar.GetAttackRange();
		short currDistance = DomainManager.Combat.GetCurrentDistance();
		if (base.IsDirect ? (currDistance > attackRange.Inner) : (currDistance < attackRange.Outer))
		{
			_addingRange = true;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 145);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 146);
			if (DomainManager.Combat.CanCastSkill(base.CombatChar, base.SkillTemplateId, costFree: true))
			{
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
				ShowSpecialEffectTips(0);
			}
			else
			{
				_addingRange = false;
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 145);
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 146);
			}
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
			return _addingRange ? 30 : 0;
		}
		return 0;
	}
}
