using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    public int pasillo;
    public int columna;

    public void Interact()
    {
        Debug.Log("Interacted with P" + pasillo + "C" + columna);
    }
}
