using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.FistAndPalm;

public class ChaiShanWuQinQuan : CombatSkillEffectBase
{
	private const sbyte ReduceDamagePercent = -15;

	private bool _affected;

	public ChaiShanWuQinQuan()
	{
	}

	public ChaiShanWuQinQuan(CombatSkillKey skillKey)
		: base(skillKey, 10100, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (IsSrcSkillPerformed && defender.GetId() == base.CharacterId && _affected)
		{
			_affected = false;
			ReduceEffectCount();
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!IsSrcSkillPerformed)
		{
			if (charId == base.CharacterId && skillId == base.SkillTemplateId)
			{
				IsSrcSkillPerformed = true;
				if (PowerMatchAffectRequire(power))
				{
					AppendAffectedData(context, base.CharacterId, 102, EDataModifyType.AddPercent, -1);
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
		else if (Config.CombatSkill.Instance[skillId].EquipType == 1 && _affected)
		{
			_affected = false;
			ReduceEffectCount();
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
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 102 && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0))
		{
			if (!_affected)
			{
				_affected = true;
				ShowSpecialEffectTips(0);
			}
			return -15;
		}
		return 0;
	}
}
