using UnityEditor;
using UnityEngine;
namespace RollaBall
{
    public static partial class BuilderExtension
    {
         public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        public static GameObject AddRigidbody(this GameObject gameObject, float mass)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody>();
            component.mass = mass;
            return gameObject;
        }

        public static GameObject AddSphereCollider(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<SphereCollider>();
            return gameObject;
        }
        public static GameObject AddBoxCollider(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<BoxCollider>();
            return gameObject;
        }
        public static GameObject ChangeBoxColliderFloor(this GameObject gameObject)
        {
            gameObject.GetComponent<BoxCollider>().size = new Vector3(10,1,10);
            gameObject.GetComponent<BoxCollider>().center = new Vector3(0,-0.5f,0);
            return gameObject;
        }
        public static GameObject SetTrigger(this GameObject gameObject)
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            return gameObject;
        } 
        public static GameObject SetTag(this GameObject gameObject, string tag)
        {
            gameObject.tag = tag;
            return gameObject;
        }
        
        public static GameObject AddMaterial(this GameObject gameObject, Material material)
        {
            var component = gameObject.GetOrAddComponent<MeshRenderer>();
            component.material = material;
            return gameObject;
        }
        public static GameObject AddMeshSphere( this GameObject gameObject)
        {
            var component = gameObject.GetOrAddComponent<MeshFilter>();
            var m = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            
            component.mesh = m.GetComponent<MeshFilter>().mesh;
            GameObject.Destroy(m);
            return gameObject;
        }
        public static GameObject AddMeshCube( this GameObject gameObject)
        {
            var component = gameObject.GetOrAddComponent<MeshFilter>();
            var m = GameObject.CreatePrimitive(PrimitiveType.Cube);
            
            component.mesh = m.GetComponent<MeshFilter>().mesh;
            GameObject.Destroy(m);
            return gameObject;
        }
        public static GameObject AddMeshPlane( this GameObject gameObject)
        {
            var component = gameObject.GetOrAddComponent<MeshFilter>();
            var m = GameObject.CreatePrimitive(PrimitiveType.Plane);
            
            component.mesh = m.GetComponent<MeshFilter>().mesh;
            GameObject.Destroy(m);
            return gameObject;
        }
        public static GameObject ChangeRotation( this GameObject gameObject,Vector3 n)
        {
            gameObject.transform.Rotate(n);
            return gameObject;
        }
        public static GameObject ChangeScale( this GameObject gameObject,Vector3 n)
        {
            gameObject.transform.localScale += n;
            return gameObject;
        }
        public static GameObject ChangePosition( this GameObject gameObject,Vector3 n)
        {
            gameObject.transform.position += n;
            return gameObject;
        }

        private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }

            return result;
        }
    }
}