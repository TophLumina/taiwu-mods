using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.Combat.Ai;

public class AiEnvironment
{
	public enum ENormalAttackType
	{
		None,
		Hit,
		Miss,
		OutOfRange
	}

	private readonly CombatCharacter _combatChar;

	public (int weaponIndex, ENormalAttackType type) LastNormalAttack = (weaponIndex: -1, type: ENormalAttackType.None);

	public short LastPrepareSkill = -1;

	public AiEnvironment(CombatCharacter combatChar)
	{
		_combatChar = combatChar;
	}

	public void RegisterCallbacks()
	{
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_NormalAttackOutOfRange(OnNormalAttackOutOfRange);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	public void UnregisterCallbacks()
	{
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_NormalAttackOutOfRange(OnNormalAttackOutOfRange);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightback)
	{
		if (attacker.GetId() == _combatChar.GetId())
		{
			if (pursueIndex == 0)
			{
				LastNormalAttack = (weaponIndex: attacker.GetUsingWeaponIndex(), type: hit ? ENormalAttackType.Hit : ENormalAttackType.Miss);
			}
			else if (LastNormalAttack.type == ENormalAttackType.Hit && !hit)
			{
				LastNormalAttack.type = ENormalAttackType.Miss;
			}
		}
	}

	private void OnNormalAttackOutOfRange(DataContext context, int charId, bool isAlly)
	{
		if (charId == _combatChar.GetId())
		{
			LastNormalAttack = (weaponIndex: _combatChar.GetUsingWeaponIndex(), type: ENormalAttackType.OutOfRange);
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == _combatChar.GetId())
		{
			LastPrepareSkill = skillId;
		}
	}
}
