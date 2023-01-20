using UnityEngine;
using Alteruna;
public class PlayerStats : MonoBehaviour
{
    private Alteruna.Avatar _avatar;
    
    void Start()
    {
        _avatar = GetComponent<Alteruna.Avatar>();

        if (!_avatar.IsMe)
        {
            Debug.Log("This is NOT me!");
            return;
        }
        Debug.Log("Avatar name: " + _avatar.Possessor.Index);
    }

    void Update()
    {
        if (!_avatar.IsMe) return;
        
    }

    
}
