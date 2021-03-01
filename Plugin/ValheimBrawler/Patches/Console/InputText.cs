using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using ValheimBrawler.Utils;
using GameConsole = Console;

namespace ValheimBrawler.Patches.Console
{
    /// <summary>
    ///     Example harmony Prefix patch for in-game console input. Replace with your patching.
    /// </summary>
    [HarmonyPatch(typeof(GameConsole), "InputText")]
    public static class InputText
    {
        public static void Prefix()
        {
            var console = GameConsole.instance;
            var input = console.m_input.text;

            // hook into the console, can use later
        }
    }
}
