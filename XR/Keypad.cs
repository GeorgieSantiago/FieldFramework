namespace Field.XR
{
    using HurricaneVR.Framework.Components;
    using TMPro;
    using UnityEngine;
    using UnityEngine.Events;
    using GameCreator.Core;
    using GameCreator.Variables;
    public class Keypad : MonoBehaviour
    {
        public static string EVENT_UNLOCK_NAME = "FIELD_KEYPAD_EVENT_UNLOCK";
        public static string EVENT_FORCE_UNLOCK_NAME = "FIELD_KEYPAD_EVENT_FORCE_UNLOCK";
        public StringProperty Code;
        public StringProperty Entry;
        public int Index => Entry.GetValue(gameObject)?.Length ?? 0;

        public int MaxLength => Code.GetValue(gameObject)?.Length ?? 0;
        public TMP_Text Display;
        private bool _unlocked;

        protected virtual void Start()
        {
            var buttons = GetComponentsInChildren<KeypadButton>();
            var colliders = GetComponentsInChildren<Collider>();

            foreach (var keyCollider in colliders)
            {
                foreach (var ourCollider in GetComponents<Collider>())
                {
                    Physics.IgnoreCollision(ourCollider, keyCollider);
                }
            }

            for (int i = 0; i < buttons.Length; i++)
            {
                var button = buttons[i];
                button.ButtonDown.AddListener(OnButtonDown);
                if (i >= 0 && i <= 9)
                {
                    button.Key = i.ToString()[0];
                }
                else if (i == 10)
                {
                    button.Key = '<';
                }
                else if (i == 11)
                {
                    button.Key = '+';
                }

                if (button.TextMeshPro)
                {
                    button.TextMeshPro.text = button.Key.ToString();
                }
            }

            if (Display)
            {
                Display.text = Entry
                  .GetValue(gameObject)
                  .PadLeft(MaxLength, '*');
            }
        }

        protected virtual void OnButtonDown(HVRPhysicsButton button)
        {
            var keyPadButton = button as KeypadButton;

            if (keyPadButton.Key == '<')
            {
                if (Entry.GetValue(gameObject).Length > 0)
                {
                    string entry = Entry.GetValue(gameObject);
                    Entry.value = entry.Substring(0, entry.Length - 1);
                }
                else
                {
                    return;
                }
            }
            else if (keyPadButton.Key == '+')
            {
                if (Code == Entry)
                {
                    Unlock();
                }
            }
            else if (Index >= 0 && Index < MaxLength)
            {
                Entry.value += keyPadButton.Key;
            }

            if (Display)
            {
                Display.text = Entry
                  .GetValue(gameObject)
                  .PadLeft(MaxLength, '*');
            }
        }

        protected virtual void Unlock()
        {
            _unlocked = true;
        }
    }
}