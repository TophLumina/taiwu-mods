using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Polearm;

public class DaMoZhangFa : CombatSkillEffectBase
{
	private const sbyte AddPowerRatio = 20;

	private int _addPower;

	private short _addPowerSkillId;

	private DataUid _affectingDefendUid;

	public DaMoZhangFa()
	{
	}

	public DaMoZhangFa(CombatSkillKey skillKey)
		: base(skillKey, 1308, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_addPower = 0;
		_addPowerSkillId = -1;
		CreateAffectedData(199, EDataModifyType.AddPercent, -1);
		CreateAffectedData(154, EDataModifyType.Custom, -1);
		Events.RegisterHandler_CastAgileOrDefenseWithoutPrepareBegin(OnCastAgileOrDefenseWithoutPrepareBegin);
		Events.RegisterHandler_CastAgileOrDefenseWithoutPrepareEnd(OnCastAgileOrDefenseWithoutPrepareEnd);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		_affectingDefendUid = ParseCombatCharacterDataUid(63);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_affectingDefendUid, base.DataHandlerKey, UpdatePower);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAgileOrDefenseWithoutPrepareBegin(OnCastAgileOrDefenseWithoutPrepareBegin);
		Events.UnRegisterHandler_CastAgileOrDefenseWithoutPrepareEnd(OnCastAgileOrDefenseWithoutPrepareEnd);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_affectingDefendUid, base.DataHandlerKey);
	}

	private void OnCastAgileOrDefenseWithoutPrepareBegin(DataContext context, int charId, short skillId)
	{
		if (charId == base.CharacterId && base.CombatChar.GetPreparingSkillId() == base.SkillTemplateId && Config.CombatSkill.Instance[skillId].EquipType == 3)
		{
			_addPowerSkillId = (base.IsDirect ? skillId : base.SkillTemplateId);
			_addPower = (base.IsDirect ? base.SkillInstance : DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(base.CharacterId, skillId))).GetPower() * 20 / 100;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			ShowSpecialEffectTips(1);
		}
	}

	private void OnCastAgileOrDefenseWithoutPrepareEnd(DataContext context, int charId, short skillId)
	{
		if (charId == base.CharacterId && base.CombatChar.GetPreparingSkillId() == base.SkillTemplateId && Config.CombatSkill.Instance[skillId].EquipType == 3)
		{
			UpdateCanCastSkills(context);
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			UpdateCanCastSkills(context);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			UpdateCanCastSkills(context);
		}
		if (charId == base.CharacterId && _addPowerSkillId == base.SkillTemplateId)
		{
			_addPower = 0;
			_addPowerSkillId = -1;
			InvalidateCache(context, 199);
		}
	}

	private void UpdatePower(DataContext context, DataUid _)
	{
		if (_addPowerSkillId >= 0 && base.CombatChar.GetAffectingDefendSkillId() != _addPowerSkillId && base.SkillTemplateId != _addPowerSkillId)
		{
			_addPower = 0;
			_addPowerSkillId = -1;
			InvalidateCache(context, 199);
		}
	}

	private void UpdateCanCastSkills(DataContext context)
	{
		base.CombatChar.CanCastDuringPrepareSkills.Clear();
		if (base.CombatChar.GetPreparingSkillId() == base.SkillTemplateId && base.CombatChar.GetAffectingDefendSkillId() < 0)
		{
			base.CombatChar.CanCastDuringPrepareSkills.AddRange(base.CombatChar.GetDefenceSkillList());
			base.CombatChar.CanCastDuringPrepareSkills.RemoveAll((short id) => id < 0);
		}
		DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar);
		if (base.CombatChar.CanCastDuringPrepareSkills.Count > 0)
		{
			ShowSpecialEffectTips(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != _addPowerSkillId || dataKey.FieldId != 199)
		{
			return 0;
		}
		return _addPower;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || base.CombatChar.GetPreparingSkillId() != base.SkillTemplateId || Config.CombatSkill.Instance[dataKey.CombatSkillId].EquipType != 3)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 154)
		{
			return false;
		}
		return dataValue;
	}
}
