using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Sword;

public class WuShangPuTiJian : CombatSkillEffectBase
{
	private CombatSkillKey _affectingSkill;

	private bool IsAffectChar(int charId)
	{
		return DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar) && (base.IsDirect ? (charId == base.CharacterId) : (DomainManager.Combat.GetElement_CombatCharacterDict(charId).IsAlly != base.CombatChar.IsAlly));
	}

	public WuShangPuTiJian()
	{
	}

	public WuShangPuTiJian(CombatSkillKey skillKey)
		: base(skillKey, 5206, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(85, EDataModifyType.Custom, base.SkillTemplateId);
		CreateAffectedData(291, EDataModifyType.Add, -1);
		CreateAffectedAllEnemyData(291, EDataModifyType.Add, -1);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (Config.CombatSkill.Instance[skillId].EquipType == 1 && IsAffectChar(charId) && base.EffectCount > 0)
		{
			_affectingSkill = new CombatSkillKey(charId, skillId);
			ReduceEffectCount();
			ShowSpecialEffectTips(0);
			InvalidateCache(context, charId, 291);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (_affectingSkill.IsMatch(charId, skillId))
		{
			_affectingSkill = CombatSkillKey.Invalid;
			InvalidateCache(context, charId, 291);
		}
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power))
		{
			AddMaxEffectCount();
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.SkillKey != _affectingSkill || dataKey.FieldId != 291)
		{
			return 0;
		}
		return base.IsDirect ? 1 : (-1);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey != SkillKey || dataKey.FieldId != 85)
		{
			return dataValue;
		}
		return false;
	}
}
