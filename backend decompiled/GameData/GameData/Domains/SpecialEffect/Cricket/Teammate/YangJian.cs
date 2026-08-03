using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.Cricket.Teammate;

public class YangJian : AutoCollectEffectBase
{
	private const int AddCriticalValue = 33;

	public YangJian(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CombatCharacter mainChar = DomainManager.Combat.GetMainCharacter(base.CombatChar.IsAlly);
		CreateAffectedData(mainChar.GetId(), 341, EDataModifyType.TotalPercent, -1);
		CreateAffectedData(mainChar.GetId(), 339, EDataModifyType.TotalPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		ushort fieldId = dataKey.FieldId;
		if ((fieldId == 339 || fieldId == 341) ? true : false)
		{
			return 33;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
