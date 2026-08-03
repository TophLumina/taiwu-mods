using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

public class BuffTeammateCommand : AssistSkillBase
{
	private const int RequirePrepareValueReduce = 100;

	protected ETeammateCommandImplement[] AffectTeammateCommandType;

	protected sbyte CommandPowerUpPercent;

	protected BuffTeammateCommand()
	{
	}

	protected BuffTeammateCommand(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
		SetConstAffectingOnCombatBegin = DomainManager.Combat.IsMainCharacter(base.CombatChar);
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (DomainManager.Combat.IsMainCharacter(base.CombatChar))
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 183 : 184), -1), base.IsDirect ? EDataModifyType.AddPercent : EDataModifyType.Add);
		}
		else
		{
			Events.RegisterHandler_CombatBegin(OnCombatBegin);
		}
	}

	private void OnCombatBegin(DataContext context)
	{
		RemoveSelf(context);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		SetConstAffecting(context, base.CanAffect);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !AffectImplement((ETeammateCommandImplement)dataKey.CustomParam0) || !base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 183)
		{
			return 100;
		}
		if (dataKey.FieldId == 184)
		{
			return CommandPowerUpPercent;
		}
		return 0;
	}

	private bool AffectImplement(ETeammateCommandImplement implement)
	{
		ETeammateCommandImplement[] affectTeammateCommandType = AffectTeammateCommandType;
		foreach (ETeammateCommandImplement teammateCommandImplement in affectTeammateCommandType)
		{
			if (implement == teammateCommandImplement)
			{
				return true;
			}
		}
		return false;
	}
}
