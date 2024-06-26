using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;    //�ϥ�UnityEngine.AI
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("�l�ܥؼг]�w")]
    public string targetName = "Player";       // �]�w�ؼЪ��󪺼��ҦW��
    public float minimunTraceDistance = 5.0f;  // �]�w�̵u���l�ܶZ��

    [Header("�ͩR��")]
    public float maxLife = 10.0f;              // �]�w�ĤH���̰��ͩR��
    public Image lifeBarImage;                 // �]�w�ĤH������Ϥ�
    float lifeAmount;                          // �ثe���ͩR��

    NavMeshAgent navMeshAgent;                 // �ŧiNavMeshAgent����
    GameObject targetObject = null;            // �ؼЪ����ܼ�

    void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag(targetName);   // �H�a���S�w�����ҦW�٬��ؼЪ���
        navMeshAgent = GetComponent<NavMeshAgent>();                   // ����NavMeshAgent
        lifeAmount = maxLife;
    }

    void Update()
    {
        // �p��ؼЪ���M�ۤv���Z��
        float distance = Vector3.Distance(transform.position, targetObject.transform.position);

        // �P�_���G�P�_�Z���O�_�C��̵u�l�ܶZ���A�p�G�P�ؼЪ��Z���j��̤p�Z���A�N���l�ܡA�_�h�N�}�l�l��
        if (distance <= minimunTraceDistance)
            navMeshAgent.enabled = true;
        else
            navMeshAgent.enabled = false;

        faceTarget(); // �N�ĤH�@���������﨤��A�]���ĤH�M�����m�|�ܤơA�ҥH�n���_Update

        // �P�_���G�p�G�ͩR�ƭȧC��0�A�h���ĤH����
        if (lifeAmount <= 0.0f)
            Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (navMeshAgent.enabled)
            navMeshAgent.SetDestination(targetObject.transform.position);    // ���ۤv���ؼЪ����y�в���   
    }

    // �I������
    private void OnCollisionEnter(Collision collision)
    {
        // �p�G�I��a��Bullet���Ҫ�����A�N�n����A�åB��s������A
        if (collision.gameObject.tag == "Bullet")
        {
            lifeAmount -= 1.0f;
            //Debug.Log(lifeAmount / maxLife);
            lifeBarImage.fillAmount = lifeAmount / maxLife;
        }
    }

    // �禡�G�N�ĤH�@���������﨤��(�]�N�O���ĤH��Z�b���_���˷Ǩ���)
    void faceTarget()
    {
        Vector3 targetDir = targetObject.transform.position - transform.position;                               // �p��ĤH�P���⤧�����V�q
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 0.1f * Time.deltaTime, 0.0F);      // �̷ӼĤHZ�b�V�q�P��̶��V�q�A�i�H�p��X�ݭn���઺����
        transform.rotation = Quaternion.LookRotation(newDir);                                                   // �i�����
    }
}