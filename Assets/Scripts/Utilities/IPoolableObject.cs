namespace developer0223
{
    // Unity
    using UnityEngine;

    public interface IPoolableObject
    {
        bool GetActived();

        GameObject GetReferenceObject();

        void Active();

        void Active(Vector3 position);

        void Active(Vector3 position, Quaternion rotation, Vector3 scale);

        void DeActive();
    }
}