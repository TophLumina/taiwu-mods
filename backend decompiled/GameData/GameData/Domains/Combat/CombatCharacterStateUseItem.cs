using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Combat;

public class CombatCharacterStateUseItem : CombatCharacterStateBase
{
	public enum EType
	{
		Invalid = -1,
		Poison,
		Rope,
		Custom
	}

	private ItemKey _itemKey;

	private bool _hit;

	private EType Type
	{
		get
		{
			if (_itemKey.ItemType == 8)
			{
				return EType.Poison;
			}
			if (_itemKey.ItemType != 12)
			{
				return EType.Invalid;
			}
			short templateId = _itemKey.TemplateId;
			if (1 == 0)
			{
			}
			EType result;
			switch (templateId)
			{
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 89:
			case 90:
				result = EType.Rope;
				break;
			case 275:
				result = EType.Rope;
				break;
			case 254:
			case 255:
			case 256:
			case 257:
			case 258:
			case 259:
			case 260:
			case 261:
			case 262:
			case 263:
				result = EType.Custom;
				break;
			default:
				result = EType.Invalid;
				break;
			}
			if (1 == 0)
			{
			}
			return result;
		}
	}

	private IItemConfig Template => _itemKey.GetConfig();

	private bool InRange => Template.MaxUseDistance < 0 || CurrentCombatDomain.GetCurrentDistance() <= Template.MaxUseDistance;

	private CombatCharacter EnemyChar => CurrentCombatDomain.GetCombatCharacter(!CombatChar.IsAlly);

	private CombatItemUseItem UseConfig
	{
		get
		{
			EType type = Type;
			if (1 == 0)
			{
			}
			CombatItemUseItem result = ((type != EType.Rope || !_hit) ? (CombatItemUse.Instance.GetItem(ItemTemplateHelper.GetItemCombatUseEffect(_itemKey.ItemType, _itemKey.TemplateId)) ?? CombatItemUse.DefValue.UseRopeFail) : CombatItemUse.Instance[EnemyChar.AnimalConfig?.CatchEffect ?? 5]);
			if (1 == 0)
			{
			}
			return result;
		}
	}

	public CombatCharacterStateUseItem(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.UseItem)
	{
		IsUpdateOnPause = true;
	}

	public override void OnEnter()
	{
		base.OnEnter();
		DataContext context = CombatChar.GetDataContext();
		_itemKey = CombatChar.UsingItem;
		short displayDistance = UseConfig.Distance;
		int distance = CurrentCombatDomain.GetCurrentDistance();
		_hit = CheckItemHit(context);
		int playEffectDelay = ((InRange && distance != displayDistance) ? 6 : 0);
		if (playEffectDelay > 0)
		{
			CurrentCombatDomain.SetDisplayPosition(context, CombatChar.IsAlly, CurrentCombatDomain.GetDisplayPosition(CombatChar.IsAlly, displayDistance));
		}
		DelayCall(PlayEffect, playEffectDelay);
		if (CheckItemRemove())
		{
			CombatChar.GetCharacter().RemoveInventoryItem(context, _itemKey, 1, deleteItem: true);
		}
	}

	public override void OnExit()
	{
		CombatChar.SetPreparingItem(ItemKey.Invalid, CombatChar.GetDataContext());
		CombatChar.UsingItem = ItemKey.Invalid;
	}

	private bool CheckItemHit(DataContext context)
	{
		if (!InRange)
		{
			return false;
		}
		if (Type != EType.Rope)
		{
			return true;
		}
		CombatConfigItem combatConfig = DomainManager.Combat.CombatConfig;
		if (combatConfig.CaptureRequireRope >= 0 && _itemKey.TemplateId != combatConfig.CaptureRequireRope)
		{
			return false;
		}
		return CurrentCombatDomain.CheckRopeHit(context.Random, Template.Grade);
	}

