using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Sword;

public class ShaJian : CombatSkillEffectBase
{
	private const int MakeFatalDamagePercentPerTrick = 10;

	private int _extraFlawCount;

	private int _makeDirectDamage;

	private CombatCharacter TrickChar => base.IsDirect ? base.CombatChar : base.EnemyChar;

	public ShaJian()
	{
	}

	public ShaJian(CombatSkillKey skillKey)
		: base(skillKey, 13204, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && DomainManager.Combat.InAttackRange(base.CombatChar))
		{
			_extraFlawCount = TrickChar.GetTrickCount(19);
			if (_extraFlawCount > 0)
			{
				AppendAffectedData(context, base.CharacterId, 84, EDataModifyType.Add, base.SkillTemplateId);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (SkillKey.IsMatch(attackerId, combatSkillId))
		{
			_makeDirectDamage += damageValue;
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			int trickCount = TrickChar.GetContinueTricksAtStart(19);
			if (trickCount > 0 && _makeDirectDamage > 0)
			{
				DomainManager.Combat.RemoveTrick(context, TrickChar, 19, (byte)trickCount);
				CValuePercent percent = 10 * trickCount;
				base.CurrEnemyChar.AddFatalDamage(context, _makeDirectDamage * percent, -1, -1, -1);
				ShowSpecialEffectTips(1);
				_makeDirectDamage = 0;
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
		if (dataKey.FieldId == 84)
		{
			return _extraFlawCount;
		}
		return 0;
	}
}
