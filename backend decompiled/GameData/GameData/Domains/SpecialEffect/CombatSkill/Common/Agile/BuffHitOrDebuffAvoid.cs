using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

public abstract class BuffHitOrDebuffAvoid : AgileSkillBase
{
	private const sbyte AddEffectPercent = 50;

	protected abstract sbyte AffectHitType { get; }

	protected BuffHitOrDebuffAvoid()
	{
	}

	protected BuffHitOrDebuffAvoid(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (base.IsDirect)
		{
			CreateAffectedData(36, EDataModifyType.Custom, -1);
			CreateAffectedData(37, EDataModifyType.Add, -1);
		}
		else
		{
			CreateAffectedAllEnemyData(36, EDataModifyType.Custom, -1);
			CreateAffectedAllEnemyData(37, EDataModifyType.Add, -1);
		}
		if (base.CanAffect)
		{
			ShowSpecialEffectTips(0);
		}
	}

	protected override void OnMoveSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
		if (base.IsDirect)
		{
			InvalidateCache(context, 36);
		}
		else
		{
			InvalidateAllEnemyCache(context, 36);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CustomParam0 != AffectHitType || dataKey.CustomParam1 != (base.IsDirect ? 1 : 0) || !base.CanAffect)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 36)
		{
			return false;
		}
		return dataValue;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CustomParam0 != AffectHitType || dataKey.CustomParam1 != ((!base.IsDirect) ? 1 : 0) || !base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 37)
		{
			return 50;
		}
		return 0;
	}
}
