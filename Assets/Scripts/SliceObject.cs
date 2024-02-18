using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.InputSystem;
using Oculus.Interaction;
using System.Reflection;
using Oculus.Interaction.HandGrab;

public class SliceObject : MonoBehaviour
{
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator;
    public VelocityTracker velocityTracker;
    public Material crossSectionMaterial;
    public float cutForce;
    public LayerMask sliceableLayer;
    public GameObject grabbablePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if (hasHit)
        {
            if (velocityTracker.atChoppingSpeed)
            {
                GameObject target = hit.transform.gameObject;
                Slice(target);
            }
        }

        
    }

    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);

        if (hull != null )
        {
            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);
            SetUpSlicedComponent(upperHull);

            GameObject lowerHull = hull.CreateLowerHull(target, crossSectionMaterial);
            SetUpSlicedComponent(lowerHull);



            Destroy(target);
        }

    }

    public void SetUpSlicedComponent(GameObject slicedGameObject)
    {
        //Rigibody
        Rigidbody rb = slicedGameObject.AddComponent<Rigidbody>();
        //rb.AddExplosionForce(cutForce, slicedGameObject.transform.position, 0.000000001f);
        // Coillider
        MeshCollider collider = slicedGameObject.AddComponent<MeshCollider>();
        collider.convex = true;

        // Setting the Sliceable layer

        slicedGameObject.layer = LayerMask.NameToLayer("Sliceable");


        // Grababble
        Grabbable gb = slicedGameObject.AddComponent<Grabbable>();
        gb.TransferOnSecondSelection = true;

        // HandGrabInteractable
        HandGrabInteractable hg = slicedGameObject.AddComponent<HandGrabInteractable>();
        hg.InjectRigidbody(rb);
        hg.InjectSupportedGrabTypes(Oculus.Interaction.Grab.GrabTypeFlags.All);
        hg.HandAlignment = HandAlignType.None;
        hg.InjectOptionalPointableElement(gb);

        // SnapInteractor
        //SnapInteractor snap = slicedGameObject.AddComponent<SnapInteractor>();
        //snap.InjectPointableElement(gb);
        //snap.InjectRigidbody(rb);

        PlaceSandwichElement element = slicedGameObject.AddComponent<PlaceSandwichElement>();
        slicedGameObject.tag = "Sliceable";
        //// PointableElement pe = slicedGameObject.AddComponent<PointableElement>();
        //InteractableGroupView gv = slicedGameObject.AddComponent<InteractableGroupView>();
        //List<IInteractableView> interactables = new List<IInteractableView>
        //{
        //    hg
        //};
        //gv.InjectInteractables(interactables);

        // Pointable Unity Event Wrapper
        ////PointableUnityEventWrapper ew = slicedGameObject.AddComponent<PointableUnityEventWrapper>();
        ////ew.InjectPointable(gb);
        //ew.WhenSelect.Invoke(sliceObject.DeactivateGrab());

        // ////List<>
        // ////gv.InjectInteractables(0) = gb;
    }
}
