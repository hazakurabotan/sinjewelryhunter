using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float axisH; //左右のキーの値を格納
    Rigidbody2D rbody;　//Rigidbody2Dの情報を扱うための媒体
    public float speed = 5.0f; //歩くすぴーど
    bool isJump;
    bool onGround;
    public LayerMask groundLayer;
    public float jump = 9.0f; //ジャンプ力

    // Start is called before the first frame update
    void Start()
    {
        //PlayerについているRigidbody2Dコンポーネントを
        //変数rbodyに宿した。以後、Rigidbody2Dコンポーネントの
        //変数rbodyという変数を通してプログラム側から活用できる。
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //左右のキーが押されたら、どっちの値だったのかをaxisHに格納
        //引数Horizontalの場合 ; 水平方向のキーが押された場合
        //左なら-1、右なら1、何も押されていないのあれば常に０を返すメソッド
        axisH = Input.GetAxisRaw("Horizontal");

        //もしaxisHが正の数なら右向き
        if (axisH > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //もしaxisHが負の数なら左向き
        else if (axisH < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);　//Vector3は構造体
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    }


    private void FixedUpdate()
    {
        //地面にいるかどうかさーくるキャスターで判断
        onGround = Physics2D.CircleCast(
            transform.position, //プレイヤーの基準点
            0.2f, //半径
            Vector2.down,　// 指定した点からどの方向にチェックをのばすか
            0.0f,　//指定した点からどれくらいのチェック距離を伸ばしたか
            groundLayer　//指定したレイヤー
            );

        //velocityに軸の方向データVector2を代入  Vector2は２つだけ
        rbody.velocity = new Vector2(axisH, rbody.velocity.y);
        if (isJump)
        {
            rbody.AddForce(new Vector2(0,jump),ForceMode2D.Impulse);
            isJump = false;
        }
    
    }

    public void Jump()
    {
        //地面判定がふぉるすならジャンプフラグは立てない
        if(onGround) isJump = true;
    }
    
}
