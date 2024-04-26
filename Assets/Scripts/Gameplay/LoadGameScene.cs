using System.Collections;
using CoroutineSystem;
using ItemSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Game.Constants;
using Random = UnityEngine.Random;
using UnityEngine.UI;

namespace SceneSystem
{
    public class LoadGameScene
    {
        public LoadGameScene(ItemController itemController, CoroutineHandler coroutineHandler)
        {
            var loaderImg = itemController.GetImage(ImageViewID + ImageObject.Loader);
            var loaderImgBg = itemController.GetImage(ImageViewID + ImageObject.LoaderBg);

            itemController.SetActiveBtn(ButtonViewID + ButtonObject.LoadGameScene, true);
            loaderImgBg.gameObject.SetActive(false);

            itemController.SetAction(ButtonViewID + ButtonObject.LoadGameScene, () =>
            {
                itemController.SetActiveBtn(ButtonViewID + ButtonObject.LoadGameScene, false);
                loaderImgBg.gameObject.SetActive(true);
                
                coroutineHandler.StartActiveCoroutine(StartAnimation(loaderImg));
            });
        }

        private IEnumerator StartAnimation(Image img)
        {
            img.fillAmount = 0;
            do
            {
                yield return new WaitForSeconds(0.1f);
                var value = Random.Range(0, 0.1f);
                img.fillAmount += value;
            } while (img.fillAmount != 1);

            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(NumGameScene);
        }
    }
}