using UnityEngine;
using TMPro; // Make sure to include this for TextMeshPro support

public class Interactable : MonoBehaviour, IInteractable
{
    public int pasillo;
    public int columna;

    [SerializeField]
    private GameObject popup; // Reference to the Popup UI panel

    private TextMeshProUGUI popupText; // Reference to the TextMeshProUGUI component

    public void Start()
    {
        popupText = popup.transform.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    public void Interact()
    {
        popupText.text = "Select quantity of P" + pasillo + "C" + columna;
        popup.SetActive(true); // Show the popup
        Debug.Log("Interacted with P" + pasillo + "C" + columna);
    }
}
