using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CaseStudy
{



    public static class Input
    {
        public static CharacterInput Actions
        {
            get { return _actions ?? (_actions = new CharacterInput()); }
        }

        private static CharacterInput _actions;
    }

    public interface IInput
    {
        void InitControls();
        void DeinitControls();
    }
}