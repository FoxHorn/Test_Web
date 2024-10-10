using Unity.Burst;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.U2D;
using UnityEngine.UI;

[BurstCompile]
public class SpriteGallery : MonoBehaviour
{
    [SerializeField] private string atlasAddress;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private GameObject galleryItemPrefab;

    private bool isShowed;

    public void ShowGallery()
    {
        if (!isShowed) LoadAtlass();
    }

    private void LoadAtlass()
    {
        isShowed = true;
        Addressables.LoadAssetAsync<SpriteAtlas>(atlasAddress).Completed += OnAtlasLoaded;
    }

    private void FillGallery(SpriteAtlas atlas)
    {
        Sprite[] sprites = new Sprite[atlas.spriteCount];
        atlas.GetSprites(sprites);
        foreach (var sprite in sprites)
        {
            Image imageGallery = Instantiate(galleryItemPrefab, parentTransform).GetComponent<Image>();
            imageGallery.name = sprite.name;
            imageGallery.sprite = sprite;
        }
    }

    private void OnAtlasLoaded(AsyncOperationHandle<SpriteAtlas> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            SpriteAtlas atlas = handle.Result;
            FillGallery(atlas);
        }
        else
        {
            Debug.LogError("Failed to load SpriteAtlas.");
            isShowed = false;
        }
    }
}
