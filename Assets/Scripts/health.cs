using Alteruna;
using UnityEngine;
using UnityEngine.UI;
using Avatar = Alteruna.Avatar;

public class health : AttributesSync
{
    [SynchronizableField] private int healthPoints = 10;
    [SerializeField] private Text text;

    public void TakeDamage(int dmg)
    {
        healthPoints -= dmg;
    }
    
    void Update()
    {

        text.text = ""+healthPoints;
    }
}
