using System;
using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Whip;

public class LaoJunFuChenGong : CombatSkillEffectBase
{
	private const sbyte InitEffectCount = 6;

	private DataUid _defeatMarkUid;

	private readonly List<(sbyte, sbyte)> _markRandomPool = new List<(sbyte, sbyte)>();

	public LaoJunFuChenGong()
	{
	}

	public LaoJunFuChenGong(CombatSkillKey skillKey)
		: base(skillKey, 4303, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		DomainManager.Combat.AddSkillEffect(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), 6, base.MaxEffectCount, autoRemoveOnNoCount: false);
		_defeatMarkUid = new DataUid(8, 10, (ulong)base.CharacterId, 50u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey, OnDefeatMarkChanged);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defeatMarkUid, base.DataHandlerKey);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnDefeatMarkChanged(DataContext context, DataUid dataUid)
	{
		if (base.EffectCount <= 0 || !DomainManager.Combat.IsCharacterHalfFallen(base.CombatChar))
		{
			return;
		}
		if (base.IsDirect)
		{
			Injuries injuries = base.CombatChar.GetInjuries();
			Injuries newInjuries = injuries.Subtract(base.CombatChar.GetOldInjuries());
			List<sbyte> bodyPartRandomPool = ObjectPool<List<sbyte>>.Instance.Get();
			bodyPartRandomPool.Clear();
			for (sbyte part = 0; part < 7; part++)
			{
				(sbyte, sbyte) markCount = newInjuries.Get(part);
				for (int i = 0; i < markCount.Item1 + markCount.Item2; i++)
				{
					bodyPartRandomPool.Add(part);
				}
			}
			if (bodyPartRandomPool.Count > 0)
			{
				int removeCount = Math.Min(base.EffectCount, bodyPartRandomPool.Count);
				for (int j = 0; j < removeCount; j++)
				{
					sbyte part2 = bodyPartRandomPool[context.Random.Next(0, bodyPartRandomPool.Count)];
					bool isInner = newInjuries.Get(part2, isInnerInjury: true) > 0 && (newInjuries.Get(part2, isInnerInjury: false) <= 0 || context.Random.CheckPercentProb(50));
					injuries.Change(part2, isInner, -1);
					newInjuries.Change(part2, isInner, -1);
				}
				base.CombatChar.SetInjuries(context, injuries);
				DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), (short)(-removeCount));
				ShowSpecialEffectTips(0);
			}
			return;
		}
		DefeatMarkCollection markCollection = base.CombatChar.GetDefeatMarkCollection();
		_markRandomPool.Clear();
		for (sbyte part3 = 0; part3 < 7; part3++)
		{
			for (int k = 0; k < markCollection.FlawMarkList[part3].Count; k++)
			{
				_markRandomPool.Add((0, part3));
			}
			for (int l = 0; l < markCollection.AcupointMarkList[part3].Count; l++)
			{
				_markRandomPool.Add((1, part3));
			}
		}
		for (int m = 0; m < markCollection.MindMarkList.Count; m++)
		{
			_markRandomPool.Add((2, -1));
		}
		if (_markRandomPool.Count <= 0)
		{
			return;
		}
		int removeCount2 = Math.Min(base.EffectCount, _markRandomPool.Count);
		for (int n = 0; n < removeCount2; n++)
		{
			int index = context.Random.Next(0, _markRandomPool.Count);
			(sbyte, sbyte) mark = _markRandomPool[index];
			if (mark.Item1 == 0)
			{
				DomainManager.Combat.RemoveFlaw(context, base.CombatChar, mark.Item2, context.Random.Next(0, base.CombatChar.GetFlawCount()[mark.Item2]));
			}
			else if (mark.Item1 == 1)
			{
				DomainManager.Combat.RemoveAcupoint(context, base.CombatChar, mark.Item2, context.Random.Next(0, base.CombatChar.GetAcupointCount()[mark.Item2]));
			}
			else
			{
				base.CombatChar.RemoveMindMark(context, 1, random: true);
			}
			_markRandomPool.RemoveAt(index);
		}
		DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), (short)(-removeCount2));
		ShowSpecialEffectTips(0);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power) && base.EffectCount < base.MaxEffectCount)
		{
			DomainManager.Combat.ChangeSkillEffectCount(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), 1);
		}
	}
}
