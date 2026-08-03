using System;
using System.Linq;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Carrier;

public class Fuxi : CombatStateEffectBase
{
	private const int AttainmentDivisor = 100;

	private static readonly sbyte[] HitOrAvoidLifeSkillTypes = new sbyte[4] { 0, 1, 2, 3 };

	private static readonly sbyte[] PenetrateOrResistLifeSkillTypes = new sbyte[4] { 7, 6, 10, 11 };

	protected override short CombatStateId => 206;

	public Fuxi(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		for (int i = 0; i < 4; i++)
		{
			CreateAffectedData((ushort)(32 + i), EDataModifyType.AddPercent, -1);
			CreateAffectedData((ushort)(38 + i), EDataModifyType.AddPercent, -1);
		}
		CreateAffectedData(44, EDataModifyType.AddPercent, -1);
		CreateAffectedData(45, EDataModifyType.AddPercent, -1);
		CreateAffectedData(46, EDataModifyType.AddPercent, -1);
		CreateAffectedData(47, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		GameData.Domains.Character.Character character = CharObj;
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		sbyte[] array;
		switch (fieldId)
		{
		case 32:
		case 33:
		case 34:
		case 35:
		case 38:
		case 39:
		case 40:
		case 41:
			array = HitOrAvoidLifeSkillTypes;
			break;
		case 44:
		case 45:
		case 46:
		case 47:
			array = PenetrateOrResistLifeSkillTypes;
			break;
		default:
			array = Array.Empty<sbyte>();
			break;
		}
		if (1 == 0)
		{
		}
		sbyte[] lifeSkillTypes = array;
		return lifeSkillTypes.Sum((sbyte x) => character.GetLifeSkillAttainment(x)) / 100;
	}
}
