using UnityEngine;

public class ConnectionManager : MonoBehaviour
{
    public static ConnectionManager Instance;

    private IOutput _draggingFrom;

    void Update()
    {
        // Detecta mouse y actualiza línea provisional
    }

    public void StartDragging(IOutput from)
    {
        _draggingFrom = from;
    }

    public void StopDragging(IInput to)
    {
        /*
        if (to.IsInput && _draggingFrom.Type == to.Type)
        {
            // Crear conexión final
        }*/

        _draggingFrom = null;
    }
}