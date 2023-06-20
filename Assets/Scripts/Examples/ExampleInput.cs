using UnityEngine;
using Cinemachine;

namespace e23.VehicleController.Examples
{
	public class ExampleInput : MonoBehaviour
	{
		[SerializeField] private VehicleBehaviour vehicleBehaviour;

        // Cameras
        [SerializeField] private CinemachineVirtualCamera cinemachineCamera1;
        [SerializeField] private CinemachineVirtualCamera cinemachineCamera2;

        [Header("Controls")]
		[SerializeField] private KeyCode accelerate = KeyCode.W;
		[SerializeField] private KeyCode brake = KeyCode.S;
		[SerializeField] private KeyCode steerLeft = KeyCode.A;
		[SerializeField] private KeyCode steerRight = KeyCode.D;
// This stops a console warning because strafeLeft and strafeRight are not assigned here, they're open to be assigned in the inspector
#pragma warning disable 0649
		[SerializeField] private KeyCode strafeLeft;
		[SerializeField] private KeyCode strafeRight;
#pragma warning restore 0649
		[SerializeField] private KeyCode boost = KeyCode.Space;
		[SerializeField] private KeyCode oneShotBoost = KeyCode.B;

        // Camera switch key
        [SerializeField] private KeyCode cameraSwitch = KeyCode.C;

        [Header("Settings")]
		[SerializeField] private float boostLength = 1f;

		public VehicleBehaviour VehicleBehaviour { get => vehicleBehaviour; set => vehicleBehaviour = value; }

        private bool isCamera1Active = true;

        private void FixedUpdate()
		{
			if (Input.GetKeyDown(KeyCode.E)) { vehicleBehaviour.ToggleEngine(!vehicleBehaviour.EngineRunning, false); }
			
			// Acceleration
			if (Input.GetKey(accelerate)) { VehicleBehaviour.ControlAcceleration(); }
			if (Input.GetKey(brake)) { VehicleBehaviour.ControlBrake(); }

			// Steering
			if (Input.GetKey(steerLeft)) { VehicleBehaviour.ControlTurning(-1f); }
			if (Input.GetKey(steerRight)) { VehicleBehaviour.ControlTurning(1f); }

			// Strafing
			if (Input.GetKey(strafeLeft)) { VehicleBehaviour.ControlStrafing(-1f); }
			if (Input.GetKey(strafeRight)) { VehicleBehaviour.ControlStrafing(1f); }

			// Boost
			if (Input.GetKeyDown(boost)) { VehicleBehaviour.Boost(); }
			if (Input.GetKeyUp(boost)) { VehicleBehaviour.StopBoost(); }
			if (Input.GetKey(oneShotBoost)) { VehicleBehaviour.OneShotBoost(boostLength); }

            // Camera switch
            if (Input.GetKeyDown(cameraSwitch))
            {
                cinemachineCamera1.gameObject.SetActive(isCamera1Active);
                cinemachineCamera2.gameObject.SetActive(!isCamera1Active);
                isCamera1Active = !isCamera1Active;
            }
        }
    }
}