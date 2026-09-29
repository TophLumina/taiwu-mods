using System;
using System.Collections.Generic;
using Config;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character.AvatarSystem.AvatarRes;

public class AvatarGroup
{
	public byte Id;

	public bool HasAsset;

	public bool AvatarAvailable;

	public List<BodyRes> BodyRes;

	public List<AvatarAsset> HeadRes;

	public List<EyeRes> EyesGroup;

	public List<AvatarAsset> EyesRes;

	private readonly Dictionary<string, AvatarAsset> _eyeballsRes;

	public List<AvatarAsset> EyeBrowRes;

	public List<AvatarAsset> NoseRes;

	public List<MouthRes> MouthRes;

	public List<HairRes> Hair1Res;

	public List<HairRes> Hair2Res;

	public List<AvatarAsset> Beard1Res;

	public List<AvatarAsset> Beard2Res;

	public List<AvatarAsset> Feature1Res;

	public List<AvatarAsset> Feature2Res;

	public List<AvatarAsset> Wrinkle1Res;

	public List<AvatarAsset> Wrinkle2Res;

	public List<AvatarAsset> Wrinkle3Res;

	public AvatarAsset WorstFeature2;

	public const short ObsoletedFeatureId = 6;

	private AvatarElementPositionItem PositionConfig => AvatarElementPosition.Instance[Id - 1];

	public AvatarGroup()
	{
		BodyRes = new List<BodyRes>();
		HeadRes = new List<AvatarAsset>();
		EyesRes = new List<AvatarAsset>();
		_eyeballsRes = new Dictionary<string, AvatarAsset>();
		EyeBrowRes = new List<AvatarAsset>();
		NoseRes = new List<AvatarAsset>();
		MouthRes = new List<MouthRes>();
		Beard1Res = new List<AvatarAsset>();
		Beard2Res = new List<AvatarAsset>();
		Hair1Res = new List<HairRes>();
		Hair2Res = new List<HairRes>();
		Feature1Res = new List<AvatarAsset>();
		Feature2Res = new List<AvatarAsset>();
		Wrinkle1Res = new List<AvatarAsset>();
		Wrinkle2Res = new List<AvatarAsset>();
		Wrinkle3Res = new List<AvatarAsset>();
	}

	private BodyRes EnsureBody(short bodyId)
	{
		BodyRes body = BodyRes.Find((BodyRes e) => e.Id == bodyId);
		if (body == null)
		{
			body = new BodyRes
			{
				Id = bodyId,
				ClothParts = new List<AvatarAsset>()
			};
			BodyRes.Add(body);
		}
		return body;
	}

	private MouthRes EnsureMouth(short mouthId)
	{
		MouthRes mouthCell = MouthRes.Find((MouthRes e) => e.Id == mouthId);
		if (mouthCell == null)
		{
			mouthCell = new MouthRes
			{
				Id = mouthId
			};
			MouthRes.Add(mouthCell);
		}
		return mouthCell;
	}

	private HairRes EnsureHair1(short hairId)
	{
		HairRes hairCell = Hair1Res.Find((HairRes e) => e.Id == hairId);
		if (hairCell == null)
		{
			hairCell = new HairRes
			{
				Id = hairId
			};
			Hair1Res.Add(hairCell);
		}
		return hairCell;
	}

	private HairRes EnsureHair2(short hairId)
	{
		HairRes hairCell = Hair2Res.Find((HairRes e) => e.Id == hairId);
		if (hairCell == null)
		{
			hairCell = new HairRes
			{
				Id = hairId
			};
			Hair2Res.Add(hairCell);
		}
		return hairCell;
	}

