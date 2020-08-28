using GTA;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeFunctionHookV
{
    /// <summary>
    /// Controls and alters, checks for general game behaivor.
    /// </summary>
    public static class NGame
    {
        /// <summary>
        /// Sets a value indicating whether game should play ambient siren sound effect.
        /// </summary>
        public static bool PlayAmbientSirenEffect
        {
            set
            {
                Function.Call(Hash._FORCE_AMBIENT_SIREN, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether player head is shown in pause menu.
        /// </summary>
        public static bool ShowPlayerHeadInPauseMenu
        {
            set => Function.Call(Hash._SET_PLAYER_IS_IN_ANIMAL_FORM, value);
            get => Function.Call<bool>(Hash.GET_IS_PLAYER_IN_ANIMAL_FORM);
        }

        /// <summary>
        /// Sets whether disables rockstar editor in current session.
        /// </summary>
        public static bool DisableRockstarEditor
        {
            set => Function.Call(Hash._SET_PLAYER_ROCKSTAR_EDITOR_DISABLED, value);
        }

        /// <summary>
        /// Gets or sets whether enables heat vision.
        /// </summary>
        public static bool HeatVision
        {
            get => Function.Call<bool>(Hash.GET_USINGSEETHROUGH);
            set => Function.Call(Hash.SET_SEETHROUGH, value);
        }

        /// <summary>
        /// Gets a value indicating whether is player signed into Social Club or not. Beware, it related to social club.
        /// </summary>
        public static bool IsSignedIntoSocialClub => Function.Call<bool>(Hash.NETWORK_IS_SIGNED_IN);

        /// <summary>
        /// Gets a value indicating whether is displaying black loading screen, caused by <see cref="FadeScreenOut(int)"/> or player wasted/busted.
        /// </summary>
        public static bool IsScreenFadedOut => Function.Call<bool>(Hash.IS_SCREEN_FADED_OUT);

        /// <summary>
        /// Gets a value indicating whether the <see cref="FadeScreenOut(int)"/> is in progress.
        /// </summary>
        public static bool IsScreenFadingOut => Function.Call<bool>(Hash.IS_SCREEN_FADING_OUT);

        /// <summary>
        /// Gets a value indicating whether the <see cref="FadeScreenIn(int)"/> is done.
        /// </summary>
        public static bool IsScreenFadedIn => Function.Call<bool>(Hash.IS_SCREEN_FADED_IN);

        /// <summary>
        /// Gets a value indicating whether the <see cref="FadeScreenIn(int)"/> is in progress.
        /// </summary>
        public static bool IsScreenFadingIn => Function.Call<bool>(Hash.IS_SCREEN_FADING_IN);

        /// <summary>
        /// Gets or sets a value indicating whether a mission is in progress.
        /// Sets this value may block some game interactivity features.
        /// </summary>
        public static bool IsMissionActive
        {
            get => Function.Call<bool>(Hash.GET_MISSION_FLAG);
            set => Function.Call(Hash.SET_MISSION_FLAG, value);
        }

        /// <summary>
        /// Gets or sets whether the game is paused.
        /// When game paused, only the calling thread is not paused.
        /// </summary>
        public static bool IsPaused
        {
            set => Function.Call(Hash.SET_GAME_PAUSED, value);
        }

        /// <summary>
        /// Gets a value indicating whether the loading screen is active.
        /// </summary>
        public static bool IsLoading
        {
            get => Function.Call<bool>(Hash.GET_IS_LOADING_SCREEN_ACTIVE);
        }

        /// <summary>
        /// Displays help text in left top help box.
        /// </summary>
        /// <param name="message">The text content.</param>
        /// <param name="duration">The duration of this text help.</param>
        /// <param name="sound">Whether it sounds when displaying help.</param>
        public static void DisplayHelp(string message, int duration = 8000, bool sound = true)
        {
            Function.Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_HELP, "STRING");
            Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, message);
            Function.Call(Hash.END_TEXT_COMMAND_DISPLAY_HELP, 0, false, sound, duration);

        }

        /// <summary>
        /// Display a line of text in subtitle bar at mid-bottom of screen.
        /// </summary>
        /// <param name="message">The text content.</param>
        /// <param name="duration">The duration of this subtitle display.</param>
        /// <param name="replacePrevious">If set to <c>true</c>, the subtitle will immedately show and replace previous subtitle. If set to <c>false</c>, it will be shown when previous subtitle has finished it's duration.</param>
        public static void DisplaySubtitle(string message, int duration = 8000, bool replacePrevious = true)
        {
            Function.Call(Hash.BEGIN_TEXT_COMMAND_PRINT, "STRING");
            Function.Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, message);
            Function.Call(Hash.END_TEXT_COMMAND_PRINT, 8000, replacePrevious);
        }

        /// <summary>
        /// Fades screen in from black loading screen over specified amount of time.
        /// </summary>
        /// <param name="duration">Duration of the fade in process, in milliseconds.</param>
        public static void FadeScreenIn(int duration)
        {
            Function.Call(Hash.DO_SCREEN_FADE_IN, duration);
        }

        /// <summary>
        /// Fades screen out to black loading screen over specified amount of time.
        /// </summary>
        /// <param name="duration">Duration of the fade out process, in milliseconds.</param>
        public static void FadeScreenOut(int duration)
        {
            Function.Call(Hash.DO_SCREEN_FADE_OUT, duration);
        }

        /// <summary>
        /// Gets whether the specified achievement has been passed.
        /// </summary>
        /// <param name="achievement">Achievement value.</param>
        public static void HasAchievementBeenPassed(int achievement)
        {
            Function.Call(Hash.HAS_ACHIEVEMENT_BEEN_PASSED, achievement);
        }

        /// <summary>
        /// Converts string to hash.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <returns>The hash.</returns>
        public static int GetHashKey(string source)
        {
            if(string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentException("The source is null or empty, or whitespaces.");
            }

            return Function.Call<int>(Hash.GET_HASH_KEY, source);
        }
    }
}
