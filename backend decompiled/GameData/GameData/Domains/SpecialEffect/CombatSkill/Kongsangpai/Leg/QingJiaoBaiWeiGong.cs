using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Leg;

public class QingJiaoBaiWeiGong : CombatSkillEffectBase
{
	private const sbyte PrepareProgressPercent = 75;

	private const sbyte AddDamagePercentUnit = 30;

	private DataUid _defeatMarkUid;

	private bool _checking;

	private bool _delaying;

	private bool _affecting;

	private int _addDamagePercent;

	public QingJiaoBaiWeiGong()
	{
	}

	public QingJiaoBaiWeiGong(CombatSkillKey skillKey)
		: base(skillKey, 10304, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(69, EDataModifyType.AddPercent, -1);
		_affecting = false;
		_addDamagePercent = 0;
		AddMaxEffectCount(autoRemoveOnNoCount: false);
		_defeatMarkUid = ParseCombatCharacterDataUid(50);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey, OnDefeatMarkChanged);
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey);
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnDefeatMarkChanged(DataContext context, DataUid dataUid)
	{
		_delaying = true;
	}

	private void OnCombatStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (combatChar.GetId() != base.CharacterId)
		{
			return;
		}
		bool checking = _checking;
		_checking = false;
		if (combatChar.NeedUseSkillFreeId >= 0 || !_delaying || combatChar.StateMachine.GetCurrentStateType() != CombatCharacterStateType.Idle)
		{
			return;
		}
		_checking = true;
		if (checking)
		{
			_delaying = false;
			if (base.EffectCount > 0 && base.CombatChar.GetDefeatMarkCollection().GetTotalCount() > GlobalConfig.NeedDefeatMarkCount[DomainManager.Combat.GetCombatType()] / 2 && DomainManager.Combat.CanCastSkill(base.CombatChar, base.SkillTemplateId, costFree: true, checkRange: true))
			{
				_affecting = true;
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
				ShowSpecialEffectTips(0);
				ReduceEffectCount();
			}
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && _affecting)
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 75 / 100);
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker == base.CombatChar && skillId == base.SkillTemplateId && _affecting)
		{
			DefeatMarkCollection markCollection = base.CombatChar.GetDefeatMarkCollection();
			_addDamagePercent = 30 * (base.IsDirect ? markCollection.OuterInjuryMarkList : markCollection.InnerInjuryMarkList).Sum();
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && _affecting)
		{
			_affecting = false;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 69 && _affecting && dataKey.CombatSkillId == base.SkillTemplateId && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0))
		{
			ShowSpecialEffectTips(1);
			return _addDamagePercent;
		}
		return 0;
	}
}