	public void Add(AvatarAsset asset)
	{
		if (asset == null)
		{
			return;
		}
		HasAsset = true;
		switch (asset.Type)
		{
		case EAvatarElementsType.Cloth:
			EnsureBody(asset.Id).Cloth = asset;
			break;
		case EAvatarElementsType.ClothColor:
			EnsureBody(asset.Id).Color = asset;
			break;
		case EAvatarElementsType.ClothSkin:
			EnsureBody(asset.Id).Skin = asset;
			break;
		case EAvatarElementsType.ClothPart:
		{
			List<AvatarAsset> partList = EnsureBody(asset.Id).ClothParts;
			AvatarAsset partAssetPre = partList.Find((AvatarAsset e) => e.Id == asset.Id);
			if (partAssetPre == null)
			{
				partList.Add(asset);
			}
			else
			{
				partList[partList.IndexOf(partAssetPre)] = asset;
			}
			break;
		}
		case EAvatarElementsType.Head:
		{
			AvatarAsset headAssetPre = HeadRes.Find((AvatarAsset e) => e.Id == asset.Id);
			if (headAssetPre == null)
			{
				HeadRes.Add(asset);
			}
			else
			{
				HeadRes[HeadRes.IndexOf(headAssetPre)] = asset;
			}
			break;
		}
		case EAvatarElementsType.Eye:
		{
			AvatarAsset eyeAssetPre = EyesRes.Find((AvatarAsset e) => e.Id == asset.Id && e.SubId == asset.SubId);
			if (eyeAssetPre == null)
			{
				EyesRes.Add(asset);
			}
			else
			{
				EyesRes[EyesRes.IndexOf(eyeAssetPre)] = asset;
			}
			break;
		}
		case EAvatarElementsType.EyeBall:
		{
			string eyeBallKey = $"{asset.Id}_{asset.SubId}";
			if (!_eyeballsRes.ContainsKey(eyeBallKey))
			{
				_eyeballsRes.Add(eyeBallKey, asset);
			}
			else
			{
				_eyeballsRes[eyeBallKey] = asset;
			}
			break;
		}
		case EAvatarElementsType.EyeBrow:
		{
			AvatarAsset eyebrowAssetPre = EyeBrowRes.Find((AvatarAsset e) => e.Id == asset.Id);
			if (eyebrowAssetPre == null)
			{
				EyeBrowRes.Add(asset);
			}
			else
			{
				EyeBrowRes[EyeBrowRes.IndexOf(eyebrowAssetPre)] = asset;
			}
			break;
		}
		case EAvatarElementsType.Nose:
		{
			AvatarAsset noseAssetPre = NoseRes.Find((AvatarAsset e) => e.Id == asset.Id);
			if (noseAssetPre == null)
			{
				NoseRes.Add(asset);
			}
			else
			{
				NoseRes[NoseRes.IndexOf(noseAssetPre)] = asset;
			}
			break;
		}
		case EAvatarElementsType.Mouth:
			EnsureMouth(asset.Id).Mouth = asset;
			break;
		case EAvatarElementsType.MouthPart:
			EnsureMouth(asset.Id).MouthPart = asset;
			break;
		case EAvatarElementsType.Beard1:
		{
			AvatarAsset beard1AssetPre = Beard1Res.Find((AvatarAsset e) => e.Id == asset.Id);
			if (beard1AssetPre == null)
			{
				Beard1Res.Add(asset);
			}
			else
			{
				Beard1Res[Beard1Res.IndexOf(beard1AssetPre)] = asset;
			}
			break;
		}
		case EAvatarElementsType.Beard2:
		{
			AvatarAsset beard2AssetPre = Beard2Res.Find((AvatarAsset e) => e.Id == asset.Id);
			if (beard2AssetPre == null)
			{
				Beard2Res.Add(asset);
			}
			else
			{
				Beard2Res[Beard2Res.IndexOf(beard2AssetPre)] = asset;
			}
			break;
		}
		case EAvatarElementsType.Hair1:
			EnsureHair1(asset.Id).Hair = asset;
			break;
		case EAvatarElementsType.Hair1Part:
			EnsureHair1(asset.Id).HairPart = asset;
			break;
		case EAvatarElementsType.Hair2:
			EnsureHair2(asset.Id).Hair = asset;
			break;
		case EAvatarElementsType.Hair2Part:
			EnsureHair2(asset.Id).HairPart = asset;
			break;
		case EAvatarElementsType.Feature1:
		{
			AvatarAsset feature1AssetPre = Feature1Res.Find((AvatarAsset e) => e.Id == asset.Id);
			if (feature1AssetPre == null)
			{
				Feature1Res.Add(asset);
			}
			else
			{
				Feature1Res[Feature1Res.IndexOf(feature1AssetPre)] = asset;
			}
			break;
		}
		case EAvatarElementsType.Feature2:
		{
			AvatarAsset feature2AssetPre = Feature2Res.Find((AvatarAsset e) => e.Id == asset.Id);
			if (feature2AssetPre == null)
			{
				Feature2Res.Add(asset);
			}
			else
			{
				Feature2Res[Feature2Res.IndexOf(feature2AssetPre)] = asset;
			}
			break;
		}
		case EAvatarElementsType.Wrinkle1:
		{
			AvatarAsset wrinkle1AssetPre = Wrinkle1Res.Find((AvatarAsset e) => e.Id == asset.Id);
			if (wrinkle1AssetPre == null)
			{
				Wrinkle1Res.Add(asset);
			}
			else
			{
				Wrinkle1Res[Wrinkle1Res.IndexOf(wrinkle1AssetPre)] = asset;
			}
			break;
		}
		case EAvatarElementsType.Wrinkle2:
		{
			AvatarAsset wrinkle2AssetPre = Wrinkle2Res.Find((AvatarAsset e) => e.Id == asset.Id);
			if (wrinkle2AssetPre == null)
			{
				Wrinkle2Res.Add(asset);
			}
			else
			{
				Wrinkle2Res[Wrinkle2Res.IndexOf(wrinkle2AssetPre)] = asset;
			}
			break;
		}
		case EAvatarElementsType.Wrinkle3:
		{
			AvatarAsset wrinkle3AssetPre = Wrinkle3Res.Find((AvatarAsset e) => e.Id == asset.Id);
			if (wrinkle3AssetPre == null)
			{
				Wrinkle3Res.Add(asset);
			}
			else
			{
				Wrinkle3Res[Wrinkle3Res.IndexOf(wrinkle3AssetPre)] = asset;
			}
			break;
		}
		}
	}

