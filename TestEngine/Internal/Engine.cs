using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TestEngine
{
    /// <summary>
    /// The main engine class.
    /// </summary>
    public static class Engine
    {
        public static int MaxFPS { get; set; }
        public static int FrameStep { get; set; }
        public static int Time { get; private set; }
        public static float DeltaTime { get; private set; }
        public static bool IsRunning { get; private set; }
        public static Scene CurrentScene { get; private set; }

        public static List<Scene> Scenes = new List<Scene>();

        public static void LoadScene(Scene scene)
        {
            CurrentScene = Scenes.Find(x => scene != null);
        }

        public static GameObject FindGameObject(string name)
        {
            return CurrentScene._gameObjects.Find(x => x.Name == name);
        }

        public static T FindBehaviour<T>() where T : Behaviour
        {
            return CurrentScene.internalFindBehaviour(typeof(T)) as T;
        }

        public static void Initialize() // Execute on scene load
        {
            var internalTimer = Stopwatch.StartNew().Elapsed.Milliseconds;

            int skipTicks;
            //skipTicks = 1000 / MaxFPS;
            skipTicks = 1000;

            Time = internalTimer;
            int previousTime = 0;
            int loops;

            // Start
            for (int i = 0; i < CurrentScene._behaviours.Length; i++)
            {
                CurrentScene._behaviours[i].Start();
            }

            while (IsRunning)
            {
                loops = 0;

                // FixedUpdate
                for (int i = 0; i < CurrentScene._behaviours.Length; i++)
                {
                    CurrentScene._behaviours[i].FixedUpdate();
                }

                while (internalTimer > Time && loops < FrameStep)
                {
                    // Update
                    for (int i = 0; i < CurrentScene._behaviours.Length; i++)
                    {
                        CurrentScene._behaviours[i].Update();
                    }

                    Time += skipTicks;
                    loops++;
                }

                DeltaTime = (Time - previousTime) / 1000f;
                previousTime = internalTimer;

                //Draw game by DeltaTime
            }
        }

        public static void Kill()
        {
            IsRunning = false;
        }
    }
}
