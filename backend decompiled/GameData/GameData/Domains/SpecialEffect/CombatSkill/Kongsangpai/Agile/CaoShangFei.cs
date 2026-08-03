using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Agile;

public class CaoShangFei : AgileSkillBase
{
	private const sbyte AddDistanceUnit = 5;

	private const sbyte MaxAddDistance = 10;

	private int _addDistance;

	private bool _affecting;

	public CaoShangFei()
	{
	}

	public CaoShangFei(CombatSkillKey skillKey)
		: base(skillKey, 10500)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_addDistance = 0;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 165, -1), EDataModifyType.Add);
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
		if (!(mover != base.CombatChar || !isMove || isForced) && (base.IsDirect ? (distance < 0) : (distance > 0)) && _addDistance < 10 && _affecting && !DomainManager.Combat.IsMovedByTeammate(base.CombatChar))
		{
			_addDistance += 5;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 165);
		}
	}

	protected override void OnMoveSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
		bool canAffect = base.CanAffect;
		if (_affecting != canAffect)
		{
			_affecting = canAffect;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 165);
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
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId || !_affecting)
		{
			return 0;
		}
		if (dataKey.FieldId == 165)
		{
			return _addDistance;
		}
		return 0;
	}
}