	public void ConstructEyesGroup()
	{
		EyesGroup = new List<EyeRes>();
		int i = 0;
		while (i < EyesRes.Count)
		{
			AvatarAsset asset = EyesRes[i];
			string eyeballKey = $"{asset.Id}_{asset.SubId}";
			_eyeballsRes.TryGetValue(eyeballKey, out var eyeball);
			EyeRes res = new EyeRes();
			res.Id = asset.Id;
			res.LeftEye = EyesRes[i];
			res.RightEye = EyesRes[i];
			res.LeftEyeball = eyeball;
			res.RightEyeball = eyeball;
			EyesGroup.Add(res);
			for (i++; i < EyesRes.Count && EyesRes[i].Id == asset.Id; i++)
			{
				AvatarAsset eyeGroupAsset = EyesRes[i];
				string groupEyeballKey = $"{eyeGroupAsset.Id}_{eyeGroupAsset.SubId}";
				_eyeballsRes.TryGetValue(groupEyeballKey, out var groupEyeball);
				EyeRes groupRes1 = new EyeRes();
				groupRes1.Id = asset.Id;
				groupRes1.LeftEye = asset;
				groupRes1.RightEye = eyeGroupAsset;
				groupRes1.LeftEyeball = eyeball;
				groupRes1.RightEyeball = groupEyeball;
				EyesGroup.Add(groupRes1);
				EyeRes groupRes2 = new EyeRes();
				groupRes2.Id = asset.Id;
				groupRes2.LeftEye = eyeGroupAsset;
				groupRes2.RightEye = asset;
				groupRes2.LeftEyeball = groupEyeball;
				groupRes2.RightEyeball = eyeball;
				EyesGroup.Add(groupRes2);
			}
		}
	}

	public void Sort()
	{
		BodyRes.Sort((BodyRes l, BodyRes r) => l.Id - r.Id);
		HeadRes.Sort((AvatarAsset l, AvatarAsset r) => l.Id - r.Id);
		EyesRes.Sort((AvatarAsset l, AvatarAsset r) => (l.Id == r.Id) ? (l.SubId - r.SubId) : (l.Id - r.Id));
		NoseRes.Sort((AvatarAsset l, AvatarAsset r) => l.Id - r.Id);
		MouthRes.Sort((MouthRes l, MouthRes r) => l.Id - r.Id);
		Hair1Res.Sort((HairRes l, HairRes r) => l.Id - r.Id);
		Hair2Res.Sort((HairRes l, HairRes r) => l.Id - r.Id);
		Beard1Res.Sort((AvatarAsset l, AvatarAsset r) => l.Id - r.Id);
		Beard2Res.Sort((AvatarAsset l, AvatarAsset r) => l.Id - r.Id);
		Feature1Res.Sort((AvatarAsset l, AvatarAsset r) => l.Id - r.Id);
		Feature2Res.Sort((AvatarAsset l, AvatarAsset r) => l.Id - r.Id);
		Wrinkle1Res.Sort((AvatarAsset l, AvatarAsset r) => l.Id - r.Id);
		Wrinkle2Res.Sort((AvatarAsset l, AvatarAsset r) => l.Id - r.Id);
		Wrinkle3Res.Sort((AvatarAsset l, AvatarAsset r) => l.Id - r.Id);
		WorstFeature2 = null;
		foreach (AvatarAsset feature in Feature2Res)
		{
			if (WorstFeature2 == null || WorstFeature2.Config.CharmExtraArg > feature.Config.CharmExtraArg)
			{
				WorstFeature2 = feature;
			}
		}
	}

