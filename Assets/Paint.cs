using UnityEngine;
using Es.InkPainter;
using UnityEngine.VR.WSA.Input;

public class Paint : MonoBehaviour
{

    [SerializeField]
    private Brush brush;

    private bool pressflag = false;

    private void Start()
    {
        InteractionManager.SourceUpdated += InteractionManager_SourceUpdated;
        InteractionManager.SourcePressed += InteractionManager_SourcePressed;
        InteractionManager.SourceReleased += InteractionManager_SourceReleased;
    }

    private void Update()
    {

    }

    void InteractionManager_SourceUpdated(InteractionSourceState state)
    {
        if (pressflag == true)
        {
            Vector3 v;
            state.properties.location.TryGetPosition(out v);
            RaycastHit hitInfo;
            if (Physics.Raycast(v, Camera.main.transform.forward, out hitInfo))
            {
                var paintObject = hitInfo.transform.GetComponent<InkCanvas>();
                if (paintObject != null) paintObject.Paint(brush, hitInfo);
            }
        }

    }

    void InteractionManager_SourcePressed(InteractionSourceState state)
    {
        pressflag = true;
    }

    void InteractionManager_SourceReleased(InteractionSourceState state)
    {
        pressflag = false;
    }
}
