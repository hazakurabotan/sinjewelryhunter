using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static string gameState; //ゲームの状態管理役 ※ 静的変数

    public GameObject stageTitle; //ステージタイトルのUIオブジェクト
    public Sprite gameClearSprite; //ゲームクリアの絵
    public Sprite gameOverSprite; //ゲームオーバーの絵


    public GameObject buttonPanel; //ボタンパネルのUIオブジェクト
    public GameObject restartButton; //リスタートボタン
    public GameObject nextButton; //ネクストボタン

    TimeController timeCnt; //TimeControllerスクリプトを取得する

    public TextMeshProUGUI timeText; //TimeTextオブジェクトが持っているTextMeshProコンポーネントの情報を取得

    // Start is called before the first frame update
    void Start()
    {
        //ゲーム開始と同時にゲームステータスを"playing"
        gameState = "playing";

        Invoke("InactiveImage",1.0f); //第一引数に指定したメソッド(名)を、第二引数秒後に発動
        
        buttonPanel.SetActive(false); //オブジェクトを非表示

        //TimeControllerコンポーネントの情報を取得
        timeCnt = GetComponent<TimeController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState == "playing")
        {
            //カウントダウンの変数currentTimeをUIに連動
            //timeCntのcurrentTime(float型)をまずintに型変換してから、
            //ToString()で文字列に変換し、timeText(TextMeshPro)のtext欄に代入
            timeText.text = ((int)timeCnt.currentTime).ToString();

            //もしcurrentTimeが0になったらゲームオーバー
            if(timeCnt.currentTime <= 0)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player"); //プレイヤーを探す
                //探し出したプレイヤーが持っているPlayerControllerコンポーネントのGameOverメソッドを発動
                player.GetComponent<PlayerController>().GameOver();
            }

        }

        //ゲームの状態がクリアまたはオーバーの時、ボタンを復活させたい
        else if(gameState == "gameclear" || gameState == "gameover")
        {
            //ステージタイトルを復活
            stageTitle.SetActive(true);

            //ボタンの復活
            buttonPanel.SetActive(true);
        }

        if(gameState == "gameclear")
        {
            stageTitle.GetComponent<Image>().sprite = gameClearSprite;

            //restartButtonオブジェクトがもっているButtonコンポーネントの値であるinteractableをfalse　→　ボタン機能を停止
            restartButton.GetComponent<Button>().interactable = false;
        }
        else if (gameState == "gameover")
        {
            stageTitle.GetComponent<Image>().sprite = gameOverSprite;

            //nextButtonオブジェクトがもっているButtonコンポーネントの値であるinteractableをfalse　→　ボタン機能を停止
            nextButton.GetComponent<Button>().interactable = false;
        }
    }

    //ステージタイトルを非表示にするメソッド
    void InactiveImage()
    {
        stageTitle.SetActive(false); //オブジェクトを非表示
    }

}