	private float GetRandomFloat(IRandomSource random, float min, float max)
	{
		return min + (float)random.NextDouble() * (max - min);
	}

	private int GetRandomInt(IRandomSource random, int min, int max)
	{
		return random.Next(min, max);
	}

	public AvatarAsset Get(EAvatarElementsType elemType, params short[] ids)
	{
		AvatarAsset finalAsset = null;
		int id = ids[0];
		int subId = ((ids.Length == 2) ? ids[1] : 0);
		switch (elemType)
		{
		case EAvatarElementsType.Cloth:
			finalAsset = BodyRes.Find((BodyRes e) => e.Id == id)?.Cloth;
			break;
		case EAvatarElementsType.ClothColor:
			finalAsset = BodyRes.Find((BodyRes e) => e.Id == id)?.Color;
			break;
		case EAvatarElementsType.ClothSkin:
			finalAsset = BodyRes.Find((BodyRes e) => e.Id == id)?.Skin;
			break;
		case EAvatarElementsType.ClothPart:
		{
			BodyRes res = BodyRes.Find((BodyRes e) => e.Id == id);
			if (res != null && subId != 0)
			{
				finalAsset = res.ClothParts.Find(FuncFind);
			}
			break;
		}
		case EAvatarElementsType.Head:
			finalAsset = HeadRes.Find(FuncFind);
			break;
		case EAvatarElementsType.Eye:
			finalAsset = ((subId != 0) ? EyesRes.Find((AvatarAsset e) => e.Id == id && e.SubId == subId) : EyesRes.Find(FuncFind));
			break;
		case EAvatarElementsType.EyeBall:
		{
			_eyeballsRes.TryGetValue($"{id}_{subId}", out var eyeballAsset);
			finalAsset = eyeballAsset;
			break;
		}
		case EAvatarElementsType.EyeBrow:
			finalAsset = EyeBrowRes.Find(FuncFind);
			break;
		case EAvatarElementsType.Nose:
			finalAsset = NoseRes.Find(FuncFind);
			break;
		case EAvatarElementsType.Mouth:
			finalAsset = MouthRes.Find((MouthRes e) => e.Id == id)?.Mouth;
			break;
		case EAvatarElementsType.MouthPart:
			finalAsset = MouthRes.Find((MouthRes e) => e.Id == id)?.MouthPart;
			break;
		case EAvatarElementsType.Beard1:
			finalAsset = Beard1Res.Find(FuncFind);
			break;
		case EAvatarElementsType.Beard2:
			finalAsset = Beard2Res.Find(FuncFind);
			break;
		case EAvatarElementsType.Hair1:
			finalAsset = Hair1Res.Find((HairRes e) => e.Id == id)?.Hair;
			break;
		case EAvatarElementsType.Hair1Part:
			finalAsset = Hair1Res.Find((HairRes e) => e.Id == id)?.HairPart;
			break;
		case EAvatarElementsType.Hair2:
			finalAsset = Hair2Res.Find((HairRes e) => e.Id == id)?.Hair;
			break;
		case EAvatarElementsType.Hair2Part:
			finalAsset = Hair2Res.Find((HairRes e) => e.Id == id)?.HairPart;
			break;
		case EAvatarElementsType.Feature1:
			finalAsset = Feature1Res.Find(FuncFind);
			break;
		case EAvatarElementsType.Feature2:
			finalAsset = Feature2Res.Find(FuncFind);
			break;
		case EAvatarElementsType.Wrinkle1:
			finalAsset = Wrinkle1Res.Find(FuncFind);
			break;
		case EAvatarElementsType.Wrinkle2:
			finalAsset = Wrinkle2Res.Find(FuncFind);
			break;
		case EAvatarElementsType.Wrinkle3:
			finalAsset = Wrinkle3Res.Find(FuncFind);
			break;
		default:
			return null;
		}
		return finalAsset;
		bool FuncFind(AvatarAsset asset)
		{
			return asset.Id == id;
		}
	}

