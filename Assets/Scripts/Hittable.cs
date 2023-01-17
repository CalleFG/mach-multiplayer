using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int>
{
}

public class Hittable : MonoBehaviour
{
    [SerializeField] private IntEvent onHit;
    private int _selfID = -2;

    private void Start()
    {
        onHit ??= new IntEvent();
        _selfID = GetComponent<Alteruna.Avatar>().Possessor.Index;
    }

    public void Hit(int instigatorID)
    {
        onHit.Invoke(instigatorID);
    }
}
