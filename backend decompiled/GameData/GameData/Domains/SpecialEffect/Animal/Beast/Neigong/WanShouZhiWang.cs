using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal.Beast.Neigong;

public class WanShouZhiWang : AnimalEffectBase
{
	private const int ReduceHitOddsUnit = -10;

	private bool _addDirectInjury;

	private int _perpetualAttackCount;

	private int AddDamagePercentUnit => base.IsElite ? 40 : 20;

	public WanShouZhiWang()
	{
	}

	public WanShouZhiWang(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 74, -1), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_NormalAttackPrepareEnd(OnNormalAttackPrepareEnd);
		Events.RegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackPrepareEnd(OnNormalAttackPrepareEnd);
		Events.UnRegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	private void OnNormalAttackPrepareEnd(DataContext context, int charId, bool isAlly)
	{
		if (charId == base.CharacterId)
		{
			_addDirectInjury = false;
		}
	}

	private void OnAddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		if (attackerId == base.CharacterId && outerMarkCount + innerMarkCount > 0)
		{
			_addDirectInjury = true;
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (attacker.GetId() == base.CharacterId)
		{
			if (_addDirectInjury)
			{
				_perpetualAttackCount++;
				base.CombatChar.NormalAttackFree();
				ShowSpecialEffectTips(0);
			}
			else
			{
				_perpetualAttackCount = 0;
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId >= 0)
		{
			return 0;
		}
		if (dataKey.FieldId == 69)
		{
			return _perpetualAttackCount * AddDamagePercentUnit;
		}
		if (dataKey.FieldId == 74)
		{
			return _perpetualAttackCount * -10;
		}
		return 0;
	}
}
