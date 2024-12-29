using UnityEngine;
using System.Collections;

public class SpwanManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Prefab;

    [SerializeField]
    private float minimumSpwanTime;

    [SerializeField]
    private float maxiumSpwanTime;

    private float TimeUntilSpwan;

    void Awake()
    {
        SetTimeUnitlSpwan();
    }

    void Update()
    {
        TimeUntilSpwan-=Time.deltaTime;
        if(TimeUntilSpwan <= 0)
        {
            Instantiate(Prefab,transform.position,Quaternion.identity);
            SetTimeUnitlSpwan();
        }
    }
    private void SetTimeUnitlSpwan()
    {
        TimeUntilSpwan=Random.Range(minimumSpwanTime, maxiumSpwanTime);
    }


}
