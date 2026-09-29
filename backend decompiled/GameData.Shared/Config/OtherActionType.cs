using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class OtherActionType : ConfigData<OtherActionTypeItem, sbyte>
{
	public static OtherActionType Instance = new OtherActionType();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"TemplateId", "PrepareAnim", "PrepareParticle", "PrepareEndAnim", "PrepareEndParticle", "ForwardAnim", "ForwardParticle", "BackwardAnim", "BackwardParticle", "ForwardFastAnim",
		"ForwardFastParticle", "BackwardFastAnim", "BackwardFastParticle"
	};

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new OtherActionTypeItem(0, "CS_001_1", "Particle_CS_001_1", null, null, "MS_001_1", "Particle_MS_001_1", "MS_001_2", "Particle_MS_001_2", "MS_001_3", "Particle_MS_001_3", "MS_001_4", "Particle_MS_001_4"));
		_dataArray.Add(new OtherActionTypeItem(1, "CS_002_1", "Particle_CS_002_1", null, null, "MS_002_1", "Particle_MS_002_1", "MS_002_2", "Particle_MS_002_2", "MS_002_3", "Particle_MS_002_3", "MS_002_4", "Particle_MS_002_4"));
		_dataArray.Add(new OtherActionTypeItem(2, "CS_003_1", "Particle_CS_003_1", null, null, "MS_003_1", "Particle_MS_003_1", "MS_003_2", "Particle_MS_003_2", "MS_003_3", "Particle_MS_003_3", "MS_003_4", "Particle_MS_003_4"));
		_dataArray.Add(new OtherActionTypeItem(3, "CS_004_1", "Particle_CS_004_1", "CS_004_2", "Particle_CS_004_2", "MS_004_1", "Particle_MS_004_1", "MS_004_2", "Particle_MS_004_2", "MS_004_3", "Particle_MS_004_3", "MS_004_4", null));
		_dataArray.Add(new OtherActionTypeItem(4, null, null, null, null, null, null, null, null, null, null, null, null));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<OtherActionTypeItem>(5);
		CreateItems0();
	}
}
