using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Shot;

public class ShiErXianQiZhenGong : CombatSkillEffectBase
{
	private const int CostMaxChangeTrickCount = 12;

	private const int CostChangeTrickCountUnit = 4;

	private const int FlawOrAcupointLevel = 2;

	private const int TransferFiveElementsValue = 12;

	private int _affectingEffectCount;

	public ShiErXianQiZhenGong()
	{
	}

	public ShiErXianQiZhenGong(CombatSkillKey skillKey)
		: base(skillKey, 3208, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(300, EDataModifyType.Add, -1);
		Events.RegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_ChangeTrickCountChanged(OnChangeTrickCountChanged);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_ChangeTrickCountChanged(OnChangeTrickCountChanged);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	private void OnNormalAttackCalcHitEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, int pursueIndex, bool hit, bool isFightback, bool isMind)
	{
		if (attacker.GetId() == base.CharacterId && hit && attacker.GetChangeTrickAttack() && _affectingEffectCount > 0 && pursueIndex <= 0)
		{
			sbyte fiveElementsType = BodyPartType.TransferToFiveElementsType(attacker.NormalAttackBodyPart);
			if (fiveElementsType >= 0)
			{
				defender.ChangeToProportion(context, fiveElementsType, 12 * _affectingEffectCount);
				ShowSpecialEffectTips(1);
			}
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (!SkillKey.IsMatch(attacker.GetId(), skillId))
		{
			return;
		}
		int costedChangeTrickCount = Math.Min((int)base.CombatChar.GetChangeTrickCount(), 12);
		int unit = costedChangeTrickCount / 4;
		costedChangeTrickCount = unit * 4;
		if (costedChangeTrickCount > 0)
		{
			if (base.IsDirect)
			{
				DomainManager.Combat.AddAcupoint(context, defender, 2, SkillKey, base.CombatChar.SkillAttackBodyPart, unit);
			}
			else
			{
				DomainManager.Combat.AddFlaw(context, defender, 2, SkillKey, base.CombatChar.SkillAttackBodyPart, unit);
			}
			DomainManager.Combat.ChangeChangeTrickCount(context, base.CombatChar, -costedChangeTrickCount);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power))
		{
			int newEffectCount = base.MaxEffectCount - base.EffectCount;
			if (newEffectCount != 0)
			{
				AddMaxEffectCount();
				DomainManager.Combat.ChangeChangeTrickCount(context, base.CombatChar, newEffectCount);
			}
		}
	}

	private void OnChangeTrickCountChanged(DataContext context, CombatCharacter character, int addValue, bool bySelectChangeTrick)
	{
		if (character == base.CombatChar && addValue < 0 && base.EffectCount > 0)
		{
			ReduceEffectCount(Math.Abs(addValue));
			if (bySelectChangeTrick)
			{
				_affectingEffectCount += Math.Abs(addValue);
			}
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (attacker.GetId() == base.CharacterId)
		{
			_affectingEffectCount = 0;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 300)
		{
			return 0;
		}
		return base.EffectCount;
	}
}
