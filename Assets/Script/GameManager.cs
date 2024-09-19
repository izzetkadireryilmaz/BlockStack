using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static event Action OnCubeSpawned = delegate { };

    private CubeRespawn[] spawners;
    private int spawnIndex;
    private CubeRespawn currentSpawn;

    private void Awake()
    {
        spawners = FindObjectsOfType<CubeRespawn>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // UI elemanýna týklanmadýðýný kontrol et
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    if (MovingCube.currentCube != null)
                        MovingCube.currentCube.Stop();

                    spawnIndex = spawnIndex == 0 ? 1 : 0;
                    currentSpawn = spawners[spawnIndex];
                    currentSpawn.SpawnCube();

                    OnCubeSpawned();
                }
            }
        }

    }
}
