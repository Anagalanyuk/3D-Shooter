using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
	private int _helth;
    void Start()
    {
		_helth = 5;
    }

	public void Hurt(int damage)
	{
		_helth -= damage;
	}
}