using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiXiang;

public class AutoCastAgileAndDefense : CombatSkillEffectBase
{
	protected sbyte AddPower;

	private short _affectingAgileSkill;

	private short _affectingDefenseSkill;

	private DataUid _agileSkillUid;

	private DataUid _defenseSkillUid;

	protected AutoCastAgileAndDefense()
	{
	}

	protected AutoCastAgileAndDefense(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(199, EDataModifyType.AddPercent, -1);
		_affectingAgileSkill = (_affectingDefenseSkill = -1);
		_agileSkillUid = ParseCombatCharacterDataUid(62);
		_defenseSkillUid = ParseCombatCharacterDataUid(63);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_agileSkillUid, base.DataHandlerKey, OnAgileSkillChanged);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defenseSkillUid, base.DataHandlerKey, OnDefenseSkillChanged);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_agileSkillUid, base.DataHandlerKey);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defenseSkillUid, base.DataHandlerKey);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	private void CastAgileAndDefense(DataContext context)
	{
		_affectingAgileSkill = ParseCanCastOrInvalidSkillId(base.CombatChar.GetAgileSkillList()[0]);
		_affectingDefenseSkill = ParseCanCastOrInvalidSkillId(base.CombatChar.GetDefenceSkillList()[0]);
		if (_affectingAgileSkill >= 0 || _affectingDefenseSkill >= 0)
		{
			InvalidateCache(context, 199);
			ShowSpecialEffectTips(0);
		}
		if (_affectingAgileSkill > 0)
		{
			DomainManager.Combat.CastAgileOrDefenseWithoutPrepare(base.CombatChar, _affectingAgileSkill);
		}
		if (_affectingDefenseSkill > 0)
		{
			DomainManager.Combat.CastAgileOrDefenseWithoutPrepare(base.CombatChar, _affectingDefenseSkill);
		}
	}

	private short ParseCanCastOrInvalidSkillId(short skillId)
	{
		return (short)(DomainManager.Combat.CanCastSkill(base.CombatChar, skillId, costFree: true) ? skillId : (-1));
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			CastAgileAndDefense(context);
		}
	}

	private void OnAgileSkillChanged(DataContext context, DataUid dataUid)
	{
		if (_affectingAgileSkill >= 0 && _affectingAgileSkill != base.CombatChar.GetAffectingMoveSkillId())
		{
			_affectingAgileSkill = -1;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	private void OnDefenseSkillChanged(DataContext context, DataUid dataUid)
	{
		if (_affectingDefenseSkill >= 0 && _affectingDefenseSkill != base.CombatChar.GetAffectingDefendSkillId())
		{
			_affectingDefenseSkill = -1;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.CombatSkillId != _affectingAgileSkill && dataKey.CombatSkillId != _affectingDefenseSkill)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return AddPower;
		}
		return 0;
	}
}
