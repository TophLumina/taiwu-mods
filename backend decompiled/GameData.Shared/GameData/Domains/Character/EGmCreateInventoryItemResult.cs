using GameData.Serializer;

namespace GameData.Domains.Character;

[SerializeTo(typeof(int))]
public enum EGmCreateInventoryItemResult
{
	Success,
	TameLoongDlcNotInstalled,
	LoongAlreadyCarrier,
	LoongAlreadyPolymorph,
	LoongCarrierCreateFailed
}
