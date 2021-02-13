using System;
using System.Runtime.InteropServices;
using System.Security;

namespace CoreLibrary.CharacterModels
{
    public abstract class Character : IComparable, IComparable<Character>
    {
        public virtual string Name { get; set; } = "";
        public virtual string Reading { get; set; } = "";
        public virtual VoiceActor? VoiceActor { get; set; }

        public int CompareTo(object? obj)
        {
            if (obj == this)
            {
                return 0;
            }

            if (obj is not Character)
            {
                return -1;
            }

            var character = obj as Character;
            return CompareTo(character);
        }

        public int CompareTo(Character? other)
        {
            return NativeMethods.StrCmpLogicalW(Reading, other?.Reading);
        }

        public abstract string ScriptToOutputText(string script);

        [SuppressUnmanagedCodeSecurity]
        private static class NativeMethods
        {
            [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
            public static extern int StrCmpLogicalW(string? psz1, string? psz2);
        }
    }
}