	public int GetTypeCount(EAvatarElementsType type)
	{
		int count = 0;
		switch (type)
		{
		case EAvatarElementsType.Cloth:
			count = BodyRes.Count;
			break;
		case EAvatarElementsType.Head:
			count = HeadRes.Count;
			break;
		case EAvatarElementsType.Eye:
			count = EyesGroup.Count;
			break;
		case EAvatarElementsType.EyeBrow:
			count = EyeBrowRes.Count;
			break;
		case EAvatarElementsType.Nose:
			count = NoseRes.Count;
			break;
		case EAvatarElementsType.Mouth:
			count = MouthRes.Count;
			break;
		case EAvatarElementsType.Beard1:
			count = Beard1Res.Count;
			break;
		case EAvatarElementsType.Beard2:
			count = Beard2Res.Count;
			break;
		case EAvatarElementsType.Hair1:
			count = Hair1Res.Count;
			break;
		case EAvatarElementsType.Hair2:
			count = Hair2Res.Count;
			break;
		case EAvatarElementsType.Feature1:
			count = Feature1Res.Count;
			break;
		case EAvatarElementsType.Feature2:
			count = Feature2Res.Count;
			break;
		case EAvatarElementsType.Wrinkle1:
			count = Wrinkle1Res.Count;
			break;
		case EAvatarElementsType.Wrinkle2:
			count = Wrinkle2Res.Count;
			break;
		case EAvatarElementsType.Wrinkle3:
			count = Wrinkle3Res.Count;
			break;
		}
		return count;
	}

	public int GetClothNPartCount(int clothId)
	{
		return BodyRes.Find((BodyRes e) => e.Id == clothId)?.ClothParts.Count ?? 0;
	}

