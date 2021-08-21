using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text _ammoText;

    Player _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        UpdateAmmo(_player._maxAmmo);
    }

    public void UpdateAmmo(int ammo)
    {
        _ammoText.text = "Ammo: " + ammo.ToString();
    }
}
