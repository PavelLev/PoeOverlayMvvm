using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PoeOverlayMvvm.Utility
{
    public static class TaskExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] // Causes compiler to optimize the call away
        public static void NoWarning(this Task task) { /* No code goes in here */ }
    }
}
