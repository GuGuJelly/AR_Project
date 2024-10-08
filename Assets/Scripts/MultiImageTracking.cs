using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MultiImageTracking : MonoBehaviour
{
    [SerializeField] ARTrackedImageManager imageManager;

    [SerializeField] GameObject IronMaskPrefab;
    [SerializeField] GameObject MarzanaPrefab;

    private void OnEnable()
    {
        imageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        // 새로운 이미지가 추적됐을때
        foreach (ARTrackedImage trackedImage in args.added)
        {
            // 이미지 라이브러리에서 이미지의 이름을 확인
            string imageName = trackedImage.referenceImage.name;

            // 새로운 게임오브젝트를 트래킹한 이미지의 자식으로 생성
            switch (imageName)
            {
                case "IronMask":
                    GameObject IronMask = Instantiate(IronMaskPrefab, trackedImage.transform.position, trackedImage.transform.rotation);
                    IronMask.transform.parent = trackedImage.transform;
                    break;
                case "Marzana":
                    GameObject Marzana = Instantiate(MarzanaPrefab, trackedImage.transform.position, trackedImage.transform.rotation);
                    Marzana.transform.parent = trackedImage.transform;
                    break;
            }
        }

        // 기존의 이미지가 변경(이동, 회전)됐을 때
        foreach (ARTrackedImage trackedImage in args.updated)
        {
            // 이미지의 변경사항이 있는 경우 자식으로 있던 게임오브젝트를 위치와 회전을 갱신
            // 이미지의 transform을 했을 때 첫번째 자식의 위치를 변경해준다
            trackedImage.transform.GetChild(0).position = trackedImage.transform.position;
            trackedImage.transform.GetChild(0).rotation = trackedImage.transform.rotation;
        }

        // 기존의 이미지가 사라졌을 때
        foreach (ARTrackedImage trackedImage in args.removed)
        {
            // 이미지가 사라진 경우 자식으로 있었던 게임오브젝트를 삭제
            Destroy(trackedImage.transform.GetChild(0).gameObject);
        }
    }
}
