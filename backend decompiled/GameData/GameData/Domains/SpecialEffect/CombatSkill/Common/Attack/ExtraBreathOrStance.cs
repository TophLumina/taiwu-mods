using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public abstract class ExtraBreathOrStance : CombatSkillEffectBase
{
	private static readonly CValuePercent AddAttackPercent = 50;

	private static readonly CValuePercent ReduceDefendPercent = -50;

	private int _costingBreathOrStancePercent;

	private int _costingEffectCount;

	protected abstract bool IsBreath { get; }

	private static bool IsAttack(short skillId)
	{
		return skillId >= 0 && Config.CombatSkill.Instance[skillId].EquipType == 1;
	}

	protected ExtraBreathOrStance()
	{
	}

	protected ExtraBreathOrStance(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData((ushort)(IsBreath ? 173 : 174), EDataModifyType.Add, -1);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CastSkillUseExtraBreathOrStance(OnCastSkillUseExtraBreathOrStance);
		Events.RegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CastSkillUseExtraBreathOrStance(OnCastSkillUseExtraBreathOrStance);
		Events.UnRegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (base.IsDirect)
		{
			AppendAffectedData(context, 44, EDataModifyType.AddPercent, -1);
			AppendAffectedData(context, 45, EDataModifyType.AddPercent, -1);
		}
		else
		{
			AppendAffectedAllEnemyData(context, 46, EDataModifyType.AddPercent, -1);
			AppendAffectedAllEnemyData(context, 47, EDataModifyType.AddPercent, -1);
		}
	}

	private void OnCastSkillUseExtraBreathOrStance(DataContext context, int charId, short skillId, int extraBreath, int extraStance)
	{
		if (charId == base.CharacterId && !(IsBreath ? (extraBreath <= 0) : (extraStance <= 0)))
		{
			_costingEffectCount = (IsBreath ? extraBreath : extraStance);
			ReduceEffectCount(_costingEffectCount);
			InvalidateAffectDataCache(context);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCostBreathAndStance(DataContext context, int charId, bool isAlly, int costBreath, int costStance, short skillId)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			int breathPercent = CValuePercent.ParseInt(costBreath, 30000);
			int stancePercent = CValuePercent.ParseInt(costStance, 4000);
			_costingBreathOrStancePercent = (IsBreath ? stancePercent : breathPercent);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId)
		{
			int effectCount = _costingBreathOrStancePercent * power / 50;
			_costingBreathOrStancePercent = 0;
			if (skillId == base.SkillTemplateId && effectCount > 0)
			{
				AddEffectCount(effectCount);
			}
			if (_costingEffectCount > 0)
			{
				_costingEffectCount = 0;
				InvalidateAffectDataCache(context);
			}
		}
	}

	private void InvalidateAffectDataCache(DataContext context)
	{
		if (base.IsDirect)
		{
			InvalidateCache(context, 44);
			InvalidateCache(context, 45);
		}
		else
		{
			InvalidateAllEnemyCache(context, 46);
			InvalidateAllEnemyCache(context, 47);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 46) <= 1u)
		{
			return _costingEffectCount * ReduceDefendPercent;
		}
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == (IsBreath ? 173 : 174) && IsAttack(dataKey.CombatSkillId))
		{
			return base.EffectCount;
		}
		fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 44) <= 1u)
		{
			return _costingEffectCount * AddAttackPercent;
		}
		return 0;
	}
}
