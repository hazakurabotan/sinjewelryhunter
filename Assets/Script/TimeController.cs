using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float gameTime = 60.0f; //基準時間
    public float currentTime; //現在の残り時間
    float pastTime = 0; //経過時間

    public bool isTimeOver; //カウントダウンを止めるフラグ


    // Start is called before the first frame update
    void Start()
    {
        currentTime = gameTime; //残り時間に基準時間をセット
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimeOver)
        {
            return; //タイムオーバーのフラグが立ったらそれ以上カウントダウンしない
        }

        //経過時間
        pastTime += Time.deltaTime; //1フレームあたりにかかる時間

        //残り時間の計算
        currentTime = gameTime - pastTime; 
        
        //残り時間が0秒以下であれば
        if(currentTime <= 0)
        {
            isTimeOver = true; //カウントダウンしないフラグをON
            currentTime = 0f; //残り時間を0にピッタリ整える
        }

        //コンソールパネルに情報出力
        Debug.Log("残り時間：" + currentTime);
    }
}
