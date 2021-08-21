using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField]
    GameObject _destroyedCrate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyedObject()
    {
        Instantiate(_destroyedCrate, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
