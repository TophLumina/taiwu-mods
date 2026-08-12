using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.GoodSuper;

public class XiangMoJinShen : MysteryEffectBase
{
	private const int RequireBuddhismAttainment = 500;

	private const int BuddhismAttainmentPowerUnit = 20;

	private CombatSkillKey _addPowerKey = CombatSkillKey.Invalid;

	private int _addPower;

	private static CValuePercent AddProgress => 50;

	protected override short SpecialEffectId => 1768;

	public XiangMoJinShen()
	{
	}

	public XiangMoJinShen(int charId, int itemId)
		: base(charId, itemId, 50100)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(199, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastAgileOrDefenseWithoutPrepareBegin(OnCastAgileOrDefenseWithoutPrepareBegin);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastAgileOrDefenseWithoutPrepareBegin(OnCastAgileOrDefenseWithoutPrepareBegin);
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
		base.OnDisable(context);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && CombatSkillEquipType.IsDefense(skillId) && !base.CombatChar.GetAutoCastingSkill())
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * AddProgress);
			ShowSpecialEffect(1);
			SetPower(context, skillId);
		}
	}

	private void OnCastAgileOrDefenseWithoutPrepareBegin(DataContext context, int charId, short skillId)
	{
		if (charId == base.CharacterId && CombatSkillEquipType.IsDefense(skillId))
		{
			SetPower(context, skillId);
		}
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		ResetPower(context);
	}

	private void AutoReset(DataContext context, DataUid uid)
	{
		if (!DomainManager.Combat.IsCharInCombat(base.CharacterId) || (base.CombatChar.GetPreparingSkillId() != _addPowerKey.SkillTemplateId && base.CombatChar.StateMachine.GetCurrentStateType() != CombatCharacterStateType.CastSkill && base.CombatChar.GetAffectingDefendSkillId() != _addPowerKey.SkillTemplateId))
		{
			ResetPower(context);
		}
	}

	private void ResetPower(DataContext context)
	{
		_addPower = 0;
		_addPowerKey = CombatSkillKey.Invalid;
		InvalidateCache(context, 199);
		ClearMonitors();
	}

	private void SetPower(DataContext context, short skillId)
	{
		if (_addPowerKey.IsValid)
		{
			ResetPower(context);
		}
		short buddhismAttainment = CharObj.GetLifeSkillAttainment(13);
		if (buddhismAttainment >= 500)
		{
			int addPower = buddhismAttainment / 20;
			if (addPower != _addPower)
			{
				_addPower = addPower;
				_addPowerKey = new CombatSkillKey(base.CharacterId, skillId);
				InvalidateCache(context, 199);
				AutoMonitor(ParseCombatCharacterDataUid(56), AutoReset);
				AutoMonitor(ParseCombatCharacterDataUid(63), AutoReset);
				ShowSpecialEffect(0);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.SkillKey == _addPowerKey && dataKey.FieldId == 199)
		{
			return _addPower;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
