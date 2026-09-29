using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.Chicken;

public class ChickenClever : AutoCollectEffectBase
{
	private readonly int _totalPoint;

	private short _targetSkillId = -1;

	public ChickenClever(int charId, int totalPoint)
		: base(charId)
	{
		_totalPoint = totalPoint;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		List<short> pool = ObjectPool<List<short>>.Instance.Get();
		pool.Clear();
		foreach (short skillId in base.CombatChar.GetAttackSkillList())
		{
			if (skillId >= 0)
			{
				pool.Add(skillId);
			}
		}
		if (pool.Count > 0)
		{
			_targetSkillId = pool.GetRandom(context.Random);
			CreateAffectedData(199, EDataModifyType.Add, _targetSkillId);
		}
		ObjectPool<List<short>>.Instance.Return(pool);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte _, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == _targetSkillId && !interrupted)
		{
			_targetSkillId = -1;
		}
		if (_targetSkillId < 0)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.CombatSkillId == _targetSkillId && dataKey.FieldId == 199)
		{
			return _totalPoint;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
