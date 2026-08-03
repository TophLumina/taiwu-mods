using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.DefenseAndAssist;

public class XueTongBuSiShen : AssistSkillBase
{
	private const short AddQiDisorderFrame = 60;

	private const short AddQiDisorder = 400;

	private const int DamageAddPercent = 80;

	private const int CostStanceBreathOnCastReducePercent = 50;

	private bool _affecting;

	private int _frameCounter;

	private DataUid _qiDisorderUid;

	private DataUid _defeatMarkUid;

	private bool DefeatMarkMax => base.CombatChar.GetDefeatMarkCollection().GetTotalCount() >= GlobalConfig.NeedDefeatMarkCount[DomainManager.Combat.GetCombatType()];

	public XueTongBuSiShen()
	{
	}

	public XueTongBuSiShen(CombatSkillKey skillKey)
		: base(skillKey, 15808)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(69, EDataModifyType.AddPercent, -1);
		CreateAffectedData(102, EDataModifyType.AddPercent, -1);
		CreateAffectedData(206, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(205, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(281, EDataModifyType.Custom, -1);
		_affecting = false;
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_AddDirectDamageValue(AddDirectDamageValue);
		Events.RegisterHandler_CostBreathAndStance(CostBreathAndStance);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_AddDirectDamageValue(AddDirectDamageValue);
		Events.UnRegisterHandler_CostBreathAndStance(CostBreathAndStance);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_qiDisorderUid, base.DataHandlerKey);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey);
		if (_affecting)
		{
			Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
		}
	}

	private void OnCombatBegin(DataContext context)
	{
		_qiDisorderUid = new DataUid(4, 0, (ulong)base.CharacterId, 21u);
		_defeatMarkUid = new DataUid(8, 10, (ulong)base.CharacterId, 50u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_qiDisorderUid, base.DataHandlerKey, UpdateDirectCanAffect);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey, OnDefeatMarkChanged);
		UpdateDirectCanAffect(context, default(DataUid));
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	private void AddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (!_affecting || !DefeatMarkMax)
		{
			return;
		}
		int charId = base.CombatChar.GetId();
		bool num;
		if (attackerId != charId)
		{
			if (defenderId != charId)
			{
				return;
			}
			num = base.IsDirect == isInner;
		}
		else
		{
			num = base.IsDirect != isInner;
		}
		if (num)
		{
			ShowEffectTips(context);
			ShowSpecialEffectTips(1);
		}
	}

	private void CostBreathAndStance(DataContext context, int charId, bool isAlly, int costBreath, int costStance, short skillId)
	{
		bool typeMatch = (base.IsDirect ? (costStance > 0) : (costBreath > 0));
		if (base.CombatChar.GetId() == charId && typeMatch && DefeatMarkMax)
		{
			ShowEffectTips(context);
			ShowSpecialEffectTips(2);
		}
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (base.CombatChar == combatChar && !DomainManager.Combat.Pause && DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar) && DefeatMarkMax)
		{
			_frameCounter++;
			if (_frameCounter >= 60)
			{
				_frameCounter = 0;
				DomainManager.Combat.ChangeDisorderOfQiRandomRecovery(context, base.CombatChar, 400, changeToOld: true);
				ShowEffectTips(context);
				ShowSpecialEffectTips(0);
			}
		}
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		if (base.IsDirect)
		{
			UpdateDirectCanAffect(context, default(DataUid));
		}
	}

	private void UpdateDirectCanAffect(DataContext context, DataUid dataUid)
	{
		bool canAffect = base.CanAffect && DisorderLevelOfQi.GetDisorderLevelOfQi(CharObj.GetDisorderOfQi()) < 4;
		if (_affecting != canAffect)
		{
			_affecting = canAffect;
			SetConstAffecting(context, canAffect);
			InvalidateAllCache(context);
			if (canAffect)
			{
				_frameCounter = 0;
				Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
			}
			else
			{
				Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
				DomainManager.Combat.AddToCheckFallenSet(base.CombatChar.GetId());
			}
		}
	}

	private void OnDefeatMarkChanged(DataContext context, DataUid dataUid)
	{
		InvalidateAllCache(context);
	}

	private void InvalidateAllCache(DataContext context)
	{
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 69);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 102);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 206);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 205);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !_affecting || !DefeatMarkMax)
		{
			return 0;
		}
		if (dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0) && dataKey.FieldId == 69)
		{
			return 80;
		}
		if (dataKey.CustomParam0 == (base.IsDirect ? 1 : 0) && dataKey.FieldId == 102)
		{
			return 80;
		}
		if (dataKey.FieldId == (base.IsDirect ? 206 : 205))
		{
			return -50;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 281)
		{
			return dataValue;
		}
		return dataValue || _affecting;
	}
}
