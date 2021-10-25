using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject Player;
    public Vector3 offset = new Vector3(0, 9, -10);
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + offset;
    }
}
