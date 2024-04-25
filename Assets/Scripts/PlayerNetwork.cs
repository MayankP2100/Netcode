using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] private Transform spawnedObjectPrefab;

    private void Update()
    {
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(spawnedObjectPrefab).GetComponent<NetworkObject>().Spawn(true);
        }

        Vector3 moveDirection = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) moveDirection.z = +1f;
        if (Input.GetKey(KeyCode.A)) moveDirection.x = -1f;
        if (Input.GetKey(KeyCode.S)) moveDirection.z = -1f;
        if (Input.GetKey(KeyCode.D)) moveDirection.x = +1f;

        float moveSpeed = 3f;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}