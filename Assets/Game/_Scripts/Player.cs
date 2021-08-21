using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    CharacterController _controller;

    [SerializeField]
    GameObject _muzzleFlash, hitMarkerPrefab;

    [SerializeField]
    AudioSource _audioSource;

    [SerializeField]
    AudioClip _laserShootSound;

    [SerializeField]
    float _moveSpeed = 1.5f;

    float _gravity = 9.81f;

    

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetMouseButton(0))
        {
            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("You shot: " + hitInfo.transform.name);
            }

            _muzzleFlash.SetActive(true);

            if (_audioSource.isPlaying == false)
            {
                _audioSource.Play();
            }

            GameObject hitMarker = Instantiate(hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitMarker, 1f);
        }

        else
        {
            _muzzleFlash.SetActive(false);
            _audioSource.Stop();
        }
    }

  

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = movement * _moveSpeed;
        velocity = transform.transform.TransformDirection(velocity);
        velocity.y -= _gravity;
        _controller.Move(velocity * Time.deltaTime);
    }
}
