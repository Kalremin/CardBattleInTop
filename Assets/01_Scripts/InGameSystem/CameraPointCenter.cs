using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointCenter : MonoBehaviour
{
    bool isLock = false;
    int lockonIdx = 0;

    Transform lockonTransform;
    List<Transform> enemyLockonTransform = new List<Transform>();

    public bool IsLock => isLock && enemyLockonTransform.Count > 0;
    public Transform LockonTransformm => lockonTransform;

    private void Update()
    {
        if (IsLock)
            lockonTransform = enemyLockonTransform[lockonIdx];
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
            if(other.TryGetComponent(out EnemyCharacter eCharacter))
            {
                if(eCharacter.IsAlive)
                {
                    enemyLockonTransform.Add(other.transform);

                }
                else if (enemyLockonTransform.Contains(other.transform))
                {
                    enemyLockonTransform.Remove(other.transform);

                }
            }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
            enemyLockonTransform.Remove(other.transform);

    }

    public void SetIsLock(bool val)
    {
        isLock = val;
        if (isLock)
        {
            lockonIdx = 0;
            lockonTransform = enemyLockonTransform[lockonIdx];
            lockonTransform.GetComponent<EnemyCharacter>().lockOnGround.SetActive(true);
        }
        else
        {
            lockonTransform = enemyLockonTransform[lockonIdx];
            lockonTransform.GetComponent<EnemyCharacter>().lockOnGround.SetActive(false);
        }
    }

    public void ChangeLockonTarget()
    {

        lockonTransform.GetComponent<EnemyCharacter>().lockOnGround.SetActive(false);

        if (lockonIdx == enemyLockonTransform.Count - 1)
        {
            lockonIdx = 0;
        }
        else
            lockonIdx++;

        lockonTransform = enemyLockonTransform[lockonIdx];
        lockonTransform.GetComponent<EnemyCharacter>().lockOnGround.SetActive(true);

    }
}
