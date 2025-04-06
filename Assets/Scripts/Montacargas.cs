using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Montacargas : MonoBehaviour, IInteractable
{
    // Dictionary to store the pedidos (items and their required quantities)
    public Dictionary<string, int> pedidos = new Dictionary<string, int>();
    [SerializeField]
    private GameObject targetObject;    // Reference to the GameObject that holds the Character script

    [SerializeField]
    private GameObject popup; // Reference to the Popup UI panel
    private TMP_Text popupText; // Reference to the TMP Text component

    void Start()
    {
        // Initialize the pedidos dictionary with some example data
        pedidos.Add("P2C2", 3);
        pedidos.Add("P1C4", 4);
        pedidos.Add("P1C3", 1);

        // Get the TextMesh Pro Text component from the popup
        popupText = popup.GetComponentInChildren<TMP_Text>();
    }

    public void Interact()
    {
        // Access the Character script on the target GameObject
        Character characterScript = targetObject.GetComponent<Character>();
        // Retrieve current item and quantity from the character script
        string currentObject = characterScript.GetCurrentObject();
        int quantity = characterScript.GetCurrentQuantity();

        // Check if the first element in the pedidos dictionary matches the current character's object and quantity
        if (pedidos.Count > 0)
        {
            var firstPedido = pedidos.Keys.GetEnumerator();
            firstPedido.MoveNext();
            string firstKey = firstPedido.Current;
            int requiredQuantity = pedidos[firstKey];

            // Check if currentObject and quantity match the first element in the dictionary
            if (currentObject == firstKey && quantity == requiredQuantity)
            {

                characterScript.SetCurrentObject("");
                characterScript.SetCurrentQuantity(0);
                // Pop the first element from the pedidos dictionary
                pedidos.Remove(firstKey);
            }
            else if (currentObject == firstKey && quantity < requiredQuantity)
            {
                // Update the quantity value in the pedidos dictionary
                pedidos[firstKey] = requiredQuantity - quantity;  // Reduces the required quantity by the current quantity
                characterScript.SetCurrentQuantity(0);
                popupText.text = "You have selected correct product but not enough quantity.\n" + pedidos[firstKey] + " units of " + firstKey + " are still needed.";
                popup.SetActive(true); // Show the popup
            }
            else if (currentObject == firstKey && quantity > requiredQuantity)
            {
                characterScript.SetCurrentObject("");
                characterScript.SetCurrentQuantity(0);
                // Pop the first element from the pedidos dictionary
                pedidos.Remove(firstKey);
                popupText.text = "You have selected correct product but too many units.\nDiscarding " + (quantity - requiredQuantity) + " units of " + firstKey + ".";
                popup.SetActive(true); // Show the popup
            }
            else
            {
                popupText.text = "You have selected the wrong product or wrong quantity.\nPlease revise it.";
                popup.SetActive(true); // Show the popup
            }
        }
        else
        {
            Debug.LogWarning("No more pedidos left in the list.");
        }
    }

    public KeyValuePair<string, int> GetFirstPedido()
    {
        if (pedidos.Count > 0)
        {
            var enumerator = pedidos.GetEnumerator();
            enumerator.MoveNext(); // Move to the first element
            return enumerator.Current; // Returns the first key-value pair
        }
        return default(KeyValuePair<string, int>); // Return default if the dictionary is empty
    }


}
