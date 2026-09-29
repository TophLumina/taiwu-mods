using System;
using GameData.Serializer;

namespace GameData.Domains.Combat;

[Flags]
[SerializeTo(typeof(byte))]
public enum ESkillDamageSectionResult : byte
{
	Uncheck = 0,
	Checked = 1,
	Hit = 2,
	Critical = 4
}