	private bool CheckItemRemove()
	{
		EType type = Type;
		if (1 == 0)
		{
		}
		bool result = type switch
		{
			EType.Poison => Template.ItemSubType != 802 || _hit, 
			EType.Rope => _itemKey.TemplateId != 275 && (!_hit || EnemyChar.AnimalConfig != null), 
			_ => false, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private void PlayEffect()
	{
		DataContext context = CombatChar.GetDataContext();
		if (_hit && Type != EType.Poison)
		{
			CombatChar.SetAnimationToLoop(null, context);
			EnemyChar.SetAnimationToLoop(null, context);
		}
		if (Type == EType.Rope)
		{
			CombatChar.SetParticleToLoop(null, context);
			CombatChar.SetSoundToLoop(null, context);
		}
		CombatItemUseItem useConfig = UseConfig;
		CombatChar.SetParticleToPlay(useConfig.Particle, context);
		CombatChar.SetSkillSoundToPlay(useConfig.Sound, context);
		CombatChar.SetAnimationToPlayOnce(useConfig.Animation, context);
		DelayCall(PlayHitAnim, AnimDataCollection.GetEventFrame(useConfig.Animation, "act0"));
		DelayCall(PlayCastAnim, AnimDataCollection.GetDurationFrame(useConfig.Animation));
	}

	private void PlayHitAnim()
	{
		DataContext context = CombatChar.GetDataContext();
		string enemyAni = null;
		if (_hit)
		{
			EType type = Type;
			if (1 == 0)
			{
			}
			string text = ((type != EType.Poison) ? UseConfig.BeHitAnimation : EnemyChar.GetBeHitAni(Template.Grade / 3));
			if (1 == 0)
			{
			}
			enemyAni = text;
			if (Type == EType.Poison)
			{
				MedicineItem itemConfig = (MedicineItem)Template;
				if (itemConfig.ItemSubType != 802)
				{
					CurrentCombatDomain.AddPoison(context, CombatChar, EnemyChar, itemConfig.PoisonType, (sbyte)(Template.Grade / 3 + 1), itemConfig.EffectValue * GlobalConfig.Instance.ThrowPoisonParam, -1);
					Events.RaiseThrowPoison(context, CombatChar.GetId(), _itemKey);
				}
				else
				{
					EnemyChar.AddWugIrresistibly(context, _itemKey);
					CurrentCombatDomain.ShowWugKingEffectTips(context, CombatChar.GetId(), EnemyChar.GetId());
				}
			}
			else if (Type == EType.Custom)
			{
				Events.RaiseUsedCustomItem(context, CombatChar.GetId(), _itemKey);
			}
			else
			{
				DomainManager.Combat.ClearShowUseSpecialMisc(context);
			}
		}
		else if (InRange)
		{
			enemyAni = EnemyChar.GetAvoidAni(2);
		}
		else
		{
			CombatChar.SetAttackOutOfRange(attackOutOfRange: true, context);
		}
		if (enemyAni != null)
		{
			EnemyChar.SetAnimationToPlayOnce(enemyAni, context);
		}
	}

	private void PlayCastAnim()
	{
		DataContext context = CombatChar.GetDataContext();
		CombatCharacter enemyChar = CurrentCombatDomain.GetCombatCharacter(!CombatChar.IsAlly, tryGetCoverCharacter: true);
		if (_itemKey.ItemType == 8)
		{
			CurrentCombatDomain.AddToCheckFallenSet(enemyChar.GetId());
		}
		if (Type == EType.Rope && _hit)
		{
			if (enemyChar.AnimalConfig == null)
			{
				DomainManager.Combat.AppendGetChar(enemyChar.GetId());
				DomainManager.TaiwuEvent.SetListenerEventActionIntArg("CombatOver", "CharIdSeizedInCombat", enemyChar.GetId());
				DomainManager.TaiwuEvent.SetListenerEventActionISerializableArg("CombatOver", "ItemKeySeizeCharacterInCombat", _itemKey);
				DomainManager.TaiwuEvent.SetListenerEventActionIntArg("CombatOver", "UseItemKeySeizeCharacterId", CombatChar.GetId());
			}
			else if (!DomainManager.Combat.CombatConfig.CaptureNoCarrier)
			{
				ItemKey carrierKey = DomainManager.Item.CreateItem(context, 4, enemyChar.AnimalConfig.CarrierId);
				CombatChar.GetCharacter().AddInventoryItem(context, carrierKey, 1);
				DomainManager.Combat.AppendGetItem(carrierKey);
				DomainManager.TaiwuEvent.SetListenerEventActionISerializableArg("CombatOver", "ItemKeySeizeCarrierInCombat", _itemKey);
			}
			else
			{
				DomainManager.TaiwuEvent.SetListenerEventActionISerializableArg("CombatOver", "ItemKeySeizeCarrierInCombat", _itemKey);
			}
			Events.RaiseUsedRope(context, CombatChar);
			CurrentCombatDomain.EndCombat(context, enemyChar, flee: false, playAni: false);
		}
		else
		{
			CombatChar.StateMachine.TranslateState(CombatCharacterStateType.Idle);
			CurrentCombatDomain.SetDisplayPosition(context, CombatChar.IsAlly, int.MinValue);
		}
	}
}
