using UnityEngine;

namespace Infrastructure
{
    public class InputServices : IInputServices
    {
        public Vector2 Axis
        {
            get
            {
                return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
        }
    }
}