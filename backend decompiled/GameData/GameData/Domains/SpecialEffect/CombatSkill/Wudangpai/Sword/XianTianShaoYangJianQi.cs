using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Sword;

public class XianTianShaoYangJianQi : CombatSkillEffectBase
{
	private const sbyte PowerNoReduceAge = 40;

	private int _addPowerInThisCombat;

	private int _addPower;

	public XianTianShaoYangJianQi()
	{
	}

	public XianTianShaoYangJianQi(CombatSkillKey skillKey)
		: base(skillKey, 4207, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		int age = CharObj.GetActualAge();
		_addPowerInThisCombat = (base.IsDirect ? (80 - age) : (age / 2));
		_addPower = 0;
		if (_addPowerInThisCombat > 0)
		{
			CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
		}
		if (base.IsDirect ? (age <= 40) : (age >= 40))
		{
			CreateAffectedData(201, EDataModifyType.Custom, base.SkillTemplateId);
		}
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
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && _addPowerInThisCombat > 0)
		{
			_addPower = _addPowerInThisCombat;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && _addPowerInThisCombat > 0)
		{
			_addPower = 0;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _addPower;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey != SkillKey || dataKey.FieldId != 201)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		return false;
	}
}
