using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Image imageLoding;

    public bool autoActive = true;

    //Use for init the parameters of class
    private void Start() {
        if (autoActive) {
            Fade(1, 0, delegate { imageLoding.gameObject.SetActive(false); });
        }
    }

    public void Fade(float _time, float _alphaTarget, Action _callback = null) {
        imageLoding.gameObject.SetActive(true);
        StartCoroutine(RutineFade(_time, _alphaTarget, _callback));
    }

    IEnumerator RutineFade(float _time, float _alphaTarget, Action _callback) {
        imageLoding.CrossFadeAlpha(_alphaTarget, _time, false);
        yield return new WaitForSeconds(_time);
        _callback?.Invoke();
    }
}
