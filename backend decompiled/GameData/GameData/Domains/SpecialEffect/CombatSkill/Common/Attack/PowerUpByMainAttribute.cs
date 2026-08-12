using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class PowerUpByMainAttribute : PowerUpOnCast
{
	protected sbyte RequireMainAttributeType;

	private CValuePercent AddPowerFactor => base.IsDirect ? 40 : 60;

	protected override EDataModifyType ModifyType => EDataModifyType.AddPercent;

	public PowerUpByMainAttribute()
	{
	}

	public PowerUpByMainAttribute(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
	}

	public unsafe override void OnEnable(DataContext context)
	{
		MainAttributes currAttributes = CharObj.GetCurrMainAttributes();
		short currValue = currAttributes.Items[RequireMainAttributeType];
		if (base.IsDirect)
		{
			PowerUpValue = currValue;
		}
		else
		{
			MainAttributes maxAttributes = CharObj.GetMaxMainAttributes();
			PowerUpValue = maxAttributes.Items[RequireMainAttributeType] - currValue;
		}
		PowerUpValue *= AddPowerFactor;
		base.OnEnable(context);
	}
}
