using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Throw;

public class JiuChiXiang : CombatSkillEffectBase
{
	private const sbyte AddDamage = 80;

	private const sbyte InterruptPreparePercent = 90;

	private const sbyte InterruptOdds = 40;

	private int _affectCharId;

	public JiuChiXiang()
	{
	}

	public JiuChiXiang(CombatSkillKey skillKey)
		: base(skillKey, 10404, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_PrepareSkillProgressChange(OnPrepareSkillProgressChange);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_PrepareSkillProgressChange(OnPrepareSkillProgressChange);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (IsSrcSkillPerformed && !base.IsDirect && attacker.IsAlly && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			ShowSpecialEffectTips(1);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!IsSrcSkillPerformed)
		{
			if (charId == base.CharacterId && skillId == base.SkillTemplateId)
			{
				if (PowerMatchAffectRequire(power))
				{
					IsSrcSkillPerformed = true;
					_affectCharId = (base.IsDirect ? base.CurrEnemyChar.GetId() : base.CharacterId);
					AppendAffectedData(context, _affectCharId, 69, EDataModifyType.AddPercent, -1);
					AddMaxEffectCount();
				}
				else
				{
					RemoveSelf(context);
				}
			}
		}
		else if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
		else if (charId == _affectCharId && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			ReduceEffectCount();
		}
	}

	private void OnPrepareSkillProgressChange(DataContext context, int charId, bool isAlly, short skillId, sbyte preparePercent)
	{
		if (IsSrcSkillPerformed && preparePercent == 90 && charId == _affectCharId && Config.CombatSkill.Instance[skillId].EquipType == 1 && context.Random.CheckPercentProb((base.EffectCount % 2 == 1) ? 40 : (base.IsDirect ? 80 : 20)))
		{
			DomainManager.Combat.InterruptSkill(context, DomainManager.Combat.GetElement_CombatCharacterDict(charId));
			ShowSpecialEffectTips(0);
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!IsSrcSkillPerformed)
		{
			return 0;
		}
		if (dataKey.FieldId == 69 && dataKey.CombatSkillId >= 0)
		{
			ShowSpecialEffectTips(1);
			return 80;
		}
		return 0;
	}
}
