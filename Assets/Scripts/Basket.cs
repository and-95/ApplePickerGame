using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Настройки динамики")]
    public Text scoreGT;

     void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");//настройка интерфейса
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }

    void Update()
    {
        //текущие координаты мыши
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;// координата z определяет в трехмерном пространстве, как далеко находится указатель мыши
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); //преоброзование точки в 2D в 3D координаты игры
        //перемещение корзины вдоль оси х указателя мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);


            int score = int.Parse(scoreGT.text);
            score += 1;
            scoreGT.text = score.ToString();
            //высший результат
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
