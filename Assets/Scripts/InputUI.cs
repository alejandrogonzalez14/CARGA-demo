using UnityEngine;
using UnityEngine.UI;  // For InputField
using TMPro;           // For TMP_InputField, if you're using TextMeshPro

public class InputUI : MonoBehaviour
{
    public TMP_InputField inputField;

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
        // You can add any action you want to trigger here
    }
}
