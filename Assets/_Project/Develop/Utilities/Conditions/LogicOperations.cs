using UnityEngine;

namespace Utilities.Conditions
{
    public class LogicOperations : MonoBehaviour
    {
        public static bool And(bool a, bool b) => a && b;
        public static bool Or(bool a, bool b) => a || b;
    }
}
