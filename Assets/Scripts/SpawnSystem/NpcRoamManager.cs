using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.SpawnSystem
{
    public class NpcRoamManager : MonoBehaviour
    {
        [SerializeField] private int npcCount = 10;
        [SerializeField] private float delay = 0.05f;
        [SerializeField] private GameObject npcPrefab;
        [SerializeField] private Transform[] leftToRight;
        [SerializeField] private Transform[] rightToLeft;

        [SerializeField] private List<Transform> leftWayNpc;
        [SerializeField] private List<Transform> rightWayNpc;

        //private Sequence rightNpcMoveSequence;

        private void Start()
        {
            Spawn();
            MoveNpc();
        }

        private void Spawn()
        {
            for (int i = 0; i < npcCount; i++)
            {
                

                if (i < npcCount / 2)
                {
                    GameObject npc = Instantiate(npcPrefab, transform);
                    Transform npcTrans = npc.transform;
                    npcTrans.position = leftToRight[0].position;
                    npcTrans.Rotate(new Vector3 (0f, 90f, 0f));
                    leftWayNpc.Add(npcTrans);
                }
                else
                {
                    GameObject npc = Instantiate(npcPrefab, transform);
                    Transform npcTrans = npc.transform;
                    npcTrans.position = rightToLeft[0].position;
                    npcTrans.Rotate(new Vector3(0f, -90f, 0f));
                    rightWayNpc.Add(npcTrans);
                }
            }
        }

        private void MoveNpc()
        {

            for (int i = 0; i < leftWayNpc.Count; i++)
            {
                Sequence leftNpcMoveSequence = DOTween.Sequence();

                Transform leftNpcTrans = leftWayNpc[i];
                leftNpcMoveSequence.Append(
                    leftNpcTrans.DOMove(leftToRight[1].position, 5f)
                    .OnComplete(() => leftNpcTrans.transform.Rotate(new Vector3(0f, -90f, 0f))
                    ));
                leftNpcMoveSequence.SetDelay(i * delay);
                leftNpcMoveSequence.SetLoops(-1, LoopType.Yoyo);

                Sequence rightNpcMoveSequence = DOTween.Sequence();

                Transform rightNpcTrans = rightWayNpc[i];
                rightNpcMoveSequence.Append(
                    rightNpcTrans.DOMove(rightToLeft[1].position, 5f)
                    .OnComplete(() => rightNpcTrans.transform.Rotate(new Vector3(0f, 90f, 0f))
                    ));
                rightNpcMoveSequence.SetDelay(i * delay);
                rightNpcMoveSequence.SetLoops(-1, LoopType.Yoyo);

            }


            for (int i = 0; i < rightWayNpc.Count; i++)
            {
                
            }
        }

      
    }
}
