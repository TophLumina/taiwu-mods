using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

public abstract class WeaponUnlockEffectBase : CombatSkillEffectBase
{
	private DataUid _usingWeaponUid;

	protected abstract short WeaponType { get; }

	protected abstract CValuePercent DirectAddUnlockPercent { get; }

	protected abstract bool ReverseEffectDoubling { get; }

	protected short DirectWeaponId => base.SkillConfig.FixedBestWeaponID;

	protected bool UsingDirectWeapon => IsDirectWeapon(DomainManager.Combat.GetUsingWeaponKey(base.CombatChar));

	protected bool IsDirectOrReverseEffectDoubling => base.IsDirect || ReverseEffectDoubling;

	protected bool IsReverseOrUsingDirectWeapon => !base.IsDirect || UsingDirectWeapon;

	protected bool Affected { get; private set; }

	protected bool IsMatchWeaponType(ItemKey weaponKey)
	{
		return ItemTemplateHelper.GetItemSubType(weaponKey.ItemType, weaponKey.TemplateId) == WeaponType;
	}

	protected bool IsDirectWeapon(ItemKey weaponKey)
	{
		return weaponKey.TemplateId == DirectWeaponId;
	}

	protected WeaponUnlockEffectBase()
	{
	}

	protected WeaponUnlockEffectBase(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_UnlockAttack(OnUnlockAttack);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		_usingWeaponUid = ParseCombatCharacterDataUid(16);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_usingWeaponUid, base.DataHandlerKey, OnUsingWeaponChanged);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_UnlockAttack(OnUnlockAttack);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_usingWeaponUid, base.DataHandlerKey);
		base.OnDisable(context);
	}

	protected abstract void DoAffect(DataContext context, int weaponIndex);

	private void OnCombatBegin(DataContext context)
	{
		OnUsingWeaponChanged(context);
	}

	private void OnUnlockAttack(DataContext context, CombatCharacter combatChar, int weaponIndex)
	{
		if (combatChar.GetId() != base.CharacterId)
		{
			return;
		}
		ItemKey weapon = combatChar.GetWeapons()[weaponIndex];
		bool num;
		if (!base.IsDirect)
		{
			if (!IsMatchWeaponType(weapon))
			{
				return;
			}
			num = ReverseEffectDoubling;
		}
		else
		{
			num = IsDirectWeapon(weapon);
		}
		if (num)
		{
			DoAffect(context, weaponIndex);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && power > 0)
		{
			OnCastAddUnlockAttackValue(context, power);
		}
	}

	private void OnUsingWeaponChanged(DataContext context, DataUid arg2)
	{
		OnUsingWeaponChanged(context);
	}

	private void OnUsingWeaponChanged(DataContext context)
	{
		bool affected = IsReverseOrUsingDirectWeapon;
		if (affected != Affected)
		{
			Affected = affected;
			OnAffectedChanged(context);
		}
	}

	protected virtual void OnAffectedChanged(DataContext context)
	{
	}

	protected virtual void OnCastAddUnlockAttackValue(DataContext context, CValuePercent power)
	{
		if (!base.IsDirect || !UsingDirectWeapon)
		{
			return;
		}
		int addValue = GlobalConfig.Instance.UnlockAttackUnit * power * DirectAddUnlockPercent;
		for (int i = 0; i < 3; i++)
		{
			if (base.CombatChar.GetWeapons()[i].TemplateId == DirectWeaponId)
			{
				base.CombatChar.ChangeUnlockAttackValue(context, i, addValue);
			}
		}
		ShowSpecialEffectTipsOnceInFrame(0);
	}
}
