using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Agile;

public class ChengWuChe : AgileSkillBase
{
	private const int JumpSpeedAddPercent = 80;

	private bool _affecting;

	private bool _addingJumpSpeed;

	public ChengWuChe()
	{
	}

	public ChengWuChe(CombatSkillKey skillKey)
		: base(skillKey, 13404)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(152, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
		_affecting = false;
		OnMoveSkillCanAffectChanged(context, default(DataUid));
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		DomainManager.Combat.DisableJumpMove(context, base.CombatChar, base.SkillTemplateId);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (!(mover != base.CombatChar || !isMove || isForced) && (base.IsDirect ? (distance < 0) : (distance > 0)) && _affecting && !DomainManager.Combat.IsMovedByTeammate(base.CombatChar))
		{
			if (_addingJumpSpeed)
			{
				_addingJumpSpeed = false;
				return;
			}
			_addingJumpSpeed = true;
			ShowSpecialEffectTips(0);
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
		if (dataKey.SkillKey != SkillKey || dataKey.FieldId != 152 || !base.CanAffect || !_addingJumpSpeed)
		{
			return 0;
		}
		return 80;
	}
}
