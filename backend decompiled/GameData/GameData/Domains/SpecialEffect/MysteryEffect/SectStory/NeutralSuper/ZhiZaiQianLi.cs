using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Taiwu.Profession;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.NeutralSuper;

public class ZhiZaiQianLi : MysteryEffectBase
{
	private const int ReduceCooldownCount = 3;

	private readonly List<(ProfessionData data, int skillIndex)> _pool = new List<(ProfessionData, int)>();

	private readonly List<ProfessionData> _changedData = new List<ProfessionData>();

	protected override short SpecialEffectId => 1774;

	public ZhiZaiQianLi()
	{
	}

	public ZhiZaiQianLi(int charId, int itemId)
		: base(charId, itemId, 50106)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_AdvanceMonthFinish(OnAdvanceMonthFinish);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AdvanceMonthFinish(OnAdvanceMonthFinish);
		base.OnDisable(context);
	}

	private void OnAdvanceMonthFinish(DataContext context)
	{
		TaiwuProfessionSkillSlots professionSlots = DomainManager.Extra.GetTaiwuProfessionSkillSlots();
		if (!professionSlots.IsFull())
		{
			return;
		}
		int currDate = DomainManager.World.GetCurrDate();
		IntList[] slots = professionSlots.Slots;
		for (int i = 0; i < slots.Length; i++)
		{
			IntList slot = slots[i];
			foreach (int slotSkill in slot.Items)
			{
				ProfessionSkillItem config = ProfessionSkill.Instance[slotSkill];
				ProfessionData professionData = DomainManager.Extra.GetProfessionData(config.Profession);
				if (professionData != null)
				{
					int skillIndex = config.Level - 1;
					if (professionData.IsSkillCooldown(currDate, skillIndex))
					{
						_pool.Add((professionData, skillIndex));
					}
				}
			}
		}
		foreach (var (data, skillIndex2) in RandomUtils.GetRandomUnrepeated(context.Random, 3, _pool))
		{
			data.SkillOffCooldownDates[skillIndex2]--;
			if (!_changedData.Contains(data))
			{
				_changedData.Add(data);
			}
		}
		foreach (ProfessionData data2 in _changedData)
		{
			DomainManager.Extra.SetProfessionData(context, data2);
		}
		_pool.Clear();
		_changedData.Clear();
	}
}
