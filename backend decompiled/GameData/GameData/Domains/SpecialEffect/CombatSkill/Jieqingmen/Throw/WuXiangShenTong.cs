using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Throw;

public class WuXiangShenTong : CombatSkillEffectBase
{
	private static readonly string[] SpiritWeaponAttackParticleName = new string[3] { "Particle_Effect_SpiritWeaponAttack1", "Particle_Effect_SpiritWeaponAttack2", "Particle_Effect_SpiritWeaponAttack3" };

	private static readonly string[] SpiritWeaponHitParticleName = new string[3] { "Particle_Effect_SpiritWeaponHit1", "Particle_Effect_SpiritWeaponHit2", "Particle_Effect_SpiritWeaponHit3" };

	private const string SpiritWeaponSoundName = "se_effect_spirit_attack";

	private const sbyte AddPowerPerTrick = 1;

	private const int InvokeInternalDelayFrame = 12;

	private readonly Queue<int> _autoAttackWeapons = new Queue<int>();

	private int _internalDelayFrame;

	public WuXiangShenTong()
	{
	}

	public WuXiangShenTong(CombatSkillKey skillKey)
		: base(skillKey, 13308, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_GetShaTrick(OnGetShaTrick);
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_GetShaTrick(OnGetShaTrick);
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		ItemKey[] weapons = base.CombatChar.GetWeapons();
		for (int i = 0; i < 3; i++)
		{
			if (weapons[i].IsValid() && Config.Weapon.Instance[weapons[i].TemplateId].ItemSubType == 2)
			{
				CombatWeaponData weaponData = base.CombatChar.GetWeaponData(i);
				if (weaponData.GetAutoAttackEffect().SkillId < 0)
				{
					weaponData.SetAutoAttackEffect(base.EffectKey, context);
					ShowSpecialEffectTipsOnceInFrame(1);
				}
			}
		}
	}

	private void OnGetShaTrick(DataContext context, int charId, bool isAlly, bool real)
	{
		if ((base.IsDirect ? (charId != base.CharacterId) : (base.CombatChar.IsAlly == isAlly)) || !base.IsCurrent)
		{
			return;
		}
		DomainManager.Combat.AddSkillPowerInCombat(context, SkillKey, base.EffectKey, 1);
		ShowSpecialEffectTips(0);
		ItemKey[] weapons = base.CombatChar.GetWeapons();
		for (int i = 0; i < 7; i++)
		{
			if (weapons[i].IsValid() && base.CombatChar.GetWeaponData(i).GetAutoAttackEffect().SkillId == base.SkillTemplateId)
			{
				_autoAttackWeapons.Enqueue(i);
			}
		}
	}

	private void OnCombatStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (!DomainManager.Combat.Pause && combatChar.GetId() == base.CharacterId)
		{
			if (_internalDelayFrame > 0)
			{
				_internalDelayFrame--;
			}
			else if (_autoAttackWeapons.Count > 0 && base.CombatChar.StateMachine.GetCurrentStateType() == CombatCharacterStateType.Idle)
			{
				InvokeAutoAttack(context);
			}
		}
	}

	private void InvokeAutoAttack(DataContext context)
	{
		bool anyInvoked = false;
		while (_autoAttackWeapons.Count > 0)
		{
			int weaponIndex = _autoAttackWeapons.Dequeue();
			ItemKey weaponKey = base.CombatChar.GetWeapons()[weaponIndex];
			if (DomainManager.Item.GetBaseItem(weaponKey).GetCurrDurability() <= 0)
			{
				continue;
			}
			anyInvoked = true;
			if (DomainManager.Combat.CalcSpiritAttack(base.CombatChar, weaponIndex))
			{
				ShowSpecialEffectTips(3);
			}
			_internalDelayFrame = 12;
			break;
		}
		if (anyInvoked)
		{
			int index = context.Random.Next(SpiritWeaponAttackParticleName.Length);
			base.CombatChar.SetSkillSoundToPlay("se_effect_spirit_attack", context);
			base.CombatChar.SetParticleToPlay(SpiritWeaponAttackParticleName[index], context);
			base.CurrEnemyChar.SetParticleToPlay(SpiritWeaponHitParticleName[index], context);
			ShowSpecialEffectTips(2);
		}
	}
}
