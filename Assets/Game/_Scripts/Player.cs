using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    CharacterController _controller;

    [SerializeField]
    GameObject _muzzleFlash, _hitMarkerPrefab, _coin;

    [SerializeField]
    AudioSource _audioSource;

    [SerializeField]
    AudioClip _laserShootSound;

    [SerializeField]
    float _moveSpeed = 1.5f;

    float _gravity = 9.81f;

    [SerializeField]
    public int _currentAmmo, _maxAmmo = 150;

    bool _isReloading = false;
    public bool hasCoin = false;

    UIManager _uiManager;

    

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _currentAmmo = _maxAmmo;
        _uiManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetMouseButton(0) && _currentAmmo > 0)
        {
            Shoot();
        }

        else if (_currentAmmo < _maxAmmo && Input.GetKeyDown(KeyCode.R) && !_isReloading)
        {
            Invoke("Reload", 1.5f);
        }

        else if (_currentAmmo == 0 && Input.GetKeyDown(KeyCode.R))
        {
            Invoke("Reload", 1.5f);
        }

        else
        {
            _muzzleFlash.SetActive(false);
            _audioSource.Stop();
        }

        if (hasCoin)
        {
            _coin.SetActive(true);
        }
    }

    private void Reload()
    {
        _currentAmmo = _maxAmmo;
        _uiManager.UpdateAmmo(_currentAmmo);
        _isReloading = true;
    }

    private void Shoot()
    {
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            Debug.Log("You shot: " + hitInfo.transform.name);
        }
        _currentAmmo--;
        _uiManager.UpdateAmmo(_currentAmmo);
        _muzzleFlash.SetActive(true);

        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        GameObject hitMarker = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        Destroy(hitMarker, 1f);
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
