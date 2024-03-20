using UnityEngine;
using System;

namespace UI
{

    public static class MainMenuEventHub
    {
        public static Action OnNewGameButtonPressedAction;
        public static Action OnContinueButtonPressedAction;
        public static Action OnSettingsButtonPressedAction;
        public static Action OnExitButtonPressedAction;

        public static void NewGameButtonPressed() => OnNewGameButtonPressedAction?.Invoke();

        public static void ContinueButtonPressed() => OnContinueButtonPressedAction?.Invoke();

        public static void SettingsButtonPressed() => OnSettingsButtonPressedAction?.Invoke();

        public static void ExitButtonPressed() => OnExitButtonPressedAction?.Invoke();

    }
}