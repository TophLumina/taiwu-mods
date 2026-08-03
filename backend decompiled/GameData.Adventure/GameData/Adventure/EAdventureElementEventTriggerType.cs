using Google.Protobuf.Reflection;

namespace GameData.Adventure;

public enum EAdventureElementEventTriggerType
{
	[OriginalName("Undefined")]
	Undefined,
	[OriginalName("TaiwuArrivedElement")]
	TaiwuArrivedElement,
	[OriginalName("ElementArrivedTaiwu")]
	ElementArrivedTaiwu,
	[OriginalName("ManualInteract")]
	ManualInteract,
	[OriginalName("TimePasses")]
	TimePasses,
	[OriginalName("DynamicCreated")]
	DynamicCreated
}
