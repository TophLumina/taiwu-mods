using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.FistAndPalm;

public class JiuSiLiHunShou : PoisonAddInjury
{
	private const string SecretInformationParticleName = "Particle_Effect_SecretInformation";

	private const string SecretInformationParticleNameReverse = "Particle_Effect_SecretInformationReverse";

	private const string SecretInformationSoundName = "se_effect_secret_information";

	private const int SecretInformationOccurredRate = 30;

	private static bool IsAffectChar(GameData.Domains.Character.Character character)
	{
		return character.GetCreatingType() == 1 && character.GetAgeGroup() == 2;
	}

	public JiuSiLiHunShou()
	{
	}

	public JiuSiLiHunShou(CombatSkillKey skillKey)
		: base(skillKey, 12107)
	{
		RequirePoisonType = 5;
	}

	protected override void OnCastMaxPower(DataContext context)
	{
		CombatCharacter knowChar = base.CombatChar;
		if (!IsAffectChar(knowChar.GetCharacter()))
		{
			return;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!knowChar.IsAlly);
		if (!IsAffectChar(enemyChar.GetCharacter()))
		{
			return;
		}
		byte unit = (base.IsDirect ? enemyChar : knowChar).GetDefeatMarkCollection().PoisonMarkList[RequirePoisonType];
		if (!context.Random.CheckPercentProb(unit * 30))
		{
			return;
		}
		int makeCharId = enemyChar.GetId();
		List<int> acceptCharIds = ObjectPool<List<int>>.Instance.Get();
		acceptCharIds.Clear();
		acceptCharIds.AddRange(from x in DomainManager.Combat.GetTeamCharacterIds()
			where x != enemyChar.GetId()
			where DomainManager.Character.TryGetElement_Objects(x, out var element) && IsAffectChar(element)
			select x);
		int acceptCharId = ((acceptCharIds.Count > 0) ? acceptCharIds.GetRandom(context.Random) : (-1));
		ObjectPool<List<int>>.Instance.Return(acceptCharIds);
		if (acceptCharId >= 0)
		{
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoType = context.Random.Next(4);
			if (1 == 0)
			{
			}
			int num = secretInfoType switch
			{
				0 => secretInformationCollection.AddKidnapInPrivate(makeCharId, acceptCharId), 
				1 => secretInformationCollection.AddPoisonEnemy(makeCharId, acceptCharId), 
				2 => secretInformationCollection.AddPlotHarmEnemy(makeCharId, acceptCharId), 
				3 => secretInformationCollection.AddRape(makeCharId, acceptCharId), 
				_ => -1, 
			};
			if (1 == 0)
			{
			}
			int secretInfoOffset = num;
			if (secretInfoOffset < 0)
			{
				PredefinedLog.Show(7, base.EffectId, $"secretInfoType={secretInfoType}");
			}
			else
			{
				SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(context, secretInfoOffset, withInitialDistribute: false);
				DomainManager.Information.ReceiveSecretInformation(context, secretInfoId, knowChar.GetId());
				ShowSpecialEffectTips(1);
				base.CombatChar.SetSkillSoundToPlay("se_effect_secret_information", context);
				enemyChar.SetParticleToPlay(enemyChar.IsAlly ? "Particle_Effect_SecretInformation" : "Particle_Effect_SecretInformationReverse", context);
			}
		}
	}
}
