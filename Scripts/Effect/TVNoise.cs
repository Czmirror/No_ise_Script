using UnityEngine;

namespace _No_ise.Scripts.Effect
{
    public class TVNoise : MonoBehaviour
    {
        [SerializeField] private Material noiseMat;
        [SerializeField] private float noiseSpeed = 1.0f;
        private float noiseTime = 0f;
        private bool isNoiseActive = true;

        void Update()
        {
            if (isNoiseActive)
            {
                noiseTime += Time.deltaTime * noiseSpeed;
                float noiseVal = Mathf.PerlinNoise(noiseTime, 0f);
                noiseMat.SetFloat("_NoiseStrength", noiseVal);
            }
        }

        public void StopNoise()
        {
            isNoiseActive = false;
            noiseMat.SetFloat("_NoiseStrength", 0f);
        }
    }
}
