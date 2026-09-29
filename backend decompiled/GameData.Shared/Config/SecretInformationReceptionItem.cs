using System;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationReceptionItem : ConfigItem<SecretInformationReceptionItem, short>
{
	public readonly short TemplateId;

	public readonly short NoRateRt;

	public readonly short RateRt;

	public readonly short RateItsFriRt;

	public readonly short RateItsEnmRt;

	public readonly short[] PersonalityTypeRt;

	public readonly short[] SourceTaiwu;

	public readonly short[] SourceOrg8;

	public readonly short[] SourceOrg7;

	public readonly short[] SourceOrg6;

	public readonly short[] SourceCity8;

	public readonly short[] SourceCity7;

	public readonly short[] SourceCity6;

	public readonly short[] SourceOrg5;

	public readonly short[] SourceOrg4;

	public readonly short[] SourceOrg3;

	public readonly short[] SourceCity5;

	public readonly short[] SourceCity4;

	public readonly short[] SourceCity3;

	public readonly short[] SourceOrgLow2;

	public readonly short[] SourceOrgLow1;

	public readonly short[] SourceOrgLow0;

	public readonly short[] SourceCityLow2;

	public readonly short[] SourceCityLow1;

	public readonly short[] SourceCityLow0;

	public readonly byte SourcePrincipal;

	public readonly short DisRateAct;

	public readonly short DisRateUna;

	public readonly short DisNoRate;

	public readonly short DisRateActFri;

	public readonly short DisRateActEn;

	public readonly short DisRateActAd;

	public readonly short DisRateActLo;

	public readonly short DisRateActLe;

	public readonly short DisRateUnaFri;

	public readonly short DisRateUnaEn;

	public readonly short DisRateUnaAd;

	public readonly short DisRateUnaLo;

	public readonly short DisRateUnaLe;

	public readonly short[] PersonalityTypeDisForRelationForInvolved;

	public readonly short[] BehaviorTypeDisForRelationForInvolved;

	public readonly short[] PersonalityTypeDisForRelationForUninvolved;

	public readonly short[] BehaviorTypeDisForRelationForUninvolved;

	public readonly short[] PersonalityTypeDisForRelationForEffective;

	public readonly short[] BehaviorTypeDisForRelationForEffective;

	public readonly short[] PersonalityTypeDisForNonRelation;

	public readonly short[] BehaviorTypeDisForNonRelation;

	public SecretInformationReceptionItem(short templateId, short noRateRt, short rateRt, short rateItsFriRt, short rateItsEnmRt, short[] personalityTypeRt, short[] sourceTaiwu, short[] sourceOrg8, short[] sourceOrg7, short[] sourceOrg6, short[] sourceCity8, short[] sourceCity7, short[] sourceCity6, short[] sourceOrg5, short[] sourceOrg4, short[] sourceOrg3, short[] sourceCity5, short[] sourceCity4, short[] sourceCity3, short[] sourceOrgLow2, short[] sourceOrgLow1, short[] sourceOrgLow0, short[] sourceCityLow2, short[] sourceCityLow1, short[] sourceCityLow0, byte sourcePrincipal, short disRateAct, short disRateUna, short disNoRate, short disRateActFri, short disRateActEn, short disRateActAd, short disRateActLo, short disRateActLe, short disRateUnaFri, short disRateUnaEn, short disRateUnaAd, short disRateUnaLo, short disRateUnaLe, short[] personalityTypeDisForRelationForInvolved, short[] behaviorTypeDisForRelationForInvolved, short[] personalityTypeDisForRelationForUninvolved, short[] behaviorTypeDisForRelationForUninvolved, short[] personalityTypeDisForRelationForEffective, short[] behaviorTypeDisForRelationForEffective, short[] personalityTypeDisForNonRelation, short[] behaviorTypeDisForNonRelation)
	{
		TemplateId = templateId;
		NoRateRt = noRateRt;
		RateRt = rateRt;
		RateItsFriRt = rateItsFriRt;
		RateItsEnmRt = rateItsEnmRt;
		PersonalityTypeRt = personalityTypeRt;
		SourceTaiwu = sourceTaiwu;
		SourceOrg8 = sourceOrg8;
		SourceOrg7 = sourceOrg7;
		SourceOrg6 = sourceOrg6;
		SourceCity8 = sourceCity8;
		SourceCity7 = sourceCity7;
		SourceCity6 = sourceCity6;
		SourceOrg5 = sourceOrg5;
		SourceOrg4 = sourceOrg4;
		SourceOrg3 = sourceOrg3;
		SourceCity5 = sourceCity5;
		SourceCity4 = sourceCity4;
		SourceCity3 = sourceCity3;
		SourceOrgLow2 = sourceOrgLow2;
		SourceOrgLow1 = sourceOrgLow1;
		SourceOrgLow0 = sourceOrgLow0;
		SourceCityLow2 = sourceCityLow2;
		SourceCityLow1 = sourceCityLow1;
		SourceCityLow0 = sourceCityLow0;
		SourcePrincipal = sourcePrincipal;
		DisRateAct = disRateAct;
		DisRateUna = disRateUna;
		DisNoRate = disNoRate;
		DisRateActFri = disRateActFri;
		DisRateActEn = disRateActEn;
		DisRateActAd = disRateActAd;
		DisRateActLo = disRateActLo;
		DisRateActLe = disRateActLe;
		DisRateUnaFri = disRateUnaFri;
		DisRateUnaEn = disRateUnaEn;
		DisRateUnaAd = disRateUnaAd;
		DisRateUnaLo = disRateUnaLo;
		DisRateUnaLe = disRateUnaLe;
		PersonalityTypeDisForRelationForInvolved = personalityTypeDisForRelationForInvolved;
		BehaviorTypeDisForRelationForInvolved = behaviorTypeDisForRelationForInvolved;
		PersonalityTypeDisForRelationForUninvolved = personalityTypeDisForRelationForUninvolved;
		BehaviorTypeDisForRelationForUninvolved = behaviorTypeDisForRelationForUninvolved;
		PersonalityTypeDisForRelationForEffective = personalityTypeDisForRelationForEffective;
		BehaviorTypeDisForRelationForEffective = behaviorTypeDisForRelationForEffective;
		PersonalityTypeDisForNonRelation = personalityTypeDisForNonRelation;
		BehaviorTypeDisForNonRelation = behaviorTypeDisForNonRelation;
	}

	public SecretInformationReceptionItem()
	{
		TemplateId = 0;
		NoRateRt = 0;
		RateRt = 0;
		RateItsFriRt = 0;
		RateItsEnmRt = 0;
		PersonalityTypeRt = null;
		SourceTaiwu = new short[5];
		SourceOrg8 = new short[5];
		SourceOrg7 = new short[5];
		SourceOrg6 = new short[5];
		SourceCity8 = new short[5];
		SourceCity7 = new short[5];
		SourceCity6 = new short[5];
		SourceOrg5 = new short[5];
		SourceOrg4 = new short[5];
		SourceOrg3 = new short[5];
		SourceCity5 = new short[5];
		SourceCity4 = new short[5];
		SourceCity3 = new short[5];
		SourceOrgLow2 = new short[5];
		SourceOrgLow1 = new short[5];
		SourceOrgLow0 = new short[5];
		SourceCityLow2 = new short[5];
		SourceCityLow1 = new short[5];
		SourceCityLow0 = new short[5];
		SourcePrincipal = 100;
		DisRateAct = 0;
		DisRateUna = 0;
		DisNoRate = 0;
		DisRateActFri = 0;
		DisRateActEn = 0;
		DisRateActAd = 0;
		DisRateActLo = 0;
		DisRateActLe = 0;
		DisRateUnaFri = 0;
		DisRateUnaEn = 0;
		DisRateUnaAd = 0;
		DisRateUnaLo = 0;
		DisRateUnaLe = 0;
		PersonalityTypeDisForRelationForInvolved = null;
		BehaviorTypeDisForRelationForInvolved = new short[5];
		PersonalityTypeDisForRelationForUninvolved = null;
		BehaviorTypeDisForRelationForUninvolved = new short[5];
		PersonalityTypeDisForRelationForEffective = new short[7];
		BehaviorTypeDisForRelationForEffective = new short[5];
		PersonalityTypeDisForNonRelation = new short[7];
		BehaviorTypeDisForNonRelation = new short[5];
	}

	public SecretInformationReceptionItem(short templateId, SecretInformationReceptionItem other)
	{
		TemplateId = templateId;
		NoRateRt = other.NoRateRt;
		RateRt = other.RateRt;
		RateItsFriRt = other.RateItsFriRt;
		RateItsEnmRt = other.RateItsEnmRt;
		PersonalityTypeRt = other.PersonalityTypeRt;
		SourceTaiwu = other.SourceTaiwu;
		SourceOrg8 = other.SourceOrg8;
		SourceOrg7 = other.SourceOrg7;
		SourceOrg6 = other.SourceOrg6;
		SourceCity8 = other.SourceCity8;
		SourceCity7 = other.SourceCity7;
		SourceCity6 = other.SourceCity6;
		SourceOrg5 = other.SourceOrg5;
		SourceOrg4 = other.SourceOrg4;
		SourceOrg3 = other.SourceOrg3;
		SourceCity5 = other.SourceCity5;
		SourceCity4 = other.SourceCity4;
		SourceCity3 = other.SourceCity3;
		SourceOrgLow2 = other.SourceOrgLow2;
		SourceOrgLow1 = other.SourceOrgLow1;
		SourceOrgLow0 = other.SourceOrgLow0;
		SourceCityLow2 = other.SourceCityLow2;
		SourceCityLow1 = other.SourceCityLow1;
		SourceCityLow0 = other.SourceCityLow0;
		SourcePrincipal = other.SourcePrincipal;
		DisRateAct = other.DisRateAct;
		DisRateUna = other.DisRateUna;
		DisNoRate = other.DisNoRate;
		DisRateActFri = other.DisRateActFri;
		DisRateActEn = other.DisRateActEn;
		DisRateActAd = other.DisRateActAd;
		DisRateActLo = other.DisRateActLo;
		DisRateActLe = other.DisRateActLe;
		DisRateUnaFri = other.DisRateUnaFri;
		DisRateUnaEn = other.DisRateUnaEn;
		DisRateUnaAd = other.DisRateUnaAd;
		DisRateUnaLo = other.DisRateUnaLo;
		DisRateUnaLe = other.DisRateUnaLe;
		PersonalityTypeDisForRelationForInvolved = other.PersonalityTypeDisForRelationForInvolved;
		BehaviorTypeDisForRelationForInvolved = other.BehaviorTypeDisForRelationForInvolved;
		PersonalityTypeDisForRelationForUninvolved = other.PersonalityTypeDisForRelationForUninvolved;
		BehaviorTypeDisForRelationForUninvolved = other.BehaviorTypeDisForRelationForUninvolved;
		PersonalityTypeDisForRelationForEffective = other.PersonalityTypeDisForRelationForEffective;
		BehaviorTypeDisForRelationForEffective = other.BehaviorTypeDisForRelationForEffective;
		PersonalityTypeDisForNonRelation = other.PersonalityTypeDisForNonRelation;
		BehaviorTypeDisForNonRelation = other.BehaviorTypeDisForNonRelation;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SecretInformationReceptionItem Duplicate(int templateId)
	{
		return new SecretInformationReceptionItem((short)templateId, this);
	}
}
