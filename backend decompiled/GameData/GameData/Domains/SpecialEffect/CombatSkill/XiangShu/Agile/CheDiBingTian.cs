using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Agile;

public class CheDiBingTian : AgileSkillBase
{
	private const int ReduceSpeedPercent = -75;

	private bool _inAttackRange;

	public CheDiBingTian()
	{
	}

	public CheDiBingTian(CombatSkillKey skillKey)
		: base(skillKey, 16202)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_inAttackRange = DomainManager.Combat.InAttackRange(base.CombatChar);
		CreateAffectedAllEnemyData(9, EDataModifyType.TotalPercent, -1);
		CreateAffectedAllEnemyData(14, EDataModifyType.TotalPercent, -1);
		CreateAffectedAllEnemyData(11, EDataModifyType.TotalPercent, -1);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		base.OnDisable(context);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		bool inAttackRange = DomainManager.Combat.InAttackRange(base.CombatChar);
		if (inAttackRange != _inAttackRange)
		{
			_inAttackRange = inAttackRange;
			InvalidateAllEnemyCache(context, 9);
			InvalidateAllEnemyCache(context, 14);
			InvalidateAllEnemyCache(context, 11);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		bool flag = base.CanAffect && _inAttackRange;
		bool flag2 = flag;
		if (flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = ((fieldId == 9 || fieldId == 11 || fieldId == 14) ? true : false);
			flag2 = flag3;
		}
		if (flag2)
		{
			return -75;
		}
		return 0;
	}
}
