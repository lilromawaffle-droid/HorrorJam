using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null && spawnPoint != null)
        {
            CharacterController cc = player.GetComponent<CharacterController>();

            if (cc != null) cc.enabled = false;
            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation;
            if (cc != null) cc.enabled = true;

            Debug.Log("Player respawned at: " + spawnPoint.position);
        }
        else
        {
            Debug.LogWarning("Player atau SpawnPoint tidak ditemukan!");
        }
    }
}