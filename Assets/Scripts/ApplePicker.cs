using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Настройки")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;// высота положения
    public float basketSpacingY = 2f;// расстояние корзин к корзине
    public List<GameObject> basketList;

    void Start()
    {
       basketList = new List<GameObject>();
       for(int i =0; i < numBaskets; i++)// создание 3 корзин
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");// далить все упавшие яблоки
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        //удалить 1 корзину 
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        //перезапуск игры
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("End");
        }

    }
}
