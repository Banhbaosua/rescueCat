using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Watermelon;
using System.Threading;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;

public enum CatchType
{
    Follow,
    Hold,
}

public class CatCatcher : MonoBehaviour
{
    [SerializeField] Transform catchZone;
    [SerializeField] float timeToCatch;
    private List<CatBehaviour> catFollows;
    private List<CatBehaviour> catHolds;
    private List<Transform> headPos;
    private Dictionary<CatBehaviour, CancellationTokenSource> cancelTokenByCat;
    public void Init(List<Transform> headPos)
    {
        this.headPos = headPos;
        cancelTokenByCat = new Dictionary<CatBehaviour, CancellationTokenSource>();
        catFollows = new List<CatBehaviour>();
        catHolds = new List<CatBehaviour>();
        Debug.Log(headPos.Count);
    }

    private void Update()
    {
        Debug.Log(cancelTokenByCat.Count);
        if(cancelTokenByCat.Count > 0)
            catchZone.gameObject.SetActive(true);
        else
            catchZone.gameObject.SetActive(false);
    }
    async UniTaskVoid CatchCat(CatBehaviour cat, CancellationTokenSource cts)
    {
        float timer = 0;
        catchZone.gameObject.SetActive(true);
        while (timer < timeToCatch)
        {

            timer += Time.deltaTime;
            await UniTask.Yield(cancellationToken: cts.Token);
        }
        cat.Catched();
        var catchType = RandomCatchBehaviour();
        if (catchType == CatchType.Follow)
            CatchTypeFollowBehaviour(cat);
        else
            CatchTypeHoldBehaviour(cat);

        cancelTokenByCat.Remove(cat);
    }

    CatchType RandomCatchBehaviour()
    {
        var random = Random.Range(0, catHolds.Count<headPos.Count?2:0);
        Debug.Log(random);
        if(random == 0)
        {
            return CatchType.Follow;
        }
        else
        {
            return CatchType.Hold;
        }
    }

    void CatchTypeFollowBehaviour(CatBehaviour cat)
    {
        cat.Run();
        if (catFollows.Count == 0)
            cat.Follow(transform.parent.transform);
        else
        {
            var catToFollow = catFollows[catFollows.Count - 1].transform;
            cat.Follow(catToFollow);
        }
        cat.SetSpeed(2.5f);
        catFollows.Add(cat);
    }

    void CatchTypeHoldBehaviour(CatBehaviour cat)
    {
        cat.Stop();
        cat.Hold();
        var parent = headPos[catHolds.Count].transform;
        cat.transform.parent = parent;
        cat.transform.DOLocalMove(Vector3.zero, 1f);
        cat.transform.rotation = Quaternion.identity;
        catHolds.Add(cat);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CatBehaviour>() != null)
        {
            var cat = other.GetComponent<CatBehaviour>();
            if (cat.IsCatched || cancelTokenByCat.ContainsKey(cat)) return;
            CancellationTokenSource cts = new CancellationTokenSource();
            cancelTokenByCat.Add(cat, cts);

            _ = CatchCat(cat, cts);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent <CatBehaviour>() != null)
        {
            catchZone.gameObject.SetActive(true);
        }
        else
        { 
            catchZone.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CatBehaviour>() != null)
        {
            var cat = other.GetComponent<CatBehaviour>();
            if (cancelTokenByCat.ContainsKey(cat))
            {
                cancelTokenByCat[cat].Cancel();
                cancelTokenByCat.Remove(cat);
            }
        }
    }
}
