using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SharkShop : MonoBehaviour
{

    [SerializeField]
    GameObject _coin, _pressESharkText;

    Player _player;

    [SerializeField]
    AudioClip _winSound;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_pressESharkText != null)
            {
                _pressESharkText.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_player.hasCoin)
                {
                    AudioSource.PlayClipAtPoint(_winSound, transform.position);
                    _player.PurchasedWeapon();
                    Destroy(_coin);
                    Destroy(_pressESharkText);
                }

                else if (!_player.hasCoin)
                {
                    Debug.Log("GET OUT OF HERE SCUM!");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_pressESharkText != null)
            {
                _pressESharkText.SetActive(false);
            }
        }
    }
}
