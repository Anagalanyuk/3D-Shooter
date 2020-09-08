using System;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
	public const float _baseSpeed = 6.0f;

	public float _speed = 6.0f;
	public float _gravity = -9.8f;
	private CharacterController _charControler;

    private void Awake()
    {
		Messenger<float>.AddListener(GameEvent.SPEED_CHANGE, OnSpeedChanged);
    }

    private void OnDestroy()
    {
		Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGE, OnSpeedChanged);
    }

    private void OnSpeedChanged(float value)
    {
		_speed = _baseSpeed * value;
    }

    void Start()
    {
		_charControler = GetComponent<CharacterController>();
    }

    void Update()
    {
		float deltaX = Input.GetAxis("Horizontal") * _speed;
		float deltaZ = Input.GetAxis("Vertical") * _speed;
		Vector3 movement = new Vector3(deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude(movement, _speed);

		movement.y = _gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charControler.Move(movement);
	}
}
