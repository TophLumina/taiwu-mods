using GameData.Common;
using GameData.Domains.Combat;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Helper;

public class HeavenlyEmperorHelper
{
	private readonly IHeavenlyEmperorHandler _handler;

	private static SkillEffectKey AcceptDamageEffectKey => new SkillEffectKey(937, isDirect: true);

	private static SkillEffectKey MakeDamageEffectKey => new SkillEffectKey(939, isDirect: true);

	public int AcceptDamageEffectCount => GetEffectCount(AcceptDamageEffectKey);

	public int MakeDamageEffectCount => GetEffectCount(MakeDamageEffectKey);

	public HeavenlyEmperorHelper(IHeavenlyEmperorHandler handler)
	{
		_handler = handler;
	}

	public void ChangeAcceptDamageEffectCount(DataContext context, int delta)
	{
		ChangeEffectCount(context, AcceptDamageEffectKey, delta);
	}

	public void ChangeMakeDamageEffectCount(DataContext context, int delta)
	{
		ChangeEffectCount(context, MakeDamageEffectKey, delta);
	}

	private int GetEffectCount(SkillEffectKey effectKey)
	{
		CombatCharacter combatChar = _handler.CombatChar;
		SkillEffectCollection effects = combatChar.GetSkillEffectCollection();
		return effects.EffectDict?.GetOrDefault(effectKey) ?? 0;
	}

	private void ChangeEffectCount(DataContext context, SkillEffectKey effectKey, int delta)
	{
		CombatCharacter combatChar = _handler.CombatChar;
		if (DomainManager.Combat.IsSkillEffectExist(combatChar, effectKey))
		{
			DomainManager.Combat.ChangeSkillEffectCount(context, combatChar, effectKey, (short)delta);
		}
	}
}
