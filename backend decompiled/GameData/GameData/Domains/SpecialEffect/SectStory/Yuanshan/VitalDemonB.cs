using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.SectStory.Yuanshan;

public class VitalDemonB : VitalDemonEffectBase
{
	private const int AddAttackRange = 10000;

	private const int GetTrickCountAddPercent = 200;

	public VitalDemonB(int charId)
		: base(charId, 1749)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		foreach (CombatCharacter character in DomainManager.Combat.GetCharacters(base.CombatChar.IsAlly))
		{
			CreateAffectedData(character.GetId(), 145, EDataModifyType.Add, -1);
			CreateAffectedData(character.GetId(), 146, EDataModifyType.Add, -1);
			CreateAffectedData(character.GetId(), 326, EDataModifyType.AddPercent, -1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 326)
		{
			ShowSpecialEffect(0);
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result;
		switch (fieldId)
		{
		case 145:
		case 146:
			result = 10000;
			break;
		case 326:
			result = 200;
			break;
		default:
			result = base.GetModifyValue(dataKey, currModifyValue);
			break;
		}
		if (1 == 0)
		{
		}
		return result;
	}
}
