using System;
using Config;
using GameData.Common;
using GameData.Domains.Item;
using GameData.Domains.Taiwu.Profession;

namespace GameData.Domains.Combat;

public class CombatCharacterStateAnimalAttack : CombatCharacterStateBase
{
	private CombatCharacter _animalChar;

	private sbyte _trickType;

	private string _attackAni;

	private string _attackParticle;

	private string _attackSound;

	private short _animalEnterFrame;

	private short _attackDamageFrame;

	private short _animalLeaveFrame;

	private short _stateTotalFrame;

	public CombatCharacterStateAnimalAttack(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.AnimalAttack)
	{
		IsUpdateOnPause = true;
	}

	public override void OnEnter()
	{
		DataContext context = CombatChar.GetDataContext();
		_animalChar = CurrentCombatDomain.GetElement_CombatCharacterDict(CurrentCombatDomain.GetCarrierAnimalCombatCharId());
		ItemKey[] weapons = _animalChar.GetWeapons();
		int maxWeaponIndex = 0;
		for (int i = 1; i < 3 && weapons[i].IsValid(); i++)
		{
			maxWeaponIndex = i;
		}
		CurrentCombatDomain.ChangeWeapon(context, _animalChar, context.Random.Next(maxWeaponIndex));
		sbyte[] weaponTricks = _animalChar.GetWeaponTricks();
		_trickType = weaponTricks[context.Random.Next(weaponTricks.Length)];
		GameData.Domains.Item.Weapon weapon = _animalChar.GetWeaponData().Item;
		sbyte displayDist = _animalChar.AnimalConfig.AttackDistances[_animalChar.GetUsingWeaponIndex()];
		int displayPos = CurrentCombatDomain.GetDisplayPosition(CombatChar.IsAlly, displayDist);
		AttackEffect attackEffect = _animalChar.GetAttackEffect(weapon, _trickType);
		_attackAni = attackEffect.AniName;
		_attackParticle = attackEffect.Particle;
		_attackSound = attackEffect.Sound;
		_animalEnterFrame = 34;
		_attackDamageFrame = (short)((double)_animalEnterFrame + Math.Round(AnimDataCollection.Data[attackEffect.FullAniName].Events["act0"][0] * 60f));
		_animalLeaveFrame = (short)((double)_animalEnterFrame + Math.Round(AnimDataCollection.Data[attackEffect.FullAniName].Duration * 60f));
		_stateTotalFrame = (short)(_animalLeaveFrame + 24);
		CombatChar.NeedAnimalAttack = false;
		_animalChar.SetVisible(visible: true, context);
		_animalChar.SetDisplayPosition(displayPos, context);
		_animalChar.SetAnimationToLoop(_animalChar.GetIdleAni(), context);
		short carrierId = CombatChar.GetCharacter().GetEquipment()[13].TemplateId;
		sbyte carrierGrade = Config.Carrier.Instance[carrierId].Grade;
		ProfessionFormulaItem formula = ProfessionFormula.Instance[13];
		int addSeniority = formula.Calculate(carrierGrade);
		DomainManager.Extra.ChangeProfessionSeniority(context, 1, addSeniority);
	}

	public override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		if (_animalEnterFrame > 0)
		{
			_animalEnterFrame--;
			if (_animalEnterFrame == 0)
			{
				DataContext context = CombatChar.GetDataContext();
				_animalChar.SetAnimationToPlayOnce(_attackAni, context);
				_animalChar.SetParticleToPlay(_attackParticle, context);
				_animalChar.SetAttackSoundToPlay(_attackSound, context);
			}
		}
		if (_attackDamageFrame > 0)
		{
			_attackDamageFrame--;
			if (_attackDamageFrame == 0)
			{
				CombatContext context2 = CombatContext.Create(_animalChar, null, -1, -1);
				CombatCharacter enemyChar = CurrentCombatDomain.GetCombatCharacter(!CombatChar.IsAlly, tryGetCoverCharacter: true);
				_animalChar.NormalAttackHitType = CurrentCombatDomain.GetAttackHitType(_animalChar, _trickType);
				_animalChar.NormalAttackBodyPart = CurrentCombatDomain.GetAttackBodyPart(_animalChar, enemyChar, context2.Random, -1, _trickType, -1);
				CurrentCombatDomain.CalcNormalAttack(context2, _trickType);
			}
		}
		if (_animalLeaveFrame > 0)
		{
			_animalLeaveFrame--;
			if (_animalLeaveFrame == 0)
			{
				DataContext context3 = CombatChar.GetDataContext();
				_animalChar.SetDisplayPosition(int.MinValue, context3);
			}
		}
		if (_stateTotalFrame > 0)
		{
			_stateTotalFrame--;
			if (_stateTotalFrame == 0)
			{
				_animalChar.SetVisible(visible: false, CombatChar.GetDataContext());
				CombatChar.StateMachine.TranslateState();
			}
		}
		return false;
	}
}
