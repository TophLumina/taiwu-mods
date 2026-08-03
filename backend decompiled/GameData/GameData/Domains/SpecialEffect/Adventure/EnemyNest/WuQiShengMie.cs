using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Adventure.EnemyNest;

public class WuQiShengMie : FeatureEffectBase
{
	private const int AddOrReducePower = 50;

	private CombatSkillKey _affectingKey;

	private int _affectingValue;

	private sbyte NeiliFiveElementsType => (sbyte)NeiliType.Instance[base.CombatChar.GetNeiliType()].FiveElements;

	public WuQiShengMie()
	{
	}

	public WuQiShengMie(int charId, short featureId)
		: base(charId, featureId, 100000)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_affectingKey = new CombatSkillKey(-1, -1);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId))
		{
			AppendAffectedAllEnemyData(context, 199, EDataModifyType.TotalPercent, -1);
		}
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		_affectingKey = new CombatSkillKey(-1, -1);
		ClearAffectedData(context);
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (!DomainManager.Combat.IsCharInCombat(base.CharacterId) || isAlly == base.CombatChar.IsAlly || !CombatSkillEquipType.IsAttack(skillId))
		{
			return;
		}
		CombatSkillKey skillKey = new CombatSkillKey(charId, skillId);
		if (IsCountered(skillKey))
		{
			_affectingValue = 50;
		}
		else
		{
			if (!IsDifferentAndNotCountered(skillKey))
			{
				return;
			}
			_affectingValue = -50;
		}
		_affectingKey = skillKey;
		InvalidateCache(context, charId, 199);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool _)
	{
		if (_affectingKey.IsMatch(charId, skillId))
		{
			_affectingKey = new CombatSkillKey(-1, -1);
			InvalidateCache(context, charId, 199);
		}
	}

	private bool IsDifferentAndNotCountered(CombatSkillKey skillKey)
	{
		if (FiveElementsEquals(skillKey, NeiliFiveElementsType))
		{
			return false;
		}
		return !IsCountered(skillKey);
	}

	private bool IsCountered(CombatSkillKey skillKey)
	{
		if (NeiliFiveElementsType == 5)
		{
			return false;
		}
		sbyte counteredType = FiveElementsType.Countered[NeiliFiveElementsType];
		return FiveElementsEquals(skillKey, counteredType);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.SkillKey == _affectingKey && dataKey.FieldId == 199)
		{
			return _affectingValue;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
