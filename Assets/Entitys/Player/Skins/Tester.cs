using Spine;
using Spine.Unity;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation _graphic;
    [SerializeField] private Sprite _mesh;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var slot = _graphic.Skeleton.Skin;
            _graphic.Update(0);
        }
    }
}
