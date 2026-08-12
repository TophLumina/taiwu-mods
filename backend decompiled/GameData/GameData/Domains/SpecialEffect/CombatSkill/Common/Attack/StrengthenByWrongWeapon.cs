using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class StrengthenByWrongWeapon : CombatSkillEffectBase
{
	private const sbyte AddPowerUnit = 20;

	private const sbyte AddRangeUnit = 5;

	protected short RequireWeaponSubType;

	private int _directWeaponCount;

	private bool _disableSkills;

	protected StrengthenByWrongWeapon()
	{
	}

	protected StrengthenByWrongWeapon(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		if (base.IsDirect)
		{
			_directWeaponCount = 0;
			ItemKey[] weapons = base.CombatChar.GetWeapons();
			for (int i = 0; i < 3; i++)
			{
				ItemKey weaponKey = weapons[i];
				if (IsRequiredWeapon(weaponKey))
				{
					_directWeaponCount++;
				}
			}
			if (_directWeaponCount > 0)
			{
				CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
				CreateAffectedData(145, EDataModifyType.Add, base.SkillTemplateId);
				CreateAffectedData(146, EDataModifyType.Add, base.SkillTemplateId);
				ShowSpecialEffectTips(0);
			}
		}
		else
		{
			Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
			CreateAffectedAllEnemyData(286, EDataModifyType.Custom, -1);
			CreateAffectedAllEnemyData(284, EDataModifyType.Custom, -1);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		if (!base.IsDirect)
		{
			Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		}
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker.GetId() == base.CharacterId && skillId == base.SkillTemplateId && IsRequiredWeapon(DomainManager.Combat.GetUsingWeaponKey(base.CombatChar)))
		{
			_disableSkills = true;
			InvalidateCache(context, base.CurrEnemyChar.GetId(), 286);
			InvalidateCache(context, base.CurrEnemyChar.GetId(), 284);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			_disableSkills = false;
			RemoveSelf(context);
		}
	}

	private bool IsRequiredWeapon(ItemKey weaponKey)
	{
		bool result = weaponKey.IsValid() && ItemTemplateHelper.GetItemSubType(weaponKey.ItemType, weaponKey.TemplateId) != RequireWeaponSubType;
		if (base.IsDirect)
		{
			result = result && DomainManager.Combat.WeaponHasNeedTrick(base.CombatChar, base.SkillTemplateId, DomainManager.Combat.GetElement_WeaponDataDict(weaponKey.Id));
		}
		return result;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return 20 * _directWeaponCount;
		}
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 145) <= 1u)
		{
			return 5 * _directWeaponCount;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		ushort fieldId = dataKey.FieldId;
		if ((fieldId != 284 && fieldId != 286) || 1 == 0)
		{
			return dataValue;
		}
		return dataValue && !_disableSkills;
	}
}
