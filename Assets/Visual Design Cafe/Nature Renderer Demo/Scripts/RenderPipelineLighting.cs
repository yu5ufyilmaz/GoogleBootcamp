namespace NatureRendererDemo
{
    using UnityEngine;
#if UNITY_EDITOR
    using VisualDesignCafe.ShaderX.Editor.Drops;
#endif

    [ExecuteInEditMode]
    public class RenderPipelineLighting : MonoBehaviour
    {
        [Header( "Input" )]
        [SerializeField]
        private GameObject _legacyInputSystem;

        [SerializeField]
        private GameObject _newInputSystem;

        [Header( "Standard" )]
        [SerializeField]
        private GameObject _standardLighting;

        [SerializeField]
        private Material _standardSky;

        [SerializeField]
        private Material _standardTerrain;

        [SerializeField]
        private GameObject _standardVolume;

        [SerializeField]
        private Material _standardLineMaterial;

        [SerializeField]
        private Material _standardCameraIconMaterial;

        [Header( "Universal" )]
        [SerializeField]
        private GameObject _universalLighting;

        [SerializeField]
        private Material _universalSky;

        [SerializeField]
        private Material _universalTerrain;

        [SerializeField]
        private GameObject _universalVolume;

        [SerializeField]
        private Material _universalLineMaterial;

        [SerializeField]
        private Material _universalCameraIconMaterial;

        [Header( "HD" )]
        [SerializeField]
        private GameObject _highDefinitionLighting;

        [SerializeField]
        private Material _highDefinitionSky;

        [SerializeField]
        private GameObject _highDefinitionVolume;

        [SerializeField]
        private Material _highDefinitionTerrain;

        [SerializeField]
        private Material _highDefinitionLineMaterial;

        [SerializeField]
        private Material _highDefinitionCameraIconMaterial;

        private void OnValidate()
        {
            Awake();
        }

        private void Awake()
        {
#if UNITY_EDITOR

            if( Application.isPlaying )
            {
#if ENABLE_INPUT_SYSTEM
                _legacyInputSystem.SetActive( false );
                _newInputSystem.SetActive( true );
#else
                _legacyInputSystem.SetActive( true );
                _newInputSystem.SetActive( false );
#endif
            }

            var renderPipeline = new RenderPipeline();

            if( _standardVolume != null )
                _standardVolume.SetActive( renderPipeline.Type == RenderPipelineType.Standard );

            if( _universalVolume != null )
                _universalVolume.SetActive( renderPipeline.Type == RenderPipelineType.Universal );

            if( _highDefinitionVolume != null )
                _highDefinitionVolume.SetActive( renderPipeline.Type == RenderPipelineType.HighDefinition );

            if( _standardLighting != null )
                _standardLighting.SetActive( renderPipeline.Type == RenderPipelineType.Standard );

            if( _universalLighting != null )
                _universalLighting.SetActive( renderPipeline.Type == RenderPipelineType.Universal );

            if( _highDefinitionLighting != null )
                _highDefinitionLighting.SetActive( renderPipeline.Type == RenderPipelineType.HighDefinition );

            switch( renderPipeline.Type )
            {
                case RenderPipelineType.Standard:
                    RenderSettings.skybox = _standardSky;
                    SetTerrainMaterial( _standardTerrain );
                    SetLineMaterial( _standardLineMaterial );
                    SetCameraIconMaterial( _standardCameraIconMaterial );
                    break;
                case RenderPipelineType.Universal:
                    RenderSettings.skybox = _universalSky;
                    SetTerrainMaterial( _universalTerrain );
                    SetLineMaterial( _universalLineMaterial );
                    SetCameraIconMaterial( _universalCameraIconMaterial );
                    break;
                case RenderPipelineType.HighDefinition:
                    RenderSettings.skybox = _highDefinitionSky;
                    SetTerrainMaterial( _highDefinitionTerrain );
                    SetLineMaterial( _highDefinitionLineMaterial );
                    SetCameraIconMaterial( _highDefinitionCameraIconMaterial );
                    break;
            }
#endif
        }

#if UNITY_EDITOR
        private void SetTerrainMaterial( Material material )
        {
            foreach( var terrain in FindObjectsOfType<Terrain>( true ) )
                terrain.materialTemplate = material;
        }

        private void SetLineMaterial( Material material )
        {
            if( material == null )
                return;

            foreach( var renderer in FindObjectsOfType<LineRenderer>( true ) )
                renderer.sharedMaterial = material;
        }

        private void SetCameraIconMaterial( Material material )
        {
            if( material == null )
                return;

            foreach( var renderer in FindObjectsOfType<ParticleSystemRenderer>( true ) )
                renderer.sharedMaterial = material;
        }
#endif
    }
}