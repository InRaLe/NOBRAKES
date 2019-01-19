using UnityEngine;
using UnityEngine.UI;

public class PunktestandZaehler : MonoBehaviour
{
    public Transform player;
    public Text punktestandText;

    // Update is called once per frame
    void Update()
    {
        punktestandText.text = player.position.z.ToString("0") + " Meter";
    }
}
