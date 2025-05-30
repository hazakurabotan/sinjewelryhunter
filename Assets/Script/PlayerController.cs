using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float axisH; //���E�̃L�[�̒l���i�[
    Rigidbody2D rbody;�@//Rigidbody2D�̏����������߂̔}��
    public float speed = 5.0f; //�������ҁ[��
    bool isJump;
    bool onGround;
    public LayerMask groundLayer;
    public float jump = 9.0f; //�W�����v��

    // Start is called before the first frame update
    void Start()
    {
        //Player�ɂ��Ă���Rigidbody2D�R���|�[�l���g��
        //�ϐ�rbody�ɏh�����B�Ȍ�ARigidbody2D�R���|�[�l���g��
        //�ϐ�rbody�Ƃ����ϐ���ʂ��ăv���O���������犈�p�ł���B
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //���E�̃L�[�������ꂽ��A�ǂ����̒l�������̂���axisH�Ɋi�[
        //����Horizontal�̏ꍇ ; ���������̃L�[�������ꂽ�ꍇ
        //���Ȃ�-1�A�E�Ȃ�1�A����������Ă��Ȃ��̂���Ώ�ɂO��Ԃ����\�b�h
        axisH = Input.GetAxisRaw("Horizontal");

        //����axisH�����̐��Ȃ�E����
        if (axisH > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //����axisH�����̐��Ȃ獶����
        else if (axisH < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);�@//Vector3�͍\����
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    }


    private void FixedUpdate()
    {
        //�n�ʂɂ��邩�ǂ������[����L���X�^�[�Ŕ��f
        onGround = Physics2D.CircleCast(
            transform.position, //�v���C���[�̊�_
            0.2f, //���a
            Vector2.down,�@// �w�肵���_����ǂ̕����Ƀ`�F�b�N���̂΂���
            0.0f,�@//�w�肵���_����ǂꂭ�炢�̃`�F�b�N������L�΂�����
            groundLayer�@//�w�肵�����C���[
            );

        //velocity�Ɏ��̕����f�[�^Vector2����  Vector2�͂Q����
        rbody.velocity = new Vector2(axisH, rbody.velocity.y);
        if (isJump)
        {
            rbody.AddForce(new Vector2(0,jump),ForceMode2D.Impulse);
            isJump = false;
        }
    
    }

    public void Jump()
    {
        //�n�ʔ��肪�ӂ��邷�Ȃ�W�����v�t���O�͗��ĂȂ�
        if(onGround) isJump = true;
    }
    
}
