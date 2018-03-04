using FlyweightPattern.Interface;
using System;
using System.Collections.Generic;

namespace FlyweightPattern.Factory
{
    public static class CharacterFactory
    {
        private static Dictionary<char, ICharacter> _characters = new Dictionary<char, ICharacter>();

        public static ICharacter GetOrAddCharacter(char key)
        {
            if(_characters.ContainsKey(key))
            {
                return _characters[key];
            }
            else
            {
                Type type = Type.GetType($"FlyweightPattern.Flyweights.Character{key}", true, true);
                var instance = (ICharacter)Activator.CreateInstance(type);
                _characters.Add(key, instance);
                return instance;
            }
        }
    }
}
