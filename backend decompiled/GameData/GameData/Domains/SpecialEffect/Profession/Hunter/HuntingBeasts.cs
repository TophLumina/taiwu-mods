using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Taiwu.Profession;

namespace GameData.Domains.SpecialEffect.Profession.Hunter;

public class HuntingBeasts : ProfessionEffectBase
{
	private static readonly List<ushort> AllFieldIds = new List<ushort>
	{
		32, 33, 34, 35, 38, 39, 40, 41, 44, 45,
		46, 47
	};

	private int _addPercent;

	protected override short CombatStateId => 243;

	public HuntingBeasts()
	{
	}

	public HuntingBeasts(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(1);
		_addPercent = professionData.GetSeniorityHunterAnimalBonus();
		foreach (ushort fieldId in AllFieldIds)
		{
			CreateAffectedData(fieldId, EDataModifyType.AddPercent, -1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !AllFieldIds.Contains(dataKey.FieldId))
		{
			return 0;
		}
		return _addPercent;
	}
}
