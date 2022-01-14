using UnityEngine;

[RequireComponent(typeof(Ship))]
public class ShipView : MonoBehaviour {
    public enum DamageTypes {
        NONE,
        MEDIUM,
        HIGH,
        DESTROYED,
    }

    [SerializeField] private DamageTypes damageType = DamageTypes.NONE;
    [SerializeField] private GameObject hullNoDmg;
    [SerializeField] private GameObject hullMedDmg;
    [SerializeField] private GameObject hullHighDmg;
    [SerializeField] private GameObject hullDestroyed;
    [SerializeField] private GameObject sailLargeNoDmg;
    [SerializeField] private GameObject sailLargeMedDmg;
    [SerializeField] private GameObject sailLargeHighDmg;
    [SerializeField] private GameObject sailSmallNoDmg;
    [SerializeField] private GameObject sailSmallMedDmg;
    [SerializeField] private GameObject sailSmallHighDmg;

    public DamageTypes DamageType {
        get => damageType;
        set {
            damageType = value;
            UpdateView();
        }
    }

    private void Start() {
        UpdateView();
    }

    public void UpdateView() {
        switch (DamageType) {
            case DamageTypes.NONE:
                if (hullNoDmg) hullNoDmg.SetActive(true);//
                if (hullMedDmg) hullMedDmg.SetActive(false);
                if (hullHighDmg) hullHighDmg.SetActive(false);
                if (hullDestroyed) hullDestroyed.SetActive(false);
                if (sailLargeNoDmg) sailLargeNoDmg.SetActive(true);//
                if (sailLargeMedDmg) sailLargeMedDmg.SetActive(false);
                if (sailLargeHighDmg) sailLargeHighDmg.SetActive(false);
                if (sailSmallNoDmg) sailSmallNoDmg.SetActive(true);//
                if (sailSmallMedDmg) sailSmallMedDmg.SetActive(false);
                if (sailSmallHighDmg) sailSmallHighDmg.SetActive(false);
                break;
            case DamageTypes.MEDIUM:
                if (hullNoDmg) hullNoDmg.SetActive(false);
                if (hullMedDmg) hullMedDmg.SetActive(true);//
                if (hullHighDmg) hullHighDmg.SetActive(false);
                if (hullDestroyed) hullDestroyed.SetActive(false);
                if (sailLargeNoDmg) sailLargeNoDmg.SetActive(false);
                if (sailLargeMedDmg) sailLargeMedDmg.SetActive(true);//
                if (sailLargeHighDmg) sailLargeHighDmg.SetActive(false);
                if (sailSmallNoDmg) sailSmallNoDmg.SetActive(false);
                if (sailSmallMedDmg) sailSmallMedDmg.SetActive(true);//
                if (sailSmallHighDmg) sailSmallHighDmg.SetActive(false);
                break;
            case DamageTypes.HIGH:
                if (hullNoDmg) hullNoDmg.SetActive(false);
                if (hullMedDmg) hullMedDmg.SetActive(false);
                if (hullHighDmg) hullHighDmg.SetActive(true);//
                if (hullDestroyed) hullDestroyed.SetActive(false);
                if (sailLargeNoDmg) sailLargeNoDmg.SetActive(false);
                if (sailLargeMedDmg) sailLargeMedDmg.SetActive(false);
                if (sailLargeHighDmg) sailLargeHighDmg.SetActive(true);//
                if (sailSmallNoDmg) sailSmallNoDmg.SetActive(false);
                if (sailSmallMedDmg) sailSmallMedDmg.SetActive(false);
                if (sailSmallHighDmg) sailSmallHighDmg.SetActive(true);//
                break;
            case DamageTypes.DESTROYED:
                if (hullNoDmg) hullNoDmg.SetActive(false);
                if (hullMedDmg) hullMedDmg.SetActive(false);
                if (hullHighDmg) hullHighDmg.SetActive(false);
                if (hullDestroyed) hullDestroyed.SetActive(true);//
                if (sailLargeNoDmg) sailLargeNoDmg.SetActive(false);
                if (sailLargeMedDmg) sailLargeMedDmg.SetActive(false);
                if (sailLargeHighDmg) sailLargeHighDmg.SetActive(true);//
                if (sailSmallNoDmg) sailSmallNoDmg.SetActive(false);
                if (sailSmallMedDmg) sailSmallMedDmg.SetActive(false);
                if (sailSmallHighDmg) sailSmallHighDmg.SetActive(true);//
                break;
            default: break;
        }
    }
}
