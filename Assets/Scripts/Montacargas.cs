using UnityEngine;
using System.Collections.Generic;

public class Montacargas : MonoBehaviour, IInteractable
{
    // Dictionary to store the pedidos (items and their required quantities)
    public Dictionary<string, int> pedidos = new Dictionary<string, int>();
    [SerializeField]
    private GameObject targetObject;    // Reference to the GameObject that holds the Character script

    void Start()
    {
        // Initialize the pedidos dictionary with some example data
        pedidos.Add("P2C2", 3);
        pedidos.Add("P1C4", 4);
        pedidos.Add("P1C3", 1);
    }

    public void Interact()
    {
        // Check if the targetObject is assigned
        if (targetObject != null)
        {
            // Access the Character script on the target GameObject
            Character characterScript = targetObject.GetComponent<Character>();

            if (characterScript != null)
            {
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
                    if (currentObject == firstKey && quantity >= requiredQuantity)
                    {

                        characterScript.SetCurrentObject("");
                        characterScript.SetCurrentQuantity(0);
                        // Pop the first element from the pedidos dictionary
                        pedidos.Remove(firstKey);

                        // Debug message for successful interaction
                        Debug.Log("Pedido completed! Removed " + firstKey + " from pedidos.");
                    }
                    else
                    {
                        // Print a debug message if the condition isn't met
                        Debug.Log("Condition not met. Player's current object: " + currentObject + ", Quantity: " + quantity +
                                  ". Required: " + firstKey + ", Quantity: " + requiredQuantity);
                    }
                }
                else
                {
                    Debug.LogWarning("No more pedidos left in the list.");
                }
            }
            else
            {
                Debug.LogWarning("The assigned GameObject does not have the 'Character' script.");
            }
        }
        else
        {
            Debug.LogWarning("Target GameObject is not assigned.");
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
