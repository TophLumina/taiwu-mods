using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.PestleEffect;

public class PestleEffectBase : SpecialEffectBase
{
	private readonly SkillEffectKey _effectKey;

	private ItemKey _weaponKey;

	private DataUid _weaponDurabilityUid;

	private CombatWeaponData _weaponData;

	protected bool IsDirect => _effectKey.IsDirect;

	protected bool CanAffect => DomainManager.Combat.GetUsingWeaponKey(base.CombatChar).Equals(_weaponKey);

	protected PestleEffectBase(int charId, SkillEffectKey effectKey)
		: base(charId, -1)
	{
		_effectKey = effectKey;
	}

	public override void OnEnable(DataContext context)
	{
		_weaponKey = DomainManager.Combat.GetUsingWeaponKey(base.CombatChar);
		_weaponDurabilityUid = new DataUid(8, 30, (ulong)_weaponKey, 3u);
		_weaponData = DomainManager.Combat.GetElement_WeaponDataDict(_weaponKey.Id);
		Events.RegisterHandler_RemovePestleEffect(OnRemovePestleEffect);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_weaponDurabilityUid, base.DataHandlerKey, OnDurabilityChanged);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_RemovePestleEffect(OnRemovePestleEffect);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_weaponDurabilityUid, base.DataHandlerKey);
	}

	private void OnRemovePestleEffect(DataContext context, SkillEffectKey effectKey)
	{
		if (_effectKey.Equals(effectKey))
		{
			RemoveSelf(context);
		}
	}

	private void OnDurabilityChanged(DataContext context, DataUid dataUid)
	{
		if (_weaponData.GetDurability() <= 0)
		{
			_weaponData.RemovePestleEffect(context);
		}
	}
}
