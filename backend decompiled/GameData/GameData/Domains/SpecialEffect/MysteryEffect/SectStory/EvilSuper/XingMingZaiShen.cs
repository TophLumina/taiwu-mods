using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.EvilSuper;

public class XingMingZaiShen : MysteryEffectBase
{
	private const int RequireAttainment = 500;

	private const int AddMakeSuccessRate = 50;

	private const int ReduceAcceptSuccessRate = -50;

	protected override short SpecialEffectId => 1780;

	public XingMingZaiShen()
	{
	}

	public XingMingZaiShen(int charId, int itemId)
		: base(charId, itemId, 50112)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(331, EDataModifyType.AddPercent, -1);
		CreateAffectedData(332, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || CharObj.GetLifeSkillAttainment(4) < 500)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result = fieldId switch
		{
			331 => 50, 
			332 => -50, 
			_ => base.GetModifyValue(dataKey, currModifyValue), 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
