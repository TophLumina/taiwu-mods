using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class QiHanLingQi : BossNeigongBase
{
	private const int ReduceRecoveryOfBreathAndStancePercent = -75;

	private bool _inAttackRange;

	public QiHanLingQi()
	{
	}

	public QiHanLingQi(CombatSkillKey skillKey)
		: base(skillKey, 16102)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		base.OnDisable(context);
	}

	protected override void ActivePhase2Effect(DataContext context)
	{
		_inAttackRange = DomainManager.Combat.InAttackRange(base.CombatChar);
		AppendAffectedAllEnemyData(context, 8, EDataModifyType.TotalPercent, -1);
		AppendAffectedAllEnemyData(context, 7, EDataModifyType.TotalPercent, -1);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		bool inAttackRange = DomainManager.Combat.InAttackRange(base.CombatChar);
		if (inAttackRange != _inAttackRange)
		{
			_inAttackRange = inAttackRange;
			InvalidateAllEnemyCache(context, 8);
			InvalidateAllEnemyCache(context, 7);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		bool inAttackRange = _inAttackRange;
		bool flag = inAttackRange;
		if (flag)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag2 = (uint)(fieldId - 7) <= 1u;
			flag = flag2;
		}
		if (flag)
		{
			return -75;
		}
		return 0;
	}
}
