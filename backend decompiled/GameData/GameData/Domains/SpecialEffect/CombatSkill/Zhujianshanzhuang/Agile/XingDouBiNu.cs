using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Agile;

public class XingDouBiNu : AgileSkillBase
{
	private const sbyte WeaponExtraGrade = 2;

	private const sbyte AddWeaponAttackOrDefense = 50;

	private bool _affecting;

	public XingDouBiNu()
	{
	}

	public XingDouBiNu(CombatSkillKey skillKey)
		: base(skillKey, 9504)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData((ushort)(base.IsDirect ? 141 : 142), EDataModifyType.AddPercent, -1);
		_affecting = false;
		Events.RegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		if (attacker == base.CombatChar && pursueIndex <= 0 && base.CanAffect)
		{
			UpdateAffecting(base.CombatChar.NormalAttackBodyPart);
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (_affecting && attacker == base.CombatChar)
		{
			_affecting = false;
		}
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && base.CanAffect && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			UpdateAffecting(base.CombatChar.SkillAttackBodyPart);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (_affecting && charId == base.CharacterId)
		{
			_affecting = false;
		}
	}

	private void UpdateAffecting(sbyte attackBodyPart)
	{
		_affecting = CheckCanAffect(attackBodyPart);
		if (_affecting)
		{
			ShowSpecialEffectTips(0);
		}
	}

	private bool CheckCanAffect(sbyte attackBodyPart)
	{
		if (attackBodyPart < 0)
		{
			return false;
		}
		if (base.CurrEnemyChar.GetCharacter().GetConsummateLevel() <= CharObj.GetConsummateLevel())
		{
			return true;
		}
		sbyte weaponGrade = DomainManager.Combat.GetUsingWeapon(base.CombatChar).GetGrade();
		int armorGrade = -1;
		ItemKey armorKey = base.CurrEnemyChar.Armors[attackBodyPart];
		if (armorKey.IsValid())
		{
			GameData.Domains.Item.Armor armor = DomainManager.Item.GetElement_Armors(armorKey.Id);
			if (armor.GetCurrDurability() > 0)
			{
				armorGrade = armor.GetGrade();
			}
		}
		return weaponGrade + 2 > armorGrade;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !_affecting)
		{
			return 0;
		}
		return 50;
	}
}
