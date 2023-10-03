using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Utils;
using Mapbox.Unity.Map;

public class SpawnRandomInMap : MonoBehaviour
{
    public AbstractLocationProvider locationProvider;
    public Vector2d location;  // 현재 위치 
    public AbstractMap map;
    public GameObject spawnedObject;
    public List<GameObjectInfo> spawnedObjects = new List<GameObjectInfo>(); // GameObjectInfo 리스트 추가

    [System.Serializable]
    public class GameObjectInfo
    {
        public GameObject obj;
        public Vector2d objLoc;
    }

    void Start()
    {
        location = locationProvider.CurrentLocation.LatitudeLongitude;  //  현재 위치 가져옴

        // Random.Range를 사용하여 5에서 10초 사이의 랜덤한 주기를 생성합니다.
        float initialDelay = Random.Range(5f, 10f);
        float repeatRate = Random.Range(5f, 10f);

        // 함수를 주기적으로 실행합니다.
        InvokeRepeating("Spawn", initialDelay, repeatRate);
    }

    private void Update()
    {
        location = locationProvider.CurrentLocation.LatitudeLongitude;

        // Update 함수에서 spawnedObjects 리스트의 모든 요소에 대해 위치 업데이트
        foreach (var objInfo in spawnedObjects)
        {
            objInfo.obj.transform.localPosition = map.GeoToWorldPosition(objInfo.objLoc, true);
        }
    }

    private void Spawn()
    {
        float randomValue1 = Random.Range(-0.0005f, 0.0005f);
        float randomValue2 = Random.Range(-0.0005f, 0.0005f);

        GameObject obj;
        obj = Instantiate(spawnedObject);
        Vector2d objLoc = new Vector2d(location[0] - randomValue1, location[1] - randomValue2);
        obj.transform.localPosition = map.GeoToWorldPosition(objLoc, true);
        obj.transform.localScale = new Vector3(5, 5, 5);

        // GameObjectInfo를 생성하고 리스트에 추가
        GameObjectInfo objInfo = new GameObjectInfo
        {
            obj = obj,
            objLoc = objLoc
        };
        spawnedObjects.Add(objInfo);
    }
}
