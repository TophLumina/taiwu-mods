using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.DefenseAndAssist;

public class ShiXiaoGong : AssistSkillBase
{
	private DataUid _defeatMarkUid;

	private bool _affected;

	public ShiXiaoGong()
	{
	}

	public ShiXiaoGong(CombatSkillKey skillKey)
		: base(skillKey, 6604)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_defeatMarkUid = ParseCombatCharacterDataUid(50);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey, UpdateAffected);
		_affected = DomainManager.Combat.IsCharacterHalfFallen(base.CombatChar);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		DoReduceEffect(context);
	}

	private void UpdateAffected(DataContext context, DataUid dataUid)
	{
		bool affected = DomainManager.Combat.IsCharacterHalfFallen(base.CombatChar);
		if (affected != _affected)
		{
			_affected = affected;
			if (affected)
			{
				DoReduceEffect(context);
			}
		}
	}

	private void DoReduceEffect(DataContext context)
	{
		if (base.CanAffect && (base.IsCurrent || base.IsEntering))
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			if (base.IsDirect)
			{
				ChangeMobilityValue(context, enemyChar, -MoveSpecialConstants.MaxMobility);
				ClearAffectingAgileSkill(context, enemyChar);
			}
			else
			{
				ChangeBreathValue(context, enemyChar, -30000);
				ChangeStanceValue(context, enemyChar, -4000);
			}
			ShowEffectTips(context);
			ShowSpecialEffectTips(0);
		}
	}
}
