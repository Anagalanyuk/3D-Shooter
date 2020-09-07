using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	private int _helth;
    // Start is called before the first frame update
    void Start()
    {
		_helth = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Hurt(int damage)
	{
		_helth -= damage;
		Debug.Log("Helth: " + _helth);
	}
}
