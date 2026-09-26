using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 10;
    private List<GameObject> bulletList = new List<GameObject>();
    private static BulletPool instance;

    public static BulletPool Instance{
        get { 
            return instance; 
        }
    }

    private void Awake(){
        //Debug.Log("BULLET POOL AWAKE");
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Start(){
        //Debug.Log("START DEL BULLET POOL");
        AddBulletsToPool(poolSize);
        //Debug.Log("START BALAS CREADAS: " + bulletList.Count);
    }

    private void AddBulletsToPool(int cantidad){
        for (int i = 0; i < cantidad; i++){
            GameObject bullet = Instantiate(bulletPrefab, transform);
            Debug.Log("CREADA: " + bullet.name);
            bullet.SetActive(false);
            bulletList.Add(bullet);
        }
    }

    public GameObject RequestBullet(){
        for (int i = 0; i < bulletList.Count; i++){
            if (!bulletList[i].activeSelf){
                //Debug.Log("REUTILIZANDO BALA: " + i);
                return bulletList[i];
            }
        }

        AddBulletsToPool(1);
        //Debug.Log("POOL LLENO - CREANDO UNA BALA NUEVA");
        return bulletList[bulletList.Count - 1];
    }
}
