using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Neigong;

public class RuMoGong : CombatSkillEffectBase
{
	private const sbyte DirectReducePercentPerMark = -3;

	private const sbyte ReverseAddPercentPerMark = 3;

	public RuMoGong()
	{
	}

	public RuMoGong(CombatSkillKey skillKey)
		: base(skillKey, 14006, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 102 : 69), -1), EDataModifyType.TotalPercent);
		Events.RegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
	}

	private void OnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		if (base.CombatChar == (base.IsDirect ? defender : attacker) && DomainManager.Combat.InAttackRange(attacker) && base.CombatChar.GetDefeatMarkCollection().FatalDamageMarkCount > 0 && pursueIndex == 0)
		{
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (base.CombatChar == (base.IsDirect ? defender : attacker) && DomainManager.Combat.InAttackRange(attacker) && base.CombatChar.GetDefeatMarkCollection().FatalDamageMarkCount > 0)
		{
			ShowSpecialEffectTips(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		int fatalMarkCount = base.CombatChar.GetDefeatMarkCollection().FatalDamageMarkCount;
		if (dataKey.FieldId == 102)
		{
			return -3 * fatalMarkCount;
		}
		if (dataKey.FieldId == 69)
		{
			return 3 * fatalMarkCount;
		}
		return 0;
	}
}
