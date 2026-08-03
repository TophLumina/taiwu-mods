using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Agile;

public class LiCuanShu : AgileSkillBase
{
	private const sbyte AddPrepareUnit = 20;

	private const sbyte MaxAttackedCount = 4;

	private bool _affecting;

	private int _attackedCount;

	public LiCuanShu()
	{
	}

	public LiCuanShu(CombatSkillKey skillKey)
		: base(skillKey, 15600)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(152, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_MoveEnd(OnMoveEnd);
		_affecting = false;
		OnMoveSkillCanAffectChanged(context, default(DataUid));
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_MoveEnd(OnMoveEnd);
		DomainManager.Combat.DisableJumpMove(context, base.CombatChar, base.SkillTemplateId);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (defender == base.CombatChar && pursueIndex <= 0 && _attackedCount < 4)
		{
			_attackedCount++;
			ShowSpecialEffectTips(0);
		}
	}

	private void OnMoveEnd(DataContext context, CombatCharacter mover, int distance, bool isJump)
	{
		if (mover.GetId() == base.CharacterId && isJump && _attackedCount > 0)
		{
			_attackedCount = 0;
		}
	}

	protected override void OnMoveSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
		bool canAffect = base.CanAffect;
		if (_affecting != canAffect)
		{
			_affecting = canAffect;
			if (canAffect)
			{
				DomainManager.Combat.EnableJumpMove(base.CombatChar, base.SkillTemplateId, base.IsDirect);
			}
			else
			{
				DomainManager.Combat.DisableJumpMove(context, base.CombatChar, base.SkillTemplateId);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || _attackedCount <= 0)
		{
			return 0;
		}
		if (dataKey.FieldId == 152)
		{
			return base.CanAffect ? (20 * _attackedCount) : 0;
		}
		return 0;
	}
}
