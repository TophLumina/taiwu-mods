using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Leg;

public class YuanShanTanTui : CombatSkillEffectBase
{
	private const sbyte RequirePursueCount = 2;

	private const sbyte PrepareProgressPercent = 50;

	public YuanShanTanTui()
	{
	}

	public YuanShanTanTui(CombatSkillKey skillKey)
		: base(skillKey, 5100, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 209, base.SkillTemplateId), EDataModifyType.Custom);
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
		if (attacker.GetId() == base.CharacterId && attacker.PursueAttackCount >= 2)
		{
			ItemKey weaponKey = DomainManager.Combat.GetUsingWeaponKey(attacker);
			if (ItemTemplateHelper.GetItemSubType(weaponKey.ItemType, weaponKey.TemplateId) == (base.IsDirect ? 9 : 8) && DomainManager.Combat.CanCastSkill(base.CombatChar, base.SkillTemplateId, costFree: true, checkRange: true))
			{
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && base.CombatChar.GetAutoCastingSkill())
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 / 100);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			ShowSpecialEffectTips(1);
			base.IsDirect = !base.IsDirect;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 209);
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 209)
		{
			return (!base.IsDirect) ? 1 : 0;
		}
		return dataValue;
	}
}
