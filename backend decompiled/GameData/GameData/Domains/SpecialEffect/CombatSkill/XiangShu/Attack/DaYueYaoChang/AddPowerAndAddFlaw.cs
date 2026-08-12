using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.DaYueYaoChang;

public class AddPowerAndAddFlaw : CombatSkillEffectBase
{
	protected short AddPower;

	protected sbyte FlawCount;

	private int _addPower;

	protected AddPowerAndAddFlaw()
	{
	}

	protected AddPowerAndAddFlaw(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		short preparingSkill = enemyChar.GetPreparingSkillId();
		_addPower = 0;
		if (preparingSkill >= 0)
		{
			CombatSkillKey skillKey = new CombatSkillKey(enemyChar.GetId(), preparingSkill);
			sbyte direction = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey).GetDirection();
			if (direction == 1)
			{
				_addPower += AddPower;
			}
		}
		if (preparingSkill < 0 || Config.CombatSkill.Instance[preparingSkill].EquipType != 1)
		{
			_addPower += AddPower;
		}
		if (_addPower > 0)
		{
			AppendAffectedData(context, 199, EDataModifyType.AddPercent, base.SkillTemplateId);
			ShowSpecialEffectTips(0);
		}
		if (!DomainManager.Combat.InAttackRange(base.CombatChar))
		{
			for (int i = 0; i < FlawCount; i++)
			{
				DomainManager.Combat.AddFlaw(context, enemyChar, 3, SkillKey, -1);
			}
			ShowSpecialEffectTips(1);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
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
}
