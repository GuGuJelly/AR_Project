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
        // ���ο� �̹����� ����������
        foreach (ARTrackedImage trackedImage in args.added)
        {
            // �̹��� ���̺귯������ �̹����� �̸��� Ȯ��
            string imageName = trackedImage.referenceImage.name;

            // ���ο� ���ӿ�����Ʈ�� Ʈ��ŷ�� �̹����� �ڽ����� ����
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

        // ������ �̹����� ����(�̵�, ȸ��)���� ��
        foreach (ARTrackedImage trackedImage in args.updated)
        {
            // �̹����� ��������� �ִ� ��� �ڽ����� �ִ� ���ӿ�����Ʈ�� ��ġ�� ȸ���� ����
            // �̹����� transform�� ���� �� ù��° �ڽ��� ��ġ�� �������ش�
            trackedImage.transform.GetChild(0).position = trackedImage.transform.position;
            trackedImage.transform.GetChild(0).rotation = trackedImage.transform.rotation;
        }

        // ������ �̹����� ������� ��
        foreach (ARTrackedImage trackedImage in args.removed)
        {
            // �̹����� ����� ��� �ڽ����� �־��� ���ӿ�����Ʈ�� ����
            Destroy(trackedImage.transform.GetChild(0).gameObject);
        }
    }
}
