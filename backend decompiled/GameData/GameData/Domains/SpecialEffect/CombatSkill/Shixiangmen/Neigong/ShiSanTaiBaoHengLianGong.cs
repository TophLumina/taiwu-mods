using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Neigong;

public class ShiSanTaiBaoHengLianGong : CombatSkillEffectBase
{
	private const sbyte DamageChangePercentPerCast = 15;

	private const sbyte MaxAccumulateCount = 3;

	private short _lastCastSkillId;

	private sbyte _accumulateCount;

	public ShiSanTaiBaoHengLianGong()
	{
	}

	public ShiSanTaiBaoHengLianGong(CombatSkillKey skillKey)
		: base(skillKey, 6001, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_lastCastSkillId = -1;
		_accumulateCount = 0;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 102 : 69), -1), EDataModifyType.TotalPercent);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (base.CharacterId != (base.IsDirect ? defender.GetId() : attacker.GetId()) || !DomainManager.Combat.InAttackRange(attacker))
		{
			return;
		}
		if (skillId == _lastCastSkillId)
		{
			if (_accumulateCount < 3)
			{
				_accumulateCount++;
			}
			ShowSpecialEffectTips(0);
		}
		else
		{
			_lastCastSkillId = skillId;
			_accumulateCount = 0;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || _accumulateCount <= 0)
		{
			return 0;
		}
		if (dataKey.FieldId == 102)
		{
			return -15 * _accumulateCount;
		}
		if (dataKey.FieldId == 69)
		{
			return 15 * _accumulateCount;
		}
		return 0;
	}
}
