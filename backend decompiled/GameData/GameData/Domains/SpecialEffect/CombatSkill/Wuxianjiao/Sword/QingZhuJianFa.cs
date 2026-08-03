using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Sword;

public class QingZhuJianFa : CombatSkillEffectBase
{
	private const sbyte AffectSkillCount = 3;

	private int _affectEnemyId;

	private List<short> _affectSkillList;

	public QingZhuJianFa()
	{
	}

	public QingZhuJianFa(CombatSkillKey skillKey)
		: base(skillKey, 12306, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		if (_affectSkillList != null)
		{
			ObjectPool<List<short>>.Instance.Return(_affectSkillList);
		}
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!IsSrcSkillPerformed)
		{
			if (charId != base.CharacterId || skillId != base.SkillTemplateId)
			{
				return;
			}
			if (PowerMatchAffectRequire(power))
			{
				List<short> skillRandomPool = ObjectPool<List<short>>.Instance.Get();
				List<short> attackSkillList = base.CurrEnemyChar.GetAttackSkillList();
				_affectEnemyId = base.CurrEnemyChar.GetId();
				skillRandomPool.Clear();
				for (int i = 0; i < attackSkillList.Count; i++)
				{
					short enemySkillId = attackSkillList[i];
					if (enemySkillId >= 0)
					{
						CombatSkillKey skillKey = new CombatSkillKey(_affectEnemyId, enemySkillId);
						sbyte innerRatio = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey).GetCurrInnerRatio();
						if (base.IsDirect ? (innerRatio < 50) : (innerRatio > 50))
						{
							skillRandomPool.Add(enemySkillId);
						}
					}
				}
				if (skillRandomPool.Count > 0)
				{
					IsSrcSkillPerformed = true;
					_affectSkillList = ObjectPool<List<short>>.Instance.Get();
					_affectSkillList.Clear();
					if (skillRandomPool.Count <= 3)
					{
						_affectSkillList.AddRange(skillRandomPool);
					}
					else
					{
						for (int j = 0; j < 3; j++)
						{
							int index = context.Random.Next(0, skillRandomPool.Count);
							_affectSkillList.Add(skillRandomPool[index]);
							skillRandomPool.RemoveAt(index);
						}
					}
					AppendAffectedCurrEnemyData(context, 199, EDataModifyType.TotalPercent, -1);
					ShowSpecialEffectTips(0);
				}
				else
				{
					RemoveSelf(context);
				}
				ObjectPool<List<short>>.Instance.Return(skillRandomPool);
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (charId == _affectEnemyId && _affectSkillList.Contains(skillId) && !interrupted)
		{
			_affectSkillList.Remove(skillId);
			if (_affectSkillList.Count == 0)
			{
				RemoveSelf(context);
			}
			else
			{
				DomainManager.SpecialEffect.InvalidateCache(context, _affectEnemyId, 199);
			}
		}
		else if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 199 && dataKey.CharId == _affectEnemyId && _affectSkillList.Contains(dataKey.CombatSkillId))
		{
			return -50;
		}
		return 0;
	}
}
