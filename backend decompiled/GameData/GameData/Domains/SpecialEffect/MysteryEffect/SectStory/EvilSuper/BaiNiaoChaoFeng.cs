using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.EvilSuper;

public class BaiNiaoChaoFeng : MysteryEffectBase
{
	private const int RequireAttainment = 500;

	private int _addMaxPower;

	protected override short SpecialEffectId => 1781;

	public BaiNiaoChaoFeng()
	{
	}

	public BaiNiaoChaoFeng(int charId, int itemId)
		: base(charId, itemId, 50113)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(200, EDataModifyType.Add, -1);
		AutoMonitor(ParseCharDataUid(58), Update);
		AutoMonitor(ParseCharDataUid(97), Update);
	}

	private void Update(DataContext context, DataUid dataUid)
	{
		int addMaxPower = CalcAddMaxPower();
		if (addMaxPower != _addMaxPower)
		{
			_addMaxPower = addMaxPower;
			InvalidateCache(context, 200);
		}
	}

	private int CalcAddMaxPower()
	{
		if (CharObj.GetLifeSkillAttainment(14) < 500 || CharObj.GetLifeSkillAttainment(5) < 500)
		{
			return 0;
		}
		int addMaxPower = 0;
		EatingItems eatingItems = CharObj.GetEatingItems();
		for (int i = 0; i < 9; i++)
		{
			ItemKey itemKey = eatingItems.Get(i);
			bool flag = itemKey.IsValid();
			bool flag2 = flag;
			if (flag2)
			{
				sbyte itemType = itemKey.ItemType;
				bool flag3 = ((itemType == 7 || itemType == 9) ? true : false);
				flag2 = flag3;
			}
			if (flag2)
			{
				addMaxPower += itemKey.GetConfig().Grade + 1;
			}
		}
		return addMaxPower;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 200)
		{
			return _addMaxPower;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
