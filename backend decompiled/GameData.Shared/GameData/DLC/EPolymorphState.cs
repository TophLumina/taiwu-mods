using System;
using GameData.Serializer;

namespace GameData.DLC;

[SerializeTo(typeof(byte))]
[Flags]
public enum EPolymorphState
{
	None = 0,
	Male = 1,
	Female = 2,
	Alive = 3,
	WaitForReturn = 4,
	Returned = 8,
	Dead = 0x10
}
