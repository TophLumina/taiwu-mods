using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.DefenseAndAssist;

public class YiDaoYiJian : AssistSkillBase
{
	private const sbyte AddMaxPower = 40;

	private const int ChangeTrickValueCount = 3;

	private short _affectingSkillId;

	private static bool IsMatchAffect(sbyte skillType, short weaponType)
	{
		sbyte b = skillType;
		if (1 == 0)
		{
		}
		bool result;
		if (b != 7)
		{
			if (b != 8 || weaponType != 8)
			{
				goto IL_0028;
			}
			result = true;
		}
		else
		{
			if (weaponType != 9)
			{
				goto IL_0028;
			}
			result = true;
		}
		goto IL_002c;
		IL_002c:
		if (1 == 0)
		{
		}
		return result;
		IL_0028:
		result = false;
		goto IL_002c;
	}

	public YiDaoYiJian()
	{
	}

	public YiDaoYiJian(CombatSkillKey skillKey)
		: base(skillKey, 5601)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(200, EDataModifyType.Add, -1);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_ChangeWeapon(OnChangeWeapon);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_ChangeWeapon(OnChangeWeapon);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && base.CanAffect && base.IsDirect)
		{
			sbyte skillType = Config.CombatSkill.Instance[skillId].Type;
			short weaponType = DomainManager.Combat.GetUsingWeapon(base.CombatChar).GetItemSubType();
			if (IsMatchAffect(skillType, weaponType))
			{
				_affectingSkillId = skillId;
				InvalidateCache(context, 200);
				ShowSpecialEffectTips(0);
				ShowEffectTips(context);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == _affectingSkillId)
		{
			_affectingSkillId = -1;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 200);
		}
	}

	private void OnChangeWeapon(DataContext context, int charId, bool isAlly, CombatWeaponData newWeapon, CombatWeaponData oldWeapon)
	{
		if (charId == base.CharacterId && !base.IsDirect && newWeapon.Template.ItemSubType != oldWeapon.Template.ItemSubType)
		{
			int value = DomainManager.Character.CalcWeaponChangeTrickValue(base.CharacterId, newWeapon.Item.GetItemKey());
			value *= 3;
			DomainManager.Combat.ChangeChangeTrickProgress(context, base.CombatChar, value);
			ShowSpecialEffectTips(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != _affectingSkillId)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result = ((fieldId == 200) ? 40 : 0);
		if (1 == 0)
		{
		}
		return result;
	}
}
