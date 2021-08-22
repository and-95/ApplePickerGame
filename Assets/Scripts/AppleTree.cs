using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Настройки")]
    public GameObject applePrefab;// создание яблок
    public float speed = 1f;// скорость движения яблок
    public float leftAndRightEdge = 10f;//расстояние для изменения направления движения яблони
    public float chanceToChangeDirection = 0.1f;//вероятность изменения направления
    public float secondBetweenAppleDrops = 1f;// частота создания яблок

    private void Start()
    {
        //сброс яблок в секунду
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondBetweenAppleDrops);
    }

    private void Update() //перемещение и изменение направления
    {
        //перемещение
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //направление
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);//движение вправо
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);//движение влево
        }

    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirection)
        {
            speed *= -1; //изменение направления
        }
    }

}