	public (AvatarData avatar, short clothId) GetRandomAvatar(IRandomSource random, bool randColor = true, bool randCloth = false, bool canCreateOnly = false, bool canNaked = false)
	{
		AvatarData avatarData = new AvatarData();
		avatarData.AvatarId = Id;
		if (!AvatarManager.Instance.DisplayMode)
		{
			avatarData.ChildClothId = AvatarManager.Instance.GetRandomChildClothIdByAvatarId(random, Id);
		}
		short clothId = 0;
		AvatarElementPositionItem positionCfg = avatarData.PositionConfig;
		if (HasAsset)
		{
			if (randCloth)
			{
				clothId = GetRandomCloth(random, canCreateOnly, canNaked);
				avatarData.ClothPartId = GetRandomClothPart(random, clothId);
			}
			avatarData.HeadId = (byte)GetRandomHead(random);
			(short, short, short, short) eyes = GetRandomEyes(random);
			avatarData.EyesMainId = eyes.Item1;
			avatarData.EyesLeftId = eyes.Item2;
			avatarData.EyesRightId = eyes.Item3;
			avatarData.EyesHeight = AvatarData.GetRandomOffsetShortVal(random, positionCfg.EyeHeightRange);
			avatarData.EyesDistance = AvatarData.GetRandomOffsetShortVal(random, positionCfg.EyeDistanceRange);
			avatarData.EyesAngle = AvatarData.GetRandomOffsetShortVal(random, positionCfg.EyeAngleRange);
			avatarData.EyesScale = AvatarData.GetRandomOffsetShortVal(random, positionCfg.EyeScaleRange);
			avatarData.EyebrowId = eyes.Item4;
			avatarData.EyebrowHeight = AvatarData.GetRandomOffsetShortVal(random, positionCfg.EyebrowHeightRange);
			avatarData.EyebrowDistance = AvatarData.GetRandomOffsetShortVal(random, positionCfg.EyebrowDistanceRange);
			avatarData.EyebrowAngle = AvatarData.GetRandomOffsetShortVal(random, positionCfg.EyebrowAngleRange);
			avatarData.EyebrowScale = AvatarData.GetRandomOffsetShortVal(random, positionCfg.EyebrowScaleRange);
			avatarData.MouthId = GetRandomMouth(random);
			avatarData.MouthHeight = AvatarData.GetRandomOffsetShortVal(random, positionCfg.MouthHeightRange);
			avatarData.MouthScale = AvatarData.GetRandomOffsetShortVal(random, positionCfg.MouthScaleRange);
			avatarData.NoseId = GetRandomNose(random);
			avatarData.NoseHeight = AvatarData.GetRandomOffsetShortVal(random, positionCfg.NoseHeightRange);
			avatarData.NoseScale = AvatarData.GetRandomOffsetShortVal(random, positionCfg.NoseScaleRange);
			(avatarData.Beard1Id, avatarData.Beard2Id) = GetRandomBeards(random);
			(avatarData.FrontHairId, avatarData.BackHairId) = GetRandomHairs(random);
			(avatarData.Feature1Id, avatarData.Feature2Id, avatarData.Wrinkle1Id, avatarData.Wrinkle2Id, avatarData.Wrinkle3Id) = GetRandomMaskElems(random);
			if (avatarData.Gender == 1 && (avatarData.Beard1Id == 0 || avatarData.Beard2Id == 0))
			{
				throw new Exception($"AvatarGroup {avatarData.AvatarId} generate error:Get beard id error! beardId_1 = {avatarData.Beard1Id}  beardId_2 = {avatarData.Beard2Id}");
			}
			if (randColor)
			{
				AvatarManager manager = AvatarManager.Instance;
				Func<IRandomSource, IList<byte[]>, int, byte[]> generateRandomWeightCell = RandomUtils.GenerateRandomWeightCell;
				int weightIndex = manager.GetColorWeightIndex();
				byte[] skinColorItem = generateRandomWeightCell(random, manager.SkinColorsWeight, weightIndex);
				avatarData.ColorSkinId = skinColorItem[0];
				byte[] mouthColorItem = generateRandomWeightCell(random, manager.LipColorsWeight, weightIndex);
				avatarData.ColorMouthId = mouthColorItem[0];
				byte[] hairColorItem = generateRandomWeightCell(random, manager.HairColorsWeight, weightIndex);
				avatarData.ColorFrontHairId = hairColorItem[0];
				avatarData.ColorBackHairId = avatarData.ColorFrontHairId;
				avatarData.ColorBeard1Id = avatarData.ColorFrontHairId;
				avatarData.ColorBeard2Id = avatarData.ColorFrontHairId;
				avatarData.ColorEyebrowId = avatarData.ColorFrontHairId;
				if (random.CheckPercentProb(GlobalConfig.Instance.AvatarFurColorSplitObb))
				{
					int randomValue = random.Next(100);
					byte[] obbArray = GlobalConfig.Instance.AvatarFurColorSplitObbArray;
					if (randomValue < obbArray[0])
					{
						hairColorItem = generateRandomWeightCell(random, manager.HairColorsWeight, weightIndex);
						avatarData.ColorBeard1Id = hairColorItem[0];
						avatarData.ColorBeard2Id = hairColorItem[0];
					}
					else if (randomValue < obbArray[0] + obbArray[1])
					{
						byte[] eyebrowColorItem = generateRandomWeightCell(random, manager.HairColorsWeight, weightIndex);
						avatarData.ColorEyebrowId = eyebrowColorItem[0];
					}
					else if (randomValue < obbArray[0] + obbArray[1] + obbArray[2])
					{
						hairColorItem = generateRandomWeightCell(random, manager.HairColorsWeight, weightIndex);
						avatarData.ColorFrontHairId = hairColorItem[0];
						avatarData.ColorBackHairId = avatarData.ColorFrontHairId;
					}
					else
					{
						avatarData.ColorBackHairId = generateRandomWeightCell(random, manager.HairColorsWeight, weightIndex)[0];
						avatarData.ColorBeard1Id = generateRandomWeightCell(random, manager.HairColorsWeight, weightIndex)[0];
						avatarData.ColorBeard2Id = generateRandomWeightCell(random, manager.HairColorsWeight, weightIndex)[0];
						avatarData.ColorEyebrowId = generateRandomWeightCell(random, manager.HairColorsWeight, weightIndex)[0];
					}
				}
				byte[] featureColorItem = generateRandomWeightCell(random, manager.FeatureColorsWeight, weightIndex);
				avatarData.ColorFeature1Id = featureColorItem[0];
				byte[] eyeballColorItem = generateRandomWeightCell(random, manager.EyeballColorsWeight, weightIndex);
				avatarData.ColorEyeballId = eyeballColorItem[0];
				byte[] clothColorItem = generateRandomWeightCell(random, manager.ClothColorsWeight, weightIndex);
				avatarData.ColorClothId = clothColorItem[0];
			}
		}
		return (avatar: avatarData, clothId: clothId);
	}

	public short GetRandomHead(IRandomSource random)
	{
		List<AvatarAsset> availableHeadAssetList = new List<AvatarAsset>();
		int i = 0;
		for (int max = HeadRes.Count; i < max; i++)
		{
			AvatarAsset headRes = HeadRes[i];
			if (headRes.HeadConfig.CanRandom)
			{
				availableHeadAssetList.Add(headRes);
			}
		}
		return availableHeadAssetList.GetRandom(random)?.Id ?? 0;
	}

