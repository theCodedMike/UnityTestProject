using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class EditorPlus : UnityEditor.Editor
    {
        [MenuItem("MyTools/ChangeColorToGreen")]
        static void ChangeColorToGreen()
        {
            MeshRenderer[] gbs = GameObject.FindObjectsOfType<MeshRenderer>();
            foreach (var gb in gbs)
            {
                gb.sharedMaterial.color = Color.green;
            }
            
            // 如果资源在Editor/Resources文件下内，则资源path必须写全，例如"Assets/Editor/Resources/Right.jpg"
            // 如果资源在Editor Default Resources文件夹内，则资源path写资源的名字即可，例如"Right2.png"
            Object pic = EditorGUIUtility.Load("Right2.png");
            Debug.Log(pic.name); // Right2
        }
    
        [MenuItem("MyTools/ChangeColorToWhite")]
        static void ChangeColorToWhite()
        {
            MeshRenderer[] gbs = GameObject.FindObjectsOfType<MeshRenderer>();
            foreach (var gb in gbs)
            {
                gb.sharedMaterial.color = Color.white;
            }
        }
    }

}
