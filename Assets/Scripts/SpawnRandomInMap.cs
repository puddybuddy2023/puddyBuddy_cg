using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Utils;
using Mapbox.Unity.Map;

public class SpawnRandomInMap : MonoBehaviour
{
    public AbstractLocationProvider locationProvider;
    public Vector2d location;
    public AbstractMap map;
    public GameObject spawnedObject;

    void Start()
    {
        location = locationProvider.CurrentLocation.LatitudeLongitude;  //  현재 위치 가져옴
        spawnedObject = Instantiate(spawnedObject);
        spawnedObject.transform.localPosition = map.GeoToWorldPosition(location, true);
        spawnedObject.transform.localScale = new Vector3(5, 5, 5);
    }

    private void Update()
    {
        location = locationProvider.CurrentLocation.LatitudeLongitude;
        Vector3 _l = spawnedObject.transform.localPosition = map.GeoToWorldPosition(location, true);  // location위치에 오브젯트를 생성
        //Debug.Log(locationProvider.CurrentLocation.LatitudeLongitude[0]);
        //Debug.Log(_l[0]);
    }


}