	public short GetRandomCloth(IRandomSource random, bool canCreateOnly, bool canNaked = false)
	{
		return BodyRes.FindAll(delegate(BodyRes e)
		{
			bool result = true;
			if (!canNaked && e.Cloth.Config.ElementId == 0)
			{
				result = false;
			}
			if (canCreateOnly && !e.Cloth.Config.CanCreate)
			{
				result = false;
			}
			if (e.Cloth.Config.ElementId >= 10000)
			{
				result = false;
			}
			return result;
		}).GetRandom(random)?.Id ?? 0;
	}

	public byte GetRandomClothPart(IRandomSource random, int clothId)
	{
		BodyRes bodyRes = BodyRes.Find((BodyRes e) => e.Id == clothId);
		if (bodyRes != null && bodyRes.ClothParts != null && bodyRes.ClothParts.Count > 0)
		{
			return (byte)bodyRes.ClothParts.GetRandom(random).SubId;
		}
		return 0;
	}

	public short GetRandomMouth(IRandomSource random)
	{
		return MouthRes.GetRandom(random)?.Id ?? 0;
	}

	public (short mainId, short leftId, short rightId, short eyebrowId) GetRandomEyes(IRandomSource random)
	{
		short mainId = 0;
		short leftId = 0;
		short rightId = 0;
		short eyebrowId = 0;
		EyeRes eyeRes = EyesGroup.GetRandom(random);
		if (eyeRes != null)
		{
			mainId = eyeRes.Id;
			leftId = eyeRes.LeftEye.SubId;
			rightId = eyeRes.RightEye.SubId;
		}
		eyebrowId = EyeBrowRes.GetRandom(random)?.Id ?? 0;
		return (mainId: mainId, leftId: leftId, rightId: rightId, eyebrowId: eyebrowId);
	}

	public short GetRandomNose(IRandomSource random)
	{
		return NoseRes.GetRandom(random)?.Id ?? 0;
	}

	public (short id1, short id2) GetRandomBeards(IRandomSource random)
	{
		short id1 = 1;
		short id2 = 1;
		if (random.CheckProb(GlobalConfig.Instance.AvatarNoneBeardObb, 10000))
		{
			return (id1: id1, id2: id2);
		}
		List<AvatarAsset> beard1Res = ((Beard1Res.Count > 0 || Id % 2 == 0) ? Beard1Res : GetBackupAvatarGroup().Beard1Res);
		id1 = (short)((beard1Res.Count <= 1) ? 1 : beard1Res[GetRandomInt(random, 1, beard1Res.Count)].Id);
		List<AvatarAsset> beard2Res = ((Beard2Res.Count > 0 || Id % 2 == 0) ? Beard2Res : GetBackupAvatarGroup().Beard2Res);
		id2 = (short)((beard2Res.Count <= 1) ? 1 : beard2Res[GetRandomInt(random, 1, beard2Res.Count)].Id);
		return (id1: id1, id2: id2);
	}

	public (short id1, short id2) GetRandomBeardsWithCondition(IRandomSource random, Predicate<AvatarAsset> condition)
	{
		short id1 = 1;
		short id2 = 1;
		if (random.CheckProb(GlobalConfig.Instance.AvatarNoneBeardObb, 10000))
		{
			return (id1: id1, id2: id2);
		}
		List<AvatarAsset> selectableBeardResList = new List<AvatarAsset>();
		List<AvatarAsset> beard1Res = ((Beard1Res.Count > 0 || Id % 2 == 0) ? Beard1Res : GetBackupAvatarGroup().Beard1Res);
		id1 = SelectBeardInList(beard1Res);
		List<AvatarAsset> beard2Res = ((Beard2Res.Count > 0 || Id % 2 == 0) ? Beard2Res : GetBackupAvatarGroup().Beard2Res);
		id2 = SelectBeardInList(beard2Res);
		return (id1: id1, id2: id2);
		short SelectBeardInList(List<AvatarAsset> resList)
		{
			selectableBeardResList.Clear();
			for (int i = 1; i < resList.Count; i++)
			{
				AvatarAsset res = resList[i];
				if (condition(res))
				{
					selectableBeardResList.Add(res);
				}
			}
			if (selectableBeardResList.Count == 0)
			{
				return 1;
			}
			return selectableBeardResList[GetRandomInt(random, 0, selectableBeardResList.Count)].Id;
		}
	}

	private AvatarGroup GetBackupAvatarGroup()
	{
		return AvatarManager.Instance.GetAvatarGroup(Id - 1);
	}

	public (short frontId, short backId) GetRandomHairs(IRandomSource random)
	{
		return GetRandomHairsWithCondition(random, null);
	}

