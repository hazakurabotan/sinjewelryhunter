using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GimmicBlock : MonoBehaviour
{
    public float length = 3.0f; //�����������m����
    public bool isDelete = false; //������ɏ��ł���t���O
    public GameObject deadObj; //���S�����蔻��
    bool isFell = false; //�����t���O
    float fadeTime = 0.5f; //�t�F�[�h�A�E�g����

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("GimmicBlock is alive! " + gameObject.name);

        //Rigidbody2D�̕����������~
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.bodyType = RigidbodyType2D.Static;
        deadObj.SetActive(false); //���S��������\��

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("GimmicBlock is alive! " + gameObject.name);

        GameObject player =
        GameObject.FindGameObjectWithTag("Player"); //�v���C���[��T��
        if (player != null)
        {
            //�v���C���[�Ƃ̋�������
            float d = Vector2.Distance(
                transform.position, player.transform.position);
            if (length >= d)
            {
                Rigidbody2D rbody = GetComponent<Rigidbody2D>();
                if (rbody.bodyType == RigidbodyType2D.Static)
                {
                    //Rigidbody2D�̕��������̊J�n
                    rbody.bodyType = RigidbodyType2D.Dynamic;
                    deadObj.SetActive(true); //���S�����蔻���\��
                }
            }
        }
        if (isFell)
        {
            fadeTime -= Time.deltaTime; // �������I���炵�Ă���
            Color col = GetComponent<SpriteRenderer>().color;
            col.a = fadeTime; // �ŏ�0.5��0.0�Ɍ������Ȃ�0�`1�ɐ��K��
            GetComponent<SpriteRenderer>().color = col;
            if(fadeTime <= 0.0f)
            {
                Destroy(this.gameObject);

            }

        }

    }
            private void OnCollisionEnter2D(Collision2D collision)
           {
            if (isDelete)
             {
            isFell = true;
             }
           } 

 
    //�͈͕\��
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, length);
    }

}

