using UnityEngine;
using TMPro;           // For TMP_InputField, if you're using TextMeshPro

public class InputUI : MonoBehaviour
{
    public TMP_InputField inputField;  // Reference to your TMP Input Field
    public GameObject targetObject;    // Reference to the GameObject that holds the Character script
    public TextMeshProUGUI popupText; // Reference to the TextMeshProUGUI component

    void Update()
    {
        // Check for the Enter key press and if the input is not empty
        if (Input.GetKeyDown(KeyCode.Return) && !string.IsNullOrEmpty(inputField.text))
        {
            // Trigger your action here
            TriggerAction();
        }
    }

    void TriggerAction()
    {
        Debug.Log("Enter key pressed and input is not empty!");

        // Check if the targetObject is assigned
        if (targetObject != null)
        {
            // Access the Character script on the target GameObject
            Character characterScript = targetObject.GetComponent<Character>();

            if (characterScript != null)
            {

                int quantity = int.Parse(inputField.text);

                Debug.Log(popupText.text);

                string selectedObject = popupText.text.Substring(popupText.text.Length - 4);
                // Set variables in the Character script
                characterScript.SetCurrentObject(selectedObject); // Set current object
                characterScript.SetCurrentQuantity(quantity);

                Debug.Log("Player has object " + selectedObject + " in quantity " + quantity);
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
}