	public (short frontId, short backId) GetRandomHairsNoSkinHead(IRandomSource random)
	{
		return GetRandomHairsWithCondition(random, (HairRes res) => res.Id != Hair1Res[0].Id && res.Id != Hair2Res[0].Id);
	}

	public (short frontId, short backId) GetHairsSkinHead(IRandomSource random)
	{
		return (frontId: Hair1Res[0].Id, backId: Hair2Res[0].Id);
	}

	public (short frontId, short backId) GetRandomHairsWithCondition(IRandomSource random, Predicate<HairRes> condition)
	{
		List<HairRes> selectableHairResList = new List<HairRes>();
		for (int i = 1; i < Hair1Res.Count; i++)
		{
			HairRes hairRes = Hair1Res[i];
			if (hairRes.Hair.Config.CanCreate && (condition == null || condition(hairRes)))
			{
				selectableHairResList.Add(hairRes);
			}
		}
		short frontHairId = (short)((selectableHairResList.Count <= 0) ? 1 : selectableHairResList[GetRandomInt(random, 0, selectableHairResList.Count)].Id);
		AvatarAsset hair1Asset = Get(EAvatarElementsType.Hair1, frontHairId);
		if (hair1Asset.Config.DisableRelativeType)
		{
			return (frontId: frontHairId, backId: 1);
		}
		selectableHairResList.Clear();
		foreach (HairRes hairRes2 in Hair2Res)
		{
			if (hairRes2.Hair.Config.CanCreate && !hair1Asset.Config.BanElements.Exist(hairRes2.Hair.Config.TemplateId) && (condition == null || condition(hairRes2)))
			{
				selectableHairResList.Add(hairRes2);
			}
		}
		short backHairId = (short)((selectableHairResList.Count <= 0) ? 1 : selectableHairResList[GetRandomInt(random, 0, selectableHairResList.Count)].Id);
		return (frontId: frontHairId, backId: backHairId);
	}

	public bool IsHairless(short frontId, short backId)
	{
		if (frontId == Hair1Res[0].Id)
		{
			return backId == Hair2Res[0].Id;
		}
		return false;
	}

	public bool IsBeardless(short beard1Id, short beard2Id)
	{
		if (beard1Id == Beard1Res[0].Id)
		{
			return beard2Id == Beard2Res[0].Id;
		}
		return false;
	}

	public (short feature1Id, short feature2Id, short wrinkle1Id, short wrinkle2Id, short wrinkle3Id) GetRandomMaskElems(IRandomSource random)
	{
		short feature1Id = 1;
		short feature2Id = 1;
		short wrinkle1Id = 0;
		short wrinkle2Id = 0;
		short wrinkle3Id = 0;
		if (!random.CheckProb(GlobalConfig.Instance.AvatarNoneFeatureObb, 10000))
		{
			if (random.CheckPercentProb(GlobalConfig.Instance.AvatarHasFeature1Obb) && Feature1Res.Count > 0)
			{
				List<AvatarAsset> feature1Res = GetFeatureResExcludeDelete(Feature1Res);
				feature1Id = feature1Res[GetRandomInt(random, 1, feature1Res.Count)].Id;
			}
			if (random.CheckPercentProb(GlobalConfig.Instance.AvatarHasFeature2Obb) && Feature2Res.Count > 0)
			{
				List<AvatarAsset> feature2Res = GetFeatureResExcludeDelete(Feature2Res);
				feature2Id = feature2Res[GetRandomInt(random, 1, feature2Res.Count)].Id;
			}
		}
		wrinkle1Id = Wrinkle1Res.GetRandom(random)?.Id ?? 0;
		wrinkle2Id = Wrinkle2Res.GetRandom(random)?.Id ?? 0;
		wrinkle3Id = Wrinkle3Res.GetRandom(random)?.Id ?? 0;
		return (feature1Id: feature1Id, feature2Id: feature2Id, wrinkle1Id: wrinkle1Id, wrinkle2Id: wrinkle2Id, wrinkle3Id: wrinkle3Id);
	}

	public static List<AvatarAsset> GetFeatureResExcludeDelete(List<AvatarAsset> featureRes)
	{
		List<AvatarAsset> feature1Res = new List<AvatarAsset>(featureRes);
		int index = feature1Res.FindIndex((AvatarAsset e) => e.Config.ElementId == 6);
		if (index >= 0)
		{
			feature1Res.RemoveAt(index);
		}
		return feature1Res;
	}

	public static short GetUsefulFeatureId(short featureId)
	{
		if (featureId == 6)
		{
			return 7;
		}
		return featureId;
	}
}
