using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [SerializeField]
    public GameObject pressEText;

    [SerializeField]

    Player _player;
    AudioSource _audioSource;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (pressEText != null)
            {
                pressEText.SetActive(true);
            }

            if (Input.GetKeyDown("e"))
            {
                _player.hasCoin = true;
                _audioSource.Play();
                Destroy(pressEText);
                Destroy(this.gameObject, 0.5f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pressEText.SetActive(false);
        }
    }
}
