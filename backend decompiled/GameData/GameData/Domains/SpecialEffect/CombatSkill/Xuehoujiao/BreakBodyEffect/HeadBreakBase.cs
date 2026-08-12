using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public class HeadBreakBase : BreakBodyEffectBase
{
	private const sbyte NeedAttackCount = 1;

	private const sbyte ReduceHitAvoid = -40;

	private sbyte _attackAccumulator;

	private sbyte _defendAccumulator;

	private bool _hitAffecting;

	private bool _avoidAffecting;

	protected override bool IsAffectBodyParts(sbyte bodyPart)
	{
		return bodyPart == 2;
	}

	protected HeadBreakBase()
	{
	}

	protected HeadBreakBase(int charId, int type)
		: base(charId, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 56, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 57, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 58, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 59, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 94, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 95, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 96, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 97, -1), EDataModifyType.TotalPercent);
		Events.RegisterHandler_CombatBegin(RegisterAttackHandler);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
		RegisterAttackHandler(context);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_CombatBegin(RegisterAttackHandler);
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId))
		{
			Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
			Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		}
	}

	private void RegisterAttackHandler(DataContext context)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId))
		{
			_attackAccumulator = 0;
			_defendAccumulator = 0;
			_hitAffecting = false;
			_avoidAffecting = false;
			Events.RegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
			Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		}
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId, checkCombatStatus: false))
		{
			Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
			Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		}
	}

	private void OnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		if (pursueIndex > 0)
		{
			return;
		}
		if (attacker == base.CombatChar)
		{
			_attackAccumulator++;
			if (_attackAccumulator >= 1)
			{
				_attackAccumulator--;
				_hitAffecting = true;
				DomainManager.Combat.ShowSpecialEffectTips(base.CharacterId, IsInner ? 1301 : 575, 2);
			}
		}
		else if (defender == base.CombatChar)
		{
			_defendAccumulator++;
			if (_defendAccumulator >= 1)
			{
				_defendAccumulator--;
				_avoidAffecting = true;
				DomainManager.Combat.ShowSpecialEffectTips(base.CharacterId, IsInner ? 1301 : 575, 2);
			}
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (attacker == base.CombatChar)
		{
			_hitAffecting = false;
		}
		else if (defender == base.CombatChar)
		{
			_avoidAffecting = false;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (_hitAffecting && (dataKey.FieldId == 56 || dataKey.FieldId == 57 || dataKey.FieldId == 58 || dataKey.FieldId == 59))
		{
			return -40;
		}
		if (_avoidAffecting && (dataKey.FieldId == 94 || dataKey.FieldId == 95 || dataKey.FieldId == 96 || dataKey.FieldId == 97))
		{
			return -40;
		}
		return 0;
	}
}
