using System.Linq;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class Bian : AnimalEffectBase
{
	private const int EffectDivisor = 10;

	public Bian()
	{
	}

	public Bian(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(64, EDataModifyType.AddPercent, -1);
		CreateAffectedData(65, EDataModifyType.AddPercent, -1);
		CreateAffectedData(100, EDataModifyType.AddPercent, -1);
		CreateAffectedData(101, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		bool flag = dataKey.CharId != base.CharacterId;
		bool flag2 = flag;
		if (!flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = (((uint)(fieldId - 64) <= 1u || (uint)(fieldId - 100) <= 1u) ? true : false);
			flag2 = !flag3;
		}
		if (flag2)
		{
			return 0;
		}
		int currDate = DomainManager.World.GetCurrDate();
		return (from record in base.CurrEnemyChar.GetCharacter().GetFameActionRecords()
			where record.EndDate > currDate
			where record.Value < 0
			select record.Value * record.Value).Sum() / 10;
	}
}
