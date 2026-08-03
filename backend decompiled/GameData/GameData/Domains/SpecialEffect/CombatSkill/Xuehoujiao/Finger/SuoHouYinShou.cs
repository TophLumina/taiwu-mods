using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Finger;

public class SuoHouYinShou : CombatSkillEffectBase
{
	private const sbyte AddPrepareProgressUnit = 50;

	private const sbyte AddPowerUnit = 20;

	private const sbyte ReduceBreathStance = -40;

	private const sbyte EffectPartType = 1;

	public SuoHouYinShou()
	{
	}

	public SuoHouYinShou(CombatSkillKey skillKey)
		: base(skillKey, 15201, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		DomainManager.Combat.AddSkillEffect(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), 0, base.MaxEffectCount, autoRemoveOnNoCount: false);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (hit && attacker == base.CombatChar && base.EffectCount < base.MaxEffectCount && DomainManager.Combat.IsCurrentCombatCharacter(base.CurrEnemyChar) && attacker.NormalAttackBodyPart == 1)
		{
			DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), 1);
			ShowSpecialEffectTips(0);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 * base.EffectCount / 100);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId)
		{
			return;
		}
		if (skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power))
			{
				if (base.IsDirect)
				{
					ChangeStanceValue(context, base.CurrEnemyChar, -1600);
				}
				else
				{
					ChangeBreathValue(context, base.CurrEnemyChar, -12000);
				}
				ShowSpecialEffectTips(1);
			}
			ReduceEffectCount(base.EffectCount);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
		else if (power > 0 && Config.CombatSkill.Instance[skillId].EquipType == 1 && DomainManager.Combat.IsCurrentCombatCharacter(base.CurrEnemyChar) && base.CombatChar.SkillAttackBodyPart == 1 && base.EffectCount < base.MaxEffectCount)
		{
			DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), 1);
			ShowSpecialEffectTips(0);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return 20 * base.EffectCount;
		}
		return 0;
	}
}
