namespace GameCreator.Core
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
    using HurricaneVR.Framework.Shared;
    using HurricaneVR.Framework.ControllerInput;
    [AddComponentMenu("")]
    public class OnControllerInput : Igniter 
	{
		#if UNITY_EDITOR
        public new static string NAME = "Field/On Controller Input";
        //public new static string COMMENT = "Uncomment to add an informative message";
        //public new static bool REQUIRES_COLLIDER = true; // uncomment if the igniter requires a collider
        #endif
        public HVRButtons button;
        public HVRHandSide side;
        public HVRButtonState state;
        private void Start()
        {
            var GlobalInputs = HVRGlobalInputs.Instance;
            state = SetControllerState();
        }

        private void Update()
        {
            if(state.JustActivated) {
                this.ExecuteTrigger(gameObject);
            }
        }

        private HVRButtonState SetControllerState() {
            bool left = side == HVRHandSide.Left;
            switch(button) {
                case HVRButtons.Grip:
                    return left 
                      ? HVRGlobalInputs.Instance.LeftGripButtonState
                      : HVRGlobalInputs.Instance.RightGripButtonState;
                case HVRButtons.Primary: 
                    return left
                      ? HVRGlobalInputs.Instance.LeftPrimaryButtonState
                      : HVRGlobalInputs.Instance.RightPrimaryButtonState;
                case HVRButtons.JoystickButton:
                    return left
                      ? HVRGlobalInputs.Instance.LeftJoystickButtonState
                      : HVRGlobalInputs.Instance.RightJoystickButtonState;
                case HVRButtons.JoystickTouch:
                    return left
                      ? HVRGlobalInputs.Instance.LeftJoystickTouchState
                      : HVRGlobalInputs.Instance.RightJoystickTouchState;
                case HVRButtons.Menu:
                    return left
                      ? HVRGlobalInputs.Instance.LeftMenuButtonState
                      : HVRGlobalInputs.Instance.RightMenuButtonState;
                case HVRButtons.PrimaryTouch:
                    return left
                      ? HVRGlobalInputs.Instance.LeftPrimaryTouchButtonState
                      : HVRGlobalInputs.Instance.RightPrimaryTouchButtonState;
                case HVRButtons.Secondary:
                    return left
                      ? HVRGlobalInputs.Instance.LeftSecondaryButtonState
                      : HVRGlobalInputs.Instance.RightSecondaryButtonState;
                case HVRButtons.SecondaryTouch:
                    return left
                      ? HVRGlobalInputs.Instance.LeftSecondaryTouchButtonState
                      : HVRGlobalInputs.Instance.RightSecondaryTouchButtonState;
                case HVRButtons.ThumbNearTouch:
                    return left
                      ? HVRGlobalInputs.Instance.LeftThumbNearTouchState
                      : HVRGlobalInputs.Instance.RightThumbNearTouchState;
                case HVRButtons.ThumbTouch:
                    return left
                      ? HVRGlobalInputs.Instance.LeftThumbTouchState
                      : HVRGlobalInputs.Instance.RightThumbTouchState;
                case HVRButtons.TrackPadDown:
                    return left
                      ? HVRGlobalInputs.Instance.LeftTrackPadDown
                      : HVRGlobalInputs.Instance.RightTrackPadDown;
                case HVRButtons.TrackPadLeft:
                    return left
                      ? HVRGlobalInputs.Instance.LeftTrackPadLeft
                      : HVRGlobalInputs.Instance.RightTrackPadLeft;
                case HVRButtons.TrackPadUp:
                    return left
                      ? HVRGlobalInputs.Instance.LeftTrackPadUp
                      : HVRGlobalInputs.Instance.RightTrackPadUp;
                case HVRButtons.TrackPadRight:
                    return left
                      ? HVRGlobalInputs.Instance.LeftTrackPadRight
                      : HVRGlobalInputs.Instance.RightTrackPadRight;
                case HVRButtons.Trigger:
                    return left
                      ? HVRGlobalInputs.Instance.LeftTriggerButtonState
                      : HVRGlobalInputs.Instance.RightTriggerButtonState;
                case HVRButtons.TriggerNearTouch:
                    return left
                      ? HVRGlobalInputs.Instance.LeftTriggerNearTouchState
                      : HVRGlobalInputs.Instance.RightTriggerNearTouchState;
                case HVRButtons.TriggerTouch:
                    return left
                      ? HVRGlobalInputs.Instance.LeftTriggerTouchState
                      : HVRGlobalInputs.Instance.RightTriggerTouchState;
                default:
                    return HVRGlobalInputs.Instance.RightMenuButtonState;
            }
        }
	}
}