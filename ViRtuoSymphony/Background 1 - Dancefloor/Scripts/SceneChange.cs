using UnityEngine;

public class EnvironmentChanger : MonoBehaviour
{
    public GameObject[] environments; // Array to hold your environments

    private int currentEnvironmentIndex = 0; // Current environment index

    public void ChangeEnvironment()
    {
        // Disable current environment
        environments[currentEnvironmentIndex].SetActive(false);

        // Change index to next environment
        currentEnvironmentIndex = (currentEnvironmentIndex + 1) % environments.Length;

        // Enable new current environment
        environments[currentEnvironmentIndex].SetActive(true);
    }
}
