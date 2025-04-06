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
            gameObject.SetActive(false); // Deactivates the object this script is attached to

            // Clear the input field
            inputField.text = string.Empty; // Clears the input field
        }
    }

    void TriggerAction()
    {
        // Access the Character script on the target GameObject
        Character characterScript = targetObject.GetComponent<Character>();
        int quantity = int.Parse(inputField.text);

        string selectedObject = popupText.text.Substring(popupText.text.Length - 4);
        // Set variables in the Character script
        characterScript.SetCurrentObject(selectedObject); // Set current object
        characterScript.SetCurrentQuantity(quantity);
    }
}
