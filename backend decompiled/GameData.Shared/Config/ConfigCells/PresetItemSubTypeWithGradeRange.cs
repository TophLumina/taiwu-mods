using System;

namespace Config.ConfigCells;

[Serializable]
public struct PresetItemSubTypeWithGradeRange(short subType, sbyte gradeMin, sbyte gradeMax)
{
	public short SubType = subType;

	public sbyte GradeMin = gradeMin;

	public sbyte GradeMax = gradeMax;
}
