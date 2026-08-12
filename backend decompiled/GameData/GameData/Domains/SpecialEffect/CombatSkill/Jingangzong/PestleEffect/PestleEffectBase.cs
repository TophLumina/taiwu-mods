using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.PestleEffect;

public class PestleEffectBase : SpecialEffectBase
{
	private ItemKey _weaponKey;

	private DataUid _weaponDurabilityUid;

	private CombatWeaponData _weaponData;

	protected bool IsDirect => _weaponData.GetPestleEffect().IsDirect;

	protected bool CanAffect => DomainManager.Combat.GetUsingWeaponKey(base.CombatChar).Equals(_weaponKey);

	protected PestleEffectBase()
	{
	}

	protected PestleEffectBase(int charId, int type)
		: base(charId, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_weaponKey = DomainManager.Combat.GetUsingWeaponKey(base.CombatChar);
		_weaponDurabilityUid = new DataUid(8, 30, (ulong)_weaponKey, 3u);
		_weaponData = DomainManager.Combat.GetElement_WeaponDataDict(_weaponKey.Id);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_weaponDurabilityUid, base.DataHandlerKey, OnDurabilityChanged);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_weaponDurabilityUid, base.DataHandlerKey);
	}

	private void OnDurabilityChanged(DataContext context, DataUid dataUid)
	{
		if (_weaponData.GetDurability() <= 0)
		{
			_weaponData.RemovePestleEffect(context);
		}
	}
}
