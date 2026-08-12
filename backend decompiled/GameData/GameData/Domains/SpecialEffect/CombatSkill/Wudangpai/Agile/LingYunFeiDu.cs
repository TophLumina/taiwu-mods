using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Agile;

public class LingYunFeiDu : AgileSkillBase
{
	private const sbyte AddNeiliAllocation = 5;

	private const sbyte ExtraAddNeiliAllocation = 15;

	private bool _affecting;

	public LingYunFeiDu()
	{
	}

	public LingYunFeiDu(CombatSkillKey skillKey)
		: base(skillKey, 4406)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
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
			byte neiliAllocationType = (byte)context.Random.Next(0, 4);
			base.CombatChar.ChangeNeiliAllocation(context, neiliAllocationType, 5);
			ShowSpecialEffectTips(0);
			if (base.CombatChar.GetNeiliAllocation()[neiliAllocationType] < base.CombatChar.GetOriginNeiliAllocation()[neiliAllocationType])
			{
				base.CombatChar.ChangeNeiliAllocation(context, neiliAllocationType, 15);
			}
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
}
